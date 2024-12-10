<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PERMISSION.aspx.cs" Inherits="ROLES_PERMISSION" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


      <!-- Ionicons -->
<link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <%--<link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>--%>
  <!-- Tempusdominus Bbootstrap 4 -->
  <%--<link rel="stylesheet" href="../plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css"/>--%>
  <!-- iCheck -->
  <%--<link rel="stylesheet" href="../plugins/icheck-bootstrap/icheck-bootstrap.min.css"/>--%>
  <!-- JQVMap -->
  <%--<link rel="stylesheet" href="../plugins/jqvmap/jqvmap.min.css"/>--%>
  <!-- Theme style -->
  <link rel="stylesheet" href="../dist/css/adminlte.min.css"/>
    <!-- SweetAlert2 -->
  <link rel="stylesheet" href="../../plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css">
  <!-- Google Font: Source Sans Pro -->
  <%--<link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet"/>--%>
      <%--<link href="<%= Page.ResolveUrl ("~/CSS/ionicons.min.css")%>" rel="stylesheet" type="text/css" />--%>
  <!-- Theme style -->
    <link href="../plugins/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <%--<link href="<%= Page.ResolveUrl ("~/dist/css/adminlte.min.css")%>" rel="stylesheet" type="text/css" />--%>
  <!-- Google Font: Source Sans Pro -->
    <%--<link href="<%= Page.ResolveUrl ("~/CSS/google-Font.css")%>" rel="stylesheet" type="text/css" />--%>
  <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>

  
    
      <style>
    .color-palette {
      height: 35px;
      line-height: 35px;
      text-align: right;
      padding-right: .75rem;
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
    .user-control
         {
         padding-top:5px;
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
         .button_bg {
        background-color:#009da5;
        }
  </style>
    
     <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>

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

         <%--<script type="text/javascript">
            jQuery(function ($) {{
                    $("#<%=txtS_date.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    changeMonth: true,
                    changeYear: true,
                    showWeek: true,
                    gotoCurrent: true,
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#Start_date').mask('99-aaa-9999');

                $("#<%=txtE_date.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    changeMonth: true,
                    changeYear: true,
                    showWeek: true,
                    gotoCurrent: true,
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#Start_date').mask('99-aaa-9999');

            }
            });
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div style ="width:95%">
                  <div class="row ">
                    <div class="col-md-6">
                         <asp:LinkButton ID="linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="linkbtnsave_Click" ><i class="fa fa-save" style="color:white" aria-hidden="true"></i> Save</asp:LinkButton>
                         <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Linkbtncancel_Click"><i class="fas fa-caret-left" style="color:white" aria-hidden="true" ></i> Cancel</asp:LinkButton>                   
                    </div>
                </div>

                  <div class="row user-control">
                            <div class="col-md-12">
                                <div id="alert_container"> </div>
                                </div>
                   </div>

                  <div class="row user-control">
                    <div class="col-md-3">
                        GROUPID<strong style="color:red">*</strong>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtgroupid" runat="server" CssClass="textboxstyle" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        Name
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtgroupname" runat="server" CssClass="textboxstyle" Enabled="false"></asp:TextBox>
                    </div>
                </div>
        
                  <div class="row user-control">
                      <div class="col-xs-6 col-md-4">
                         <nav class="mt-2">
                            <ul class=" sidebar-menu nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                              
                              <li class="nav-header">Navigation</li>

                                <asp:Repeater ID="rptMenu" runat="server" EnableTheming="True" OnItemDataBound ="rptMenu_ItemDataBound" >
                                        <ItemTemplate>
                                            <li class="nav-item has-treeview">
                                                        <a href="#" class="nav-link">
                                                            <i class="<%#Eval("iconcode")%>"></i>
                                                              <%--<i class="nav-icon far fa-envelope"></i>--%>
                                          
                                                             <p>
                                                                <%#Eval("funcdesc")%>
                                                                <i class="fas fa-angle-left right"></i>
                                                                  <span class="badge badge-info right" style="background-color:#009da5;">
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
                                                         <asp:Repeater ID="rptChildMenu" runat="server" EnableTheming="True" >  
                                                                  <ItemTemplate>
                                                                    <li class="nav-item">
                                                                        <a href="#" onclick="openTab('<%# Page.ResolveClientUrl((string)Eval("weburl")+"?Menuid="+Eval("ID"))%>');" class="nav-link"> 
                                                                          <i class="<%#Eval("iconcode")%>"></i>
                                                                            <p>
                                                                                <%#Eval("funcdesc")%>
                                                                                  <span class="badge badge-info right" style="background-color:#f99d1c">
                                                                                      <asp:Label ID="l_values2" runat ="server" CssClass="Margin"></asp:Label>
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

                      </div>

                      <div  class="col-xs-10 col-md-7">
                          <div class="table-responsive" style="height:800px">
                              <asp:GridView ID="gridpermission"  CssClass="table-bordered table-hover"    runat="server"  AutoGenerateColumns="false" GridLines="None" RowStyle-Wrap="false" OnDataBound="gridpermission_DataBound" >
                                  
                                  <Columns>  
                                        <asp:BoundField DataField="RightType" HeaderText="RightType" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="RightType" />
                                       <asp:BoundField DataField="RName" HeaderText="RName" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="RName" />
                                       <asp:BoundField DataField="rightid" HeaderText="rightid" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="rightid" />
                                       <%--<asp:BoundField DataField="AllowView" HeaderText="AllowView" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="AllowView" />
                                       <asp:BoundField DataField="allowEdit" HeaderText="allowEdit" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="allowEdit" />
                                       <asp:BoundField DataField="AllowNew" HeaderText="AllowNew" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="AllowNew" />
                                       <asp:BoundField DataField="AllowExec" HeaderText="AllowExec" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="AllowExec" />
                                       <asp:BoundField DataField="AllowEnquiry" HeaderText="AllowEnquiry" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="AllowEnquiry" />
                                       <asp:BoundField DataField="Allowimport" HeaderText="Allowimport" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="Allowimport" />
                                       <asp:BoundField DataField="AllowExport" HeaderText="AllowExport" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="AllowExport" />
                                       <asp:BoundField DataField="AllowReport" HeaderText="AllowReport" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="AllowReport" />
                                       <asp:BoundField DataField="AllowAuthorize" HeaderText="AllowAuthorize" 
                                            InsertVisible="False" ReadOnly="True" SortExpression="AllowAuthorize" />--%>
                            <asp:TemplateField>  
                                <HeaderTemplate>  
                                    View
                                </HeaderTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="chkview" runat="server"  Checked='<%# Eval("View").ToString().Equals("1") %>'/>  <%--Enabled='<%# !Eval("AllowView").ToString().Equals("1") %>'--%>  
                                </ItemTemplate>  
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter" />
                            </asp:TemplateField>  
                            
                              <asp:TemplateField>  
                                <HeaderTemplate>  
                                    NEW
                                </HeaderTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="chknew" runat="server"  Checked='<%# Eval("NEW").ToString().Equals("1") %>'/>  <%--Enabled='<%# !Eval("AllowView").ToString().Equals("1") %>'--%>  
                                </ItemTemplate>  
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter" />
                            </asp:TemplateField>  


                             <asp:TemplateField>  
                                <HeaderTemplate>  
                                    Edit
                                </HeaderTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="chkedit" runat="server"  Checked='<%# Eval("Edit").ToString().Equals("1") %>'/>  <%--Enabled='<%# !Eval("AllowView").ToString().Equals("1") %>'--%>  
                                </ItemTemplate>  
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter" />
                            </asp:TemplateField>  


                               <asp:TemplateField>  
                                <HeaderTemplate>  
                                    Delete
                                </HeaderTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="chkdelete" runat="server"  Checked='<%# Eval("Delete").ToString().Equals("1") %>'/>  <%--Enabled='<%# !Eval("AllowView").ToString().Equals("1") %>'--%>  
                                </ItemTemplate>  
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter" />
                            </asp:TemplateField>  

                             <asp:TemplateField>  
                                <HeaderTemplate>  
                                    Execute
                                </HeaderTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="chkexec" runat="server"  Checked='<%# Eval("Execute").ToString().Equals("1") %>'/>  <%--Enabled='<%# !Eval("AllowView").ToString().Equals("1") %>'--%>  
                                </ItemTemplate>  
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter" />
                            </asp:TemplateField>  

                            <asp:TemplateField>  
                                <HeaderTemplate>  
                                    import
                                </HeaderTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="chkimport" runat="server"  Checked='<%# Eval("import").ToString().Equals("1") %>'/>  <%--Enabled='<%# !Eval("AllowView").ToString().Equals("1") %>'--%>  
                                </ItemTemplate>  
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter" />
                            </asp:TemplateField>  

                             <asp:TemplateField>  
                                <HeaderTemplate>  
                                    Export
                                </HeaderTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="chkexport" runat="server"  Checked='<%# Eval("Export").ToString().Equals("1") %>'/>  <%--Enabled='<%# !Eval("AllowView").ToString().Equals("1") %>'--%>  
                                </ItemTemplate>  
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter" />
                            </asp:TemplateField>  

                                        <asp:TemplateField>  
                                <HeaderTemplate>  
                                    Report
                                </HeaderTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="chkreport" runat="server"  Checked='<%# Eval("Report").ToString().Equals("1") %>'/>  <%--Enabled='<%# !Eval("AllowView").ToString().Equals("1") %>'--%>  
                                </ItemTemplate>  
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter" />
                            </asp:TemplateField>  

                                        <asp:TemplateField>  
                                <HeaderTemplate>  
                                    Authorize
                                </HeaderTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="chkauth" runat="server"  Checked='<%# Eval("Authorize").ToString().Equals("1") %>'/>  <%--Enabled='<%# !Eval("AllowView").ToString().Equals("1") %>'--%>  
                                </ItemTemplate>  
                                <ItemStyle CssClass="gvItemCenter" />
                                <HeaderStyle CssClass="gvHeaderCenter" />
                            </asp:TemplateField>  
                        </Columns>  
                                  
                                  <%-- <AlternatingRowStyle BackColor="White" />--%>
                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />

<RowStyle Wrap="False"></RowStyle>
                        </asp:GridView>
                          </div>
                      </div>

                  </div>

           </div> 
        
    </form>
<script src="plugins/jquery/jquery.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="plugins/jquery-ui/jquery-ui.min.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script>
  $.widget.bridge('uibutton', $.ui.button)
</script>
<!-- Bootstrap 4 -->
<script src="../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- ChartJS -->
<script src="../plugins/chart.js/Chart.min.js"></script>
<!-- Sparkline -->
<script src="../plugins/sparklines/sparkline.js"></script>
<!-- JQVMap -->
<script src="../plugins/jqvmap/jquery.vmap.min.js"></script>
<script src="../plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
<!-- jQuery Knob Chart -->
<script src="../plugins/jquery-knob/jquery.knob.min.js"></script>
<!-- daterangepicker -->
<script src="../plugins/moment/moment.min.js"></script>
<script src="../plugins/daterangepicker/daterangepicker.js"></script>
<!-- Tempusdominus Bootstrap 4 -->
<script src="../plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
<!-- Summernote -->
<script src="../plugins/summernote/summernote-bs4.min.js"></script>
<!-- overlayScrollbars -->
<script src="../plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
<!-- AdminLTE App -->
<script src="../dist/js/adminlte.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="../dist/js/pages/dashboard.js"></script>
</body>
</html>
