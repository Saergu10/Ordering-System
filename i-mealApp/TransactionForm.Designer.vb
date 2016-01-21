<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionForm
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
        Me.TransactionTable = New System.Windows.Forms.DataGridView()
        Me.TransactionOrderTable = New System.Windows.Forms.DataGridView()
        Me.SummaryTable = New System.Windows.Forms.DataGridView()
        CType(Me.TransactionTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionOrderTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TransactionTable
        '
        Me.TransactionTable.AllowUserToAddRows = False
        Me.TransactionTable.AllowUserToDeleteRows = False
        Me.TransactionTable.BackgroundColor = System.Drawing.SystemColors.Window
        Me.TransactionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TransactionTable.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.TransactionTable.Location = New System.Drawing.Point(12, 12)
        Me.TransactionTable.Name = "TransactionTable"
        Me.TransactionTable.RowTemplate.Height = 23
        Me.TransactionTable.Size = New System.Drawing.Size(455, 420)
        Me.TransactionTable.TabIndex = 0
        '
        'TransactionOrderTable
        '
        Me.TransactionOrderTable.AllowUserToAddRows = False
        Me.TransactionOrderTable.AllowUserToDeleteRows = False
        Me.TransactionOrderTable.BackgroundColor = System.Drawing.SystemColors.Window
        Me.TransactionOrderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TransactionOrderTable.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TransactionOrderTable.Location = New System.Drawing.Point(488, 12)
        Me.TransactionOrderTable.Name = "TransactionOrderTable"
        Me.TransactionOrderTable.RowTemplate.Height = 23
        Me.TransactionOrderTable.Size = New System.Drawing.Size(377, 288)
        Me.TransactionOrderTable.TabIndex = 1
        '
        'SummaryTable
        '
        Me.SummaryTable.AllowUserToAddRows = False
        Me.SummaryTable.AllowUserToDeleteRows = False
        Me.SummaryTable.BackgroundColor = System.Drawing.SystemColors.Window
        Me.SummaryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SummaryTable.GridColor = System.Drawing.SystemColors.Window
        Me.SummaryTable.Location = New System.Drawing.Point(488, 295)
        Me.SummaryTable.Name = "SummaryTable"
        Me.SummaryTable.ReadOnly = True
        Me.SummaryTable.RowTemplate.Height = 23
        Me.SummaryTable.Size = New System.Drawing.Size(377, 63)
        Me.SummaryTable.TabIndex = 2
        '
        'TransactionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 444)
        Me.Controls.Add(Me.SummaryTable)
        Me.Controls.Add(Me.TransactionOrderTable)
        Me.Controls.Add(Me.TransactionTable)
        Me.Name = "TransactionForm"
        Me.Text = "Transaction"
        CType(Me.TransactionTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionOrderTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TransactionTable As System.Windows.Forms.DataGridView
    Friend WithEvents TransactionOrderTable As System.Windows.Forms.DataGridView
    Friend WithEvents SummaryTable As System.Windows.Forms.DataGridView
End Class
