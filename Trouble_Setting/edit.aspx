<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="Trouble_Setting_edit" %>

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
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
     <section class="content">
              <div class="row">
                            <div class="col-xs-12">
                                   <div class="box box-primary">
                                       <div class="box-body box-profile">
                                                     <div class="box-header">
                                                 <h3 class="box-title">Edit Trouble Setting</h3>           
                                             </div>
                                             <div class="box-body">
                                                  <div class="row">
                                                       <div class="col-md-12">
                                                           <asp:LinkButton ID="linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnedit_Click" ><i class="fa fa-plus fa-lg" style="color:green" aria-hidden="true"></i> Edit</asp:LinkButton>
                                                           <asp:LinkButton ID="linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnsave_Click" Enabled="false"><i class="fa fa-pencil fa-lg" style="color:blue" aria-hidden="true" ></i> Save</asp:LinkButton>
                                                           <asp:LinkButton ID="linkbtnCancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnCancel_Click"><i class="fa  fa-times fa-lg" style="color:red" aria-hidden="true" ></i> Cancel</asp:LinkButton>

                                                       </div>
                                                  </div>

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

                                                 <div class="row">
                                                     <div class="col-md-3">
                                                            <asp:Label ID="Label4" runat="server" Text="Attach File"></asp:Label><span style=" color:Red;">*</span>
                                                     </div>
                                                     <div class="col-md-3">
                                                         <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select Only Excel File" />
                                                     </div>
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
