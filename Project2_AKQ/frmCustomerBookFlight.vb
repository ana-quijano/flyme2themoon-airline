Public Class frmCustomerBookFlight

    Dim dblBaseCost As Decimal = 250
    Dim dblTotalFlightMiles As Decimal
    Dim intReservedPassengers As Integer
    Dim strPlaneType As String
    Dim strDestination As String
    Dim intPassengerAge As Integer
    Dim intPastFlightCount As Integer
    Dim dblFlightCost As Decimal

    Private Sub frmCustomerBookFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable

        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If

            strSelect = "Select TFlights.intFlightID, TAFrom.strAirportCity + ' to ' + TATo.strAirportCity As FlightFromTo
                            From TFlights Join TAirports As TAFrom
                            On TFlights.intFromAirportID = TAFrom.intAirportID
	                        Join TAirports As TATo
                            On TFlights.intToAirportID = TATo.intAirportID
                            Where TFlights.dtmFlightDate > '04/04/2024'"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            ' We are binding the column name to the combo box display and value members.

            cboFlight.ValueMember = "intFlightID"
            cboFlight.DisplayMember = "FlightFromTo"
            cboFlight.DataSource = dt

            cboSeat.SelectedIndex = 0

            ' Select the first item in the list by default
            If cboFlight.Items.Count > 0 Then cboFlight.SelectedIndex = 0

            drSourceTable.Close()

            ''    Dim dblBaseCost As Decimal = 250
            'Dim dblTotalFlightMiles As Decimal
            'Dim intReservedPassengers As Integer
            'Dim strPlaneType As String
            'Dim strDestination As String
            'Dim blnReservedSeat As Boolean
            'Dim intPassengerAge As Integer
            'Dim intPastFlightCount As Integer

            'Call Calculate_TotalFlightCost()
            'Call Display_FlightCost()

            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub cboFlight_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFlight.SelectedIndexChanged
        Dim strSelect As String
        Dim strAgeSelect As String
        Dim strFlightSelect As String
        Dim strPastFlightCountSelect As String
        Dim strFlight As String = cboFlight.Text
        Dim intBookingFlightID As String

        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdFlightSelect As OleDb.OleDbCommand ' this will be used for our Flight Select statement
        Dim cmdAgeSelect As OleDb.OleDbCommand ' this will be used for Passenger Age Select statement
        Dim cmdPastFlightCountSelect As OleDb.OleDbCommand ' this will be used for Past Flight Count statement

        Dim drSourceTable As OleDb.OleDbDataReader
        Dim drFlightSourceTable As OleDb.OleDbDataReader
        Dim drAgeSourceTable As OleDb.OleDbDataReader
        Dim drPastFlightCountSelectTable As OleDb.OleDbDataReader

        lstFlight.Items.Clear()

        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            strSelect = "SELECT TF.intFlightID, TF.strFlightNumber, TF.dtmFlightDate, TF.dtmTimeofDeparture, TF.dtmTimeOfLanding " &
                        " From TFlights As TF Join TAirports As TAFrom " &
                        " On TF.intFromAirportID = TAFrom.intAirportID " &
                        " Join TAirports As TATo " &
                        " On TF.intToAirportID = TATo.intAirportID " &
                        " WHERE TF.dtmFlightDate > '04/04/2024' " &
                        " and TAFrom.strAirportCity + ' to ' + TATo.strAirportCity = '" & strFlight & "'"

            'MessageBox.Show(strSelect)

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            ' Get flightID for next select statement
            intBookingFlightID = drSourceTable("intFlightID")

            ' Display flight details in listbox
            lstFlight.Items.Add(" ")
            lstFlight.Items.Add("Flight ID: " & vbTab & vbTab & intBookingFlightID)
            lstFlight.Items.Add("Flight Date: " & vbTab & drSourceTable("dtmFlightDate"))
            lstFlight.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
            lstFlight.Items.Add("Departure Time: " & vbTab & drSourceTable("dtmTimeOfDeparture"))
            lstFlight.Items.Add("Arrival Time: " & vbTab & drSourceTable("dtmTimeOfLanding"))

            ' Get flightID

            'Select statement to get Flight information
            strFlightSelect = "SELECT TF.intMilesFlown, TPT.strPlaneType, TATo.strAirportCode As strDestination, COUNT(TFP.intFlightPassengerID) As intPassengerCount" &
                                " FROM TFlights As TF Join TPlanes As TP
	                                On TF.intPlaneID = TP.intPlaneID
	                                Join TPlaneTypes As TPT
	                                On TP.intPlaneTypeID = TPT.intPlaneTypeID
	                                Join TAirports As TAFrom
	                                On TF.intFromAirportID = TAFrom.intAirportID
	                                Join TAirports As TATo
	                                On TF.intToAirportID = TATo.intAirportID
	                                Left Join TFlightPassengers As TFP
	                                ON TF.intFlightID = TFP.intFlightID
                                WHERE TF.intFlightID = '" & intBookingFlightID & "'" &
                                " GROUP BY TF.intMilesFlown, TPT.strPlaneType, TATo.strAirportCode"

            cmdFlightSelect = New OleDb.OleDbCommand(strFlightSelect, m_conAdministrator)
            drFlightSourceTable = cmdFlightSelect.ExecuteReader
            drFlightSourceTable.Read()

            ' Select Statement to get Passenger age and past flight count
            strAgeSelect = "SELECT DATEDIFF(HOUR,TPS.dtmDateofBirth,GETDATE())/8766 As intPassengerAge" &
                                    " FROM TPassengers As TPS" &
                                    " WHERE TPS.intPassengerID = " & intCustomerID &
                                    " GROUP BY TPS.dtmDateofBirth"

            cmdAgeSelect = New OleDb.OleDbCommand(strAgeSelect, m_conAdministrator)
            drAgeSourceTable = cmdAgeSelect.ExecuteReader
            drAgeSourceTable.Read()

            ' Select statement to get past flight count
            strPastFlightCountSelect = "SELECT isnull(COUNT(TFP.intPassengerID),0) As intPastFlightCount" &
                                        " FROM TPassengers As TPS Join TFlightPassengers As TFP" &
                                        " On TPS.intPassengerID = TFP.intPassengerID" &
                                        " Join TFlights As TF" &
                                        " On TFP.intFlightID = TF.intFlightID" &
                                        " WHERE TPS.intPassengerID = " & intCustomerID &
                                        " and dtmFlightDate < GETDATE()"

            cmdPastFlightCountSelect = New OleDb.OleDbCommand(strPastFlightCountSelect, m_conAdministrator)
            drPastFlightCountSelectTable = cmdPastFlightCountSelect.ExecuteReader
            drPastFlightCountSelectTable.Read()

            ' Getting input variables for Total Flight Cost calculations
            dblTotalFlightMiles = drFlightSourceTable("intMilesFlown")
            intReservedPassengers = drFlightSourceTable("intPassengerCount")
            strPlaneType = drFlightSourceTable("strPlaneType")
            strDestination = drFlightSourceTable("strDestination")
            intPassengerAge = drAgeSourceTable("intPassengerAge")
            intPastFlightCount = drPastFlightCountSelectTable("intPastFlightCount")

            CloseDatabaseConnection()

            Call Calculate_TotalFlightCost()
            Call Display_FlightCost()
            'MessageBox.Show(dblTotalFlightMiles & vbCr & intReservedPassengers & vbCr & strPlaneType & vbCr & strDestination & vbCr & intPassengerAge & vbCr & intPastFlightCount)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub radDesignatedSeat_CheckedChanged(sender As Object, e As EventArgs) Handles radAssignedSeat.CheckedChanged

        Call Calculate_TotalFlightCost()
        Call Display_FlightCost()

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim strSelect As String = ""
        Dim strInsert As String = ""
        Dim intFlightID As Integer
        Dim strSeat As String = cboSeat.Text
        Dim strFlight As String = cboFlight.Text

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
            result = MessageBox.Show("Are you sure you want to book this flight from " & strFlight & "?", "Confirm Booking", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Cancelled.")
                Case DialogResult.No
                    MessageBox.Show("Action Cancelled.")
                Case DialogResult.Yes

                    strSelect = "SELECT MAX(intFlightPassengerID) + 1 AS intNextPrimaryKey" &
                            " FROM TFlightPassengers"

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

                    strInsert = "INSERT INTO TFlightPassengers (intFlightPassengerID, intFlightID, intPassengerID, strSeat, monFlightPrice)" &
                                    " VALUES (" & intNextPrimaryKey & ", " & intFlightID & ", " & intCustomerID & ", '" & cboSeat.Text & "', " & dblFlightCost & ")"

                    'MessageBox.Show(strInsert)

                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Flight booking successful.")
                    End If

            End Select

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Calculate_TotalFlightCost()

        Dim dblAgeDiscount As Decimal
        Dim dblLoyaltyDiscount As Decimal

        dblFlightCost = dblBaseCost

        If dblTotalFlightMiles > 750 Then
            dblFlightCost += 50
        End If

        If intReservedPassengers > 8 Then
            dblFlightCost += 100
        Else
            If intReservedPassengers < 4 Then
                dblFlightCost -= 50
            End If
        End If

        If strPlaneType = “Airbus A350” Then
            dblFlightCost += 35
        Else
            If strPlaneType = “Boeing 747-8” Then
                dblFlightCost -= 25
            End If
        End If

        If strDestination = “MIA” Then
            dblFlightCost += 15
        End If

        If radReservedSeat.Checked Then
            dblFlightCost += 125
        End If

        If intPassengerAge >= 65 Then
            dblAgeDiscount = dblFlightCost * 0.2
            dblFlightCost = dblFlightCost - dblAgeDiscount
        Else
            If intPassengerAge <= 5 Then
                dblAgeDiscount = dblFlightCost * 0.65
                dblFlightCost = dblFlightCost - dblAgeDiscount
            End If
        End If

        If intPastFlightCount > 10 Then
            dblLoyaltyDiscount = dblFlightCost * 0.2
            dblFlightCost = dblFlightCost - dblLoyaltyDiscount
        Else
            If intPastFlightCount > 5 Then
                dblLoyaltyDiscount = dblFlightCost * 0.1
                dblFlightCost = dblFlightCost - dblLoyaltyDiscount
            End If
        End If

    End Sub

    Private Sub Display_FlightCost()
        If radReservedSeat.Checked Then
            lblReservedSeatFlighCost.Text = FormatCurrency(dblFlightCost)
            lblAssignSeatFlightCost.ResetText()
        Else
            lblAssignSeatFlightCost.Text = FormatCurrency(dblFlightCost)
            lblReservedSeatFlighCost.ResetText()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

End Class