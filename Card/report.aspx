<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="Card_report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
        <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
        <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-theme.min.css") %>" rel="stylesheet" />
        <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap.min.css") %>" rel="stylesheet" />
        <%--<link href="<%= Page.ResolveUrl ("~/Datetimecss/cs_New_Component.css") %>" rel="stylesheet" />--%>
        <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
                <style type="text/css">
                    .form-control{
                            font-size:15px;
                            border-radius:5px 5px 5px 5px;
                            padding:2px 2px 2px 2px;
                            height:auto;
                            margin: 0 auto;
                        }
                    .user-control{
                                padding-top:5px;
                            }
                    .radiostyle {
                          height: auto;
                          width: auto !important;
                        }

                        .radiostyle label {
                            margin-left: 3px !important;
                            margin-right: 10px !important;
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
                         textarea
                    {
                        resize: none;
                    }
                </style>

    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>
       <script type="text/javascript">
         jQuery(function ($) {
            $("#<%=T_From.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
             $('#T_From').mask('99-aaa-9999');
            $("#<%=T_To.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
             $('#T_To').mask('99-aaa-9999');
        });
    </script>

    <script type="text/javascript">
        jQuery(function ($) {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setUpScript);
            function setUpScript(){
                $("#<%=T_From.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#T_From').mask('99-aaa-9999');
                $("#<%=T_To.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#T_To').mask('99-aaa-9999');
            }});
    </script>
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
         <section class="content">
              <div class="row">
                            <div class="col-xs-12">
                                   <div class="box box-primary">
                                    <div class="box-body box-profile">
                                                 <div class="box-header with-border">
                                                     <i class="fa fa-file-text"></i>
                                                 <h3 class="box-title" style="color:blue">Card Report Dashboard</h3>           
                                             </div>
                                             <div class="box-body">
                                                 <asp:ScriptManager ID="SMreportCard" runat="server"></asp:ScriptManager>
                                                  <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>

                                                 <div class="row user-control">
                                                     <div class="col-md-12" align="left">
                                                          <asp:LinkButton ID="Linkexport" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Button1_Click"><i class="fa fa-file-excel-o fa-lg" aria-hidden="true" ></i> Apply</asp:LinkButton>
                                                          <asp:LinkButton ID="LinkBtncancel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Button2_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                                         <%-- <asp:Button ID="btnRedirect" runat="server" Text="Cancel" OnClick="Cancel_click" />--%>
                                                     </div>
                                                 </div>

                                                 <div class="row user-control">
                                                     <div class="col-md-3">
                                                        <asp:Label ID="Label1" runat="server" Text="Report_type"></asp:Label>
                                                     </div>

                                                     <div class="col-md-3">
                                                        <asp:DropDownList ID="D_Report_type" runat="server" CssClass = "textboxstyle form-control" AutoPostBack="true" OnSelectedIndexChanged="D_Report_type_SelectedIndexChanged"></asp:DropDownList>
                                                     </div>

                                                     <div class="col-md-3">
                                                        <asp:Label ID="Label4" runat="server" Text="Select Date"></asp:Label>
                                                     </div>
                                                     <div class="col-md-3">
                                                        <asp:DropDownList ID="D_selectDate" runat="server" CssClass = "textboxstyle form-control" OnSelectedIndexChanged="D_selectDate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                     </div>
                                                 </div>

                                                 <div class="row user-control">
                                                     <div class="col-md-3">
                                                     From
                                                     </div>
                                                     <div class="col-md-3">
                                                     <asp:TextBox ID="T_From" runat="server" CssClass = "textboxstyle form-control"></asp:TextBox>
                                                     </div>
                                                     <div class="col-md-3">
                                                     To
                                                     </div>
                                                     <div class="col-md-3">
                                                     <asp:TextBox ID="T_To" runat="server" CssClass = "textboxstyle form-control"></asp:TextBox>
                                                     </div>
                                                 </div>
                                                 
                                                 <div class="row user-control">
                                                     <div class="col-md-12" align = "center">
                                                     <asp:RadioButtonList ID="rbl_report_listing" runat="server" CssClass="form-check-input"  ForeColor="Blue" RepeatColumns="1" Font-Size="Small"></asp:RadioButtonList>
                                                     </div>
                                                 </div>
                                               
                                                 
                                                 
                                            </ContentTemplate>
                                                <Triggers>
                                                        <asp:PostBackTrigger ControlID="Linkexport" />
                                                        
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
