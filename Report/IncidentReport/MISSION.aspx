<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MISSION.aspx.cs" Inherits="Report_IncidentReport_MISSION" %>

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
                    .td-control
                     {
                        padding-right:5px;
                     }
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
                        height: 23px;
                    }
                      .form-control
                       {
                            font-size:15px;
                            border-radius:5px 5px 5px 5px;
                            padding:2px 2px 2px 2px;
                            height:auto;
                            margin: 0 auto;
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
        <div class="box-body box-profile">
             <h3 class="box-title" style="color:blue" align="center">Misstion Report Dashboard</h3>
        </div>
            <asp:ScriptManager ID="SMMission" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="updateMission" UpdateMode="Conditional" runat="server">
					<ContentTemplate>
                        <div class="row">
                            <div class="col-md-12" align="center" >
                                 <table  class="table-responsive">
                                     <tr>
                                         <td class="td-control">
                                             Branch Name 
                                             <div>
                                                 <asp:DropDownList ID="D_branch_name" runat="server" Width="200" CssClass="textboxstyle form-control" OnSelectedIndexChanged="D_branch_name_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                             </div>
                                         </td>
                                         <td class="td-control">
                                             Terminal
                                             <div>
                                                 <asp:DropDownList ID="D_Terminal" runat="server" Width="200"  CssClass="textboxstyle form-control"></asp:DropDownList>
                                             </div>
                                         </td>

                                         <td class="td-control">
                                             Select Date
                                             <div>
                                                 <asp:DropDownList ID="D_SelectDate" runat="server" CssClass="textboxstyle form-control" OnSelectedIndexChanged="D_SelectDate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                             </div>
                                         </td>
                                         <td class="td-control">
                                             Start Date
                                             <div>
                                                 <asp:TextBox ID="T_Form" runat="server" CssClass="textboxstyle form-control"></asp:TextBox>
                                             </div>
                                         </td>
                                         <td class="td-control">
                                              End Date
                                             <div>
                                                 <asp:TextBox ID="T_To" runat="server" CssClass="textboxstyle form-control"></asp:TextBox>
                                             </div>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="user-control">
                                             <asp:LinkButton ID="LinkbtnApply" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkbtnApply_Click" ><i class="fa fa-pencil fa-lg" aria-hidden="true"></i> Apply</asp:LinkButton>
                                         <asp:LinkButton ID="Linkbtnexport" runat="server" CssClass="btn btn-sm btn-primary"  OnClick="Linkbtnexport_Click"><i class="fa fa-save fa-lg" aria-hidden="true" ></i> Export</asp:LinkButton>
                                         </td>
                                     </tr>

                                     <tr>
                                         <td>
                                              <asp:Label ID="Label3" runat="server" Text="Records:" ForeColor="#3333FF"
                                            Visible="true"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>      
                                         </td>
                                     </tr>

                                 </table>
                            </div>
                        </div>
                        
                        <div class="row" align="center">
                            <div class="col-md-12">
                                  <div class="table-responsive" style="width:950px">
                                                            <asp:GridView ID="Getgridview" runat="server"  CssClass="table table-bordered table-hover" CellPadding="4" Font-Size="Smaller" AutoGenerateColumns="true" RowStyle-Wrap="false" CellSpacing = "4">
                        
                                                                </asp:GridView>
                                                        </div>
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
