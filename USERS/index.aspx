<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="USERS_index" %>

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
        .form-control{
            font-size:15px;
            border-radius:5px 5px 5px 5px;
            padding:2px 2px 2px 2px;
            height:auto;
            margin: 0 auto;
        } 
        .user-control
         {
         padding-top:5px;
         }
         .textboxstyle
            {
                font-size:15px;
                border-radius:5px 5px 5px 5px;
                border:1px solid #c4c4c4;
                padding:2px 2px 2px 2px;
                vertical-align:middle!important;
                /*text-align:center!important;*/
            margin-bottom: 0px;
        }
            .textboxstyle:focus
            {
                border:1px solid #7bc1f7;
            }
            .gvItemCenter { text-align: center; }
            .gvHeaderCenter {  text-align: center; }
        .tdalign {
                vertical-align: middle !important;
                text-align: center !important;
        }
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

</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
    <section class="content">
               <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
          <div class="card-header">
            <h3 class="card-title">
              <i class="fa fa-users"></i>
              USER INFROMATION
            </h3>
          </div>
            <div class="card-body">
                      <div class="row user-control">
                            <div class="col-md-12">
                                        <div  id="alert_container">
                                                         
                                      </div>
                            </div>
                    </div>

                <div class="row">
                    <div class="col-md-6">
                         <asp:LinkButton ID="linkbtnnew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnnew_Click" ><i class="fa fa-plus" style="color:green" aria-hidden="true"></i> Add</asp:LinkButton>
                         <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnedit_Click1"><i class="fa fa-pencil" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                         <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtndel_Click"><i class="fa  fa-times" style="color:red" aria-hidden="true" ></i> Delete</asp:LinkButton>
                         <asp:LinkButton ID="LinkBtnview" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtnview_Click"><i class="fa fa-eye" style="color:orange" aria-hidden="true" ></i> View</asp:LinkButton>
                         <asp:LinkButton ID="Linkprint" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkprint_Click"><i class="fa fa-print" style="color:black" aria-hidden="true" ></i> Print</asp:LinkButton>
                        
                              <div class="btn-group">
                                <button type="button" class="btn btn-sm btn-primary">Action</button>
                                <button type="button" class="btn btn-sm btn-primary dropdown-toggle" data-toggle="dropdown">
                                <span class="caret"></span>
                                <span class="sr-only">Toggle Dropdown</span>
                                </button>
                                   <ul class="dropdown-menu" role="menu" style="background-color:#00A7A5; width: 300px">
                                        <li >
                                            <a class="fa fa-file-excel-o fa-lg" id="adisacc"  href="#" onserverclick="adisacc_ServerClick1" runat="server" style="color:black; height:auto; margin-left:10px;">  Disable Account</a>
                                            <a class="fa fa-check-circle fa-lg" id="enaacc" runat="server" onserverclick="enaacc_ServerClick" style="color:black; height:auto; margin-left:10px;">  Enable Account</a>
                                            <a class="fa fa-eraser fa-lg" id="clearlog" runat="server" onserverclick="clearlog_ServerClick" style="color:black; height:auto; margin-left:10px;"> Clear Log</a>
                                            <a class="fa fa-refresh fa-lg" id="refresh_pwd" runat="server" onserverclick="refresh_pwd_ServerClick" style="color:black; height:auto; margin-left:10px;"> Refresh Password</a>
                                            <a class="fa fa-check-circle fa-lg" id="userppermission" runat="server" onserverclick="userppermission_ServerClick" style="color:black; height:auto; margin-left:10px;"> user And Permission</a>
                                        </li>
                                    </ul>
                         </div>

                    </div>
                    <div class="col-md-6" align ="right">
                        <asp:TextBox ID="TxtUser" runat="server" CssClass="textboxstyle" placeholder="UserName" ></asp:TextBox>
                        <%--<input type="button" id="btnSearch" class="btn btn-sm btn-primary" value="Search" runat="server" onclick="bc"/>--%>
                        <asp:LinkButton ID="btnsearch" CssClass="btn btn-sm btn-primary" runat="server"  aria-hidden="true" OnClick="btnsearch_Click"><i class="fa fa-search" style="color:white" aria-hidden="true" ></i></asp:LinkButton>
                    </div>
                </div>

                <div class="row user-control">
                    <div class="col-lg-12">
                        <div class ="table-responsive">
                            <asp:GridView ID="grid1" CssClass="table table-bordered table-hover"  runat="server" Font-Size="11px"  AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" OnRowCommand="grid1_RowCommand" onpageindexchanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true">
                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" /> 
                        <Columns>

                            <asp:TemplateField >
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                            <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);"  />
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
            
          </div>
        </div>
        </div>
                            </div>
      </div><!-- /.container-fluid -->
    </section>
    </form>


</body>
</html>
