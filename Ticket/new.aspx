<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new.aspx.cs" Inherits="Ticket_new" %>

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
        .category_bg {
        background-color:#f99d1c;
        }
        .button3:hover {
            background-color: #f99d1c;
            color: black;
            border: 2px solid #009da5;
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
             .user-control
         {
         padding-top:5px;
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
                $("#<%=t_Issue_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y ",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

                $("#<%=t_Start_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y %H:%M",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

                $("#<%=t_end_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y %H:%M",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });
            }});

        </script>
    <script type="text/javascript">
        jQuery(function ($) {
                $("#<%=t_Issue_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y ",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

                $("#<%=t_Start_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y %H:%M",
                    daFormat: "%l;%M %p, %e %m,  %Y",
                    align: "BR",
                    electric: false,
                    singleClick: false,
                    displayArea: ".siblings('.dtcDisplayArea')",
                    button: ".next()"
                });

                $("#<%=t_end_date.ClientID %>").dynDateTime({
                    showsTime: true,
                    ifFormat: "%m/%d/%Y %H:%M",
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

            //setTimeout(function () {
            //    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
            //        $("#alert_div").remove();
            //    });
            //}, 5000);//5000=5 seconds
        };

      
    </script>

</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
               <section class="content">
                        <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header">
                                                <h3 class="box-title" style="color:blue">Register Ticket</h3>
                                            </div>
                                            <div class="box-body">
                                                <asp:ScriptManager ID="SMticketnew" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdateticketNew1" UpdateMode="Conditional" runat="server">
								                        <ContentTemplate>
                                                    <div class="row">
                                                           <div class="col-lg-12" align="left">
                                                               <asp:LinkButton ID="linkbtnsave" runat="server" class="btn btn-sm btn-primary button_bg button3" onclick="btn_save_Click"  ><i class="fa fa-save fa-lg" aria-hidden="true"></i> Save</asp:LinkButton>
                                                               <asp:LinkButton ID="linkbtncacel" runat="server" class="btn btn-sm btn-primary button_bg button3" onclick="btn_cancel_Click"  ><i class="fa fa-backward fa-lg" aria-hidden="true"></i> Cancel</asp:LinkButton>
                                                               <%-- <asp:Button ID="btn_save" runat="server" Text="Save" 
                                                                    class="btn btn-sm btn-primary" onclick="btn_save_Click" />--%>
                                                              <%--  <asp:Button ID="btn_cancel" runat="server" Text="Cancel" 
                                                                    class="btn btn-sm btn-primary" onclick="btn_cancel_Click" />  --%>
                                                           </div>
                                                   </div>
                                                       
                                                            <div class="row user-control">
                                                            <div class="col-md-12">
                                                                <div  id="alert_container">
                                                            </div>
                                                        </div>
                                                      </div>

                                                 
                                                     <div class="row user-control">
                                                        <div class="col-lg-12 textboxstyle category_bg">
                                                            <label id="lblBG">ATM information</label>
                                                        </div>
                                                    </div>
                                                    
                                                      <div class="row user-control">
                                                            <div class="col-md-3">Ticket No</div>
                                                            <div class="col-md-3">
                                                            <input name="Ticket_no" type="text" value="************" id="t_Ticket_no" disabled="disabled" class="aspNetDisabled  textboxstyle" style="color:Blue;width:100%"  />
                                                            </div>
                                                                <%--<asp:TextBox ID="Ticket_no" runat="server" disabled="disabled" class = "textboxstyle" ></asp:TextBox></div>--%>
                                                            <div class="col-md-3">Channel</div>
                                                            <div class ="col-md-3">
                                                                <asp:DropDownList ID="Channel" runat="server" CssClass = "textboxstyle" Width="100%" 
                                                                 AutoPostBack="true" onselectedindexchanged="Channel_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                      </div>

                                                    <div class="row user-control">
                                                            <div class="col-md-3"> <asp:Label ID="l_Branch_name" runat="server" 
                                                                    Text="Branch_name" Visible="true"></asp:Label></div>
                                                            <div class="col-md-3">
                                                                 <asp:DropDownList ID="D_Branch_name" runat="server" CssClass = "textboxstyle" 
                                                                  Width="100%" AutoPostBack = "true" 
                                                                     onselectedindexchanged="D_Branch_name_SelectedIndexChanged" 
                                                                     Visible="true">
                                                                 </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-3">
                                                                 <asp:Label ID="l_Terminal" runat="server" Text="Terminal" Visible="true"></asp:Label>

                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:DropDownList ID="t_Terminal" runat="server" CssClass = "textboxstyle" Width="100%" Enabled="true" Visible="true" OnSelectedIndexChanged="t_Terminal_SelectedIndexChanged" AutoPostBack = "true"></asp:DropDownList>
                               
                                                            </div>
                      
                                                   </div>

                                                 <div class="row user-control">
                                                       <div class="col-md-3"><asp:Label ID="l_Part_Decription" runat="server" 
                                                               Text="OS_Version" Visible="true"></asp:Label>
                                                       </div>
                                                       <div class="col-md-3">
                                                            <asp:TextBox ID="T_OS" runat="server" CssClass = "textboxstyle" Width="100%"
                                                                Visible="true" Enabled = "false"></asp:TextBox>
                                                           </div>
                                                       <div class="col-md-3">
                                                       <asp:Label ID="l_Part_Serial" runat="server" Text="Part_Serial" Visible="true"></asp:Label>
                                                       </div>
                                                       <div class="col-md-3">
                                                           <asp:TextBox ID="t_Part_Serial" runat="server" CssClass = "textboxstyle"  Width="100%"
                                                               Visible="true" Enabled = "false"></asp:TextBox>
                                                       </div>
                                               </div>

                                                  <div class="row user-control">
                                                           <div class="col-md-3">
                                                              <asp:Label ID="l_ATM_serial" runat="server" Text="ATM_serial" Visible="true"></asp:Label>
                                                              </div>
                                                           <div class="col-md-3">
                                                                 <asp:TextBox ID="t_ATM_serial" runat="server" class = "textboxstyle" Width="100%" 
                                                                    Visible="true" Enabled = "false"></asp:TextBox>
                                                           </div>

                                                           <div class="col-md-3">
                                                               <asp:Label ID="l_Product_Type" runat="server" Text="Product_Type" 
                                                                   Visible="true"></asp:Label>
                                                           </div>

                                                           <div class="col-md-3">
                                                               <asp:TextBox ID="t_Product_Type" runat="server" CssClass = "textboxstyle"  Width="100%"
                                                                   Visible="true" Enabled = "false"></asp:TextBox>
                                                           </div>
                                                   </div>
                                                
                                                 <div class="row user-control">
                                                        <div class="col-lg-12 textboxstyle category_bg">
                                                            <label id="lblProbleminfo">Problem Information</label>
                                                        </div>

                                                    </div>
                                                
                                                    <div class="row user-control">
                                                           <div class="col-md-3"><asp:Label ID="l_Source_Issue" runat="server" 
                                                                   Text="ReasonGroup" Visible="true"></asp:Label></div>
                                                           <div class="col-md-3">
                                                               <asp:DropDownList ID="D_Source_Issue" runat="server"
                                                                Width="100%" AutoPostBack = "true" CssClass = "textboxstyle" 
                                                                   onselectedindexchanged="D_Source_Issue_SelectedIndexChanged" 
                                                                   Visible="true">
                                                               </asp:DropDownList>
                                                           </div>  
                                                             <div class="col-md-3">
                                                                <asp:Label ID="l_Issue_date" runat="server" Text="Issue_date" Visible="true"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="t_Issue_date" runat="server" CssClass = "textboxstyle" 
                                                                 Width="85%" Visible="true"></asp:TextBox>
                                                                <asp:Image ID="Image2" src="../Image/calender.png" runat="server" 
                                                                    Visible="true"/>
                                                            </div>  
                                                   </div>

                                                   <div class ="row user-control">
                       
                                                          <div class="col-md-3"><asp:Label ID="L_Cause_of_issue" runat="server" 
                                                                   Text="ReasonType" Visible="true"></asp:Label></div>
                                                           <div class="col-md-3">
                                                                        <asp:DropDownList ID="d_Cause_of_issue" runat="server" Width="100%" CssClass = "textboxstyle"  
                                                                            Visible="true">
                                                                        </asp:DropDownList>
                                                           </div>

                                                             <div class="col-md-3">
                                                                <asp:Label ID="Start_date" runat="server" Text="Start_date" Visible="true"></asp:Label>
                                                            </div>

                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="t_Start_date" runat="server" CssClass = "textboxstyle" 
                                                                Width="85%" Visible="true"></asp:TextBox>
                                                                <asp:Image ID="Image1" src="../Image/calender.png" runat="server" 
                                                                    Visible="true"/>
                                                            </div>
                                                   </div>

                                                            <div class = "row user-control">
                                                          
                                                           <div class="col-md-3">
                                                                <asp:Label ID="L_status" runat="server" Text="Status" Visible="true"></asp:Label>
                                                           </div>

                                                           <div class="col-md-3">
                                                               <asp:DropDownList ID="D_Status" runat="server" CssClass = "textboxstyle" 
                                                                  Width="100%" Visible="true">
                                                                 </asp:DropDownList>
                                                           </div>

                                                           <div class="col-md-3">
                                                                 <asp:Label ID="l_end_date" runat="server" Text="end_date" Visible="true"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                 <asp:TextBox ID="t_end_date" runat="server" CssClass = "textboxstyle" 
                                                                 Width="85%" Visible="true"></asp:TextBox>
                                                                <asp:Image ID="Image3" src="../Image/calender.png" runat="server" 
                                                                    Visible="true"/>
                                                            </div>
                                                   </div>

                                                       <div class="row user-control">
                                                        <div class="col-lg-12 textboxstyle category_bg">
                                                            <label id="lblUserinput">User input</label>
                                                        </div>
                                                    </div>

                                                      <div class="row user-control">
                                                       <div class=" col-md-3">
                                                            <asp:Label ID="l_inform" runat="server" Text="inform" Visible="true"></asp:Label>
                                                        </div>
                                                        <div class=" col-md-3">
                                                            <asp:TextBox ID="t_inform" runat="server" class = "textboxstyle" width="100%" 
                                                                Visible="true"></asp:TextBox>
                                                        </div>
                                                        <div class=" col-md-3">
                                                            <asp:Label ID="l_User_input" runat="server" Text="User input" Visible="true"></asp:Label>
                                                        </div>
                                                        <div class=" col-md-3">
                                                            <asp:TextBox ID="t_user_input" runat="server" CssClass = "textboxstyle" 
                                                                width="100%" Enabled="false"></asp:TextBox>
                                                        </div>    
                                                    </div>
                                                       
                                                      <div class="row user-control">
                                                        <div class=" col-md-3">
                                                            <asp:Label ID="Label1" runat="server" Text="Decription" Visible="true"></asp:Label>
                                                        </div>
                                                        <div class=" col-md-3">
                                                        <asp:TextBox ID="t_Decription" runat="server" class = "textboxstyle" 
                                                                TextMode="MultiLine" width="100%" Visible="true"></asp:TextBox>
                                                        </div>
                                                        <div class=" col-md-3">
                                                            <asp:Label ID="l_Solution" runat="server" Text="Solution" Visible="true"></asp:Label>
                                                        </div>
                                                        <div class=" col-md-3">
                                                        <asp:TextBox ID="t_Solution" runat="server" class = "textboxstyle" 
                                                                TextMode="MultiLine" width="100%" Visible="true" ></asp:TextBox>
                                                        </div>
                                                    </div>


                                                     <div class="row user-control">
                                                          <div class=" col-md-3">
                                                            <asp:Label ID="Label2" runat="server" Text="Support By" Visible="true"></asp:Label>
                                                        </div>
                                                        <div class=" col-md-3">
                                                            <asp:DropDownList ID="D_Support_by" runat="server" 
                                                                CssClass = "textboxstyle" width="100%" AutoPostBack="true" OnSelectedIndexChanged="D_Support_by_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                        
                                                         <div class=" col-md-3">
                                                            <asp:Label ID="l_Assign_to" runat="server" Text="Support Name" Visible="true"></asp:Label>
                                                        </div>
                                                        <div class=" col-md-3">
                                                            <asp:DropDownList ID="d_assign_to" runat="server" 
                                                                CssClass = "textboxstyle" width="100%">
                                                            </asp:DropDownList>
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
