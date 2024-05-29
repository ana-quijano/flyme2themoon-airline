<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerBookFlight
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblAssignSeatFlightCost = New System.Windows.Forms.Label()
        Me.lblReservedSeatFlighCost = New System.Windows.Forms.Label()
        Me.radAssignedSeat = New System.Windows.Forms.RadioButton()
        Me.radReservedSeat = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstFlight = New System.Windows.Forms.ListBox()
        Me.cboSeat = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFlight = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(226, 380)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(142, 35)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(78, 380)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(142, 35)
        Me.btnSubmit.TabIndex = 21
        Me.btnSubmit.Text = "Book Flight"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAssignSeatFlightCost)
        Me.GroupBox1.Controls.Add(Me.lblReservedSeatFlighCost)
        Me.GroupBox1.Controls.Add(Me.radAssignedSeat)
        Me.GroupBox1.Controls.Add(Me.radReservedSeat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lstFlight)
        Me.GroupBox1.Controls.Add(Me.cboSeat)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboFlight)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 329)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Flight Details"
        '
        'lblAssignSeatFlightCost
        '
        Me.lblAssignSeatFlightCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAssignSeatFlightCost.Location = New System.Drawing.Point(229, 284)
        Me.lblAssignSeatFlightCost.Name = "lblAssignSeatFlightCost"
        Me.lblAssignSeatFlightCost.Size = New System.Drawing.Size(129, 23)
        Me.lblAssignSeatFlightCost.TabIndex = 11
        Me.lblAssignSeatFlightCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReservedSeatFlighCost
        '
        Me.lblReservedSeatFlighCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReservedSeatFlighCost.Location = New System.Drawing.Point(229, 257)
        Me.lblReservedSeatFlighCost.Name = "lblReservedSeatFlighCost"
        Me.lblReservedSeatFlighCost.Size = New System.Drawing.Size(129, 23)
        Me.lblReservedSeatFlighCost.TabIndex = 10
        Me.lblReservedSeatFlighCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radAssignedSeat
        '
        Me.radAssignedSeat.AutoSize = True
        Me.radAssignedSeat.Location = New System.Drawing.Point(30, 285)
        Me.radAssignedSeat.Name = "radAssignedSeat"
        Me.radAssignedSeat.Size = New System.Drawing.Size(179, 21)
        Me.radAssignedSeat.TabIndex = 9
        Me.radAssignedSeat.Text = "Assign Seat at Check-In"
        Me.radAssignedSeat.UseVisualStyleBackColor = True
        '
        'radReservedSeat
        '
        Me.radReservedSeat.AutoSize = True
        Me.radReservedSeat.Checked = True
        Me.radReservedSeat.Location = New System.Drawing.Point(30, 258)
        Me.radReservedSeat.Name = "radReservedSeat"
        Me.radReservedSeat.Size = New System.Drawing.Size(123, 21)
        Me.radReservedSeat.TabIndex = 8
        Me.radReservedSeat.TabStop = True
        Me.radReservedSeat.Text = "Reserved Seat"
        Me.radReservedSeat.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(244, 231)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Total Flight Cost:"
        '
        'lstFlight
        '
        Me.lstFlight.FormattingEnabled = True
        Me.lstFlight.ItemHeight = 16
        Me.lstFlight.Location = New System.Drawing.Point(30, 100)
        Me.lstFlight.Name = "lstFlight"
        Me.lstFlight.Size = New System.Drawing.Size(328, 116)
        Me.lstFlight.TabIndex = 6
        '
        'cboSeat
        '
        Me.cboSeat.FormattingEnabled = True
        Me.cboSeat.Items.AddRange(New Object() {"2A", "2B", "3C", "3D"})
        Me.cboSeat.Location = New System.Drawing.Point(128, 70)
        Me.cboSeat.Name = "cboSeat"
        Me.cboSeat.Size = New System.Drawing.Size(90, 24)
        Me.cboSeat.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Select Seat:"
        '
        'cboFlight
        '
        Me.cboFlight.FormattingEnabled = True
        Me.cboFlight.Location = New System.Drawing.Point(128, 40)
        Me.cboFlight.Name = "cboFlight"
        Me.cboFlight.Size = New System.Drawing.Size(230, 24)
        Me.cboFlight.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Select Flight:"
        '
        'frmCustomerBookFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 445)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSubmit)
        Me.Name = "frmCustomerBookFlight"
        Me.Text = "Book Flight"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboFlight As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboSeat As ComboBox
    Friend WithEvents lstFlight As ListBox
    Friend WithEvents radAssignedSeat As RadioButton
    Friend WithEvents radReservedSeat As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAssignSeatFlightCost As Label
    Friend WithEvents lblReservedSeatFlighCost As Label
End Class
