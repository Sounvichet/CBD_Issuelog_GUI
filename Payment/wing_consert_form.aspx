<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wing_consert_form.aspx.cs" Inherits="payment_wing_consert_form" %>

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
    size: A4 ;
    
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
        .proxy-title {
            font-family: 'Bayon' !important;
            font-size: 16px;
            text-align: center;
            font-weight:bold;

        }

        .proxy-content-title {
            font-family: 'Khmer Mool' !important;
            font-size: 15px;
            width: 10%
        }

        .proxy-content {
            font-family: 'Khmer OS Battambang' !important;
            font-size: 14px;
        }
        .proxy-content-right {
            font-family: 'Khmer OS Battambang' !important;
            font-size: 14px;
            text-align: right;
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
            font-family: 'Kh Battambang' !important;
            font-size: 14px;
            /*vertical-align: baseline;*/
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
        text-align:left;
        }
        .proxy-title {
        font-family: 'Bayon' !important;
        font-size: 22px;
        text-align: center;
        }

         .proxy-subtitle {
        font-family: 'Bayon' !important;
        font-size: 18px;
        text-align: center;
        font-weight:bold;
        }

          .proxy-subtitle-left {
        font-family: 'Bayon' !important;
        font-size: 16px;
        text-align:left;
        font-weight:bold;
        }
    </style>

       <script>

                     function Print() {
                         window.print();
                     }
        </script>
</head>
<body class="A4" >
    <form id="form1" runat="server">
        <section class="sheet padding-10mm">

                              <%--  <div class="col-md-12">
                            
                                    <button id="printPage" class="no-print btn btn-sm btn-primary" onclick="Print()"><i class="fa fa-print fa-lg" style="color:black;" aria-hidden="true"></i> Print</button>
                                </div>--%>

                <div> <%--style="border: 2px solid black ;"--%>
                    <table style="width:100%;">
                        <tr>
                            <td colspan="2">
                                <p class="proxy-title">
                                    ព្រះរាជាណាចក្រកម្ពុជា
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <p class="proxy-title">
                                    ជាតិ សាសនា ព្រះមហាក្សត្រ
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <p class="proxy-subtitle">
                                    លិខិតព្រមព្រៀង និងអនុញ្ញាតិឳ្យដកប្រាក់ចេញពីគណនី
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <p class="proxy-subtitle-left">
                                    គោរពជូននាយក​/នាយិការ ធនាគារ ហត្ថា ម.ក សាខា <asp:Label ID="l_branch" runat="server"></asp:Label>
                                </p>
                            </td>
                        </tr>
                    </table>
                
                    <br />
            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td class="proxy-content">
                          <span class="proxy-replace">ខ្ញុំបាទ/នាងខ្ញុំ ឈ្មោះ</span> <asp:Label ID="l_customer" runat="server" Font-Bold="true"></asp:Label> 
                          <span class="proxy-replace">កាន់អត្តសញ្ញាណប័ណ្ណសញ្ជាតិខ្មែរ</span> <asp:Label ID="l_National_ID" runat="server" Font-Bold="true"></asp:Label>
                          <span class="proxy-replace">ជាម្ចាស់គណនីនៅ ធនាគារ ហត្ថា ម.ក ដែលមានឈ្មោះ</span> <asp:Label ID="l_customer1" runat="server" Font-Bold="true"></asp:Label> 
                          <span class="proxy-replace">និងលេខគណនី</span> <asp:Label ID="l_cust_acct" runat="server"></asp:Label>
                          <span class="proxy-replace">។</span>
                        </td>
                    </tr>

                </tbody>
            </table>      
                     <br />
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                
                                 <td class="proxy-content">
                                    <span class="proxy-replace">ដោយហេតុថា កាលពីថ្ងៃទី</span><asp:Label ID="L_rec_date" runat="server" Font-Bold="true"></asp:Label>
                                    <span class="proxy-replace">គណនីរបស់ខ្ញុំបាទ/នាងខ្ញុំខាងលើ បានទទួលប្រាក់លើសចំនួន </span>
                                    <asp:Label ID="l_amt" runat="server" Font-Bold="true"></asp:Label>
                                    <span class="proxy-replace">(................................................................)។</span>
                                </td>
                                    
                                </tr>
                        </tbody>
                  </table>

                     <br />
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td class="proxy-content">
                                    ហេតុដូច្នេះ ខ្ញុំបាទ/នាងខ្ញុំ យល់ព្រមដោយស្ម័គ្រចិត្ត និងអនុញ្ញាតឱ្យ ធនាគារ ហត្ថា ម.ក ដកប្រាក់ដែលមានចំនួនលើស ចេញពីគណនីរបស់ខ្ញុំបាទ/នាងខ្ញុំវិញ។ 
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <br />
                    <table style="width:100%;">
                        <tbody>
                                <tr>
                                    <td class="proxy-content">
                                        <span class="proxy-replace">ដើម្បីជាសក្ខីភាព ខ្ញុំបាទ/នាងខ្ញុំ សូមផ្តិតស្នាមមេដៃស្តាំ / ចុះហត្ថលេខា តាមកាលបរិច្ឆេទដូចខាងក្រោម។</span>
                                    </td>
                                </tr>
                       </tbody>
                   </table>

                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <table style="width:100%;">
                        <tbody>
                                <tr>
                                    <td class="proxy-content-right">
                                        <span class="proxy-replace">ធ្វើនៅ.................ថ្ងៃទី.......ខែ...............ឆ្នាំ..........</span>
                                        </td>
                                    </tr>
                            </tbody>
                        </table>

                    <br />
                    <br />
                    <br />
                    <br />
                    <br />

                    <table style="width:100%;">
                        <tbody>
                                <tr>
                                    <td class="proxy-content-right">
                                        <span class="proxy-replace">ស្នាមមេដៃ/ហត្ថលេខាម្ចាស់គណនី</span>
                                        </td>
                                    </tr>
                            </tbody>
                        </table>
           </div>
    </section>
    </form>
</body>
</html>
