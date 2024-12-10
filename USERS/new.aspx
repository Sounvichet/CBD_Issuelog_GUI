<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new.aspx.cs" Inherits="USERS_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
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

    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-theme.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap.min.css") %>" rel="stylesheet" />

    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <%--<script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>--%>
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />

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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51); background-color:#00ff21" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:black">' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 5000);//5000=5 seconds
        };
    </script>
</head>
<body > <!--style="background-color:#ecf0f5"-->
    <form id="form1" runat="server">
     
         <section class="content">

            <div class="row">
                <div class="col-md-12">
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <div class="box-header with-border">
                                <i class="fa fa-money"></i>
                                <h3 class="box-title" style="color: blue">Register User</h3>
                            </div>
                            <div class="box-body">

                            <div class="row ">
                                <div class="col-md-6">
                                     <asp:LinkButton ID="linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnsave_Click" ><i class="fa fa-save" style="color:white" aria-hidden="true"></i> Save</asp:LinkButton>
                                     <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtncancel_Click"><i class="fas fa-caret-left" style="color:white" aria-hidden="true" ></i> Cancel</asp:LinkButton>                   
                                </div>
                            </div>

                            <div class="row user-control">
                                <div class="col-md-12">
                                    <div id="alert_container">
                                    </div>
                                </div>
                            </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        First Name
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtfname" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        Last Name
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtlname" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        Gender
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="D_gender" runat="server" CssClass="textboxstyle"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        IDCard
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtIDCard" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        Account
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtuserid" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        Password
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtpassword" runat="server" CssClass="textboxstyle" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        Email
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtemail" runat="server" CssClass="textboxstyle" Width="92%"></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
             </div>
            </section>

    </form>
</body>
</html>
