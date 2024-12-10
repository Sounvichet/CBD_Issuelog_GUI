<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FASTindex.aspx.cs" Inherits="Payment_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-theme.min.css") %>" rel="stylesheet" />


    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/js/dataTables.bootstrap.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/CSSchart/js/morris.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/CSSchart/js/raphael.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl("~/js/adminlte.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <style>
          .form-control{
            font-size:15px;
            border-radius:5px 5px 5px 5px;
            padding:2px 2px 2px 2px;
            height:auto;
            margin: 0 auto;
        }
         .textboxstyle
            {
                font-size:15px;
                border-radius:5px 5px 5px 5px;
                border:1px solid #c4c4c4;
                padding:2px 2px 2px 2px;
                vertical-align:middle!important;
                text-align:center!important;
                }
            .textboxstyle:focus
            {
                border:1px solid #7bc1f7;
            }
            .gvItemCenter { text-align: center; }
            .gvHeaderCenter {  text-align: center; }
        .tdalign {
                vertical-align: middle !important;
                text-align: center !important;
                }
        .user-control
         {
         padding-top:5px;
         }
    </style>


     <script type="text/javascript">
         function OpenPage() {
             document.getElementById("frm2").contentWindow.print();
             $("#iframe-open").modal('hide');
         }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnHideModal").click(function () {
                $("#loginModal").modal('hide');
            });

            //$('#btn_print_proxy').click(function () {
            //    document.getElementById("frm2").contentWindow.print();
            //});
     </script>

