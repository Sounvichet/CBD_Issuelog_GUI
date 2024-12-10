﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="CUSTOMERS_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

  <link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../dist/css/adminlte.min.css">
      <!-- SweetAlert2 -->
  <link rel="stylesheet" href="../../plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <%--<link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />--%>
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
        function OpenPage() {
            this.parent.document.getElementById("frm2").src = "getcustserviceimage.aspx";
        }
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
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
    <section class="content">
      <div class="container-fluid">
        <!-- COLOR PALETTE -->
        <div class="card card-default color-palette-box">
          <div class="card-header">
            <h3 class="card-title">
              <i class="fas fa-users"></i>
              CUSTOMER INFORMATION
            </h3>
          </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-6">
                         <asp:LinkButton ID="linkbtnnew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnnew_Click" ><i class="fa fa-plus" style="color:green" aria-hidden="true"></i> Add</asp:LinkButton>
                         <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnedit_Click"><i class="fa fa-pencil" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                         <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtndel_Click"><i class="fa  fa-times" style="color:red" aria-hidden="true" ></i> Delete</asp:LinkButton>
                         <asp:LinkButton ID="LinkBtnview" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtnview_Click"><i class="fa fa-eye" style="color:orange" aria-hidden="true" ></i> View</asp:LinkButton>
                         <asp:LinkButton ID="Linkprint" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkprint_Click"><i class="fa fa-print" style="color:black" aria-hidden="true" ></i> Print</asp:LinkButton>  
                        
                   
                    </div>
                    <div class="col-md-6" align ="right">
                        <asp:TextBox ID="TxtUser" runat="server" CssClass="textboxstyle" placeholder="Customer phone" ></asp:TextBox>
                        <%--<input type="button" id="btnSearch" class="btn btn-sm btn-primary" value="Search" runat="server" onclick="bc"/>--%>
                        <asp:LinkButton ID="btnsearch" CssClass="btn btn-sm btn-primary" OnClick="btnsearch_Click" runat="server"  aria-hidden="true"><i class="fas fa-search" style="color:white" aria-hidden="true" ></i> Search</asp:LinkButton>
                    </div>
                </div>

                <div class="row user-control">
                    <div class="col-lg-12">
                        <div class ="table-responsive">
                            <asp:GridView ID="grid1" DataKeyNames="CustomerID" CssClass="table-bordered table-hover gridgetsize" runat="server" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" onpageindexchanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true">
                        <%-- <AlternatingRowStyle BackColor="White" />--%>
                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#01559E" Font-Bold="true" ForeColor="#f5f5f5" />
                        <Columns>

                            <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                            <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);"  />
                                <%--<input type ="checkbox" runat="server" onclick ="RadioCheck(this);" checked="checked"/>--%>
                           <%-- <asp:LinkButton ID="lnkEdit"   runat="server" CommandName="lnkedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-left:30px;margin-right:30px"><i class= "fas fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton ID = "InkDelete" runat="server" CommandName="InkDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-right:30px"><i class= "far fa-trash-alt"> </i></asp:LinkButton>
                            <asp:LinkButton ID = "lnkView" runat="server" CommandName="lnkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-right:30px"><i class= "fa fa-eye"> </i></asp:LinkButton>--%>
                            </ItemTemplate>
                            </asp:TemplateField>


                         <%--   <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblEdit" runat="server" Text="Edit" align="center"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="LinkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fas fa-edit" style ="color:blue"></i></asp:LinkButton>  
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gvItemCenter" />
                                        <HeaderStyle CssClass="gvHeaderCenter" />
                                    </asp:TemplateField>--%>

                                <%--   <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lbldelete" runat="server" Text="Delete" align="center"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <asp:LinkButton ID="InkDelete" runat="server" CommandName="LinkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="far fa-trash-alt" style ="color:blue"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gvItemCenter" />
                                        <HeaderStyle CssClass="gvHeaderCenter" />
                                    </asp:TemplateField>--%>

                                 <%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblview" runat="server" Text="View" align="center"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <asp:LinkButton ID="LinkView" runat="server" CommandName="LinkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-search" style ="color:blue"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gvItemCenter" />
                                        <HeaderStyle CssClass="gvHeaderCenter" />
                                    </asp:TemplateField>--%>


                        </Columns>
                        <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" Font-Size="Small"/>
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
            
                <div class="row">
                                                     <div class="col-md-12" >
                                                         <div class="modal fade"  style="display: none; width:100%" id="iframe-open">
                                                                <div class="modal-dialog modal-lg">
                                                                    <div class="modal-content">
                                                                        <div class="modal-header">
                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                <span aria-hidden="true">&times;</span></button>
                                                                            <h4 class="modal-title" style="color:black;font-size:larger">
                                                                             <label id="GetTitlescreen" runat="server"></label>

                                                                            </h4>
                                                                        </div>
                                                                        <div class="modal-body">
                                                                            <button id="btn_print_proxy" style="margin-bottom: 10px;" class="btn btn-default">
                                                                                <i class="fa fa-print"></i> Print</button>
                                                                            <button type="button" class="btn btn-default" style="margin-bottom: 10px;" data-dismiss="modal">
                                                                                <i class="fa fa-times"></i>Close</button>
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
          </div>
        </div>
        <!-- /.card -->

      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  
        
    </form>
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
<script src="../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../dist/js/adminlte.min.js"></script>
<!-- SweetAlert2 -->
<script src="../../plugins/sweetalert2/sweetalert2.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="../dist/js/demo.js"></script>
</body>
</html>
