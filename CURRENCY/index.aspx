<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="CURRENCY_index" %>

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
  </style>
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
              COMPANY INFROMATION
            </h3>
          </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-6">
                         <asp:LinkButton ID="linkbtnnew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnnew_Click" ><i class="fa fa-plus" style="color:green" aria-hidden="true"></i> Add</asp:LinkButton>
                         <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnedit_Click1"><i class="fa fa-pencil" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                         <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtndel_Click"><i class="fa  fa-times" style="color:red" aria-hidden="true" ></i> Delete</asp:LinkButton>
                         <asp:LinkButton ID="LinkBtnview" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtnview_Click"><i class="fa fa-eye" style="color:orange" aria-hidden="true" ></i> View</asp:LinkButton>
                         <asp:LinkButton ID="Linkprint" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkprint_Click"><i class="fa fa-print" style="color:black" aria-hidden="true" ></i> Print</asp:LinkButton>                   
                    </div>
                    
                </div>

                <div class="row user-control">
                    <div class="col-lg-12">
                        <div class ="table-responsive">
                            <asp:GridView ID="grid1"  CssClass="table-bordered table-hover gridgetsize"  runat="server"  AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" OnRowCommand="grid1_RowCommand" onpageindexchanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true">
                        <%-- <AlternatingRowStyle BackColor="White" />--%>
                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#01559E" Font-Bold="true" ForeColor="#f5f5f5" />
                        <Columns>

                            <asp:TemplateField >
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                            <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);"  />
                                <%--<input type ="checkbox" runat="server" onclick ="RadioCheck(this);" checked="checked"/>--%>
                            <asp:LinkButton ID="lnkEdit"   runat="server" CommandName="lnkedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-left:30px;margin-right:30px"><i class= "fas fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton ID = "InkDelete" runat="server" CommandName="InkDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" style = "margin-right:30px"><i class= "far fa-trash-alt"> </i></asp:LinkButton>
                            <asp:LinkButton ID = "lnkView" runat="server" CommandName="lnkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class= "fa fa-eye"> </i></asp:LinkButton>
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

            
          </div>
        </div>
        <!-- /.card -->

      </div><!-- /.container-fluid -->
    </section>
    </form>
<script src="../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../dist/js/adminlte.min.js"></script>
</body>
</html>
