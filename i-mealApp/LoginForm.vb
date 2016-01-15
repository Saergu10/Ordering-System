Imports System.Data.SqlClient

Public Class LoginForm
    Private userID As Integer

    Public Function getUserID()
        Return userID
    End Function

    Private Sub loginBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginBTN.Click
        ' setup connection to DB
        Dim connectPath As String = Application.StartupPath.ToString() + "\i-meal.mdf"
        Dim connectString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + connectPath + ";Integrated Security=True;User Instance=True"
        Dim connection As New SqlConnection(connectString)
        Try
            connection.Open()
        Catch ex As Exception
            Print("connection error: " + ex.ToString)
        End Try

        Dim userName As String = userNameTB.Text
        Dim userPassword As String = pwTB.Text

        ' setup sql query
        Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM User_Profile WHERE Name = @name", connection)
        sqlCommand.Parameters.Add("@name", SqlDbType.VarChar)
        sqlCommand.Parameters("@name").Value = userName

        Dim dataAdaptor As New SqlDataAdapter
        dataAdaptor.SelectCommand = sqlCommand

        ' retrieve query feedback
        Dim cmdBuilder As New SqlCommandBuilder(dataAdaptor)
        Dim dataTable As New DataTable
        dataAdaptor.Fill(dataTable)

        ' check if Username and Password exist/match in DB
        If (dataTable.Rows.Count <> 0) Then
            Dim dataRow As DataRow = dataTable.Rows(0)
            If (dataRow("Password").Equals(userPassword)) Then
                userID = dataRow("Role_Id")
                MainForm.Show()
            Else
                MsgBox("Invalid username or password!")
            End If
        Else
            MsgBox("Invalid username or password!")
        End If

    End Sub

    Private Sub cancelBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelBTN.Click
        Me.Close()
    End Sub

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AcceptButton = loginBTN
    End Sub
End Class
