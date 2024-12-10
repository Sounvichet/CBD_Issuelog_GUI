<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CSS_KHR.aspx.cs" Inherits="Payment_CSS_KHR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/paper.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/normalize.min.css")%>" rel="stylesheet" type="text/css" />
    <style>
     @page {
    size: A4 landscape
        }

        @media print
        {    
            .no-print, .no-print *
            {
                display: none !important;
            }
        }

         .user-control
         {
         padding-top:20px;
         }
        .proxy-title-USD {
            font-family: 'Calibri' !important;
            font-size: 16px;
            text-align: center;
        }
         .proxy-title-KHR {
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
         .vertical-middle{
                          vertical-align: middle !important;
                          text-align: center !important;
                          white-space:nowrap;
                          border:2px solid black;
                          color:white;
                          background-color:gray;
                      }
         /*body {
        border:2px solid Black;
              }*/
        .tdname 
        {
            width:150px;
        }
          .tdsex 
        {
            width:100px;
        }
            .tdposition
        {
            width:250px;
        }
                 .tdcompany
        {
            width:200px;
        }
          .tdphone
        {
            width:100px;
        }
            .tdcard
        {
            width:200px;
        }
        .tdalignRight
        {
        text-align:right;
        }
        .tdalign 
        {
        text-align:center;
         }
        .tablecenter {
        
        margin:0 auto !important;
        }
        .trbgcolor {
        border:2px solid black;
        color:white;
        background-color:gray;
        }
        

    </style>
</head>

<body class="A4.landscape">
    <form id="form1" runat="server">
            <section class="sheet padding-10mm">
                    <table>
                            <tr>
                                <td>
                                    <img src="../Image/Logo.png" alt="title" style="width:120px;"/>
                                </td>
                            </tr>
                    </table>
                    <table class="tablecenter" >
                        <tr>
                            <td>
                                <p style="margin-top:20px; text-decoration-line:underline; bo" class="proxy-title-USD"  >DAILY CASH SETTLEMENT CSS REPORT</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Date to Settlement:  <label id="Date_settle" runat="server"></label>  CCY: KHR</p>   
                            </td>
                        </tr>
                    </table>

             <%--   <table class="tablecenter trbgcolor" border="1">
                    <tr>
                        <td rowspan="2" style="vertical-align:middle;">No</td>
                        <td rowspan="2" style="white-space:nowrap; vertical-align:middle;">NAME of BANK/MFI</td> <td colspan="7">INCOMING CASH</td><td colspan="7">OUTGOING CASH</td>
                    </tr>
                    <tr>
                        <td>Branch Code</td><td>Transaction Type</td><td>Amount Settle</td><td>QTY of Tran</td><td>SUSPEN ACC</td><td>Fee Income </td><td>SUSPEN ACC</td><td>Branch Code</td><td>Transaction Type</td>
                        <td>Amount Settle</td><td>QTY of Tran</td><td>SUSPEN ACC</td><td>Fees Sharing</td><td>SUSPEN ACC</td>
                    </tr>
                </table>--%>

                <%--<asp:PlaceHolder  ID = "PlaceHolder1" runat="server" /> --%>
                  <table class="tablecenter" style="width:100%;">
                            <tr>
                                <td>
                                          <asp:GridView ID="GridView1" runat="server" 
                                                                       CssClass="table table-bordered table-hover"
                                                                       Font-Size="10px" BorderStyle="Solid" RowStyle-Wrap="false" 
                                                                       AutoGenerateColumns="false" GridLines="None" OnDataBound="OnDataBound"
                                                                       ShowFooter ="true"> <%--OnDataBound="OnDataBound" OnRowDataBound="GridView1_RowDataBound"--%>
                                                                       <Columns>
                                                                        <asp:TemplateField HeaderText = "ID" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                           <%--<asp:BoundField DataField="AUTO_NUM" HeaderText="No"  />--%>
                                                                          <asp:BoundField DataField="BANK_NAME" HeaderText="NAME of BANK/MFI" /> <%--FooterText ="Grand Total:" footerstyle-font-bold="true" FooterStyle-HorizontalAlign="Right"--%>
                                                                           <asp:BoundField DataField="BRANCH_CODE_I" HeaderText="BRANCH_CODE" />
                                                                           <asp:BoundField DataField="TRAN_TYPE_I" HeaderText="Transaction Type" />
                                                                           <asp:BoundField DataField="AMT_SETTLE_i" HeaderText="Amount Settle" ItemStyle-HorizontalAlign="Center" />
                                                                           <asp:BoundField DataField="NUM_OF_TRN_I" HeaderText="QTY of Tran" />
                                                                           <asp:BoundField DataField="SUSPEN_ACC1_I" HeaderText="SUSPEN ACC" />
                                                                           <asp:BoundField DataField="FEE_Income" HeaderText="Fee Income" ItemStyle-HorizontalAlign="Center" />
                                                                           <asp:BoundField DataField="SUSPEN_ACC2_I" HeaderText="SUSPEN ACC" />
                                                                           <asp:BoundField DataField="BRANCH_CODE_O" HeaderText="BRANCH_CODE" ItemStyle-HorizontalAlign="Center" />
                                                                           <asp:BoundField DataField="TRAN_TYPE_O" HeaderText="Transaction Type" ItemStyle-HorizontalAlign="Center" />
                                                                           <asp:BoundField DataField="AMT_SETTLE_O" HeaderText="Amount Settle" ItemStyle-HorizontalAlign="Center" />
                                                                           <asp:BoundField DataField="NUM_OF_TRN_O" HeaderText="QTY of Tran" />
                                                                           <asp:BoundField DataField="SUSPEN_ACC1_O" HeaderText="SUSPEN ACC" />
                                                                           <asp:BoundField DataField="FEE_Sharing" HeaderText="FEE_Sharing" ItemStyle-HorizontalAlign="Center" />
                                                                           <asp:BoundField DataField="SUSPEN_ACC2_O" HeaderText="SUSPEN ACC" ItemStyle-HorizontalAlign="Center" />
                                                            
                                                                         </Columns>
                                                                <RowStyle Wrap="False"></RowStyle>
                                                                   </asp:GridView>
                                </td>
                            </tr>
                    </table>

                 <table class="tablecenter" style="width:100%;" >
                            <tr>
                                <td class="tdalign">
                                    <img src="../img/Preparedby.JPG" class="InGrid" />
                                </td>
                                <td class="tdalign">
                                    <img src="../img/agreedby.JPG" class="InGrid" />
                                </td>
                   
                                <td class="tdalign" >
                                    <img src="../img/verifyby.JPG" class="InGrid" />
                                </td>
                            </tr>
                </table>


            </section>
    </form>
</body>
</html>
