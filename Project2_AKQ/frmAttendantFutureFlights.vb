Public Class frmAttendantFutureFlights
    Private Sub frmAttendantFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim strSelect As String = ""
            Dim strSelectMilesFlown As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim dts As DataTable = New DataTable           ' this is the table we will load from our reader, take result set and hold that data

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

            ' Select statement for Flight Information
            strSelect = "SELECT TA.intAttendantID, TF.intFlightID, TF.strFlightNumber, TF.dtmFlightDate, TF.dtmTimeofDeparture, TF.dtmTimeOfLanding, TAFrom.strAirportCity As OriginCity, TATo.strAirportCity As DestinationCity, TF.intMilesFlown, TPL.strPlaneNumber " &
                        " FROM TAttendantFlights As TAF JOIN TFlights As TF " &
                        " On TAF.intFlightID = TF.intFlightID " &
                        " JOIN TAttendants AS TA " &
                        " On TA.intAttendantID = TAF.intAttendantID " &
                        " JOIN TAirports As TAFrom " &
                        " On TF.intFromAirportID = TAFrom.intAirportID " &
                        " JOIN TAirports As TATo " &
                        " On TF.intToAirportID = TATo.intAirportID " &
                        " JOIN TPlanes As TPL " &
                        " On TF.intPlaneID = TPL.intPlaneID " &
                        " Where TA.intAttendantID = " & intAttendantID &
                        " and TF.dtmFlightDate > '04/10/2024'"

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Loop through result set and display in Listbox

            lstFutureFlights.Items.Add("Future Flights:")
            lstFutureFlights.Items.Add("=============================")

            While drSourceTable.Read()

                lstFutureFlights.Items.Add("  ")

                lstFutureFlights.Items.Add("FlightID: " & vbTab & drSourceTable("intFlightID"))
                lstFutureFlights.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
                lstFutureFlights.Items.Add("Flight Date: " & vbTab & drSourceTable("dtmFlightDate"))
                lstFutureFlights.Items.Add("Departure Time: " & vbTab & drSourceTable("dtmTimeofDeparture"))
                lstFutureFlights.Items.Add("Arrival Time: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                lstFutureFlights.Items.Add("Origin: " & vbTab & vbTab & drSourceTable("OriginCity"))
                lstFutureFlights.Items.Add("Destination: " & vbTab & drSourceTable("DestinationCity"))
                lstFutureFlights.Items.Add("Miles Flown: " & vbTab & drSourceTable("intMilesFlown"))
                lstFutureFlights.Items.Add("Plane Number: " & vbTab & drSourceTable("strPlaneNumber"))

                lstFutureFlights.Items.Add("  ")
                lstFutureFlights.Items.Add("=============================")

            End While

            ' Select Statement for Total Miles Flown
            strSelect = "Select SUM(intMilesFlown) As 'TotalMiles'
                        From TAttendantFlights As TAF Join TFlights As TF
                        On TAF.intFlightID = TF.intFlightID
	                    Join TAttendants As TA
                        On TA.intAttendantID = TAF.intAttendantID
                        Where TA.intAttendantID = " & intAttendantID &
                        " and TF.dtmFlightDate > '04/10/2024'"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            lblTotalMilesFlown.Text = (drSourceTable("TotalMiles") & " miles")

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        lstFutureFlights.Items.Clear()
        Close()
    End Sub
End Class