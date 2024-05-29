Public Class frmCustomerPastFlights
    Private Sub frmCustomerPastFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim strSelect As String = ""
            Dim strSelectMilesFlown As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim drPastFlightsSourceTable As OleDb.OleDbDataReader
            Dim dts As DataTable = New DataTable           ' this is the table we will load from our reader, take result set and hold that data
            Dim objParam As OleDb.OleDbParameter           ' this will be used to add parameters needed for stored procedures

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show("Database connection error." & vbNewLine &
                                "The application will now close.",
                                Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Close()

            End If

            '' Select statement for Flight Information
            'strSelect = "SELECT TP.intPassengerID, TF.intFlightID, TF.strFlightNumber, TF.dtmFlightDate, TF.dtmTimeofDeparture, TF.dtmTimeOfLanding, TAFrom.strAirportCity As OriginCity, TATo.strAirportCity As DestinationCity, TF.intMilesFlown, TPL.strPlaneNumber " &
            '            " FROM TFlightPassengers As TPF JOIN TFlights As TF " &
            '            " On TPF.intFlightID = TF.intFlightID " &
            '            " JOIN TPassengers AS TP " &
            '            " On TP.intPassengerID = TPF.intPassengerID " &
            '            " JOIN TAirports As TAFrom " &
            '            " On TF.intFromAirportID = TAFrom.intAirportID " &
            '            " JOIN TAirports As TATo " &
            '            " On TF.intToAirportID = TATo.intAirportID " &
            '            " JOIN TPlanes As TPL " &
            '            " On TF.intPlaneID = TPL.intPlaneID " &
            '            " Where TP.intPassengerID = " & intCustomerID &
            '            " and TF.dtmFlightDate < '04/10/2024'"

            ''MessageBox.Show(strSelect)

            '' Retrieve all the records 
            'cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            'drSourceTable = cmdSelect.ExecuteReader

            ' --------------------------------------------
            ' Using Stored Procedure uspPassengerPastFlights
            ' to return past flights of selected customer
            ' --------------------------------------------
            '
            cmdSelect = New OleDb.OleDbCommand("uspCustomerPastFlights", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@passenger_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intCustomerID

            drSourceTable = cmdSelect.ExecuteReader

            ' Loop through result set and display in Listbox

            lstPastFlights.Items.Add("Past Flights:")
            lstPastFlights.Items.Add("=============================")

            While drSourceTable.Read()

                lstPastFlights.Items.Add("  ")

                lstPastFlights.Items.Add("FlightID: " & vbTab & drSourceTable("intFlightID"))
                lstPastFlights.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
                lstPastFlights.Items.Add("Flight Date: " & vbTab & drSourceTable("dtmFlightDate"))
                lstPastFlights.Items.Add("Departure Time: " & vbTab & drSourceTable("dtmTimeofDeparture"))
                lstPastFlights.Items.Add("Arrival Time: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                lstPastFlights.Items.Add("Origin: " & vbTab & vbTab & drSourceTable("OriginCity"))
                lstPastFlights.Items.Add("Destination: " & vbTab & drSourceTable("DestinationCity"))
                lstPastFlights.Items.Add("Miles Flown: " & vbTab & drSourceTable("intMilesFlown"))

                lstPastFlights.Items.Add("  ")
                lstPastFlights.Items.Add("=============================")

            End While

            ' Select Statement for Total Miles Flown
            strSelect = "Select SUM(intMilesFlown) As 'TotalMiles'
                        From TFlightPassengers As TPF Join TFlights As TF
                        On TPF.intFlightID = TF.intFlightID
                     Join TPassengers As TP
                        On TP.intPassengerID = TPF.intPassengerID
                        Where TP.intPassengerID = " & intCustomerID &
                        " and TF.dtmFlightDate < '04/10/2024'"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drPastFlightsSourceTable = cmdSelect.ExecuteReader
            drPastFlightsSourceTable.Read()

            '' --------------------------------------------
            '' Using Stored Procedure uspPassengerPastMiles
            '' to return total past miles of selected customer
            '' --------------------------------------------

            'cmdSelect = New OleDb.OleDbCommand("uspPassengerPastMiles", m_conAdministrator)
            'cmdSelect.CommandType = CommandType.StoredProcedure

            'objParam = cmdSelect.Parameters.Add("@passenger_id", OleDb.OleDbType.Integer)
            'objParam.Direction = ParameterDirection.Input
            'objParam.Value = intCustomerID

            'drSourceTable = cmdSelect.ExecuteReader
            'drSourceTable.Read()

            lblTotalMilesFlown.Text = (drPastFlightsSourceTable("TotalMiles") & " miles")

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        lstPastFlights.Items.Clear()
        Close()
    End Sub
End Class

