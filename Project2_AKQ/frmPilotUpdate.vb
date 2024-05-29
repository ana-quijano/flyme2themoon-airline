Public Class frmPilotUpdate
    Private Sub frmPilotUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dts As DataTable = New DataTable ' this is the table we will load from our reader for State
        Dim dte As DataTable = New DataTable ' this is the table we will load from our reader for Employees

        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            ' Select statement to obtain Pilot Roles
            strSelect = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)

            cboPilotRole.ValueMember = "intPilotRoleID"
            cboPilotRole.DisplayMember = "strPilotRole"
            cboPilotRole.DataSource = dts

            strSelect = "SELECT TE.strEmployeeLogInID, TE.strEmployeePassword, TP.strFirstName, TP.strLastName, TP.strEmployeeID, TP.dtmDateOfHire, TP.dtmDateOfTermination,
                        TP.dtmDateOfLicense, TP.intPilotRoleID" &
                        " FROM TEmployees As TE Join TPilots As TP" &
                        " ON TE.intEmployeePK = TP.intPilotID" &
                        " WHERE TE.strEmployeeRole = 'Pilot'" &
                        " and TP.intPilotID = " & intPilotID

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
            dtmDateofLicense.Value = drSourceTable("dtmDateOfLicense")
            cboPilotRole.SelectedValue = drSourceTable("intPilotRoleID")

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
        Dim intPilotRole As Integer = cboPilotRole.SelectedValue
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer
        Dim intEmployeePK As Integer
        Dim blnValidated As Boolean = True

        ' this will hold our Update statement
        Dim strUpdate As String
        Dim cmdUpdatePilot As New OleDb.OleDbCommand()
        Dim cmdUpdate As OleDb.OleDbCommand
        Dim cmdSelect As OleDb.OleDbCommand
        Dim strSelect As String
        Dim drSourceTable As OleDb.OleDbDataReader
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
                '' Build the select statement using PK from name selected
                'strUpdate = "UPDATE TPilots Set " &
                '        "strFirstName = '" & strFirstName & "', " &
                '        "strLastName = '" & strLastName & "', " &
                '        "strEmployeeID = '" & strEmployeeID & "', " &
                '        "dtmDateOfHire = '" & dtmDateOfHire & "', " &
                '        "dtmDateOfTermination = " & dtmDateOfTermination & ", " &
                '        "dtmDateOfLicense = '" & dtmDateOfLicense & "', " &
                '        "intPilotRoleID = " & intPilotRole &
                '        " WHERE intPilotID = " & intCustomerID

                '' make the connection
                'cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)

                '' IUpdate the row with execute the statement
                'intRowsAffected = cmdUpdate.ExecuteNonQuery()

                ' --------------------------------------------
                ' Using Stored Procedure uspPilotUpdate
                ' --------------------------------------------

                cmdUpdatePilot.CommandText = "EXECUTE uspPilotUpdate '" & intPilotID & "', '" & strFirstName & "', '" & strLastName & "', '" & strEmployeeID & "', '" & dtmDateofHire.Value & "', '" & dtmDateofTermination.Value & "', '" & dtmDateofLicense.Value & "', " & intPilotRole & ", 'Active';"
                cmdUpdatePilot.CommandType = CommandType.StoredProcedure

                cmdUpdatePilot = New OleDb.OleDbCommand(cmdUpdatePilot.CommandText, m_conAdministrator)

                intRowsAffected = cmdUpdatePilot.ExecuteNonQuery()

                'If update successful, then also update the Employees Table
                If intRowsAffected = 1 Then

                    strUpdate = "UPDATE TEmployees SET " &
                            " strEmployeeLogInID = '" & strLoginID & "'," &
                            " strEmployeePassword = '" & strPassword & "'" &
                            " WHERE strEmployeeRole = 'Pilot'" &
                            " and intEmployeePK = " & intPilotID

                    cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)

                    intEmployeeRowsAffected = cmdUpdate.ExecuteNonQuery()

                    ' If update successful for both tables, let user know
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

    Private Sub GetValidate_Inputs(ByRef strLoginID As String, ByRef strPassword As String, ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeID As String,
                                   ByRef blnValidated As Boolean)

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