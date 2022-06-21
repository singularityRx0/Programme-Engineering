<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/default_mtr.master" CodeBehind="membership_src.aspx.vb" Inherits="PROJ1.membership_src" %>

<%@ Register Src="~/errorUC.ascx" TagPrefix="uc1" TagName="errorUC" %>
<%@ Register Src="~/toastUC.ascx" TagPrefix="uc1" TagName="toastUC" %>

<%@ Register Src="~/paging.ascx" TagPrefix="uc2" TagName="paging" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHoldertop" runat="server">
Membership

     
</asp:Content>

<asp:Content ID="ctcpmain" ContentPlaceHolderID="cphMain" runat="Server">



        <style>
          @media screen and (min-width: 601px) {
            .local_div2 {
                width:1000px;
                max-width:800px;

            }
        }
         .local_div {
                width:500px;

            }
        @media screen and (max-width: 600px) {
            .local_div {
                width:100%;

            }
        }

    </style>

    <uc1:errorUC runat="server" ID="errorUC" />
    <uc1:toastUC runat="server" ID="toastUC" />


            <div class="drv_row">

      
                <div class="drv_rw20201206-column local_div2" style="height: 500px;">
                               <div class="drv_title">Membership List      <button class="drv_buttonrowtable" style="float:right" onclick="openright(0)" type="button">Register</button></div>
                     <asp:TextBox ID="txtsearchtext" runat="server" placeholder="Phone No." CssClass="drv_textbox" autofocus="true" Width="200px" />
         <asp:Button ID="btnsearch" runat="server" CssClass="drv_button20201202" Text="Search"></asp:Button><br /><br />
                                     <div class="drv_datatable">
                                         <asp:GridView ID="dgmember" AutoGenerateColumns="false" GridLines="None" runat="server" Width="100%" EnableViewState="False"
                                             ShowHeaderWhenEmpty="True" EmptyDataText="No records Found">

                                             <Columns>
                                                 <asp:TemplateField HeaderText="No." ItemStyle-Width="25px">
                                                     <ItemTemplate>

                                                         <%#DataBinder.Eval(Container.DataItem, "seq")%>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Code">
                                                     <ItemTemplate>


                                                         <%#DataBinder.Eval(Container.DataItem, "Person_Name")%>
                                                         <div>
                                                             <%#DataBinder.Eval(Container.DataItem, "Identity_Card_Number")%>
                                                         </div>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>



                                                 <asp:TemplateField HeaderText="Action" ItemStyle-Width="50px">
                                                     <ItemTemplate>



                                                         <button class="drv_buttonrowtable" onclick="openright(<%#DataBinder.Eval(Container.DataItem, "id")%>)" type="button">Edit</button>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                             </Columns>

                                         </asp:GridView>
									</div>



		                         <div style="width: 100%; display: block; text-align: center">


            <div style="display: inline-block">

           <uc2:paging runat="server" ID="paging1" />
            </div>
</div>

     


                </div>



            </div>
    
    <%--------right box----------%>
              <div class="drv_newrightboxmodelout local_div" id="rightbox">
                    

   <div class="drv_newrightboxclosebtnout"><a onclick="closeright();"><i class="material-icons" style="font-size: 20px; color: #2e2d2d;">close</i></a> </div>  
                  
                   <iframe id="ifcontent" style="border-style: none; width: 100%; height: calc(100vh - 50px)"></iframe>
            </div>

         <script>



             function openright(Membershipid) {
                 var d = new Date();
                 var t = d.getTime();

                 //$("#rightbox").width("400px");
                 //        $("#rightbox").css("right", "0px");

                 $("#rightbox").animate({
                     width: "toggle"
                 });

                 if (Customerid > 0) {
                     document.getElementById('ifcontent').src = "membership_mdf.aspx?xID=" + Membershipid + "&time=" + t;

                 } else {
                     document.getElementById('ifcontent').src = "membership_mdf.aspx?frmMode=NEW&time=" + t;

                 }



             }

             function closeright() {
                 $("#rightbox").animate({
                     width: "toggle"
                 });

                 document.getElementById('ifcontent').src = "";


             }

         </script>
    <%-------------end right box --------------------------%>


        <script>

            selectedleftmenu(28);
            opensub2(4);
        </script>
</asp:Content>
