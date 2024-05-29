Public Class frmAdminAssignPilot
    Private Sub frmAdminAssignPilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable
        Dim dtf As DataTable = New DataTable
        Dim objParam As OleDb.OleDbParameter           ' this will be used to add parameters needed for stored procedures

        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If
            'Select Statement for Pilot
            strSelect = "SELECT intPilotID, strEmploymentStatus, strFirstName + ' ' + strLastName as PilotName FROM TPilots WHERE strEmploymentStatus <> 'Inactive'"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            cboPilot.ValueMember = "intPilotID"
            cboPilot.DisplayMember = "PilotName"
            cboPilot.DataSource = dt

            ' Select the first item in the list by default
            If cboPilot.Items.Count > 0 Then cboPilot.SelectedIndex = 0

            'Select statement for flight
            strSelect = "Select TFlights.intFlightID, TAFrom.strAirportCity + ' to ' + TATo.strAirportCity As FlightFromTo
                            From TFlights Join TAirports As TAFrom
                            On TFlights.intFromAirportID = TAFrom.intAirportID
                         Join TAirports As TATo
                            On TFlights.intToAirportID = TATo.intAirportID
                            Where TFlights.dtmFlightDate > '04/04/2024'"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dtf.Load(drSourceTable)

            ' We are binding the column name to the combo box display and value members.

            cboFlight.ValueMember = "intFlightID"
            cboFlight.DisplayMember = "FlightFromTo"
            cboFlight.DataSource = dtf

            ' Select the first item in the list by default
            If cboFlight.Items.Count > 0 Then cboFlight.SelectedIndex = 0

            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub cboFlight_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFlight.SelectedIndexChanged
        Dim strSelect = ""
        Dim strFlight As String = cboFlight.Text
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        lstFlight.Items.Clear()

        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            strSelect = "SELECT TFlights.intFlightID, TFlights.strFlightNumber, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, TFlights.dtmTimeOfLanding " &
                        " From TFlights Join TAirports As TAFrom " &
                        " On TFlights.intFromAirportID = TAFrom.intAirportID " &
                        " Join TAirports As TATo " &
                        " On TFlights.intToAirportID = TATo.intAirportID " &
                        " WHERE TFlights.dtmFlightDate > '04/04/2024' " &
                        " and TAFrom.strAirportCity + ' to ' + TATo.strAirportCity = '" & strFlight & "'"

            'MessageBox.Show(strSelect)

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            lstFlight.Items.Add(" ")
            lstFlight.Items.Add("Flight ID: " & vbTab & vbTab & drSourceTable("intFlightID"))
            lstFlight.Items.Add("Flight Date: " & vbTab & drSourceTable("dtmFlightDate"))
            lstFlight.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
            lstFlight.Items.Add("Departure Time: " & vbTab & drSourceTable("dtmTimeOfDeparture"))
            lstFlight.Items.Add("Arrival Time: " & vbTab & drSourceTable("dtmTimeOfLanding"))

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect As String = ""
        Dim strInsert As String = ""
        Dim intFlightID As Integer
        Dim strFlight As String = cboFlight.Text
        Dim strPilotName As String = cboPilot.Text

        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdInsert As OleDb.OleDbCommand ' insert command object
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim intNextPrimaryKey As Integer ' holds next highest PK value
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

        Dim result As DialogResult
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

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
            result = MessageBox.Show("Are you sure you want to assign Pilot " & strPilotName & " to this flight from " & strFlight & "?", "Confirm Booking", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Cancelled.")
                Case DialogResult.No
                    MessageBox.Show("Action Cancelled.")
                Case DialogResult.Yes

                    strSelect = "SELECT MAX(intPilotFlightID) + 1 AS intNextPrimaryKey" &
                            " FROM TPilotFlights"

                    'MessageBox.Show(strSelect)

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    ' Read result( highest ID )
                    drSourceTable.Read()

                    ' Null? (empty table)
                    If drSourceTable.IsDBNull(0) = True Then

                        ' Yes, start numbering at 1
                        intNextPrimaryKey = 1

                    Else

                        ' No, get the next highest ID
                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                    End If

                    ' Select Statement to get intPilotID
                    strSelect = "SELECT intPilotID, strFirstName, strLastName
                                FROM TPilots
                                WHERE strFirstName + ' ' + strLastName = '" & strPilotName & "'"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader
                    drSourceTable.Read()

                    intPilotID = CInt(drSourceTable("intPilotID"))

                    ' wow this assignment is so long

                    ' Select statement to get intFlightID
                    strSelect = "Select TFlights.intFlightID, TAFrom.strAirportCity + ' to ' + TATo.strAirportCity As FlightFromTo
                            From TFlights Join TAirports As TAFrom
                            On TFlights.intFromAirportID = TAFrom.intAirportID
	                        Join TAirports As TATo
                            On TFlights.intToAirportID = TATo.intAirportID
                            Where TFlights.dtmFlightDate > '04/04/2024'
                            and TAFrom.strAirportCity + ' to ' + TATo.strAirportCity = '" & strFlight & "'"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader
                    drSourceTable.Read()

                    intFlightID = CInt(drSourceTable("intFlightID"))

                    strInsert = "INSERT INTO TPilotFlights (intPilotFlightID, intPilotID, intFlightID) " &
                                    " VALUES (" & intNextPrimaryKey & ", " & intPilotID & ", " & intFlightID & ")"

                    'MessageBox.Show(strInsert)

                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Pilot successfully assigned to flight.")
                    End If

            End Select

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class