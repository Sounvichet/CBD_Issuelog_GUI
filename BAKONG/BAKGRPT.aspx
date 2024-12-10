<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BAKGRPT.aspx.cs" Inherits="BAKONG_BAKGRPT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />


    <script src="<%= Page.ResolveUrl ("~/js/jquery-1.11.1.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <style>
        .button_bg {
            background-color: #009da5;
        }

        .category_bg {
            background-color: #f99d1c;
        }

        .gvItemCenter {
            text-align: center;
        }

        .gvHeaderCenter {
            text-align: center;
        }

        .lds-roller {
            display: inline-block;
            position: relative;
            width: 80px;
            height: 80px;
        }

            .lds-roller div {
                animation: lds-roller 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
                transform-origin: 40px 40px;
            }

                .lds-roller div:after {
                    content: " ";
                    display: block;
                    position: absolute;
                    width: 7px;
                    height: 7px;
                    border-radius: 50%;
                    background: #cef;
                    margin: -4px 0 0 -4px;
                }

                .lds-roller div:nth-child(1) {
                    animation-delay: -0.036s;
                }

                    .lds-roller div:nth-child(1):after {
                        top: 63px;
                        left: 63px;
                    }

                .lds-roller div:nth-child(2) {
                    animation-delay: -0.072s;
                }

                    .lds-roller div:nth-child(2):after {
                        top: 68px;
                        left: 56px;
                    }

                .lds-roller div:nth-child(3) {
                    animation-delay: -0.108s;
                }

                    .lds-roller div:nth-child(3):after {
                        top: 71px;
                        left: 48px;
                    }

                .lds-roller div:nth-child(4) {
                    animation-delay: -0.144s;
                }

                    .lds-roller div:nth-child(4):after {
                        top: 72px;
                        left: 40px;
                    }

                .lds-roller div:nth-child(5) {
                    animation-delay: -0.18s;
                }

                    .lds-roller div:nth-child(5):after {
                        top: 71px;
                        left: 32px;
                    }

                .lds-roller div:nth-child(6) {
                    animation-delay: -0.216s;
                }

                    .lds-roller div:nth-child(6):after {
                        top: 68px;
                        left: 24px;
                    }

                .lds-roller div:nth-child(7) {
                    animation-delay: -0.252s;
                }

                    .lds-roller div:nth-child(7):after {
                        top: 63px;
                        left: 17px;
                    }

                .lds-roller div:nth-child(8) {
                    animation-delay: -0.288s;
                }

                    .lds-roller div:nth-child(8):after {
                        top: 56px;
                        left: 12px;
                    }

        @keyframes lds-roller {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }

        :root {
            --htb: #009FA5;
            --primary: #009FA5;
            --htb-light: #80CFD2;
            --white: #ffffff;
            --grey: grey;
            --half-white: rgba(255, 255, 255, 0.5);
            --border-nomal: #ced4da;
        }

        #loading {
            position: fixed;
            top: 0;
            left: 0;
            bottom: 0;
            right: 0;
            width: 100%;
            height: 100%;
            /* display: none; */
            margin: 0 auto;
            text-align: center;
            background: rgba(0, 159, 165, 0.7);
            text-align: center;
            transition: visibility 0s, opacity 0.5s linear;
            z-index: 100000;
            display: none;
            backdrop-filter: blur(6px);
        }

            #loading .loading-content {
                position: absolute;
                left: 50%;
                top: 50%;
                -webkit-transform: translate(-50%, -50%);
                transform: translate(-50%, -50%);
            }

            #loading .spinner-bg {
                /* width: 50px; */
                /* height: 50px; */
                margin: 0 auto;
                padding: 9px;
                /* background: #ffffff; */
                border-radius: 50%;
            }

                #loading .spinner-bg .spinner-border {
                    color: #009FA5; /*var(--htb)*/
                }

            #loading .spinner-content {
                text-align: center;
                margin: 15px auto;
                font-weight: 400;
                color: #ffffff;
            }

        .form-control {
            font-size: 15px;
            border-radius: 5px 5px 5px 5px;
            padding: 2px 2px 2px 2px;
            height: auto;
            margin: 0 auto;
        }

        .user-control {
            padding-top: 5px;
        }

        .textboxstyle {
            font-size: 15px;
            border-radius: 5px 5px 5px 5px;
            border: 1px solid #c4c4c4;
            padding: 2px 2px 2px 2px;
            vertical-align: middle !important;
            /*text-align:center!important;*/
        }

            .textboxstyle:focus {
                border: 1px solid #7bc1f7;
            }

        .tdalign {
            vertical-align: middle !important;
            text-align: center !important;
        }

        .getscrollcolor a:hover {
            background-color: black;
            color: gray;
        }


        .align-middle a:hover {
            background-color: #f99d1c;
        }

        .auto-style1 {
            height: 32px;
        }
    </style>


    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-datepicker3.standalone.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap-theme.min.css") %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl ("~/Datetimecss/bootstrap.min.css") %>" rel="stylesheet" />

    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/bootstrap-datepicker.en-GB.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl ("~/Datetimejs/responce.js") %>" type="text/javascript"></script>
    <%--<script src="<%= Page.ResolveUrl ("~/Datetimejs/jquery.maskedinput.min.js") %>" type="text/javascript"></script>--%>
    <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        jQuery(function ($) {
            $("#<%=t_start_date.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $("#<%=t_end_date.ClientID %>").datepicker({
                format: "dd-M-yyyy",
                orientation: "top right",
                autoclose: true,
                todayHighlight: true,
                toggleActive: true
            });
            $('#T_To').mask('99-aaa-9999');
        });
    </script>


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
            $('#alert_container').append('<div id="alert_div" role="alert" style = "box-shadow: 3px 4px 6px 0px rgba(0,0,0,0.51); background-color:#00ff21" class="alert fade in ' + cssclass + '" ><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong style="color:black; text-decoration: underline;">' + messagetype + '!</strong> <span style="color:black">' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 5000);//5000=5 seconds
        };
    </script>
        
    <script>
        function showLoading() {
            document.getElementById('loading').style.display = 'block';
            setTimeout(() => {
                  document.getElementById('loading').style.display = 'none';
            }, 5000);
        };

        function hideLoading() {
            document.getElementById('loading').style.display = 'none';
        }
        
    </script>
    

