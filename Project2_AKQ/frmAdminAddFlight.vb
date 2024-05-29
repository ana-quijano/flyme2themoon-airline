Public Class frmAdminAddFlight
    Private Sub frmAdminAddFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect = ""
        Dim strName = ""
        Dim strOrigin As String
        Dim strDestination As String
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim objParam As OleDb.OleDbParameter           ' this will be used to add parameters needed for stored procedures
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dtp As DataTable = New DataTable ' this is the table we will load from our reader for Plane Type
        Dim dtaf As DataTable = New DataTable ' this is the table we will load from our reader for Airport
        Dim dtat As DataTable = New DataTable ' this is the table we will load from our reader for Airport


        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            ' Select statement to obtain From Airport
            strSelect = "SELECT intAirportID As FromAirportID, strAirportCity As FromAirportCity
                            FROM TAirports"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtaf.Load(drSourceTable)

            cboOrigin.ValueMember = "FromAirportID"
            cboOrigin.DisplayMember = "FromAirportCity"
            cboOrigin.DataSource = dtaf
            strOrigin = cboOrigin.DisplayMember

            ' Select statement to obtain From Airport
            strSelect = "SELECT intAirportID As ToAirportID, strAirportCity As ToAirportCity
                            FROM TAirports"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtat.Load(drSourceTable)

            cboDestination.ValueMember = "ToAirportID"
            cboDestination.DisplayMember = "ToAirportCity"
            cboDestination.DataSource = dtat
            strDestination = cboDestination.DisplayMember

            strSelect = "SELECT intPlaneID, strPlaneNumber
                            FROM TPlanes"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            cboPlaneNumber.ValueMember = "intPlaneID"
            cboPlaneNumber.DisplayMember = "strPlaneNumber"
            cboPlaneNumber.DataSource = dtp

            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect = ""
        Dim strName = ""
        Dim dtmFlightDate As String
        Dim strFlightNumber As String
        Dim dtmDepartureTime As String
        Dim dtmLandingTime As String
        Dim strOrigin As String
        Dim intFromAirport = cboOrigin.SelectedValue
        Dim strDestination As String
        Dim intToAirport = cboDestination.SelectedValue
        Dim intMiles As Integer
        Dim strPlaneNumber As String
        Dim intPlaneID = cboPlaneNumber.SelectedValue
        Dim blnValidated As Boolean = True

        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer
        Dim strInsert As String
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim cmdInsert As OleDb.OleDbCommand ' this will be used for our Insert statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to

        Call GetValidate_FlightInputs(dtmFlightDate, strFlightNumber, dtmDepartureTime, dtmLandingTime, strOrigin, strDestination, intMiles, strPlaneNumber, blnValidated)

        If blnValidated = True Then
            Try

                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

                ' Select statement to get next highest primary key for Flight
                strSelect = "SELECT MAX(intFlightID) + 1 AS intNextPrimaryKey" &
                            " FROM TFlights"

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
                strInsert = "INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)" &
                            " VALUES (" & intNextPrimaryKey & ",'" & dtmFlightDate & "','" & strFlightNumber & "','" & dtmDepartureTime & "','" & dtmLandingTime & "'," & intFromAirport & ", " & intToAirport & ", " & intMiles & ", " & intPlaneID & ")"
                'MessageBox.Show(strInsert)

                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                intRowsAffected = cmdInsert.ExecuteNonQuery()

                If intRowsAffected = 1 Then
                    MessageBox.Show("New Flight has been added.")
                Else
                    MessageBox.Show("Transaction failed. New Flight not added.")
                End If

                drSourceTable.Close()
                CloseDatabaseConnection()
                Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub GetValidate_FlightInputs(ByRef dtmFlightDate As String, ByRef strFlightNumber As String, ByRef dtmDepartureTime As String, ByRef dtmLandingTime As String,
                                         ByRef strOrigin As String, ByRef strDestination As String, ByRef intMiles As Integer, ByRef strPlaneNumber As String,
                                         ByRef blnValidated As Boolean)
        Call GetValidate_FlightDate(dtmFlightDate, blnValidated)
        If blnValidated = True Then
            Call GetValidate_FlightNumber(strFlightNumber, blnValidated)
            If blnValidated = True Then
                Call GetValidate_DepartureTime(dtmDepartureTime, blnValidated)
                If blnValidated = True Then
                    Call GetValidate_LandingTime(dtmLandingTime, blnValidated)
                    If blnValidated = True Then
                        Call GetValidate_Origin(strOrigin, blnValidated)
                        If blnValidated = True Then
                            Call GetValidate_Destination(strDestination, strOrigin, blnValidated)
                            If blnValidated = True Then
                                Call GetValidate_Miles(intMiles, blnValidated)
                                'If blnValidated = True Then
                                '    Call GetValidate_PlaneNumber(strPlaneNumber, blnValidated)
                                'End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub GetValidate_FlightDate(ByRef dtmFlightDate As String, ByRef blnValidated As Boolean)
        dtmFlightDate = dtmDateofFlight.Value
        If dtmFlightDate <= Today Then
            MessageBox.Show("Flight Date must be future date.")
            dtmDateofFlight.Value = Today
            blnValidated = False
        Else
            dtmFlightDate = dtmFlightDate.Substring(0, 9)
        End If
    End Sub

    Private Sub GetValidate_FlightNumber(ByRef strFlightNumber As String, ByRef blnValidated As Boolean)
        strFlightNumber = txtFlightNumber.Text
        If strFlightNumber = "" Then
            MessageBox.Show("Last Name is required.")
            txtFlightNumber.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub GetValidate_DepartureTime(ByRef dtmDepartureTime As String, ByRef blnValidated As Boolean)
        dtmDepartureTime = dtmTimeofDeparture.Value
        dtmDepartureTime = dtmDepartureTime.Substring(10)
        blnValidated = True
    End Sub

    Private Sub GetValidate_LandingTime(ByRef dtmLandingTime As String, ByRef blnValidated As Boolean)
        dtmLandingTime = dtmTimeofLanding.Value
        dtmLandingTime = dtmLandingTime.Substring(10)
        blnValidated = True
    End Sub

    Private Sub GetValidate_Origin(ByRef strOrigin As String, ByRef blnValidated As Boolean)
        strOrigin = cboOrigin.Text
        If strOrigin = "" Then
            MessageBox.Show("Origin is required.")
            cboOrigin.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub GetValidate_Destination(ByRef strDestination As String, ByVal strOrigin As String, ByRef blnValidated As Boolean)
        strDestination = cboDestination.Text
        If strDestination = strOrigin Then
            MessageBox.Show("Origin and Destination must be different cities.")
            cboDestination.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub GetValidate_Miles(ByRef intMiles As Integer, ByRef blnValidated As Boolean)
        intMiles = numMiles.Text
        If intMiles < 1 Then
            MessageBox.Show("Miles is required and must be greater than 0.")
            numMiles.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        dtmDateofFlight.Value = Today
        txtFlightNumber.ResetText()
        dtmTimeofDeparture.Value = "12:00:00"
        dtmTimeofLanding.Value = "12:00:00"
        numMiles.ResetText()
        Close()
    End Sub
End Class