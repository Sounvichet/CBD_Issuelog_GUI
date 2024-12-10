<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="Trouble_Setting_view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
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
<body>
    <form id="form1" runat="server">
                <section class="content">
              <div class="row">
                            <div class="col-xs-12">
                                   <div class="box">
                                             <div class="box-header">
                                                 <h3 class="box-title">View Trouble Setting</h3>           
                                             </div>
                                             <div class="box-body">

                                             <div class="row">
                                                      <div class="col-md-3">
                                                            <asp:Label ID="Label1" runat="server" Text="ReportCode"></asp:Label>
                                                      </div>
                                                      <div class="col-md-3"> 
                                                            <asp:Label ID="ReportCode" runat="server" Text="Null"></asp:Label>
                                                      </div>
                                                      <div class="col-md-3">
                                                            <asp:Label ID="Label2" runat="server" Text="Issue Name"></asp:Label>
                                                      </div>
                                                      <div class="col-md-3">
                                                            <asp:TextBox ID="t_issuename" runat="server" CssClass="textboxstyle" Width="100%" Enabled="false"></asp:TextBox>
                                                      </div>
                                                  </div>

                                                 <div class="row">
                                                     <div class="col-md-3">
                                                            <asp:Label ID="Label3" runat="server" Text="Issue desc"></asp:Label>
                                                     </div>
                                                     <div class="col-md-9">
                                                            <asp:TextBox ID="t_issuedesc" runat="server" TextMode="MultiLine" CssClass="textboxstyle" Width="100%" Enabled="false"></asp:TextBox>
                                                     </div>
                                                 </div>
                                                 <div class ="row">
                                                     <div class ="col-md-3" align ="center">
                                                         <asp:Image  ID="Image1" runat="server" class="img-responsive" alt="User Image"></asp:Image>
                                                     </div>
                                                 </div>
                                                 <hr />
                                                 <p></p>
                                                 <div class="row">
                                                     <div class="col-md-12" align="right">
                                                         <asp:LinkButton ID="linkbtnCancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Button1_Click"><i class="fa  fa-times fa-lg" style="color:red" aria-hidden="true" ></i> Cancel</asp:LinkButton>
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
