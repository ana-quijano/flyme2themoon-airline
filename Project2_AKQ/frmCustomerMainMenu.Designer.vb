<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCustomerMainMenu
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
        Me.btnUpdateCustomer = New System.Windows.Forms.Button()
        Me.btnCustomerAddFlight = New System.Windows.Forms.Button()
        Me.btnCustomerPastFlights = New System.Windows.Forms.Button()
        Me.btnCustomerFutureFlights = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdateCustomer
        '
        Me.btnUpdateCustomer.Location = New System.Drawing.Point(16, 43)
        Me.btnUpdateCustomer.Name = "btnUpdateCustomer"
        Me.btnUpdateCustomer.Size = New System.Drawing.Size(193, 48)
        Me.btnUpdateCustomer.TabIndex = 3
        Me.btnUpdateCustomer.Text = "Update Customer Profile"
        Me.btnUpdateCustomer.UseVisualStyleBackColor = True
        '
        'btnCustomerAddFlight
        '
        Me.btnCustomerAddFlight.Location = New System.Drawing.Point(16, 96)
        Me.btnCustomerAddFlight.Name = "btnCustomerAddFlight"
        Me.btnCustomerAddFlight.Size = New System.Drawing.Size(193, 48)
        Me.btnCustomerAddFlight.TabIndex = 4
        Me.btnCustomerAddFlight.Text = "Book Flight"
        Me.btnCustomerAddFlight.UseVisualStyleBackColor = True
        '
        'btnCustomerPastFlights
        '
        Me.btnCustomerPastFlights.Location = New System.Drawing.Point(17, 150)
        Me.btnCustomerPastFlights.Name = "btnCustomerPastFlights"
        Me.btnCustomerPastFlights.Size = New System.Drawing.Size(193, 48)
        Me.btnCustomerPastFlights.TabIndex = 5
        Me.btnCustomerPastFlights.Text = "Display Past Flights"
        Me.btnCustomerPastFlights.UseVisualStyleBackColor = True
        '
        'btnCustomerFutureFlights
        '
        Me.btnCustomerFutureFlights.Location = New System.Drawing.Point(17, 204)
        Me.btnCustomerFutureFlights.Name = "btnCustomerFutureFlights"
        Me.btnCustomerFutureFlights.Size = New System.Drawing.Size(193, 48)
        Me.btnCustomerFutureFlights.TabIndex = 6
        Me.btnCustomerFutureFlights.Text = "Display Future Flights"
        Me.btnCustomerFutureFlights.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(39, 333)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(194, 34)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnUpdateCustomer)
        Me.GroupBox1.Controls.Add(Me.btnCustomerAddFlight)
        Me.GroupBox1.Controls.Add(Me.btnCustomerFutureFlights)
        Me.GroupBox1.Controls.Add(Me.btnCustomerPastFlights)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 281)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Action"
        '
        'frmCustomerMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 390)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmCustomerMainMenu"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Customer Main Menu"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents btnUpdateCustomer As Button
    Private WithEvents btnCustomerAddFlight As Button
    Private WithEvents btnCustomerPastFlights As Button
    Private WithEvents btnCustomerFutureFlights As Button
    Private WithEvents btnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
