<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMSWF.aspx.cs" Inherits="Payment_MaintenanceFee" %>

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
            margin: 0 auto;
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
         jQuery(function ($) {
             //Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(setUpScript);
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setUpScript);
             function setUpScript() {

                 $("#<%=txtForm.ClientID %>").datepicker({
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

                 $("#<%=txtto.ClientID %>").datepicker({
                     format: "dd-M-yyyy",
                     orientation: "top right",
                     autoclose: true,
                     todayHighlight: true,
                     toggleActive: true
                 });
                 $('#End_date').mask('99-aaa-9999');

                 $("#<%=Txtgeneratedate.ClientID %>").datepicker({
                     format: "dd-M-yyyy",
                     orientation: "top right",
                     autoclose: true,
                     todayHighlight: true,
                     toggleActive: true
                 });
                 $('#generate').mask('99-aaa-9999');


                 $("#<%=txtupload.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $('#upload').mask('99-aaa-9999');

            $("#<%=txtnextupload.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $('#nextupload').mask('99-aaa-9999');
             }
         });
    </script>
    <script type="text/javascript">
        jQuery(function ($) {
            $("#<%=txtForm.ClientID %>").datepicker({
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


            $("#<%=txtto.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $('#End_date').mask('99-aaa-9999');

            $("#<%=Txtgeneratedate.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $('#generate').mask('99-aaa-9999');


            $("#<%=txtupload.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $('#upload').mask('99-aaa-9999');

            $("#<%=txtnextupload.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $('#nextupload').mask('99-aaa-9999');

        });
    </script>

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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style = "Color:Blue">' + message + '</span></div>');

            //setTimeout(function () {
            //    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
            //        $("#alert_div").remove();
            //    });
            //}, 5000);//5000=5 seconds
        };
    </script>


</head>
<body> <%--style="background-color:#ecf0f5"--%>
    <form id="form1" runat="server">
    
      <section class="content">
               <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header with-border">
                                            <i class="fa fa-money"></i>
                                                <h3 class="box-title" style="color:blue">WorkFlow</h3>
                                            </div>
                                            <div class="box-body">
                                                   <asp:ScriptManager ID="SMSMTF" runat="server"></asp:ScriptManager>
                                                            <asp:UpdatePanel ID="UpdateMTF" UpdateMode="Conditional" runat="server">
			                                                            <ContentTemplate> 
                                                    <div class="row">
                                                            <div class="col-md-12">
                                                                <div  id="alert_container">
                                                         
                                                            </div>
                                                        </div>
                                                      </div>
                                                        
                                                      <div class="row">
                                                          <div class="col-md-12">
                                                              <asp:LinkButton ID="LinkEdit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkEdit_Click"><i class="fa fa-file-excel-o fa-lg" aria-hidden="true" ></i> Edit</asp:LinkButton>
                                                              <asp:LinkButton ID="Linkbtnapply" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnapply_Click" Enabled="false"><i class="fa fa-file-excel-o fa-lg" aria-hidden="true" ></i> Apply</asp:LinkButton>

                                                               <div class="btn-group">
                                                              <button type="button" class="btn btn-sm btn-primary">Action</button>
                                                              <button type="button" class="btn btn-sm btn-primary dropdown-toggle" data-toggle="dropdown">
                                                                <span class="caret"></span>
                                                                <span class="sr-only">Toggle Dropdown</span>
                                                              </button>
                                                              <ul class="dropdown-menu" role="menu" id="iddropdown" style="background-color:#245580">
                                                              <%--  <li><a href="#">Add New</a></li>
                                                                <li><a href="#">Add New By Batch</a></li>
                                                                <li><a href="#">Delete</a></li>
                                                                <li><a href="#">Vew</a></li>--%>
                                                                <li style="height:20px">
                                                                    <span class="align-middle">
                                                                    <a id="exportmultisheet" href="#" class="fa fa-file-excel-o fa-lg" style="color:white; height:auto; margin-left:10px;" onserverclick="generate_click" runat="server" > Generate</a>
                                                                    </span>
                                                                        </li>
                                                              </ul>
                                                            </div>


                                                          </div>
                                                      </div>

                                                     <div class="row user-control">
                                                         <div class="col-md-3">
                                                               USD <a class="fa fa-long-arrow-right"></a> KHR
                                                         </div>
                                                         <div class="col-md-3">
                                                               <asp:TextBox ID="txtUSDKHR" runat="server" CssClass="form-control textboxstyle"></asp:TextBox> 
                                                         </div>
                                                         <div class="col-md-3">
                                                                THB <a class="fa fa-long-arrow-right"></a> KHR
                                                         </div>
                                                         <div class="col-md-3">
                                                                <asp:TextBox ID="txtTHBKHR" runat="server" CssClass="form-control textboxstyle"></asp:TextBox> 
                                                         </div>
                                                     </div>   
                                                                          
                                                    <div class="row user-control">
                                                            <div class="col-md-3">
                                                                USD <a class="fa fa-long-arrow-right"></a> THB
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="txtUSDTHB" runat="server" CssClass="form-control textboxstyle"></asp:TextBox> 
                                                                </div>
                                                            <div class="col-md-3">
                                                                Service Type
                                                                </div>
                                                            <div class="col-md-3">
                                                                <asp:DropDownList ID ="D_servtype" runat="server" CssClass="form-control textboxstyle"  OnSelectedIndexChanged="D_servtype_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem>A</asp:ListItem>
                                                                    <asp:ListItem>M</asp:ListItem>
                                                                </asp:DropDownList>
                                                                </div>
                                                    </div>

                                                    <div class="row user-control">
                                                        <div class="col-md-3">
                                                            From Branch_code:
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:DropDownList ID="d_f_brncode" runat="server" CssClass="form-control textboxstyle" OnSelectedIndexChanged="d_f_brncode_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-3">
                                                            To Branch_code:
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:DropDownList ID="d_t_brncode" runat="server" CssClass="form-control textboxstyle" ></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="row user-control">
                                                        <div class="col-md-3">
                                                            Select Date:
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:DropDownList ID="d_selectdate" runat="server" CssClass="form-control textboxstyle" OnSelectedIndexChanged="D_selectdate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-3">
                                                            From Date:
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="txtForm" runat="server" CssClass="form-control textboxstyle"></asp:TextBox> 
                                                        </div>
                                                    </div>
                                                    
                                                    <div class="row user-control">
                                                            <div class="col-md-3">
                                                                Generate Date:
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="Txtgeneratedate" runat="server" CssClass="form-control textboxstyle"></asp:TextBox> 
                                                                </div>
                                                            <div class="col-md-3">
                                                                To Date:
                                                                </div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="txtto" runat="server" CssClass="form-control textboxstyle"></asp:TextBox> 
                                                                </div>

                                                    </div>
                                                     
                                                      <div class="row user-control">
                                                          <div class="col-md-3">
                                                              Upload:
                                                          </div>
                                                          <div class="col-md-3">
                                                              <asp:TextBox ID="txtupload" runat="server" CssClass="form-control textboxstyle"></asp:TextBox>
                                                            </div>
                                                          <div class="col-md-3">
                                                              Next Upload:
                                                            </div>
                                                          <div class="col-md-3">
                                                              <asp:TextBox ID="txtnextupload" runat="server" CssClass="form-control textboxstyle"></asp:TextBox>
                                                            </div>
                                                      </div>
                                                </ContentTemplate>
                                                                <Triggers >
                                                                    <asp:PostBackTrigger ControlID="Linkbtnapply"/>
                                                                    <asp:PostBackTrigger ControlID="exportmultisheet"/>
                                                                    
                                                                </Triggers>
                                              </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                </div>
    </section>
    
    </form>
</body>
</html>
