<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="Ticket_view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
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
    </style>



</head>
<body>
    <form id="form1" runat="server">
             <section class="content">
                        <div class="row">
                            <div class="col-md-12">
                                    <div class="box box-primary">
                                            <div class="box-body box-profile">
                                            <div class="box-header">
                                                    <h3 class="box-title" style="color:blue">Ticket View</h3>
                                                </div>
                                                <div class="box-body">

                                                    <div class="row">
                                                       <div class="col-md-1">
                                                            <asp:Label ID="Label1" runat="server" Text="Ticket_no"></asp:Label>
                                                       </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="l_ticket_no" runat="server" Text="Label" ForeColor ="Red"></asp:Label>
                                                       </div>
                                                  
                                                   </div>

                                                 <div class="row">
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label23" runat="server" Text="Channel"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                     <asp:TextBox ID="t_Channel" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>

                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label24" runat="server" Text="Source_issue"></asp:Label>
                                                    </div>
                                                     <div class="col-md-3">
                                                     <asp:TextBox ID="t_source_issue" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label25" runat="server" Text="Assign_to"></asp:Label>
                                                    </div>
                                                     <div class="col-md-3">
                                                     <asp:TextBox ID="t_assign_to" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                 </div>

                                               <div class="row">
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label26" runat="server" Text="Branch_name"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_Branch" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label27" runat="server" Text="Problemtype"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_problem_type" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label28" runat="server" Text="User_name"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_user_name" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                </div>

                                                 <div class="row">
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label29" runat="server" Text="ATM_serial"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_atm_serial" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label30" runat="server" Text="issue_date"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_issue_date" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label31" runat="server" Text="Status"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_status" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                </div>

                                                 <div class="row">
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label32" runat="server" Text="P_Decription"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_Part_Decription" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label33" runat="server" Text="Start_date"></asp:Label>
                                    
                                                    </div>

                                                    <div class="col-md-3">
                                                            <div class="has-feedback">
                                                                <asp:TextBox ID="t_start_date" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                            </div>
                                                     </div>

                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label34" runat="server" Text="Inform"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="T_inform" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                </div>

                                                    <div class="row">
                                                        <div class="col-md-1">
                                                            <asp:Label ID="Label35" runat="server" Text="Part_Serial"></asp:Label>
                                    
                                                        </div>
                                                        <div class="col-md-3">
                                                        <asp:TextBox ID="t_part_serial" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:Label ID="Label36" runat="server" Text="End_date"></asp:Label>
                                    
                                                        </div>
                                                        <div class="col-md-3">
                                                        <asp:TextBox ID="t_end_date" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:Label ID="Label37" runat="server" Text="Root_issue"></asp:Label>
                                    
                                                        </div>
                                                        <div class="col-md-3">
                                                        <asp:TextBox ID="t_root_issue" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-md-1">
                                                            <asp:Label ID="Label38" runat="server" Text="Terminal"></asp:Label>
                                    
                                                        </div>
                                                        <div class="col-md-3">
                                                        <asp:TextBox ID="t_Terminal" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:Label ID="Label39" runat="server" Text="Phone"></asp:Label>
                                    
                                                        </div>
                                                        <div class="col-md-3">
                                                        <asp:TextBox ID="t_phone" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:Label ID="Label40" runat="server" Text="Decription"></asp:Label>
                                    
                                                        </div>
                                                        <div class="col-md-3">
                                                        <asp:TextBox ID="T_dec" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                 <div class="row">
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label41" runat="server" Text="Product_type"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_product_type" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label42" runat="server" Text="Router_Type"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_router_type" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Label ID="Label43" runat="server" Text="Solution"></asp:Label>
                                    
                                                    </div>
                                                    <div class="col-md-3">
                                                    <asp:TextBox ID="t_solution" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                    </div>
                                                </div>
                                                    <p></p>
                                                <div class="row">
                                                        <div class="col-lg-12 textboxstyle category_bg">
                                                            <label id="lblProbleminfo">Ticket listing</label>
                                                        </div>

                                                    </div>

                                                    <p></p>

                                                 <div class="row">
                                                     <div class="col-lg-12">
                                                              <div class="widget-contain table-responsive">
                                                              <asp:GridView ID="grid1" DataKeyNames="ticket_no" CssClass="table table-bordered table-hover" runat="server" Font-Size="Smaller" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                            <Columns>
                                                                            </Columns>
                                                              </asp:GridView>
                                                            </div>
                                                     </div>
                                                 </div>

                                                    <div class="row">
                                                        <div class=" col-lg-12">
                                                                <asp:Label ID="Label3" runat="server" Text="Records:" ForeColor="#3333FF"
                                                             Visible="true"></asp:Label>
                                                            <asp:Label ID="Label4" runat="server" Text="Label" Visible="true"></asp:Label>
                                                        </div>
                                                </div>

                                                    <div class="row">
                                                    <div class="col-lg-12" align="right">
                                                        <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="btncancel_Click1"><i class="fa  fa-times fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                                        <%--<asp:Button ID="btncancel" runat="server" Text="Cancel" class=" btn btn-sm btn-primary" onclick="btncancel_Click1" />--%>
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
