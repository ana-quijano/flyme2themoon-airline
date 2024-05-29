<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmployeeLogIn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtEmployeePassword = New System.Windows.Forms.TextBox()
        Me.txtEmployeeLoginID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(110, 148)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(167, 35)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnSubmit)
        Me.GroupBox1.Controls.Add(Me.txtEmployeePassword)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeLoginID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 212)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(110, 107)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(167, 35)
        Me.btnSubmit.TabIndex = 4
        Me.btnSubmit.Text = "Log In"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtEmployeePassword
        '
        Me.txtEmployeePassword.Location = New System.Drawing.Point(176, 58)
        Me.txtEmployeePassword.Name = "txtEmployeePassword"
        Me.txtEmployeePassword.Size = New System.Drawing.Size(129, 22)
        Me.txtEmployeePassword.TabIndex = 3
        Me.txtEmployeePassword.UseSystemPasswordChar = True
        '
        'txtEmployeeLoginID
        '
        Me.txtEmployeeLoginID.Location = New System.Drawing.Point(176, 32)
        Me.txtEmployeeLoginID.Name = "txtEmployeeLoginID"
        Me.txtEmployeeLoginID.Size = New System.Drawing.Size(129, 22)
        Me.txtEmployeeLoginID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(97, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Login ID:"
        '
        'frmEmployeeLogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 275)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmEmployeeLogIn"
        Me.Text = "Employee Log In"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents txtEmployeePassword As TextBox
    Friend WithEvents txtEmployeeLoginID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
