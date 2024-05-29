<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminMainMenu
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
        Me.btnStatistics = New System.Windows.Forms.Button()
        Me.btnManageAttendants = New System.Windows.Forms.Button()
        Me.btnManagePilots = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAddFutureFlight = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(39, 333)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(193, 34)
        Me.btnExit.TabIndex = 16
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnStatistics
        '
        Me.btnStatistics.Location = New System.Drawing.Point(15, 205)
        Me.btnStatistics.Name = "btnStatistics"
        Me.btnStatistics.Size = New System.Drawing.Size(193, 48)
        Me.btnStatistics.TabIndex = 15
        Me.btnStatistics.Text = "Display Statistics"
        Me.btnStatistics.UseVisualStyleBackColor = True
        '
        'btnManageAttendants
        '
        Me.btnManageAttendants.Location = New System.Drawing.Point(16, 97)
        Me.btnManageAttendants.Name = "btnManageAttendants"
        Me.btnManageAttendants.Size = New System.Drawing.Size(193, 48)
        Me.btnManageAttendants.TabIndex = 14
        Me.btnManageAttendants.Text = "Manage Attendants"
        Me.btnManageAttendants.UseVisualStyleBackColor = True
        '
        'btnManagePilots
        '
        Me.btnManagePilots.Location = New System.Drawing.Point(16, 43)
        Me.btnManagePilots.Name = "btnManagePilots"
        Me.btnManagePilots.Size = New System.Drawing.Size(193, 48)
        Me.btnManagePilots.TabIndex = 13
        Me.btnManagePilots.Text = "Manage Pilots"
        Me.btnManagePilots.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddFutureFlight)
        Me.GroupBox1.Controls.Add(Me.btnStatistics)
        Me.GroupBox1.Controls.Add(Me.btnManagePilots)
        Me.GroupBox1.Controls.Add(Me.btnManageAttendants)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 281)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Action"
        '
        'btnAddFutureFlight
        '
        Me.btnAddFutureFlight.Location = New System.Drawing.Point(15, 151)
        Me.btnAddFutureFlight.Name = "btnAddFutureFlight"
        Me.btnAddFutureFlight.Size = New System.Drawing.Size(193, 48)
        Me.btnAddFutureFlight.TabIndex = 16
        Me.btnAddFutureFlight.Text = "Add Flight"
        Me.btnAddFutureFlight.UseVisualStyleBackColor = True
        '
        'frmAdminMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 390)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmAdminMainMenu"
        Me.Text = "Admin Main Menu"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnStatistics As Button
    Friend WithEvents btnManageAttendants As Button
    Friend WithEvents btnManagePilots As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAddFutureFlight As Button
End Class
