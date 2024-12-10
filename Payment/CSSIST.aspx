<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CSSIST.aspx.cs" Inherits="Payment_CSSIST" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <style>
        .button_bg {
            background-color: #009da5;
        }
        .form-control{
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
         .textboxstyle
            {
                font-size:15px;
                border-radius:5px 5px 5px 5px;
                border:1px solid #c4c4c4;
                padding:2px 2px 2px 2px;
                vertical-align:middle!important;
                text-align:center!important;
                }
            .textboxstyle:focus
            {
                border:1px solid #7bc1f7;
            }
            .gvItemCenter { text-align: center; }
            .gvHeaderCenter {  text-align: center; }
        .tdalign {
                vertical-align: middle !important;
                text-align: center !important;
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
                                                <h3 class="box-title" style="color:blue">1-Insert Transaction Record</h3>
                                            </div>
                                            <div class="box-body">
                                                   <%--<asp:ScriptManager ID="SMSCSSIST" runat="server"></asp:ScriptManager>
                                                            <asp:UpdatePanel ID="UpdateCSSIST" UpdateMode="Conditional" runat="server">
			                                                            <ContentTemplate> --%>
                                                                            <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <div  id="alert_container">
                                                         
                                                                                    </div>
                                                                                </div>
                                                                              </div>

                                                                            <div class="row user-control">
                                                                                <div class="col-md-12">
                                                                                    <table class="table-responsive">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                                                  <asp:DropDownList ID="ddlIsHeaderExists" runat="server" Visible ="false">
                                                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td>
                                                                                                  <asp:Button ID="btnUpload" runat="server" Text="Apply" OnClick="btnUpload_Click" Enabled="true" CssClass="btn btn-sm btn-primary button_bg" /> 
                                                                                            </td>
                                                                                        </tr>
                                                                                </table>
                                                                                </div>
                                                                            </div>


                                                                            <div class="row user-control">
                                                                                <div class="col-md-12">
                                                                                    <div class ="table-responsive">
                                                                                    <asp:GridView ID="getgrid1"  CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                                                      </asp:GridView>
                                                                                    </div>
                                                                                 
                                                                                </div>

                                                                            </div>
                                                                       <%-- </ContentTemplate>
                                                                </asp:UpdatePanel>--%>
                                             </div>
                                        </div>
                                   </div>
                            </div>
                   </div>
              </section>
    </form>
</body>
</html>
