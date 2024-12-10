<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ISSLIST.aspx.cs" Inherits="Report_IncidentReport_ISSLIST" %>

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
            $("#<%=T_Form.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
             $('#Start_date').mask('99-aaa-9999');
            $("#<%=T_To.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
             $('#End_date').mask('99-aaa-9999');
        });
    </script>

    <script type="text/javascript">
        jQuery(function ($) {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setUpScript);
            function setUpScript(){
                $("#<%=T_Form.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#Start_date').mask('99-aaa-9999');
                $("#<%=T_To.ClientID %>").datepicker({
                    format: "dd-M-yyyy",
                    orientation: "top right",
                    autoclose: true,
                    todayHighlight: true,
                    toggleActive: true
                });
                $('#End_date').mask('99-aaa-9999');
            }});
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="SMISSBYDATE" runat="server"></asp:ScriptManager>
                     <asp:UpdatePanel ID="UpdateISSLIST" UpdateMode="Conditional" runat="server">
							         <ContentTemplate>
                                                    <div class ="row">
                                                       <div class="col-lg-12" align="center">  
                                                           <asp:Label ID="Label1" runat="server" Text="Select Date:"></asp:Label> 
                                                           <asp:DropDownList ID="D_date" runat="server" CssClass = "textboxstyle" OnSelectedIndexChanged="DropDown_Selectdate" AutoPostBack="true"></asp:DropDownList>          
                                                            From
                                                            <asp:TextBox ID="T_Form" runat="server" CssClass = "textboxstyle" Width="100px"></asp:TextBox>
                                                            To
                                                            <asp:TextBox ID="T_To" runat="server" CssClass = "textboxstyle" Width="100px"></asp:TextBox>
                                                        </div>
                                                  </div>
                                                    <p></p>
                                                    <div class="row">
                                                       <div class="col-lg-12" align = "center">
                 
                                                           <asp:LinkButton ID="Linkbtnexport" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Button1_Click" ><i class="fa fa-pencil fa-lg" aria-hidden="true"></i> Export</asp:LinkButton>
                                                           <asp:LinkButton ID="Linkbtcancel" runat="server" CssClass="btn btn-sm btn-primary"  OnClick="Button2_Click"><i class="fa fa-save fa-lg" aria-hidden="true" ></i> Cancel</asp:LinkButton> 
                                                       </div>
                                                  </div>
                                                        <p></p>

                                              <div class="row" align="center">
                                                <div class="col-md-12">
                                                    <asp:RadioButtonList ID="rbl_issuelisting" runat="server" CssClass="rbListWrap" RepeatColumns="1"  Width = "20%" ForeColor="Blue"></asp:RadioButtonList>
                                                </div>
        
                                            </div>
                                </ContentTemplate>
                         <Triggers>
                             <asp:PostBackTrigger ControlID="Linkbtnexport" />
                         </Triggers>
                      </asp:UpdatePanel>
    </form>
</body>
</html>
