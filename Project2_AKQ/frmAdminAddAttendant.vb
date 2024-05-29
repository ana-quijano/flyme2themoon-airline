Public Class frmAdminAddAttendant
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strLoginID As String
        Dim strPassword As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim blnValidated As Boolean = True

        Dim strSelect As String
        Dim strInsert As String
        Dim strDelete As String
        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdInsert As OleDb.OleDbCommand ' insert command object
        Dim cmdDelete As OleDb.OleDbCommand ' delete command object
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim cmdAddEmployee As New OleDb.OleDbCommand()
        Dim intNextPrimaryKey As Integer ' holds next highest PK value
        Dim intRowsAffected As Integer
        Dim intEmployeeRowsAffected As Integer = 0

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

                ' Select statement to get next highest primary key for Attendant
                strSelect = "SELECT MAX(intAttendantID) + 1 AS intNextPrimaryKey" &
                            " FROM TAttendants"

                'MessageBox.Show(strSelect)

                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                drSourceTable.Read()

                ' Null? (empty table)
                If drSourceTable.IsDBNull(0) = True Then

                    ' Yes, start numbering at 1
                    intNextPrimaryKey = 1

                Else

                    ' No, get the next highest ID
                    intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                End If

                'Insert New Row with New Attendant Attributes
                strInsert = "INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination, strEmploymentStatus)" &
                            " VALUES (" & intNextPrimaryKey & ",'" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dtmDateOfHire.Value & "','" & dtmDateOfTermination.Value & "', 'Active')"
                'MessageBox.Show(strInsert)

                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                intRowsAffected = cmdInsert.ExecuteNonQuery()

                'If Add New Attendant Successful...
                If intRowsAffected = 1 Then
                    ' --------------------------------------------
                    ' Execute Stored Procedure uspEmployeeAdd
                    ' to add new row for new attendant to TEmployees
                    ' --------------------------------------------
                    cmdAddEmployee.CommandText = "EXECUTE uspEmployeeAdd " & intNextPrimaryKey & ", '" & strLoginID & "', '" & strPassword & "', 'Attendant', " & intNextPrimaryKey & ";"
                    cmdAddEmployee.CommandType = CommandType.StoredProcedure
                    cmdAddEmployee = New OleDb.OleDbCommand(cmdAddEmployee.CommandText, m_conAdministrator)

                    intEmployeeRowsAffected = cmdAddEmployee.ExecuteNonQuery()

                    If intEmployeeRowsAffected = 1 Then
                        MessageBox.Show("New Attendant has been added.")
                    Else
                        ' Failed to add new employee, also delete new attendant
                        strDelete = "DELETE FROM TAttendants" &
                                    " WHERE intAttendantID = " & intNextPrimaryKey
                        cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)

                        MessageBox.Show("Transaction failed. Attendant not added.")
                    End If
                Else
                    MessageBox.Show("Transaction failed. Attendant not added.")
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

    Private Sub frmAdminAddAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
