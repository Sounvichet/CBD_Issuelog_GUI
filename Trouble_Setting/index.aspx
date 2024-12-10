<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Trouble_Setting_index" %>

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
                    .gvItemCenter { text-align: center; }
                    .gvHeaderCenter {  text-align: center; }
                    .GridPager {
                       background-color: #fff;
                       padding: 2px;
                       margin: 2% auto;
                         }

                   .GridPager a {
                       margin: auto 1%;
                       border-radius: 50%;
                       background-color: #545454;
                       padding: 5px 10px 5px 10px;
                       color: #fff;
                       text-decoration: none;
                       -o-box-shadow: 1px 1px 1px #111;
                       -moz-box-shadow: 1px 1px 1px #111;
                       -webkit-box-shadow: 1px 1px 1px #111;
                       box-shadow: 1px 1px 1px #111;
                   }

                   .GridPager a:hover {
                       background-color: #337ab7;
                       color: #fff;
                   }

               .GridPager span {
                   background-color: #066091;
                   color: #fff;
                   -o-box-shadow: 1px 1px 1px #111;
                   -moz-box-shadow: 1px 1px 1px #111;
                   -webkit-box-shadow: 1px 1px 1px #111;
                   box-shadow: 1px 1px 1px #111;
                   border-radius: 50%;
                   padding: 5px 10px 5px 10px;
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
                                                     <div class="box-header with-border">
                                                         <i class="fa fa-file-text"></i>
                                                     <h3 class="box-title"style="color:blue">Trouble Setting</h3>
                                                    </div>
                                                <div class="box-body">
                                                             <div class="row">
                                                                  <div class="col-md-12">
                                                                      <div class ="table-responsive">
                                                                            <asp:GridView ID="Gridtrouble" DataKeyNames="ReportCat" runat="server" CssClass="table table-bordered table-hover" Font-Size="Smaller" Width="100%" RowStyle-Wrap="false" OnRowCommand="Gridview_RowCommand"> 
                                                                               <Columns>
                                                                                       <asp:TemplateField>
                                                                                           <HeaderTemplate>
                                                                                               Edit
                                                                                           </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                    <asp:LinkButton ID="EditTrouble" runat="server" CommandName="EditTrouble" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ><i class="fa fa-pencil" style="color:blue"></i></asp:LinkButton>    <%--style = "margin-left:30px;margin-right:30px;width:20px"--%>
                                                                                            </ItemTemplate>
                                                                                           <ItemStyle CssClass="gvItemCenter" />
                                                                                           <HeaderStyle CssClass="gvHeaderCenter" />
                                                                                        </asp:TemplateField>

                                                                                   <asp:TemplateField>
                                                                                           <HeaderTemplate>
                                                                                               View
                                                                                           </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                    
                                                                                                    <asp:LinkButton ID="ViewTrouble" runat="server" CommandName="ViewTrouble" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-eye" style="color:blue"></i></asp:LinkButton>    <%--style = "margin-left:30px;margin-right:30px;width:20px"--%>
                                                                                            </ItemTemplate>
                                                                                             <ItemStyle CssClass="gvItemCenter" />
                                                                                             <HeaderStyle CssClass="gvHeaderCenter" />
                                                                                        </asp:TemplateField>

                                                                                   </Columns>
                                                                            </asp:GridView>
                                                                          </div>
                                                                  </div>
                                                             </div>
                                                 
                                                                   
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                        <asp:Label ID="Label9" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                                                                        <asp:Label ID="Label10" runat="server"  Visible="true"></asp:Label>
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
