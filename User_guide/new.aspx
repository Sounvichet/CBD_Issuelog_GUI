<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new.aspx.cs" Inherits="User_guide_new" %>

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
    <style type="text/css">
          .getmsgfont 
          {
            color:blue;
          }
        .user-control
         {
         padding-top:5px;
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
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
    <section class="content">
              <div class="row">
                            <div class="col-xs-12">
                                  <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header">
                                                 <h3 class="box-title" style = "color:blue;">Form UserGuide</h3>
                                             </div>
                                        <div class="box-body">
                                    <asp:ScriptManager ID="SMSinsertForm" runat="server"></asp:ScriptManager>
                                        <asp:UpdatePanel ID="updateinsertForm" UpdateMode="Conditional" runat="server">
                                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:LinkButton ID="linkbtnsave" runat="server" class="btn btn-sm btn-primary" onclick="btn_save_Click"  ><i class="fa fa-save fa-lg" aria-hidden="true"></i> Save</asp:LinkButton>
                                                    <asp:LinkButton ID="linkbtncacel" runat="server" class="btn btn-sm btn-primary" onclick="btn_cancel_Click"  ><i class="fa fa-backward fa-lg" aria-hidden="true"></i> Cancel</asp:LinkButton>
                                                        
                                                 </div>
                                             </div>
                                            
                                            <div class="row">
                                                    <div class="col-md-12">
                                                        <div  id="alert_container">
                                                         
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row user-control">
                                                <div class="col-md-3">
                                                    <asp:Label ID="Label1" runat="server" Text="Form_Name"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:TextBox ID="txtform_Name" runat="server" CssClass="textboxstyle form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3">
                                                    Post_date
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:TextBox ID="t_post_date" runat="server" CssClass="textboxstyle form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                             
                                            
                                            <div class ="row user-control">
                                                <div class="col-md-3">
                                                    <asp:Label ID="Label3" runat="server" Text="Post_by"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:TextBox ID="t_userid" runat="server" CssClass="textboxstyle form-control" Enabled="false"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="Label4" runat="server" Text="Indicator"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:DropDownList ID="D_Indicator" runat="server" CssClass="textboxstyle form-control" AutoPostBack="true" OnSelectedIndexChanged="D_Indicator_SelectedIndexChanged">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Form</asp:ListItem>
                                                    <asp:ListItem>Document</asp:ListItem>
                                                    <asp:ListItem>Userguide</asp:ListItem>
                                                    <asp:ListItem>RequestChange</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="row user-control">
                                                <div class="col-md-3">
                                                    <asp:Label ID="Label2" runat="server" Text="Service"></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:DropDownList ID ="D_service" runat="server" CssClass="textboxstyle form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                            
                                            <div class ="row user-control">
                                                <div class="col-md-3">
                                                  <p>Attachment<span style=" color:Red;">*</span></p>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:FileUpload ID="file_attach1" runat="server" ToolTip="Select Only Excel File"></asp:FileUpload>
                                                </div>
                                            </div>
                                         
                                    </ContentTemplate>
                                            <Triggers>
                                                 <asp:PostBackTrigger ControlID="linkbtnsave" />
                                            </Triggers>
                                </asp:UpdatePanel>
                                            

                                         </div>
                                     </div>
                                </div>
                           </div>
                     </div>
        </section>

         <script type="text/javascript">
             function callBack(fileName) {
                 document.getElementById('Attach1').innerHTML = fileName;
             }


             function setUpScript() {
                 $("#<%=t_post_date.ClientID %>").datepicker({
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
                 $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span class="getmsgfont"><b>' + message + '</b></span></div>');

                 setTimeout(function () {
                     $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                         $("#alert_div").remove();
                     });
                 }, 5000);//5000=5 seconds
             };
             // for Form Load
             jQuery(function ($) {
                 setUpScript()
                 //Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(setUpScript);
             });
             // For update panel
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setUpScript);
             window.top.callBack(fileName);
    </script> 
    </form>
</body>
</html>
