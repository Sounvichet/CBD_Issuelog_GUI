<%@ Page Language="C#" AutoEventWireup="true" CodeFile="apptop_old.aspx.cs" Inherits="apptop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issuelog System</title> 
    <link  rel="shortcut icon" href="<%= Page.ResolveUrl ("~/Icon/ATM1.png") %>" type="image/x-icon" />
    <link  rel="icon" href="<%= Page.ResolveUrl ("~/Icon/ATM1.png") %>" type="image/ico" />
    <!-- Bootstrap 3.3.7 -->
     <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <!-- Font Awesome -->
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <!-- Ionicons -->
     <link href="<%= Page.ResolveUrl ("~/CSS/ionicons.min.css") %>" rel="stylesheet" type="text/css" />
    <!-- jvectormap -->
     <link href="<%= Page.ResolveUrl ("~/CSS/jquery-jvectormap.css") %>" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
     <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />

   <link href="<%= Page.ResolveUrl ("~/CSS/calendar-blue.css")%>" rel="stylesheet" type="text/css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
    folder instead of downloading all of them to reduce the load. -->

    <link href="<%= Page.ResolveUrl ("~/CSS/_all-skins.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/Font_style.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/CSS01.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/portal.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/portal.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <style type="text/css">
        textarea
        {
            resize: none;
        }
        .proxy-content {
            font-family: 'Khmer Nettra' !important;
            font-size: 13px;
        }
    </style>    
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <form id="formmain" action ="#" runat="server">
       
       <div class="wrapper">
            <header class="main-header">
    <!-- Logo -->
    <a href="<%= Page.ResolveClientUrl ("~/apptop.aspx") %>" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b>I</b>Log</span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg"><img src="Image/HKL_Logo_JPG1.png" style="width:70px;height:50px" /><b>Issue</b>Log</span>
    </a>


    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
        <span class="sr-only">Toggle navigation</span>
      </a>
        
      <!-- Navbar Right Menu -->
      <div class="navbar-custom-menu" >
        <ul class="nav navbar-nav">
          <!-- Messages: style can be found in dropdown.less-->
          <!-- Notifications: style can be found in dropdown.less -->
          <!-- Tasks: style can be found in dropdown.less -->
          <!-- User Account: style can be found in dropdown.less -->
            <li class="dropdown user user-menu">

              <a>
                  <div class="loadingstart" style="display: block;" align ="center">
                       <img src="Gif/ajax-loader6-stop.gif" />
                      </div>
                   <div class="loading" style="display: none;" align ="center">
                                      <img src="Gif/ajax-loader6.gif" />
                                  </div>
              </a>

                             
            </li>
          <li class="dropdown user user-menu">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <asp:Image ID="Image2" CssClass="user-image" runat="server"></asp:Image>
              <span class="hidden-xs"><asp:Label ID="Label1" runat="server" CssClass="proxy-content" ></asp:Label></span>
                
            </a>
            <ul class="dropdown-menu">
              <!-- User image -->
              <li class="user-header">
                <asp:Image  ID="Image1" runat="server" class="img-rounded" alt="User Image"></asp:Image>

                <p>
                  <asp:Label ID="Label2" runat="server" CssClass="proxy-content" ></asp:Label>
                  <small><asp:Label ID="Label3" runat="server"></asp:Label></small>
                </p>
              </li>
              <!-- Menu Body -->
              <li class="user-body">
                <div class="row">
                  <div class="col-xs-4 text-center">
                    <a href="#" onclick ="Opentabfix();">Contact</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href="#" onclick="empcontact();">Employee_Contact</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <%--<a href="<%= Page.ResolveUrl ("~/Username/changeimage.aspx")%>">Image</a>--%>
                  </div>
                </div>
                <!-- /.row -->
              </li>
              <!-- Menu Footer-->
              <li class="user-footer">
                <div class="pull-left">
                  <a href="#" onclick="Opentabmyprofile();" class="btn btn-default btn-flat" ><i class="fa fa-book fa-lg" aria-hidden="true"></i> Profile</a>
                </div>
                <div class="pull-right">
              <button runat="server" class="btn btn-default btn-flat" onServerClick="sign_out_Click" >
                  <i class="fa  fa-sign-out fa-lg" aria-hidden="true"></i> Sign out</button>
                </div>
              </li>
            </ul>
          </li>
          <!-- Control Sidebar Toggle Button -->
          <li>
            <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
          </li>
        </ul>
      </div>

        
    </nav>
  </header>
           
        <aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
      <!-- Sidebar user panel -->
      <div class="user-panel">
        <div class="pull-left image">
          <%--<img src="image/vichet.jpg" class="img-circle" alt="User Image">--%>
                <asp:Image  ID="Image3" runat="server" class="img-circle" alt="User Image"></asp:Image>
        </div>
        <div class="pull-left info">
          <p><asp:Label ID="Label4" runat="server" Text="Label" CssClass="proxy-content"></asp:Label></p>
          <a href="#"><i class="fa fa-circle text-success"></i>Online</a>
        </div>
      </div>
      <!-- search form -->
     
      <!-- /.search form -->
      <!-- sidebar menu: : style can be found in sidebar.less -->


         <div class="sidebar-form">
                                        <div class="input-group custom-search-form">
                                           <input type="text" id ="searchid" class="form-control" placeholder="Search..."
                                               onkeyup ="filterMenu()" onkeydown ="arrowEnterMenu(event)"/>
                                                <span class="input-group-btn">
                                                    <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                                                        <i class="fa fa-search"></i>
                                                    </button>
                                               </span>
                                    </div>
                                    <!-- /input-group -->
                                </div>


      <ul class="sidebar-menu" data-widget="tree">

        <li class="header">NAVIGATION</li> 

            <asp:Repeater ID="rptMenu" runat="server" EnableTheming="True" OnItemDataBound ="rptMenu_OnItemBound" >  <%--OnItemDataBound ="rptMenu_OnItemBound" OnPreRender="repeater1_PreRender" --%>
                        <ItemTemplate>
                            <%-- <asp:Label ID="lblcatid" runat="server" Text='<%# Eval("FuncType") %>' Visible="true" ForeColor="White"></asp:Label>    --%>
                            <li class="treeview">
                             <a href="#">
                                <i class="<%#Eval("iconcode")%>"></i>
                                    <span class="menu-name"><%#Eval("funcdesc")%> 
                                        <span class="pull-right-container">
                                             <small class="label pull-right bg-red">
                                                <%--<asp:Label ID="LabelID" runat="server"   Text='<%# Eval("NumChild") %>'></asp:Label> <%--Text='<%# Eval("Count_submenu") %>'--%>
                                                <asp:Label id ="Label2" runat="server" ></asp:Label> <%--Text='<%# Eval("Count_submenu") %>'--%>
                                            </small> 
                                            </span>
                                        </span>
                                    
                                </a>
                  <ul class="treeview-menu">
                      
                      <asp:Repeater ID="rptChildMenu" runat="server" EnableTheming="True" >  <%--OnItemDataBound ="rptChildMenu_OnItemBound"--%>
                          <ItemTemplate>
                                 <li>
                                <a href="#" onclick="openTab('<%# Page.ResolveClientUrl((string)Eval("weburl")+"?Menuid="+Eval("ID"))%> ');"> 
                                    <i class="<%#Eval("iconcode")%>"></i>
                                    <span class="menu-name"> <%#Eval("funcdesc")%></span>
                                    
                                     <span class="pull-right-container">
                                         <small class="label pull-right bg-blue">
                                         <%--<asp:Label ID="SubLabelCount" runat="server" Text='<%#Eval("NumChild")%>'></asp:Label>--%>
                                         <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                         </small>
                                         </span>
                                </a>
                                    <%-- ---Three Submenu--%>
                                    
                                 </li>
                         </ItemTemplate>
                      </asp:Repeater>

                  </ul>
                </li>
            </ItemTemplate>
       </asp:Repeater>              
      </ul>
    </section>
    <!-- /.sidebar -->
             
         </aside>
                    


                        <!-- Content Wrapper. Contains page content --> 
                          <div class="content-wrapper" >
                              
                            <!-- Content Header (Page header) -->
                            <!-- Main content -->
                                 <%-- <section class="content">
                                          <div class="row">
                                                        <div class="col-md-12">
                                                                <div class="box box-primary">
                                                                       <div class="box-body box-profile">
                                                                       <div class="row">--%>
                          
                                                                      <div class="row">
                                                                            <div class="col-md-12" >
                                                                                  <div style="background-color:#ecf0f5" >
                                                                                       <iframe id="main_frame" style="border-style: none ; height:1155px;width:100% ; border:hidden" src="index.aspx">
                                      
                                                                                            </iframe>
                                                                                  </div>
                                                                            </div>
                                                                      </div>
                            
                                                                                               
                                                                          <%--       </div>
                                                                     </div>
                                                                   </div>
                                                                        
                                                               </div>
                                                        </div>
                                          </div>
                             </section>--%>
                        </div>
     <footer class="main-footer">
        <div class="pull-right hidden-xs">
          <b>Version</b> 2.0.0
        </div>
        <strong>Copyright &copy; By Channel Banking 2016-2020.</strong> All rights reserved.
     </footer>   

