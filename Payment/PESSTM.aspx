﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PESSTM.aspx.cs" Inherits="Payment_PESSTM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-theme.min.css") %>" rel="stylesheet" />
    <style>
        .user-control
         {
         padding-top:5px;
         }
         .textboxstyle
          {
                font-size:15px;
                border-radius:5px 5px 5px 5px;
                border:1px solid #c4c4c4;
                padding:2px 2px 2px 2px;
                height:auto;
           }
         .textboxstyle:focus
           {
                border:1px solid #7bc1f7;
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
    <script src="<%= Page.ResolveUrl ("~/js/dataTables.bootstrap.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/CSSchart/js/morris.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/CSSchart/js/raphael.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl("~/js/adminlte.min.js")%>"></script>
<script type="text/javascript">
         jQuery(function ($) {
             //Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(setUpScript);
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setUpScript);
             function setUpScript() {

                 $("#<%=txtfrom.ClientID %>").datepicker({
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

                $("#<%=txtto.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#End_date').mask('99-aaa-9999');

                $("#<%=txtgenerate.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#generate').mask('99-aaa-9999');
            });
    </script>
    <script type="text/javascript">
        jQuery(function ($) {
            $("#<%=txtfrom.ClientID %>").datepicker({
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


            $("#<%=txtto.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $('#End_date').mask('99-aaa-9999');

            $("#<%=txtgenerate.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $('#generate').mask('99-aaa-9999');
        });
    </script>
</head>
    
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <div class="box-header with-border">
                                <i class="fa fa-money"></i>
                                <h3 class="box-title" style="color:blue">PES Settlement</h3>
                            </div>
                            <div class="box-body" style="height:500px">
                                <asp:ScriptManager ID="SMSPESSTM" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePESSTM" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                             <div class="row">
                                                    <div class="col-md-12">
                                                            <asp:LinkButton ID="Linkbtnapply" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnapply_Click"><i class="fa fa-file-excel-o fa-lg" aria-hidden="true" ></i> Apply</asp:LinkButton>
                                                            <asp:LinkButton ID="Linkbtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtncancel_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> Cancel</asp:LinkButton>
                                                    </div>
                                            </div>

                                            <div class="row user-control">
                                                <div class="col-md-3">
                                                    Get Form:
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:TextBox ID="txtfrom" runat="server" CssClass="textboxstyle form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3">
                                                    Generate Date:
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:TextBox ID="txtgenerate" runat="server" CssClass="textboxstyle form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row user-control">
                                                <div class="col-md-3">
                                                    Get To :
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:TextBox ID="txtto" runat="server" CssClass="textboxstyle form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger  ControlID="Linkbtnapply"/>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
