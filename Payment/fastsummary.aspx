<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fastsummary.aspx.cs" Inherits="Payment_fastsummary" %>

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
    <link rel="stylesheet" media="screen" href="<%= Page.ResolveUrl ("~/CSS/main-portrait.css") %>" />

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
            .tablecenter {
        margin:0 auto !important;
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
          
        .tdalign {
        text-align:center;
        
        }
         .tablecenter {
        margin:0 auto !important;
        }
    </style>
      

</head>
<body class="A4.landscape">
    <form id="form1" runat="server">
                <section class="sheet padding-20mm">
                  <%--  <p id="Pdate" runat="server" style="font-family:'Khmer OS Battambang'; font-size:14px; position:absolute;margin-top:45px; padding-left:5px;">
                    </p>--%>
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
                                <p style="margin-top:20px;" class="proxy-title">FAST Payment Daily Settlement Summary</p>
                            </td>
                        </tr>
                    </table>

                    <table class="tablecenter">
                        <tr>
                               <td>
                                     <p class="proxy-title"> Settlement Date :<label id="Label1" runat="server"></label> , Currency: KHR </p>
                               </td>
                        </tr>
                    </table>
                                                  
                    <table  class="tablecenter" style="width:100%;">
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Font-Size="10px" GridLines="None" RowStyle-Wrap="false" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnDataBound="OnDataBound" OnRowCreated="GridView1_RowCreated">
                                                           <Columns>
                                                               <asp:BoundField DataField="COUNT_OUT" HeaderText="COUNT_OUT" />
                                                               <asp:BoundField DataField="COUNT_IN" HeaderText="COUNT_IN" />
                                                               <asp:BoundField DataField="TOTAL_OUT" HeaderText="TOTAL_OUT" />
                                                               <asp:BoundField DataField="TOTAL_IN" HeaderText="TOTAL_IN" />
                                                               <asp:BoundField DataField="NET_AMOUNT" HeaderText="Net_Position" />
                                                               <asp:BoundField DataField="SETTLE_SESSION" HeaderText="SESSION" />
                                                               
                                                           </Columns>

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
                                 <img src="../img/verifyby.JPG" class="InGrid" />
                            </td>
                        </tr>
                    </table>
                                              
        </section>
    </form>
</body>
</html>
