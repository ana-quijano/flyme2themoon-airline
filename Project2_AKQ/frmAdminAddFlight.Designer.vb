<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminAddFlight
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
        Me.numMiles = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboPlaneNumber = New System.Windows.Forms.ComboBox()
        Me.cboDestination = New System.Windows.Forms.ComboBox()
        Me.cboOrigin = New System.Windows.Forms.ComboBox()
        Me.dtmTimeofLanding = New System.Windows.Forms.DateTimePicker()
        Me.dtmTimeofDeparture = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtmDateofFlight = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numMiles)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboPlaneNumber)
        Me.GroupBox1.Controls.Add(Me.cboDestination)
        Me.GroupBox1.Controls.Add(Me.cboOrigin)
        Me.GroupBox1.Controls.Add(Me.dtmTimeofLanding)
        Me.GroupBox1.Controls.Add(Me.dtmTimeofDeparture)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtmDateofFlight)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFlightNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 311)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Flight Details"
        '
        'numMiles
        '
        Me.numMiles.Location = New System.Drawing.Point(193, 220)
        Me.numMiles.Name = "numMiles"
        Me.numMiles.Size = New System.Drawing.Size(126, 22)
        Me.numMiles.TabIndex = 57
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(74, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 17)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Plane Number"
        '
        'cboPlaneNumber
        '
        Me.cboPlaneNumber.FormattingEnabled = True
        Me.cboPlaneNumber.Location = New System.Drawing.Point(193, 249)
        Me.cboPlaneNumber.Name = "cboPlaneNumber"
        Me.cboPlaneNumber.Size = New System.Drawing.Size(126, 24)
        Me.cboPlaneNumber.TabIndex = 55
        '
        'cboDestination
        '
        Me.cboDestination.FormattingEnabled = True
        Me.cboDestination.Location = New System.Drawing.Point(193, 190)
        Me.cboDestination.Name = "cboDestination"
        Me.cboDestination.Size = New System.Drawing.Size(126, 24)
        Me.cboDestination.TabIndex = 53
        '
        'cboOrigin
        '
        Me.cboOrigin.FormattingEnabled = True
        Me.cboOrigin.Location = New System.Drawing.Point(193, 160)
        Me.cboOrigin.Name = "cboOrigin"
        Me.cboOrigin.Size = New System.Drawing.Size(126, 24)
        Me.cboOrigin.TabIndex = 52
        '
        'dtmTimeofLanding
        '
        Me.dtmTimeofLanding.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtmTimeofLanding.Location = New System.Drawing.Point(193, 132)
        Me.dtmTimeofLanding.Name = "dtmTimeofLanding"
        Me.dtmTimeofLanding.Size = New System.Drawing.Size(126, 22)
        Me.dtmTimeofLanding.TabIndex = 51
        Me.dtmTimeofLanding.Value = New Date(2024, 4, 29, 12, 0, 0, 0)
        '
        'dtmTimeofDeparture
        '
        Me.dtmTimeofDeparture.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.dtmTimeofDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtmTimeofDeparture.Location = New System.Drawing.Point(193, 104)
        Me.dtmTimeofDeparture.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.dtmTimeofDeparture.Name = "dtmTimeofDeparture"
        Me.dtmTimeofDeparture.Size = New System.Drawing.Size(126, 22)
        Me.dtmTimeofDeparture.TabIndex = 26
        Me.dtmTimeofDeparture.Value = New Date(2024, 4, 29, 12, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(76, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 17)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Flight Number"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(96, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 17)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Flight Date"
        '
        'dtmDateofFlight
        '
        Me.dtmDateofFlight.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmDateofFlight.Location = New System.Drawing.Point(193, 48)
        Me.dtmDateofFlight.Name = "dtmDateofFlight"
        Me.dtmDateofFlight.Size = New System.Drawing.Size(126, 22)
        Me.dtmDateofFlight.TabIndex = 6
        Me.dtmDateofFlight.Value = New Date(2024, 5, 2, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(132, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 17)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Miles"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(93, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Destination"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 17)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Departure Time"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(89, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Arrival Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(126, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Origin"
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Location = New System.Drawing.Point(193, 76)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(126, 22)
        Me.txtFlightNumber.TabIndex = 4
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(234, 360)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(125, 36)
        Me.btnClose.TabIndex = 28
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(92, 360)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(125, 36)
        Me.btnSubmit.TabIndex = 27
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'frmAdminAddFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 421)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmAdminAddFlight"
        Me.Text = "Add Flight"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtmDateofFlight As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents cboDestination As ComboBox
    Friend WithEvents cboOrigin As ComboBox
    Friend WithEvents dtmTimeofLanding As DateTimePicker
    Friend WithEvents dtmTimeofDeparture As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents cboPlaneNumber As ComboBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents numMiles As TextBox
End Class
