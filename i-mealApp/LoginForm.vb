Public Class Form1

    Private Sub userIdLabel_Click(sender As System.Object, e As System.EventArgs) Handles userNameLabel.Click

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles loginBTN.Click
        'If userNameTB.Text = "Mark" And pwTB.Text = "aa123" Then
        MainForm.Show()
        'Else
        '    MsgBox("Invalid username or password!", MsgBoxStyle.Information, "Error")

        '    userNameTB.Clear()
        '    pwTB.Clear()



        'End If

    End Sub

    Private Sub cancelBTN_Click(sender As System.Object, e As System.EventArgs) Handles cancelBTN.Click
        Me.Close()

    End Sub
End Class
