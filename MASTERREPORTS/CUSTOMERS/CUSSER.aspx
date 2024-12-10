<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CUSSER.aspx.cs" Inherits="MASTERREPORTS_CUSTOMERS_CUSSER" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="<%= Page.ResolveUrl ("~/plugins/fontawesome-free/css/all.min.css")%>" rel="stylesheet" type="text/css" />
  <!-- Ionicons -->
    <link href="<%= Page.ResolveUrl ("~/CSS/ionicons.min.css")%>" rel="stylesheet" type="text/css" />
  <!-- Theme style -->
    <link href="<%= Page.ResolveUrl ("~/dist/css/adminlte.min.css")%>" rel="stylesheet" type="text/css" />
  <!-- Google Font: Source Sans Pro -->
    <link href="<%= Page.ResolveUrl ("~/CSS/google-Font.css")%>" rel="stylesheet" type="text/css" />
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

         <script type="text/javascript">
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
            <div class="row">
                    <div class="col-md-12 table-responsive">
                        <table style="border:hidden" class="table">
                        <tr>
                            <td>
                                Branch Name
                                <div>
                                    <asp:DropDownList ID="d_branch" runat="server" CssClass="textboxstyle"></asp:DropDownList>
                                </div>
                            </td>

                            <td>
                                Start Date
                                <div>
                                    <asp:TextBox ID="txtS_date" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                </div>
                            </td>

                            <td>
                                End Date
                                <div>
                                    <asp:TextBox ID="txtE_date" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                </div>
                            </td>
                        </tr>    
                        </table>
                    </div>
                </div>

            <div class="row user-control">
                   <div class="col-md-12">
                       <asp:LinkButton ID="linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnsave_Click" ><i class="fa fa-save" style="color:white" aria-hidden="true"></i> Apply</asp:LinkButton>
                       <asp:LinkButton ID="Linkbtnrefresh" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnrefresh_Click"><i class="fas fa-sync-alt" style="color:white" aria-hidden="true" ></i> Refresh</asp:LinkButton> 
                       <asp:LinkButton ID="Linkexport" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkexport_Click"><i class="far fa-file-excel" style="color:white" aria-hidden="true" ></i> Export</asp:LinkButton>  
                       <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtncancel_Click"><i class="fas fa-caret-left" style="color:white" aria-hidden="true" ></i> Cancel</asp:LinkButton>                   
                   </div>
            </div>

        <div class="row user-control">
            <div class="col-md-12 table-responsive">
                            <asp:GridView ID="GridCustreport"  CssClass="table-bordered table-hover gridgetsize"  runat="server"  AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" >
                        <%-- <AlternatingRowStyle BackColor="White" />--%>
                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#01559E" Font-Bold="true" ForeColor="#f5f5f5" />
                        <Columns>

                        </Columns>
                        </asp:GridView>
                       
                <div>
                        <asp:Label ID="Label3" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                        <asp:Label ID="Label4" runat="server"  Visible="true"></asp:Label>
                </div> 
            </div>
        </div>
    </form>
</body>
</html>
