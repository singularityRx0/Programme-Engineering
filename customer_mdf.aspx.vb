Imports System.Data.SqlClient
Public Class customer_mdf
    Inherits System.Web.UI.Page

    Private gconn1 As SqlConnection = createconn()
    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        gconn1.Close()
        gconn1.Dispose()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        gconn1.Close()

        gconn1.Dispose()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not usercheckpermission(gconn1, 41) Then
            Exit Sub
        End If
        If Page.IsPostBack = False Then

            gconn1.Close()
            Dim frmMode As String = Request.Params("frmMode")
            If Not (frmMode <> "") Then frmMode = ""
            SetFormMode(frmMode)

            Dim xid As String = Request.Params("xid")
            If xid <> "" Then
                hfid.Value = xid
                loaddata()
            End If


            gconn1.Close()






        End If

    End Sub
    Private Sub Reset(ByVal I As Integer)
        hfid.Value = ""

        txtcode.Text = ""
        txtdescription.Text = ""
    End Sub
    Private Sub SetFormMode(ByVal frmMode As String)

        Dim bNew As Boolean
        Dim bEdit As Boolean
        Dim bView As Boolean
        Dim bidle As Boolean

        bNew = frmMode.ToUpper = "NEW"
        bEdit = frmMode.ToUpper = "EDIT"
        bView = frmMode.ToUpper = "VIEW"
        bidle = frmMode.ToUpper = "IDLE"



        If bNew Or bView Then Reset(0)

        btnAdd.Visible = bNew

        btnSave.Visible = bEdit
        btnDelete.Visible = bEdit

    End Sub
    Private Sub loaddata()


        Dim p3 As New customerDB(gconn1)

        If p3.pFind(strton(hfid.Value), "") Then
            txtcode.Text = p3.MyDetail.code
            txtdescription.Text = p3.MyDetail.description

            txtAddress.Text = p3.MyDetail.Address
            txttel.Text = p3.MyDetail.Tel
            txtfax.Text = p3.MyDetail.Fax
            txtcontact.Text = p3.MyDetail.Contact
            txtAcc_GLAccountCode.Text = p3.MyDetail.Acc_GLAccountCode
            txtterms.Text = p3.MyDetail.terms

            txttermsremarks.Text = p3.MyDetail.TermsRemarks
            chkactive.Checked = p3.MyDetail.active
            txtdeliverTo.Text = p3.MyDetail.DeliverTo


            SetFormMode("Edit")
        End If

        p3.Dispose()

        gconn1.Close()
    End Sub


    Private Sub updatedata(ByVal Action As String)
        Dim p As New customerDB(gconn1)
        Dim xID As Integer


        txtcode.Text = Trim(txtcode.Text)

        txtdescription.Text = Trim(txtdescription.Text)

        If hfid.Value <> "" Then xID = CInt(hfid.Value)

        If (Action.ToUpper() = "NEW") Or (Action.ToUpper() = "UPDATE") Or (Action.ToUpper() = "DEL") Then

            If p.pUpdate(xID, txtcode.Text, txtdescription.Text, txtAddress.Text,
            txttel.Text, txtfax.Text, txtcontact.Text,
             txtAcc_GLAccountCode.Text, strton(txtterms.Text), txttermsremarks.Text, chkactive.Checked, txtdeliverTo.Text, Action.ToUpper()) Then
                If Action.ToUpper() = "DEL" Then
                    toastUC.pText = "Deleted Record. (" & Now & ")"
                    SetFormMode("VIEW")
                Else
                    hfid.Value = xID.ToString
                    toastUC.pText = "Updated Record. (" & Now & ")"

                    loaddata()
                End If

            Else
                errorUC.pText = p.ErrorMsg
            End If

        End If
        p.Dispose()

        gconn1.Close()



    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        updatedata("NEW")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        updatedata("UPDATE")

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        updatedata("DEL")

    End Sub

End Class
