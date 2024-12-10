<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TBSWDSL.aspx.cs" Inherits="Payment_TBSWDSL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <%--<script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>--%>
    <style>
        .button_bg {
            background-color: #009da5;
        }
         .textboxstyle
            {
                font-size:15px;
                border-radius:5px 5px 5px 5px;
                border:1px solid #c4c4c4;
                padding:2px 2px 2px 2px;
                }
            .textboxstyle:focus
            {
                border:1px solid #7bc1f7;
            }
            .gvItemCenter { text-align: center; }
                    .gvHeaderCenter {  text-align: center; }
                    .GridPager {
                       background-color: #fff;
                       padding: 2px;
                       margin: 2% auto;
                         }

                   .GridPager a {
                       margin: auto 1%;
                       border-radius: 50%;
                       background-color: #545454;
                       padding: 5px 10px 5px 10px;
                       color: #fff;
                       text-decoration: none;
                       -o-box-shadow: 1px 1px 1px #111;
                       -moz-box-shadow: 1px 1px 1px #111;
                       -webkit-box-shadow: 1px 1px 1px #111;
                       box-shadow: 1px 1px 1px #111;
                   }

                   .GridPager a:hover {
                       background-color: #337ab7;
                       color: #fff;
                   }

               .GridPager span {
                   background-color: #066091;
                   color: #fff;
                   -o-box-shadow: 1px 1px 1px #111;
                   -moz-box-shadow: 1px 1px 1px #111;
                   -webkit-box-shadow: 1px 1px 1px #111;
                   box-shadow: 1px 1px 1px #111;
                   border-radius: 50%;
                   padding: 5px 10px 5px 10px;
               }
        .row {
            margin-bottom: 0px;
        }
    </style>
    <script type="text/javascript">
         function RadioCheck(rb) {
             var gv = document.getElementById("<%=grid1.ClientID%>");
             var rbs = gv.getElementsByTagName("input");
             var row = rb.parentNode.parentNode;
             for (var i = 0; i < rbs.length; i++) {
                 if (rbs[i].type == "checkbox") {
                     if (rbs[i].checked && rbs[i] != rb) {
                         rbs[i].checked = false;
                         break;
                     }
                 }
             }
         };
