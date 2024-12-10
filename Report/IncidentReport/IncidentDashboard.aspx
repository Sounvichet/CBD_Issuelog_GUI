<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncidentDashboard.aspx.cs" Inherits="Report_IncidentReport_IncidentDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="box-body box-profile">
             <h3 class="box-title" style="color:blue" align="center">Report Incident Dashboard</h3>
        </div>
    </form>
</body>
</html>
