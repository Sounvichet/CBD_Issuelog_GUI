<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CSSSTM.aspx.cs" Inherits="Payment_CSS" %>

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
        
        .category_bg {
            background-color: #f99d1c;
        }
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
        $(document).ready(function () {  
            //$("#btnShowModal").click(function () {  
            //    $("#loginModal").modal('show');  
            //});  
  
            $("#btnHideModal").click(function () {  
                $("#loginModal").modal('hide');  
            });  
        });  
    </script>
    <script type="text/javascript">

        $('a.example').click(function () {   //bind handlers
            var url = $(this).attr('href');
            showDialog(url);

            return false;
        });

        $("#targetDiv").dialog({  //create dialog, but keep it closed
            autoOpen: false,
            height: 300,
            width: 350,
            modal: true
        });

        function showDialog(url) {  //load content and open dialog
            $("#targetDiv").load(url);
            $("#targetDiv").dialog("open");
        }

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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:blue;">' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 5000);//5000=5 seconds
        };
    </script>

    <script  type="text/javascript">

        function opendialog() {
            //var requestUrl = '@Url.Action("GetSomeData", "Home")';
            var requestUrl = 'apptop.aspx';
            $.get(requestUrl)

                .done(function (responsedata) {
                    console.log("success");
                    $("#partialViewContent").html(responsedata);

                    $('#iframe-apptop').modal('show');

                })
                .fail(function () {
                    alert("error");
                })
                .always(function () {
                    console.log("finished");
                });
        };


         function getdialog () {
             $('#load-model').load('../apptop.aspx #iframe-apptop'); 
             $('#iframe-apptop').modal({ show: true });
           
        };

            //function showDialog(url) {  //load content and open dialog
            //    $("#iframe-apptop").load(url);
            //    $("#iframe-apptop").dialog("open");
            //}
    </script>

     <script type="text/javascript">
         jQuery(function ($) {
            $("#<%=T_start_date.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
             $('#Start_date').mask('99-aaa-9999');
           
        });
    </script>


    <script type="text/javascript">
        jQuery(function ($) {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setUpScript);
            function setUpScript(){
                $("#<%=T_start_date.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#Start_date').mask('99-aaa-9999');
                
            }});
    </script>

</head>
<body>
    <form id="form1" runat="server">
      <%--  <p runat="server" onclick="thavath();" css="p-5 bg-danger pointer-event" >Thavath</p>--%>

        

      <section class="content">
              <div class="row">
                     <div class="col-xs-12">
                             <div class="box box-primary">
                                  <div class="box-body box-profile">
                                        <div class="box-header with-border">
                                         <i class="fa fa-money"></i>
                                             <h3 class="box-title" style="color:blue">CSS Settlement</h3>
                                         </div>
                                            <div class="box-body">
                                            <asp:ScriptManager ID="SMSCSS" runat="server"></asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdateSMSCSS" UpdateMode="Conditional" runat="server">
			                                    <ContentTemplate>

                                                                        
                                                    <div class="row">
                                                            <div class="col-md-12">
                                                                <div  id="alert_container">
                                                         
                                                            </div>
                                                        </div>
                                                      </div>
                                                    
                                                    <div class="row">
                                                            <div class="col-md-12">
                                                                    <table style="width:500px">
                                                                        <tr>
                                                                            
                                                                            <td>
                                                                                <asp:Label ID="L_Start_date" runat="server">Start Date</asp:Label>
                                                                                <div>
                                                                                    <asp:TextBox ID="T_start_date" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                            </div>
                                                    </div>
                                                    <div class="row user-control">
                                                          <div class="col-md-12">
                                                              
                                                              <button ID="Linkexport" runat="server" class="btn btn-sm btn-primary button_bg" onserverclick="Linkexport_Click"><i class="fa fa-file-excel-o fa-lg"></i>Export</button>
                                                          </div>
                                                    </div>

                                                   
                                               
                                             <%--  <div class="row">
                                                     <div class="col-md-12" >
                                                         <div id="load-model"></div>
                                                            <div class="modal fade bd-example-modal-lg" id="iframe-open" 
                                                                 tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" >
                                                              <div class="modal-dialog modal-lg">
                                                                <div class="modal-content w-100">
                                                                  
                                                                        <div class="modal-header">
                                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                              <h4 class="modal-title">Topup Dialog</h4>
                                                                        </div>

                                                                    <div class="modal-body  ">
                                                                        <button id="btn_print_proxy" style="margin-bottom: 10px;" class="btn btn-default" onclick="OpenPage();">
                                                                                <i class="fa fa-print"></i> Print</button>
                                                                            <button type="button" class="btn btn-default" style="margin-bottom: 10px;" data-dismiss="modal">
                                                                                <i class="fa fa-times"></i>Close</button>
                                                                         <iframe id="frm2" runat="server" class="overflow-scroll" style="width:100%; height:1155px" > 
                                                                          </iframe>
                                                                    </div>

                                                                   <div class="modal-footer">
                                                                      <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                    </div>

                                                                  </div>
                                                             </div>
                                                         </div>
                                                     </div>
                                                 </div>--%>


                                                </ContentTemplate>
                                                <Triggers>

                                                    <asp:PostBackTrigger ControlID="Linkexport"/>
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
