<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schedule.aspx.cs" Inherits="PACKAGES_schedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- SweetAlert2 -->
  <link rel="stylesheet" href="../../plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css">
  <!-- Toastr -->
  <link rel="stylesheet" href="../../plugins/toastr/toastr.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>

    <%--<link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />--%>
      <style>
    .color-palette {
      height: 35px;
      line-height: 35px;
      text-align: right;
      padding-right: .75rem;
    }
     .Popup  
        {  
            background-color: #FFFFFF;  
            border-width: 3px;  
            border-style: solid;  
            border-color: black;  
            padding-top: 10px;  
            padding-left: 10px;  
            width: 1000px;  
            height: 350px;  
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
  </style>

    <script type="text/javascript">
        function OpenPage() {
            this.parent.document.getElementById("frm2").src = "customerAction.aspx";
        }
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
    <div class="container-fluid">
        <!-- COLOR PALETTE -->
        <div class="card card-default color-palette-box">
          <div class="card-header">
            <h3 class="card-title" style="font-size:large">
               <i class="fas fa-toolbox"></i>
             PACKAGES SCHEDULE
            </h3>
          </div>
            <div class="card-body">

                      <div class="row user-control">
                            <div class="col-md-12">
                                <div  id="alert_container">                        
                            </div>
                    </div>
                 </div>

                <div class="row user-control">
                    <div class="col-md-3">
                        PACKAGEID<strong style="color:red">*</strong>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="TxtPACKAGEID" runat="server" CssClass="textboxstyle" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        PACKAGE_NAMEK
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtPKGname" runat="server" CssClass="textboxstyle" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="row user-control">
                    <div class="col-md-3">
                        PRICE
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="TxtPrice" runat="server" CssClass="textboxstyle"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        PACKAGESTATUS
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="D_PKGSTATUS" runat="server" CssClass="textboxstyle"></asp:DropDownList>
                    </div>
                    
                </div>

                 <div class="row user-control">
                    <div class="col-md-6">
                         <asp:LinkButton ID="linkbtnAdd" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnAdd_Click" ><i class="fa fa-plus" style="color:green" aria-hidden="true"></i> ADD</asp:LinkButton>
                        <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnedit_Click"><i class="fa fa-pencil" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                        <asp:LinkButton ID="Linkbtnrefresh" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnrefresh_Click"><i class="fas fa-sync-alt" style="color:white" aria-hidden="true" ></i> Refresh</asp:LinkButton>  
                        <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtncancel_Click"><i class="fas fa-caret-left" style="color:white" aria-hidden="true" ></i> Cancel</asp:LinkButton>                   
                    </div>
                </div>

                <div class="row user-control">
                    <div class="col-md-12">
                        <div class="table-responsive">
                                <asp:GridView ID="gridschedule" DataKeyNames="PackageID" runat="server" CssClass="table-bordered table-hover gridgetsize " style="width:100%" Font-Size="Smaller" OnRowDataBound="gridschedule_RowDataBound">
                                   <HeaderStyle CssClass="gvHeaderCenter" BackColor="#01559E" Font-Bold="true" ForeColor="#f5f5f5" />
                                    <Columns>
                                   <asp:TemplateField >
                                    <HeaderTemplate>
                                        CheckBox
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);"  />
                                    </ItemTemplate>
                                       <ItemStyle CssClass="gvItemCenter" />
                                    <HeaderStyle CssClass="gvHeaderCenter" />
                                    </asp:TemplateField>
                            
                                    <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lbldelete" runat="server" Text="Delete" align="center"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                            <asp:LinkButton ID="InkDelete" runat="server" CommandName="LinkDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="far fa-trash-alt" style ="color:blue"></i></asp:LinkButton>    <%--style = "margin-left:30px;margin-right:30px;width:20px"--%>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="gvItemCenter" />
                                    <HeaderStyle CssClass="gvHeaderCenter" />
                                </asp:TemplateField>


                                    </Columns>
                               </asp:GridView>
                           </div>
                    </div>
                </div>

                                <div class="row  user-control">
                                                     <div class="col-md-12" >
                                                              <div class="modal fade"  style="display: none; width:100%" id="iframe-open">
                                                                        <div class="modal-dialog modal-lg">
                                                                          <div class="modal-content">
                                                                            <div class="modal-header">
                                                                              <h4 class="modal-title" style="color:black; font-size:larger">
                                                                                 <label id="gettitlescreen" runat="server"></label>

                                                                              </h4>
                                                                              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                <span aria-hidden="true">&times;</span>
                                                                              </button>
                                                                            </div>
                                                                            <div class="modal-body">
                                                                              <iframe id="frm2" runat="server"  allowfullscreen="true" scrolling="yes" frameborder="0" style ="width:100% !important;height:200px;"  ></iframe>
                                                                            </div>
                                                                          <%--  <div class="modal-footer justify-content-between">
                                                                              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                              <button type="button" class="btn btn-primary">Save changes</button>
                                                                            </div>--%>
                                                                          </div>
                                                                          <!-- /.modal-content -->
                                                                        </div>
                                                                        <!-- /.modal-dialog -->
                                                                      </div>


                                                          <%--End TopUp Dialog --%>
                                                         </div>
                                                     </div>


            </div>
            </div>
          </div>
            </div>
          </div>

    </form>
        <script type="text/javascript">
         function RadioCheck(rb) {
             var gv = document.getElementById("<%=gridschedule.ClientID%>");
             var rbs = gv.getElementsByTagName("input");
             var row = rb.parentNode.parentNode;
             for (var i = 0; i < rbs.length; i++) {
                 if (rbs[i].type == "checkbox") {
                     if (rbs[i].checked && rbs[i] != rb) {
                         rbs[i].checked = false;
                         break;
                     }
                 }
             }
         };
</script>
<script src="../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- SweetAlert2 -->
<script src="../../plugins/sweetalert2/sweetalert2.min.js"></script>
<!-- Toastr -->
<script src="../../plugins/toastr/toastr.min.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
    </body>
</html>
