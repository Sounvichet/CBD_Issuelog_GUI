<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TBSWEDIT.aspx.cs" Inherits="Payment_TBSWEDIT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                $("#<%=t_htb_confirm_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });
                $("#<%=t_party_confirm_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });
                $("#<%=t_send_to_branch.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });
                 $("#<%=t_Received_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y",
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
            $("#<%=t_htb_confirm_date.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%m/%d/%Y", //%H:%M:%S
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
            $("#<%=t_party_confirm_date.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%m/%d/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
            $("#<%=t_send_to_branch.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%m/%d/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
             $("#<%=t_Received_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y",
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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert  ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span>' + message + '</span></div>');

            //setTimeout(function () {
            //    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
            //        $("#alert_div").remove();
            //    });
            //}, 5000);//5000=5 seconds
        };


        function Enable() {
            $("#Linkbtnsave").attr('disabled', false);
        };
        function Disable() {
            $("#Linkbtnsave").attr('disabled', true);
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
                                <h3 class="box-title" style="color: blue">Edit Disputed</h3>
                            </div>
                            <div class="box-body">
                                <asp:ScriptManager ID="SMTBSWEDIT" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UPDATETBSWEDIT" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>




                                        <div class="row user-control">
                                            <div class="col-md-12">
                                                <Button ID="Linkbtnsave" class ="btn btn-sm btn-primary button_bg" runat="server"  onserverclick ="Linkbtnsave_Click" onclick ="$('#loading').show();"  ><i class="fa fa-save fa-lg" aria-hidden="true"></i> Save</Button>
                                                
                                                <asp:LinkButton ID="LinkBtncal"  runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="LinkBtncal_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>

                                                <%--<asp:Button ID="btnedit" runat="server" CssClass="btn btn-sm btn-primary" Text="Edit" OnClick="btnedit_Click"></asp:Button>
                                                         <asp:Button ID="btnsave_edit" runat="server" CssClass="btn btn-sm btn-primary"  Text="Save" Enabled="false" OnClick="btnsave_Click"></asp:Button>
                                                         <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-sm btn-primary"  Text="Cancel"  OnClick="btnCancel_Click"></asp:Button>                    --%>
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
                                        <p></p>

                                        <div class="row user-control">
                                            <div class="col-lg-12 textboxstyle category_bg">
                                                <label id="lblBG">Transaction information</label>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label20" runat="server" Text="CHANNEL"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="d_channel" runat="server" CssClass="textboxstyle" Width="100%">
                                                    <asp:ListItem>WING</asp:ListItem>
                                                    <asp:ListItem>TRUE_MONEY</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label21" runat="server" Text="TRN_REF"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="l_trn_ref" runat="server" ForeColor="Blue"></asp:Label>
                                            </div>
                                        </div>
                                        <%--New enhancement update--%>
                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label1" runat="server" Text="Received_date"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_Received_date" runat="server" CssClass="textboxstyle" Width="85%"></asp:TextBox>
                                                <asp:Image ID="Image1" src="../Image/calender.png" runat="server"/>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label2" runat="server" Text="Dispute_type"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="d_Dispute_type" runat="server" CssClass="textboxstyle" Width="100%"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label3" runat="server" Text="Correct_Amount"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_Correct_Amount" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label4" runat="server" Text="Adjustment_Amount"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_Adjustment_Amount" runat="server" CssClass="textboxstyle" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
     
                                        <%--end --%>


                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label22" runat="server" Text="STATUS"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="t_status" runat="server" CssClass="textboxstyle" Width="100%">
                                                    <asp:ListItem>In_progress</asp:ListItem>
                                                    <asp:ListItem>Solved</asp:ListItem>
                                                    <asp:ListItem>Closed</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label23" runat="server" Text="HTB_CONFIRM_DATE"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_htb_confirm_date" runat="server" CssClass="textboxstyle" Width="85%"></asp:TextBox>
                                                <asp:Image ID="Image2" src="../Image/calender.png" runat="server"/>
                                            </div>
                                        </div>

                                        <div class="row user-control">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label24" runat="server" Text="Third_party_confirm_date"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_party_confirm_date" runat="server" CssClass="textboxstyle" Width="85%"></asp:TextBox>
                                                <asp:Image ID="Image3" src="../Image/calender.png" runat="server"/>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label26" runat="server" Text="SEND_TO_BRANCH"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_send_to_branch" runat="server" CssClass="textboxstyle" Width="85%"></asp:TextBox>
                                                <asp:Image ID="Image4" src="../Image/calender.png" runat="server"/>
                                            </div>

                                        </div>

                                        <div class="row user-control">
                                             <%--new enhancement update --%>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label5" runat="server" Text="Adjustment_Method"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="d_Adjustment_Method" runat="server" CssClass="textboxstyle" Width="100%">
                                                    <asp:ListItem>Full_amount</asp:ListItem>
                                                    <asp:ListItem>Patial_amount</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <%--end --%>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label25" runat="server" Text="DEPT_REMARK"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="t_dept_remark" runat="server" TextMode="MultiLine" CssClass="textboxstyle form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <%-- <asp:PostBackTrigger ControlID="d_Disputed_status" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </div>
        </section>
    </form>
</body>
</html>
