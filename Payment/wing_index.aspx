<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wing_index.aspx.cs" Inherits="Payment_wing_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    

    <style type="text/css">
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
             textarea
        {
            resize: none;
        }
    </style>
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.4.1.min.js")%>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/js/jquery.dynDateTime.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/js/calendar-en.min.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/CSS/calendar-blue.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />

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


       <script type="text/javascript">
           //function setSrcIFrame() {
           //    var dropdownIndex = document.getElementById('D_serviceType').selectedIndex;
           //    var dropdownValue = document.getElementById('D_serviceType')[dropdownIndex].value + '.aspx';
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
               $("#D_serviceType").change(function () {
                   var selectedText = $(this).find("option:selected").text();
                   var selectedValue = $(this).val();
                   
                       var dropdownIndex = document.getElementById('D_serviceType').selectedIndex;
                       var dropdownValue = document.getElementById('D_serviceType')[dropdownIndex].value + '.aspx';
                       if (dropdownValue == '.aspx')
                       {
                           document.getElementById("CSS_iframe").src = 'Wing_Dashboard.aspx';
                       }
                       else
                       {
                           document.getElementById("CSS_iframe").src = dropdownValue;
                       }

               });
           });
    </script>
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
            <section class="content">
                            <div class="col-xs-12">
                                   <div class="box box-primary">
                                        <div class="box-body box-profile">
                                              <div class="box-header with-border">
                                                        <i class="fa fa-file-text"></i>
                                                         <h3 class="box-title" style="color:blue">Wing Settlement Dashboard</h3>
                                                     </div>

                                       <div class="box-body">

                                           <div class="row">
                                                     <div class="col-md-3">
                                                        <asp:Label ID="L_report" runat="server" Text="Service Type"></asp:Label>
                                                     </div>
                                                     <div class="col-md-3">
                                                        <asp:DropDownList ID="D_serviceType" runat="server" class = "textboxstyle"> <%--Onclick="setSrcIFrame();"--%>
                                                        </asp:DropDownList>
                                                     </div>
                                                 </div>
                                           <p></p>
                                           <div class="row">
                                                <div class="col-md-12">
                                                       <iframe id="CSS_iframe"
                                                                style="border-style: none; width: 100%; height: 1155px;" src="Wing_Dashboard.aspx">
                                                            </iframe>
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
