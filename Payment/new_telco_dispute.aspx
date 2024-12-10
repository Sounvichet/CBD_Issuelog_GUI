<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_telco_dispute.aspx.cs" Inherits="Payment_new_biller_dispute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap 3.3.7 -->
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    
    <style>
        .button_bg {
            background-color: #009da5;
        }

        .category_bg {
            background-color: #f99d1c;
        }
        .gvItemCenter { text-align: center; }
        .gvHeaderCenter {  text-align: center; }
        .lds-roller {
  display: inline-block;
  position: relative;
  width: 80px;
  height: 80px;
}
.lds-roller div {
  animation: lds-roller 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
  transform-origin: 40px 40px;
}
.lds-roller div:after {
  content: " ";
  display: block;
  position: absolute;
  width: 7px;
  height: 7px;
  border-radius: 50%;
  background: #cef;
  margin: -4px 0 0 -4px;
}
.lds-roller div:nth-child(1) {
  animation-delay: -0.036s;
}
.lds-roller div:nth-child(1):after {
  top: 63px;
  left: 63px;
}
.lds-roller div:nth-child(2) {
  animation-delay: -0.072s;
}
.lds-roller div:nth-child(2):after {
  top: 68px;
  left: 56px;
}
.lds-roller div:nth-child(3) {
  animation-delay: -0.108s;
}
.lds-roller div:nth-child(3):after {
  top: 71px;
  left: 48px;
}
.lds-roller div:nth-child(4) {
  animation-delay: -0.144s;
}
.lds-roller div:nth-child(4):after {
  top: 72px;
  left: 40px;
}
.lds-roller div:nth-child(5) {
  animation-delay: -0.18s;
}
.lds-roller div:nth-child(5):after {
  top: 71px;
  left: 32px;
}
.lds-roller div:nth-child(6) {
  animation-delay: -0.216s;
}
.lds-roller div:nth-child(6):after {
  top: 68px;
  left: 24px;
}
.lds-roller div:nth-child(7) {
  animation-delay: -0.252s;
}
.lds-roller div:nth-child(7):after {
  top: 63px;
  left: 17px;
}
.lds-roller div:nth-child(8) {
  animation-delay: -0.288s;
}
.lds-roller div:nth-child(8):after {
  top: 56px;
  left: 12px;
}
@keyframes lds-roller {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}

        :root { 
    --htb: #009FA5; 
    --primary: #009FA5; 
    --htb-light: #80CFD2; 
    --white: #ffffff; 
    --grey: grey; 
    --half-white: rgba(255, 255, 255, 0.5); 
    --border-nomal: #ced4da; 
}
        #loading { 
    position: fixed; 
    top: 0; 
    left: 0; 
    bottom: 0; 
    right: 0; 
    width: 100%; 
    height: 100%; 
    /* display: none; */ 
    margin: 0 auto; 
    text-align: center; 
    background: rgba(0, 159, 165, 0.7); 
    text-align: center; 
    transition: visibility 0s, opacity 0.5s linear; 
    z-index: 100000; 
    display: none; 
    backdrop-filter: blur(6px); 
} 
 
#loading .loading-content { 
    position: absolute; 
    left: 50%; 
    top: 50%; 
    -webkit-transform: translate(-50%, -50%); 
    transform: translate(-50%, -50%); 
} 
 
#loading .spinner-bg { 
    /* width: 50px; */
    /* height: 50px; */
    margin: 0 auto;
    padding: 9px;
    /* background: #ffffff; */
    border-radius: 50%;
} 
 
#loading .spinner-bg .spinner-border { 
    color: #009FA5;  /*var(--htb)*/
} 
 
