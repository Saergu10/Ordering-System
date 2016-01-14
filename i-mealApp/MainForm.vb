﻿Imports System.Data.SqlClient

Public Class MainForm
    ' DB variables
    Dim connection As SqlConnection
    Dim sqlCommand As SqlCommand
    Dim dataAdaptor As New SqlDataAdapter
    Dim dataTable As DataTable

    ' Panel Arrays
    Dim panelPictureBoxArray() As PictureBox
    Dim panelLableItemArray() As Label
    Dim panelAddButtonArray() As Button
    Dim panelRemoveButtonArray() As Button

    ' Order variables
    Dim customerId As Integer
    Dim orderDataDictionary As Dictionary(Of Integer, Integer)

    Const Tax_Rate = 0.07
    Dim subTotal As Decimal
    Dim tax As Decimal
    Dim total As Decimal

    Private Sub evmBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles evmBtn.Click
        DisplayFoodCategory(1)
    End Sub

    Private Sub vmdBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vmdBtn.Click
        DisplayFoodCategory(2)
    End Sub

    Private Sub hmBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hmBtn.Click
        DisplayFoodCategory(3)
    End Sub

    Private Sub burgerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles burgerBtn.Click
        DisplayFoodCategory(4)
    End Sub

    Private Sub ffnBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ffnBtn.Click
        DisplayFoodCategory(5)
    End Sub

    Private Sub saladBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saladBtn.Click
        DisplayFoodCategory(6)
    End Sub

    Private Sub beverageBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles beverageBtn.Click
        DisplayFoodCategory(7)
    End Sub

    Private Sub DessertsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DessertsBtn.Click
        DisplayFoodCategory(8)
    End Sub

    Private Sub DisplayFoodCategory(ByVal categoryID As Integer)
        ' setup sql query
        sqlCommand = New SqlCommand("SELECT * FROM Food WHERE Food_Cate_id = @id", connection)
        sqlCommand.Parameters.Add("@id", SqlDbType.Int)
        sqlCommand.Parameters("@id").Value = categoryID

        dataAdaptor.SelectCommand = sqlCommand

        ' retrieve query feedback
        Dim cmdBuilder As New SqlCommandBuilder(dataAdaptor)
        dataTable = New DataTable
        dataAdaptor.Fill(dataTable)

        For index As Integer = 0 To (dataTable.Rows.Count - 1)
            Dim foodInfo As DataRow = dataTable.Rows(index)

            panelPictureBoxArray(index).SizeMode = PictureBoxSizeMode.StretchImage
            panelPictureBoxArray(index).Image = Image.FromFile(".\images\" + foodInfo("ID").ToString + ".jpg")
            Dim displayedIndex As Integer = index + 1
            panelLableItemArray((index + 1) * 2 - 2).Text = "0" + displayedIndex.ToString + " $" + Format(foodInfo("Price"), "0.00").ToString
            panelLableItemArray((index + 1) * 2 - 1).Text = foodInfo("Name")

            panelPictureBoxArray(index).Visible = True
            panelAddButtonArray(index).Visible = True
            panelRemoveButtonArray(index).Visible = True
            panelLableItemArray((index + 1) * 2 - 2).Visible = True
            panelLableItemArray((index + 1) * 2 - 1).Visible = True
        Next

        ' set all unnecessary components to invisible
        For index As Integer = dataTable.Rows.Count To 3
            panelPictureBoxArray(index).Visible = False
            panelAddButtonArray(index).Visible = False
            panelRemoveButtonArray(index).Visible = False
            panelLableItemArray((index + 1) * 2 - 2).Visible = False
            panelLableItemArray((index + 1) * 2 - 1).Visible = False
        Next
    End Sub


    Private Sub AddButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton1.Click
        selectFood(0)
    End Sub

    Private Sub AddButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton2.Click
        selectFood(1)
    End Sub

    Private Sub AddButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton3.Click
        selectFood(2)
    End Sub

    Private Sub AddButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton4.Click
        selectFood(3)
    End Sub

    Private Sub selectFood(ByVal index As Integer)
        Dim foodInfo As DataRow = dataTable.Rows(index)
        Dim foodId As Integer = foodInfo("ID")

        ' update orderDataDictionary
        Dim value As Integer
        If orderDataDictionary.TryGetValue(foodId, value) Then
            orderDataDictionary(foodId) = value + 1
        Else
            orderDataDictionary.Add(foodId, 1)
        End If

        ' update displayed form
        updateSummaryTable()
    End Sub

    Private Sub RemoveButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveButton1.Click
        removeFood(0)
    End Sub

    Private Sub RemoveButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveButton2.Click
        removeFood(1)
    End Sub

    Private Sub RemoveButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveButton3.Click
        removeFood(2)
    End Sub

    Private Sub RemoveButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveButton4.Click
        removeFood(3)
    End Sub

    Private Sub removeFood(ByVal index As Integer)
        Dim foodInfo As DataRow = dataTable.Rows(index)
        Dim foodId As Integer = foodInfo("ID")

        ' update orderDataDictionary
        Dim value As Integer
        If orderDataDictionary.TryGetValue(foodId, value) Then
            If value <> 1 Then
                orderDataDictionary(foodId) = value - 1
            Else
                orderDataDictionary.Remove(foodId)
            End If
        End If

        ' update displayed form
        updateSummaryTable()
    End Sub

    Private Sub updateSummaryTable()
        summaryLB.Rows.Clear()
        subTotal = 0
        For Each pair In orderDataDictionary
            subTotal += pair.Value * getFoodPrice(pair.Key)
            summaryLB.Rows.Add(customerId, pair.Value, getFoodName(pair.Key))
        Next

        tax = subTotal * Tax_Rate
        total = subTotal + tax
        totalLB.Rows.Clear()
        totalLB.Rows.Add("SubTotal: ", subTotal)
        totalLB.Rows.Add("GST: ", tax)
        totalLB.Rows.Add("Total: ", total)

        summaryLB.ClearSelection()
        totalLB.ClearSelection()
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

    Private Function getFoodName(ByVal id)
        Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM Food WHERE ID = @id", connection)
        sqlCommand.Parameters.Add("@id", SqlDbType.Int)
        sqlCommand.Parameters("@id").Value = id
        dataAdaptor.SelectCommand = sqlCommand

        ' retrieve query feedback
        Dim cmdBuilder As New SqlCommandBuilder(dataAdaptor)
        Dim dataTable As New DataTable
        dataAdaptor.Fill(dataTable)

        Return dataTable.Rows(0)("Name")
    End Function


    ' save order info to DB
    Private Sub orderBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles orderBtn.Click
        Dim transID As Integer = generateTransactionID()
        insertTransaction(transID, customerId, total)

        ' update transaction order table
        For Each pair In orderDataDictionary
            insertTransactionOrder(transID, pair.Key, pair.Value)
        Next

        ' update transaction table in UI
        updateTransactionTable()

        InitializeVariables()
    End Sub

    Private Function generateTransactionID()
        ' generate transaction ID -- * note: transaction is a reserved keyword
        Dim sqlCommand As SqlCommand = New SqlCommand("SELECT ID FROM [Transaction] ORDER BY ID DESC", connection)
        dataAdaptor.SelectCommand = sqlCommand

        ' retrieve query feedback
        Dim cmdBuilder As New SqlCommandBuilder(dataAdaptor)
        Dim dataTable As New DataTable
        dataAdaptor.Fill(dataTable)

        If dataTable.Rows.Count = 0 Then
            ' let starting ID be 1
            Return 1
        Else
            Return dataTable.Rows(0)("ID") + 1
        End If
    End Function

    Private Sub insertTransaction(ByVal transID As Integer, ByVal userID As Integer, ByVal price As Decimal)
        Dim sqlCommand As SqlCommand = New SqlCommand("INSERT INTO [Transaction](ID, User_Id, price) VALUES (@transactionId, @userId, @price)",
                                                      connection)
        sqlCommand.Parameters.Add("@transactionId", SqlDbType.Int)
        sqlCommand.Parameters("@transactionId").Value = transID
        sqlCommand.Parameters.Add("@userId", SqlDbType.Int)
        sqlCommand.Parameters("@userId").Value = userID
        sqlCommand.Parameters.Add("@price", SqlDbType.Decimal)
        sqlCommand.Parameters("@price").Value = price

        Dim rowsAffected As Integer = sqlCommand.ExecuteNonQuery()
    End Sub

    Private Sub insertTransactionOrder(ByVal transID As Integer, ByVal foodID As Integer, ByVal qty As Integer)
        Dim sqlCommand As SqlCommand = New SqlCommand("INSERT INTO TransactionOrder(Transaction_Id, Food_Id, Qty) VALUES (@transactionId, @foodId, @qty)",
                                                      connection)
        sqlCommand.Parameters.Add("@transactionId", SqlDbType.Int)
        sqlCommand.Parameters("@transactionId").Value = transID
        sqlCommand.Parameters.Add("@foodId", SqlDbType.Int)
        sqlCommand.Parameters("@foodId").Value = foodID
        sqlCommand.Parameters.Add("@qty", SqlDbType.Int)
        sqlCommand.Parameters("@qty").Value = qty

        Dim rowsAffected As Integer = sqlCommand.ExecuteNonQuery()
    End Sub

    Private Sub updateTransactionTable()
        transactionOrderTable.Rows.Clear()
        Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM [Transaction]", connection)
        dataAdaptor.SelectCommand = sqlCommand

        ' retrieve query feedback
        Dim cmdBuilder As New SqlCommandBuilder(dataAdaptor)
        Dim dataTable As New DataTable
        dataAdaptor.Fill(dataTable)

        For index As Integer = 1 To dataTable.Rows.Count
            Dim transactionInfo = dataTable.Rows(index - 1)
            transactionOrderTable.Rows.Add(transactionInfo("ID"), transactionInfo("User_Id"), transactionInfo("Price"))
        Next
    End Sub


    Private Sub clearBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearBtn.Click
        InitializeVariables()
    End Sub

    Private Sub InitializeVariables()
        orderDataDictionary = New Dictionary(Of Integer, Integer)
        summaryLB.Rows.Clear()
        totalLB.Rows.Clear()
        subTotal = 0
        tax = 0
        total = 0
    End Sub


    ' on load
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim connectPath As String = Application.StartupPath.ToString() + "\i-meal.mdf"
        Dim connectString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + connectPath + ";Integrated Security=True;User Instance=True"
        connection = New SqlConnection(connectString)
        Try
            connection.Open()
        Catch ex As Exception
            Print("connection error: " + ex.ToString)
        End Try

        panelPictureBoxArray = {picItem1, picItem2, picItem3, picItem4}
        panelAddButtonArray = {AddButton1, AddButton2, AddButton3, AddButton4}
        panelRemoveButtonArray = {RemoveButton1, RemoveButton2, RemoveButton3, RemoveButton4}
        panelLableItemArray = {lblItem1, lblItem2, lblItem3, lblItem4, lblItem5, lblItem6, lblItem7, lblItem8}

        summaryLB.ColumnCount = 3
        summaryLB.ColumnHeadersVisible = True
        summaryLB.RowHeadersVisible = False
        summaryLB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        summaryLB.Columns(0).Name = "User ID"
        summaryLB.Columns(0).FillWeight = 60
        summaryLB.Columns(1).Name = "Qty"
        summaryLB.Columns(1).FillWeight = 50
        summaryLB.Columns(2).Name = "Item Name"
        summaryLB.Columns(2).FillWeight = 150

        totalLB.ColumnCount = 2
        totalLB.ColumnHeadersVisible = False
        totalLB.RowHeadersVisible = False
        totalLB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        transactionOrderTable.ColumnCount = 3
        transactionOrderTable.ColumnHeadersVisible = True
        transactionOrderTable.RowHeadersVisible = False
        transactionOrderTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        transactionOrderTable.Columns(0).Name = "Transaction ID"
        transactionOrderTable.Columns(1).Name = "User ID"
        transactionOrderTable.Columns(2).Name = "Price"

        InitializeVariables()

        DisplayFoodCategory(1)

        ' retrieve userID from login page
        customerId = Form1.getUserID
    End Sub
End Class