</script>

    <script type="text/javascript">
        function OpenPage() {
            this.parent.document.getElementById("frm2").src = "wing_consert_form.aspx";
        }
    </script>
    <script type="text/javascript">  
        $(document).ready(function () {  
            //$("#btnShowModal").click(function () {  
            //    $("#loginModal").modal('show');  
            //});  
  
            $("#btnHideModal").click(function () {  
                $("#loginModal").modal('hide');  
            });

            $('#btn_print_proxy').click(function  ()  {
                document.getElementById("frm2").contentWindow.print();
                }); 
        });  
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <section class="content">
              <div class="row">
                     <div class="col-xs-12">
                             <div class="box box-primary">
                                            <div class="box-body box-profile">
                                     <div class="box-header with-border">
                                         <i class="fa fa-ticket"></i>
                                                 <h3 class="box-title" style="color:blue">Wing Disputed Resolution</h3>
                                             </div>
                                       <div class="box-body">
                                           <%--<asp:ScriptManager ID="SMTBSWDSL" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatetTBSWDSL" UpdateMode="Conditional" runat="server">
			                                <ContentTemplate> --%>
                                           <div class="row">
                                               <div class="col-md-6">
                                                   <asp:LinkButton ID="linkbtnnew" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="linkbtnnew_Click" ><i class="fa fa-plus fa-lg" style="color:green" aria-hidden="true"></i> Add</asp:LinkButton>
                                                   <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Linkbtnedit_Click"><i class="fa fa-pencil fa-lg" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                                                   <asp:LinkButton ID="Linkconsent" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Linkconsent_Click" Visible="false"><i class="fa  fa-times fa-lg" style="color:red" aria-hidden="true" ></i> Consent Form</asp:LinkButton>
                                                   <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="LinkBtndel_Click" ><i class="fa  fa-times fa-lg" style="color:red" aria-hidden="true" ></i> Delete</asp:LinkButton>
                                                   <asp:LinkButton ID="LinkBtnview" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="LinkBtnview_Click" Visible="false"><i class="fa fa-eye fa-lg" style="color:orange" aria-hidden="true" ></i> View</asp:LinkButton>
                                               </div>
                                               <p></p>
                                               <div class="col-md-6" align="right">
                                                    <asp:Label ID="Label1" runat="server" Text="TRN_REF"></asp:Label>
                                                    <asp:TextBox ID="txttrn_ref" runat ="server" CssClass="textboxstyle"></asp:TextBox>

                                                   <asp:LinkButton ID="LinkbtnExport" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="LinkbtnExport_Click"><i class="fa fa-reply-all fa-lg" aria-hidden="true" ></i> Apply</asp:LinkButton>  <%--btn_apply_Click--%>
                                               </div>

                                           </div>

                                           <div class="row">
                                               <div class="col-lg-12">
                                                  <div class ="table-responsive">
                                                        <asp:GridView ID="grid1"  DataKeyNames="original_ref" CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" onpageindexchanging="grid1_PageIndexChanging" PageSize="11" AllowPaging="true">
                                                  <%-- <AlternatingRowStyle BackColor="White" />--%>
                                                            <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" /> 
                                                   <Columns>

                                                        <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server"/>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                        <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);"  />
                                                         <%--<input type ="checkbox" runat="server" onclick ="RadioCheck(this);" checked="checked"/>--%>
                                                        <%--<asp:LinkButton ID="lnkEdit"   runat="server" CommandName="lnkedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-left:30px;margin-right:30px"><i class= "fa fa-pencil"></i></asp:LinkButton>
                                                        <asp:LinkButton ID = "InkDelete" runat="server" CommandName="InkDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-right:30px"><i class= "fa fa-trash-o"> </i></asp:LinkButton>
                                                        <asp:LinkButton ID = "lnkView" runat="server" CommandName="lnkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-right:30px"><i class= "fa fa-eye"> </i></asp:LinkButton>--%>
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                   <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                                    </asp:GridView>
                                                   </div>
                                                   </div>
                                               </div>

                                           <div class="row">
                                                   <div class="col-lg-12">
                                                    <asp:Label ID="Label3" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                                                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="true"></asp:Label>
                                                   </div>
                                               </div>

                                                <div class="row">
                                                     <div class="col-md-12" >
                                                         <div class="modal fade"  style="display: none;" id="iframe-open">
                                                                <div class="modal-dialog" style="width: 90%;">
                                                                    <div class="modal-content">
                                                                        <div class="modal-header">
                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                <span aria-hidden="true">&times;</span></button>
                                                                            <h4 class="modal-title">Wing Consent Form</h4>
                                                                        </div>
                                                                        <div class="modal-body">
                                                                            <button id="btn_print_proxy" style="margin-bottom: 10px;" class="btn btn-default">
                                                                                <i class="fa fa-print"></i> Print</button>
                                                                            <button type="button" class="btn btn-default" style="margin-bottom: 10px;" data-dismiss="modal">
                                                                                <i class="fa fa-times"></i>Close</button>
                                                                            <iframe id="frm2" runat="server"  allowfullscreen="true" scrolling="yes" frameborder="0" style ="width:100%;height:1155px;"  ></iframe>
                                                                        </div>
                                                                      
                                                                        <div class="modal-footer">
                                                                          
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                          <%--End TopUp Dialog --%>
                                                         </div>
                                                     </div>

                                              <%--  </ContentTemplate>
                                                             <Triggers>
                                                                                <asp:PostBackTrigger ControlID="LinkbtnExport" />
                                                             </Triggers>
                                                </asp:UpdatePanel>--%>
                                            </div>
                                       </div>
                              </div>
                     </div>
             </div>
    </section>
    </form>
</body>
</html>
