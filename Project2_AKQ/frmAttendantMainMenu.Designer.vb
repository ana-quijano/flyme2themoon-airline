<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendantMainMenu
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
        Me.btnAttendantFutureFlights = New System.Windows.Forms.Button()
        Me.btnAttendantPastFlights = New System.Windows.Forms.Button()
        Me.btnUpdateAttendant = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(39, 277)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(195, 34)
        Me.btnExit.TabIndex = 16
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAttendantFutureFlights
        '
        Me.btnAttendantFutureFlights.Location = New System.Drawing.Point(15, 151)
        Me.btnAttendantFutureFlights.Name = "btnAttendantFutureFlights"
        Me.btnAttendantFutureFlights.Size = New System.Drawing.Size(193, 48)
        Me.btnAttendantFutureFlights.TabIndex = 15
        Me.btnAttendantFutureFlights.Text = "Display Future Flights"
        Me.btnAttendantFutureFlights.UseVisualStyleBackColor = True
        '
        'btnAttendantPastFlights
        '
        Me.btnAttendantPastFlights.Location = New System.Drawing.Point(16, 97)
        Me.btnAttendantPastFlights.Name = "btnAttendantPastFlights"
        Me.btnAttendantPastFlights.Size = New System.Drawing.Size(193, 48)
        Me.btnAttendantPastFlights.TabIndex = 14
        Me.btnAttendantPastFlights.Text = "Display Past Flights"
        Me.btnAttendantPastFlights.UseVisualStyleBackColor = True
        '
        'btnUpdateAttendant
        '
        Me.btnUpdateAttendant.Location = New System.Drawing.Point(16, 43)
        Me.btnUpdateAttendant.Name = "btnUpdateAttendant"
        Me.btnUpdateAttendant.Size = New System.Drawing.Size(193, 48)
        Me.btnUpdateAttendant.TabIndex = 13
        Me.btnUpdateAttendant.Text = "Update Attendant Profile"
        Me.btnUpdateAttendant.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnUpdateAttendant)
        Me.GroupBox1.Controls.Add(Me.btnAttendantPastFlights)
        Me.GroupBox1.Controls.Add(Me.btnAttendantFutureFlights)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 229)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Action"
        '
        'frmAttendantMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 338)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmAttendantMainMenu"
        Me.Text = "Attendant Main Menu"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnAttendantFutureFlights As Button
    Friend WithEvents btnAttendantPastFlights As Button
    Friend WithEvents btnUpdateAttendant As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
