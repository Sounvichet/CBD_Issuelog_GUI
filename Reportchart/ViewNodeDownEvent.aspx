<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNodeDownEvent.aspx.cs" Inherits="Reportchart_ViewNodeDownEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl("~/js/adminlte.min.js")%>"></script>
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
        .gvItemCenter { text-align: center; }
        .gvHeaderCenter {  text-align: center; }
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
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header">
                                                <h3 class="box-title" style="color:blue">View NodeDownEvent</h3>
                                            </div>
                                            <hr />
                                            <div class="box-body">
                                                
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        Event No :
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txtEventno" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-3">
                                                        Node Type :
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txtNodetype" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <p></p>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        BranchName :
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txtbranchname" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                                                    </div>
                                                    
                                                </div>
                                                <p></p>
                                                  <div class="row">
                                                    <div class="col-md-3">
                                                        NodeName :
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtNodeName" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                                                    </div>  
                                                </div>
                                                <p></p>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        DownTimePlan :
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:DropDownList ID="D_DownTimePlan" runat="server" CssClass="textboxstyle" Width="100%"></asp:DropDownList>
                                                    </div>  

                                                    <div class="col-md-3">
                                                        Group Reason :
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:DropDownList ID="d_groupReason" runat="server" CssClass="textboxstyle" Width="100%"></asp:DropDownList>
                                                    </div>

                                                </div>
                                                <p></p>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        Description:
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtdesc" runat="server" CssClass="textboxstyle" TextMode="MultiLine" Width="100%" Height="50px"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <p></p>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        Down Time :
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group has-feedback">
                                                            <asp:TextBox ID="txtdowntime" runat="server" CssClass="textboxstyle form-control" Width="100%" Enabled="false"></asp:TextBox>
                                                            <span class="fa fa-calendar form-control-feedback"></span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        Up Time :
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group has-feedback">
                                                            <asp:TextBox ID="txtuptime" runat="server" CssClass="textboxstyle form-control" Width="100%" Enabled="false"></asp:TextBox>
                                                            <span class="fa fa-calendar form-control-feedback"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <p></p>

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        Resolution :
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtResolution" runat="server" CssClass="textboxstyle" TextMode="MultiLine" Width="100%" Height="50px"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <p></p>
                                                <div class="row">
                                                    <div class ="col-md-3">
                                                        Reason :
                                                    </div>

                                                    <div class ="col-md-3">
                                                        <asp:DropDownList ID="D_reason" runat="server" CssClass="textboxstyle" Width="100%"></asp:DropDownList>
                                                    </div>
                                                    <div class ="col-md-3">
                                                        Action :
                                                    </div>

                                                    <div class ="col-md-3">
                                                        <asp:DropDownList ID="D_action" runat="server" CssClass="textboxstyle" Width="100%"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <p></p>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        Reason Desc :
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtreasondesc" runat="server" CssClass="textboxstyle" TextMode="MultiLine" Width="100%" Height="50px"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <p></p>

                                              <div class ="row">
                                                     <div class="col-md-12">
                                                          <div class="box box-primary table-responsive">
                                                            <div class="box-header with-border">
                                                              <h3 class="box-title">NodeEvent His</h3>
                                                              <div class="box-tools pull-right">
                                                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                                                                </button>
                                                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                              </div>
                                                            </div>
                                                                <div class="box-body">
                                                                   <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-hover" Font-Size="Smaller"  GridLines="None" RowStyle-Wrap="false"> 
                                                                   <Columns>

                                                                         
                                                                   </Columns> 
                                                                   </asp:GridView>
                                                                  <div>
                                                                     <asp:Label ID="Label9" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                                                                     <asp:Label ID="Label10" runat="server"  Visible="true"></asp:Label>
                                                                 </div>
                                                                </div>
                                                             </div>
                                                     </div>
                                                  
                                                 </div>

                                                <div class="row">
                                                    <div class="col-md-12" align ="right">
                                                        <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btncancel_Click1"><i class="fa  fa-times fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
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
