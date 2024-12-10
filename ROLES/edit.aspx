﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="ROLES_edit" %>

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
  <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
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
     <div class="container-fluid">
        <!-- COLOR PALETTE -->
        <div class="card card-default color-palette-box">
          <div class="card-header">
            <h3 class="card-title" style="font-size:large">
               <i class="fas fa-users-cog"></i>
             ROLE EDIT
            </h3>
          </div>
            <div class="card-body">
                <div class="row ">
                    <div class="col-md-12">
                    <asp:LinkButton ID="Linkbtnnew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnnew_Click" ><i class="fa fa-plus" style="color:white" aria-hidden="true"></i> Edit</asp:LinkButton>
                    <asp:LinkButton ID="linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnsave_Click" Enabled="false"><i class="fa fa-save" style="color:white" aria-hidden="true"></i> Save</asp:LinkButton>
                    <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtncancel_Click" Enabled="false"><i class="fas fa-caret-left" style="color:white" aria-hidden="true" ></i> Cancel</asp:LinkButton>                   
                    </div>
                </div>

                    <div class="row user-control">
                            <div class="col-md-12">
                                <div  id="alert_container">                        
                            </div>
                    </div>
                 </div>

                <div class="row user-control">
                    <div class="col-md-3">
                        Group ID
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtgroupid" runat="server" CssClass="textboxstyle" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                  <div class="row user-control">
                    <div class="col-md-3">
                        Name
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtname" runat="server" CssClass="textboxstyle" Enabled="false"></asp:TextBox>
                    </div>
                      <div class="col-md-3">
                        Order
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtorder" runat="server" CssClass="textboxstyle" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                  <div class="row user-control">
                    <div class="col-md-3">
                        Description
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textboxstyle" Width="93%" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                  <div class="row user-control">
                    <div class="col-md-3">
                        
                    </div>
                    <div class="col-md-3">
                        <asp:CheckBox ID="chkactive" runat="server" Text="Active" Enabled="false" />
                    </div>
                    <div class="col-md-3">
                        Group level
                    </div>
                      <div class="col-md-3">
                          <asp:DropDownList ID="dgrouplevel" runat="server" CssClass="textboxstyle" Width="78%" Enabled="false"></asp:DropDownList>
                    </div>
                </div>

                <div class="row user-control">
                    <div class="col-md-3">

                    </div>
                    <div class="col-md-3">
                        <asp:CheckBox ID="Chkholiday" runat="server" Text="Allow Holiday login" Enabled="false" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
