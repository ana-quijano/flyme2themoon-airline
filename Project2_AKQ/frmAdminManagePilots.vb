Public Class frmAdminManagePilots
    Private Sub btnAddPilot_Click(sender As Object, e As EventArgs) Handles btnAddPilot.Click
        frmAdminAddPilot.ShowDialog()
    End Sub

    Private Sub btnDeletePilot_Click(sender As Object, e As EventArgs) Handles btnDeletePilot.Click
        frmAdminDeletePilot.ShowDialog()
    End Sub

    Private Sub btnAddPilotFlight_Click(sender As Object, e As EventArgs) Handles btnAssignPilotFlight.Click
        frmAdminAssignPilot.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

End Class