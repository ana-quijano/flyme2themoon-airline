Public Class frmCustomerUpdate
    Private Sub frmCustomerUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect = ""
        Dim strName = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim objParam As OleDb.OleDbParameter           ' this will be used to add parameters needed for stored procedures
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

            ' Select statement to obtain States
            strSelect = "SELECT intStateID, strState FROM TStates"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)

            cboState.ValueMember = "intStateID"
            cboState.DisplayMember = "strState"
            cboState.DataSource = dts

            ' --------------------------------------------
            ' Execute Stored Procedure uspCustomerUpdateTable 
            ' to return all columns of selected customer
            ' --------------------------------------------
            cmdSelect = New OleDb.OleDbCommand("uspCustomerUpdateTable", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@intPassengerID", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intCustomerID

            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            txtLoginID.Text = drSourceTable("strPassengerLoginID")
            txtPassword.Text = drSourceTable("strPassengerPassword")
            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtAddress.Text = drSourceTable("strAddress")
            txtCity.Text = drSourceTable("strCity")
            cboState.SelectedValue = drSourceTable("intStateID")
            txtZip.Text = drSourceTable("strZip")
            dtmDateofBirth.Value = drSourceTable("dtmDateofBirth")
            txtPhone.Text = drSourceTable("strPhoneNumber")
            txtEmail.Text = drSourceTable("strEmail")

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

        ' thie will hold our Update statement
        Dim cmdUpdate As OleDb.OleDbCommand
        Dim cmdUpdatePassenger As New OleDb.OleDbCommand()

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

            Call GetValidate_Inputs(strFirstName, strLastName, strAddress, strCity, strZip, strPhoneNumber, strEmail, strCustomerID, strPassword, blnValidated)

            If blnValidated = True Then

                ' --------------------------------------------
                ' Execute Stored Procedure uspCustomerUpdateUpdate
                ' --------------------------------------------

                cmdUpdatePassenger.CommandText = "EXECUTE uspCustomerUpdate " & intCustomerID & ",'" & strFirstName & "','" & strLastName & "','" & strAddress & "','" & strCity & "'," & intState & ",'" & strZip & "','" & strPhoneNumber & "','" & strEmail & "','" & strCustomerID & "','" & strPassword & "','" & dtmDateofBirth.Value & "';"
                cmdUpdatePassenger.CommandType = CommandType.StoredProcedure

                cmdUpdatePassenger = New OleDb.OleDbCommand(cmdUpdatePassenger.CommandText, m_conAdministrator)

                intRowsAffected = cmdUpdatePassenger.ExecuteNonQuery()

                ' have to let the user know what happened 
                If intRowsAffected = 1 Then
                    MessageBox.Show("Update successful.")
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

    ' --------------------------------------------
    ' Validation Procedures
    ' --------------------------------------------
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

    Private Sub GetValidate_CustomerID(ByRef strCustomerID As String, ByRef blnValidated As Boolean)
        strCustomerID = txtLoginID.Text
        If strCustomerID = "" Then
            MessageBox.Show("CustomerID is required.")
            txtLoginID.Focus()
            blnValidated = False
        Else
            If strCustomerID.Length < 6 Then
                MessageBox.Show("CustomerID must be at least 6 characters long and must not contain spaces.")
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub


End Class