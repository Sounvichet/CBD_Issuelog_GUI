<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TBSTMDIS.aspx.cs" Inherits="Payment_TBSTMDIS" %>
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

</head>
<body>
    
    <form id="form1" runat="server">
              <section class="content">

               <div class="row">
                        <div class="col-md-12">
                                <div class="box box-primary">
                                        <div class="box-body box-profile">
                                        <div class="box-header with-border">
                                            <i class="fa fa-money"></i>
                                                <h3 class="box-title" style="color:blue">Insert True money Disputed</h3>
                                            </div>
                                            <div class="box-body">
                                                <%--   <asp:ScriptManager ID="SMSCSSIST" runat="server"></asp:ScriptManager>
                                                            <asp:UpdatePanel ID="UpdateCSSIST" UpdateMode="Conditional" runat="server">
			                                                            <ContentTemplate> --%>

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


                                                                            <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <div  id="alert_container">
                                                         
                                                                                    </div>
                                                                                </div>
                                                                              </div>


                                                                            <div class="row user-control">
                                                                                <div class="col-md-12">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                                                  <asp:DropDownList ID="ddlIsHeaderExists" runat="server" Visible ="false">
                                                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                
                                                                                            </td>

                                                                                            <td>
                                                                                                <button ID="btnUpload" class ="btn btn-sm btn-primary button_bg" runat="server"  onserverclick ="btnUpload_Click" onclick ="$('#loading').show();"  >Apply</button>
                                                                                            </td>
                                                                                            <td style="width:50px">

                                                                                            </td>

                                                                                            <td>
                                                                                                <label>Currency </label>
                                                                                                 <asp:DropDownList ID="d_CCY" runat="server" CssClass="textboxstyle">
                                                                                                        <asp:ListItem>USD</asp:ListItem>
                                                                                                        <asp:ListItem>KHR</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                            </td>

                                                                                            <td style="width:50px">

                                                                                            </td>
                                                                                            
                                                                                            <td>
                                                                                                 <div class="btn-group">
                                                                                                          <button type="button" class="btn btn-sm btn-primary button_bg">Action</button>
                                                                                                          <button type="button" class="btn btn-sm btn-primary dropdown-toggle button_bg" data-toggle="dropdown">
                                                                                                            <span class="caret"></span>
                                                                                                            <span class="sr-only">Toggle Dropdown</span>
                                                                                                          </button>


                                                                                                          <ul class="dropdown-menu" role="menu" id="iddropdown" style="background-color:#00A7A5; width: 300px ">
                                                                                                          <%--  <li><a href="#">Add New</a></li>
                                                                                                            <li><a href="#">Add New By Batch</a></li>
                                                                                                            <li><a href="#">Delete</a></li>
                                                                                                            <li><a href="#">Vew</a></li>--%>
                                                                                                          

                                                                                                                <li style="height:20px">
                                                                                                                <span class="align-middle">
                                                                                                                <a id="Review" href="#" class="fa fa-eye fa-lg"  style="color:black; height:auto; margin-left:10px;" onserverclick="Review_ServerClick1" onclick ="$('#loading').show();"   runat="server" > Review</a>
                                                                                                                </span>
                                                                                                            </li>
                                                                                                              <li style="height:20px">
                                                                                                                <span class="align-middle">
                                                                                                                <a id="Update" href="#" class="fa fa-pencil fa-lg"  style="color:black; height:auto; margin-left:10px;" onserverclick="Update_ServerClick" onclick="$('#loading').show();" runat="server" > Update Info</a>
                                                                                                                </span>
                                                                                                            </li>
                                                                                                               <li style="height:20px">
                                                                                                                <span class="align-middle"> 
                                                                                                                <a id="A4" href="#" class="fa fa-solid fa-plus fa-lg"  style="color:black; height:auto; margin-left:10px;" onserverclick="A4_ServerClick" onclick="$('#loading').show();" runat="server" > Push records to DETB_ITO</a>
                                                                                                                </span>
                                                                                                            </li>

                                                                                                                <li style="height:20px">
                                                                                                                <span class="align-middle">
                                                                                                                <a id="A3" href="#" class="fa fa-solid fa-plus fa-lg"  style="color:black; height:auto; margin-left:10px;" onserverclick="A3_ServerClick" onclick="$('#loading').show();" runat="server" > ITO Push Entries</a>
                                                                                                                </span>
                                                                                                            </li>

                                                                                                               <li style="height:20px">
                                                                                                                <span class="align-middle">
                                                                                                                <a id="A5" href="#" class="fa  fa-times fa-lg"  style="color:black; height:auto; margin-left:10px;" onserverclick="A5_ServerClick" onclick="$('#loading').show();" runat="server" > ITO Delete Entries</a>
                                                                                                                </span>
                                                                                                            </li>
                                                                                                                            
                                                                                                          </ul>
                                                                                                        </div> 
                                                                                            </td>
                                                                                            
                                                                                        </tr>

                                                                                           <tr>
                                                                                                    <td>
                                                                                                        <label runat="server" style="color: red;"  id="lblErrorMessage" visible="false"></label>
                                                                                                    </td>
                                                                                             </tr>

                                                                                        
                                                                                    </table>

                                                                                </div>
                                                                             </div>

                                                                    <div class="row user-control">

                                                                               <div class="col-md-6">
                                                                                         <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    
                                                                                                </td>
                                                                                                <td style="width:50px">

                                                                                                </td>
                                                                                                <td>

                                                                                                  
                                                                                                 </td>
                                                                                            </tr>

                                                                                          

                                                                                          </table>
                                                                               </div>
                                                                    </div>

                                                                              <div class="row">
                                                                                <div class="col-md-12 textboxstyle category_bg">
                                                                                    <asp:Label id="Label1" runat="server" Font-Bold="true" Text ="True Money Disputed Summary Report"></asp:Label>
                                                                                </div>
                                                                            </div>

                                                                          <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class ="table-responsive">
                                                                                    <asp:GridView ID="GetGrid_Wing_smy"  CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                                                    <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />   
                                                                                    </asp:GridView>
                                                                                    </div>
                                                                            </div>
                                                                        </div>

                                                                            <div class="row">
                                                                                <div class="col-md-12 textboxstyle category_bg">
                                                                                    <asp:Label id="Label2" runat="server" Font-Bold="true"  Text ="True Money Disputed listing"></asp:Label>
                                                                                </div>
                                                                            </div>

                                                                         <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class ="table-responsive">
                                                                                    <asp:GridView ID="GetGrid_Wing_list"  CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                                                     <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />   
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row">
                                                                              <div class ="col-md-12">
                                                                                  <asp:Label ID="l_Wing" runat="server">GetCount :</asp:Label><asp:Label ID="l_count_wing" runat="server" ForeColor="Blue"></asp:Label>
                                                                              </div>
                                                                        </div>

                                                                            <div class="row">
                                                                                <div class="col-md-12 textboxstyle category_bg">
                                                                                    <asp:Label id="Label3" runat="server" Font-Bold="true"  Text ="CBS Success listing"></asp:Label>
                                                                                </div>
                                                                            </div>


                                                                         <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class ="table-responsive">
                                                                                    <asp:GridView ID="GetGrid_CBS_list"  CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                                                    <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />     
                                                                                    </asp:GridView>
                                                                                    </div>
                                                                            </div>
                                                                        </div>
                                                                            

                                                                         <div class="row">
                                                                              <div class ="col-md-12">
                                                                                  <asp:Label ID="Label4" runat="server">GetCount :</asp:Label><asp:Label ID="l_count_CBS" runat="server" ForeColor="Blue"></asp:Label>
                                                                              </div>
                                                                        </div>

                                                                         <%--   <div class="row user-control">
                                                                                <div class="col-md-12">
                                                                                    <div class ="table-responsive">
                                                                                    <asp:GridView ID="getgrid1"  CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                                                      </asp:GridView>
                                                                                    </div>
                                                                                 <div>
                                                                                     ROW COUNT:<label id="L_count" runat="server"></label>
                                                                                 </div>
                                                                                </div>
                                                                            </div>--%>
                                                                  <%--      </ContentTemplate>
                                                                <Triggers>
                                                                    
                                                                   <asp:PostBackTrigger  ControlID=""/>
                                                                </Triggers>
                                                                </asp:UpdatePanel>--%>
                                                                                
                                                                             
                                             </div>
                                   </div>
                            </div>
                      </div>
                   </div>
              </section>
    </form>
</body>
</html>
