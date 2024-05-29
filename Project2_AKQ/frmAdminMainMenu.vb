Public Class frmAdminMainMenu
    Private Sub btnManagePilots_Click(sender As Object, e As EventArgs) Handles btnManagePilots.Click
        frmAdminManagePilots.ShowDialog()
    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        frmAdminStatistics.ShowDialog()
    End Sub

    Private Sub btnManageAttendants_Click(sender As Object, e As EventArgs) Handles btnManageAttendants.Click
        frmAdminManageAttendants.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnAddFutureFlight_Click(sender As Object, e As EventArgs) Handles btnAddFutureFlight.Click
        frmAdminAddFlight.ShowDialog()
    End Sub
End Class