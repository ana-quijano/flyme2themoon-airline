Public Class frmMainLogin
    Private Sub btnCustomerLogIn_Click(sender As Object, e As EventArgs) Handles btnCustomerLogIn.Click
        frmCustomerLogIn.ShowDialog()
    End Sub

    Private Sub btnEmployeeLogIn_Click(sender As Object, e As EventArgs) Handles btnEmployeeLogIn.Click
        frmEmployeeLogIn.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class