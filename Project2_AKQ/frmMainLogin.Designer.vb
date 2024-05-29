<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainLogin
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
        Me.btnCustomerLogIn = New System.Windows.Forms.Button()
        Me.btnEmployeeLogIn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCustomerLogIn
        '
        Me.btnCustomerLogIn.Location = New System.Drawing.Point(21, 40)
        Me.btnCustomerLogIn.Name = "btnCustomerLogIn"
        Me.btnCustomerLogIn.Size = New System.Drawing.Size(159, 48)
        Me.btnCustomerLogIn.TabIndex = 0
        Me.btnCustomerLogIn.Text = "Customer"
        Me.btnCustomerLogIn.UseVisualStyleBackColor = True
        '
        'btnEmployeeLogIn
        '
        Me.btnEmployeeLogIn.Location = New System.Drawing.Point(21, 94)
        Me.btnEmployeeLogIn.Name = "btnEmployeeLogIn"
        Me.btnEmployeeLogIn.Size = New System.Drawing.Size(159, 48)
        Me.btnEmployeeLogIn.TabIndex = 1
        Me.btnEmployeeLogIn.Text = "Employee"
        Me.btnEmployeeLogIn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEmployeeLogIn)
        Me.GroupBox1.Controls.Add(Me.btnCustomerLogIn)
        Me.GroupBox1.Location = New System.Drawing.Point(36, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 165)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Log In Type"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(57, 217)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(159, 34)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        Me.btnExit.UseWaitCursor = True
        '
        'frmMainLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 274)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMainLogin"
        Me.Text = "FlyMe2theMoon LogIn"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCustomerLogIn As Button
    Friend WithEvents btnEmployeeLogIn As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnExit As Button
End Class
