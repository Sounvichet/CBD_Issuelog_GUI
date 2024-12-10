<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userpermission.aspx.cs" Inherits="USERS_userpermission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
   <link href="<%= Page.ResolveUrl ("~/plugins/fontawesome-free/css/all.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/plugins/toastr/toastr.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/dist/css/adminlte.min.css") %>" rel="stylesheet" type="text/css" />
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
                          USER AND PERMISSIONS
                        </h3>
                      </div>
                    <div class="card-body" style="height:700px">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtncancel_Click"><i class="fas fa-caret-left" style="color:white" aria-hidden="true" ></i> Cancel</asp:LinkButton>                   
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                Login Account
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="t_loginacc" runat="server" CssClass="textboxstyle"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Password Algorithm
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="t_password_algr" runat="server" CssClass="textboxstyle"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row user-control">
                            <div class="col-md-3">
                                First Name
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="t_firstName" runat="server" CssClass="textboxstyle"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Last Name
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="t_lastName" runat="server" CssClass="textboxstyle"></asp:TextBox>
                            </div>
                        </div>


                        <div class="row user-control">
                            <div class="col-md-3">
                                Nick Name
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="t_NickName" runat="server" CssClass="textboxstyle"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Order 
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="t_order" runat="server" CssClass="textboxstyle"></asp:TextBox>
                            </div>
                        </div>

                       <div class="row user-control">
                            <div class="col-md-3">
                                Email
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="t_email" runat="server" CssClass="textboxstyle" Width="92%"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row user-control">
                            <div class="col-md-3">
                                Description
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="t_desc" runat="server" CssClass="textboxstyle" Width="92%"></asp:TextBox>
                            </div>
                        </div>

                         <div class="row user-control">
                            <div class="col-md-3">
                                Member of Group
                            </div>
                            <div class="col-md-9">
                                <asp:DropDownList ID="d_membergroup" runat="server" CssClass="textboxstyle" Width="92%"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="row user-control">
                            <div class="col-md-3">
                                Branch
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="d_Branch" runat="server" CssClass="textboxstyle" Width="76%" Enabled="false" ></asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                Language
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="d_language" runat="server" CssClass="textboxstyle" Width="76%" Enabled="false"></asp:DropDownList>
                            </div>

                        </div>

                          <div class="row user-control">
                            <div class="col-md-3">
                                Assigned
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="t_assigned" runat="server" CssClass="textboxstyle"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Job Title
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="t_jobtitle" runat="server" CssClass="textboxstyle"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row user-control">
                            <div class="col-md-3">
                                Assigned Group
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="t_assignedGroup" runat="server" CssClass="textboxstyle" TextMode="MultiLine" Width="76%"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="btngroup" CssClass="btn btn-sm btn-primary"  runat="server"  aria-hidden="true" OnClick="btngroup_Click"><i class="fa fa-plus" style="color:white" aria-hidden="true" ></i> apply</asp:LinkButton>
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
                                                                          <%--  <button id="btn_print_proxy" style="margin-bottom: 10px;" class="btn btn-default">
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

                                                          <%--End TopUp Dialog --%>
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
</body>
</html>
