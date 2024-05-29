Public Class frmCustomerMainMenu

    Private Sub btnUpdateCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomer.Click
        frmCustomerUpdate.ShowDialog()
    End Sub

    Private Sub btnCustomerAddFlight_Click(sender As Object, e As EventArgs) Handles btnCustomerAddFlight.Click
        frmCustomerBookFlight.ShowDialog()
    End Sub

    Private Sub btnCustomerPastFlights_Click(sender As Object, e As EventArgs) Handles btnCustomerPastFlights.Click
        frmCustomerPastFlights.ShowDialog()
    End Sub

    Private Sub btnCustomerFutureFlights_Click(sender As Object, e As EventArgs) Handles btnCustomerFutureFlights.Click
        frmCustomerFutureFlights.ShowDialog()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub frmCustomerMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class