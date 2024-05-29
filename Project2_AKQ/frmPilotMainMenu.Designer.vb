<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotMainMenu
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCustomerFutureFlights = New System.Windows.Forms.Button()
        Me.btnCustomerPastFlights = New System.Windows.Forms.Button()
        Me.btnUpdatePilot = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(39, 277)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(195, 34)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnCustomerFutureFlights
        '
        Me.btnCustomerFutureFlights.Location = New System.Drawing.Point(15, 151)
        Me.btnCustomerFutureFlights.Name = "btnCustomerFutureFlights"
        Me.btnCustomerFutureFlights.Size = New System.Drawing.Size(195, 48)
        Me.btnCustomerFutureFlights.TabIndex = 11
        Me.btnCustomerFutureFlights.Text = "Display Future Flights"
        Me.btnCustomerFutureFlights.UseVisualStyleBackColor = True
        '
        'btnCustomerPastFlights
        '
        Me.btnCustomerPastFlights.Location = New System.Drawing.Point(16, 97)
        Me.btnCustomerPastFlights.Name = "btnCustomerPastFlights"
        Me.btnCustomerPastFlights.Size = New System.Drawing.Size(195, 48)
        Me.btnCustomerPastFlights.TabIndex = 10
        Me.btnCustomerPastFlights.Text = "Display Past Flights"
        Me.btnCustomerPastFlights.UseVisualStyleBackColor = True
        '
        'btnUpdatePilot
        '
        Me.btnUpdatePilot.Location = New System.Drawing.Point(16, 43)
        Me.btnUpdatePilot.Name = "btnUpdatePilot"
        Me.btnUpdatePilot.Size = New System.Drawing.Size(195, 48)
        Me.btnUpdatePilot.TabIndex = 8
        Me.btnUpdatePilot.Text = "Update Pilot Profile"
        Me.btnUpdatePilot.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCustomerPastFlights)
        Me.GroupBox1.Controls.Add(Me.btnUpdatePilot)
        Me.GroupBox1.Controls.Add(Me.btnCustomerFutureFlights)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 229)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Action"
        '
        'frmPilotMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 338)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmPilotMainMenu"
        Me.Text = "Pilot Main Menu"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnCustomerFutureFlights As Button
    Friend WithEvents btnCustomerPastFlights As Button
    Friend WithEvents btnUpdatePilot As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
