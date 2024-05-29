<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdminStatistics
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstAttendants = New System.Windows.Forms.ListBox()
        Me.lstPilots = New System.Windows.Forms.ListBox()
        Me.lblTotalNumberofCustomers = New System.Windows.Forms.Label()
        Me.lblTotalFlightsTakenByAllCustomers = New System.Windows.Forms.Label()
        Me.lblAverageMilesFlownForAllCustomers = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Number of Customers:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(243, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Flights Taken By All Customers:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Average Miles Flown For All Customers:"
        '
        'lstAttendants
        '
        Me.lstAttendants.FormattingEnabled = True
        Me.lstAttendants.ItemHeight = 16
        Me.lstAttendants.Location = New System.Drawing.Point(42, 306)
        Me.lstAttendants.Name = "lstAttendants"
        Me.lstAttendants.Size = New System.Drawing.Size(370, 164)
        Me.lstAttendants.TabIndex = 3
        '
        'lstPilots
        '
        Me.lstPilots.FormattingEnabled = True
        Me.lstPilots.ItemHeight = 16
        Me.lstPilots.Location = New System.Drawing.Point(42, 136)
        Me.lstPilots.Name = "lstPilots"
        Me.lstPilots.Size = New System.Drawing.Size(370, 164)
        Me.lstPilots.TabIndex = 4
        '
        'lblTotalNumberofCustomers
        '
        Me.lblTotalNumberofCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalNumberofCustomers.Location = New System.Drawing.Point(312, 36)
        Me.lblTotalNumberofCustomers.Name = "lblTotalNumberofCustomers"
        Me.lblTotalNumberofCustomers.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalNumberofCustomers.TabIndex = 5
        Me.lblTotalNumberofCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalFlightsTakenByAllCustomers
        '
        Me.lblTotalFlightsTakenByAllCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalFlightsTakenByAllCustomers.Location = New System.Drawing.Point(312, 68)
        Me.lblTotalFlightsTakenByAllCustomers.Name = "lblTotalFlightsTakenByAllCustomers"
        Me.lblTotalFlightsTakenByAllCustomers.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalFlightsTakenByAllCustomers.TabIndex = 6
        Me.lblTotalFlightsTakenByAllCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAverageMilesFlownForAllCustomers
        '
        Me.lblAverageMilesFlownForAllCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAverageMilesFlownForAllCustomers.Location = New System.Drawing.Point(312, 100)
        Me.lblAverageMilesFlownForAllCustomers.Name = "lblAverageMilesFlownForAllCustomers"
        Me.lblAverageMilesFlownForAllCustomers.Size = New System.Drawing.Size(100, 23)
        Me.lblAverageMilesFlownForAllCustomers.TabIndex = 7
        Me.lblAverageMilesFlownForAllCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(151, 492)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(149, 36)
        Me.btnClose.TabIndex = 24
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmAdminStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 553)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblAverageMilesFlownForAllCustomers)
        Me.Controls.Add(Me.lblTotalFlightsTakenByAllCustomers)
        Me.Controls.Add(Me.lblTotalNumberofCustomers)
        Me.Controls.Add(Me.lstPilots)
        Me.Controls.Add(Me.lstAttendants)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAdminStatistics"
        Me.Text = "FlyMe2theMoon Statistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lstAttendants As ListBox
    Friend WithEvents lstPilots As ListBox
    Friend WithEvents lblTotalNumberofCustomers As Label
    Friend WithEvents lblTotalFlightsTakenByAllCustomers As Label
    Friend WithEvents lblAverageMilesFlownForAllCustomers As Label
    Friend WithEvents btnClose As Button
End Class
