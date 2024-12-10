<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Issuelog | Log in</title>
    <link rel="shortcut icon" href="/Image/icon.png" type="image/png" />
    <link rel="icon" href="/Image/icon.png" type="image/png" />
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">    
    <link href="StylesLogin/bootstrap.min.css" rel="stylesheet" />
   
    <link rel="shortcut icon" href="/icon.png" type="image/png" />
	<link rel="icon" href="/icon.png" type="image/png" />
    <!-- Styling Icon -->
    <link href="StylesLogin/bootstrap.min.css" rel="stylesheet" type="text/css" />
	<link href="StylesLogin/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <script src="StylesLogin/jquery-1.11.2.min.js" type="text/javascript"></script>
    <link href="StylesLogin/font-awesome.min.css" rel="stylesheet" type="text/css" />
	<link href="StylesLogin/cs_wfmain.css" rel="stylesheet" type="text/css" />
    <link href="StylesLogin/custome.css" rel="stylesheet" type="text/css" />

    <link href="<%= Page.ResolveUrl ("~/plugins/fontawesome-free/css/all.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/plugins/icheck-bootstrap/icheck-bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <%--<link href="<%= Page.ResolveUrl ("~/dist/css/adminlte.min.css") %>" rel="stylesheet" type="text/css" />--%>

    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style type="text/css">
        .button_bg {
            background-color: #009da5;
        }

        .tablecss {
            width: 35%;
            display: inline-block;
            padding-top: 15px;
            font-size: 13px;
        }

        .button3:hover {
            background-color: #f99d1c;
            color: black;
            border: 2px solid #009da5;
        }

        .tablecss td {
            padding: 5px;
        }

        .td:nth-child(1) {
            width: 5%;
        }

        .td:nth-child(2) {
            width: 3%;
        }

        .td:nth-child(3) {
            width: 20%;
        }

        .head-column {
            background: #c5c6c9;
        }

        .panel-border {
            border-radius: 15px 15px 15px 15px;
        }

        .colored-image {
            width: 200px;
            height: 200px;
        }

        .text-center {
            display: block;
            text-align: center !important;
        }

        i.fa {
            color: #009da5 !important;
        }

        img.find_replace {
            color: #009da5 !important;
            fill: white !important;
        }

        a {
            font-family: Graphik !important;
            color: #009da5 !important;
        }

            a:hover {
                color: white !important;
            }

        .icon:hover {
            opacity: 1;
            background-color: #f99d1c !important;
        }
       
        a:hover i.fa {
            color: white !important;
        }

        body {
            font-family: Graphik !important;
        }

        h4 {
            font-family: Graphik !important;
            font-weight: normal !important;
        }

        .shadow {
            box-shadow: 0px 6px 12px 6px #EEE;
            -webkit-box-shadow: 0px 6px 12px 6px #EEE;
            -moz-box-shadow: 0px 6px 12px 6px #EEE;
        }

        div.col-lg-2.col-md-3.col-sm-4.col-6 {
            padding: 10px !important;
        }
        .navbar-fixed-top {
      z-index: 1030;
    }
    /* Make the content scrollable */
    .scrollable-content {
      overflow-y: auto;
      max-height: calc(100vh - 70px); /* Adjust this value based on your navbar height */
    }
    .panel-sidebar{
        height: calc(100vh - 33px);
    }
        @media screen and (min-width: 1500px) {
            .col-lg-3 {
                padding: 10px;
                width: 16.6%;
            }
        }
        @media screen and (max-width: 1400px) {
            .col-lg-3 {
                padding: 10px;
            }
        }
   .input-group{
	position:relative;
	display:-ms-flexbox;
	display:flex;
	-ms-flex-wrap:wrap;
	flex-wrap:wrap;
	-ms-flex-align:stretch;
	align-items:stretch;
	width:300px;
    }
   .input-group>.custom-file,.input-group>.custom-select,.input-group>.form-control,.input-group>.form-control-plaintext{
	position:relative;
	-ms-flex:1 1 0%;
	flex:1 1 0%;
	min-width:0;
	margin-bottom:0
}
.input-group>.custom-file+.custom-file,.input-group>.custom-file+.custom-select,.input-group>.custom-file+.form-control,.input-group>.custom-select+.custom-file,.input-group>.custom-select+.custom-select,.input-group>.custom-select+.form-control,.input-group>.form-control+.custom-file,.input-group>.form-control+.custom-select,.input-group>.form-control+.form-control,.input-group>.form-control-plaintext+.custom-file,.input-group>.form-control-plaintext+.custom-select,.input-group>.form-control-plaintext+.form-control{
	margin-left:-1px
}
.input-group>.custom-file .custom-file-input:focus~.custom-file-label,.input-group>.custom-select:focus,.input-group>.form-control:focus{
	z-index:3
}
.input-group>.custom-file .custom-file-input:focus{
	z-index:4
}
.input-group>.custom-select:not(:last-child),.input-group>.form-control:not(:last-child){
	border-top-right-radius:0;
	border-bottom-right-radius:0
}
.input-group>.custom-select:not(:first-child),.input-group>.form-control:not(:first-child){
	border-top-left-radius:0;
	border-bottom-left-radius:0
}
.input-group>.custom-file{
	display:-ms-flexbox;
	display:flex;
	-ms-flex-align:center;
	align-items:center
}
.input-group>.custom-file:not(:last-child) .custom-file-label,.input-group>.custom-file:not(:last-child) .custom-file-label::after{
	border-top-right-radius:0;
	border-bottom-right-radius:0
}
.input-group>.custom-file:not(:first-child) .custom-file-label{
	border-top-left-radius:0;
	border-bottom-left-radius:0
}
   .card{
	position:relative;
	display:-ms-flexbox;
	display:flex;
	-ms-flex-direction:column;
	flex-direction:column;
	min-width:0;
	word-wrap:break-word;
	background-color:#fff;
	background-clip:border-box;
	border:0 solid rgba(0,0,0,.125);
	border-radius:.25rem;
    width:350px;
    
}
   .input-group-text{
	display:-ms-flexbox;
	display:flex;
	-ms-flex-align:center;
	align-items:center;
	padding:.375rem .75rem;
	margin-bottom:0;
	font-size:1rem;
	font-weight:400;
	line-height:1.5;
	color:#495057;
	text-align:center;
	white-space:nowrap;
	background-color:#e9ecef;
	border:1px solid #ced4da;
	border-radius:.25rem
}
.input-group-append,.input-group-prepend{
	display:-ms-flexbox;
	display:flex
}
.input-group-append .btn,.input-group-prepend .btn{
	position:relative;
	z-index:2
}
.input-group-append .btn:focus,.input-group-prepend .btn:focus{
	z-index:3
}
.input-group-append .btn+.btn,.input-group-append .btn+.input-group-text,.input-group-append .input-group-text+.btn,.input-group-append .input-group-text+.input-group-text,.input-group-prepend .btn+.btn,.input-group-prepend .btn+.input-group-text,.input-group-prepend .input-group-text+.btn,.input-group-prepend .input-group-text+.input-group-text{
	margin-left:-1px
}
.input-group-prepend{
	margin-right:-1px
}
.input-group-append{
	margin-left:-1px
}

