Imports System.Data.SqlClient

Public Class MainForm

    Const Tax_Rate = 0.07
   
    Dim subTotal As Decimal
    Dim tax As Decimal
    Dim total As Decimal

    ' DB parameters
    Dim connection As SqlConnection
    Dim sqlCommand As SqlCommand
    Dim dataAdaptor As New SqlDataAdapter

    Const MAXITEMSPORDER As Decimal = 30
    Dim currentFoodIDLists(MAXITEMSPORDER) As Integer
    Dim orderedFoodIDLists(MAXITEMSPORDER) As Integer
    Dim numOrdered As Integer

    Private Sub evmBtn_Click(sender As System.Object, e As System.EventArgs) Handles evmBtn.Click

        'Create a Command object.
        'myCmd = connection.CreateCommand
        Dim myCmd As New SqlCommand("SELECT Food.* FROM Food INNER JOIN " & _
                            "FoodCategory ON Food.Food_Cate_id = FoodCategory.ID " & _
                            "WHERE        (FoodCategory.ID = @id) " & _
                            "ORDER BY Food.ID", connection)

        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = 1

        Try
            'Open the connection.
            connection.Open()
            'Dim ds As New DataSet
            'Dim adapter As New SqlDataAdapter
            'adapter.SelectCommand = New SqlCommand("Your SQL Statement Here", connection)
            'adapter.Fill(ds)
            Dim sqlReader As SqlDataReader = myCmd.ExecuteReader()

            Dim count As Integer = 0
            While sqlReader.Read()
                ''MsgBox(sqlReader.Item(0) & "  -  " & sqlReader.Item(1) & "  -  " & sqlReader.Item(2))

                If (count = 0) Then
                    picItem1.Image = Image.FromFile(".\images\evmItem1.jpg")
                    lblItem1.Text = String.Format("01 ${0.00}", sqlReader.Item(2).ToString())
                    'lblItem1.Text = String.Format("01 ${0:f2}", sqlReader.Item(2).ToString())
                    lblItem2.Text = sqlReader.Item(1)
                    'RadioButton1.Text = sqlReader.Item(1)

                ElseIf (count = 1) Then


                    picItem2.Image = Image.FromFile(".\images\evmItem2.jpg")
                    lblItem3.Text = String.Format("02 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem4.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1)            
                End If

                currentFoodIDLists(count) = sqlReader.Item(0)
                count = count + 1
            End While
            sqlReader.Close()
            myCmd.Dispose()

        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        Finally

            connection.Close()
        End Try



        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = False
        RadioButton4.Visible = False
        picItem1.Visible = True
        lblItem1.Visible = True
        lblItem2.Visible = True
        picItem2.Visible = True
        lblItem3.Visible = True
        lblItem4.Visible = True
        picItem4.Visible = False
        picItem3.Visible = False
        lblItem5.Visible = False
        lblItem6.Visible = False
        lblItem7.Visible = False
        lblItem8.Visible = False


    End Sub

    Private Sub vmdBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vmdBtn.Click

        RadioButton1.Checked = False


        'Create a Command object.
        'myCmd = connection.CreateCommand
        Dim myCmd As New SqlCommand("SELECT Food.* FROM Food INNER JOIN " & _
                            "FoodCategory ON Food.Food_Cate_id = FoodCategory.ID " & _
                            "WHERE        (FoodCategory.ID = @id) " & _
                            "ORDER BY Food.ID", connection)

        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = 2

        Try
            'Open the connection.
            connection.Open()
            'Dim ds As New DataSet
            'Dim adapter As New SqlDataAdapter
            'adapter.SelectCommand = New SqlCommand("Your SQL Statement Here", connection)
            'adapter.Fill(ds)
            Dim sqlReader As SqlDataReader = myCmd.ExecuteReader()

            Dim count As Integer = 0
            While sqlReader.Read()
                ''MsgBox(sqlReader.Item(0) & "  -  " & sqlReader.Item(1) & "  -  " & sqlReader.Item(2))
                If (count = 0) Then
                    picItem1.Image = Image.FromFile(".\images\vmdItem1.jpg")
                    lblItem1.Text = String.Format("01 ${0.00}", sqlReader.Item(2).ToString())

                    lblItem2.Text = sqlReader.Item(1)
                    'RadioButton1.Text = sqlReader.Item(1)

                ElseIf (count = 1) Then


                    picItem2.Image = Image.FromFile(".\images\vmdItem2.jpg")
                    lblItem3.Text = String.Format("02 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem4.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1)  
                ElseIf (count = 2) Then


                    picItem3.Image = Image.FromFile(".\images\vmdItem3.jpg")
                    lblItem5.Text = String.Format("03 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem6.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                ElseIf (count = 3) Then


                    picItem4.Image = Image.FromFile(".\images\vmdItem4.jpg")
                    lblItem7.Text = String.Format("04 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem8.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                End If

                currentFoodIDLists(count) = sqlReader.Item(0)
                count = count + 1
            End While
            sqlReader.Close()
            myCmd.Dispose()

        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        Finally
            connection.Close()
        End Try

        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = True
        RadioButton4.Visible = True
        picItem1.Visible = True
        lblItem1.Visible = True
        lblItem2.Visible = True
        picItem2.Visible = True
        lblItem3.Visible = True
        lblItem4.Visible = True
        picItem4.Visible = True
        picItem3.Visible = True
        lblItem5.Visible = True
        lblItem6.Visible = True
        lblItem7.Visible = True
        lblItem8.Visible = True



    End Sub



    Private Sub hmBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hmBtn.Click
        'Create a Command object.
        'myCmd = connection.CreateCommand
        Dim myCmd As New SqlCommand("SELECT Food.* FROM Food INNER JOIN " & _
                            "FoodCategory ON Food.Food_Cate_id = FoodCategory.ID " & _
                            "WHERE        (FoodCategory.ID = @id) " & _
                            "ORDER BY Food.ID", connection)

        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = 3

        Try
            'Open the connection.
            connection.Open()
            'Dim ds As New DataSet
            'Dim adapter As New SqlDataAdapter
            'adapter.SelectCommand = New SqlCommand("Your SQL Statement Here", connection)
            'adapter.Fill(ds)
            Dim sqlReader As SqlDataReader = myCmd.ExecuteReader()

            Dim count As Integer = 0
            While sqlReader.Read()
                ''MsgBox(sqlReader.Item(0) & "  -  " & sqlReader.Item(1) & "  -  " & sqlReader.Item(2))
                If (count = 0) Then
                    picItem1.Image = Image.FromFile(".\images\hmItem1.jpg")
                    lblItem1.Text = String.Format("01 ${0.00}", sqlReader.Item(2).ToString())

                    lblItem2.Text = sqlReader.Item(1)
                    'RadioButton1.Text = sqlReader.Item(1)

                ElseIf (count = 1) Then


                    picItem2.Image = Image.FromFile(".\images\hmItem2.jpg")
                    lblItem3.Text = String.Format("02 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem4.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1)  

                End If

                currentFoodIDLists(count) = sqlReader.Item(0)
                count = count + 1
            End While
            sqlReader.Close()
            myCmd.Dispose()

        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        Finally
            connection.Close()
        End Try

        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = False
        RadioButton4.Visible = False
        picItem1.Visible = True
        lblItem1.Visible = True
        lblItem2.Visible = True
        picItem2.Visible = True
        lblItem3.Visible = True
        lblItem4.Visible = True
        picItem4.Visible = False
        picItem3.Visible = False
        lblItem5.Visible = False
        lblItem6.Visible = False
        lblItem7.Visible = False
        lblItem8.Visible = False

    End Sub

    Private Sub burgerBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles burgerBtn.Click
        'Create a Command object.
        'myCmd = connection.CreateCommand
        Dim myCmd As New SqlCommand("SELECT Food.* FROM Food INNER JOIN " & _
                            "FoodCategory ON Food.Food_Cate_id = FoodCategory.ID " & _
                            "WHERE        (FoodCategory.ID = @id) " & _
                            "ORDER BY Food.ID", connection)

        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = 5

        Try
            'Open the connection.
            connection.Open()
            'Dim ds As New DataSet
            'Dim adapter As New SqlDataAdapter
            'adapter.SelectCommand = New SqlCommand("Your SQL Statement Here", connection)
            'adapter.Fill(ds)
            Dim sqlReader As SqlDataReader = myCmd.ExecuteReader()

            Dim count As Integer = 0
            While sqlReader.Read()
                ''MsgBox(sqlReader.Item(0) & "  -  " & sqlReader.Item(1) & "  -  " & sqlReader.Item(2))
                If (count = 0) Then
                    picItem1.Image = Image.FromFile(".\images\bmItem1.jpg")
                    lblItem1.Text = String.Format("01 ${0.00}", sqlReader.Item(2).ToString())

                    lblItem2.Text = sqlReader.Item(1)
                    'RadioButton1.Text = sqlReader.Item(1)

                ElseIf (count = 1) Then


                    picItem2.Image = Image.FromFile(".\images\bmItem2.jpg")
                    lblItem3.Text = String.Format("02 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem4.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1)  
                ElseIf (count = 2) Then


                    picItem3.Image = Image.FromFile(".\images\bmItem3.jpg")
                    lblItem5.Text = String.Format("03 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem6.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                ElseIf (count = 3) Then


                    picItem4.Image = Image.FromFile(".\images\bmItem4.jpg")
                    lblItem7.Text = String.Format("04 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem8.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                End If

                currentFoodIDLists(count) = sqlReader.Item(0)
                count = count + 1
            End While
            sqlReader.Close()
            myCmd.Dispose()

        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        Finally
            connection.Close()
        End Try


        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = True
        RadioButton4.Visible = True
        picItem1.Visible = True
        lblItem1.Visible = True
        lblItem2.Visible = True
        picItem2.Visible = True
        lblItem3.Visible = True
        lblItem4.Visible = True
        picItem4.Visible = True
        picItem3.Visible = True
        lblItem5.Visible = True
        lblItem6.Visible = True
        lblItem7.Visible = True
        lblItem8.Visible = True





    End Sub

    Private Sub ffnBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ffnBtn.Click
        'Create a Command object.
        'myCmd = connection.CreateCommand
        Dim myCmd As New SqlCommand("SELECT Food.* FROM Food INNER JOIN " & _
                            "FoodCategory ON Food.Food_Cate_id = FoodCategory.ID " & _
                            "WHERE        (FoodCategory.ID = @id) " & _
                            "ORDER BY Food.ID", connection)

        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = 7

        Try
            'Open the connection.
            connection.Open()
            'Dim ds As New DataSet
            'Dim adapter As New SqlDataAdapter
            'adapter.SelectCommand = New SqlCommand("Your SQL Statement Here", connection)
            'adapter.Fill(ds)
            Dim sqlReader As SqlDataReader = myCmd.ExecuteReader()

            Dim count As Integer = 0
            While sqlReader.Read()
                ''MsgBox(sqlReader.Item(0) & "  -  " & sqlReader.Item(1) & "  -  " & sqlReader.Item(2))
                If (count = 0) Then
                    picItem1.Image = Image.FromFile(".\images\fItem1.jpg")
                    lblItem1.Text = String.Format("01 ${0.00}", sqlReader.Item(2).ToString())

                    lblItem2.Text = sqlReader.Item(1)
                    'RadioButton1.Text = sqlReader.Item(1)

                ElseIf (count = 1) Then


                    picItem2.Image = Image.FromFile(".\images\fItem2.jpg")
                    lblItem3.Text = String.Format("02 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem4.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1)  
                ElseIf (count = 2) Then


                    picItem3.Image = Image.FromFile(".\images\fItem3.jpg")
                    lblItem5.Text = String.Format("03 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem6.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                ElseIf (count = 3) Then


                    picItem4.Image = Image.FromFile(".\images\nItem4.jpg")
                    lblItem7.Text = String.Format("04 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem8.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                End If

                currentFoodIDLists(count) = sqlReader.Item(0)
                count = count + 1
            End While
            sqlReader.Close()
            myCmd.Dispose()

        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        Finally
            connection.Close()
        End Try


        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = True
        RadioButton4.Visible = True
        picItem1.Visible = True
        lblItem1.Visible = True
        lblItem2.Visible = True
        picItem2.Visible = True
        lblItem3.Visible = True
        lblItem4.Visible = True
        picItem4.Visible = True
        picItem3.Visible = True
        lblItem5.Visible = True
        lblItem6.Visible = True
        lblItem7.Visible = True
        lblItem8.Visible = True


    End Sub

    Private Sub saladBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saladBtn.Click
        'Create a Command object.
        'myCmd = connection.CreateCommand
        Dim myCmd As New SqlCommand("SELECT Food.* FROM Food INNER JOIN " & _
                            "FoodCategory ON Food.Food_Cate_id = FoodCategory.ID " & _
                            "WHERE        (FoodCategory.ID = @id) " & _
                            "ORDER BY Food.ID", connection)

        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = 6

        Try
            'Open the connection.
            connection.Open()
            'Dim ds As New DataSet
            'Dim adapter As New SqlDataAdapter
            'adapter.SelectCommand = New SqlCommand("Your SQL Statement Here", connection)
            'adapter.Fill(ds)
            Dim sqlReader As SqlDataReader = myCmd.ExecuteReader()

            Dim count As Integer = 0
            While sqlReader.Read()
                ''MsgBox(sqlReader.Item(0) & "  -  " & sqlReader.Item(1) & "  -  " & sqlReader.Item(2))
                If (count = 0) Then
                    picItem1.Image = Image.FromFile(".\images\csItem1.jpg")
                    lblItem1.Text = String.Format("01 ${0.00}", sqlReader.Item(2).ToString())

                    lblItem2.Text = sqlReader.Item(1)
                    'RadioButton1.Text = sqlReader.Item(1)

                End If

                currentFoodIDLists(count) = sqlReader.Item(0)
                count = count + 1
            End While
            sqlReader.Close()
            myCmd.Dispose()

        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        Finally
            connection.Close()
        End Try
        RadioButton1.Visible = True
        RadioButton2.Visible = False
        RadioButton3.Visible = False
        RadioButton4.Visible = False
        picItem1.Visible = True
        lblItem1.Visible = True
        lblItem2.Visible = True
        picItem2.Visible = False
        picItem4.Visible = False
        picItem3.Visible = False
        lblItem3.Visible = False
        lblItem4.Visible = False
        lblItem5.Visible = False
        lblItem6.Visible = False
        lblItem7.Visible = False
        lblItem8.Visible = False


    End Sub

    Private Sub beverageBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles beverageBtn.Click
        'Create a Command object.
        'myCmd = connection.CreateCommand
        Dim myCmd As New SqlCommand("SELECT Food.* FROM Food INNER JOIN " & _
                            "FoodCategory ON Food.Food_Cate_id = FoodCategory.ID " & _
                            "WHERE        (FoodCategory.ID = @id) " & _
                            "ORDER BY Food.ID", connection)

        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = 4

        Try
            'Open the connection.
            connection.Open()
            'Dim ds As New DataSet
            'Dim adapter As New SqlDataAdapter
            'adapter.SelectCommand = New SqlCommand("Your SQL Statement Here", connection)
            'adapter.Fill(ds)
            Dim sqlReader As SqlDataReader = myCmd.ExecuteReader()

            Dim count As Integer = 0
            While sqlReader.Read()
                ''MsgBox(sqlReader.Item(0) & "  -  " & sqlReader.Item(1) & "  -  " & sqlReader.Item(2))
                If (count = 0) Then
                    picItem1.Image = Image.FromFile(".\images\dkItem1.jpg")
                    lblItem1.Text = String.Format("01 ${0.00}", sqlReader.Item(2).ToString())

                    lblItem2.Text = sqlReader.Item(1)
                    'RadioButton1.Text = sqlReader.Item(1)

                ElseIf (count = 1) Then


                    picItem2.Image = Image.FromFile(".\images\dkItem2.jpg")
                    lblItem3.Text = String.Format("02 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem4.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1)  
                ElseIf (count = 2) Then


                    picItem3.Image = Image.FromFile(".\images\dkItem3.jpg")
                    lblItem5.Text = String.Format("03 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem6.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                ElseIf (count = 3) Then


                    picItem4.Image = Image.FromFile(".\images\dkItem4.jpg")
                    lblItem7.Text = String.Format("04 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem8.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                End If

                currentFoodIDLists(count) = sqlReader.Item(0)
                count = count + 1
            End While
            sqlReader.Close()
            myCmd.Dispose()

        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        Finally
            connection.Close()
        End Try
        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = True
        RadioButton4.Visible = True
        picItem1.Visible = True
        lblItem1.Visible = True
        lblItem2.Visible = True
        picItem2.Visible = True
        lblItem3.Visible = True
        lblItem4.Visible = True
        picItem4.Visible = True
        picItem3.Visible = True
        lblItem5.Visible = True
        lblItem6.Visible = True
        lblItem7.Visible = True
        lblItem8.Visible = True



    End Sub

    Private Sub DessertsBtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DessertsBtn.Click
        'Create a Command object.
        'myCmd = connection.CreateCommand
        Dim myCmd As New SqlCommand("SELECT Food.* FROM Food INNER JOIN " & _
                            "FoodCategory ON Food.Food_Cate_id = FoodCategory.ID " & _
                            "WHERE        (FoodCategory.ID = @id) " & _
                            "ORDER BY Food.ID", connection)

        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = 8

        Try
            'Open the connection.
            connection.Open()
            'Dim ds As New DataSet
            'Dim adapter As New SqlDataAdapter
            'adapter.SelectCommand = New SqlCommand("Your SQL Statement Here", connection)
            'adapter.Fill(ds)
            Dim sqlReader As SqlDataReader = myCmd.ExecuteReader()

            Dim count As Integer = 0
            While sqlReader.Read()
                ''MsgBox(sqlReader.Item(0) & "  -  " & sqlReader.Item(1) & "  -  " & sqlReader.Item(2))
                If (count = 0) Then
                    picItem1.Image = Image.FromFile(".\images\dmItem1.jpg")
                    lblItem1.Text = String.Format("01 ${0.00}", sqlReader.Item(2).ToString())

                    lblItem2.Text = sqlReader.Item(1)
                    'RadioButton1.Text = sqlReader.Item(1)

                ElseIf (count = 1) Then


                    picItem2.Image = Image.FromFile(".\images\dmItem2.jpg")
                    lblItem3.Text = String.Format("02 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem4.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1)  
                ElseIf (count = 2) Then


                    picItem3.Image = Image.FromFile(".\images\dmItem3.jpg")
                    lblItem5.Text = String.Format("03 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem6.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                ElseIf (count = 3) Then


                    picItem4.Image = Image.FromFile(".\images\dmItem4.jpg")
                    lblItem7.Text = String.Format("04 ${0.00}", sqlReader.Item(2).ToString())
                    lblItem8.Text = sqlReader.Item(1)
                    'RadioButton2.Text = sqlReader.Item(1) 
                End If

                currentFoodIDLists(count) = sqlReader.Item(0)
                count = count + 1
            End While
            sqlReader.Close()
            myCmd.Dispose()

        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        Finally
            connection.Close()

        End Try
        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = True
        RadioButton4.Visible = True
        picItem1.Visible = True
        lblItem1.Visible = True
        lblItem2.Visible = True
        picItem2.Visible = True
        lblItem3.Visible = True
        lblItem4.Visible = True
        picItem4.Visible = True
        picItem3.Visible = True
        lblItem5.Visible = True
        lblItem6.Visible = True
        lblItem7.Visible = True
        lblItem8.Visible = True





    End Sub



    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim connectPath As String = Application.StartupPath.ToString() + "\i-meal.mdf"
        Dim connectString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + connectPath + ";Integrated Security=True;User Instance=True"
        connection = New SqlConnection(connectString)
        Try
            connection.Open()
        Catch ex As Exception
            Print("connection error: " + ex.ToString)
        End Try

        ' setup sql query
        'sqlCommand = New SqlCommand("SELECT * FROM User_Profile WHERE Name = @name", connection)
        'sqlCommand.Parameters.Add("@name", SqlDbType.VarChar)
        'sqlCommand.Parameters("@name").Value = userName

        'dataAdaptor.SelectCommand = sqlCommand

        ' retrieve query feedback
        'Dim cmdBuilder As New SqlCommandBuilder(dataAdaptor)
        'Dim dataTable As New DataTable
        'dataAdaptor.Fill(dataTable)

        picItem1.Image = Image.FromFile(".\images\evmItem1.jpg")
        lblItem1.Text = "01 $8.00"
        lblItem2.Text = "Burrito&Chicken Burger"
        picItem2.Image = Image.FromFile(".\images\evmItem2.jpg")
        lblItem3.Text = "02 $7.00"
        lblItem4.Text = "Fillet O Fish&Ice Cream"
        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton3.Visible = False
        RadioButton4.Visible = False
        picItem1.Visible = True
        lblItem1.Visible = True
        lblItem2.Visible = True
        picItem2.Visible = True
        lblItem3.Visible = True
        lblItem4.Visible = True
        picItem4.Visible = False
        picItem3.Visible = False
        lblItem5.Visible = False
        lblItem6.Visible = False
        lblItem7.Visible = False
        lblItem8.Visible = False

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