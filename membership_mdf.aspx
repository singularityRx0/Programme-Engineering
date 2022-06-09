<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="membership_mdf.aspx.vb" Inherits="PROJ1.membership_mdf" %>

<%@ Register Src="~/errorUC.ascx" TagPrefix="uc1" TagName="errorUC" %>
<%@ Register Src="~/toastUC.ascx" TagPrefix="uc1" TagName="toastUC" %>

<%@ Register Src="~/paging.ascx" TagPrefix="uc2" TagName="paging" %>
<%@ Register Src="~/switchCtl.ascx" TagPrefix="uc2" TagName="switchCtl" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 transitional//EN">
<html>
<head id="wwwhead" runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
  

</head>

<body class="drv_rightbody">
      <link href='css/drv.css?a=<%=Format(Now, "yyyy-M-d-HH") %>' rel="stylesheet" />


    <form id="Form1" method="post" runat="server">

    <style>
        @media screen and (min-width: 601px) {
            .local_div {
                width:45%;

            }
        }
    </style>

    <uc1:errorUC runat="server" ID="errorUC" />
    <uc1:toastUC runat="server" ID="toastUC" />
    <asp:HiddenField ID="hfid" runat="server" />

        <div class="drv_rightboxtitle">Membership</div>

            <div class="drv_row">


            <div class="drv_rw20201206-column local_div" style="height: auto;">
                    <div class="drv_title">Detail</div>

                   
                  <div class="drv_group_underline">
                      <b>Code</b>
                                <asp:TextBox ID="txtcode" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float:right" />

                  </div>



                  <div class="drv_group_underline">
                      <b>Description</b>
                                <asp:TextBox ID="txtdescription" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float:right" />

                  </div>

                <div class="drv_group_underline" style="height:100px">
                    <b>Address</b>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" Height="100px" TextMode="MultiLine" />

                </div>
                <div class="drv_group_underline" style="height:100px">
                    <b>Deliver To</b>
                    <asp:TextBox ID="txtdeliverTo" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" Height="100px" TextMode="MultiLine" />

                </div>
                <div class="drv_group_underline">
                    <b>Tel</b>
                    <asp:TextBox ID="txttel" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>

                <div class="drv_group_underline">
                    <b>Fax</b>
                    <asp:TextBox ID="txtfax" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>

                <div class="drv_group_underline">
                    <b>Contact Person</b>
                    <asp:TextBox ID="txtcontact" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>

                <div class="drv_group_underline">
                    <b>Terms</b>
                    <asp:TextBox ID="txtterms" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>
                      <div class="drv_group_underline">
                    <b>Terms Remarks</b>
                    <asp:TextBox ID="txttermsremarks" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>
                <div class="drv_group_underline">
                    <b>GL Account</b>
                    <asp:TextBox ID="txtAcc_GLAccountCode" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>

                <div class="drv_group_underline">
                    <b>Active</b>
                    <asp:CheckBox  Style="float: right" ID="chkactive" runat="server" />
                   
                </div>


       <br /> <br /> <br />
      <div style="text-align:center">
                              <asp:Button ID="btnAdd" runat="server" CssClass="drv_button20201202" Text="Create"></asp:Button>
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" CssClass="drv_button20201202" Text="Save" CausesValidation="False"></asp:Button>
                    &nbsp;
                   
                    <asp:Button ID="btnDelete" runat="server" CssClass="drv_button20201202" Text="Delete" CausesValidation="False"></asp:Button>


          </div>
                </div>

            </div>



    </form>
</body>
</html>



