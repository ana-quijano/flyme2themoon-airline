Public Class frmAdminAddPilot
    Private Sub frmAdminAddPilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dts As DataTable = New DataTable ' this is the table we will load from our reader for State
            Dim dtr As DataTable = New DataTable ' load from read for Pilot Role

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Select statement to obtain Pilot ID
            strSelect = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)

            cboPilotRole.ValueMember = "intPilotRoleID"
            cboPilotRole.DisplayMember = "strPilotRole"
            cboPilotRole.DataSource = dts

            ' Clean up
            drSourceTable.Close()

            ' Close the database connection
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
        Dim blnValidated As Boolean = True

        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdAddPilot As New OleDb.OleDbCommand()
        Dim cmdAddEmployee As New OleDb.OleDbCommand()
        Dim cmdDeletePilot As New OleDb.OleDbCommand()
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim intNextPrimaryKey As Integer ' holds next highest PK value
        Dim intPilotRowsAffected As Integer
        Dim intEmployeeRowsAffected As Integer

        Dim intEmployeePK As Integer ' holds new pilot primary key
        Try

            Call GetValidate_Inputs(strLoginID, strPassword, strFirstName, strLastName, strEmployeeID, blnValidated)

            If blnValidated = True Then
                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

                ' --------------------------------------------
                ' Execute Stored Procedure uspPilotAdd
                ' to add new pilot to TPilots
                ' --------------------------------------------

                cmdAddPilot.CommandText = "EXECUTE uspPilotAdd " & intNextPrimaryKey & ", '" & strFirstName & "', '" & strLastName & "', '" & strEmployeeID & "', '" & dtmDateofHire.Value &
                                        "', '" & dtmDateofTermination.Value & "', '" & dtmDateofLicense.Value & "', " & intPilotRole & " , 'Active';"

                cmdAddPilot.CommandType = CommandType.StoredProcedure
                cmdAddPilot = New OleDb.OleDbCommand(cmdAddPilot.CommandText, m_conAdministrator)

                intPilotRowsAffected = cmdAddPilot.ExecuteNonQuery()

                ' If Add New Pilot successful...
                If intPilotRowsAffected = 1 Then
                    ' --------------------------------------------
                    ' Select Primary Key of newly added Pilot
                    ' --------------------------------------------
                    strSelect = "SELECT intPilotID" &
                            " FROM TPilots" &
                            " WHERE strEmployeeID = '" & strEmployeeID & "'"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    drSourceTable.Read()

                    intEmployeePK = drSourceTable("intPilotID")

                    'MessageBox.Show("New Employee ID: " & intEmployeePK)

                    ' --------------------------------------------
                    ' Execute Stored Procedure uspEmployeeAdd
                    ' to add new row for new pilot to TEmployees
                    ' --------------------------------------------
                    cmdAddEmployee.CommandText = "EXECUTE uspEmployeeAdd " & intNextPrimaryKey & ", '" & strLoginID & "', '" & strPassword & "', 'Pilot', " & intEmployeePK & ";"
                    cmdAddEmployee.CommandType = CommandType.StoredProcedure
                    cmdAddEmployee = New OleDb.OleDbCommand(cmdAddEmployee.CommandText, m_conAdministrator)

                    intEmployeeRowsAffected = cmdAddEmployee.ExecuteNonQuery()

                    If intEmployeeRowsAffected = 1 Then
                        MessageBox.Show("New Pilot has been added.")
                    Else
                        ' --------------------------------------------
                        ' Execute Stored Procedure uspPilotDelete
                        ' to delete new pilot because Employee row could not be created
                        ' --------------------------------------------
                        cmdDeletePilot.CommandText = "EXECUTE uspPilotDelete " & intEmployeePK & ";"
                        cmdDeletePilot.CommandType = CommandType.StoredProcedure
                        cmdDeletePilot = New OleDb.OleDbCommand(cmdDeletePilot.CommandText, m_conAdministrator)

                        MessageBox.Show("Transaction failed. Pilot not added.")
                    End If
                Else
                    MessageBox.Show("Transaction failed. Pilot not added.")
                End If

                CloseDatabaseConnection()
                txtLoginID.ResetText()
                txtPassword.ResetText()
                txtFirstName.ResetText()
                txtLastName.ResetText()
                txtEmployeeID.ResetText()
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
        txtEmployeeID.ResetText()
        txtPassword.ResetText()
        txtFirstName.ResetText()
        txtLastName.ResetText()
        txtEmployeeID.ResetText()
        Close()
    End Sub

End Class