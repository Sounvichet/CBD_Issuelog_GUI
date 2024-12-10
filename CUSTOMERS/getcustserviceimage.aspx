<%@ Page Language="C#" AutoEventWireup="true" CodeFile="getcustserviceimage.aspx.cs" Inherits="CUSTOMERS_getcustserviceimage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../dist/css/adminlte.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="cusimage" CssClass="profile-user-img img-responsive user-image" alt="User profile picture" runat="server" Width="800px"></asp:Image>
    </form>
</body>
</html>
