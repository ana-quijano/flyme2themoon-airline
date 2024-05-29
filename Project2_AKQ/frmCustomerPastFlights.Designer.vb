<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerPastFlights
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
        Me.lstPastFlights = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalMilesFlown = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstPastFlights
        '
        Me.lstPastFlights.FormattingEnabled = True
        Me.lstPastFlights.ItemHeight = 16
        Me.lstPastFlights.Location = New System.Drawing.Point(40, 35)
        Me.lstPastFlights.Name = "lstPastFlights"
        Me.lstPastFlights.Size = New System.Drawing.Size(370, 324)
        Me.lstPastFlights.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(119, 376)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total Miles:"
        '
        'lblTotalMilesFlown
        '
        Me.lblTotalMilesFlown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalMilesFlown.Location = New System.Drawing.Point(212, 373)
        Me.lblTotalMilesFlown.Name = "lblTotalMilesFlown"
        Me.lblTotalMilesFlown.Size = New System.Drawing.Size(120, 23)
        Me.lblTotalMilesFlown.TabIndex = 2
        Me.lblTotalMilesFlown.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(138, 419)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(174, 36)
        Me.btnClose.TabIndex = 21
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmCustomerPastFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 480)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblTotalMilesFlown)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstPastFlights)
        Me.Name = "frmCustomerPastFlights"
        Me.Text = "Past Flights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstPastFlights As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTotalMilesFlown As Label
    Friend WithEvents btnClose As Button
End Class
