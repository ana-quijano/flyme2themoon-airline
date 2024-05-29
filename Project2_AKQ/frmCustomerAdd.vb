Public Class frmCustomerAdd
    Private Sub frmCustomerAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dts As DataTable = New DataTable ' this is the table we will load from our reader for State

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

            '' Select Case statement To obtain States
            'strSelect = "SELECT intStateID, strState FROM TStates"

            'cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            'drSourceTable = cmdSelect.ExecuteReader
            'dts.Load(drSourceTable)

            ' ---------------------------------------------------
            ' Using Stored Procedure uspStatesTable to get States
            ' ---------------------------------------------------

            cmdSelect = New OleDb.OleDbCommand("uspStatesTable", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)

            cboState.ValueMember = "intStateID"
            cboState.DisplayMember = "strState"
            cboState.DataSource = dts

            ' Clean up
            drSourceTable.Close()

            ' Close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer = cboState.SelectedValue
        Dim strZip As String
        Dim strPhoneNumber As String
        Dim strEmail As String
        Dim strCustomerID As String
        Dim strPassword As String
        Dim intRowsAffected As Integer
        Dim blnValidated As Boolean = True

        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdInsert As OleDb.OleDbCommand ' insert command object
        Dim cmdAddPassenger As New OleDb.OleDbCommand()
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim intNextPrimaryKey As Integer = 0 ' holds next highest PK value

        Try

            Call GetValidate_Inputs(strFirstName, strLastName, strAddress, strCity, strZip, strPhoneNumber, strEmail, strCustomerID, strPassword, blnValidated)

            If blnValidated = True Then
                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

                ' --------------------------------------------
                ' Execute Stored Procedure uspCustomerAdd
                ' --------------------------------------------

                cmdAddPassenger.CommandText = "EXECUTE uspCustomerAdd " & intNextPrimaryKey & ", '" & strFirstName & "','" & strLastName & "','" & strAddress & "','" & strCity & "'," & intState &
                                            ",'" & strZip & "','" & strPhoneNumber & "','" & strEmail & "','" & strCustomerID & "','" & strPassword & "','" & dtmDateofBirth.Value & "';"

                cmdAddPassenger.CommandType = CommandType.StoredProcedure

                cmdAddPassenger = New OleDb.OleDbCommand(cmdAddPassenger.CommandText, m_conAdministrator)

                intRowsAffected = cmdAddPassenger.ExecuteNonQuery()

                If intRowsAffected = 1 Then
                    ' --------------------------------------------
                    ' Select Primary Key of newly added Passenger
                    ' --------------------------------------------
                    strSelect = "SELECT intPassengerID" &
                            " FROM TPassengers" &
                            " WHERE strPhoneNumber = '" & strPhoneNumber & "'"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    drSourceTable.Read()

                    intCustomerID = drSourceTable("intPassengerID")

                    ' MessageBox.Show("New Passenger First Name: " & intCustomerID)
                    MessageBox.Show("Passenger has been added. Click OK to go to Main Menu.")
                    frmCustomerMainMenu.ShowDialog()
                Else
                    MessageBox.Show("Transaction failed. Passenger not added.")
                End If

                CloseDatabaseConnection()

                Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetValidate_Inputs(ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String,
                                   ByRef strZip As String, ByRef strPhone As String, ByRef strEmail As String, ByRef strCustomerID As String,
                                   ByRef strPassword As String, ByRef blnValidated As Boolean)

        Call GetValidate_FirstName(strFirstName, blnValidated)
        If blnValidated = True Then
            Call GetValidate_LastName(strLastName, blnValidated)
            If blnValidated = True Then
                Call GetValidate_Address(strAddress, blnValidated)
                If blnValidated = True Then
                    Call GetValidate_City(strCity, blnValidated)
                    If blnValidated = True Then
                        Call GetValidate_Zip(strZip, blnValidated)
                        If blnValidated = True Then
                            Call GetValidate_Phone(strPhone, blnValidated)
                            If blnValidated = True Then
                                Call GetValidate_Email(strEmail, blnValidated)
                                If blnValidated = True Then
                                    Call GetValidate_CustomerID(strCustomerID, blnValidated)
                                    If blnValidated = True Then
                                        Call GetValidate_Password(strPassword, blnValidated)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GetValidate_CustomerID(ByRef strCustomerID As String, ByRef blnValidated As Boolean)
        strCustomerID = txtCustomerID.Text
        If strCustomerID = "" Then
            MessageBox.Show("CustomerID is required.")
            txtCustomerID.Focus()
            blnValidated = False
        Else
            If strCustomerID.Length < 6 Then
                MessageBox.Show("CustomerID must be at least 6 characters long and must not contain spaces.")
                txtCustomerID.Focus()
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

    Private Sub GetValidate_Address(ByRef strAddress As String, ByRef blnValidated As Boolean)
        strAddress = txtAddress.Text
        If strAddress = "" Then
            MessageBox.Show("Address is required.")
            txtAddress.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub GetValidate_City(ByRef strCity As String, ByRef blnValidated As Boolean)
        strCity = txtCity.Text
        If strCity = "" Then
            MessageBox.Show("City is required.")
            txtCity.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub GetValidate_Zip(ByRef strZip As String, ByRef blnValidated As Boolean)
        strZip = txtZip.Text
        If strZip = "" Then
            MessageBox.Show("Zip Code is required and must be five digits.")
            txtZip.Focus()
            blnValidated = False
        Else
            If strZip.Length <> 5 Then
                MessageBox.Show("Zip Code must be five digits.")
                txtZip.Focus()
                blnValidated = False
            End If
        End If
    End Sub

    Private Sub GetValidate_Phone(ByRef strPhoneNumber As String, ByRef blnValidated As Boolean)
        strPhoneNumber = txtPhone.Text
        If strPhoneNumber = "" Then
            MessageBox.Show("Phone Number is required and must be ten digits.")
            txtPhone.Focus()
            blnValidated = False
        Else
            If strPhoneNumber.Length <> 10 Then
                MessageBox.Show("Phone Number must be ten digits.")
                txtPhone.Focus()
                blnValidated = False
            End If
        End If
    End Sub

    Private Sub GetValidate_Email(ByRef strEmail As String, ByRef blnValidated As Boolean)
        strEmail = txtEmail.Text
        If strEmail = "" Then
            MessageBox.Show("Email Address is required and must contain '@'.")
            txtEmail.Focus()
            blnValidated = False
        Else
            If strEmail.IndexOf("@") < 1 Then
                MessageBox.Show("Email Address must contain '@'.")
                txtEmail.Focus()
                blnValidated = False
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

End Class