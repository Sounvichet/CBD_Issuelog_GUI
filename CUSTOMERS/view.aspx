<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="CUSTOMERS_view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

  <link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../dist/css/adminlte.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>

      <style>
               @page {
    size: A4.landscape ;
    
        }
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
         textarea
         {
            resize: none;
         }
  </style>

     <script type="text/javascript">
        function OpenPage() {
            this.parent.document.getElementById("frm2").src = "getcustserviceimage.aspx";
         };
          function Print() {
            window.print();
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
<body style="background-color:#ecf0f5" class="A4.landscape">
    <form id="form1" runat="server">
        <section class="content">
          <div class="container-fluid">
            <!-- COLOR PALETTE -->
            <div class="card card-default color-palette-box">
              <div class="card-header">
                <h3 class="card-title">
                  <i class="fas fa-users"></i>
                  View CUSTOMER 
                </h3>
              </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                         <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtncancel_Click"><i class="fas fa-caret-left" style="color:white" aria-hidden="true" ></i> Cancel</asp:LinkButton>                   
                        <button id="printPage" class="no-print btn btn-sm btn-primary" onclick="Print();"><i class="fa fa-print fa-lg" style="color:black;" aria-hidden="true"></i> Print</button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="text-align:left">
                              <asp:Image ID="cusimage" CssClass="profile-user-img img-responsive user-image" alt="User profile picture" runat="server" Width="150px"></asp:Image>                                      
                         </div>
                    </div>
                       <div class="row user-control">
                                                <div class="col-md-6">
                                                      <div class="form-group">
                                                          <asp:LinkButton ID="LinkAction" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkAction_Click"><i class="fas fa-image" style="color:white" aria-hidden="true" ></i> Edit Image</asp:LinkButton> 
                                                          </div>
                                                </div>
                                            </div>

                    <div class="row user-control">
                        <div class="col-md-3">
                            CUSTOMER ID
                        </div>
                        <div class="col-md-3">
                            <label id="txtcustomerID" runat="server" style="color:blue"></label>
                        </div>
                        <div class="col-md-3">
                            Customer Name
                        </div>
                        <div class="col-md-3">
                            <label id="Txtcustomername" runat="server" style="color:blue"></label>
                        </div>
                    </div>

                    <div class="row user-control">
                        <div class="col-md-3">
                            Phone number
                        </div>
                        <div class="col-md-3">
                            <label id="txtphone" runat="server" style="color:blue"></label>
                        </div>
                        <div class="col-md-3">
                            ServicePackage
                        </div>
                        <div class="col-md-3">
                            <label id="txtservicePKG" runat="server" style="color:blue"></label>
                            <%--<asp:TextBox ID="txtservicePKG" runat ="server" CssClass="textboxstyle"></asp:TextBox>--%>
                        </div>
                    </div>

                    <div class="row user-control">
                        <div class="col-md-3">
                            Service Status
                        </div>
                        <div class="col-md-3">
                            <label id="txtserviceStatus" runat="server" style="color:blue"></label>
                        </div>
                        <div class="col-md-3">
                            SERVICEID
                        </div>
                        <div class="col-md-3">
                            <label id="txtSERVICEID" runat="server" style="color:blue"></label>
                        </div>
                    </div>

                     <div class="row user-control">
                        <div class="col-md-3">
                            Cycle (វត្ត)
                        </div>
                        <div class="col-md-3">
                            <label id="txtcycle" runat="server" style="color:blue"></label>
                        </div>

                         <div class="col-md-3">
                             OutStanding
                         </div>
                         <div class="col-md-3">
                             <label id="txtoutstanding" runat="server" style="color:blue"></label>
                         </div>
                    </div>

                    <div class="row user-control">
                        <div class="col-md-3"> 
                             Description
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="t_cust_desc" runat ="server" CssClass ="textboxstyle" Width="100%" TextMode="MultiLine" Height="50px"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:LinkButton ID="linkADD" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkADD_Click"><i class="fa fa-plus" style="color:white" aria-hidden="true" ></i> ADD</asp:LinkButton> 
                        </div>
                    </div>

                      <div class="row user-control">
                                <div class="col-lg-12 textboxstyle" style="background-color:cornflowerblue;height:inherit">
                                    <label id="lblBG">Customer Schedule</label>
                                </div>
                    </div>

                    <div class="row user-control">
                    <div class="col-md-6">
                         <asp:LinkButton ID="linkView" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkView_Click" ><i class="fa fa-search" style="color:white" aria-hidden="true"></i> View</asp:LinkButton>             
                    </div>
                </div>

                        <div class="row user-control">
                        <div class="col-lg-12">
                            <div class ="table-responsive">
                                <asp:GridView ID="grid1" DataKeyNames="CustomerID" CssClass="table table-bordered gridgetsize" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" onpageindexchanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true" OnRowDataBound="grid1_RowDataBound" OnRowCommand="grid1_RowCommand">
                                    <HeaderStyle CssClass="gvHeaderCenter" BackColor="#01559E" Font-Bold="true" ForeColor="#f5f5f5" />
                            <Columns>

                                <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server"/>
                                </HeaderTemplate>
                                <ItemTemplate>
                                <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);"  />
                                <%--<input type ="checkbox" runat="server" onclick ="RadioCheck(this);" checked="checked"/>--%>
                                <%-- <asp:LinkButton ID="lnkEdit"   runat="server" CommandName="lnkedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-left:30px;margin-right:30px"><i class= "fa fa-pencil"></i></asp:LinkButton>
                                <asp:LinkButton ID = "InkDelete" runat="server" CommandName="InkDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-right:30px"><i class= "fa fa-trash-o"> </i></asp:LinkButton>--%>
                                <%--<asp:LinkButton ID = "lnkView" runat="server" CommandName="lnkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class= "fa fa-eye"> </i></asp:LinkButton>--%>
                                </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblview" runat="server" Text="View" align="center"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <asp:LinkButton ID="LinkView" runat="server" CommandName="LinkView"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-search" style ="color:blue"></i></asp:LinkButton>    <%--style = "margin-left:30px;margin-right:30px;width:20px"--%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gvItemCenter" />
                                        <HeaderStyle CssClass="gvHeaderCenter" />
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


                      <div class="row user-control">
                                <div class="col-lg-12 textboxstyle" style="background-color:cornflowerblue;height:inherit">
                                    <label id="lblhisservice">Customer Service Hisotry</label>
                                </div>
                    </div>


                    <div class="row user-control">
                        <div class="col-lg-12">
                            <div class ="table-responsive">
                                <asp:GridView ID="GridService" DataKeyNames="CustomerID" CssClass="table table-bordered gridgetsize" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" onpageindexchanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true" OnRowDataBound="GridService_RowDataBound">
                                    <HeaderStyle CssClass="gvHeaderCenter" BackColor="#01559E" Font-Bold="true" ForeColor="#f5f5f5" />
                            <Columns>

                                

                              <%--  <asp:TemplateField>
                                        <ItemStyle CssClass="gvItemCenter" />
                                        <HeaderStyle CssClass="gvHeaderCenter" />
                                    </asp:TemplateField>--%>

                            </Columns>
                            <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                            </asp:GridView>
                            </div>
                            </div>
                       </div>

                     <div class="row">
                        <div class="col-lg-12">
                        <asp:Label ID="Label1" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Label" Visible="true"></asp:Label>
                        </div>
                    </div>


                     <div class="row user-control">
                                <div class="col-lg-12 textboxstyle" style="background-color:cornflowerblue;height:inherit">
                                    <label id="lblhispayment">Payment Hisotry</label>
                                </div>
                    </div>

                    <div class="row user-control">
                        <div class="col-lg-12">
                            <div class ="table-responsive">
                                <asp:GridView ID="Gridpayment"  CssClass="table table-bordered gridgetsize" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" onpageindexchanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true" OnRowDataBound="Gridpayment_RowDataBound">
                                    <HeaderStyle CssClass="gvHeaderCenter" BackColor="#01559E" Font-Bold="true" ForeColor="#f5f5f5" />
                            <Columns>

                                

                              <%--  <asp:TemplateField>
                                        <ItemStyle CssClass="gvItemCenter" />
                                        <HeaderStyle CssClass="gvHeaderCenter" />
                                    </asp:TemplateField>--%>

                            </Columns>
                            <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                            </asp:GridView>
                            </div>
                            </div>
                       </div>

                     <div class="row">
                        <div class="col-lg-12">
                        <asp:Label ID="Label5" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="Label" Visible="true"></asp:Label>
                        </div>
                    </div>

                    <div class="row user-control">
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
                                                                           <%-- <button id="btn_print_proxy" style="margin-bottom: 10px;" class="btn btn-default">
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
                                                         </div>
                                                     </div>


                </div>
                </div>
              </div>
            </section>
    </form>
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
