<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="BRANCHES_edit" %>

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
  <%-- <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
   <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
   <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
   <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
   <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-theme.min.css") %>" rel="stylesheet" />
   <link href="<%= Page.ResolveUrl ("~/Datetimecss/cs_New_Component.css") %>" rel="stylesheet" />--%>
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
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
            <div class="container-fluid">
        <!-- COLOR PALETTE -->
        <div class="card card-default color-palette-box">
          <div class="card-header">
            <h3 class="card-title" style="font-size:large">
               <i class="fas fa-building"></i>
             BRANCH EDIT
            </h3>
          </div>
            <div class="card-body">


                <div class="row ">
                    <div class="col-md-6">
                         <asp:LinkButton ID="linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnsave_Click" ><i class="fa fa-save" style="color:white" aria-hidden="true"></i> Save</asp:LinkButton>
                         <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtncancel_Click"><i class="fas fa-caret-left" style="color:white" aria-hidden="true" ></i> Cancel</asp:LinkButton>                   
                    </div>
                </div>

                    <div class="row user-control">
                            <div class="col-md-12">
                                <div  id="alert_container">
                                                         
                    </div>

                <div class="row user-control">
                    <div class="col-md-3">
                        COMPANY<strong style="color:red">*</strong>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtCompany" runat="server" CssClass="textboxstyle"></asp:TextBox>
                    </div>
                </div>


                <div class="row user-control">
                    <div class="col-md-3">
                        BRANCH_CODE<strong style="color:red">*</strong>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtBranchCode" runat="server" CssClass="textboxstyle"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        BranchShort
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtBranchShort" runat="server" CssClass="textboxstyle"></asp:TextBox>
                    </div>
                </div>

                <div class="row user-control">
                    <div class="col-md-3">
                        BranchName
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtBranchName" runat="server" CssClass="textboxstyle"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        BranchNameK
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="TxtBranchNameK" runat="server" CssClass="textboxstyle"></asp:TextBox>
                    </div>
                </div>


            </div>
            </div>
          </div>
            </div>
          </div>

    </form>
</body>
</html>
