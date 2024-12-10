<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_visa_case_dispute.aspx.cs" Inherits="Payment_edit_visa_case_dispute" %>

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
                                <h3 class="box-title" style="color: blue">Update Pending Biller Dispute</h3>
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
                                        <asp:Label ID="Label3" runat="server" Text="REFNUM"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="l_rrn" runat="server" Text="Label" ForeColor="Blue"></asp:Label>
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        Tranasction Amount
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="l_trn_amount" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        Operation Currency
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="l_opr_ccy" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="row user-control">
                                    <div class="col-md-3">
                                        Operation Date
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="l_opr_date" runat ="server"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        STATUS
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="d_status" runat="server" CssClass="textboxstyle">
                                                        <asp:ListItem>PENDING</asp:ListItem>
                                                        <asp:ListItem>SOLVE</asp:ListItem>
                                                    </asp:DropDownList>
                                    </div>
                                </div>
                                
                                <div class="row user-control">
                                    <div class="col-md-3">
                                        REMARK
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="t_remark" runat="server" CssClass="textboxstyle" TextMode="MultiLine" Width="95%"></asp:TextBox>
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
