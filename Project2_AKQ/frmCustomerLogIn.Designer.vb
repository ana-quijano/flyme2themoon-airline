<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerLogIn
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtCustomerPassword = New System.Windows.Forms.TextBox()
        Me.txtCustomerLogInID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAddNewCustomer = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSubmit)
        Me.GroupBox1.Controls.Add(Me.txtCustomerPassword)
        Me.GroupBox1.Controls.Add(Me.txtCustomerLogInID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 185)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Existing Customer Log In"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(109, 122)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(167, 35)
        Me.btnSubmit.TabIndex = 4
        Me.btnSubmit.Text = "Log In"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtCustomerPassword
        '
        Me.txtCustomerPassword.Location = New System.Drawing.Point(175, 75)
        Me.txtCustomerPassword.Name = "txtCustomerPassword"
        Me.txtCustomerPassword.Size = New System.Drawing.Size(129, 22)
        Me.txtCustomerPassword.TabIndex = 3
        Me.txtCustomerPassword.UseSystemPasswordChar = True
        '
        'txtCustomerLogInID
        '
        Me.txtCustomerLogInID.Location = New System.Drawing.Point(175, 47)
        Me.txtCustomerLogInID.Name = "txtCustomerLogInID"
        Me.txtCustomerLogInID.Size = New System.Drawing.Size(129, 22)
        Me.txtCustomerLogInID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer ID:"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(110, 285)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(231, 35)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnAddNewCustomer
        '
        Me.btnAddNewCustomer.Location = New System.Drawing.Point(110, 244)
        Me.btnAddNewCustomer.Name = "btnAddNewCustomer"
        Me.btnAddNewCustomer.Size = New System.Drawing.Size(231, 35)
        Me.btnAddNewCustomer.TabIndex = 6
        Me.btnAddNewCustomer.Text = "Add New Customer"
        Me.btnAddNewCustomer.UseVisualStyleBackColor = True
        '
        'frmCustomerLogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 351)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAddNewCustomer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCustomerLogIn"
        Me.Text = "Customer Log In"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtCustomerPassword As TextBox
    Friend WithEvents txtCustomerLogInID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnAddNewCustomer As Button
End Class
