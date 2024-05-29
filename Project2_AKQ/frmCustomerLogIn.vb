Public Class frmCustomerLogIn

    Private Sub btnAddNewCustomer_Click(sender As Object, e As EventArgs) Handles btnAddNewCustomer.Click
        frmCustomerAdd.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable

        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If

            Try
                ' Select statement to get PassengerID with corresponding LogInID and Password
                strSelect = "SELECT TP.intPassengerID, TP.strFirstName, TP.strLastName" &
                        " FROM TPassengers As TP" &
                        " WHERE strPassengerLoginID = '" & txtCustomerLogInID.Text & "'" &
                        " AND strPassengerPassword = '" & txtCustomerPassword.Text & "'"

                'MessageBox.Show(strSelect)

                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                drSourceTable.Read()

                intCustomerID = drSourceTable("intPassengerID")
                frmCustomerMainMenu.ShowDialog()

                drSourceTable.Close()
                CloseDatabaseConnection()

                txtCustomerLogInID.Clear()
                txtCustomerPassword.Clear()

            Catch ex As Exception

                MessageBox.Show("Customer ID and/or Password not valid.")

            End Try

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub frmCustomerLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class