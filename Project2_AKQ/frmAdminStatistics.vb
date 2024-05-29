Public Class frmAdminStatistics
    Private Sub frmAdminStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim strSelect As String = ""
            Dim strSelectSum As String = ""
            Dim intCustomerCount As Integer
            Dim strPilotName As String
            Dim strMilesFlown As String

            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim cmdSelectSum As OleDb.OleDbCommand
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

            '------------------------------------------------------
            ' Select statement for total customer count
            strSelect = "Select COUNT(intPassengerID) As CustomerCount
                        From TPassengers"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()


            '' ---------------------------------------------------
            '' Using Stored Procedure uspPassengerCount
            '' to get Customer Count
            '' ---------------------------------------------------

            'cmdSelect = New OleDb.OleDbCommand("uspPassengerCount", m_conAdministrator)
            'cmdSelect.CommandType = CommandType.StoredProcedure

            'drSourceTable = cmdSelect.ExecuteReader
            'drSourceTable.Read()

            intCustomerCount = drSourceTable("CustomerCount")
            lblTotalNumberofCustomers.Text = intCustomerCount

            '------------------------------------------------------
            ' Select statement for total flights taken by all customers
            strSelect = "Select COUNT(intFlightPassengerID) As FlightCount
                        From TFlightPassengers"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            '' ---------------------------------------------------
            '' Using Stored Procedure uspFlightCount
            '' to get Total Flights For All Customer
            '' ---------------------------------------------------

            'cmdSelect = New OleDb.OleDbCommand("uspFlightCount", m_conAdministrator)
            'cmdSelect.CommandType = CommandType.StoredProcedure

            'drSourceTable = cmdSelect.ExecuteReader
            'drSourceTable.Read()

            lblTotalFlightsTakenByAllCustomers.Text = drSourceTable("FlightCount")


            '------------------------------------------------------
            ' Select statement for total miles flown for all customers (to be divided by customer count)

            strSelectSum = "Select SUM(TF.intMilesFlown) As MilesFlown
                            From TFlights As TF Join TFlightPassengers As TFP
                         On TF.intFlightID = TFP.intFlightID
                         Join TPassengers As TP
                         On TFP.intPassengerID = TP.intPassengerID"

            cmdSelectSum = New OleDb.OleDbCommand(strSelectSum, m_conAdministrator)
            drSourceTable = cmdSelectSum.ExecuteReader
            drSourceTable.Read()


            '' ---------------------------------------------------
            '' Using Stored Procedure uspTotalMilesAllCustomers
            '' to get Total Miles Flown for All Customers
            '' to be divided by Customer Count
            '' ---------------------------------------------------

            'cmdSelect = New OleDb.OleDbCommand("uspTotalMilesAllCustomers", m_conAdministrator)
            'cmdSelect.CommandType = CommandType.StoredProcedure

            'drSourceTable = cmdSelect.ExecuteReader
            'drSourceTable.Read()

            lblAverageMilesFlownForAllCustomers.Text = Math.Round((drSourceTable("MilesFlown") / intCustomerCount), 2)


            ' -----------------------------------------------------
            ' Select statement for Pilots with Miles
            strSelect = "Select TP.intPilotID, TP.strEmploymentStatus, TP.strFirstName, TP.strLastName, isnull(Sum(TF.intMilesFlown),0) As MilesFlown
                        From TPilots As TP Left Join TPilotFlights As TPF
	                    On TP.intPilotID = TPF.intPilotID
	                    Left Join TFlights As TF
	                    On TPF.intFlightID = TF.intFlightID
                        Where TF.intMilesFlown Is Null
	                    Or TF.dtmFlightDate < GETDATE()
                        Group By TP.intPilotID, TP.strEmploymentStatus, TP.strFirstName, TP.strLastName"

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Loop through result set and display in Listbox

            lstPilots.Items.Add("List of Pilots with Total Miles Flown:")
            lstPilots.Items.Add("=============================")

            While drSourceTable.Read()


                lstPilots.Items.Add("  ")

                lstPilots.Items.Add("Pilot Name: " & vbTab & drSourceTable("strFirstName") & " " & drSourceTable("strLastName"))
                lstPilots.Items.Add("Total Miles: " & vbTab & drSourceTable("MilesFlown") & " miles")

                If drSourceTable("strEmploymentStatus") = "Inactive" Then
                    lstPilots.Items.Add("*** Employment Status Inactive ***")
                End If

                lstPilots.Items.Add("  ")
                lstPilots.Items.Add("=============================")

            End While

            '------------------------------------------------------
            ' Select statement for Attendents with Miles
            strSelect = "Select TA.intAttendantID, TA.strEmploymentStatus, TA.strFirstName, TA.strLastName, isnull(Sum(TF.intMilesFlown),0) As MilesFlown
                        From TAttendants As TA Left Join TPilotFlights As TPF
	                    On TA.intAttendantID = TPF.intPilotID
	                    Left Join TFlights As TF
	                    On TPF.intFlightID = TF.intFlightID
                        Where TF.intMilesFlown Is Null
	                    Or TF.dtmFlightDate < GETDATE()
                        Group By TA.intAttendantID, TA.strEmploymentStatus, TA.strFirstName, TA.strLastName"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            lstAttendants.Items.Add("List of Attendants with Total Miles:")
            lstAttendants.Items.Add("=============================")

            While drSourceTable.Read()

                lstAttendants.Items.Add("  ")

                lstAttendants.Items.Add("Attendant Name: " & vbTab & drSourceTable("strFirstName") & " " & drSourceTable("strLastName"))
                lstAttendants.Items.Add("Total Miles: " & vbTab & drSourceTable("MilesFlown") & " miles")

                If drSourceTable("strEmploymentStatus") = "Inactive" Then
                    lstAttendants.Items.Add("*** Employment Status Inactive ***")
                End If

                lstAttendants.Items.Add("  ")
                lstAttendants.Items.Add("=============================")

            End While

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class