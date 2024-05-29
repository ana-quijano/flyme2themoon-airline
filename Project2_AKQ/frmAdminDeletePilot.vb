Public Class frmAdminDeletePilot
    Private Sub frmAdminDeletePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strAlter As String = ""
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim cmdAlter As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Try

            ' open the DB this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement
            strSelect = "SELECT intPilotID, strEmploymentStatus, strFirstName + ' ' + strLastName as PilotName FROM TPilots WHERE strEmploymentStatus = 'Active'"

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            cboPilot.ValueMember = "intPilotID"
            cboPilot.DisplayMember = "PilotName"
            cboPilot.DataSource = dt

            'intPilotID = cboPilot.ValueMember

            ' Select the first item in the list by default
            If cboPilot.Items.Count > 0 Then cboPilot.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

            Catch excError As Exception

                ' Log and display error message
                MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strUpdate As String = ""
        Dim intRowsAffected As Integer
        Dim cmdUpdate As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim cmdDeletePilot As New OleDb.OleDbCommand()
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult  ' this is the result of which button the user selects

        intPilotID = cboPilot.SelectedValue

        Try
            ' open the database this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' always ask before deleting!!!!
            result = MessageBox.Show("Are you sure you want to Delete Pilot: " & cboPilot.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Cancelled.")
                Case DialogResult.No
                    MessageBox.Show("Action Cancelled.")
                Case DialogResult.Yes

                    ' Build the delete statement using PK from name selected

                    strUpdate = "UPDATE TPilots SET strEmploymentStatus = 'Inactive' WHERE strFirstName + ' ' + strLastName = '" & cboPilot.Text & "'"

                    ' Delete the record(s) 
                    cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)
                    intRowsAffected = cmdUpdate.ExecuteNonQuery()

                    '' --------------------------------------------
                    '' Using Stored Procedure uspPassengerTable 
                    '' to return all columns of selected customer
                    '' --------------------------------------------

                    'cmdDeletePilot.CommandText = "EXECUTE uspDeletePilot " & intPilotID & ";"
                    'cmdDeletePilot.CommandType = CommandType.StoredProcedure

                    'cmdDeletePilot = New OleDb.OleDbCommand(cmdDeletePilot.CommandText, m_conAdministrator)

                    'intRowsAffected = cmdDeletePilot.ExecuteNonQuery()

                    ' Did it work?
                    If intRowsAffected > 0 Then

                        ' Yes, success
                        MessageBox.Show("Delete successful.")

                    End If

            End Select


            ' close the database connection
            CloseDatabaseConnection()

            ' call the Form Load sub to refresh the combo box data after a delete
            frmAdminDeletePilot_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class