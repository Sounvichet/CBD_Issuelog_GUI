<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Complaint_index" %>

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
    </style>
        <script type="text/javascript">
         function RadioCheck(rb) {
             var gv = document.getElementById("<%=grid1.ClientID%>");
             var rbs = gv.getElementsByTagName("input");
             var row = rb.parentNode.parentNode;
             for (var i = 0; i < rbs.length; i++) {
                 if (rbs[i].type == "checkbox") {
                     if (rbs[i].checked && rbs[i] != rb) {
                         rbs[i].checked = false;
                         break;
                     }
                 }
             }
         };
</script>
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
               <section class="content">
                              <div class="row">
                                            <div class="col-xs-12">
                                            <div class="box box-primary">
                                                    <div class="box-body box-profile">
                                                            <div class="box-header with-border">
                                                                <i class="fa fa-users"></i>
                                                                <h3 class="box-title" style="color:blue">Comaplaint Pending</h3>
                                                             </div>
                                                       <div class="box-body">
                                                           <asp:ScriptManager ID="SMcomplaintindex" runat="server"></asp:ScriptManager>
                                                           <asp:UpdatePanel ID="updatecomplaintpanel" UpdateMode="Conditional" runat="server">
                                                               <ContentTemplate>
                                                                <div class ="row">
                                                                    <div class="col-md-6">
                                                                        <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnedit_click"><i class="fa fa-pencil fa-lg" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btndel_Click"><i class="fa  fa-times fa-lg" style="color:red" aria-hidden="true" ></i> Delete</asp:LinkButton>
                                                                    </div>
                                                                    <p></p>
                                                                    <div class="col-md-6" align="right">
                                                                    <asp:Label ID="Label1" runat="server" Text="User_name"></asp:Label>
                                                                    <asp:DropDownList ID="D_User_name" runat="server" Width = "100px" AutoPostBack="true" OnSelectedIndexChanged="D_User_name_SelectedIndexChanged" CssClass = "textboxstyle">
                                                                    </asp:DropDownList>

                                                                        <asp:LinkButton ID="LinkbtnExport" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btn_apply_Click"><i class="fa fa-file-excel-o fa-lg" aria-hidden="true" ></i> Export</asp:LinkButton>

                                                                    </div>

                                                                </div>

                                                                <div class ="row">
                                                                    <div class ="col-lg-12">
                                                                        <div class="table-responsive">
                                                                            <asp:GridView ID="grid1" DataKeyNames="ticket_no" CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" OnRowCommand="grid1_RowCommand" onpageindexchanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true">
                                                                             <%--  <AlternatingRowStyle BackColor="White" />--%>
                                                                               <Columns>
                                                                                   <asp:TemplateField>
                                                                                   <HeaderTemplate>
                                                                                       <asp:Label ID="Label1" runat="server" Text="Check" align="center"></asp:Label>
                                                                                   </HeaderTemplate>

                                                                                       <ItemTemplate>
                                                                                       <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);"  />
                                                                                       </ItemTemplate>
                                                                                   
                                                                                   </asp:TemplateField>

                                                                                   <asp:TemplateField>

                                                                                       <HeaderTemplate>
                                                                                           <asp:Label ID="Label1" runat="server" Text="Edit" align="center"></asp:Label>
                                                                                       </HeaderTemplate>
                                                                                       <ItemTemplate>
                                                                                           <asp:LinkButton ID="lnkEdit"   runat="server" CommandName="lnkEdit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-user fa-pencil" style="color:blue"></i></asp:LinkButton>
                                                                                       </ItemTemplate>
                                                                                   </asp:TemplateField>

                                                                                   <asp:TemplateField>
                                                                                       <HeaderTemplate>
                                                                                           <asp:Label ID="Label1" runat="server" Text="Delete" align="center"></asp:Label>
                                                                                       </HeaderTemplate>
                                                                                       <ItemTemplate>
                                                                                           <asp:LinkButton ID = "InkDelete" runat="server" CommandName="InkDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-user fa-trash-o" style="color:red"></i></asp:LinkButton>
                                                                                       </ItemTemplate>
                                                                                   </asp:TemplateField>
                                                 
                                                                                </Columns>
                                                                               <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                              </div>

                                                           <div class="row">
                                                                   <div class="col-lg-12">
                                                                    <asp:Label ID="Label3" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                                                                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="true"></asp:Label>
                                                                   </div>
                                                           </div>
                                                </ContentTemplate>
                                                               <Triggers>
                                                                   <asp:PostBackTrigger ControlID="LinkbtnExport" />
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
