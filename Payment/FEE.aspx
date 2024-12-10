<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FEE.aspx.cs" Inherits="Payment_FEE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/CSS/paper.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/normalize.min.css")%>" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" media="screen" href="<%= Page.ResolveUrl ("~/CSS/main.css") %>" />
    <style>
         /*@media print
        {    
            .no-print, .no-print *
            {
                display: none !important;
            }
        }*/
        .proxy-title {
            font-family: 'Khmer Mool' !important;
            font-size: 16px;
            text-align: center;
        }

        .proxy-content-title {
            font-family: 'Khmer Mool' !important;
            font-size: 15px;
            width: 10%
        }

        .proxy-content {
            font-family: 'Khmer Nettra' !important;
            font-size: 13px;
        }

        table td,
        table td * {
            vertical-align: top;
        }

        .proxy-copy-to {
            font-family: 'Khmer OS Battambang' !important;
            font-size: 10px
        }

        .proxy-replace {
            font-family: 'Khmer Mool' !important;
            font-size: 15px !important;
            vertical-align: baseline;
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
            img.InGrid
                {
                max-width: 200px;
                max-height: 200px;
                }
            .tdalign {
            text-align:center;
        
            }
                .landScape
            {
                width: 100%;
                height: 100%;
                margin: 0% 0% 0% 0%;
                filter: progid:DXImageTransform.Microsoft.BasicImage(Rotation=3);
            }
         .tablecenter {
                margin:0 auto !important;
                }
          .tdalign {
            text-align:center;
        
            }
            /*.tableborder {
                border:none;
            }
            .table thead th{
                background-color: burlywood !important;

            }*/

            
        
    </style>
       <script>
           function Print() {
                window.print();
            }
        </script>
    
  
       
</head>
<body class="A4.landscape">
    <form id="form1" runat="server">
        <section class="sheet padding-10mm">
            <%--<button id="printPage" class="no-print btn btn-sm btn-primary" onclick="Print()" align="center"><i class="fa fa-print fa-lg" style="color:black;" aria-hidden="true"></i> Print</button>--%>
              <p id="Pdate" runat="server" style="font-family:'Khmer OS Battambang'; font-size:14px; position:absolute;margin-top:45px; padding-left:5px;">
                    </p>
            <table>
                <tr>
                    <td>
                        <img src="../Image/Logo.png" alt="title" style="width:120px;"/>
                    </td>
                </tr>
            </table>

            <table class="tablecenter" style="width:100%;">
                <tr>
                    <td>
                        <p style="margin-top:20px;" class="proxy-title">FAST Payment Fee Sharing Monthly Report by Branch</p>
                    </td>
                </tr>
            </table>
                                              
            <table class="tablecenter" style="width:100%;">
                <tr>
                    <td>
                        <p class="proxy-title">Settlement Date <label id="Label1" runat="server"></label></p>
                    </td>
                </tr>
            </table>

            <table class="tablecenter" style="width:100%;">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" 
                                                           CssClass="table table-bordered table-hover"
                                                           Font-Size="11px" BorderStyle="Solid" RowStyle-Wrap="false" 
                                                           AutoGenerateColumns="False" GridLines="None" OnDataBound="OnDataBound"
                                                           ShowFooter ="true"
                                                           > <%--OnDataBound="OnDataBound" OnRowDataBound="GridView1_RowDataBound"--%>
                                                           <Columns>
                                                               <asp:BoundField DataField="AUTO_NUM" HeaderText="No"  />
                                                               <asp:BoundField DataField="BRANCH_NAME" HeaderText="Branch_Name" FooterText ="Grand Total:" footerstyle-font-bold="true" FooterStyle-HorizontalAlign="Right" />
                                                               <asp:BoundField DataField="OUT_TOTAL_FEE" HeaderText="HKL" />
                                                               <asp:BoundField DataField="OUT_TOTAL_FEE" HeaderText="Other Fls" />
                                                               <asp:BoundField DataField="AP_BAL" HeaderText="HKL" />
                                                               <asp:BoundField DataField="IN_TOTAL_FEE" HeaderText="HKL-income" />
                                                               <asp:BoundField DataField="TOTAL_NET_FEE" HeaderText="Branch Net Fee" />
                                                               <asp:BoundField DataField="NET_NBC" HeaderText="TRN_REF_NO" />
                                                             </Columns>
                                                    <RowStyle Wrap="False"></RowStyle>
                                                       </asp:GridView>
                    </td>
                </tr>
            </table>

            <table class="tablecenter" style="width:100%;">
                <tr>
                    <td class="tdalign">
                        <img src="../img/Preparedby.JPG" class="InGrid" />
                    </td>
                    <td class="tdalign">
                        <img src="../img/agreedby.JPG" class="InGrid" />
                    </td>
                    <td class="tdalign">
                        <img src="../img/Net_balance_VerifiedBy.PNG" class="InGrid" />
                    </td>
                    <td class="tdalign">
                        <img src="../img/Branch_fee_verifiedBy.PNG" class="InGrid" />
                    </td>
                </tr>
            </table>
                                                
                <%--  <style type="text/css">
                      .vertical-middle{
                          vertical-align: middle !important;
                          text-align: center !important;
                      }
                  </style>--%>
                                                 
        </section>
    </form>
</body>
</html>
