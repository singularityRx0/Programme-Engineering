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
        Public code As String
        Public description As String

        Public Address As String
        Public Tel As String
        Public Fax As String
        Public Contact As String
        Public Balance As Decimal
        Public terms As Integer
        Public Acc_GLAccountCode As String

        Public active As Boolean
        Public DeliverTo As String
        Public TermsRemarks As String

    End Class
    Public MyDetail As New recordDetail



    Public Function pFind(ByVal xId As Integer, ByVal Code As String) As Boolean

        Dim found As Boolean = False

        Dim myCommand As SqlCommand = New SqlCommand("p_o_customer_Fd", mConnection)

        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parameterId As SqlParameter = New SqlParameter("@Id", SqlDbType.Int)
        parameterId.Value = xId
        myCommand.Parameters.Add(parameterId)

        Dim parameterCode As SqlParameter = New SqlParameter("@Code", SqlDbType.NVarChar, 30)
        parameterCode.Value = Code
        myCommand.Parameters.Add(parameterCode)

        ' Execute the command
        Try
            mConnection.Open()
        Catch
        End Try
        Dim result As SqlDataReader = myCommand.ExecuteReader()



        MyDetail.ID = 0
        MyDetail.code = ""



        If result.Read() Then
            With MyDetail
                ' On Error Resume Next
                .ID = result("ID")
                .code = result("Code")
                .description = result("description")

                .Address = result("Address")
                .Tel = result("Tel")
                .Fax = result("Fax")
                .Contact = result("Contact")
                .Balance = result("Balance")
                .terms = result("terms")
                .Acc_GLAccountCode = result("Acc_GLAccountCode")

                .active = YNToBoolean(result("active"))
                .DeliverTo = result("DeliverTo")
                .TermsRemarks = result("TermsRemarks")

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



        Dim myCommand As SqlCommand = New SqlCommand("p_o_customer_src", mConnection)

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

    Public Function pUpdate(ByRef xID As Integer, ByVal xCode As String, xdescription As String,
                            xAddress As String,
                            xTel As String,
                            xFax As String,
                            xContact As String,
                            xAcc_GLAccountCode As String,
                            xTerms As Integer,
                            xTermsRemarks As String,
                            xActive As Boolean,
                            xDeliverTo As String,
              ByVal xAction As String) As Boolean


        Dim myCommand As SqlCommand = New SqlCommand("p_o_customer_Updt", mConnection)


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

        Dim parameterCode As SqlParameter = New SqlParameter("@Code", SqlDbType.NVarChar, 30)
        parameterCode.Value = xCode
        myCommand.Parameters.Add(parameterCode)


        Dim parameterdescription As SqlParameter = New SqlParameter("@description", SqlDbType.NVarChar, 100)
        parameterdescription.Value = xdescription
        myCommand.Parameters.Add(parameterdescription)


        Dim parameterAddress As SqlParameter = New SqlParameter("@Address", SqlDbType.NVarChar, 250)
        parameterAddress.Value = xAddress
        myCommand.Parameters.Add(parameterAddress)

        Dim parameterTel As SqlParameter = New SqlParameter("@Tel", SqlDbType.NVarChar, 30)
        parameterTel.Value = xTel
        myCommand.Parameters.Add(parameterTel)

        Dim parameterFax As SqlParameter = New SqlParameter("@Fax", SqlDbType.NVarChar, 30)
        parameterFax.Value = xFax
        myCommand.Parameters.Add(parameterFax)

        Dim parameterContact As SqlParameter = New SqlParameter("@Contact", SqlDbType.NVarChar, 30)
        parameterContact.Value = xContact
        myCommand.Parameters.Add(parameterContact)

        Dim parameterAcc_GLAccountCode As SqlParameter = New SqlParameter("@Acc_GLAccountCode", SqlDbType.NVarChar, 30)
        parameterAcc_GLAccountCode.Value = xAcc_GLAccountCode
        myCommand.Parameters.Add(parameterAcc_GLAccountCode)

        Dim parameterTerms As SqlParameter = New SqlParameter("@Terms", SqlDbType.Int)
        parameterTerms.Value = xTerms
        myCommand.Parameters.Add(parameterTerms)

        Dim parameterTermsRemarks As SqlParameter = New SqlParameter("@TermsRemarks", SqlDbType.NVarChar, 30)
        parameterTermsRemarks.Value = xTermsRemarks
        myCommand.Parameters.Add(parameterTermsRemarks)

        Dim parameteractive As SqlParameter = New SqlParameter("@active", SqlDbType.NVarChar, 1)
        parameteractive.Value = BooleanToYN(xActive)
        myCommand.Parameters.Add(parameteractive)

        Dim parameterDeliverTo As SqlParameter = New SqlParameter("@DeliverTo", SqlDbType.NVarChar, 250)
        parameterDeliverTo.Value = xDeliverTo
        myCommand.Parameters.Add(parameterDeliverTo)

        Dim usr As New userDB(mConnection)
        usr.GetCurrentUser()
        Dim parameterUpdateBy As SqlParameter = New SqlParameter("@UpdateBy", SqlDbType.Int)
        parameterUpdateBy.Value = usr.MyDetail.ID
        myCommand.Parameters.Add(parameterUpdateBy)
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


