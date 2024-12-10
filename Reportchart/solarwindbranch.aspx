<%@ Page Language="C#" AutoEventWireup="true" CodeFile="solarwindbranch.aspx.cs" Inherits="Reportchart_solarwindbranch" %>

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
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap.min.css") %>" rel="stylesheet" />
        <style>
         .button_bg {
            background-color: #009da5;
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

                 $("#<%=T_Form.ClientID %>").datepicker({
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
                 $("#<%=T_To.ClientID %>").datepicker({
                     format: "dd-M-yyyy",
                     orientation: "top right",
                     autoclose: true,
                     todayHighlight: true,
                     toggleActive: true
                 });
                 $('#End_date').mask('99-aaa-9999');
             }
         });
    </script>

    <script type="text/javascript">
        jQuery(function ($) {
            $("#<%=T_Form.ClientID %>").datepicker({
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
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
                <section class="content">
                        <div class="row" style="height:1555px;">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header with-border">
                                            <i class="fa fa-pie-chart"></i>
                                                <h3 class="box-title">Dialy Branch Service Dashboard (Service Uptime: <asp:Label ID="lbldailyuppercent" runat="server" Text="Label" Font-Bold="true"></asp:Label>%) as of <asp:Label ID="lblcurrentdate" runat="server" Font-Bold="true" Text="Label"></asp:Label> </h3>           
                                            </div>
                                            <div class="box-body">
                                        
                     <asp:ScriptManager ID="SMSolarWindBRN" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdateSolarWindBRN" UpdateMode="Conditional" runat="server">
			                                <ContentTemplate> 

                                                 <div class="row">
                                                     <div class="col-md-6">
                                                         <div class="box box-primary table-responsive">
                                                            <div class="box-header with-border">
                                                              <h3 class="box-title">Branch Service By Status</h3>
                                                              <div class="box-tools pull-right">
                                                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                                                                </button>
                                                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                              </div>
                                                            </div>
                                                            <div class="box-body">
                                                               
                                                              <%--<div class="chart" id="chart1" style="height: 300px;"></div>--%>
                                                                <asp:Chart ID="Chart2" runat=server Width="500px">
                                                                    <Series>
                                                                        <asp:Series Name="Series1" BorderColor="Black" BorderWidth="0">

                                                                        </asp:Series>
                                                                        
                                                                    </Series>
                                                                    <borderskin backcolor="Olive" bordercolor="Olive" skinstyle="Emboss" />
                                                                    <Legends>
                                                                        <asp:Legend Title="Branch"></asp:Legend>
                                                                    </Legends>
                                                                   <%-- <Titles>
                                                                        <asp:Title Docking="Bottom" Text="Branch Service Status"></asp:Title>
                                                                    </Titles>--%>
                                                                    <ChartAreas>
                                                                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" BackColor="white"></asp:ChartArea>
                                                                        
                                                                    </ChartAreas>

                                                                </asp:Chart>
                                                           
                                                            </div>
                                                     </div>
                                                 </div>

                                                     <div class ="col-md-6">
                                                         <div class="box box-info table-responsive">
                                                            <div class="box-header with-border">
                                                              <h3 class="box-title">Branch Down Minutes By Hour</h3>
                                                              <div class="box-tools pull-right">
                                                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                                                                </button>
                                                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                              </div>
                                                            </div>
                                                            <div class="box-body">
                                                                <asp:Chart ID="Chart5" runat=server Width="500px">
                                                                    <Series>
                                                                        <asp:Series Name="Series1" BorderColor="Purple" BorderWidth="0" Enabled="false"></asp:Series>
                                                                        
                                                                    </Series>
                                                                     <borderskin backcolor="Olive" bordercolor="Olive" skinstyle="Emboss" />
                                                                    <Legends>
                                                                        <asp:Legend Title="By Date"></asp:Legend>
                                                                    </Legends>
                                                                   <%-- <Titles>
                                                                        <asp:Title Docking="Bottom" Text="Branch SERVICE DOWNMINUTE"></asp:Title>
                                                                    </Titles>--%>
                                                                    <ChartAreas>
                                                                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" BackColor="WhiteSmoke" Area3DStyle-WallWidth="10" Area3DStyle-Enable3D="false">
                                                                             
                                                                        </asp:ChartArea>
                                                                        
                                                                    </ChartAreas>

                                                                </asp:Chart>
                                                           
                                                            </div>
                                                     </div>

                                                     </div>

                                                 </div> 

                                                 <div class ="row">
                                                     <div class="col-md-12">
                                                          <div class="box box-primary table-responsive">
                                                            <div class="box-header with-border">
                                                              <h3 class="box-title">Current Branch Down</h3>
                                                              <div class="box-tools pull-right">
                                                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                                                                </button>
                                                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                              </div>
                                                            </div>
                                                                <div class="box-body">
                                                                   <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-hover" Font-Size="Smaller" Width="100%" RowStyle-Wrap="false" OnRowCommand="Node_RowCommand" OnRowDataBound="GridView2_RowDataBound">
                                                                       <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />   
                                                                       <Columns>

                                                                           <asp:TemplateField>
                                                                               <HeaderTemplate>
                                                                                   <asp:Label ID="Label1" runat="server" Text="Edit" align="center"></asp:Label>
                                                                               </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                        <asp:LinkButton ID="NodeEdit" runat="server" CommandName="Nodeedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-user fa-pencil" style="color:blue"></i></asp:LinkButton>    <%--style = "margin-left:30px;margin-right:30px;width:20px"--%>
                                                                                </ItemTemplate>
                                                                               <ItemStyle CssClass="gvItemCenter" />
                                                                               <HeaderStyle CssClass="gvHeaderCenter" />
                                                                            </asp:TemplateField>
                                                                       </Columns>
                                                                   </asp:GridView> 
                                                                    <div>
                                                                     <asp:Label ID="Label9" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                                                                     <asp:Label ID="Label10" runat="server" Text="Label" Visible="true"></asp:Label>
                                                                     </div>
                                                                </div>
                                                             </div>
                                                     </div>
                                                  
                                                 </div>

                                                 <div class="row">
                                                     <div class="col-md-12">
                                                         <div class="box box-primary table-responsive">
                                                            <div class="box-header with-border">
                                                              <h3 class="box-title">Branch Down Listing</h3>
                                                                        <p></p>
                                                              <div>
                                                                                <asp:Label ID="Label6" runat="server" Text="BranchName"></asp:Label>
                                                                                <asp:DropDownList ID="D_BranchName" runat="server" CssClass="textboxstyle" OnSelectedIndexChanged="D_BranchName_SelectedIndexChanged" AutoPostBack="true"  Width="200px"></asp:DropDownList> <%----AppendDataBoundItems="true"--%>
                                                                                <asp:Label ID="Label2" runat="server" Text="NodeName"></asp:Label>
                                                                                <asp:DropDownList ID="D_NodeName" runat="server" CssClass="textboxstyle" Width="200px"></asp:DropDownList>
                                                                                <asp:Label ID="Label3" runat="server" Text="Select Date:"></asp:Label>
                                                                                <asp:DropDownList ID="D_Date" runat="server" CssClass="textboxstyle" OnSelectedIndexChanged="D_Date_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                                <asp:Label ID="Label4" runat="server" Text="Form"></asp:Label>
                                                                                <asp:TextBox ID="T_Form" runat="server" CssClass="textboxstyle" Width="100px"></asp:TextBox>
                                                                                <asp:Label ID="Label5" runat="server" Text="To"></asp:Label>
                                                                                <asp:TextBox ID="T_To" runat="server" CssClass="textboxstyle" Width="100px"></asp:TextBox>

                                                                                <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm button_bg" OnClick="btnApply_Click"><i class="fa fa-reply-all fa-lg" aria-hidden="true" style="color:white" ></i> <span style="color:white">Apply</span> </asp:LinkButton>
                                                                                <asp:LinkButton ID="LinkBtncancel" runat="server" CssClass="btn btn-sm button_bg" OnClick="btncancel_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true"  style="color:white" ></i><span style="color:white">cancel</span></asp:LinkButton>
                                                              </div>

                                                              <div class="box-tools pull-right">
                                                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                                                                </button>
                                                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                              </div>
                                                            </div>
                                                                <div class="box-body">
                                                                   <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Font-Size="Smaller" Width="100%" RowStyle-Wrap="false" OnRowCommand="grid1_RowCommand" onpageindexchanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true" OnRowDataBound="GridView1_RowDataBound">
                                                                       <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" /> 
                                                                       <Columns>

                                                                           <asp:TemplateField>
                                                                               <HeaderTemplate>
                                                                                   <asp:Label ID="Edit" runat="server" Text="Edit" align="center"></asp:Label>
                                                                               </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="lnkedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-user fa-pencil" style ="color:blue"></i></asp:LinkButton>    <%--style = "margin-left:30px;margin-right:30px;width:20px"--%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="gvItemCenter" />
                                                                                 <HeaderStyle CssClass="gvHeaderCenter" />
                                                                            </asp:TemplateField>

                                                                             <asp:TemplateField>
                                                                               <HeaderTemplate>
                                                                                   <asp:Label ID="L_view" runat="server" Text="View" align="center"></asp:Label>
                                                                               </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                        <asp:LinkButton ID="LinkView" runat="server" CommandName="LinkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-search" style ="color:blue"></i></asp:LinkButton>    <%--style = "margin-left:30px;margin-right:30px;width:20px"--%>
                                                                                </ItemTemplate>
                                                                                 <ItemStyle CssClass="gvItemCenter" />
                                                                                 <HeaderStyle CssClass="gvHeaderCenter" />
                                                                            </asp:TemplateField>


                                                                       </Columns>
                                                                       <PagerSettings Mode="NumericFirstLast" PageButtonCount="10"  FirstPageText="First" LastPageText="Last"/> 
                                                                       <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                                                   </asp:GridView> 
                                                                       <div>
                                                                     <asp:Label ID="Label7" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                                                                     <asp:Label ID="Label8" runat="server" Text="Label" Visible="true"></asp:Label>
                                                                       </div>
                                                                </div>
                                                             </div>
                                                     </div>
                                                 </div>

                                               </ContentTemplate>
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
