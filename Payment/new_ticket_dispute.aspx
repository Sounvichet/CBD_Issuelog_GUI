<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_ticket_dispute.aspx.cs" Inherits="Payment_new_ticket_dispute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <!-- Bootstrap 3.3.7 -->
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    

    <style type="text/css">
        .button_bg {
        background-color:#009da5;
        }
        .category_bg {
        background-color:#f99d1c;
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
             .user-control
         {
         padding-top:5px;
         }
    </style>
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.4.1.min.js")%>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/js/jquery.dynDateTime.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/js/calendar-en.min.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/CSS/calendar-blue.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
   <script type="text/javascript">
        jQuery(function ($) {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Datepickerload);
            function Datepickerload() {
                $("#<%=t_WRS_DATE.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y ",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

                $("#<%=t_ISSUE_DATE.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y", // %H:%M
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

                $("#<%=t_Resolve_Date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y", // %H:%M
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });
            }});

        </script>
    <script type="text/javascript">
        jQuery(function ($) {
                $("#<%=t_WRS_DATE.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y ",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

                $("#<%=t_ISSUE_DATE.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y", // %H:%M
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

                $("#<%=t_Resolve_Date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y", // %H:%M
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
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
               <section class="content">
                        <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header">
                                                <h3 class="box-title" style="color:blue">Register Dispute Ticket</h3>
                                            </div>
                                            <div class="box-body">
                                                <asp:ScriptManager ID="SMdispute" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="Updatedispute" UpdateMode="Conditional" runat="server">
								                    <ContentTemplate>
                                                    <div class="row">
                                                           <div class="col-lg-12" align="left">
                                                               <asp:LinkButton ID="linkbtnsave" runat="server" class="btn btn-sm btn-primary button_bg" onclick="btn_save_Click"  ><i class="fa fa-save fa-lg" aria-hidden="true"></i> Save</asp:LinkButton>
                                                               <asp:LinkButton ID="linkbtncacel" runat="server" class="btn btn-sm btn-primary button_bg" onclick="btn_cancel_Click"  ><i class="fa fa-backward fa-lg" aria-hidden="true"></i> Cancel</asp:LinkButton>
                                                               <%-- <asp:Button ID="btn_save" runat="server" Text="Save" 
                                                                    class="btn btn-sm btn-primary" onclick="btn_save_Click" />--%>
                                                              <%--  <asp:Button ID="btn_cancel" runat="server" Text="Cancel" 
                                                                    class="btn btn-sm btn-primary" onclick="btn_cancel_Click" />  --%>
                                                           </div>
                                                   </div>
                                                       
                                                            <div class="row user-control">
                                                            <div class="col-md-12">
                                                                <div  id="alert_container">
                                                            </div>
                                                        </div>
                                                      </div>

                                                 
                                                     <div class="row user-control">
                                                        <div class="col-lg-12 textboxstyle category_bg">
                                                            <label id="lblBG">ATM information</label>
                                                        </div>
                                                    </div>
                                                    
                                                      <div class="row user-control">
                                                           
                                                            <div class="col-md-3">BRANCH_CODE</div>
                                                            <div class ="col-md-3">
                                                                <asp:DropDownList ID="D_BRANCH_CODE" runat="server" CssClass = "textboxstyle" 
                                                                    AutoPostBack="true" onselectedindexchanged="D_BRANCH_CODE_SelectedIndexChanged"
                                                                  Width="100%">
                                                                 </asp:DropDownList>
                                                            </div>

                                                           <div class="col-md-3">Ticket No</div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox id="t_Ticket_no" runat="server" CssClass ="textboxstyle" style="color:Blue;width:100%" ></asp:TextBox>
                                                            </div>

                                                      </div>

                                                    <div class="row user-control">
                                                            <div class="col-md-3">
                                                                 <asp:Label ID="l_Terminal" runat="server" Text="Terminal_ID" Visible="true"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:DropDownList ID="d_Terminal" runat="server" CssClass = "textboxstyle" Width="100%" ></asp:DropDownList>
                               
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:Label ID="l_issue_type" runat="server" Text="Issue_type" Visible="true"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:DropDownList ID="d_isse_type" runat="server" CssClass = "textboxstyle" Width="100%" ></asp:DropDownList>
                                                            </div>
                      
                                                   </div>

                                                    <div class="row user-control">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="Label8" runat="server" Text="System_Type" Visible="true"></asp:Label>
                                                            </div>
                                                           <div class="col-md-3">
                                                               <asp:DropDownList ID="d_System_Type" runat="server" CssClass = "textboxstyle" Width="100%" ></asp:DropDownList>
                                                            </div>
                                                            
                                                    </div>

                                                
                                                 <div class="row user-control">
                                                        <div class="col-lg-12 textboxstyle category_bg">
                                                            <label id="lblProbleminfo">Problem Information</label>
                                                        </div>

                                                    </div>

                                                        <div class="row user-control">
                                                        
                                                        <div class="col-md-3">
                                                            <asp:Label ID="l_WRS_DATE" runat="server" Text="WRS_DATE" Visible="true"></asp:Label>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="t_WRS_DATE" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="l_issue_date" runat="server" Text="ISSUE_DATE" Visible="true"></asp:Label>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="t_ISSUE_DATE" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                                                        </div>
                                                        
                                                        </div>

                                                        <div class="row user-control">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="l_resolve_date" runat="server" Text="Resolve_Date" Visible="true"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="t_Resolve_Date" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:Label ID="Label1" runat="server" Text="Problem_Type" Visible="true"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:DropDownList ID="D_Problem_Type" runat="server" CssClass = "textboxstyle" Width="100%" ></asp:DropDownList>
                                                            </div>
                                                       </div>

                                                       <div class="row user-control">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="Label2" runat="server" Text="ISS_BANK" Visible="true"></asp:Label>
                                                            </div>
                                                           <div class="col-md-3">
                                                               <asp:DropDownList ID="d_ISS_BANK" runat="server" CssClass = "textboxstyle" Width="100%" ></asp:DropDownList>
                                                            </div>
                                                           <div class="col-md-3">
                                                               <asp:Label ID="Label4" runat="server" Text="TRACE_NUMBER" Visible="true"></asp:Label>
                                                            </div>
                                                           <div class="col-md-3">
                                                               <asp:TextBox ID="t_trace_number" runat="server" CssClass="textboxstyle" style="color:Blue;width:100%"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="row user-control">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="Label3" runat="server" Text="ACQ_BANK" Visible="true"></asp:Label>
                                                            </div>
                                                           <div class="col-md-3">
                                                               <asp:DropDownList ID="d_ACQ_BANK" runat="server" CssClass = "textboxstyle" Width="100%" ></asp:DropDownList>
                                                            </div>
                                                           <div class="col-md-3">
                                                               <asp:Label ID="l_currency" runat="server" Text="Currency" Visible="true"></asp:Label>
                                                            </div>
                                                           <div class="col-md-3">
                                                               <asp:DropDownList ID="d_Currency" runat="server" CssClass = "textboxstyle" Width="100%" >
                                                                   <asp:ListItem>USD</asp:ListItem>
                                                                   <asp:ListItem>KHR</asp:ListItem>
                                                               </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="row user-control">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="l_trn_amount" runat="server" Text="TRN_AMOUNT" Visible="true"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="t_trn_amount" runat="server" CssClass="textboxstyle"  Width="100%"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:Label ID="l_FEE_AMOUNT" runat="server" Text="FEE_AMOUNT" Visible="true"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="t_fee_amount" runat="server" CssClass="textboxstyle"  Width="100%"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="row user-control">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="Label5" runat="server" Text="STATUS" Visible="true"></asp:Label>
                                                                </div>
                                                            <div class="col-md-3">
                                                                <asp:DropDownList ID="d_status" runat="server" CssClass = "textboxstyle" Width="100%" >
                                                                    <asp:ListItem>PENDING</asp:ListItem>
                                                                    <asp:ListItem>SOLVED</asp:ListItem>
                                                                </asp:DropDownList>
                                                                </div>
                                                            <div class="col-md-3">
                                                                <asp:Label ID="Label6" runat="server" Text="Refund to Other Bank" Visible="true"></asp:Label>
                                                                </div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="t_refund_bank" runat="server" TextMode="MultiLine" CssClass = "textboxstyle form-control"></asp:TextBox>
                                                                </div>
                                                        </div>
                                                   
                                                        <div class="row user-control">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="Label7" runat="server" Text="Remark" Visible="true"></asp:Label>
                                                            </div>
                                                            <div class="col-md-9">
                                                                <asp:TextBox ID="t_Remark" runat="server" TextMode="MultiLine" CssClass = "textboxstyle form-control"></asp:TextBox>
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
