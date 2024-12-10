<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delete.aspx.cs" Inherits="FC_delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
      <style type="text/css">
          .button_bg {
                background-color:#009da5;
                }
                .category_bg {
                background-color:#f99d1c;
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
         .user-control
         {
         padding-top:5px;
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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span>' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 5000);//5000=5 seconds
        };
    </script>

    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.4.1.min.js")%>" type="text/javascript"></script>

</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
          <section class="content">
          
               <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header">
                                                <h3 class="box-title" style="color:blue">Delete FC Staff</h3>
                                            </div>
                                            <div class="box-body">
                                                <asp:ScriptManager ID="SMticketdelete" runat="server"></asp:ScriptManager>
                                      <asp:UpdatePanel ID="UpdateDeleteticket" UpdateMode="Conditional" runat="server">
			                              	<ContentTemplate>

                                                <div class="row">
                                                    <div class="col-md-12" align="left">
                                                        <asp:LinkButton ID="Linkbtndelete" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Linkbtndelete_Click"><i class="fa fa-times fa-lg" aria-hidden="true" ></i> Delete</asp:LinkButton>
                                                        <asp:LinkButton ID="LinkBtncancel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="LinkBtncancel_Click"><i class="fa fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                                    </div>
                                                </div>

                                                  <div class="row user-control">
                                                            <div class="col-md-12">
                                                                <div  id="alert_container">
                                                            </div>
                                                        </div>
                                                      </div>

                                                 
                                             <div class="row user-control">
                                                        <div class="col-lg-12 textboxstyle category_bg">
                                                            <label id="lblBG">FC Staff Information</label>
                                                        </div>

                                                    </div>

                                            <div class="row user-control">
                                                  <div class="col-md-2">
                                                      <asp:Label ID="Label3" runat="server" Text="Staff ID"></asp:Label>
                                                  </div>
                                                  <div class="col-md-4">
                                                      <asp:Label ID="t_staff_ID" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                                                  </div>
                                                  <div class="col-md-2">
                                                      <asp:Label ID="Label4" runat="server" Text="Staff Name"></asp:Label>
                                                  </div>
                                                  <div class="col-md-4">
                                                      <asp:TextBox ID="T_FC_Name" runat="server" CssClass = "textboxstyle" Width="100%"></asp:TextBox>
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
