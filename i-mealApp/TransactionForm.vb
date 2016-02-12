Imports System.Data.SqlClient

Public Class TransactionForm
    Const Tax_Rate = 0.07
    Dim selectedTransactionIndex = -1
    Dim selectedTransactionId

    ' DB variables
    Dim connection As SqlConnection
    Dim dataAdaptor As New SqlDataAdapter

    Private Sub TransactionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim connectPath As String = Application.StartupPath.ToString() + "\i-meal.mdf"
        Dim connectString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + connectPath + ";Integrated Security=True;User Instance=True"
        connection = New SqlConnection(connectString)
        Try
            connection.Open()
        Catch ex As Exception
            Print("connection error: " + ex.ToString)
        End Try
        TransactionTable.ColumnCount = 6
        TransactionTable.ColumnHeadersVisible = True
        TransactionTable.RowHeadersVisible = False
        TransactionTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        TransactionTable.Columns(0).Name = "Transaction ID"
        TransactionTable.Columns(1).Name = "User ID"
        TransactionTable.Columns(2).Name = "Total Price"
        TransactionTable.Columns(3).Name = "Date"
        TransactionTable.Columns(4).Name = "Status"
        TransactionTable.Columns(5).Name = "Remark"

        TransactionOrderTable.ColumnCount = 3
        TransactionOrderTable.ColumnHeadersVisible = True
        TransactionOrderTable.RowHeadersVisible = False
        TransactionOrderTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        TransactionOrderTable.Columns(0).Name = "Food ID"
        TransactionOrderTable.Columns(1).Name = "Quantity"
        TransactionOrderTable.Columns(2).Name = "Price"

        SummaryTable.ColumnCount = 2
        SummaryTable.ColumnHeadersVisible = False
        SummaryTable.RowHeadersVisible = False
        SummaryTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        SummaryTable.Columns(0).Name = "Specification"
        SummaryTable.Columns(1).Name = "Price"

        displayTransactionTable()
    End Sub

    Private Sub displayTransactionTable()
        TransactionTable.Rows.Clear()
        TransactionOrderTable.Rows.Clear()
        SummaryTable.Rows.Clear()
        Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM [Transaction]", connection)
        dataAdaptor.SelectCommand = sqlCommand

        ' retrieve query feedback
        Dim cmdBuilder As New SqlCommandBuilder(dataAdaptor)
        Dim dataTable As New DataTable
        dataAdaptor.Fill(dataTable)

        For index As Integer = 1 To dataTable.Rows.Count
            Dim transactionInfo = dataTable.Rows(index - 1)
            TransactionTable.Rows.Add(transactionInfo("ID"), transactionInfo("User_Id"), Format(transactionInfo("Price"), "0.00"))
        Next

        TransactionTable.ClearSelection()
    End Sub

    Private Sub TransactionTable_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TransactionTable.CellClick
        TransactionTable.CurrentRow.Selected = True
        selectedTransactionIndex = TransactionTable.CurrentRow.Index
        selectedTransactionId = TransactionTable.Item(0, selectedTransactionIndex).Value
        displaySelectedTransactionOder(selectedTransactionId)

        TransactionOrderTable.ClearSelection()
        SummaryTable.ClearSelection()
    End Sub

    Private Sub displaySelectedTransactionOder(ByVal transactionId As Integer)
        TransactionOrderTable.Rows.Clear()
        Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM TransactionOrder WHERE Transaction_Id = @id", connection)
        sqlCommand.Parameters.Add("@id", SqlDbType.Int)
        sqlCommand.Parameters("@id").Value = transactionId
        dataAdaptor.SelectCommand = sqlCommand

        ' retrieve query feedback
        Dim cmdBuilder As New SqlCommandBuilder(dataAdaptor)
        Dim dataTable As New DataTable
        dataAdaptor.Fill(dataTable)

        For index As Integer = 1 To dataTable.Rows.Count
            Dim transactionInfo = dataTable.Rows(index - 1)
            Dim qty = transactionInfo("Qty")
            Dim price As Integer = getFoodPrice(transactionInfo("Food_Id")) * qty
            TransactionOrderTable.Rows.Add(transactionInfo("Food_Id"), qty, Format(price, "0.00"))
        Next

        updateSummaryTable()
    End Sub

    Private Function getFoodPrice(ByVal id)
        Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM Food WHERE ID = @id", connection)
        sqlCommand.Parameters.Add("@id", SqlDbType.Int)
        sqlCommand.Parameters("@id").Value = id
        dataAdaptor.SelectCommand = sqlCommand

        ' retrieve query feedback
        Dim cmdBuilder As New SqlCommandBuilder(dataAdaptor)
        Dim dataTable As New DataTable
        dataAdaptor.Fill(dataTable)

        Return dataTable.Rows(0)("Price")
    End Function

    Private Sub updateSummaryTable()
        Dim subTotal As Decimal = 0
        Dim tax As Decimal = 0
        Dim total As Decimal = 0

        For index As Integer = 1 To TransactionOrderTable.Rows.Count
            subTotal += TransactionOrderTable.Item(2, index - 1).Value
        Next

        tax = subTotal * Tax_Rate
        total = subTotal + tax
        SummaryTable.Rows.Clear()
        SummaryTable.Rows.Add("SubTotal: ", Format(subTotal, "0.00"))
        SummaryTable.Rows.Add("GST: ", Format(tax, "0.00"))
        SummaryTable.Rows.Add("Total: ", Format(total, "0.00"))
    End Sub

    Private Sub Done_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Done.Click
        Me.Close()
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        If (selectedTransactionIndex >= 0) Then
            Dim result As Integer = MessageBox.Show("Are you sure to delete this transaction?", "", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                ' delete current transaction form DB
                Dim sqlCommand As SqlCommand = New SqlCommand("DELETE FROM TransactionOrder WHERE Transaction_Id = @id", connection)
                sqlCommand.Parameters.Add("@id", SqlDbType.Int)
                sqlCommand.Parameters("@id").Value = selectedTransactionId
                sqlCommand.ExecuteNonQuery()

                sqlCommand = New SqlCommand("DELETE FROM [Transaction] WHERE ID = @id", connection)
                sqlCommand.Parameters.Add("@id", SqlDbType.Int)
                sqlCommand.Parameters("@id").Value = selectedTransactionId
                sqlCommand.ExecuteNonQuery()

                ' reset transactionIndex value
                selectedTransactionIndex = -1

                ' update transaction table
                displayTransactionTable()
            End If
        Else
            MsgBox("You need to select a transaction to delete!")
        End If
    End Sub
End Class