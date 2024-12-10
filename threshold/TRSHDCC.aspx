<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TRSHDCC.aspx.cs" Inherits="threshold_TRSHDCC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />

    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>" type="text/javascript"></script>
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-theme.min.css") %>" rel="stylesheet" />
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>
    <%--<script src="<%= Page.ResolveUrl ("~/js/dataTables.bootstrap.min.js") %>" type="text/javascript"></script>--%>
    <script src="<%= Page.ResolveUrl ("~/CSSchart/js/morris.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/CSSchart/js/raphael.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl("~/js/adminlte.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>

    <style>
         .textboxstyle
          {
            font-size:15px;
            border-radius:5px 5px 5px 5px;
            border:1px solid #c4c4c4;
            padding:2px 2px 2px 2px;
           }
         .form-control
         {
            font-size:15px;
            border-radius:5px 5px 5px 5px;
            padding:2px 2px 2px 2px;
            height:auto;
            margin: 0 auto;
         }
        .user-control
         {
            padding-top:5px;
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
                $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:Black">'+ message +'</span></div>');

                console.log (message);
                setTimeout(function () {
                    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                        $("#alert_div").remove();
                    });
                }, 5000);//5000=5 seconds
            }
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
                                                <h3 class="box-title" style="color:blue">Cassettes Threshold Dashboard</h3>
                                            </div>
                                            <div class="box-body">
                                    <asp:ScriptManager ID="SMSCassette" runat="server"></asp:ScriptManager>
                                         <asp:UpdatePanel ID="UpdateCassette" UpdateMode="Conditional" runat="server">
                                             <ContentTemplate>
                                                  
                                                      <div class="row">
                                                            <div class="col-md-12">
                                                                <div  id="alert_container">
                                                         
                                                            </div>
                                                        </div>
                                                      </div>

                                                      <div class="row">
                                                          <div class="col-md-12 ">
                                                               <div class ="table-responsive">
                                                              <asp:GridView ID="GriViewcassette" runat="server" CssClass="table table-bordered table-hover" Font-Size="Smaller" Width="100%" RowStyle-Wrap="false" OnRowDataBound="GridView1_RowDataBound"></asp:GridView> 
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
</body>
</html>
