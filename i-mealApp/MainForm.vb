Imports System.Data.SqlClient

Public Class MainForm

    Const Tax_Rate = 0.07
   
    Dim subTotal As Decimal
    Dim tax As Decimal
    Dim total As Decimal

    Const MAXITEMSPORDER As Decimal = 30
    Dim currentFoodIDLists(MAXITEMSPORDER) As Integer
    Dim orderedFoodIDLists(MAXITEMSPORDER) As Integer
    Dim numOrdered As Integer

    ' DB parameters
    Dim connection As SqlConnection
    Dim sqlCommand As SqlCommand
    Dim dataAdaptor As New SqlDataAdapter

    ' Panel Arrays
    Dim panelPictureBoxArray() As PictureBox
    Dim panelLableItemArray() As Label
    Dim panelRadioButtonArray() As RadioButton

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

    Private Sub DessertsBtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DessertsBtn.Click
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
        Dim dataTable As New DataTable
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

        DisplayFoodCategory(1)

        InitializeVariables()
        ClearTheReceipt()

    End Sub






    Private Sub InitializeVariables()
        subTotal = 0
        tax = 0
        total = 0
    End Sub

    Private Sub ClearTheReceipt()
        summaryLB.Items.Clear()
        totalLB.Items.Clear()

    End Sub
    Private Sub updateTotal()
        totalLB.Items.Clear()
        totalLB.Items.Add("SUB TOTAL= " & subTotal.ToString("C"))
        tax = subTotal * Tax_Rate
        totalLB.Items.Add("   Tax = " & tax.ToString("C"))
        total = subTotal + tax
        totalLB.Items.Add("   Total = " & total.ToString("C"))
        summaryLB.Items.Add("-----------------------------")
    End Sub

    Private Sub enterBtn_Click(sender As System.Object, e As System.EventArgs) Handles enterBtn.Click
        updateTotal()



    End Sub

    Private Sub ExitBtn_Click(sender As System.Object, e As System.EventArgs) Handles ExitBtn.Click
        Me.Close()
    End Sub

    Private Sub clearBtn_Click(sender As System.Object, e As System.EventArgs) Handles clearBtn.Click
        InitializeVariables()
        ClearTheReceipt()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            'subTotal += BCB
            'Dim BCBItem As String = BCB.ToString("C") & "  Burrito & Chicken Burger"
            'summaryLB.Items.Add(BCBItem)
            orderedFoodIDLists(numOrdered) = currentFoodIDLists(0)
            numOrdered = numOrdered + 1
            Dim BCBItem As String = lblItem2.Text + "     " + lblItem1.Text.ToString.Substring(4, 1)
            summaryLB.Items.Add(BCBItem)
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            orderedFoodIDLists(numOrdered) = currentFoodIDLists(1)
            numOrdered = numOrdered + 1
            Dim FFItem As String = lblItem4.Text + "     " + lblItem3.Text.ToString.Substring(4, 1)
            summaryLB.Items.Add(FFItem)
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            orderedFoodIDLists(numOrdered) = currentFoodIDLists(1)
            numOrdered = numOrdered + 1
            Dim FFItem As String = lblItem6.Text + "     " + lblItem5.Text.ToString.Substring(4, 1)
            summaryLB.Items.Add(FFItem)
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked Then
            orderedFoodIDLists(numOrdered) = currentFoodIDLists(1)
            numOrdered = numOrdered + 1
            Dim FFItem As String = lblItem8.Text + "     " + lblItem7.Text.ToString.Substring(4, 1)
            summaryLB.Items.Add(FFItem)
        End If
    End Sub
End Class