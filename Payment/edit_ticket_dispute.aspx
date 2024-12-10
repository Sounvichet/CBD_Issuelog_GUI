<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_ticket_dispute.aspx.cs" Inherits="Payment_edit_ticket_dispute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap 3.3.7 -->
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />


    <style type="text/css">
        .button_bg {
            background-color: #009da5;
        }

        .category_bg {
            background-color: #f99d1c;
        }

        .form-control {
            font-size: 15px;
            border-radius: 5px 5px 5px 5px;
            padding: 2px 2px 2px 2px;
            height: auto;
            margin: 0 auto;
        }

        .user-control {
            padding-top: 5px;
        }

        .textboxstyle {
            font-size: 15px;
            border-radius: 5px 5px 5px 5px;
            border: 1px solid #c4c4c4;
            padding: 2px 2px 2px 2px;
        }

            .textboxstyle:focus {
                border: 1px solid #7bc1f7;
            }

        textarea {
            resize: none;
        }
    </style>
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.4.1.min.js")%>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/js/jquery.dynDateTime.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/js/calendar-en.min.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/CSS/calendar-blue.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        jQuery(function ($) {
            $("#<%=t_wrs_date.ClientID %>").dynDateTime({
             showsTime: true,
             ifFormat: "%m/%d/%Y", //%H:%M:%S
             daFormat: "%l;%M %p, %e %m,  %Y",
             align: "BR",
             electric: false,
             singleClick: false,
             displayArea: ".siblings('.dtcDisplayArea')",
             button: ".next()"
         });

         $("#<%=t_issue_date.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%m/%d/%Y", // %H:%M:%S
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });

        $("#<%=t_resolved_date.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%m/%d/%Y", //%H:%M:%S
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
        jQuery(function ($) {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(datepickerload);
            function datepickerload() {
                $("#<%=t_wrs_date.ClientID %>").dynDateTime({
                     showsTime: true,
                     ifFormat: "%m/%d/%Y", // %H:%M:%S
                     daFormat: "%l;%M %p, %e %m,  %Y",
                     align: "BR",
                     electric: false,
                     singleClick: false,
                     displayArea: ".siblings('.dtcDisplayArea')",
                     button: ".next()"
                 });

                 $("#<%=t_issue_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y", // %H:%M:%S
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });
                $("#<%=t_resolved_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y", // %H:%M:%S
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

            };
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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51); background-color:#00ff21" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:black">' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 5000);//5000=5 seconds
        };
    </script>
</head>
<body style="background-color: #ecf0f5">
    <form id="form1" runat="server">
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <div class="box-header">
                                <h3 class="box-title" style="color: blue">Update Pending Ticket Dispute</h3>
                            </div>
                            <div class="box-body">

                                <div class="row user-control">
                                    <div class="col-md-12" align="left">
                                        <asp:LinkButton ID="Linkbtnupdate" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Linkbtnupdate_Click"><i class="fa fa-save fa-lg" aria-hidden="true" ></i> Save</asp:LinkButton>
                                        <asp:LinkButton ID="LinkBtncancel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="btnCancel_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                    </div>
                                </div>
                                <p></p>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="alert_container">
                                        </div>
                                    </div>
                                </div>
                                <div class="row user-control">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label3" runat="server" Text="Ticket_no"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label8" runat="server" Text="Label" ForeColor="red"></asp:Label>
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label5" runat="server" Text="Branch_name"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="branch_name" runat="server" CssClass="textboxstyle" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label6" runat="server" Text="SYSTEM_TYPE"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_system_type" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label7" runat="server" Text="WRS_DATE"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_wrs_date" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                        <img src="../Image/calender.png" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label9" runat="server" Text="ISSUE_DATE"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_issue_date" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                        <img src="../Image/calender.png" />
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label10" runat="server" Text="RESOLVED_DATE"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_resolved_date" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                        <img src="../Image/calender.png" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label1" runat="server" Text="TERMINAL_ID"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_terminal_id" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label2" runat="server" Text="TRACE_NUMBER"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_trace_number" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label4" runat="server" Text="CURRENCY"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="d_Currency" runat="server" CssClass="textboxstyle">
                                            <asp:ListItem>USD</asp:ListItem>
                                            <asp:ListItem>KHR</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row user-control">

                                    <div class="col-md-3">
                                        <asp:Label ID="Label11" runat="server" Text="TRN_AMOUNT"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_trn_amount" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label12" runat="server" Text="FEE_AMOUNT"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_fee_amount" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="row user-control">

                                    <div class="col-md-3">
                                        <asp:Label ID="Label13" runat="server" Text="ISSUE_TYPE"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="d_issue_type" runat="server" CssClass="textboxstyle" Width="100%"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label14" runat="server" Text="Problem_Type"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="d_Problem_Type" runat="server" CssClass="textboxstyle" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row user-control">

                                    <div class="col-md-3">
                                        <asp:Label ID="Label15" runat="server" Text="STATUS"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="d_status" runat="server" CssClass="textboxstyle" Width="100%">
                                            <asp:ListItem>PENDING</asp:ListItem>
                                            <asp:ListItem>SOLVED</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label16" runat="server" Text="REMARK"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_Remark" runat="server" TextMode="MultiLine" CssClass = "textboxstyle form-control"></asp:TextBox>
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
