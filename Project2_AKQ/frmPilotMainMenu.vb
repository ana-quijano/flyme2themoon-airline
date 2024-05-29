Public Class frmPilotMainMenu

    Private Sub btnUpdatePilot_Click(sender As Object, e As EventArgs) Handles btnUpdatePilot.Click
        frmPilotUpdate.ShowDialog()
    End Sub

    Private Sub btnCustomerPastFlights_Click(sender As Object, e As EventArgs) Handles btnCustomerPastFlights.Click
        frmPilotPastFlights.ShowDialog()
    End Sub

    Private Sub btnCustomerFutureFlights_Click(sender As Object, e As EventArgs) Handles btnCustomerFutureFlights.Click
        frmPilotFutureFlights.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

End Class