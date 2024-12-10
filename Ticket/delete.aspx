<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delete.aspx.cs" Inherits="Ticket_delete" %>

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
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
          <section class="content">
          
               <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header">
                                                <h3 class="box-title" style="color:blue">Delete Ticket</h3>
                                            </div>
                                            <div class="box-body">
                                                <asp:ScriptManager ID="SMticketdelete" runat="server"></asp:ScriptManager>
                                      <asp:UpdatePanel ID="UpdateDeleteticket" UpdateMode="Conditional" runat="server">
			                              	<ContentTemplate>

                                                <div class="row">
                                                    <div class="col-md-12" align="left">
                                                        <asp:LinkButton ID="Linkbtndelete" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClientClick="if (!confirm('Do you want to delete the ticket?')) return false;"   OnClick="Btndelete_Click"><i class="fa fa-times fa-lg" aria-hidden="true" ></i> Delete</asp:LinkButton>
                                                        <asp:LinkButton ID="LinkBtncancel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Btncancel_Click"><i class="fa fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                                    </div>
                                                </div>

                                                 <p></p>
                                             <div class="row user-control">
                                                        <div class="col-lg-12 textboxstyle category_bg">
                                                            <label id="lblBG">Ticket Information</label>
                                                        </div>

                                                    </div>
                                                

                                            <div class="row user-control">
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
                                                      <asp:TextBox ID="Branch_name" runat="server" CssClass = "textboxstyle" Width="100%"></asp:TextBox>
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
