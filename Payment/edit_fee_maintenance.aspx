<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_fee_maintenance.aspx.cs" Inherits="Payment_delete_ticket_dispute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.4.1.min.js")%>" type="text/javascript"></script>
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
    </style>
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
                                <h3 class="box-title">Edit ATMcard Fee Maintenance</h3>
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
                                        <asp:Label ID="Label3" runat="server" Text="CARD_ID"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_card_id" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label4" runat="server" Text="Branch_Code"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_branch_code" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label1" runat="server" Text="Account_number"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_acct_number" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label2" runat="server" Text="AMOUNT"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="t_amount" runat="server" ></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label5" runat="server" Text="STATUS"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="d_status" runat="server" CssClass="textboxstyle"></asp:DropDownList>
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
