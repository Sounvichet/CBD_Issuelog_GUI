<%@ Page Language="C#" AutoEventWireup="true" CodeFile="getmission.aspx.cs" Inherits="Ticket_getmission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
            <!-- Bootstrap 3.3.7 -->
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />


    <style type="text/css">
        .button_bg {
        background-color:#009da5;
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

        .category_bg {
            background-color: #f99d1c;
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
     <script type="text/javascript">
     jQuery(function ($) {
         $("#<%=t_Start_date.ClientID %>").dynDateTime({
             showsTime: true,
             ifFormat: "%m/%d/%Y %H:%M:%S",
             daFormat: "%l;%M %p, %e %m,  %Y",
             align: "BR",
             electric: false,
             singleClick: false,
             displayArea: ".siblings('.dtcDisplayArea')",
             button: ".next()"
         });

         $("#<%=t_End_date.ClientID %>").dynDateTime({
             showsTime: true,
             ifFormat: "%m/%d/%Y %H:%M:%S",
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
                     $("#<%=t_Start_date.ClientID %>").dynDateTime({
                         showsTime: true,
                         ifFormat: "%m/%d/%Y %H:%M:%S",
                         daFormat: "%l;%M %p, %e %m,  %Y",
                         align: "BR",
                         electric: false,
                         singleClick: false,
                         displayArea: ".siblings('.dtcDisplayArea')",
                         button: ".next()"
                     });

                     $("#<%=t_End_date.ClientID %>").dynDateTime({
                         showsTime: true,
                         ifFormat: "%m/%d/%Y %H:%M:%S",
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
</head>
<body>
    <form id="form1" runat="server">
            <section class="content">
               <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header">
                                                <h3 class="box-title" style="color:blue">Register Mission</h3>
                                            </div>
                                            <div class="box-body">
                                                <asp:ScriptManager ID="SMmissnew" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdateticketNew1" UpdateMode="Conditional" runat="server">
									                                <ContentTemplate>

                                                           <div class="row">
                                                                    <div class="col-md-12">
                                                                        <div  id="alert_container">
                                                         
                                                                    </div>
                                                                </div>
                                                              </div>
                                                        <p></p>

                                                            <div class = "row">
                                                                <div class = "col-md-12" align = "left">
                                                                    <asp:LinkButton ID="Linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Button1_Click"><i class="fa fa-save fa-lg" aria-hidden="true" ></i> Save</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkBtncancel" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="Button2_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                                                </div>
                                                            </div>
                                                                <p></p>
                                                            <div class="row">
                                                                <div class="col-lg-12 textboxstyle category_bg" >
                                                                    <label id="lblBrn">Branch Information</label>
                                                                </div>
                                                            </div>
                                                                <p></p>
                                                          <div class="row">
                                                              <div class="col-md-3">
                                                                  <asp:Label ID="Label25" runat="server" Text="Ticket_No"></asp:Label>
                                                              </div>
                                                              <div class="col-md-3">
                                                                  <asp:Label ID="L_ticket_no" runat="server" ForeColor="Blue"></asp:Label>
                                                              </div>
                                                          </div>

                                                          <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label1" runat="server" Text="Branch_Name"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox id="t_branch_name" runat="server" CssClass = "textboxstyle" ></asp:TextBox>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label2" runat="server" Text="Terminal"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Terminal" runat="server" CssClass = "textboxstyle" ></asp:TextBox>
                                                                </div>
                                                            </div>

                                                           <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label3" runat="server" Text="Product_Type"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Product_Type" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label4" runat="server" Text="Model_Type"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Model_Type" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                           

                                                           <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label22" runat="server" Text="Problem_Type"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:DropDownList ID="d_Problem_Type" runat="server" CssClass = "textboxstyle" Width = "82%">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="Label24" runat="server" Text="Problem_desc"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-9">
                                                                    <asp:TextBox ID="T_Problem_desc" runat="server" Width= "95%" TextMode="MultiLine" CssClass = "textboxstyle"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                         <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label5" runat="server" Text="Equitment"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-9">
                                                                    <asp:TextBox ID="t_Equitment" runat="server" Width= "95%" TextMode="MultiLine" CssClass = "textboxstyle"></asp:TextBox>
                                                                </div>
                                   
                                                            </div>

                                                             <p></p>
                                                            <div class="row">
                                                                <div class="col-lg-12 textboxstyle category_bg" >
                                                                    <label id="lblFC">FC Engineer 1</label>
                                                                </div>
                                                            </div>
                                                            <p></p>

                                                          <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label6" runat="server" Text="Name"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:DropDownList ID="d_Name_1" runat="server" CssClass = "textboxstyle" Width = "82%" AutoPostBack = "true" 
                                                                        onselectedindexchanged="d_Name_1_SelectedIndexChanged"> 
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label7" runat="server" Text="Position"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Position_1" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                         <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label8" runat="server" Text="Company"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Company_1" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label9" runat="server" Text="Phone" ></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Phone_1" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                          <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label10" runat="server" Text="Staff_ID"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Staff_ID_1" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label11" runat="server" Text="Gender"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Gender_1" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <p></p>
                                                            <div class="row">
                                                                <div class="col-lg-12 textboxstyle category_bg" >
                                                                    <label id="lblFC2">FC Engineer 2</label>
                                                                </div>
                                                            </div>
                                                            <p></p>

                                                         <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label12" runat="server" Text="Name"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:DropDownList ID="d_Name_2" runat="server" CssClass = "textboxstyle" AutoPostBack = "true" 
                                                                        onselectedindexchanged="d_Name_2_SelectedIndexChanged" Width = "82%">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label13" runat="server" Text="Position"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Position_2" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        <div class = "row">
                                                            <div class = "col-md-3">
                                                                <asp:Label ID="Label14" runat="server" Text="Company"></asp:Label>
                                                            </div>
                                                            <div class = "col-md-3">
                                                                <asp:TextBox ID="t_Company_2" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                            </div>
                                                            <div class = "col-md-3">
                                                                <asp:Label ID="Label15" runat="server" Text="Phone"></asp:Label>
                                                            </div>
                                                            <div class = "col-md-3">
                                                                <asp:TextBox ID="t_Phone_2" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </div>


                                                            <div class = "row">
                                                                    <div class = "col-md-3">
                                                                        <asp:Label ID="Label16" runat="server" Text="Staff_ID"></asp:Label>
                                                                    </div>
                                                                    <div class = "col-md-3">
                                                                        <asp:TextBox ID="t_Staff_ID_2" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                                    </div>
                                                                    <div class = "col-md-3">
                                                                        <asp:Label ID="Label17" runat="server" Text="Gender"></asp:Label>
                                                                    </div>
                                                                    <div class = "col-md-3">
                                                                        <asp:TextBox ID="t_Gender_2" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            <p></p>
                                                            <div class="row">
                                                                <div class="col-lg-12 textboxstyle category_bg" >
                                                                    <label id="lblDRT">Duration</label>
                                                                </div>
                                                            </div>
                                                            <p></p>

                                                         <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label18" runat="server" Text="Start_date"></asp:Label>
                                                                    <strong style="color:red">*</strong>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="t_Start_date" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                                    <asp:Image ID="Image2" src="../Image/calender.png" runat="server"/>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label19" runat="server" Text="End_date"></asp:Label>
                                                                    <strong style="color:red">*</strong>
                                                                </div>
                                                                 <div class = "col-md-3">
                                                                     <asp:TextBox ID="t_End_date" runat="server" CssClass = "textboxstyle" OnTextChanged="t_End_date_TextChanged1" AutoPostBack="true" ></asp:TextBox>
                                                                     <asp:Image ID="Image1" src="../Image/calender.png" runat="server"/>
                                                                     
                                                                </div>
                                                            </div>


                                                         <div class = "row">
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label20" runat="server" Text="Day"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="D_days" runat="server" CssClass = "textboxstyle" Enabled="false"> </asp:TextBox>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:Label ID="Label21" runat="server" Text="Night"></asp:Label>
                                                                </div>
                                                                <div class = "col-md-3">
                                                                    <asp:TextBox ID="d_nights" runat="server" CssClass = "textboxstyle" Enabled="false"> </asp:TextBox>
                                                                </div>
                                                            </div>

                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="Label23" runat="server" Text="ActionType"></asp:Label>
                                                            </div>
                                                             <div class="col-md-3">
                                                                <asp:DropDownList ID="D_ActionType" runat="server" CssClass = "textboxstyle"></asp:DropDownList>
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
