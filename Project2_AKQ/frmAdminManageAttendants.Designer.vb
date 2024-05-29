<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminManageAttendants
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
        Me.btnAddAttendant = New System.Windows.Forms.Button()
        Me.btnDeletePilot = New System.Windows.Forms.Button()
        Me.btnAssignPilotFlight = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddAttendant)
        Me.GroupBox1.Controls.Add(Me.btnDeletePilot)
        Me.GroupBox1.Controls.Add(Me.btnAssignPilotFlight)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 195)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manage Attendants"
        '
        'btnAddAttendant
        '
        Me.btnAddAttendant.Location = New System.Drawing.Point(16, 40)
        Me.btnAddAttendant.Name = "btnAddAttendant"
        Me.btnAddAttendant.Size = New System.Drawing.Size(193, 39)
        Me.btnAddAttendant.TabIndex = 13
        Me.btnAddAttendant.Text = "Add New Attendant"
        Me.btnAddAttendant.UseVisualStyleBackColor = True
        '
        'btnDeletePilot
        '
        Me.btnDeletePilot.Location = New System.Drawing.Point(16, 85)
        Me.btnDeletePilot.Name = "btnDeletePilot"
        Me.btnDeletePilot.Size = New System.Drawing.Size(193, 39)
        Me.btnDeletePilot.TabIndex = 14
        Me.btnDeletePilot.Text = "Delete Attendant"
        Me.btnDeletePilot.UseVisualStyleBackColor = True
        '
        'btnAssignPilotFlight
        '
        Me.btnAssignPilotFlight.Location = New System.Drawing.Point(16, 130)
        Me.btnAssignPilotFlight.Name = "btnAssignPilotFlight"
        Me.btnAssignPilotFlight.Size = New System.Drawing.Size(193, 39)
        Me.btnAssignPilotFlight.TabIndex = 15
        Me.btnAssignPilotFlight.Text = "Assign Attendant to Flight"
        Me.btnAssignPilotFlight.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(49, 242)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(174, 36)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAdminManageAttendants
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 303)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmAdminManageAttendants"
        Me.Text = "AdminManageAttendants"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAddAttendant As Button
    Friend WithEvents btnDeletePilot As Button
    Friend WithEvents btnAssignPilotFlight As Button
    Friend WithEvents btnExit As Button
End Class
