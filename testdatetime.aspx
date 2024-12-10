<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testdatetime.aspx.cs" Inherits="testdatetime" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css'>
    <link rel='stylesheet' href='https://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/build/css/bootstrap-datetimepicker.css'>


</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
 
          <d class="row">
            <div class='col-sm-4'>
              <div class="form-group">
                <div class='input-group date' id='datetimepicker1'>
                  <input type='text' class="form-control" />
                  <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                  </span>
                </div>
              </div>
            </div>
        </div>
    </form>


     <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.2/jquery.min.js'></script>
     <script src='https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js'></script>
     <script src='https://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/src/js/bootstrap-datetimepicker.js'></script><script  src="./script.js"></script>

    <script>
        $(function () {
		$('#datetimepicker1').datetimepicker({
			format: 'DD-MM-YYYY LT'
		});
	});
    </script>
</body>
</html>
