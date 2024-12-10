<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="Complaint_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    

    <style type="text/css">
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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span>' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 5000);//5000=5 seconds
        };
    </script>

    <script type="text/javascript">
         jQuery(function ($) {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Datepickerload);
             function Datepickerload()
             {
                 $("#<%=Start_date.ClientID %>").dynDateTime({
                     showsTime: true,
                     ifFormat: "%m/%d/%Y %H:%M:%S",
                     daFormat: "%l;%M %p, %e %m,  %Y",
                     align: "BR",
                     electric: false,
                     singleClick: false,
                     displayArea: ".siblings('.dtcDisplayArea')",
                     button: ".next()"
                 });

                 $("#<%=End_date.ClientID %>").dynDateTime({
                     showsTime: true,
                     ifFormat: "%m/%d/%Y %H:%M:%S",
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
       jQuery(function ($)
           {
               $("#<%=Start_date.ClientID %>").dynDateTime({
                   showsTime: true,
                   ifFormat: "%m/%d/%Y %H:%M:%S",
                   daFormat: "%l;%M %p, %e %m,  %Y",
                   align: "BR",
                   electric: false,
                   singleClick: false,
                   displayArea: ".siblings('.dtcDisplayArea')",
                   button: ".next()"
               });

               $("#<%=End_date.ClientID %>").dynDateTime({
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

</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
    <section class="content">
              <div class="row">
                            <div class="col-xs-12">
                                   <div class="box box-primary">
                                        <div class="box-body box-profile">
                                                 <h3 class="box-title">Update Complain</h3>
                                                
                                             </div>
                                       <div class="box-body">
                                           <asp:ScriptManager ID="SMComplaintEdit" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdateticketEdit" UpdateMode="Conditional" runat="server">
							                                  <ContentTemplate>
                                           <div class="row">
                                                        <div class=" col-lg-12" align="left">
                                                             <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnedit_Click" ><i class="fa fa-pencil fa-lg" aria-hidden="true"></i> Edit</asp:LinkButton>
                                                             <asp:LinkButton ID="Linkbtnsave" runat="server" CssClass="btn btn-sm btn-primary" Enabled="false" OnClick="btnUpdate_click"><i class="fa fa-save fa-lg" aria-hidden="true" ></i> Save</asp:LinkButton>
                                                             <asp:LinkButton ID="LinkBtndel" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnCancel_Click"><i class="fa  fa-backward fa-lg" aria-hidden="true" ></i> cancel</asp:LinkButton>
                                                        </div>
                        
                                                </div>
                                           <p></p>

                                           <div class="row">
                                                            <div class="col-md-12">
                                                                <div  id="alert_container">
                                                         
                                                            </div>
                                                        </div>
                                                      </div>
                                           <p></p>

                                                    <div class="row">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="Label1" runat="server" Text="Ticket_no  :"></asp:Label>
                              
                                                            </div>
                                                            <div class = "col-md-3">
                                                                <asp:Label ID="T_ticket_no" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                 <asp:Label ID="Label10" runat="server" Text="Branch_Name"></asp:Label>
                                
                                                            </div>
                                                            <div class = "col-md-3">
                                                                  <asp:TextBox ID="t_branch_name" runat="server" CssClass = "textboxstyle" Enabled="false"></asp:TextBox>
                                                            </div>
                                                    </div>
                                                
                                                     <div class="row">
                                                        <div class="col-md-3">
                                                            <asp:Label ID="Label6" runat="server" Text="ReasonGroup"></asp:Label>
                                                        </div>
                            
                                                        <div class="col-md-3">
                                                            <asp:DropDownList ID="D_ReasonGroup" runat="server" CssClass = "textboxstyle" Width = "73%" AutoPostBack ="true" OnSelectedIndexChanged="D_ReasonGroup_SelectedIndexChanged" Enabled="false" >
                                                                </asp:DropDownList>    
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="Label5" runat="server" Text="Start_date"></asp:Label>
                                                        </div>
                                                        <div class="col-md-3">
                                                          <asp:TextBox ID="Start_date" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                            <asp:Image ID="Image2" src="../../Image/calender.png" runat="server"/>
                                                        </div>
                                                     </div>

                                                     <div class="row">
                                                    <div class="col-md-3">
                                                        <asp:Label ID="Label9" runat="server" Text="ReasonType"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:DropDownList ID="D_ReasonType" runat="server" CssClass = "textboxstyle" Width = "73%" Enabled="false" >
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <asp:Label ID="Label7" runat="server" Text="End_date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="End_date" runat="server" CssClass = "textboxstyle"></asp:TextBox>
                                                        <asp:Image ID="Image1" src="../../Image/calender.png" runat="server"/>
                                                    </div>
                                                 </div>


                                                  <div class="row">
                                                    <div class="col-md-3">
                                                        <asp:Label ID="Label2" runat="server" Text="Status"></asp:Label>
                               
                                                    </div>
                                                    <div class="col-md-3">
                                                         <asp:DropDownList ID="D_Status" runat="server" CssClass = "textboxstyle">
                                                        </asp:DropDownList>
                                                    </div>
                                                 </div>

                                                  <div class="row">
                                                        <div class="col-md-3">
                                                            <asp:Label ID="Label3" runat="server" Text="Solution"></asp:Label>
                                                        </div>
                                                        <div class="col-md-9">
                                                            <asp:TextBox ID="T_solution" runat="server" Width="91%" TextMode="MultiLine" CssClass = "textboxstyle"></asp:TextBox>
                                                        </div>
                                                 </div>

                                                </ContentTemplate>
                                        </asp:UpdatePanel>
                                                  


                                                



                                      </div>
                                  </div>
                          </div>
                  </div>
                
        </section>
    </form>
</body>
</html>
