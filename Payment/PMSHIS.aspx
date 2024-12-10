<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMSHIS.aspx.cs" Inherits="Payment_PMSHIS" %>

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
    <style>
        .getmiddle {
        vertical-align:middle;
        }
          .form-control{
            font-size:15px;
            border-radius:5px 5px 5px 5px;
            padding:2px 2px 2px 2px;
            height:auto;
            margin-left: auto;
            margin-right: auto;
            margin-bottom: 0;
        }
         .textboxstyle
          {
                font-size:15px;
                border-radius:5px 5px 5px 5px;
                border:1px solid #c4c4c4;
                padding:2px 2px 2px 2px;
                height:auto;
           }
         .textboxstyle:focus
           {
                border:1px solid #7bc1f7;
           }
         .user-control
         {
         padding-top:5px;
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
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/js/dataTables.bootstrap.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/CSSchart/js/morris.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/CSSchart/js/raphael.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl("~/js/adminlte.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>

    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            // class="alert fade in ' + cssclass + '"
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span>' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 5000);//5000=5 seconds
        };
    </script>

</head>
<body>
    <form id="form1" runat="server">
       <section class="content">
               <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header with-border">
                                            <i class="fa fa-money"></i>
                                                <h3 class="box-title" style="color:blue">History</h3>
                                            </div>
                                            <div class="box-body">
                                                <asp:ScriptManager ID="SMSHIS" runat="server"></asp:ScriptManager>
                                                    <asp:UpdatePanel ID="UpdateHIS" UpdateMode="Conditional" runat="server">
			                                                        <ContentTemplate> 
                                                                         <div class="row">
                                                                                <div class="col-md-12">
                                                                                    <div  id="alert_container">
                                                         
                                                                                </div>
                                                                            </div>
                                                                          </div>

                                                                        <div class="row user-control">
                                                                            <div class="col-md-12 table-responsive">
                                                                                    <table style="border:hidden" class="table table-bordered">
                                                                                        <tr>
                                                                                            <td>
                                                                                                Service
                                                                                                <div>
                                                                                                    <asp:DropDownList ID="D_service" runat="server" CssClass="form-control textboxstyle"></asp:DropDownList>
                                                                                                </div>
                                                                                            </td>
                                                                                            
                                                                                            <td>
                                                                                                Select Date:
                                                                                                <div>
                                                                                                        <asp:DropDownList ID="D_selectdate" runat="server" CssClass="form-control textboxstyle" OnSelectedIndexChanged="D_selectdate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                                                </div>
                                                                                            </td>
                                                                                            
                                                                                            <td>
                                                                                                Start Date:
                                                                                                <div>
                                                                                                    <asp:TextBox ID="T_SDATE" runat ="server" CssClass="form-control textboxstyle"></asp:TextBox>
                                                                                                </div>
                                                                                            </td>
                                                                                            
                                                                                            <td>
                                                                                                End Date:
                                                                                                <div>
                                                                                                    <asp:TextBox ID="T_EDATE" runat ="server" CssClass="form-control textboxstyle"></asp:TextBox>
                                                                                                </div>
                                                                                            </td>
                                                                                            <td style="vertical-align:middle">
                                                                                                <asp:LinkButton ID="Linkbtnapply" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnapply_Click"><i class="fa fa-file-excel-o fa-lg" aria-hidden="true" ></i> Apply</asp:LinkButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                 </div>
                                                                            </div>

                                                                           <div class="row">
                                                                                <div class="col-md-12 textboxstyle" style="background-color:cornflowerblue;height:inherit">
                                                                                    <asp:Label id="Label1" runat="server" Font-Bold="true" CssClass="proxy-title" Text ="Data History"></asp:Label>
                                                                                </div>
                                                                            </div>

                                                                        <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class ="table-responsive">
                                                                                    <asp:GridView ID="GetGrid1"  CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                                                      </asp:GridView>
                                                                                    </div>
                                                                            </div>
                                                                        </div>

                                                                         <div class="row">
                                                                                <div class="col-md-12 textboxstyle" style="background-color:cornflowerblue;height:inherit">
                                                                                    <asp:Label id="lbldept" runat="server" Font-Bold="true" CssClass="proxy-title" Text ="Data Back Up History"></asp:Label>
                                                                                </div>
                                                                            </div>

                                                                         <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class ="table-responsive">
                                                                                    <asp:GridView ID="GetGrid2"  CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                                                      </asp:GridView>
                                                                                    </div>
                                                                            </div>
                                                                        </div>

                                                                    </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                
                                            </div>
                                        </div>
                                </div>
                        </div>
                </div>
        </section>
    </form>

     <script type="text/javascript">
         function setUpScript() {
             $("#<%=T_SDATE.ClientID %>").datepicker({
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

             $("#<%=T_EDATE.ClientID %>").datepicker({
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
             $('#End_date').mask('99-aaa-9999');

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
                $("#<%=T_SDATE.ClientID %>").datepicker({
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

                $("#<%=T_EDATE.ClientID %>").datepicker({
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
                $('#End_date').mask('99-aaa-9999');
            });
    </script>

</body>
</html>
