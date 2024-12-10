<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
<%--
    
    <script src="<%= Page.ResolveUrl("~/js/bootstrap.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/js/jquery.min.js")%>"></script>--%>
  <link href="<%= Page.ResolveUrl ("~/CSS/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
  <link href="<%= Page.ResolveUrl ("~/CSS/AdminLTE.min.css") %>" rel="stylesheet" type="text/css" />
  <link href="<%= Page.ResolveUrl ("~/font-awesome/css/font-awesome.min.css")%>" rel="stylesheet" type="text/css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body style="background-color:#ecf0f5">
    <form id="form1" runat="server">

        <section class="content">
                     <div class="row">
                            <div class="col-md-12">
                                    <div class="box box-primary">
                                           <div class="box-body box-profile">
                                          <div class="box-header with-border">
                                               <i class="fa fa-home"></i>
                                                <h3 class="box-title" style="color:blue">Welcome to issuelog System </h3>
                                          </div>

                                               <div class="box-body">
                                                  <%-- <div class="row">
                                                     <div class="col-xs-12 col-md-4">
                                                          <div>
                                                             <iframe src="https://covid19-map.cdcmoh.gov.kh/list_views?location_info=00" class="embed-responsive-item" style="width: 100%; height: 650px; border: 0;"></iframe>
                                                         </div>
                                                     </div>--%>

                                                   <div class="col-xs-12 col-md-12">
                                              
                                                       <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                                                            <!-- Indicators -->
                                                            <ol class="carousel-indicators">
                                                              
                                                            <li data-target="#carousel-example-generic" data-slide-to="1" class="active"></li>
                                
                                                            </ol>

                                                            <!-- Wrapper for slides -->
                                                            <div class="carousel-inner">
                                                              <div class="item active">
                                                                  <img class="img-responsive" src="img/3kom_3kapea_v2_opt.jpg" width="100%" />
                                                              </div>
                                                            </div>
                                                           

                                                            <!-- Left and right controls -->
                                                            <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                                                              <span class="fa fa-angle-left"></span>
                                                              <span class="sr-only">Previous</span>
                                                            </a>
                                                            <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                                                              <span class="fa fa-angle-right"></span>
                                                              <span class="sr-only">Next</span>
                                                            </a>
                                                          
                                                        </div>

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