</head>
<body style="height: 500px">

    <form id="form1" runat="server">
        <section class="content">

            <div class="row">
                <div class="col-md-12">
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <div class="box-header with-border">
                                <i class="fa fa-money"></i>
                                <h3 class="box-title" style="color: blue">BAKONG Payment Report</h3>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <!-- Loading -->
                                        <a href="javascript:;" id="testClick"></a>
                                        <div id="loading">
                                            <div class="loading-content">
                                                <p style="color: #ffffff;">Processing...</p>
                                                <div class="spinner-bg">
                                                    <div class="lds-roller">
                                                        <div></div>
                                                        <div></div>
                                                        <div></div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="alert_container">
                                        </div>
                                    </div>
                                </div>
                                <div class="row user-control">
                                    <div class="col-md-12">
                                        <table>
                                            <tr>
                                             <%--   <td>
                                                    <asp:Label ID="l_settlement_type" runat="server">SETTLEMENT_TYPE</asp:Label>
                                                    <asp:DropDownList ID="d_settlement" CssClass="textboxstyle" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                </td>--%>


                                                <td>
                                                    <asp:Label ID="t_report_type" runat="server">Report_type</asp:Label>
                                                    <asp:DropDownList ID="d_report_type" runat="server" CssClass="textboxstyle"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="l_start_date" runat="server">Start_date</asp:Label>
                                                    <asp:TextBox ID="t_start_date" runat="server" CssClass="textboxstyle"></asp:TextBox>

                                                </td>
                                                <td>
                                                    <asp:Label ID="l_end_date" runat="server">End_date</asp:Label>
                                                    <asp:TextBox ID="t_end_date" runat="server" CssClass="textboxstyle"></asp:TextBox>
                                                </td>
                                                <td>
                                                        <div class="btn-group">
                                                        <button type="button" class="btn btn-sm btn-primary button_bg">Action</button>
                                                        <button type="button" class="btn btn-sm btn-primary dropdown-toggle button_bg" data-toggle="dropdown">
                                                            <span class="caret"></span>
                                                            <span class="sr-only">Toggle Dropdown</span>
                                                        </button>


                                                        <ul class="dropdown-menu" role="menu" id="iddropdown" style="background-color: #00A7A5; width: 300px">
                                                            <li style="height: 20px">
                                                                <span class="align-middle">
                                                                    <a id="d_Review" href="#" class="fa fa-eye fa-lg" style="color: black; height: auto; margin-left: 10px;" onserverclick="d_Review_ServerClick" onclick="$('#loading').show();" runat="server">Review</a>
                                                                </span>
                                                            </li>

                                                            <li style="height: 20px">
                                                                <span class="align-middle">
                                                                    <a id="d_export" href="#" class="fa fa-file-excel-o fa-lg" style="color: black; height: auto; margin-left: 10px;" onserverclick="d_export_ServerClick" onclick="showLoading();" runat="server">Export</a>
                                                                </span>
                                                            </li>

                                                            <%--  <li style="height: 20px">
                                                                <span class="align-middle">
                                                                    <a id="xml_export" href="#" class="fa fa-file-excel-o fa-lg" style="color: black; height: auto; margin-left: 10px;" onserverclick="xml_export_ServerClick" onclick="showLoading();" runat="server">Xml Export</a>
                                                                </span>
                                                            </li>--%>

                                                        </ul>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    <label runat="server" style="color: red;" id="lblErrorMessage" visible="false"></label>
                                                </td>
                                            </tr>


                                        </table>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12 textboxstyle category_bg">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Report listing"></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="grid_report" CssClass="table table-bordered table-hover" runat="server" Font-Size="11px" AutoGenerateColumns="true" GridLines="None" RowStyle-Wrap="false">
                                                <HeaderStyle CssClass="gvHeaderCenter" BackColor="#00A7A5" Font-Bold="true" ForeColor="#f5f5f5" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="l_visa" runat="server">GetCount :</asp:Label><asp:Label ID="l_count_VISA" runat="server" ForeColor="Blue"></asp:Label>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
