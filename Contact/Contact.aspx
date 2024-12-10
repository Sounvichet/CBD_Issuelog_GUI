<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="ContactTest" %>

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
               .proxy-title {
            font-family: 'Khmer Mool' !important;
            font-size: 16px;
            text-align: center;
        }
        .proxy-content {
            font-family: 'Khmer Nettra' !important;
            font-size: 13px;
        }
        .category_bg {
            background-color: #f99d1c;
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
                                          <div class="box-header with-border">
                                              <i class="fa fa-users"></i>
                                                <h3 class="box-title" style="color:blue">Employee Contacts </h3>
                                          </div>
                                               <div class="box-body">

                                              
                                <div class="row">
                                        <div class="col-md-12 textboxstyle category_bg">
                                            <asp:Label id="lbldept" runat="server" Font-Bold="true" CssClass="proxy-title"></asp:Label>
                                        </div>
                                    </div>
                                <p></p>
                                    <div class="row">
                                               <div class="col-lg-12">
                                                      <div class ="table-responsive">
                                                                <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-hover" Font-Size="11px" GridLines="None" RowStyle-Wrap="false"  OnRowDataBound="GridView2_RowDataBound" > 
                                                                   <HeaderStyle BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />
                                                                    <Columns>  
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                               
                                                                              </HeaderTemplate>
                                                                            <ItemTemplate>  
                                                                               <asp:RadioButton ID="RadioButton1" runat="server" onclick="RadioCheck(this);"/>
                                                                            </ItemTemplate>
                                                                         </asp:TemplateField>
                                                                    </Columns>
                                                                  <%--<RowStyle HorizontalAlign="Center" />--%>
                                                                  
                                                                   <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                                                  
                                                                   </asp:GridView>
                                                          Row count :<label id="rowcount" runat="server" style="color:blue"></label>
                                                      </div>
                                               </div>
                                          </div>
                                 </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
                    
    </form>
     <script type="text/javascript">
         function RadioCheck(rb) {
             var gv = document.getElementById("<%=GridView2.ClientID%>");
             var rbs = gv.getElementsByTagName("input");
             var row = rb.parentNode.parentNode;
             for (var i = 0; i < rbs.length; i++) {
                 if (rbs[i].type == "radio") {
                     if (rbs[i].checked && rbs[i] != rb) {
                         rbs[i].checked = false;
                         break;
                     }
                 }
             }
         };
</script>
</body>
</html>
