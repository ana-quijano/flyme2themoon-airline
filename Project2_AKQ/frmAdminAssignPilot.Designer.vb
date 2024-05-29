<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminAssignPilot
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
        Me.cboPilot = New System.Windows.Forms.ComboBox()
        Me.lstFlight = New System.Windows.Forms.ListBox()
        Me.cboFlight = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPilot)
        Me.GroupBox1.Controls.Add(Me.lstFlight)
        Me.GroupBox1.Controls.Add(Me.cboFlight)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 246)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pilot and Flight Details"
        '
        'cboPilot
        '
        Me.cboPilot.FormattingEnabled = True
        Me.cboPilot.Location = New System.Drawing.Point(145, 53)
        Me.cboPilot.Name = "cboPilot"
        Me.cboPilot.Size = New System.Drawing.Size(207, 24)
        Me.cboPilot.TabIndex = 7
        '
        'lstFlight
        '
        Me.lstFlight.FormattingEnabled = True
        Me.lstFlight.ItemHeight = 16
        Me.lstFlight.Location = New System.Drawing.Point(39, 113)
        Me.lstFlight.Name = "lstFlight"
        Me.lstFlight.Size = New System.Drawing.Size(313, 100)
        Me.lstFlight.TabIndex = 6
        '
        'cboFlight
        '
        Me.cboFlight.FormattingEnabled = True
        Me.cboFlight.Location = New System.Drawing.Point(145, 83)
        Me.cboFlight.Name = "cboFlight"
        Me.cboFlight.Size = New System.Drawing.Size(207, 24)
        Me.cboFlight.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Select Flight:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Select Pilot:"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(280, 306)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(111, 36)
        Me.btnClose.TabIndex = 26
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(60, 306)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(203, 36)
        Me.btnSubmit.TabIndex = 25
        Me.btnSubmit.Text = "Assign Pilot to Flight"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'frmAdminAssignPilot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 372)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSubmit)
        Me.Name = "frmAdminAssignPilot"
        Me.Text = "Assign Pilot to Flight"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lstFlight As ListBox
    Friend WithEvents cboFlight As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents cboPilot As ComboBox
End Class
