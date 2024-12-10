<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_visa_cbs_reference.aspx.cs" Inherits="Payment_edit_visa_cbs_reference" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .button_bg {
            background-color: #009da5;
        }

        .category_bg {
            background-color: #f99d1c;
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
         .user-control {
            padding-top: 5px;
        }
    </style>

    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.4.1.min.js")%>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/js/jquery.dynDateTime.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl ("~/js/calendar-en.min.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/CSS/calendar-blue.css")%>" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        jQuery(function ($) {
            $("#<%=t_run_date.ClientID %>").dynDateTime({
             showsTime: true,
             ifFormat: "%m/%d/%Y", //%H:%M:%S
             daFormat: "%l;%M %p, %e %m,  %Y",
             align: "BR",
             electric: false,
             singleClick: false,
             displayArea: ".siblings('.dtcDisplayArea')",
             button: ".next()"
         });

         $("#<%=t_proc_date.ClientID %>").dynDateTime({
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
                $("#<%=t_run_date.ClientID %>").dynDateTime({
                     showsTime: true,
                     ifFormat: "%m/%d/%Y", //%H:%M:%S  
                     daFormat: "%l;%M %p, %e %m,  %Y",
                     align: "BR",
                     electric: false,
                     singleClick: false,
                     displayArea: ".siblings('.dtcDisplayArea')",
                     button: ".next()"
                 });

                 $("#<%=t_proc_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y", //%H:%M:%S 
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
                case 'Success ':
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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:black">' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 5000);//5000=5 seconds
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <div class="box-header">
                                <h3 class="box-title">VISA Update CBS Reference</h3>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12" align="left">
                                        <asp:LinkButton ID="Linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Linkbtnsave_Click"><i class="fa fa-save fa-lg" aria-hidden="true" ></i> Save</asp:LinkButton>
                                        <asp:LinkButton ID="LinkBtncancel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Btncancel_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                    </div>
                                </div>
                                <p></p>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="alert_container">
                                        </div>
                                    </div>
                                </div>
                                <p></p>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label3" runat="server" Text="RRN"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_refnum" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label4" runat="server" Text="Transaction Type"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_trans_type" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label1" runat="server" Text="Currency"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_currency" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label2" runat="server" Text="Transaction Amount"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_trn_amount" runat="server" ></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label5" runat="server" Text="Transaction Fee / Interchange Fee"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_trn_fee" runat="server" ></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label6" runat="server" Text="Transaction Date"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_trn_date" runat="server" ></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label13" runat="server" Text="Issuer Institution"></asp:Label>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label ID="t_iss_inst" runat="server"></asp:Label>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label ID="Label14" runat="server" Text="Acquire institution"></asp:Label>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label ID="t_acq_inst" runat="server"></asp:Label>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label15" runat="server" Text="Response Code"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_resp" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label16" runat="server" Text="Session File Id"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_session_file_id" runat="server" ></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label17" runat="server" Text="Markup 2%"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_markup" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label18" runat="server" Text="Visa Charge"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_visa_charge" runat="server"></asp:Label>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label7" runat="server" Text="Run Date"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_run_date" runat ="server" CssClass="textboxstyle"></asp:TextBox>
                                        <img src="../Image/calender.png" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label8" runat="server" Text="Process Date"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_proc_date" runat ="server" CssClass="textboxstyle"></asp:TextBox>
                                        <img src="../Image/calender.png" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label9" runat="server" Text="CBS Online Reference"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_online_ref" runat ="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label10" runat="server" Text="CBS Offline Reference"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="t_offline_ref" runat ="server" CssClass="textboxstyle"></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label19" runat="server" Text="Visa Charge Dr/Cr" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                            <asp:DropDownList ID="d_DRCR" runat="server" CssClass="textboxstyle" Visible="false"></asp:DropDownList>
                                    </div>
                                     <div class="col-md-3">
                                        <asp:Label ID="Label20" runat="server" Text="Visa Mask up Dr/Cr" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                            <asp:DropDownList ID="d_drcr_maskup" runat="server" CssClass="textboxstyle" Visible="false"></asp:DropDownList>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label21" runat="server" Text="Visa ICF Dr/Cr" Visible="false"></asp:Label>
                                    </div>
                                     <div class="col-md-3">
                                         <asp:DropDownList ID="d_drcr_icf" runat="server" CssClass="textboxstyle" Visible="false"></asp:DropDownList>
                                    </div>
                                  </div>


                                 <div class="row">
                                    <div class="col-md-12 textboxstyle category_bg">
                                        <asp:Label ID="Label11" runat="server" Font-Bold="true" Text="CBS Posting Entries"></asp:Label>
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="Grid_list_by_RRN" CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-md-12 textboxstyle category_bg">
                                        <asp:Label ID="Label12" runat="server" Font-Bold="true" Text="ITO Pre Ccheck"></asp:Label>
                                    </div>
                                </div>

                                 <div class="row user-control">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="Grid_ito_pre_check" CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />
                                            </asp:GridView>
                                        </div>
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
