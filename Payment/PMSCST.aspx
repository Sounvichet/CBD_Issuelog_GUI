<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMSCST.aspx.cs" Inherits="Payment_PMSCST" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <style>
        .button_bg {
            background-color: #009da5;
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

        .table .gvHeaderCenter > th:first-child {
            position: sticky;
            left: -1px;
            background: #00a7a5;
        }

        .table tr > td:first-child {
            position: sticky;
            left: -1px;
            background: #fff;
        }

        .table-hover {
            margin-top: 0px;
        }
    </style>
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=grid1.ClientID%>");
            var rbs = gv.getElementsByTagName("input");
            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "checkbox") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        };
    </script>





</head>
<body>
    <form id="form1" runat="server">


        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <div class="box-header with-border">
                                <i class="fa fa-ticket"></i>
                                <h3 class="box-title" style="color: blue">ATMCard Fee Maintenance Pending</h3>
                            </div>
                            <div class="box-body">
                                <asp:ScriptManager ID="SMticketindex" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="Updateticketindex" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="btnedit_click"><i class="fa fa-pencil fa-lg" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                                                <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="btndel_Click" Visible ="false" ><i class="fa fa-times fa-lg" style="color:red" aria-hidden="true" ></i> Delete</asp:LinkButton>
                                            </div>

                                            <div class="col-md-6" align="right">
                                                <asp:Label ID="Label1" runat="server" Text="CARD_ID"></asp:Label>
                                                <asp:TextBox ID="t_search" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                                <asp:LinkButton ID="Linkbtnsearch" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Linkbtnsearch_Click"><i class="fa fa-search fa-lg" aria-hidden="true" ></i> Search</asp:LinkButton>
                                                <%--btn_apply_Click--%>
                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="grid1" DataKeyNames="card_id" CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" OnRowCommand="grid1_RowCommand" PageSize="10" AllowPaging="true">
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
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="lnkedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Style="margin-left: 30px; margin-right: 30px"><i class= "fa fa-pencil"></i></asp:LinkButton>
                                                                </ItemTemplate>
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

                                    </ContentTemplate>
                                    <Triggers>
                                        <%--  <asp:PostBackTrigger ControlID="LinkbtnExport" />--%>
                                    </Triggers>
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
