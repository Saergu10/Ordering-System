Imports System.Data.SqlClient

Public Class MainForm

    Const MAXITEMSPORDER As Decimal = 30
    Dim numOrdered As Integer

    ' DB variables
    Dim connection As SqlConnection
    Dim sqlCommand As SqlCommand
    Dim dataAdaptor As New SqlDataAdapter
    Dim dataTable As DataTable

    ' Panel Arrays
    Dim panelPictureBoxArray() As PictureBox
    Dim panelLableItemArray() As Label
    Dim panelRadioButtonArray() As RadioButton

    ' Order variables
    Dim customerId As Integer
    Dim orderDataDictionary As Dictionary(Of String, Integer)

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

    ' helper function
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

            panelPictureBoxArray(index).Image = Image.FromFile(".\images\" + foodInfo("ID").ToString + ".jpg")
            Dim displayedIndex As Integer = index + 1
            panelLableItemArray((index + 1) * 2 - 2).Text = "0" + displayedIndex.ToString + " $" + Format(foodInfo("Price"), "0.00").ToString
            panelLableItemArray((index + 1) * 2 - 1).Text = foodInfo("Name")

            panelPictureBoxArray(index).Visible = True
            panelRadioButtonArray(index).Visible = True
            panelLableItemArray((index + 1) * 2 - 2).Visible = True
            panelLableItemArray((index + 1) * 2 - 1).Visible = True
        Next

        ' set all unnecessary components to invisible
        For index As Integer = dataTable.Rows.Count To 3
            panelPictureBoxArray(index).Visible = False
            panelRadioButtonArray(index).Visible = False
            panelLableItemArray((index + 1) * 2 - 2).Visible = False
            panelLableItemArray((index + 1) * 2 - 1).Visible = False
        Next
    End Sub


    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        selectFood(0)
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        selectFood(1)
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        selectFood(2)
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        selectFood(3)
    End Sub

    ' helper function
    Private Sub selectFood(ByVal index As Integer)
        Dim foodInfo As DataRow = dataTable.Rows(index)
        Dim foodName As String = foodInfo("Name")

        ' update orderDataDictionary
        Dim value As Integer
        If orderDataDictionary.TryGetValue(foodName, value) Then
            orderDataDictionary(foodName) = value + 1
        Else
            orderDataDictionary.Add(foodName, 1)
        End If

        ' update displayed form
        updateSummaryTable(foodInfo("Price"))
    End Sub

    Private Sub updateSummaryTable(ByVal price As Decimal)
        summaryLB.Rows.Clear()
        subTotal = 0
        For Each pair In orderDataDictionary
            subTotal += pair.Value * price
            summaryLB.Rows.Add(customerId, pair.Value, pair.Key)
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
        panelRadioButtonArray = {RadioButton1, RadioButton2, RadioButton3, RadioButton4}
        panelLableItemArray = {lblItem1, lblItem2, lblItem3, lblItem4, lblItem5, lblItem6, lblItem7, lblItem8}

        summaryLB.ColumnCount = 3
        summaryLB.ColumnHeadersVisible = True
        summaryLB.RowHeadersVisible = False
        summaryLB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        summaryLB.Columns(0).Name = "Customer"
        summaryLB.Columns(0).FillWeight = 60
        summaryLB.Columns(1).Name = "Qty"
        summaryLB.Columns(1).FillWeight = 50
        summaryLB.Columns(2).Name = "Item Name"
        summaryLB.Columns(2).FillWeight = 150

        totalLB.ColumnCount = 2
        totalLB.ColumnHeadersVisible = False
        totalLB.RowHeadersVisible = False
        totalLB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        totalLB.Columns(0).Name = "PriceName"
        totalLB.Columns(0).Name = "PriceValue"

        InitializeVariables()

        DisplayFoodCategory(1)

        customerId = 1 'hard coded temporarily
    End Sub




    Private Sub InitializeVariables()
        orderDataDictionary = New Dictionary(Of String, Integer)
        summaryLB.Rows.Clear()
        totalLB.Rows.Clear()
        subTotal = 0
        tax = 0
        total = 0
    End Sub

    Private Sub enterBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enterBtn.Click

    End Sub

    Private Sub exitBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitBtn.Click
        Me.Close()
    End Sub

    Private Sub clearBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearBtn.Click
        InitializeVariables()
    End Sub

End Class