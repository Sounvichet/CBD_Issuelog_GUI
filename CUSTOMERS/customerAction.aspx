<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customerAction.aspx.cs" Inherits="CUSTOMERS_customerAction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../dist/css/adminlte.min.css">
    <!-- SweetAlert2 -->
    <link rel="stylesheet" href="../../plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css">
    <!-- Google Font: Source Sans Pro -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
    <%--<link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />--%>
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>
    <style>
        .color-palette {
            height: 35px;
            line-height: 35px;
            text-align: right;
            padding-right: .75rem;
        }

        .user-control {
            padding-top: 5px;
        }

        .color-palette.disabled {
            text-align: center;
            padding-right: 0;
            display: block;
        }

        .color-palette-set {
            margin-bottom: 15px;
        }

        .color-palette span {
            display: none;
            font-size: 12px;
        }

        .color-palette:hover span {
            display: block;
        }

        .color-palette.disabled span {
            display: block;
            text-align: left;
            padding-left: .75rem;
        }

        .color-palette-box h4 {
            position: absolute;
            left: 1.25rem;
            margin-top: .75rem;
            color: rgba(255, 255, 255, 0.8);
            font-size: 12px;
            display: block;
            z-index: 7;
        }

        .textboxstyle {
            font-size: 15px;
            border-radius: 5px 5px 5px 5px;
            border: 1px solid #c4c4c4;
            padding: 2px 2px 2px 2px;
        }

            .textboxstyle:focus {
                border: 1px solid #7bc1f7;
            }

        .gridgetsize {
            max-height: 280px;
            overflow: auto;
            width: 100%;
            margin-bottom: 1rem;
            color: #212529;
            background-color: transparent;
        }

            .gridgetsize th {
                font-size: 14px;
                font-weight: bold;
                white-space: nowrap;
            }

            .gridgetsize th,
            .gridgetsize td {
                padding: 0.30rem;
                vertical-align: top;
                border-top: 1px solid #dee2e6;
            }

            .gridgetsize thead th {
                vertical-align: bottom;
                border-bottom: 2px solid #dee2e6;
            }

            .gridgetsize tbody + tbody {
                border-top: 2px solid #dee2e6;
            }

        .gvItemCenter {
            text-align: center;
        }

        .gvHeaderCenter {
            text-align: center;
        }

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
              .tdname 
        {
            width:150px;
        }
    </style>

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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:blue">' + message + '</span></div>');

            //setTimeout(function () {
            //    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
            //        //$("#alert_div").remove();
            //    });
            //}, 5000);//5000=5 seconds
        };
    </script>
              <script type="text/javascript">
            jQuery(function ($) {{
                    $("#<%=txtrndate.ClientID %>").datepicker({
                    format: 'dd-M-yyyy',
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
            }
            });
    </script>

    <script type="text/javascript">  
            var message = "Function Disabled!";  
            function clickIE4() {  
            if (event.button == 2) {  
            alert(message);  
            return false;  
            }  
            }  
            function clickNS4(e) {  
            if (document.layers || document.getElementById && !document.all) {  
            if (e.which == 2 || e.which == 3) {  
            alert(message);  
            return false;  
            }  
            }  
            }  
            if (document.layers) {  
            document.captureEvents(Event.MOUSEDOWN);  
            document.onmousedown = clickNS4;  
            }  
            else if (document.all && !document.getElementById) {  
            document.onmousedown = clickIE4;  
            }  
            document.oncontextmenu = new Function("return false")  
            </script>  

    
</head>
<body>
    <form id="form1" runat="server">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default color-palette-box">
                    <div class="card-header">
                        <h3 class="card-title">
                            <i class="fas fa-users"></i>
                            Transaction
                        </h3>
                    </div>
        <div class="card-body">
        <div class="row user-control">
            <div class="col-md-12">
                <table style="width:100%;">
                <tr>
                    <td class="tdname">
                        CustomerID
                    </td>
                    <td>
                        <asp:TextBox ID="lblcustomerID" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                    </td>
                    <td class="tdname">
                         វគ្ត
                    </td>
                    <td class="tdname">
                        <asp:TextBox ID="lblcycle" runat="server" CssClass="textboxstyle"></asp:TextBox>
                    </td>
                </tr>
            </table>
            </div>
        </div>

            <div class="row user-control">
                <div class="col-md-12">
                    
                    <table style="width:100%">
               <tr>
                   <td class="tdname">
                           SERVICE ID
                   </td>
                   <td>    
                        <asp:DropDownList ID="d_service_no" runat="server" CssClass="textboxstyle" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="d_service_no_SelectedIndexChanged"></asp:DropDownList>
                   </td>
                   <td class="tdname">
                           លើកទី
                   </td>
                   <td class="tdname">
                        <asp:DropDownList ID="d_cyschedule" runat="server" CssClass="textboxstyle" Width="178px" AutoPostBack="true" OnSelectedIndexChanged="d_cyschedule_SelectedIndexChanged"></asp:DropDownList>
                   </td>
               </tr>
           </table>
               </div> 
            </div>

            <div class="row user-control">
                <div class="col-md-12">
                    <table style="width:100%">
               <tr>
                   <td class="tdname">    
                           សេវាកម្ម 
                   </td>
                   <td>    
                            <asp:DropDownList ID="D_ServicePKG" runat="server" CssClass="textboxstyle"  Width="100%"  Enabled="false"></asp:DropDownList>
                           
                      
                   </td>
                   <td class="tdname"> 
                           ផលិតផល
                   </td>
                   <td>
                       <asp:DropDownList ID="d_product" runat="server" CssClass="textboxstyle"  Width="178px" Enabled="false"></asp:DropDownList>
                   </td>
               </tr>
           </table>
                </div>
            </div>

            <div class="row user-control">
                <div class="col-md-12">
                    <table style="width:100%">
               <tr>
                   <td class="tdname">
                           សាខា 
                   </td>
                   <td>    
                            <asp:DropDownList ID="D_branch" runat="server" CssClass="textboxstyle" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="D_branch_SelectedIndexChanged"></asp:DropDownList>
                   </td>
                   <td class="tdname">
                           បុគ្គលិក
                   </td>
                   <td class="tdname">
                       <asp:DropDownList ID="D_employee" runat="server" CssClass="textboxstyle" Width="178px"></asp:DropDownList>
                   </td>
               </tr>
           </table>
                </div>
            </div>
           
               <div class="row user-control">
                   <div class="col-md-12">
                       <table style="width:100%">
                            <tr>
                                <td class="tdname">
                                    Transaction DATE
                                </td>
                                <td>
                                    <asp:TextBox ID="txtrndate" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                </td>
                            </tr>
                       </table>
                   </div>
               </div>
               
            
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:LinkButton ID="LinkAction" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkAction_Click"><i class="fas fa-save" style="color:white" aria-hidden="true" ></i> Process</asp:LinkButton>                   
                        <asp:LinkButton ID="Linkbtnrefresh" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnrefresh_Click"><i class="fas fa-sync-alt" style="color:white" aria-hidden="true" ></i> Refresh</asp:LinkButton> 
                    </td>
                </tr>
            </table>
            
              <div class="row user-control">
                        <div class="col-md-12">
                        <div  id="alert_container"></div>
                        </div>
                    </div>

                <div class="table-responsive">
                    <asp:GridView ID="gridschedule" runat="server" CssClass="table-bordered table-hover gridgetsize " Font-Size="Smaller" OnRowDataBound="gridschedule_RowDataBound">
                       <HeaderStyle CssClass="gvHeaderCenter" BackColor="#01559E" Font-Bold="true" ForeColor="#f5f5f5" />
                   </asp:GridView>
               </div>
            </div>
        </div>
    </div>
</section>
    </form>
    <script src="../plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../dist/js/adminlte.min.js"></script>
    <!-- SweetAlert2 -->
    <script src="../../plugins/sweetalert2/sweetalert2.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    
</body>
</html>
