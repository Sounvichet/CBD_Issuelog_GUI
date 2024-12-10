<%@ Page Language="C#" AutoEventWireup="true" CodeFile="apptop.aspx.cs" Inherits="Testapptop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>issuelog System</title>
    <link rel="shortcut icon" href="/icon.png" type="image/png" />
    <link rel="icon" href="/Image/icon.png" type="image/png" />
    <!-- Tell the browser to be responsive to screen width -->

    
    
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">

    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">

    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">

    <link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">

    <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">

    <link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css">

    <link rel="stylesheet" href="dist/css/adminlte.min.css?v=3.2.0">

    <link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css">

    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css">

    <link rel="stylesheet" href="plugins/summernote/summernote-bs4.min.css">
    <style type="text/css">
        .Margin {
            margin-right: 5px !important;
        }

        .proxy-content {
            font-family: 'Khmer Nettra' !important;
            font-size: 13px;
            color: white;
        }
    </style>
</head>
<body class="hold-transition sidebar-mini layout-fixed">
    <!-- Sparkline Container -->
    <div id="sparkline-element"></div>
    <form id="form1" runat="server">
        <div class="wrapper">
            <!-- Navbar -->
            <nav class="main-header navbar navbar-expand navbar-white navbar-light">
                <!-- Left navbar links -->
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
                    </li>
                    <%--      <li class="nav-item d-none d-sm-inline-block">
        <a href="#" class="nav-link">Home</a>
      </li>
      <li class="nav-item d-none d-sm-inline-block">
        <a href="#" class="nav-link">Contact</a>
      </li>--%>
                </ul>

                <!-- SEARCH FORM -->
                <%--<form class="form-inline ml-3">--%>
                <div class="sidebar-form">
                    <div class="input-group input-group-sm" style="width: 200px !important;">
                        <input id="searchid" class="form-control form-control-navbar" type="search" placeholder="Search" aria-label="Search" onkeyup="filterMenu()" onkeydown="arrowEnterMenu(event)" />
                        <div class="input-group-append">
                            <button class="btn btn-navbar" type="submit">
                                <i class="fas fa-search"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <%--</form>--%>

                <!-- Right navbar links -->
                <ul class="navbar-nav ml-auto">
                    <!-- Messages Dropdown Menu -->
                    <%--<li class="nav-item dropdown">
                        <a class="nav-link" data-toggle="dropdown" href="#">
                            <i class="far fa-comments"></i>
                            <span class="badge badge-danger navbar-badge">3</span>
                        </a>
                        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
                            <a href="#" class="dropdown-item">
                                <!-- Message Start -->
                                <div class="media">
                                    <img src="dist/img/user1-128x128.jpg" alt="User Avatar" class="img-size-50 mr-3 img-circle">
                                    <div class="media-body">
                                        <h3 class="dropdown-item-title">Brad Diesel
                  <span class="float-right text-sm text-danger"><i class="fas fa-star"></i></span>
                                        </h3>
                                        <p class="text-sm">Call me whenever you can...</p>
                                        <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>4 Hours Ago</p>
                                    </div>
                                </div>
                                <!-- Message End -->
                            </a>
                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item">
                                <!-- Message Start -->
                                <div class="media">
                                    <img src="dist/img/user8-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3">
                                    <div class="media-body">
                                        <h3 class="dropdown-item-title">John Pierce
                  <span class="float-right text-sm text-muted"><i class="fas fa-star"></i></span>
                                        </h3>
                                        <p class="text-sm">I got your message bro</p>
                                        <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>4 Hours Ago</p>
                                    </div>
                                </div>
                                <!-- Message End -->
                            </a>
                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item">
                                <!-- Message Start -->
                                <div class="media">
                                    <img src="dist/img/user3-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3">
                                    <div class="media-body">
                                        <h3 class="dropdown-item-title">Nora Silvester
                  <span class="float-right text-sm text-warning"><i class="fas fa-star"></i></span>
                                        </h3>
                                        <p class="text-sm">The subject goes here</p>
                                        <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>4 Hours Ago</p>
                                    </div>
                                </div>
                                <!-- Message End -->
                            </a>
                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item dropdown-footer">See All Messages</a>
                        </div>
                    </li>--%>

                    <!-- Notifications Dropdown Menu -->
                    <li class="nav-item dropdown">
                        <a class="nav-link" data-toggle="dropdown" href="#">
                            <i class="fas fa-user-tie"></i>
                            <%--<span class="badge badge-warning navbar-badge">20</span>--%>
                        </a>
                        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
                            <span class="dropdown-item dropdown-header">User information</span>
                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item" onclick="Opentabmyprofile();">
                                <i class="fas fa-id-card mr-2"></i>Profile
            <%--<span class="float-right text-muted text-sm">12 hours</span>--%>
                            </a>

                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item" onclick="empcontact();">
                                <i class="fas fa-users mr-2"></i>Employee Contact
            <%--<span class="float-right text-muted text-sm">12 hours</span>--%>
                            </a>
                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item" onclick="Opentabfix();">
                                <i class="far fa-building mr-3"></i>Branch/Department
                            </a>

                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" runat="server" onserverclick="Logout_onclick"><%--onclick="RedirectPage();"--%>
                                <i class="fas fa-sign-out-alt mr-2"></i>Log out
                <%--<asp:LinkButton ID="linklogout" Text="Logout" runat="server" OnClick="Logout_onclick"></asp:LinkButton>--%>
                            </a>


                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item dropdown-footer">See All Notifications</a>
                        </div>
                    </li>

                    <%--<li class="nav-item">
                        <a class="nav-link" data-widget="control-sidebar" data-slide="true" href="#" role="button">
                            <i class="fas fa-th-large"></i>
                        </a>
                    </li>--%>
                </ul>
            </nav>
            <!-- /.navbar -->

            <!-- Main Sidebar Container -->
            <aside class="main-sidebar sidebar-dark-primary elevation-4">
                <!-- Brand Logo -->
                <a href="apptop.aspx" class="brand-link" style="background-color: #00A7A5; text-align: center;">
                    <%--<img src="Image/logo-htb_v4s.png" class="brand-image img-circle elevation-3" style="background-color:#009da5; margin-left:5px;"/>--%>
                    <span class="brand-text font-weight-light" style="color: white; font-size: 20px; font-weight: 300; font-family: Helvetica Neue ,Helvetica,Arial ,sans-serif;">Channel Banking System</span>
                </a>

                <!-- Sidebar -->
                <div class="sidebar">
                    <!-- Sidebar user panel (optional) -->
                    <div class="user-panel mt-3 pb-3 mb-3 d-flex">
                        <div class="image">
                            <asp:Image ID="image1" runat="server" CssClass="img-circle elevation-2" alt="User Image" />
                        </div>
                        <div class="info">
                            <a href="#" class="d-block">
                                <label id="L_USER" runat="server" class="proxy-content"></label>
                                <%--<p class="proxy-content"> BranchID : <label id="L_Branchid" runat="server" class="proxy-content"></label></p>--%>
                            </a>
                        </div>
                    </div>

                    <!-- Sidebar Menu -->
                    <nav class="mt-2">
                        <ul class=" sidebar-menu nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                            <!-- Add icons to the links using the .nav-icon class
               with font-awesome or any other icon font library -->

                            <li class="nav-header">Navigation</li>

                            <asp:Repeater ID="rptMenu" runat="server" EnableTheming="True" OnItemDataBound="rptMenu_OnItemBound">
                                <ItemTemplate>
                                    <li class="nav-item has-treeview">
                                        <a href="#" class="nav-link">
                                            <i class="<%#Eval("iconcode")%>" style="<%#Eval("WebListCode")%>"></i>
                                            <%--<i class="nav-icon far fa-envelope"></i>--%>

                                            <p class="menu-name">
                                                <%#Eval("funcdesc")%>
                                                <i class="fas fa-angle-left right"></i>
                                                <span class="badge badge-info right" style="background-color: #009da5;">
                                                    <asp:Label ID="l_values1" runat="server" CssClass="Margin"></asp:Label>
                                                </span>
                                            </p>

                                            <%--                                       <span class="menu-name"><%#Eval("funcdesc")%>
                                           <span class="pull-right-container">
                                                    <i class="fas fa-angle-left right"></i>
                                                      <span class="badge badge-info right" style="background-color:#009da5;">
                                                          <asp:Label ID="l_values1" runat="server" CssClass="Margin"></asp:Label>    
                                                      </span>
                                               </span>
                                         </span>--%>
                                          
                                        </a>


                                        <ul class="nav nav-treeview">
                                            <asp:Repeater ID="rptChildMenu" runat="server" EnableTheming="True">
                                                <ItemTemplate>
                                                    <li class="nav-item">
                                                        <a href="#" onclick="openTab('<%# Page.ResolveClientUrl((string)Eval("weburl")+"?Menuid="+Eval("ID"))%>');" class="nav-link">
                                                            <i class="<%#Eval("iconcode")%>" style="<%#Eval("WebListCode")%>"></i>
                                                            <p class="menu-name">
                                                                <%#Eval("funcdesc")%>
                                                                <span class="badge badge-info right" style="background-color: #f99d1c">
                                                                    <asp:Label ID="l_values2" runat="server" CssClass="Margin"></asp:Label>
                                                                </span>
                                                            </p>
                                                        </a>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </li>

                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>

                    </nav>
                    <!-- /.sidebar-menu -->
                </div>
                <!-- /.sidebar -->
            </aside>

            <!-- Content Wrapper. Contains page content -->
            <div class="content-wrapper" style="background-color: #ecf0f5">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">

                            <div class="col-md-12" style="width: 100%">
                                <div style="background-color: #ecf0f5">
                                    <%-- <iframe id="main_frame" style="border-style: none ; height:1155px;width:100% ; border:hidden" src="index.aspx">
                                    </iframe>--%>
                                    <iframe id="main_frame" scrolling="no" frameborder="0" style="width: 100%;" src="index.aspx" onload="autoResize('main_frame');"></iframe>
                                </div>
                            </div>

                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.container-fluid -->
                <!-- /.content-header -->

                <!-- Main content -->

                <!-- /.content -->

            </div>

            <!-- /.content-wrapper -->
            <footer class="main-footer">
                <strong>Copyright &copy; 2016-<label id="lblyear" runat="server"></label>
                    By Channel Banking Department.</strong>
                All rights reserved.
    <div class="float-right d-none d-sm-inline-block">
        <b>Version</b> 3.0.3
    </div>
            </footer>

            <!-- Control Sidebar -->
            <aside class="control-sidebar control-sidebar-dark">
                <!-- Control sidebar content goes here -->
            </aside>
            <!-- /.control-sidebar -->
        </div>
        <!-- ./wrapper -->

