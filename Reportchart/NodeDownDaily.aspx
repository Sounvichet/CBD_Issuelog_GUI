<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NodeDownDaily.aspx.cs" Inherits="Reportchart_NodeDownDaily" %>

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
    </style>

    <script type="text/javascript">
         jQuery(function ($) {

            $("#<%=T_Form.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
             $('#Start_date').mask('99-aaa-9999');
            $("#<%=T_to.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
             $('#End_date').mask('99-aaa-9999');
        });
    </script>

    <script type="text/javascript">
        jQuery(function ($) {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(datepickerload);
            function datepickerload() {

                $("#<%=T_Form.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#Start_date').mask('99-aaa-9999');
                $("#<%=T_to.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#End_date').mask('99-aaa-9999');
            }
        });
    </script>

</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
                <section class="content">
                        <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header">
                                                <h3 class="box-title" style="color:blue">Report Node Down Daily</h3>
                                            </div>
                                            <div class="box-body">
                                                <asp:ScriptManager ID="SMNodeDownDaily" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>

                                                 <div class ="row">
                                                     <div class="col-md-12 table-responsive">
                                                         <table   style="border:hidden" class="table table-bordered">

                                                             <tr>
                                                                 <td>
                                                                    View Type
                                                                     <div >
                                                                         <asp:DropDownList ID="D_View_Type" runat="server" CssClass="textboxstyle form-control"></asp:DropDownList>
                                                                     </div>
                                                                     
                                                                 </td>

                                                                 <td>
                                                                   Select Date:
                                                                     <div>
                                                                          <asp:DropDownList ID="D_Date" runat="server" CssClass="textboxstyle form-control" OnSelectedIndexChanged="D_Date_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                     </div>
                                                                 </td>

                                                                 <td>
                                                                     Form
                                                                     <div>
                                                                         <asp:TextBox ID="T_Form" runat="server" CssClass="textboxstyle form-control" Width="100px"></asp:TextBox>
                                                                     </div>
                                                                 </td>

                                                                 <td>
                                                                     To
                                                                     <div>
                                                                         <asp:TextBox ID="T_to" runat="server" CssClass="textboxstyle form-control" Width="100px"></asp:TextBox>
                                                                     </div>
                                                                 </td>

                                                                 <td>
                                                                   Node Type
                                                                     <div>
                                                                         <asp:DropDownList ID="D_NodeType" runat="server" CssClass="textboxstyle form-control"></asp:DropDownList>
                                                                     </div>
                                                                 </td>

                                                             </tr>
                                                         </table>
                                                        </ContentTemplate>
                                                                <Triggers>
                                                                         <asp:PostBackTrigger ControlID="Linkexport" />
                                                                </Triggers>
                                                    </asp:UpdatePanel>

                                                     </div>
                                                 </div>

                                                 <p></p>
                                                 <div class ="row">
                                                     <div class ="col-md-12">
                                                         <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnapply_Click"><i class="fa fa-reply-all fa-lg" aria-hidden="true" ></i> Apply</asp:LinkButton>
                                                          <asp:LinkButton ID="Linkexport" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btngenerate_Click"><i class="fa fa-file-excel-o fa-lg" aria-hidden="true" ></i> Apply</asp:LinkButton>
                                                          <asp:LinkButton ID="LinkBtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btn_cancel_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>

                                                         <div class="btn-group">
                                                              <button type="button" class="btn btn-sm btn-primary">Action</button>
                                                              <button type="button" class="btn btn-sm btn-primary dropdown-toggle" data-toggle="dropdown">
                                                                <span class="caret"></span>
                                                                <span class="sr-only">Toggle Dropdown</span>
                                                              </button>
                                                              <ul class="dropdown-menu" role="menu" id="iddropdown">
                                                              <%--  <li><a href="#">Add New</a></li>
                                                                <li><a href="#">Add New By Batch</a></li>
                                                                <li><a href="#">Delete</a></li>
                                                                <li><a href="#">Vew</a></li>--%>
                                                                <li><a id="exportmultisheet" href="#" class="fa fa-file-excel-o fa-lg" style="color:green" onserverclick="generate_click" runat="server" > Generate</a></li>
                                                              </ul>
                                                            </div>

                                                      </div>
                                                 </div>

                                                 <p></p>
                                                 <div class="row">
                                                     <div class="col-md-12">
                                                          <div class="box box-primary table-responsive">
                                                                <div class="box-header with-border">
                                                                    <h3 class="box-title">GridView List</h3>
                                                                    <div class="box-tools pull-right">
                                                                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                                                                    </button>
                                                                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                                    </div>
                                                                </div>
                                                                <div class="box-body">
                                                                    <asp:GridView ID="GriViewReport" runat="server" CssClass="table table-bordered table-hover" Font-Size="Smaller" Width="100%" RowStyle-Wrap="false"></asp:GridView> 
                                                                </div>
                                                           </div>
                                                     </div>
                                                 </div>
                                                 <p></p>
                                                 <div class ="row">
                                                     <div class ="col-md-12">
                                                         <asp:Label ID="Label7" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                                                         <asp:Label ID="Label8" runat="server" Text="Label" Visible="true"></asp:Label>
                                                     </div>
                                                 </div>


                                              </div>
                                    </div>
                             </div>
             </div>
            </section>
    </form>
</body>
</html>
