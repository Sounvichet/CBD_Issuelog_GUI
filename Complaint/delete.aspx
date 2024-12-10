<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delete.aspx.cs" Inherits="Complaint_delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.4.1.min.js")%>" type="text/javascript"></script>

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


</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
             <section class="content">
                          <div class="row">
                                        <div class="col-xs-12">
                                               <div class="box box-primary">
                                                      <div class="box-body box-profile">
                                                             <h3 class="box-title">Delete Complain</h3>
                                                
                                                         </div>
                                                   <div class="box-body">

                                                <div class="row">
                                                        <div class=" col-lg-12" align="left">
                                                             <asp:LinkButton ID="Linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Btndelete_Click"><i class="fa fa-save fa-lg" aria-hidden="true" ></i> Apply</asp:LinkButton>
                                                             <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Btncancel_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                                        </div>
                        
                                                </div>


                                                       <div class="row">
                                                            <div class="col-md-12">
                                                                <div  id="alert_container">
                                                         
                                                            </div>
                                                        </div>
                                                      </div>
                                                       <p></p>

                                                        

                                                        <div class="row">
                                                            <div class="col-md-2">
                                                                <asp:Label ID="Label3" runat="server" Text="Ticket_no"></asp:Label>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:Label ID="Problem_ID" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <asp:Label ID="Label4" runat="server" Text="Branch_Name"></asp:Label>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:TextBox ID="t_Branch_name" runat="server" CssClass = "textboxstyle" Width="100%"></asp:TextBox>
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
