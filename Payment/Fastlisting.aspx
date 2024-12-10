<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fastlisting.aspx.cs" Inherits="Payment_Fastlisting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <link href="<%= Page.ResolveUrl ("~/CSS/paper.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/normalize.min.css")%>" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" media="screen" href="<%= Page.ResolveUrl ("~/CSS/main.css") %>" />
    <style>
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
        /*@media print {
            .n-print {
                display: none;
            }*/
               

            
        
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
                                             

            <table class="tablecenter">
                <tr>
                    <td>
                        <p style="margin-top:20px;" class="proxy-title">FAST Payment Settlement Listing</p>
                    </td>
                </tr>
            </table>
            
            <table class="tablecenter">
                <tr>
                    <td>
                         <p class="proxy-title">Settlement Date <label id="lbldate" runat="server"></label></p>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Font-Size="10px" GridLines="None" RowStyle-Wrap="false" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated">
                                <Columns>
                                    <asp:BoundField DataField="TRN_REF_NO" HeaderText="TRN_REF_NO" />
                                    <asp:BoundField DataField="SENDER_BANK" HeaderText="SENDER_BANK" />
                                    <asp:BoundField DataField="SENDER_CODE" HeaderText="SENDER_BANK_CODE" />
                                    <asp:BoundField DataField="SENDER_CUSNAME" HeaderText="Sender_Cus_Name" />
                                    <asp:BoundField DataField="SOURCE_ACC" HeaderText="SOURCE_ACC" />
                                    <asp:BoundField DataField="RECEIVING_BANK" HeaderText="RECEIVING_BANK" />
                                    <asp:BoundField DataField="RECEIVING_CODE" HeaderText="RECEIVING_BANK_CODE" />
                                    <asp:BoundField DataField="RECEIVING_CUSNAME" HeaderText="RECEIVING_CUSNAME" />
                                    <asp:BoundField DataField="RECEIVING_ACC" HeaderText="RECEIVING_ACC" />
                                    <asp:BoundField DataField="TRN_AMOUNT" HeaderText="TRN_AMOUNT" />
                                    <asp:BoundField DataField="TRN_CCY" HeaderText="CCY" />
                                    <asp:BoundField DataField="TRN_DATE" HeaderText="TRN_DATE" HeaderStyle-CssClass=""/>
                                </Columns>

                            </asp:GridView>
                    </td>
                </tr>
            </table>
                           
            <table class="tablecenter" style="width:100%;" border="0">
                <tr>
                    <td class="tdalign">
                        <img src="../img/Preparedby.JPG" class="InGrid" />
                    </td>
                    <td class="tdalign">
                        <img src="../img/agreedby.JPG" class="InGrid" />
                    </td>
                    <td class="tdalign">
                        <img src="../img/verifyby.JPG" class="InGrid" />
                    </td>
                </tr>
            </table>

        </section>
    </form>
</body>
</html>
