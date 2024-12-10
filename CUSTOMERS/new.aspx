
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new.aspx.cs" Inherits="CUSTOMERS_new" %>
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
        <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
        <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
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
  </style>
    
     <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>

    <%--<script type="text/javascript">
        jQuery(function ($) {
            //Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(setUpScript);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setUpScript);
            function setUpScript() {

                $("#<%=txtdob.ClientID %>").datepicker({
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
        <script type="text/javascript">
            jQuery(function ($) {{
                    $("#<%=txtdob.ClientID %>").datepicker({
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
    </script>

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
                $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:blue">' + message + '</span></div>');

                setTimeout(function () {
                    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                        $("#alert_div").remove();
                    });
                }, 5000);//5000=5 seconds
            };


    </script>
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
    <section class="content">
      <div class="container-fluid">
        <!-- COLOR PALETTE -->
        <div class="card card-default color-palette-box">
          <div class="card-header">
            <h3 class="card-title" style="font-size:large">
              <i class="fas fa-users"></i>
              CUSTOMER REGISTRATION
            </h3>
          </div>
          <%--  <asp:ScriptManager ID="SMCUSNEW" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="UpdateCUSNEW" UpdateMode="Conditional" runat="server">
                      <ContentTemplate>--%>
            <div class="card-body">
                <div class="row user-control">
                    <div class="col-md-6">
                         <asp:LinkButton ID="linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnsave_Click" ><i class="fa fa-save" style="color:white" aria-hidden="true"></i> Save</asp:LinkButton>
                         <asp:LinkButton ID="Linkbtnrefresh" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnrefresh_Click"><i class="fas fa-sync-alt" style="color:white" aria-hidden="true" ></i> Refresh</asp:LinkButton>  
                         <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtncancel_Click"><i class="fas fa-caret-left" style="color:white" aria-hidden="true" ></i> Cancel</asp:LinkButton>                   
                    </div>
                </div>

                  <div class="row user-control">
                    <div class="col-md-12">
                        <div  id="alert_container">                                   
                    </div>
                </div>
             </div>

                <div class="row user-control">
          <div class="col-12">
            <!-- Custom Tabs -->
            <div class="card">
              <div class="card-header d-flex p-0">
                <h3 class="card-title p-3"></h3>
                <ul class="nav nav-pills ml-auto p-2">
                  <li class="nav-item"><a class="nav-link active" href="#tab_1" data-toggle="tab">CUSTOMER INFO</a></li>
                  <li class="nav-item"><a class="nav-link" href="#tab_2" data-toggle="tab">ADDRESS INFO</a></li>
                  <%--<li class="nav-item"><a class="nav-link" href="#tab_3" data-toggle="tab">Create by</a></li>--%>
                  <%--<li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#">
                      Dropdown <span class="caret"></span>
                    </a>
                    <div class="dropdown-menu">
                      <a class="dropdown-item" tabindex="-1" href="#">Action</a>
                      <a class="dropdown-item" tabindex="-1" href="#">Another action</a>
                      <a class="dropdown-item" tabindex="-1" href="#">Something else here</a>
                      <div class="dropdown-divider"></div>
                      <a class="dropdown-item" tabindex="-1" href="#">Separated link</a>
                    </div>
                  </li>--%>
                </ul>
              </div><!-- /.card-header -->
              <div class="card-body">
                <div class="tab-content">
                  <div class="tab-pane active" id="tab_1">
                      <div class="row">
                          <div class="col-md-3">First Name</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtfname" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                          <div class="col-md-3">Last Name</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtlname" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                      </div>

                      <div class="row user-control">
                          <div class="col-md-3">Name Khmer</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtkhname" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                          <div class="col-md-3">DOB</div>
                      <div class="col-md-3">
                          <asp:TextBox ID="txtdob" runat="server" CssClass="textboxstyle"></asp:TextBox>
                      </div>
                      </div>

                      <div class="row user-control">
                          <div class="col-md-3">Phone number
                          <strong style="color:red">*</strong>
                          </div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtphone" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                          <div class="col-md-3">Email</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtemail" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                      </div>

                      <div class="row user-control">
                                  <div class="col-md-3">Create by</div>
                                      <div class="col-md-3">
                                      <asp:TextBox ID="txtcreateby" runat="server" CssClass="textboxstyle" Enabled="false"></asp:TextBox>    
                                      </div>

                                <div class="col-md-3">
                                    Customer Photo <strong style="color:red">*</strong>
                                </div>

                                <div class="col-md-3">
                                      <asp:FileUpload ID="filcusUpload" runat="server" ToolTip="Select Only image File" />

                              </div>
                              </div>

                           <div class="row user-control">
                                <div class="col-md-3">
                                    PRODUCT
                                </div>
                               <div class="col-md-3">
                                   <asp:DropDownList ID= "D_PRODUCT" runat="server" CssClass="textboxstyle" > </asp:DropDownList>
                                </div>
                               <div class="col-md-3">
                                   SERVICEPACKAGE
                               </div>
                               <div class="col-md-3">
                                   <asp:DropDownList ID= "D_SERCPKG" runat="server" CssClass="textboxstyle" Width="80%"  > </asp:DropDownList>
                               </div>
                           </div>

                      <div class="row user-control">
                          <div class="col-md-3">
                              PRICE
                          </div>
                          
                          <div class="col-md-3">
                              <asp:Label ID="lblPrice" runat="server" ForeColor="Blue"></asp:Label>
                          </div>
                      </div>
                   
                  </div>
                  <!-- /.tab-pane -->
                  <div class="tab-pane" id="tab_2">
                      <div class="row">
                          <div class="col-md-3">House(ផ្ទះលេខ)</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txthouse" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                          <div class="col-md-3">Street(ផ្លូវ)</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtstreet" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                      </div>

                      <div class="row user-control">
                          <div class="col-md-3">Village(ភូមិ)</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtvillage" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                          <div class="col-md-3">Commune(ឃុំសង្កាត់)</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtcommune" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                      </div>


                      <div class="row user-control">
                          <div class="col-md-3">District(ស្រុក)</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtDistrict" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                          <div class="col-md-3">Province(ខេត្ត)</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtProvince" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                      </div>

                      <div class="row user-control">
                          <div class="col-md-3">Country(ប្រទេស)</div>
                      <div class="col-md-3">
                      <asp:TextBox ID="txtCountry" runat="server" CssClass="textboxstyle"></asp:TextBox>    
                      </div>
                      </div>


                  
                  </div>
                  <!-- /.tab-pane -->
                </div>
                <!-- /.tab-content -->
              </div><!-- /.card-body -->
            </div>
            <!-- ./card -->
          </div>
          <!-- /.col -->
        </div>
            </div>
            </div>
        </div>
    </section>
</form>

<script src="../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<script src="../plugins/bs-custom-file-input/bs-custom-file-input.min.js"></script>
<!-- AdminLTE App -->
<script src="../dist/js/adminlte.min.js"></script>
  
</body>
</html>
