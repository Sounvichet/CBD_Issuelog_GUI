<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="COMPANY_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/plugins/fontawesome-free/css/all.min.css")%>" rel="stylesheet" type="text/css" />

    <style>
        .color-palette {
            height: 35px;
            line-height: 35px;
            text-align: right;
            padding-right: .75rem;
        }

            .color-palette.disabled {
                text-align: center;
                padding-right: 0;
                display: block;
            }

        .color-palette-set {
            margin-bottom: 15px;
        }

        .color-palette span {
            display: none;
            font-size: 12px;
        }

        .color-palette:hover span {
            display: block;
        }

        .color-palette.disabled span {
            display: block;
            text-align: left;
            padding-left: .75rem;
        }

        .color-palette-box h4 {
            position: absolute;
            left: 1.25rem;
            margin-top: .75rem;
            color: rgba(255, 255, 255, 0.8);
            font-size: 12px;
            display: block;
            z-index: 7;
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

        .user-control {
            padding-top: 5px;
        }

        .gvItemCenter {
            text-align: center;
        }

        .gvHeaderCenter {
            text-align: center;
        }

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

            //setTimeout(function () {
            //    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
            //        $("#alert_div").remove();
            //    });
            //}, 5000);//5000=5 seconds
        };


    </script>

    <%--<script type="text/javascript">
            jQuery(function ($) {{
                    $("#<%=txtS_date.ClientID %>").datepicker({
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

                $("#<%=txtE_date.ClientID %>").datepicker({
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

            }
            });
    </script>--%>
</head>
<body style="background-color: #ecf0f5">
    <form id="form1" runat="server">
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <div class="box-header with-border">
                                <i class="fa fa-file-text"></i>
                                <h3 class="box-title" style="color: blue">COMPANY INFROMATION</h3>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:LinkButton ID="linkbtnnew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="linkbtnnew_Click"><i class="fa fa-plus" style="color:green" aria-hidden="true"></i> Add</asp:LinkButton>
                                        <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkbtnedit_Click1"><i class="fa fa-pencil" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                                        <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtndel_Click"><i class="fa  fa-times" style="color:red" aria-hidden="true" ></i> Delete</asp:LinkButton>
                                        <asp:LinkButton ID="LinkBtnview" runat="server" CssClass="btn btn-sm btn-primary" OnClick="LinkBtnview_Click"><i class="fa fa-eye" style="color:orange" aria-hidden="true" ></i> View</asp:LinkButton>
                                        <asp:LinkButton ID="Linkprint" runat="server" CssClass="btn btn-sm btn-primary" OnClick="Linkprint_Click"><i class="fa fa-print" style="color:black" aria-hidden="true" ></i> Print</asp:LinkButton>
                                    </div>

                                </div>

                                <div class="row user-control">
                                    <div class="col-lg-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="grid1" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" OnRowCommand="grid1_RowCommand" OnPageIndexChanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true">
                                                <%-- <AlternatingRowStyle BackColor="White" />--%>

                                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />
                                                <Columns>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);" />
                                                            <%--<input type ="checkbox" runat="server" onclick ="RadioCheck(this);" checked="checked"/>--%>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="lnkedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Style="margin-left: 30px; margin-right: 30px"><i class= "fas fa-edit"></i></asp:LinkButton>
                                                            <asp:LinkButton ID="InkDelete" runat="server" CommandName="InkDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Style="margin-right: 30px"><i class= "far fa-trash-alt"> </i></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkView" runat="server" CommandName="lnkView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Style="margin-right: 30px"><i class= "fa fa-eye"> </i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="gvItemCenter" />
                                                        <HeaderStyle CssClass="gvHeaderCenter" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="Label3" runat="server" Text="Records:" ForeColor="#3333FF" Visible="true"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text="Label" Visible="true"></asp:Label>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <!-- /.card -->
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>
    </form>
</body>
</html>