#loading .spinner-content { 
    text-align: center; 
    margin: 15px auto; 
    font-weight: 400; 
    color: #ffffff; 
}
        .form-control{
            font-size:15px;
            border-radius:5px 5px 5px 5px;
            padding:2px 2px 2px 2px;
            height:auto;
            margin: 0 auto;
        } 
        .user-control
         {
         padding-top:5px;
         }
         .textboxstyle
            {
                font-size:15px;
                border-radius:5px 5px 5px 5px;
                border:1px solid #c4c4c4;
                padding:2px 2px 2px 2px;
                vertical-align:middle!important;
                /*text-align:center!important;*/
                }
            .textboxstyle:focus
            {
                border:1px solid #7bc1f7;
            }
             textarea
        {
            resize: none;
        }
        .tdalign {
                vertical-align: middle !important;
                text-align: center !important;
        }

        .getscrollcolor a:hover {
            background-color:black;
            color: gray;
        }

      
        .align-middle a:hover {
        background-color:#f99d1c;
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
                $("#<%=t_resolved_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y ",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

            }
        });

    </script>
    <script type="text/javascript">
        jQuery(function ($) {
            $("#<%=t_resolved_date.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%m/%d/%Y ",
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
<body >
    <form id="form1" runat="server">
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <div class="box-header">
                                <h3 class="box-title" style="color: blue">Register telco Dispute Ticket</h3>
                            </div>
                            <div class="box-body">

                                <asp:ScriptManager ID="SM_wing_dispute" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="Update_wing_dispute" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>

                                        <div class="row">
                                            <div class="col-lg-12" align="left">
                                                <asp:LinkButton ID="linkbtnsave" runat="server" class="btn btn-sm btn-primary button_bg" OnClick="btn_save_Click"><i class="fa fa-save fa-lg" aria-hidden="true"></i> Save</asp:LinkButton>
                                                <asp:LinkButton ID="linkbtncacel" runat="server" class="btn btn-sm btn-primary button_bg" OnClick="btn_cancel_Click"><i class="fa fa-backward fa-lg" aria-hidden="true"></i> Cancel</asp:LinkButton>
                                                <%-- <asp:Button ID="btn_save" runat="server" Text="Save" 
                                                                    class="btn btn-sm btn-primary" onclick="btn_save_Click" />--%>
                                                <%--  <asp:Button ID="btn_cancel" runat="server" Text="Cancel" 
                                                                    class="btn btn-sm btn-primary" onclick="btn_cancel_Click" />  --%>
                                            </div>
                                        </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <!-- Loading -->
                                        <a href="javascript:;" id="testClick"></a>
                                        <div id="loading">
                                            <div class="loading-content">
                                                <p style="color: #ffffff;">Processing...</p>
                                                <div class="spinner-bg">
                                                    <div class="lds-roller">
                                                        <div></div>
                                                        <div></div>
                                                        <div></div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>


                                        <div class="row user-control">
                                            <div class="col-md-12">
                                                <div id="alert_container">
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row user-control">
                                            <div class="col-lg-12 textboxstyle category_bg">
                                                <label id="lblBG">Transaction information</label>
                                            </div>
                                        </div>

                                        <div class="row user-control">

                                            <div class="col-md-3">TRN Reference</div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_Ticket_no" runat="server" CssClass="textboxstyle" Style="color: Blue"></asp:TextBox>
                                                <button ID="Linkbtnsearch" class ="btn btn-sm btn-primary button_bg" runat="server"  onserverclick ="Linkbtnsearch_Click" onclick ="$('#loading').show();"  ><i class="fa fa-search" aria-hidden="true"></i></button>
                                                <%--<a id="d_Review" href="#" class="fa fa-search" style="color: black; height: auto; margin-left: 10px;" onserverclick="Linkbtnsearch_Click" onclick="$('#loading').show();"" runat="server"></a>--%>
                                                <%--<asp:LinkButton ID="Linkbtnsearch" runat="server" class="btn btn-sm btn-primary button_bg" onclick="Linkbtnsearch_Click"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>--%>
                                            </div>

                                            <div class="col-md-3">BRANCH_CODE</div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_branch_Code" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label7" runat="server" Text="CUSTOMER_ID"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_customer_id" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label11" runat="server" Text="CUSTOMER_NAME"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_customer_name" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label12" runat="server" Text="SERVICE_TYPE"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_service_type" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label13" runat="server" Text="SUB_SERVICE"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_sub_service" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label14" runat="server" Text="TYPE_OF_PIN"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_type_of_pin" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label15" runat="server" Text="CCY"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_ccy" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label16" runat="server" Text="TXN_AMOUNT"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_txn_amount" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label19" runat="server" Text="FEE_AMOUNT"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_fee_amount" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label20" runat="server" Text="TOTAL_AMOUNT"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_total_amount" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label21" runat="server" Text="CBS_REF"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_cbs_ref" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label22" runat="server" Text="HTB_EX_REF"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_htb_ex_ref" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label23" runat="server" Text="DEBIT ACCOUNT"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_debit_account" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label24" runat="server" Text="CREDIT ACCOUNT"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_credit_account" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label25" runat="server" Text="TXN_DATE"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_txn_date" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label2" runat="server" Text="Partner_ref"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_partner_ref" runat="server" CssClass="textboxstyle" ForeColor="Blue"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-lg-12 textboxstyle category_bg">
                                                <label id="l_additional">Additional information</label>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label6" runat="server" Text="STATUS"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="d_status" runat="server" CssClass="textboxstyle">
                                                    <asp:ListItem>SUCCESS</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label3" runat="server" Text="Issue_type"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="d_issue_type" runat="server" CssClass="textboxstyle"></asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label4" runat="server" Text="Solution"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_Solution" runat="server" CssClass="textboxstyle" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label1" runat="server" Text="Resolved_date"></asp:Label>
                                                </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_resolved_date" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                                <asp:Image ID="Image2" src="../Image/calender.png" runat="server"/>
                                                </div>                                            
                                            <div class="col-md-3">
                                                <asp:Label ID="Label5" runat="server" Text="Remark"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_Remark" runat="server" CssClass="textboxstyle" TextMode="MultiLine" Width="95%"></asp:TextBox>
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