.icheck-primary>input:first-child:not(:checked):not(:disabled):hover+input[type=hidden]+label::before,.icheck-primary>input:first-child:not(:checked):not(:disabled):hover+label::before{
	border-color:#007bff
}
.icheck-primary>input:first-child:not(:checked):not(:disabled):focus+input[type=hidden]+label::before,.icheck-primary>input:first-child:not(:checked):not(:disabled):focus+label::before{
	border-color:#007bff
}
.icheck-primary>input:first-child:checked+input[type=hidden]+label::before,.icheck-primary>input:first-child:checked+label::before{
	background-color:#007bff;
	border-color:#007bff
}
    </style>
    
      <script type="text/javascript">
            function ShowMessage(message, messagetype) {
                var cssclass;
                switch (messagetype) {
                    case 'Success':
                        cssclass = 'alert-success'
                        break;
                    case 'Error':
                        cssclass = 'alert-danger'
                        break;
                    case 'Warning':
                        cssclass = 'alert-warning'
                        break;
                    default:
                        cssclass = 'alert-info'
                }
                // class="alert fade in ' + cssclass + '"
                $('#alert_container').append('<div id="alert_div" role="alert" style = "width:350px ;  box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51);" class="alert ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:blue">' + message + '</span></div>');

                //setTimeout(function () {
                //    $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                //        $("#alert_div").remove();
                //    });
                //}, 5000);//5000=5 seconds
            };

    </script>
      
    
    <%--<link href="<%= Page.ResolveUrl ("~/CSS/googlefont.css") %>" rel="stylesheet" type="text/css" />--%>
</head>
<body class="hold-transition login-page" style="background-image:url(Image/BG_DGT.png); background-size:cover !important; overflow:hidden;"> <%--class="hold-transition login-page"--%>
        <div class="container" style="margin-top: 15px; width:100%; height:100%">
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-4 panel panel-default panel-border shadow"
                    style="border: 1px solid #009da5; overflow: hidden; border-radius: 15px !important; background-color: white;">
                    <div class="panel-sidebar">
                        <img src="Image/Artwork_Culture.png" style="width: 100%; height: 100%" class="find_replace" alt="no image found" />
                    </div>
                </div>

                <div class="col-lg-8 col-md-8 col-sm-8 col-8"
                style="overflow: hidden; border-radius: 15px !important;">
                 
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />

                 <div class="login-box" align ="center">
                    <div class="login-logo">
                        <img src="Image/logo-htb_v4_full_2.png" style="width: 150px!important;" />
                    </div>
                    <!-- /.login-logo -->

                    <div class="card">
                        <div class="card-body login-card-body">
                            <p></p>
                            <p class="login-box-msg">Sign in to Channel Banking System</p>

                            <form method="post" runat="server">
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="UserName"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <span class="fa fa-users"></span>
                                        </div>
                                    </div>
                                </div>

                                <p></p>
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <span class="fa fa-key"></span>
                                        </div>
                                    </div>
                                </div>
                                
                                <p></p>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="icheck-primary" style="margin-left:20px;">
                                            <input type="checkbox" id="remember" />
                                            <label for="remember">
                                                Remember Me
                                            </label>
                                        </div>
                                    </div>

                                    <div class="col-4">
                                        <button id="Button1" runat="server" class="btn btn-sm button_bg button3" onserverclick="Button1_Click" style="width:80px; margin-left:30px;">
                                           <span style="color:white;"> Sign in <span class="fa fa-solid fa-sign-in"></span></span></button>
                                    </div>

                                </div>


                                <div class="row user-control">
                                    <div class="col-12">
                                        <div id="alert_container"></div>
                                    </div>
                                </div>

                                <p></p>
                            </form>
                        </div>
                    </div>
                    <!-- /.login-box-body -->
                </div>
                    

                
                    
                </div>
            </div>
             
        </div>

              
<script src="<%= Page.ResolveUrl ("~/plugins/jquery/jquery.min.js")%>" type="text/javascript"></script>
<script src="<%= Page.ResolveUrl ("~/plugins/bootstrap/js/bootstrap.bundle.min.js")%>" type="text/javascript"></script>
<script src="<%= Page.ResolveUrl ("~/dist/js/adminlte.min.js")%>" type="text/javascript"></script>

</body>
</html>