<script src="plugins/jquery/jquery.min.js"></script>

<script src="plugins/jquery-ui/jquery-ui.min.js"></script>

<script>
  $.widget.bridge('uibutton', $.ui.button)
</script>

<script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>

<script src="plugins/chart.js/Chart.min.js"></script>

<%--<script src="plugins/sparklines/sparkline.js"></script>--%>

<script src="plugins/jqvmap/jquery.vmap.min.js"></script>
<script src="plugins/jqvmap/maps/jquery.vmap.usa.js"></script>

<script src="plugins/jquery-knob/jquery.knob.min.js"></script>

<script src="plugins/moment/moment.min.js"></script>
<script src="plugins/daterangepicker/daterangepicker.js"></script>

<script src="plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>

<script src="plugins/summernote/summernote-bs4.min.js"></script>

<script src="plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>

<script src="dist/js/adminlte.js?v=3.2.0"></script>

<%--<script src="dist/js/demo.js"></script>--%>

<script src="dist/js/pages/dashboard.js"></script>
        
<script>
        $(document).ready(function() {
            $('#sparkline-element').sparkline([1, 2, 3, 4, 5], {
                type: 'line'
            });
        });
    </script>

        <script type="text/javascript">
            //window.onload = window.onresize = function ResizeIFrame() {
            //var iframe = document.getElementById("main_frame");
            //var bHeight = iframe.contentWindow.document.body.scrollHeight;
            //var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;


            //var bWidth = iframe.contentWindow.document.body.scrollWidth;
            //var dWidth = iframe.contentWindow.document.documentElement.scrollWidth;


            //var height = Math.max(bHeight, dHeight);
            //var width = Math.max(dWidth, bWidth);
            //iframe.height = height;
            //iframe.width = width;
            //};

            function autoResize(id) {
                var newheight;
                var newwidth;

                if (document.getElementById) {
                    newheight = document.getElementById(id).contentWindow.document.body.scrollHeight;
                    newwidth = document.getElementById(id).contentWindow.document.body.scrollWidth;
                }

                document.getElementById(id).height = (newheight) + "px";
                document.getElementById(id).width = (newwidth) + "px";
            };
        </script>



        <script type="text/javascript">
            $(function () {

                const url = localStorage.getItem("url");
                if (url) openTab(url);
            });

            function getcookie() {

                var allcookie = document.cookie;
                if (allcookie == null) {
                    window.location.href = "Default.aspx";
                    return;
                }

            }

            function openTab(url) {
                //document.querySelector(".loadingstart").style.display = "None";
                //document.querySelector(".loading").style.display = "block";

                console.log(url);
                var iframe = document.getElementById("main_frame");
                iframe.src = url;
                console.log(iframe);


                localStorage.setItem("url", url);
                //setTimeout(() => {
                //    document.querySelector(".loading").style.display = "none";
                //    document.querySelector(".loadingstart").style.display = "block";
                //}, 10000);
            }

            function Opentabfix() {
                //document.querySelector(".loadingstart").style.display = "None";
                //document.querySelector(".loading").style.display = "block";

                var iframe = document.getElementById("main_frame");
                iframe.src = "Contact/contact.aspx";
                console.log(iframe);
                //setTimeout(() => {
                //    document.querySelector(".loading").style.display = "none";
                //    document.querySelector(".loadingstart").style.display = "block";
                //}, 10000);
            }
            function empcontact() {
                //document.querySelector(".loadingstart").style.display = "None";
                //document.querySelector(".loading").style.display = "block";

                var iframe = document.getElementById("main_frame");
                iframe.src = "Contact/Employeecontact.aspx";
                //console.log(iframe);
                //setTimeout(() => {
                //    document.querySelector(".loading").style.display = "none";
                //    document.querySelector(".loadingstart").style.display = "block";
                //}, 10000);
            }

            function Opentabmyprofile() {
                //document.querySelector(".loadingstart").style.display = "None";
                //document.querySelector(".loading").style.display = "block";

                var iframe = document.getElementById("main_frame");
                iframe.src = "Username/myprofile.aspx";
                console.log(iframe);
                //setTimeout(() => {
                //    document.querySelector(".loading").style.display = "none";
                //    document.querySelector(".loadingstart").style.display = "block";
                //}, 10000);
            }
            function afterclick(obj) {
                $("#progressbar").progressbar({
                    value: obj
                });
            }
            function RedirectPage() {
                var url = 'Default.aspx';
                window.location.href = url;

            }
        </script>

        <script type="text/javascript">  
            var message = "Function Disabled!";
            function clickIE4() {
                if (event.button == 2) {
                    alert(message);
                    return false;
                }
            }
            function clickNS4(e) {
                if (document.layers || document.getElementById && !document.all) {
                    if (e.which == 2 || e.which == 3) {
                        alert(message);
                        return false;
                    }
                }
            }
            if (document.layers) {
                document.captureEvents(Event.MOUSEDOWN);
                document.onmousedown = clickNS4;
            }
            else if (document.all && !document.getElementById) {
                document.onmousedown = clickIE4;
            }
            document.oncontextmenu = new Function("return false")
        </script>
    </form>
</body>
</html>
