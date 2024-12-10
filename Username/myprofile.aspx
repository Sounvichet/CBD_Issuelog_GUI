<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myprofile.aspx.cs" Inherits="myprofile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/plugins/fontawesome-free/css/all.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
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
        .category_bg {
            background-color: #f99d1c;
        }
        .user-control
         {
         padding-top:5px;
         }
        .button_bg {
        background-color:#009da5;
        }
    </style>
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">
   <section class="content">



              <div class="row">
                            <div class="col-md-12">
                                    <div class="box box-primary">
                                           <div class="box-body box-profile">
                                            <div class="box-header">
                                                 <h3 class="box-title" style="color:blue">My Profile</h3>
                                             </div>
                                               <div>
                                                   <asp:LinkButton ID="linkbtncacel" runat="server" class="btn btn-sm btn-primary button_bg" onclick="btncancel_Click1"  ><i class="fa fa-backward fa-lg" aria-hidden="true"></i> Cancel</asp:LinkButton>
                                               </div>
                                        <div class="box-body">
                            


                                              <div class="row user-control">
                                                <div class="col-md-12 textboxstyle category_bg">
                                                    <label id="lblBG">Employee Detail</label>
                                                </div>

                                            </div>

                                            <div class="row user-control">
                                                <div class="col-md-3">
                                                   <%-- <div class="box box-primary">
                                                        <div class="box-body box-profile">--%>  

                                                   <%-- profile-user-img img-responsive user-image--%>
                                                                <asp:Image ID="imageprofile" CssClass="img-responsive" alt="User profile picture" runat="server" Width="150px"></asp:Image>
                                                     <%--   </div>
                                                    </div>--%>
                                                </div>
                                            </div>
                                            
                                            <div class="row user-control">
                                                <div class="col-md-6">
                                                      <div class="form-group">
                                                          <asp:LinkButton ID="LinkAction" runat="server" CssClass="btn btn-sm btn-primary button_bg" OnClick="LinkAction_Click"><i class="fas fa-image" style="color:white" aria-hidden="true" ></i> Edit Image</asp:LinkButton> 
                                                          </div>
                                                </div>
                                            </div>
                                          

                                            <div class="row">
                                                <div class ="col-md-3">
                                                     <label id="label2" >Branch</label>
                                                </div>
                                                <div class ="col-md-3">
                                                     <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class ="col-md-3">
                                                     <label id="labelSidCard" >SIDCard</label>
                                                </div>
                                                <div class ="col-md-3">
                                                     <asp:Label ID="lblSidCard" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class ="col-md-3">
                                                    <label id="'label3" >EmployeeName</label>
                                                </div>
                                                <div class ="col-md-3">
                                                    <asp:Label ID="lblEmployeeName" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class ="col-md-3">
                                                    <label id="'label4" >Phone</label>
                                                </div>
                                                <div class ="col-md-3">
                                                    <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class ="col-md-3">
                                                    <label id="label5">Email</label>
                                                </div>
                                                <div class ="col-md-3">
                                                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class ="col-md-3">
                                                    <label id="label6">Employee Status</label>
                                                </div>
                                                <div class ="col-md-3">
                                                   <asp:Label ID="lblempstatus" runat="server" Text="Label"></asp:Label> 	
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class ="col-md-3">
                                                     <label id="label7">Job Title</label>
                                                </div>
                                                <div class ="col-md-3">
                                                     <asp:Label ID="lbljobtitle" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row">
                                                     <div class="col-md-12" >
                                                              <div class="modal fade"  style="display: none; width:100%" id="iframe-open">
                                                                        <div class="modal-dialog modal-lg">
                                                                          <div class="modal-content">
                                                                            <div class="modal-header">
                                                                              <h4 class="modal-title" style="color:black; font-size:larger">
                                                                                 <label id="gettitlescreen" runat="server"></label>

                                                                              </h4>
                                                                              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                <span aria-hidden="true">&times;</span>
                                                                              </button>
                                                                            </div>
                                                                            <div class="modal-body">
                                                                              <iframe id="frm2" runat="server"  allowfullscreen="true" scrolling="yes" frameborder="0" style ="width:100% !important;height:200px;"  ></iframe>
                                                                            </div>
                                                                          <%--  <div class="modal-footer justify-content-between">
                                                                              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                              <button type="button" class="btn btn-primary">Save changes</button>
                                                                            </div>--%>
                                                                          </div>
                                                                          <!-- /.modal-content -->
                                                                        </div>
                                                                        <!-- /.modal-dialog -->
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
