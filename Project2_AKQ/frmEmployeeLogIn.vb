Public Class frmEmployeeLogIn
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect As String
        Dim strSelectPilot As String
        Dim strSelectAttendant As String
        Dim strEmployeeRole As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdSelectPilot As OleDb.OleDbCommand
        Dim cmdSelectAttendant As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim drPilot As OleDb.OleDbDataReader
        Dim drAttendant As OleDb.OleDbDataReader


        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If

            Try
                ' Select statement to get Employee Role of given LogInID and Password
                strSelect = "SELECT TE.strEmployeeRole As EmployeeRole" &
                        " FROM TEmployees as TE" &
                        " WHERE TE.strEmployeeLogInID = '" & txtEmployeeLoginID.Text & "'" &
                        " and TE.strEmployeePassword = '" & txtEmployeePassword.Text & "'"

                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                drSourceTable.Read()

                strEmployeeRole = drSourceTable("EmployeeRole")

                ' If role is admin, go to admin main menu
                If strEmployeeRole = "Admin" Then
                    frmAdminMainMenu.ShowDialog()

                Else
                    ' If role is Pilot, execute Pilot select statement and go to Pilot main menu
                    If strEmployeeRole = "Pilot" Then
                        strSelectPilot = "SELECT TP.intPilotID" &
                        " FROM TEmployees as TE Join TPilots As TP" &
                        " On TE.intEmployeePK = TP.intPilotID " &
                        " WHERE TE.strEmployeeLogInID = '" & txtEmployeeLoginID.Text & "'" &
                        " and TE.strEmployeePassword = '" & txtEmployeePassword.Text & "'"

                        cmdSelectPilot = New OleDb.OleDbCommand(strSelectPilot, m_conAdministrator)
                        drPilot = cmdSelectPilot.ExecuteReader

                        drPilot.Read()

                        intPilotID = drPilot("intPilotID")
                        frmPilotMainMenu.ShowDialog()
                    Else
                        If strEmployeeRole = "Attendant" Then
                            ' If role is Attendant, execute Attendant select statement and go to Attendant main menu
                            strSelectAttendant = "SELECT TA.intAttendantID" &
                                " FROM TEmployees as TE Join TAttendants As TA" &
                                " On TE.intEmployeePK = TA.intAttendantID" &
                                " WHERE TE.strEmployeeLogInID = '" & txtEmployeeLoginID.Text & "'" &
                                " and TE.strEmployeePassword = '" & txtEmployeePassword.Text & "'"

                            cmdSelectAttendant = New OleDb.OleDbCommand(strSelectAttendant, m_conAdministrator)
                            drSourceTable = cmdSelectAttendant.ExecuteReader

                            drSourceTable.Read()

                            intAttendantID = drSourceTable("intAttendantID")

                            frmAttendantMainMenu.ShowDialog()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("LoginID and/or Password is invalid.")
                txtEmployeeLoginID.Clear()
                txtEmployeePassword.Clear()
            End Try

            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show("LoginID and/or Password is invalid.")
            txtEmployeeLoginID.Clear()
            txtEmployeePassword.Clear()
            'MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        txtEmployeeLoginID.Clear()
        txtEmployeePassword.Clear()
        Close()
    End Sub


End Class