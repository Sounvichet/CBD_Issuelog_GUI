<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mission_letter.aspx.cs" Inherits="Mission_Mission_letter" %>

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

        .gettextalign {
        margin-left:25px;
        }
        .getmarginright {
        margin-left:20px;
        }
        .gettdwight {
        width:500px;
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

        table td,
        table td * {
            vertical-align: top;
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
        font-family: 'Khmer Mool' !important;
        font-size: 16px;
        text-align: center;
        }

        .auto-style1 {
            font-family: 'Khmer OS Battambang';
            font-size: 14px;
            height: 29px;
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

                <div style="border: 2px solid black ;">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <%--<img src="../Image/Header_letter.png" style="width:100%" />--%>
                                <img src="../Image/image001.png" width="75px" />
                            </td>
                            <td style="text-align:right;vertical-align:top;">
                                <img src="../Image/QR_CODE.png" width="50px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <p class="proxy-title">
                                    លិខិតអនុញ្ញាត
                                </p>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <p class="proxy-title">
                                    ចុះបេសកកម្មតំហែទាំនិងជួសជុលម៉ាស៊ីនអេធីអឹម
                                </p>
                            </td>
                        </tr>
                    </table>
                
                <br />

            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td class="proxy-content">
                          <span class="proxy-replace">នាយកនាយកដ្នាន ឆានែលប៊ែងឃីង</span>
                          <span class="proxy-replace">របស់ ធនាគារ​ ហត្ថា បានសំរេចអនុញ្ញាតអោយ បុគ្គលិកដែលមានអត្តសញ្ញាណ ដូចខាង</span>
                        </td>
                    </tr>

                    <tr>
                            <td class="proxy-content">
                               <span class="proxy-replace">ក្រោមចុះបេសកកម្មធ្វើតំហែទាំ ឬជួសជុលម៉ាស៊ីន អេធីអឹមរបស់ ធនាគារ​ ហត្ថា តាមទីតាំង </span>
                            </td>
                    </tr>

                </tbody>
            </table>
                        
                        <br />
            <table style="width:100%;">
                    <tbody>
                        <tr>
                            <td class="proxy-content">
                                <span class="proxy-replace">
                                ឬការិយាល័យ :
                                    </span>
                            </td>
                            <td class="proxy-content">
                                <span class="proxy-replace">
                                      <asp:label id="lblBranchName" runat="server" Font-Bold="true" Font-Names="Graphik Regular" ></asp:label> <%--Font-Bold="true"  style="font-size:14px;text-align:left"--%> 
                                </span>
                              
                            </td>
                        </tr>

                        <tr>
                            <td class="proxy-content">
                                <span class="proxy-replace">
                                    ប្រភេទនៃបញ្ហា :
                                </span>
                            </td>

                            <td class="proxy-content">
                                    <span class="proxy-replace">
                                        <asp:label id="lblpurpose" runat="server" Font-Bold="true" Font-Names="Graphik Regular" ></asp:label>
                                    </span>
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="proxy-content">
                                <span class="proxy-replace">
                                    គោលបំណង :
                                </span>

                            </td>

                            <td class="proxy-content">
                                    <span class="proxy-replace">
                                        <asp:label id="lblproblem_desc" runat="server" Font-Bold="true" Font-Names="Graphik Regular"></asp:label>
                                    </span>
                            </td>
                        </tr>
                    </tbody>
            </table>

            <table style="width:100%;">
                <tbody>
                    <tr>
                        <td class="proxy-content">
                              <span class="proxy-replace">
                                     សំភារះភ្ជាប់មកជាមួយ ៖
                              </span>
                        </td>
                        <td class="proxy-content">
                            <%--................................................................................................................................................--%>
                        </td>
                    </tr>

                    <tr>
                        <td class="proxy-content" colspan="2">
                            <%-- .....................................................................................................................................................................................--%>
                        </td>
                    </tr>
                </tbody>
            </table>
                   
            <table>
                <tbody>
                    <tr>
                        <td>

                        </td>
                    </tr>
                </tbody>
            </table>
                        
                        
                        <br />
                        <br />
                                <table border="0" style="width:100%;">
                                    <tbody>
                                    <tr>
                                        <td class="proxy-content">
                                            ១. ឈ្មោះ 
                                            <%--<asp:Label ID="Label3" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="១. ឈ្មោះ"></asp:Label>--%>
                                        </td>
                                        
                                        <td class="tdname proxy-content">
                                            <asp:Label ID="lblfcname1"  runat="server" Text="Null"></asp:Label>
                                        </td>
                                        
                                        <td class="proxy-content">
                                            ភេទ :
                                            <%--<asp:Label ID="Label4" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ភេទ :"></asp:Label>--%>
                                        </td>

                                        <td class="tdsex proxy-content">
                                            <asp:Label ID="lblgender1"  runat="server" Text="Null" ></asp:Label>
                                        </td>

                                        <td class ="proxy-content">
                                            មុខដំណែង:
                                            <%--<asp:Label ID="Label5" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="មុខដំណែង:"></asp:Label>--%>
                                        </td>
                                        
                                        <td class="tdposition proxy-content">
                                            <asp:Label ID="lblposition1"  runat="server" Text="Null"></asp:Label>
                                        </td>
                                    </tr>
                                    </tbody>
                                </table>
 

                                <table style="width:100%" border="0">
                                    <tr>
                                        <td class="proxy-content">
                                            
                                                ស្ថាប័ន :
                                            
                                            <%--<asp:Label ID="Label6" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ស្ថាប័ន :"></asp:Label>--%>
                                        </td>
                                        <td class="tdcompany proxy-content">
                                            <asp:Label ID="lblcom1" runat="server"  Text="Null"></asp:Label>
                                        </td>
                                        <td class="proxy-content">
                                            ទូរស័ព្ទ :
                                            <%--<asp:Label ID="Label7" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ទូរស័ព្ទ :"></asp:Label>--%>
                                        </td>
                                        <td class="tdphone proxy-content">
                                            <asp:Label ID="lblphone1" runat="server"  Text="Null" ></asp:Label>
                                        </td>
                                        <td class="proxy-content">
                                            កាតការងារ :
                                            <%--<asp:Label ID="Label8" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="កាតការងារ :"></asp:Label>--%>
                                        </td>
                                        <td class="tdcard proxy-content">
                                            <asp:Label ID="lblcard1" runat="server"  Text="Null"></asp:Label>
                                        </td>
                                    </tr>
                                </table>


                   
                                <table style="width:100%" border="0">
                                    <tbody>
                                    <tr>
                                        <td class="proxy-content">
                                           
                                            ២. ឈ្មោះ
                                            
                                            <%--<asp:Label ID="Label9" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="២. ឈ្មោះ"></asp:Label>--%>
                                        </td>
                                        <td class="tdname proxy-content">
                                            <asp:Label ID="lblfcname2" runat="server" Text="Null"></asp:Label>
                                        </td>
                                        <td class="proxy-content">
                                           
                                            ភេទ :
                                         
                                                <%--<asp:Label ID="Label10" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ភេទ :"></asp:Label>--%>
                                        </td>
                                        <td class="tdsex proxy-content">
                                            <asp:Label ID="lblgender2" runat="server" Text="Null" ></asp:Label>
                                        </td>
                                        <td class="proxy-content">
                                           
                                            មុខដំណែង:
                                           
                                                <%--<asp:Label ID="Label11" runat="server" Text="មុខដំណែង:"></asp:Label>--%>
                                        </td>
                                        <td class="tdposition proxy-content">
                                            <asp:Label ID="lblposition2" runat="server" Text="Null"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                        </tbody>
                                </table>
                                
                           
                                <table style="width:100%" border="0">
                                    <tbody>
                                      <tr>
                                        <td class="proxy-content">
                                            ស្ថាប័ន :
                                            <%--<asp:Label ID="Label12" runat="server"  Text="ស្ថាប័ន :"></asp:Label>--%>
                                            
                                        </td>
                                        <td class="tdcompany proxy-content">
                                            <asp:Label ID="lblcom2" runat="server"  Text="Null"></asp:Label>
                                        </td>
                                        <td class="proxy-content">
                                            ទូរស័ព្ទ :
                                            <%--<asp:Label ID="Label13" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ទូរស័ព្ទ :"></asp:Label>--%>
                                            
                                        </td>
                                        <td class="tdphone proxy-content">
                                            <asp:Label ID="lblphone2" runat="server" Text="Null" ></asp:Label>
                                        </td>
                                        <td class="proxy-content">
                                            កាតការងារ :
                                            <%--<asp:Label ID="Label14" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="កាតការងារ :"></asp:Label>--%>
                                        </td>
                                        <td class="tdcard proxy-content">
                                            <asp:Label ID="lblcard2" runat="server"  Text="Null"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    </tbody>    
                             </table>

                                <table style="width:100%" border="0">
                                    <tr>
                                        <td class="proxy-content">
                                            ៣. ឈ្មោះ
                                            <%--<asp:Label ID="Label31" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="៣. ឈ្មោះ"></asp:Label>--%>
                                        </td>
                                        <td class="tdname proxy-content">
                                            <asp:Label ID="Label32" runat="server"  ></asp:Label>
                                        </td>
                                        <td>
                                            <span class="proxy-replace">ភេទ :</span>
                                            <%--<asp:Label ID="Label33" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ភេទ :"></asp:Label>--%>
                                        </td>
                                        <td class="tdsex proxy-content">
                                            <asp:Label ID="Label34" runat="server"   ></asp:Label>
                                        </td>
                                        <td>
                                            <span class="proxy-replace">មុខដំណែង:</span>
                                            <%--<asp:Label ID="Label35" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="មុខដំណែង:"></asp:Label>--%>
                                        </td>
                                        <td class="tdposition proxy-content">
                                            <asp:Label ID="Label36" runat="server"  ></asp:Label>
                                        </td>
                                        
                                    </tr>
                                </table>


                              <table style="width:100%" border="0">
                                    <tr>
                                        <td class="proxy-content">
                                            ស្ថាប័ន :
                                            <%--<asp:Label ID="Label37" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ស្ថាប័ន :"></asp:Label>--%>
                                            
                                        </td>
                                        <td class="tdcompany proxy-content">
                                            <asp:Label ID="Label38" runat="server"  ></asp:Label>
                                        </td>
                                        <td class="proxy-content">
                                            ទូរស័ព្ទ :
                                        </td>
                                        <td class="tdphone proxy-content">
                                            <asp:Label ID="Label40" runat="server"   ></asp:Label>
                                        </td>
                                        <td class="proxy-content">
                                            កាតការងារ :
                                        </td>
                                        <td class="tdcard proxy-content">
                                            <asp:Label ID="Label42" runat="server" ></asp:Label>
                                        </td>
                                        
                                    </tr>
                                </table>

                                <br />
                                <br />
                                <br />                    
                        <table style="width:100%" >
                                    <tr>
                                        <td class="tdCenter proxy-content">
                                         <span class="proxy-replace">
                                          ចាប់ពីថ្ងៃ
                                         </span>
                                           <%-- <asp:Label ID="Label15" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ចាប់ពីថ្ងៃ"></asp:Label>--%>
                                            
                                        </td>
                                        <td class="tdCenter proxy-content">
                                            <asp:Label ID="lblstartdate" runat="server" Text="Null"></asp:Label>
                                        </td>
                                        <td class="tdCenter proxy-content">
                                           <span class="proxy-replace">
                                            ដល់ថ្ងៃទី
                                            </span>
                                               <%--<asp:Label ID="Label16" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ដល់ថ្ងៃទី"></asp:Label>--%>
                                            
                                        </td>
                                        <td class="tdCenter proxy-content">
                                            <asp:Label ID="lblenddate" runat="server" Text="Null"></asp:Label>
                                        </td>
                                        <td class="tdCenter proxy-content">
                                          <span class="proxy-replace">
                                            ចំនួន
                                          </span>  
                                                 <%--<asp:Label ID="Label17" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ចំនួន"></asp:Label>--%>
                                            
                                        </td>
                                        <td class="tdCenter proxy-content">
                                            <asp:Label ID="lbldays" runat="server" Font-Size="14px" Text="Null"></asp:Label>
                                        </td>
                                        <td class="tdCenter proxy-content">
                                           <span class="proxy-replace">  
                                            ថ្ងៃ
                                            </span>
                                               <%--<asp:Label ID="Label18" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="ថ្ងៃ"></asp:Label>--%>
                                            
                                        </td>
                                        <td class="tdCenter proxy-content">
                                            <asp:Label ID="lblnights" runat="server"  Text="Null"></asp:Label>
                                        </td>
                                        <td class="tdCenter proxy-content">
                                          <span class="proxy-replace">
                                            យប់។
                                          </span>
                                              <%--<asp:Label ID="Label19" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="យប់។"></asp:Label>--%>
                                            
                                        </td>
                                    </tr>
                                </table>

                        <table style="width:100%">
                            <tbody>
                                <tr>
                                    <td class ="proxy-content">
                                        អាស្រ័យហេតុនេះ សូមលោកនាយកសាខា និងបុគ្គលិកដែលពាក់ព័ន្ធ មេត្តាជួយសម្រួល និងផ្តល់ការ សហការ អោយបាន
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                               <%-- <asp:Label ID="Label20" runat="server" Font-Names="Khmer OS Battambang" Font-Size="14px" Text="អាស្រ័យហេតុនេះ សូមលោកនាយកសាខា និងបុគ្គលិកដែលពាក់ព័ន្ធ មេត្តាជួយសម្រួល និងផ្តល់ការ សហការ អោយបាន"></asp:Label>--%>
                                
                          <table style="width:100%">
                            <tbody>
                                <tr>
                                    <td class ="proxy-content">
                                        ល្អដល់ដំណើរការបេសកកម្មនេះដោយក្តីអនុគ្រោះ។
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        
                     
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        

                    <table style="width:100%;" border="0">
                        <tr>
                            <td>
                                    <table style="width:100%;" border="0">
                                        <tr>
                                            <td>
                                                <span class="proxy-replace getmarginright">
                                                រៀបចំដោយ
                                                </span>
                                                    
                                            </td>
                                        </tr>
                                     </table>

                            </td>
                            <td class="gettdwight">

                            </td>
                            <td>
                                <table style="width:100%;" border="0">
                                        <tr>
                                            <td>
                                                <span class="proxy-replace">
                                                អនុម័តដោយ
                                                </span>
                                                    
                                            </td>
                                        </tr>
                                     </table>
                            </td>
                        </tr>

                        <tr style="height:100px;">
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>

                        
                        <tr>
                            <td>
                                <table style="width:100%;" border="0">
                                      <tr>
                                             <td class="proxy-content">
                                                <span class="proxy-replace getmarginright">
                                                ឈ្មោះ
                                                </span>
                                             </td>
                                    </tr>
                                    <tr>
                                             <td class="proxy-content">
                                                <span class="proxy-replace getmarginright">
                                                ថ្ងៃទី..........ខែ..........ឆ្នាំ..........
                                                </span>
                                             </td>
                                    </tr>
                                </table>
                            </td>

                             <td class="gettdwight">

                            </td>

                            <td>
                                 <table style="width:100%;" border="0">
                                     <tr>
                                         <td class="auto-style1">
                                                <span class="proxy-replace">
                                                ឈ្មោះ
                                                </span>
                                             </td>
                                     </tr>
                                     
                                     <tr>
                                             <td class="proxy-content">
                                                <span class="proxy-replace getmagin">
                                                ថ្ងៃទី..........ខែ..........ឆ្នាំ..........
                                                </span>
                                             </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                    </table>
                </div>
    </section>
    </form>
</body>
</html>
