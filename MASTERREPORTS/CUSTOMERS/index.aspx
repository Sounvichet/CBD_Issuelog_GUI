<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="CUSTOMERS_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/plugins/fontawesome-free/css/all.min.css")%>" rel="stylesheet" type="text/css" />
  <!-- Ionicons -->
    <link href="<%= Page.ResolveUrl ("~/CSS/ionicons.min.css")%>" rel="stylesheet" type="text/css" />
  <!-- Theme style -->
    <link href="<%= Page.ResolveUrl ("~/dist/css/adminlte.min.css")%>" rel="stylesheet" type="text/css" />
  <!-- Google Font: Source Sans Pro -->
    <link href="<%= Page.ResolveUrl ("~/CSS/google-Font.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>

      <style>
    .color-palette {
      height: 35px;
      line-height: 35px;
      text-align: right;
      padding-right: .75rem;
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
    .user-control
         {
         padding-top:5px;
         }
  </style>
    
     <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>
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
                $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:blue">' + message + '</span></div>');

                setTimeout(function () {
                    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                        $("#alert_div").remove();
                    });
                }, 5000);//5000=5 seconds
            };


    </script>

     <script type="text/javascript">
           //function setSrcIFrame() {
           //    var dropdownIndex = document.getElementById('T_report_name').selectedIndex;
           //    var dropdownValue = document.getElementById('T_report_name')[dropdownIndex].value + '.aspx';
           //    if (dropdownValue == '.aspx')
           //    {
           //        document.getElementById("RptIncident_iframe").src = 'IncidentDashboard.aspx';
           //    }
           //    else
           //    {
           //        document.getElementById("RptIncident_iframe").src = dropdownValue;
           //    }
               
           //};

           $(function () {
               $("#D_cust_report").change(function () {
                   var selectedText = $(this).find("option:selected").text();
                   var selectedValue = $(this).val();
                   
                       var dropdownIndex = document.getElementById('D_cust_report').selectedIndex;
                       var dropdownValue = document.getElementById('D_cust_report')[dropdownIndex].value + '.aspx';
                       if (dropdownValue == '.aspx')
                       {
                           document.getElementById("RptCustomer_iframe").src = 'IncidentDashboard.aspx';
                       }
                       else
                       {
                           document.getElementById("RptCustomer_iframe").src = dropdownValue;
                       }

               });
           });
    </script>

            <%--   <script type="text/javascript">
            jQuery(function ($) {{
                    $("#<%=txtDBO.ClientID %>").datepicker({
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


                    $("#<%=txtstartdate.ClientID %>").datepicker({
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
     
    </script>--%>
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
      <div class="container-fluid">
        <!-- COLOR PALETTE -->
        <div class="card card-default color-palette-box">
          <div class="card-header">
            <h3 class="card-title" style="font-size:large">
              <i class="fas fa-users"></i>
              CUSTOMERS REPORTS
            </h3>
          </div>
            <div class="card-body">

                <div class="row">
                    <div class="col-md-3">
                        CUSTOMER REPORTS
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="D_cust_report" runat="server" CssClass="textboxstyle" Width="80%"></asp:DropDownList>
                    </div>
                </div>

                 <div class="row user-control">
                    <div class="col-md-12">
                            <iframe id="RptCustomer_iframe"
                                    style="border-style: none; width: 100%; height: 850px; border:0;">
                                </iframe>
                        </div>
                </div> 


               </div>
            </div>
          </div>
        
    </form>
</body>
</html>
