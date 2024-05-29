<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdminAddPilot
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
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboPilotRole = New System.Windows.Forms.ComboBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLoginID = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtmDateofHire = New System.Windows.Forms.DateTimePicker()
        Me.dtmDateofTermination = New System.Windows.Forms.DateTimePicker()
        Me.dtmDateofLicense = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(234, 387)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(125, 36)
        Me.btnClose.TabIndex = 23
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(92, 387)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(125, 36)
        Me.btnSubmit.TabIndex = 22
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(198, 161)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(87, 22)
        Me.txtEmployeeID.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(90, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Employee ID"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(109, 276)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 17)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Pilot Role"
        '
        'cboPilotRole
        '
        Me.cboPilotRole.FormattingEnabled = True
        Me.cboPilotRole.Location = New System.Drawing.Point(198, 273)
        Me.cboPilotRole.Name = "cboPilotRole"
        Me.cboPilotRole.Size = New System.Drawing.Size(121, 24)
        Me.cboPilotRole.TabIndex = 9
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(197, 103)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(115, 22)
        Me.txtFirstName.TabIndex = 3
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(197, 131)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(115, 22)
        Me.txtLastName.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(101, 134)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 17)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "First Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLoginID
        '
        Me.txtLoginID.Location = New System.Drawing.Point(197, 48)
        Me.txtLoginID.Name = "txtLoginID"
        Me.txtLoginID.Size = New System.Drawing.Size(115, 22)
        Me.txtLoginID.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(197, 75)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(115, 22)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(117, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Login ID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtmDateofLicense)
        Me.GroupBox1.Controls.Add(Me.dtmDateofTermination)
        Me.GroupBox1.Controls.Add(Me.dtmDateofHire)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtLoginID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtLastName)
        Me.GroupBox1.Controls.Add(Me.txtFirstName)
        Me.GroupBox1.Controls.Add(Me.cboPilotRole)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeID)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 333)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Pilot Details"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(108, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 17)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(109, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Hire Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(60, 222)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 17)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Termination Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(86, 250)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 17)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "License Date"
        '
        'dtmDateofHire
        '
        Me.dtmDateofHire.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmDateofHire.Location = New System.Drawing.Point(198, 189)
        Me.dtmDateofHire.Name = "dtmDateofHire"
        Me.dtmDateofHire.Size = New System.Drawing.Size(126, 22)
        Me.dtmDateofHire.TabIndex = 6
        Me.dtmDateofHire.Value = New Date(2024, 4, 24, 0, 0, 0, 0)
        '
        'dtmDateofTermination
        '
        Me.dtmDateofTermination.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmDateofTermination.Location = New System.Drawing.Point(198, 217)
        Me.dtmDateofTermination.Name = "dtmDateofTermination"
        Me.dtmDateofTermination.Size = New System.Drawing.Size(126, 22)
        Me.dtmDateofTermination.TabIndex = 7
        Me.dtmDateofTermination.Value = New Date(2024, 4, 24, 0, 0, 0, 0)
        '
        'dtmDateofLicense
        '
        Me.dtmDateofLicense.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmDateofLicense.Location = New System.Drawing.Point(198, 245)
        Me.dtmDateofLicense.Name = "dtmDateofLicense"
        Me.dtmDateofLicense.Size = New System.Drawing.Size(126, 22)
        Me.dtmDateofLicense.TabIndex = 8
        Me.dtmDateofLicense.Value = New Date(2024, 4, 24, 0, 0, 0, 0)
        '
        'frmAdminAddPilot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 454)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmAdminAddPilot"
        Me.Text = "Add Pilot"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents txtEmployeeID As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cboPilotRole As ComboBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLoginID As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtmDateofLicense As DateTimePicker
    Friend WithEvents dtmDateofTermination As DateTimePicker
    Friend WithEvents dtmDateofHire As DateTimePicker
End Class
