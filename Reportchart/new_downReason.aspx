<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_downReason.aspx.cs" Inherits="Reportchart_new_downReason" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    

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
            .gettd 
            {
                width:25% !important
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
             $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:blue">' + message + '</span></div>');

            //setTimeout(function () {
            //    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
            //        $("#alert_div").remove();
            //    });
            //}, 5000);//5000=5 seconds
        };  
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
                <section class="content">
                        <div class="row">
                            <div class="col-md-12">
                                    <div class="box box-primary">
                                            <div class="box-body box-profile">
                                            <div class="box-header">
                                                    <h3 class="box-title" style="color:blue">Register Node down reason</h3>
                                                </div>
                                                <div class="box-body">
                                                         <div class="row">
                                                           <div class="col-lg-12" align="left">
                                                               <asp:LinkButton ID="linkbtnsave" runat="server" class="btn btn-sm btn-primary button_bg" onclick="link_save_Click"  ><i class="fa fa-save fa-lg" aria-hidden="true"></i> Save</asp:LinkButton>
                                                               <asp:LinkButton ID="linkbtncacel" runat="server" class="btn btn-sm btn-primary button_bg" onclick="link_cancel_Click" ><i class="fa fa-backward fa-lg" aria-hidden="true"></i> Cancel</asp:LinkButton>
                                                               <%-- <asp:Button ID="btn_save" runat="server" Text="Save" 
                                                                    class="btn btn-sm btn-primary" onclick="btn_save_Click" />--%>
                                                              <%--  <asp:Button ID="btn_cancel" runat="server" Text="Cancel" 
                                                                    class="btn btn-sm btn-primary" onclick="btn_cancel_Click" />  --%>
                                                           </div>
                                                        </div>

                                                     <div class="row user-control">
                                                            <div class="col-md-12">
                                                                <div  id="alert_container">
                                                            </div>
                                                        </div>
                                                      </div>

                                                       <div class="row user-control">
                                                           <div class="col-md-12">
                                                               <table style="width:100% !important" border="0">
                                                                   <tr>
                                                                       <td class="gettd">
                                                                           <label>Group ID</label>
                                                                       </td>
                                                                       <td class="gettd">
                                                                            <asp:Label runat="server" ID="l_groupid" style="color:Blue;"></asp:Label>
                                                                       </td >
                                                                       <td class="gettd">
                                                                           <label>ReasonShortDesc</label>
                                                                       </td>
                                                                       <td class="gettd">
                                                                           <asp:TextBox runat="server" ID="t_reasonshortdesc" CssClass ="textboxstyle" Width="100%"></asp:TextBox>
                                                                       </td>
                                                                   </tr>
                                                               </table>
                                                              
                                                           </div>
                                                            
                                                      </div>

                                                    <div class="row user-control">
                                                           <div class="col-md-12">
                                                               <table style="width:100% !important" border="0">
                                                                   <tr>
                                                                       <td class="gettd">
                                                                           <label>ReasonFullDesc</label>
                                                                       </td>
                                                                       <td class="gettd">
                                                                            <asp:TextBox runat="server" ID="t_ReasonFullDesc" CssClass ="textboxstyle" Width="100%"></asp:TextBox>
                                                                       </td >
                                                                       <td class="gettd">
                                                                           <label>User Input</label>
                                                                       </td>
                                                                       <td class="gettd">
                                                                           <asp:Label runat="server" ID="l_userID"></asp:Label>
                                                                       </td>
                                                                   </tr>
                                                               </table>
                                                              
                                                           </div>
                                                            
                                                      </div>



                                                </div>
                                            </div>
                                      </div>
                                </div>
                         </div>
            </section>

        </div>
    </form>
</body>
</html>
