<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test_api.aspx.cs" Inherits="test_api" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.1.js" integrity="sha256-3zlB5s2uwoUzrXK3BT7AX3FyvojsraNFxCc2vC/7pNI=" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id ="tbl_test" border="1">
        <tr>
            <th>ID</th>
            <th>Name</th>
        </tr>
    </table>

            <button onclick="testing()">test</button>
        </div>
    </form>

    <script>
        $(document).ready(function () {
            
        })

        function testing() {
            $.get('http://localhost:56159/home/index1', function (data) {
                const obj = JSON.parse(data);

                console.log(obj);
                console.log(obj['name']);
                console.log(obj.First_name);
                $('#name').text(obj['name']);

                Object.keys(obj).forEach(key => {
                    //$('#mydiv').append('<h1> ' + val + ' </h1> <h5>' + obj[val] + ' </h5>');
                    $('#tbl_test').append('<tr><td>' + key + '</td><td>' + obj[key] +'</td></tr>');
                    
                });

            })
        }
    </script>
</body>
</html>
