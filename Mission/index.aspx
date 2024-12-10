<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Mission_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <style>
        .button_bg {
            background-color: #009da5;
        }
        .button3:hover {
            background-color: #f99d1c;
            color: black;
            border: 2px solid #009da5;
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

    <script type="text/javascript">
        function OpenPage() {
            this.parent.document.getElementById("frm2").src = "Mission_letter.aspx";
        }
    </script>

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

    <script type="text/javascript">  
        $(document).ready(function () {
            //$("#btnShowModal").click(function () {  
            //    $("#loginModal").modal('show');  
            //});  

            $("#btnHideModal").click(function () {
                $("#loginModal").modal('hide');
            });

            $('#btn_print_proxy').click(function () {
                document.getElementById("frm2").contentWindow.print();
            });
        });
    </script>


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
                                <h3 class="box-title" style="color: blue">Mission Pending</h3>
                            </div>
                            <div class="box-body">

                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:LinkButton ID="linkbtnnew" runat="server" CssClass="btn btn-sm btn-primary button_bg button3" OnClick="btnNew_Click"><i class="fa fa-plus fa-lg" style="color:green" aria-hidden="true"></i> Add</asp:LinkButton>
                                        <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary button_bg button3" OnClick="btnedit_click"><i class="fa fa-pencil fa-lg" style="color:blue" aria-hidden="true" ></i> Edit</asp:LinkButton>
                                        <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary button_bg button3" OnClick="btndel_Click"><i class="fa  fa-times fa-lg" style="color:red" aria-hidden="true" ></i> Delete</asp:LinkButton>
                                        <asp:LinkButton ID="LinkBtnview" runat="server" CssClass="btn btn-sm btn-primary button_bg button3" OnClick="btnview_Click"><i class="fa fa-eye fa-lg" style="color:orange" aria-hidden="true" ></i> View</asp:LinkButton>
                                        <asp:LinkButton ID="Linkprint" runat="server" CssClass="btn btn-sm btn-primary button_bg button3" OnClick="btnprint_click"><i class="fa fa-print fa-lg" style="color:black" aria-hidden="true" ></i> Print</asp:LinkButton>
                                    </div>
                                </div>
                                <p></p>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="grid1" DataKeyNames="ticket_no" CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false" OnRowCommand="grid1_RowCommand" OnPageIndexChanging="grid1_PageIndexChanging" PageSize="10" AllowPaging="true">
                                                <%--<AlternatingRowStyle BackColor="White" />--%>
                                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text="Check" align="center"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Check" runat="server" onclick="RadioCheck(this);" />

                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text="Edit" align="center"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="lnkedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-user fa-pencil" style="color:blue"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text="Delete" align="center"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="InkDelete" runat="server" CommandName="InkDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-user fa-trash-o" style="color:red"></i></asp:LinkButton>
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

                                <div class="row">
                                    <div class="col-md-12">

                                        <%--<div class="modal fade bd-example-modal-lg" id="iframe-open"
                                                                 tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" >
                                                              <div class="modal-dialog" style="width:80%;">
                                                                <div class="modal-content w-100">
                                                                  
                                                                        <div class="modal-header">
                                                                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                              <h4 class="modal-title">Mission letter</h4>
                                                                        </div>

                                                                    <div class="modal-body">
                                                                         <iframe id="frm2" runat="server" style="width:100%; height:1115px" > 
                                                                          </iframe>
                                                                    </div>

                                                                   <div class="modal-footer">
                                                                      <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                    </div>

                                                                  </div>
                                                               </div>
                                                            </div>--%>

                                        <div class="modal fade" style="display: none;" id="iframe-open">
                                            <div class="modal-dialog" style="width: 90%;">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span></button>
                                                        <h4 class="modal-title">Mission Letter</h4>
                                                    </div>
                                                    <div class="modal-body">
                                                        <button id="btn_print_proxy" style="margin-bottom: 10px;" class="btn btn-default">
                                                            <i class="fa fa-print"></i>Print</button>
                                                        <button type="button" class="btn btn-default" style="margin-bottom: 10px;" data-dismiss="modal">
                                                            <i class="fa fa-times"></i>Close</button>
                                                        <iframe id="frm2" runat="server" allowfullscreen="true" scrolling="yes" frameborder="0" style="width: 100%; height: 1155px;"></iframe>
                                                    </div>

                                                    <div class="modal-footer">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <%--End TopUp Dialog --%>
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
