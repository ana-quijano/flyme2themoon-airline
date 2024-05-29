Public Class frmAdminManageAttendants
    Private Sub btnAddAttendant_Click(sender As Object, e As EventArgs) Handles btnAddAttendant.Click
        frmAdminAddAttendant.ShowDialog()
    End Sub

    Private Sub btnDeletePilot_Click(sender As Object, e As EventArgs) Handles btnDeletePilot.Click
        frmAdminDeleteAttendant.ShowDialog()
    End Sub

    Private Sub btnAssignPilotFlight_Click(sender As Object, e As EventArgs) Handles btnAssignPilotFlight.Click
        frmAdminAssignAttendant.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class