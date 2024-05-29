Public Class frmAttendantUpdate
    Private Sub frmAttendantUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dts As DataTable = New DataTable ' this is the table we will load from our reader for State

        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            strSelect = "SELECT TE.strEmployeeLogInID, TE.strEmployeePassword, TA.strFirstName, TA.strLastName, TA.strEmployeeID, TA.dtmDateOfHire, TA.dtmDateOfTermination" &
                        " FROM TEmployees As TE Join TAttendants As TA" &
                        " ON TE.intEmployeePK = TA.intAttendantID" &
                        " WHERE TE.strEmployeeRole = 'Attendant'" &
                        " and TA.intAttendantID = " & intAttendantID

            'MessageBox.Show(strSelect)

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            txtLoginID.Text = drSourceTable("strEmployeeLogInID")
            txtPassword.Text = drSourceTable("strEmployeePassword")
            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtEmployeeID.Text = drSourceTable("strEmployeeID")
            dtmDateofHire.Value = drSourceTable("dtmDateOfHire")
            dtmDateofTermination.Value = drSourceTable("dtmDateOfTermination")

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strLoginID As String
        Dim strPassword As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim intRowsAffected As Integer
        Dim blnValidated As Boolean = True
        Dim strUpdate As String
        Dim cmdUpdateAttendant As New OleDb.OleDbCommand()
        Dim cmdUpdate As New OleDb.OleDbCommand()
        Dim intEmployeeRowsAffected As Integer

        Try
            ' open database this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            Call GetValidate_Inputs(strLoginID, strPassword, strFirstName, strLastName, strEmployeeID, blnValidated)

            If blnValidated = True Then

                ' --------------------------------------------
                ' Using Stored Procedure uspUpdateAttendant
                ' --------------------------------------------

                cmdUpdateAttendant.CommandText = "EXECUTE uspAttendantUpdate " & intAttendantID & ", '" & strFirstName & "', '" & strLastName & "', '" & strEmployeeID & "', '" & dtmDateofHire.Value & "', '" & dtmDateofTermination.Value & "'; "
                cmdUpdateAttendant.CommandType = CommandType.StoredProcedure

                cmdUpdateAttendant = New OleDb.OleDbCommand(cmdUpdateAttendant.CommandText, m_conAdministrator)

                intRowsAffected = cmdUpdateAttendant.ExecuteNonQuery()

                ' have to let the user know what happened 
                If intRowsAffected = 1 Then
                    strUpdate = "UPDATE TEmployees SET " &
                            " strEmployeeLogInID = '" & strLoginID & "'," &
                            " strEmployeePassword = '" & strPassword & "'" &
                            " WHERE strEmployeeRole = 'Attendant'" &
                            " and intEmployeePK = " & intAttendantID
                    ' MessageBox.Show(strUpdate)
                    cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)

                    intEmployeeRowsAffected = cmdUpdate.ExecuteNonQuery()

                    If intEmployeeRowsAffected = 1 Then
                        MessageBox.Show("Update successful.")
                    Else
                        MessageBox.Show("Update failed.")
                    End If
                Else
                    MessageBox.Show("Update failed.")
                End If

                ' close the database connection
                CloseDatabaseConnection()

                Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetValidate_Inputs(ByRef strLoginID As String, ByRef strPassword As String, ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeID As String, ByRef blnValidated As Boolean)

        Call GetValidate_LogInID(strLoginID, blnValidated)
        If blnValidated = True Then
            Call GetValidate_Password(strPassword, blnValidated)
            If blnValidated = True Then
                Call GetValidate_FirstName(strFirstName, blnValidated)
                If blnValidated = True Then
                    Call GetValidate_LastName(strLastName, blnValidated)
                    If blnValidated = True Then
                        Call GetValidate_EmployeeID(strEmployeeID, blnValidated)
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub GetValidate_LogInID(ByRef strLoginID As String, ByRef blnValidated As Boolean)
        strLoginID = txtLoginID.Text
        If strLoginID = "" Then
            MessageBox.Show("Login ID is required.")
            txtLoginID.Focus()
            blnValidated = False
        Else
            If strLoginID.Length < 6 Then
                MessageBox.Show("Login ID must be at least 6 characters long and must not contain spaces.")
                txtLoginID.Focus()
                blnValidated = False
            End If
        End If
    End Sub

    Private Sub GetValidate_Password(ByRef strPassword As String, ByRef blnValidated As Boolean)
        strPassword = txtPassword.Text
        If strPassword = "" Then
            MessageBox.Show("Password is required.")
            txtPassword.Focus()
            blnValidated = False
        Else
            If strPassword.Length < 8 Then
                MessageBox.Show("Password must be at least 8 characters long.")
                txtPassword.Focus()
                blnValidated = False
            End If
        End If
    End Sub

    Private Sub GetValidate_FirstName(ByRef strFirstName As String, ByRef blnValidated As Boolean)
        strFirstName = txtFirstName.Text
        If strFirstName = "" Then
            MessageBox.Show("First Name is required.")
            txtFirstName.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub GetValidate_LastName(ByRef strLastName As String, ByRef blnValidated As Boolean)
        strLastName = txtLastName.Text
        If strLastName = "" Then
            MessageBox.Show("Last Name is required.")
            txtLastName.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub GetValidate_EmployeeID(ByRef strEmployeeID As String, ByRef blnValidated As Boolean)
        strEmployeeID = txtEmployeeID.Text
        If strEmployeeID = "" Then
            MessageBox.Show("Employee ID is required.")
            txtEmployeeID.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class