<aside class="control-sidebar control-sidebar-dark">
    <!-- Create the tabs -->
    <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
      <li><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>
      <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
      <!-- Home tab content -->
      <div class="tab-pane" id="control-sidebar-home-tab">
        <h3 class="control-sidebar-heading">Recent Activity</h3>
        <ul class="control-sidebar-menu">
          <li>
            <a href="javascript:void(0)">
              <i class="menu-icon fa fa-birthday-cake bg-red"></i>

              <div class="menu-info">
                <h4 class="control-sidebar-subheading">Langdon's Birthday</h4>

                <p>Will be 23 on April 24th</p>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <i class="menu-icon fa fa-user bg-yellow"></i>

              <div class="menu-info">
                <h4 class="control-sidebar-subheading">Frodo Updated His Profile</h4>
                <p>New phone +1(800)555-1234</p>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <i class="menu-icon fa fa-envelope-o bg-light-blue"></i>

              <div class="menu-info">
                <h4 class="control-sidebar-subheading">Nora Joined Mailing List</h4>

                <p>nora@example.com</p>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <i class="menu-icon fa fa-file-code-o bg-green"></i>

              <div class="menu-info">
                <h4 class="control-sidebar-subheading">Cron Job 254 Executed</h4>

                <p>Execution time 5 seconds</p>
              </div>
            </a>
          </li>
        </ul>
        <!-- /.control-sidebar-menu -->

        <h3 class="control-sidebar-heading">Tasks Progress</h3>
        <ul class="control-sidebar-menu">
          <li>
            <a href="javascript:void(0)">
              <h4 class="control-sidebar-subheading">
                Custom Template Design
                <span class="label label-danger pull-right">70%</span>
              </h4>

              <div class="progress progress-xxs">
                <div class="progress-bar progress-bar-danger" style="width: 70%"></div>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <h4 class="control-sidebar-subheading">
                Update Resume
                <span class="label label-success pull-right">95%</span>
              </h4>

              <div class="progress progress-xxs">
                <div class="progress-bar progress-bar-success" style="width: 95%"></div>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <h4 class="control-sidebar-subheading">
                Laravel Integration
                <span class="label label-warning pull-right">50%</span>
              </h4>

              <div class="progress progress-xxs">
                <div class="progress-bar progress-bar-warning" style="width: 50%"></div>
              </div>
            </a>
          </li>
          <li>
            <a href="javascript:void(0)">
              <h4 class="control-sidebar-subheading">
                Back End Framework
                <span class="label label-primary pull-right">68%</span>
              </h4>

              <div class="progress progress-xxs">
                <div class="progress-bar progress-bar-primary" style="width: 68%"></div>
              </div>
            </a>
          </li>
        </ul>
        <!-- /.control-sidebar-menu -->

      </div>
      <!-- /.tab-pane -->

      <!-- Settings tab content -->
      <div class="tab-pane" id="control-sidebar-settings-tab">
        <form method="post">
            
          <h3 class="control-sidebar-heading">General Settings</h3>

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Report panel usage
              <input type="checkbox" class="pull-right" checked>
            </label>

            <p>
              Some information about this general settings option
            </p>
          </div>
          <!-- /.form-group -->

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Allow mail redirect
              <input type="checkbox" class="pull-right" checked>
            </label>

            <p>
              Other sets of options are available
            </p>
          </div>
          <!-- /.form-group -->

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Expose author name in posts
              <input type="checkbox" class="pull-right" checked>
            </label>

            <p>
              Allow the user to show his name in blog posts
            </p>
          </div>
          <!-- /.form-group -->

          <h3 class="control-sidebar-heading">Chat Settings</h3>

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Show me as online
              <input type="checkbox" class="pull-right" checked>
            </label>
          </div>
          <!-- /.form-group -->

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Turn off notifications
              <input type="checkbox" class="pull-right">
            </label>
          </div>
          <!-- /.form-group -->

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Delete chat history
              <a href="javascript:void(0)" class="text-red pull-right"><i class="fa fa-trash-o"></i></a>
            </label>
          </div>
          <!-- /.form-group -->
        </form>
        
      </div>
      <!-- /.tab-pane -->
    </div>
  </aside>
  
 <div class="control-sidebar-bg"></div>
           
           <div class="row">
                            <div class="col-md-12" >

                                <%--<button type="button" id="open_iframe" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg" onclick="javascript:OpenPage();">Large modal</button>--%>

                                <div class="modal fade bd-example-modal-lg" id="iframe-apptop" 
                                        tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" >
                                    <div class="modal-dialog modal-lg">
                                    <div class="modal-content w-100">
                                                                  
                                            <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <h4 class="modal-title">CSS Settlement</h4>
                                            </div>

                                        <div class="modal-body">
                                             <div id="partialViewContent">
                                                    <button id="btn_print_proxy" style="margin-bottom: 10px;" class="btn btn-default" onclick="OpenPage();">
                                                    <i class="fa fa-print"></i> Print</button>
                                                    <button type="button" class="btn btn-default" style="margin-bottom: 10px;" data-dismiss="modal">
                                                        <i class="fa fa-times"></i>Close</button>
                                                    <iframe id="frm2" runat="server" style="width:100%; height:1155px" > 
                                                    </iframe>
                                            </div>
                                            
                                        </div>

                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                    </div>


 </div>
        
  </form>

     <script type="text/javascript">
        
         function openTab(url) {  
             document.querySelector(".loadingstart").style.display = "None";
             document.querySelector(".loading").style.display = "block";
             
             console.log(url);
             var iframe = document.getElementById("main_frame");
             iframe.src = url;
             console.log(iframe);
             setTimeout(() => {
                 document.querySelector(".loading").style.display = "none"; 
                 document.querySelector(".loadingstart").style.display = "block";
             }, 10000);
         }

         function Opentabfix()
         {
             document.querySelector(".loadingstart").style.display = "None";
             document.querySelector(".loading").style.display = "block";

             var iframe = document.getElementById("main_frame");
             iframe.src = "Contact/contact.aspx";
             console.log(iframe);
             setTimeout(() => {
                 document.querySelector(".loading").style.display = "none";
                 document.querySelector(".loadingstart").style.display = "block";
             }, 10000);
         }
         function empcontact() {
             document.querySelector(".loadingstart").style.display = "None";
             document.querySelector(".loading").style.display = "block";

             var iframe = document.getElementById("main_frame");
             iframe.src = "Contact/Employeecontact.aspx";
             //console.log(iframe);
             setTimeout(() => {
                 document.querySelector(".loading").style.display = "none";
                 document.querySelector(".loadingstart").style.display = "block";
             }, 10000);
         }

         function Opentabmyprofile() {
             document.querySelector(".loadingstart").style.display = "None";
             document.querySelector(".loading").style.display = "block";

             var iframe = document.getElementById("main_frame");
             iframe.src = "Username/myprofile.aspx";
             console.log(iframe);
             setTimeout(() => {
                 document.querySelector(".loading").style.display = "none";
                 document.querySelector(".loadingstart").style.display = "block";
             }, 10000);
         }
         function afterclick(obj)
         {
             $("#progressbar").progressbar({
                 value: obj
             });
         }
         function RedirectPage() {
             var url = 'index.aspx';
             window.location.href = url;
         }
     </script>

    

    <script src="<%= Page.ResolveUrl ("~/js/jquery.dynDateTime.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/js/calendar-en.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/jquery.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/fastclick.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/adminlte.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/jquery.sparkline.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/jquery-jvectormap-1.2.2.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/jquery-jvectormap-world-mill-en.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/jquery.slimscroll.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/Chart.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/controlsidebar.js")%>"></script>
</body>
</html>
