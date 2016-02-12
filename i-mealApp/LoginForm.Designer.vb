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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.userNameLabel = New System.Windows.Forms.Label()
        Me.userNameTB = New System.Windows.Forms.TextBox()
        Me.pwLabel = New System.Windows.Forms.Label()
        Me.pwTB = New System.Windows.Forms.TextBox()
        Me.cancelBTN = New System.Windows.Forms.Button()
        Me.loginBTN = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'userNameLabel
        '
        Me.userNameLabel.AutoSize = True
        Me.userNameLabel.Location = New System.Drawing.Point(259, 74)
        Me.userNameLabel.Name = "userNameLabel"
        Me.userNameLabel.Size = New System.Drawing.Size(59, 12)
        Me.userNameLabel.TabIndex = 0
        Me.userNameLabel.Text = "Username:"
        '
        'userNameTB
        '
        Me.userNameTB.BackColor = System.Drawing.SystemColors.Menu
        Me.userNameTB.Location = New System.Drawing.Point(261, 99)
        Me.userNameTB.Name = "userNameTB"
        Me.userNameTB.Size = New System.Drawing.Size(225, 21)
        Me.userNameTB.TabIndex = 1
        '
        'pwLabel
        '
        Me.pwLabel.AutoSize = True
        Me.pwLabel.Location = New System.Drawing.Point(261, 163)
        Me.pwLabel.Name = "pwLabel"
        Me.pwLabel.Size = New System.Drawing.Size(59, 12)
        Me.pwLabel.TabIndex = 2
        Me.pwLabel.Text = "Password:"
        '
        'pwTB
        '
        Me.pwTB.BackColor = System.Drawing.SystemColors.Menu
        Me.pwTB.Location = New System.Drawing.Point(261, 187)
        Me.pwTB.Name = "pwTB"
        Me.pwTB.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pwTB.Size = New System.Drawing.Size(225, 21)
        Me.pwTB.TabIndex = 3
        '
        'cancelBTN
        '
        Me.cancelBTN.BackColor = System.Drawing.Color.DodgerBlue
        Me.cancelBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelBTN.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cancelBTN.Location = New System.Drawing.Point(401, 247)
        Me.cancelBTN.Name = "cancelBTN"
        Me.cancelBTN.Size = New System.Drawing.Size(85, 31)
        Me.cancelBTN.TabIndex = 4
        Me.cancelBTN.Text = "CANCEL"
        Me.cancelBTN.UseVisualStyleBackColor = False
        '
        'loginBTN
        '
        Me.loginBTN.BackColor = System.Drawing.Color.DodgerBlue
        Me.loginBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loginBTN.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.loginBTN.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.loginBTN.Location = New System.Drawing.Point(261, 247)
        Me.loginBTN.Name = "loginBTN"
        Me.loginBTN.Size = New System.Drawing.Size(84, 30)
        Me.loginBTN.TabIndex = 5
        Me.loginBTN.Text = "LOGIN"
        Me.loginBTN.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(50, 74)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(153, 148)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(544, 334)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.loginBTN)
        Me.Controls.Add(Me.cancelBTN)
        Me.Controls.Add(Me.pwTB)
        Me.Controls.Add(Me.pwLabel)
        Me.Controls.Add(Me.userNameTB)
        Me.Controls.Add(Me.userNameLabel)
        Me.Name = "LoginForm"
        Me.Text = "KPC"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents userNameLabel As System.Windows.Forms.Label
    Friend WithEvents userNameTB As System.Windows.Forms.TextBox
    Friend WithEvents pwLabel As System.Windows.Forms.Label
    Friend WithEvents pwTB As System.Windows.Forms.TextBox
    Friend WithEvents cancelBTN As System.Windows.Forms.Button
    Friend WithEvents loginBTN As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