</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
                <section class="content">
              <div class="row">
                     <div class="col-xs-12">
                             <div class="box box-primary">
                                            <div class="box-body box-profile">
                                     <div class="box-header with-border">
                                         <i class="fa fa-money"></i>
                                                 <h3 class="box-title" style="color:blue">Fast Settlement</h3>
                                             </div>
                                       <div class="box-body" style ="height:500px">
                                           <asp:ScriptManager ID="SMpaymentindex" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="Updatepaymentindex" UpdateMode="Conditional" runat="server">
			                                <ContentTemplate> 
                                           <div class="row">
                                               <div class="col-md-6">
                                                   <asp:LinkButton ID="Linkprint" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnprint_Click"><i class="fa fa-print fa-lg" style="color:black" aria-hidden="true" ></i> Print</asp:LinkButton>
                                               </div>
                                                <div class="col-md-6" align="right">
                                                    GENERATE_DATE :
                                                    <asp:TextBox ID="txtgenerate" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                                    <asp:LinkButton ID="Linkbtnapply" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnapply_Click"><i class="fa fa-file-excel-o fa-lg" aria-hidden="true" ></i> Apply</asp:LinkButton>
                                                </div>
                                           </div>
                             
                                           <div class="row user-control">
                                               <div class="col-lg-12">
                                                  <div class ="table-responsive">
                                                        <asp:GridView ID="grid1" DataKeyNames="FASTID" CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" OnRowCommand="grid1_RowCommand" AllowPaging="true" OnRowDataBound="GridView1_RowDataBound">
                                                  <%-- <AlternatingRowStyle BackColor="White" />--%>
                                                   <Columns>

                                                        <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server"/>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                        <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);"  />
                                                        </ItemTemplate>
                                                            <ItemStyle CssClass="gvItemCenter" />
                                                            <HeaderStyle CssClass="gvHeaderCenter" />
                                                        </asp:TemplateField>

                                                       <asp:TemplateField>
                                                           <HeaderTemplate>
                                                               Print
                                                              <%-- <th>FastID</th>
                                                               <th>SettleDate</th>
                                                               <th>Branch name</th>
                                                               <th>Trn Type</th>
                                                               <th>Acc Cash</th>
                                                               <th>Category</th>--%>

                                                           </HeaderTemplate>
                                                           <ItemTemplate>
                                                               <asp:LinkButton ID = "lnkprint" runat="server" CommandName="lnkprint" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class= "fa fa-print"> </i></asp:LinkButton>
                                                           <%--    <td><%# DataBinder.Eval(Container.DataItem, "FASTID")%></td>
                                                               <td><%# DataBinder.Eval(Container.DataItem, "SETTLE_DATE")%></td>
                                                               <td><%# DataBinder.Eval(Container.DataItem, "BRANCH_NAME")%></td>
                                                               <td><%# DataBinder.Eval(Container.DataItem, "TRN_TYPE")%></td>
                                                               <td><%# DataBinder.Eval(Container.DataItem, "ACC_CASH")%></td>
                                                               <td class="tdalign"><span class="label label-success" style="font-size:12px;"><%# DataBinder.Eval(Container.DataItem, "CATEGORY")%></span></td>--%>
                                                           </ItemTemplate>
                                                           <ItemStyle CssClass="gvItemCenter" />
                                                            <HeaderStyle CssClass="gvHeaderCenter" />
                                                       </asp:TemplateField>
                                                    </Columns>
                                                   <%--<PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />--%>
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

                                                         <%--<button type="button" id="open_iframe" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg" onclick="javascript:OpenPage();">Large modal</button>--%>

                                                        <%--    <div class="modal fade bd-example-modal-lg" id="iframe-open" 
                                                                 tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" >
                                                              <div class="modal-dialog modal-lg">
                                                                <div class="modal-content w-100">
                                                                  
                                                                        <div class="modal-header">
                                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                            <label id ="lbltitle" runat="server" class="modal-title"></label>
                                                                        </div>

                                                                    <div class="modal-body  ">
                                                                         <iframe id="frm2" runat="server" style="width:100%; height:900px" > 
                                                                          </iframe>
                                                                    </div>

                                                                   <div class="modal-footer">
                                                                      <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                    </div>

                                                                </div>
                                                              </div>
                                                            </div>--%>

                                                       

                                                          <div class="modal fade"  style="display: none;" id="iframe-open">
                                                                <div class="modal-dialog" style="width: 90%;">
                                                                    <div class="modal-content">
                                                                        <div class="modal-header">
                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                <span aria-hidden="true">&times;</span></button>
                                                                            <h4 class="modal-title">FAST Settlement</h4>
                                                                        </div>
                                                                        <div class="modal-body">
                                                                            <button id="btn_print_proxy" style="margin-bottom: 10px;" class="btn btn-default" onclick="OpenPage()"><i   <%--onclick="OpenPage()"--%>
                                                                                    class="fa fa-print"></i> Print</button>
                                                                            <button id="btnHideModal" type="button" class="btn btn-default" style="margin-bottom: 10px;" data-dismiss="modal">
                                                                                <i class="fa fa-times fa-lg"></i>
                                                                                Close</button>
                                                                            <iframe id="frm2" runat="server"  allowfullscreen="true" scrolling="yes" frameborder="0" style ="width:100%;height:1155px;"  ></iframe>
                                                                        </div>
                                                                      
                                                                        <div class="modal-footer">
                                                                          
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>



                                                     </div>
                                                 </div>



                                                </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID ="Linkbtnapply"/>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                       </div>
                              </div>
                     </div>
             </div>
    </section>
    </form>
    

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

            function setUpScript() {
                $("#<%=txtgenerate.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    changeMonth: true,
                    changeYear: true,
                    showWeek: true,
                    gotoCurrent: true,
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#Start_date').mask('99-aaa-9999');
                // 
            }

            jQuery(function ($) {
                setUpScript()
            });
            // For update panel
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setUpScript);
    </script>
    <script type="text/javascript">
            jQuery(function ($) {
                $("#<%=txtgenerate.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    changeMonth: true,
                    changeYear: true,
                    showWeek: true,
                    gotoCurrent: true,
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#Start_date').mask('99-aaa-9999');

            });
    </script>

     
</body>
</html>
