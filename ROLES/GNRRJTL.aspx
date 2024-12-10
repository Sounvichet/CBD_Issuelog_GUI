<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GNRRJTL.aspx.cs" Inherits="ROLES_GNRRJTL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/plugins/fontawesome-free/css/all.min.css")%>" rel="stylesheet" type="text/css" />
    
      <style>
    .color-palette {
      height: 35px;
      line-height: 35px;
      text-align: right;
      padding-right: .75rem;
    }
       .user-control
         {
         padding-top:5px;
         }
    .color-palette.disabled {
      text-align: center;
      padding-right: 0;
      display: block;
    }
    
    .color-palette-set {
      margin-bottom: 15px;
    }

    .color-palette span {
      display: none;
      font-size: 12px;
    }

    .color-palette:hover span {
      display: block;
    }

    .color-palette.disabled span {
      display: block;
      text-align: left;
      padding-left: .75rem;
    }

    .color-palette-box h4 {
      position: absolute;
      left: 1.25rem;
      margin-top: .75rem;
      color: rgba(255, 255, 255, 0.8);
      font-size: 12px;
      display: block;
      z-index: 7;
    }
    .gvItemCenter { text-align: center; }
    .gvHeaderCenter {  text-align: center; width:20px }

          .gridgetsize
          {
              max-height: 280px;
              overflow : auto;
               width: 100%;
              margin-bottom: 1rem;
              color: #212529;
              background-color: transparent;
          }
          .gridgetsize th
            {
             font-size: 14px;
             font-weight: bold;
             white-space: nowrap;
              
            }

            .gridgetsize th,
            .gridgetsize td {
              padding: 0.30rem;
              vertical-align: top;
              border-top: 1px solid #dee2e6;
            }

            .gridgetsize thead th {
              vertical-align: bottom;
              border-bottom: 2px solid #dee2e6;
            }

            .gridgetsize tbody + tbody {
              border-top: 2px solid #dee2e6;
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
          .onclicked:hover {
          background-color:gray !important;
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

        <script type="text/javascript">  
        $(document).ready(function () {  
            //$("#btnShowModal").click(function () {  
            //    $("#loginModal").modal('show');  
            //});  
  
            $("#btnHideModal").click(function () {  
                $("#loginModal").modal('hide');  
            });

            $('#btn_print_proxy').click(function  ()  {
                document.getElementById("frm2").contentWindow.print();
                }); 
        });  
    </script>
</head>
<body >
    <form id="form1" runat="server">
              <div class="row">
                    <div class="col-md-6">
                         <asp:LinkButton ID="linkbtnnew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnnew_Click" ><i class="fa fa-plus" style="color:green" aria-hidden="true"></i> Add</asp:LinkButton>
                         <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnedit_Click"><i class="fa fa-pencil" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                         <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtndel_Click"><i class="fa  fa-times" style="color:red" aria-hidden="true" ></i> Delete</asp:LinkButton>
                         <asp:LinkButton ID="LinkBtnview" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtnview_Click"><i class="fa fa-eye" style="color:orange" aria-hidden="true" ></i> View</asp:LinkButton>
                        <asp:LinkButton ID="LinkPermission" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkPermission_Click"><i class="fa fa-solid fa-users" style="color:black" aria-hidden="true" ></i> PERMISSION</asp:LinkButton>             
                        <asp:LinkButton ID="Linkexport" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkexport_Click"><i class="fa fa-light fa-file-excel" style="color:forestgreen" aria-hidden="true" ></i> Export</asp:LinkButton>
                    </div>
                    <div class="col-md-6" align ="right">
                        <asp:TextBox ID="txtrole" runat="server" CssClass="textboxstyle" placeholder="Roles" ></asp:TextBox>
                        <%--<input type="button" id="btnSearch" class="btn btn-sm btn-primary" value="Search" runat="server" onclick="bc"/>--%>
                        <asp:LinkButton ID="btnsearch" CssClass="btn btn-sm btn-primary" runat="server" OnClick="btnsearch_Click"  aria-hidden="true">
                            <i class="fas fa-search" style="color:white" aria-hidden="true"></i> Search</asp:LinkButton>
                    </div>
                </div>
        
        <div class="row user-control">
                    <div class="col-lg-12">
                        <div class ="table-responsive">
                            <asp:GridView ID="gridgroup"  CssClass="table table-bordered table-hover"  runat="server" Font-Size="11px"  AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" OnRowCommand="grid1_RowCommand" onpageindexchanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true">
                        <%-- <AlternatingRowStyle BackColor="White" />--%>
                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />
                        <Columns>

                            <asp:TemplateField >
                            <HeaderTemplate>
                                Check
                            </HeaderTemplate>
                            <ItemTemplate>
                            <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);"/>
                                <%--<input type ="checkbox" runat="server" onclick ="RadioCheck(this);" checked="checked"/>--%>
                            <%--<asp:LinkButton ID="lnkEdit"   runat="server" CommandName="lnkedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-left:30px;margin-right:30px"><i class= "fas fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton ID = "InkDelete" runat="server" CommandName="InkDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-right:30px"><i class= "far fa-trash-alt"> </i></asp:LinkButton>
                            <asp:LinkButton ID = "lnkView" runat="server" CommandName="lnkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-right:20px"><i class= "fa fa-eye"> </i></asp:LinkButton>--%>
                            </ItemTemplate>
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter"/>
                            </asp:TemplateField>

                        </Columns>
                        <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" Font-Size="10px"/>
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

                    <div class="row user-control">
                                                     <div class="col-md-12" >
                                                         <div class="modal fade"  style="display: none; width:100%" id="iframe-open">
                                                                <div class="modal-dialog modal-lg">
                                                                    <div class="modal-content">
                                                                        <div class="modal-header">

                                                                            <h4 class="modal-title" style="color:black;font-size:larger">
                                                                             <label id="GetTitlescreen" runat="server"></label>
                                                                            </h4>

                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                <span aria-hidden="true">&times;</span></button>

                                                                        
                                                                        </div>
                                                                        <div class="modal-body">
                                                                          <%--  <button id="btn_print_proxy" style="margin-bottom: 10px;" class="btn btn-default">
                                                                                <i class="fa fa-print"></i> Print</button>
                                                                            <button type="button" class="btn btn-default" style="margin-bottom: 10px;" data-dismiss="modal">
                                                                                <i class="fa fa-times"></i>Close</button>--%>
                                                                            <iframe id="frm2" runat="server"  allowfullscreen="true" scrolling="yes" frameborder="0" style ="width:100%;height:800px;"  ></iframe>
                                                                        </div>
                                                                      
                                                                        <div class="modal-footer">
                                                                          
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                          <%--End TopUp Dialog --%>
                                                         </div>
                                                     </div>

    </form>
       <script type="text/javascript">
         function RadioCheck(rb) {
             var gv = document.getElementById("<%=gridgroup.ClientID%>");
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

    <script src="<%= Page.ResolveUrl ("~/plugins/jquery/jquery.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/plugins/bootstrap/js/bootstrap.bundle.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/plugins/sweetalert2/sweetalert2.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/plugins/toastr/toastr.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/dist/js/adminlte.min.js")%>"></script>
</body>
</html>
