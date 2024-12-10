<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employeecontact.aspx.cs" Inherits="Contact_Employeecontact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />

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
        .gvItemCenter { text-align: left; }
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
                            <div class="col-md-12">
                                    <div class="box box-primary">
                                           <div class="box-body box-profile">
                                          <div class="box-header with-border">
                                              <i class="fa fa-users"></i>
                                                <h3 class="box-title" style="color:blue">Employee Contacts</h3>
                                          </div>
                                               <div class="box-body">

                                                   <div class="row">
                                                           <div class="col-lg-12">
                                                                  <div class ="table-responsive">
                                                                            <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-hover" Font-Size="09px" GridLines="None" RowStyle-Wrap="false"  AutoGenerateColumns="true" OnRowDataBound="GridView2_RowDataBound" OnRowCreated="GridView2_RowCreated" > 
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
</body>
</html>
