<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bakong_Dashboard.aspx.cs" Inherits="Payment_VISA_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.4.1.min.js")%>" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <section class="content">
                            <div class="col-xs-12">
                                   <div class="box box-primary">
                                        <div class="box-body box-profile">
                                              <div class="box-header with-border">
                                                        <i class="fa fa-file-text"></i>
                                                         <h3 class="box-title" style="color:blue">Bakong CLearing</h3>
                                                     </div>
                                            </div>
                                       </div>
                                </div>
                        </section>
    </form>
</body>
</html>
