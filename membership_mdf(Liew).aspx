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
                    <div class="drv_title">Infomation</div>

                   
                  <div class="drv_group_underline">
                      <b>Person Name</b>
                                <asp:TextBox ID="txtPerson_Name" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float:right" />

                  </div>



                  <div class="drv_group_underline">
                      <b>Identity Card Number</b>
                                <asp:TextBox ID="txtIdentity_Card_Number" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float:right" />

                  </div>

                <div class="drv_group_underline" style="height:100px">
                    <b>Phone Number</b>
                    <asp:TextBox ID="txtPhone_Number" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" Height="100px" TextMode="MultiLine" />

                </div>
                <div class="drv_group_underline" style="height:100px">
                    <b>E-mail</b>
                    <asp:TextBox ID="txtE_Mail" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" Height="100px" TextMode="MultiLine" />

                </div>
                <div class="drv_group_underline">
                    <b>Uniq ID</b>
                    <asp:TextBox ID="txtUniq_ID" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>

                <div class="drv_group_underline">
                    <b>Membership Type</b>
                    <asp:TextBox ID="txtMembership_Type" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>

                <div class="drv_group_underline">
                    <b>Total Points</b>
                    <asp:TextBox ID="txtTotal_Points" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>

                <div class="drv_group_underline">
                    <b>Rebate Percentage</b>
                    <asp:TextBox ID="txtRebate_Percentage" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
                </div>
                      <div class="drv_group_underline">
                    <b>Expiry Date</b>
                    <asp:TextBox ID="txtExpiry_Date" runat="server" CssClass="drv_textbox" autofocus="true" Width="200px" Style="float: right" />
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


