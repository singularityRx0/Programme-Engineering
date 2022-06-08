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

    Public Function pSearch(ByVal xSearchText As String,
                         ByVal xPageRow As Integer, ByVal xPageindex As Integer) As SqlDataReader



        Dim myCommand As SqlCommand = New SqlCommand("p_t_member_cache_src", mConnection)

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
    Public Function pmembercheckonline(membernumber As String) As Boolean


        Dim myCommand As SqlCommand = New SqlCommand("p_t_membercheckonline", mConnection)

        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parameterReturn_v As SqlParameter = New SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4)
        parameterReturn_v.Direction = ParameterDirection.ReturnValue
        myCommand.Parameters.Add(parameterReturn_v)


        Dim parametermembernumber As SqlParameter = New SqlParameter("@membernumber", SqlDbType.NVarChar, 100)
        parametermembernumber.Value = membernumber
        myCommand.Parameters.Add(parametermembernumber)




        ' Open the connection and execute the Command
        Try
            mConnection.Open()
        Catch
        End Try
        Try
            'myConnection.Open()
            myCommand.ExecuteNonQuery()
            mConnection.Close()

        Catch ex As Exception
            ErrorMsg = ex.Message
            Return False
        End Try
        mConnection.Close()
        Return CInt(parameterReturn_v.Value) = 0

    End Function


    Public Function pUpdate(
 ByVal membernumber As String, ByVal username As String, ByVal crmuser_id As String,
 ByVal total_point_balance As Decimal, ByVal expire_at As DateTime,
 ByVal statusid As Integer, ByVal xUpdateBy As Integer,
 ByVal xAction As String) As Boolean


        Dim myCommand As SqlCommand = New SqlCommand("p_t_member_cache_Updt", mConnection)

        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parameterReturn_v As SqlParameter = New SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4)
        parameterReturn_v.Direction = ParameterDirection.ReturnValue
        myCommand.Parameters.Add(parameterReturn_v)



        Dim parametermembernumber As SqlParameter = New SqlParameter("@membernumber", SqlDbType.VarChar, 100)
        parametermembernumber.Value = membernumber
        myCommand.Parameters.Add(parametermembernumber)

        Dim parameterusername As SqlParameter = New SqlParameter("@username", SqlDbType.NVarChar, 200)
        parameterusername.Value = username
        myCommand.Parameters.Add(parameterusername)

        Dim parametercrmuser_id As SqlParameter = New SqlParameter("@crmuser_id", SqlDbType.VarChar, 100)
        parametercrmuser_id.Value = crmuser_id
        myCommand.Parameters.Add(parametercrmuser_id)

        Dim parametertotal_point_balance As SqlParameter = New SqlParameter("@total_point_balance", SqlDbType.Decimal, 30)
        parametertotal_point_balance.Value = total_point_balance
        myCommand.Parameters.Add(parametertotal_point_balance)

        Dim parameterexpire_at As SqlParameter = New SqlParameter("@expire_at", SqlDbType.DateTime)
        parameterexpire_at.Value = expire_at
        myCommand.Parameters.Add(parameterexpire_at)

        Dim parameterstatusid As SqlParameter = New SqlParameter("@t_statusid", SqlDbType.Int)
        parameterstatusid.Value = statusid
        myCommand.Parameters.Add(parameterstatusid)



        Dim parameterUpdateBy As SqlParameter = New SqlParameter("@UpdateBy", SqlDbType.Int)
        parameterUpdateBy.Value = xUpdateBy
        myCommand.Parameters.Add(parameterUpdateBy)

        Dim parameterAction As SqlParameter = New SqlParameter("@Action", SqlDbType.NVarChar, 10)
        parameterAction.Value = xAction
        myCommand.Parameters.Add(parameterAction)


        ' Open the connection and execute the Command
        Try
            mConnection.Open()
        Catch
        End Try
        Try
            'mConnection.Open()
            myCommand.ExecuteNonQuery()

        Catch ex As Exception
            ErrorMsg = ex.Message
            mConnection.Close()
            Return False
        End Try
        mConnection.Close()
        Return CInt(parameterReturn_v.Value) = 0

    End Function
End Class
