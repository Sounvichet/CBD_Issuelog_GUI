<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetJobtitlegroupid.aspx.cs" Inherits="ROLES_GetJobtitlegroupid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">

    <link href="<%= Page.ResolveUrl ("~/plugins/fontawesome-free/css/all.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/plugins/toastr/toastr.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/dist/css/adminlte.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/plugins/bootstrap4-duallistbox/bootstrap-duallistbox.min.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
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
          .onclicked:hover {
          background-color:gray !important;
          }
       textarea
        {
            resize: none;
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
<body>
    <form id="form1" runat="server">
            <section class="content">
                  <div class="container-fluid">
                    <!-- COLOR PALETTE -->
                    <div class="card card-default color-palette-box">
                      <%--<div class="card-header">
                        <h3 class="card-title">
                          <i class="fas fa-users"></i>
                          ADD USERgroup
                        </h3>
                      </div>--%>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:LinkButton ID="linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnsave_Click" ><i class="fa fa-save" style="color:white" aria-hidden="true"></i> Save</asp:LinkButton>
                            </div>
                        </div>

                          <div class="row user-control">
                                <div class="col-md-12">
                                <div  id="alert_container">
                                                         
                                </div>
                                </div>
                        </div>


                        <div class="row user-control">        
                          <div class="col-md-12" align="center">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="lstLeft" runat="server" SelectionMode="Multiple" Width="200px" Height="200px">
                                            </asp:ListBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnLeft" Text="<<" runat="server" OnClick="btnLeft_Click" />
                                            <asp:Button ID="btnRight" Text=">>" runat="server" OnClick="btnRight_Click" />
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lstRight" runat="server" SelectionMode="Multiple"  Width="200px" Height="200px"></asp:ListBox>
                                        </td>
                                    </tr>
                                </table>
                          </div>
                    </div>



                        </div>
                    </div>
                </div>
            </section>
    </form>
    <script src="<%= Page.ResolveUrl ("~/plugins/jquery/jquery.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/plugins/bootstrap/js/bootstrap.bundle.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/plugins/sweetalert2/sweetalert2.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/plugins/toastr/toastr.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/dist/js/adminlte.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/plugins/bootstrap4-duallistbox/jquery.bootstrap-duallistbox.min.js")%>"></script>
   
</body>
</html>
