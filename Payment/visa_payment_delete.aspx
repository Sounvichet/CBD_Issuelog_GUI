<%@ Page Language="C#" AutoEventWireup="true" CodeFile="visa_payment_delete.aspx.cs" Inherits="Payment_visa_payment_delete" %>

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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span>' + message + '</span></div>');

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
                                <h3 class="box-title" style="color: blue">VISA Payment Delete</h3>
                            </div>
                            <div class="box-body">
                                <asp:ScriptManager ID="SMticketedit" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatevistaEdit" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div class="row user-control">
                                            <div class="col-md-12">
                                                <asp:LinkButton ID="Linkbtndelete" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Linkbtndelete_Click"><i class="fa fa-save fa-lg" aria-hidden="true" style="color:red" ></i> Delete</asp:LinkButton>
                                                <asp:LinkButton ID="Linkbtncacel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Linkbtncacel_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" style="color:forestgreen" ></i> cancel</asp:LinkButton>

                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-12">
                                                <div id="alert_container">
                                                </div>
                                            </div>
                                        </div>
                                        <p></p>

                                        <div class="row">
                                            <div class="col-lg-12 textboxstyle category_bg">
                                                <label id="lblBG">VISA Payment Information</label>
                                            </div>
                                        </div>
                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label1" runat="server" Text="RRN  :"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="l_RRN" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                                            </div>
                                             <div class="col-md-3">
                                                    <asp:Label ID="Label2" runat="server" Text="EXCHANGE RATE  :"></asp:Label>
                                                </div>
                                             <div class="col-md-3">
                                                    <asp:Label ID="L_rate" runat="server" Text="Label"></asp:Label>
                                                </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                     <asp:Label ID="Label3" runat="server" Text="AMOUNT :"></asp:Label>
                                                </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_AMOUNT" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label4" runat="server" Text="LCY AMOUNT :"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_LCY_AMOUNT" runat="server" CssClass="textboxstyle"></asp:TextBox>
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
