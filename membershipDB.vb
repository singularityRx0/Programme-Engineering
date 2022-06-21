Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient



Public Class membershipDB
    Inherits System.ComponentModel.Component

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


    End Sub
    Public Sub New(ByRef xConnection As SqlConnection)
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        mConnection = xConnection
        'Add any initialization after the InitializeComponent() call

    End Sub
    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region
    Public ErrorMsg As String
    Public mConnection As SqlConnection

    Public Class recordDetail
        Public ID As Integer
        Public Person_Name As String
        Public Identity_Card_Number As String
        Public Phone_Number As String
        Public E_Mail As String
        Public Uniq_ID As String
        Public Set_Password As String
        Public Membership_Type As String
        Public Total_Points As Integer
        Public Rebate_Percentage As Decimal
        Public Expiry_Date As DateTime


    End Class
    Public MyDetail As New recordDetail



    Public Function pFind(ByVal xId As Integer, ByVal Person_Name As String) As Boolean

        Dim found As Boolean = False

        Dim myCommand As SqlCommand = New SqlCommand("p_o_Membership_Fd", mConnection)

        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parameterId As SqlParameter = New SqlParameter("@Id", SqlDbType.Int)
        parameterId.Value = xId
        myCommand.Parameters.Add(parameterId)

        Dim parameterPerson_Name As SqlParameter = New SqlParameter("@Person_Name", SqlDbType.NVarChar, 50)
        parameterPerson_Name.Value = Person_Name
        myCommand.Parameters.Add(parameterPerson_Name)

        ' Execute the command
        Try
            mConnection.Open()
        Catch
        End Try
        Dim result As SqlDataReader = myCommand.ExecuteReader()



        MyDetail.ID = 0
        MyDetail.Person_Name = ""



        If result.Read() Then
            With MyDetail
                ' On Error Resume Next
                .ID = result("ID")
                .Person_Name = result("Person_Name")
                .Identity_Card_Number = result("Identity_Card_Number")
                .Phone_Number = result("Phone_Number")
                .E_Mail = result("E_mail")
                .Uniq_ID = result("Uniq_ID")
                .Set_Password = result("Set_Password")
                .Membership_Type = result("Membership_Type")
                .Total_Points = result("Total_Points")
                .Rebate_Percentage = result("Rebate_Percentages")
                .Expiry_Date = result("Expiry_Date")

            End With

            found = True
        End If
        ' Return the datareader result
        result.Close()
        mConnection.Close()
        Return found


    End Function

    Public Function pSearch(ByVal xSearchText As String,
                            ByVal xPageRow As Integer, ByVal xPageindex As Integer) As SqlDataReader



        Dim myCommand As SqlCommand = New SqlCommand("p_o_Membership_src", mConnection)

        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure



        Dim parameterSearchText As SqlParameter = New SqlParameter("@SearchText", SqlDbType.NVarChar, 100)
        parameterSearchText.Value = xSearchText
        myCommand.Parameters.Add(parameterSearchText)


        Dim parameterPageRow As SqlParameter = New SqlParameter("@PageRow", SqlDbType.Int)
        parameterPageRow.Value = xPageRow
        myCommand.Parameters.Add(parameterPageRow)

        Dim parameterPageindex As SqlParameter = New SqlParameter("@Pageindex", SqlDbType.Int)
        parameterPageindex.Value = xPageindex
        myCommand.Parameters.Add(parameterPageindex)

        ' Execute the command
        'myConnection.Open()
        Try
            mConnection.Open()
        Catch
        End Try
        Dim result As SqlDataReader = myCommand.ExecuteReader()

        ' Return the datareader result
        Return result


    End Function

    Public Function pUpdate(ByRef xID As Integer, ByVal xPerson_Name As String, ByVal xIdentity_Card_Number As String,
                            xPhone_Number As String,
                            xE_Mail As String,
                            xUniq_ID As String,
                            xSet_Password As String,
                            xMembership_Type As String,
                            xTotal_Points As Integer,
                            xRebate_Percentage As Decimal,
                            xExpiry_Date As DateTime,
                            ByVal xAction As String
                            ) As Boolean


        Dim myCommand As SqlCommand = New SqlCommand("p_o_Membership_Updt", mConnection)


        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parameterReturn_v As SqlParameter = New SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4)
        parameterReturn_v.Direction = ParameterDirection.ReturnValue
        myCommand.Parameters.Add(parameterReturn_v)


        Dim parameterID As SqlParameter = New SqlParameter("@ID", SqlDbType.Int, 4)
        parameterID.Value = xID
        parameterID.Direction = ParameterDirection.InputOutput
        myCommand.Parameters.Add(parameterID)

        Dim parameterPerson_Name As SqlParameter = New SqlParameter("@Person_Name", SqlDbType.NVarChar, 50)
        parameterPerson_Name.Value = xPerson_Name
        myCommand.Parameters.Add(parameterPerson_Name)


        Dim parameterIdentity_Card_Number As SqlParameter = New SqlParameter("@Identity_Card_Number", SqlDbType.NVarChar, 50)
        parameterIdentity_Card_Number.Value = xIdentity_Card_Number
        myCommand.Parameters.Add(parameterIdentity_Card_Number)


        Dim parameterPhone_Number As SqlParameter = New SqlParameter("@Phone_Number", SqlDbType.NVarChar, 50)
        parameterPhone_Number.Value = xPhone_Number
        myCommand.Parameters.Add(parameterPhone_Number)

        Dim parameterE_Mail As SqlParameter = New SqlParameter("@E_Mail", SqlDbType.NVarChar, 50)
        parameterE_Mail.Value = xE_Mail
        myCommand.Parameters.Add(parameterE_Mail)

        Dim parameterUniq_ID As SqlParameter = New SqlParameter("@Uniq_ID", SqlDbType.NVarChar, 50)
        parameterUniq_ID.Value = xUniq_ID
        myCommand.Parameters.Add(parameterUniq_ID)

        Dim Set_Password As SqlParameter = New SqlParameter("@Uniq_ID", SqlDbType.NVarChar, 50)
        parameterUniq_ID.Value = xSet_Password
        myCommand.Parameters.Add(Set_Password)

        Dim parameterMembership_Type As SqlParameter = New SqlParameter("@Membership_Type", SqlDbType.NVarChar, 50)
        parameterMembership_Type.Value = xMembership_Type
        myCommand.Parameters.Add(parameterMembership_Type)

        Dim parameterTotal_Points As SqlParameter = New SqlParameter("@xTotal_Points", SqlDbType.Int)
        parameterTotal_Points.Value = xTotal_Points
        myCommand.Parameters.Add(parameterTotal_Points)

        Dim parameterRebate_Percentage As SqlParameter = New SqlParameter("@Rebate_Percentage", SqlDbType.Decimal)
        parameterRebate_Percentage.Value = xRebate_Percentage
        myCommand.Parameters.Add(parameterRebate_Percentage)

        Dim parameterxpiry_Date As SqlParameter = New SqlParameter("@Expriry_Date", SqlDbType.DateTime)
        parameterxpiry_Date.Value = xExpiry_Date
        myCommand.Parameters.Add(parameterxpiry_Date)


        Dim usr As New userDB(mConnection)
        usr.GetCurrentUser()
        usr.Dispose()
        mConnection.Close()


        Dim parameterAction As SqlParameter = New SqlParameter("@Action", SqlDbType.NVarChar, 10)
        parameterAction.Value = xAction
        myCommand.Parameters.Add(parameterAction)



        ' Open the connection and execute the Command
        Try
            mConnection.Open()
        Catch
        End Try


        Try
            myCommand.ExecuteNonQuery()

            xID = CInt(parameterID.Value)
        Catch ex As Exception
            ErrorMsg = ex.Message
            mConnection.Close()
            Return False
        End Try
        mConnection.Close()
        Return CInt(parameterReturn_v.Value) = 0

    End Function
End Class


