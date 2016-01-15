<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.userNameLabel = New System.Windows.Forms.Label()
        Me.userNameTB = New System.Windows.Forms.TextBox()
        Me.pwLabel = New System.Windows.Forms.Label()
        Me.pwTB = New System.Windows.Forms.TextBox()
        Me.cancelBTN = New System.Windows.Forms.Button()
        Me.loginBTN = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'userNameLabel
        '
        Me.userNameLabel.AutoSize = True
        Me.userNameLabel.Location = New System.Drawing.Point(230, 60)
        Me.userNameLabel.Name = "userNameLabel"
        Me.userNameLabel.Size = New System.Drawing.Size(59, 12)
        Me.userNameLabel.TabIndex = 0
        Me.userNameLabel.Text = "Username:"
        '
        'userNameTB
        '
        Me.userNameTB.Location = New System.Drawing.Point(232, 88)
        Me.userNameTB.Name = "userNameTB"
        Me.userNameTB.Size = New System.Drawing.Size(225, 21)
        Me.userNameTB.TabIndex = 1
        '
        'pwLabel
        '
        Me.pwLabel.AutoSize = True
        Me.pwLabel.Location = New System.Drawing.Point(232, 149)
        Me.pwLabel.Name = "pwLabel"
        Me.pwLabel.Size = New System.Drawing.Size(59, 12)
        Me.pwLabel.TabIndex = 2
        Me.pwLabel.Text = "Password:"
        '
        'pwTB
        '
        Me.pwTB.Location = New System.Drawing.Point(232, 176)
        Me.pwTB.Name = "pwTB"
        Me.pwTB.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pwTB.Size = New System.Drawing.Size(225, 21)
        Me.pwTB.TabIndex = 3
        '
        'cancelBTN
        '
        Me.cancelBTN.Location = New System.Drawing.Point(369, 248)
        Me.cancelBTN.Name = "cancelBTN"
        Me.cancelBTN.Size = New System.Drawing.Size(100, 31)
        Me.cancelBTN.TabIndex = 4
        Me.cancelBTN.Text = "Cancel"
        Me.cancelBTN.UseVisualStyleBackColor = True
        '
        'loginBTN
        '
        Me.loginBTN.Location = New System.Drawing.Point(209, 248)
        Me.loginBTN.Name = "loginBTN"
        Me.loginBTN.Size = New System.Drawing.Size(100, 30)
        Me.loginBTN.TabIndex = 5
        Me.loginBTN.Text = "Login"
        Me.loginBTN.UseVisualStyleBackColor = True
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 393)
        Me.Controls.Add(Me.loginBTN)
        Me.Controls.Add(Me.cancelBTN)
        Me.Controls.Add(Me.pwTB)
        Me.Controls.Add(Me.pwLabel)
        Me.Controls.Add(Me.userNameTB)
        Me.Controls.Add(Me.userNameLabel)
        Me.Name = "LoginForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents userNameLabel As System.Windows.Forms.Label
    Friend WithEvents userNameTB As System.Windows.Forms.TextBox
    Friend WithEvents pwLabel As System.Windows.Forms.Label
    Friend WithEvents pwTB As System.Windows.Forms.TextBox
    Friend WithEvents cancelBTN As System.Windows.Forms.Button
    Friend WithEvents loginBTN As System.Windows.Forms.Button

End Class
