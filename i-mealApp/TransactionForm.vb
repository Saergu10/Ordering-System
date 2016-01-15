Imports System.Data.SqlClient

Public Class TransactionForm
    ' DB variables
    Dim connection As SqlConnection
    Dim sqlCommand As SqlCommand
    Dim dataAdaptor As New SqlDataAdapter
    Dim dataTable As DataTable

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

        displayTransactionTable()
    End Sub

    Private Sub displayTransactionTable()
        TransactionOrderTable.Rows.Clear()
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
    End Sub
End Class