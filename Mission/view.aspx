<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="Mission_view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.4.1.min.js")%>" type="text/javascript"></script>
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
                                                                 <h3 class="box-title">View Mission</h3>
                                                             </div>
                                                                    <div class="box-body">
                                                        <asp:ScriptManager ID="SMmissdelete" runat="server"></asp:ScriptManager>
                                                                <asp:UpdatePanel ID="UpdateticketNew1" UpdateMode="Conditional" runat="server">
									                                                                        <ContentTemplate>
                                                             <div class = "row">
                                                                <div class = "col-lg-12" align = "left">
                                                                     <asp:LinkButton ID="LinkBtncancel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="btncancel_Click1"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                                                      
                                                                </div>
                                                            </div>

                                                            <p></p>

                                                            <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label9" runat="server" Text="Ticket_no"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="ID_AUTO" runat="server" ForeColor="Red" ></asp:Label>
                                                                </div>
                                                                 <div class = "col-md-3">
                                                                     <asp:Label ID="l_start_date" runat="server" Text="Start_date"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="Start_date" runat="server" class = "textboxstyle"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        <div class = "row">
                                                            <div class = "col-md-3">
                                                                <asp:Label ID="Label16" runat="server" Text="Branch_name"></asp:Label>
                                                            </div>
                                                            <div class = "col-md-3">
                                                                <asp:TextBox ID="t_branch_name" runat="server" class = "textboxstyle"></asp:TextBox>
                                                            </div>
                                                             <div class = "col-md-3">
                                                                 <asp:Label ID="Label17" runat="server" Text="End_date"></asp:Label>
                                                            </div>
                                                            <div class = "col-md-3">
                                                                <asp:TextBox ID="End_date" runat="server" class = "textboxstyle"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label18" runat="server" Text="Source_issue"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_source_issue" runat="server" class = "textboxstyle"></asp:TextBox>
                                                                </div>
                                                                 <div class = "col-md-3">
                                                                     <asp:Label ID="Label19" runat="server" Text="Decription"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Decription" runat="server" class = "textboxstyle"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label20" runat="server" Text="Problem_type"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_problem_type" runat="server" class = "textboxstyle"></asp:TextBox>
                                                                </div>
                                                                 <div class = "col-md-3">
                                                                     <asp:Label ID="Label21" runat="server" Text="Solution"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Solution" runat="server" class = "textboxstyle"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label22" runat="server" Text="Status"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_status" runat="server" class = "textboxstyle"></asp:TextBox>
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
