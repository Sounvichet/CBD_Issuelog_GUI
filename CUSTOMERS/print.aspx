<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print.aspx.cs" Inherits="CUSTOMERS_print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/paper.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/normalize.min.css")%>" rel="stylesheet" type="text/css" />
    <style>
     @page {
    size: A4.landscape ;
    
        }

        @media print
        {    
            .no-print, .no-print *
            {
                display: none !important;
            }
            /*.row{margin-right:-15px;margin-left:-15px}
            .col-lg-1,.col-lg-10,.col-lg-11,.col-lg-12,.col-lg-2,.col-lg-3,.col-lg-4,.col-lg-5,.col-lg-6,.col-lg-7,.col-lg-8,.col-lg-9,.col-md-1,.col-md-10,.col-md-11,.col-md-12,.col-md-2,.col-md-3,.col-md-4,.col-md-5,.col-md-6,.col-md-7,.col-md-8,.col-md-9,.col-sm-1,.col-sm-10,.col-sm-11,.col-sm-12,.col-sm-2,.col-sm-3,.col-sm-4,.col-sm-5,.col-sm-6,.col-sm-7,.col-sm-8,.col-sm-9,.col-xs-1,.col-xs-10,.col-xs-11,.col-xs-12,.col-xs-2,.col-xs-3,.col-xs-4,.col-xs-5,.col-xs-6,.col-xs-7,.col-xs-8,.col-xs-9{position:relative;min-height:1px;padding-right:15px;padding-left:15px}*/
        }

         .user-control
         {
         padding-top:20px;
         }
        .form-control {
        padding-right:20px;
        }
        .proxy-title {
            font-family: 'AKbalthom Freehand' !important;
            font-size: 22px;
            text-align:left;
            font-weight:bold;

        }
        .proxy-title1 {
            font-family: 'AKbalthom Freehand' !important;
            font-size: 18px;
            text-align:left;
            /*font-weight:bold;*/

        }

        .proxy-content-title {
            font-family: Bayon !important;
            font-size: 16px;
            width: 100%
        }

        .proxy-content {
            font-family: 'Khmer OS Battambang' !important;
            font-size: 14px;
        }

        table td,
        table td * {
            vertical-align: top;
            /*text-align:center;*/
        }

        
        .proxy-copy-to {
            font-family: 'Khmer OS Battambang' !important;
            font-size: 10px
        }

        .proxy-replace {
            font-family: 'Khmer OS Battambang' !important;
            font-size: 14px !important;
            /*vertical-align: baseline;*/
        }
         /*body {
        border:2px solid Black;
              }*/
        .tdname 
        {
            width:150px;
        }
          .TDformat 
        {
            width:150px;
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
        /*.proxy-title {
        font-family: 'Khmer Mool' !important;
        font-size: 16px;
        text-align: center;
        }*/
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
            .gridgetsize
          {
              max-height: 280px;
              overflow : auto;
               width: 100%;
              margin-bottom: 1rem;
              color: #212529;
              background-color: transparent;
              
          }
          .gridgetsize th
            {
             font-size: 14px;
             font-weight: bold;
             white-space: nowrap;
              
            }

            .gridgetsize th,
            .gridgetsize td {
              padding: 0.30rem;
              vertical-align: top;
              border-top: 1px solid #dee2e6;
            }

            .gridgetsize thead th {
              vertical-align: bottom;
              border-bottom: 2px solid #dee2e6;
            }

            .gridgetsize tbody + tbody {
              border-top: 2px solid #dee2e6;
            }
       
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
           <div style="border: 2px solid black ;" class="table-responsive">
           <table style="width:100%;"​​>
                        <tr>
                            <td style="width:120px" rowspan="3">
                                <%--<img src="../Image/Header_letter.png" style="width:100%" />--%>
                                <img src="../Img/MasterCare_logo.PNG" alt="title" style="width:120px;height:120px"/>
                            </td>
                            <td>
                                <p class="proxy-title">
                                    
                                </p>
                                <label class="proxy-title">ម៉ាស្ទរ័ឃែរ អ្នកឯកទេសថែរក្សាសម្រស់ </label>
                            </td>
                            <td style="text-align:center;vertical-align:middle;" rowspan="3">
                                <img src="../Image/QR_CODE.png" width="75px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p class="proxy-title1">
                                    ទីតាំងទី១ អគារ CH ផ្លូវ ៤២៦ ទួលទំពូង២ ខណ្ឌចំការមន រាជធានីភ្នំពេញ ទីតាំងទី២ តារាងបាល់បឺងកក់
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p class="proxy-title1">
                                  Tel : 098636668 0955636668 0963800068 092880068
                                </p>
                            </td>
                             
                        </tr>
                    </table>

           <br />
           <br />
           <br />

               <table style="width:100%;"​​>
               <tr>
                   <td>
                           <p class="proxy-content-title">
                            ពត័មានអតិថិជន
                       </p>
                   </td>
               </tr>    
          </table>
               
               <table>
                   <tr>
                       <td>  
                             <asp:Image ID="cusimage" alt="User profile picture" runat="server" Width="150px"></asp:Image>                                      
                       </td>                 
                   </tr>
               </table>
                          

               <table style="width:100%;"​​>
               <tr>
                      <td class="TDformat">
                            <p class="proxy-content-title">
                           លេខសម្គាល់អតិថិជន :
                             </p>
                       </td>
                      <td>
                            <asp:TextBox ID="lblcustomerID" runat="server" CssClass="textboxstyle"></asp:TextBox>
                      </td>
                      <td class="TDformat">
                            Status
                      </td>
                       <td>
                           <asp:TextBox ID="lblstatus" runat="server" CssClass="textboxstyle"></asp:TextBox>
                       </td>
                      <td class="TDformat">
                           Service_num
                      </td>
                       <td>
                           <asp:TextBox ID="lblService_num" runat="server" CssClass="textboxstyle"></asp:TextBox>
                   </td>
               </tr>
                   </table>

               <table style="width:100%;"​​>
                   <tr>

                   <td class="TDformat">
                          <p class="proxy-content-title">
                             ឈ្មោះ 
                           </p>
                      </td>
                       <td>
                           <asp:TextBox ID="lblcustomername" runat="server" CssClass="textboxstyle"></asp:TextBox>
                      </td>

                       <td class="TDformat">
                           <p class="proxy-content-title">
                           វគ្ត
                            </p>
                      </td>

                       <td>
                           <asp:TextBox ID="lblcycle" runat="server" CssClass="textboxstyle"></asp:TextBox>
                      </td>
                       <td class="TDformat">
                           <p class="proxy-content-title">
                           លេខទូរសព្ទ័
                       </p>
                      </td>

                       <td>
                           <asp:TextBox ID="lblphone" runat="server" CssClass="textboxstyle"></asp:TextBox>
                       </td>
               </tr>
               </table>
               
               <table style="width:50%">
               <tr>
                   <td class="TDformat">
                           <p class="proxy-content-title">
                           សេវាកម្ម
                       </p>
                   </td>
                   <td>    
                           <asp:TextBox ID="lblServicePKG" runat="server" CssClass="textboxstyle"></asp:TextBox>
                      
                   </td>
               </tr>
           </table>

               <table style="width:100%">

               <tr>
                   <td>
                       <asp:GridView ID="gridschedule" runat="server" CssClass="table-bordered table-hover gridgetsize" Font-Size="Smaller">
                       <HeaderStyle CssClass="gvHeaderCenter" BackColor="#01559E" Font-Bold="true" ForeColor="#f5f5f5" />
                   </asp:GridView>
                   </td>
               </tr>
           </table>
                   
               
               </div>
       </section>
    </form>
</body>
</html>
