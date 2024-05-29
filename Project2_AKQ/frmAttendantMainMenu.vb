Public Class frmAttendantMainMenu
    Private Sub btnUpdateAttendant_Click(sender As Object, e As EventArgs) Handles btnUpdateAttendant.Click
        frmAttendantUpdate.ShowDialog()
    End Sub

    Private Sub btnAttendantPastFlights_Click(sender As Object, e As EventArgs) Handles btnAttendantPastFlights.Click
        frmAttendantPastFlights.ShowDialog()
    End Sub

    Private Sub btnAttendantFutureFlights_Click(sender As Object, e As EventArgs) Handles btnAttendantFutureFlights.Click
        frmAttendantFutureFlights.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class