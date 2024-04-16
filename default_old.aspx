<%@ Page Language="VB" AutoEventWireup="false" CodeFile="default_old.aspx.vb" Inherits="Default_old" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>SSS Poker Affiliate System</title>
    <link rel="icon" type="image/png" sizes="16x16" href="favicon.png" />
    <!-- BASIC -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="js/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <!-- End BASIC -->
    <link type="text/css" rel="stylesheet" href="css/webticker.css" />
    <script src="js/jquery.webticker.js"></script>

    <script type="text/javascript">
        $(function(){})

        function refreshcode() {
            document.getElementById("img_vcode").src = "vcode.aspx?=<%Response.Write(func())%>" + new Date().getTime();
        }

        $(document).ready(function () {
            $("#webticker").webTicker();
        });
    </script>
</head>
<body id="admin">
    <form id="form1" runat="server">
        <div>
            <div class="container admistration">
                <div class="col-lg-1 col-lg-offset-3 col-md-1 col-md-offset-3 col-sm-1 col-sm-offset-2 col-xs-1" style="padding: 0px;">
                    <img src="images/login/bar-left.png" style="float: right">
                </div>
                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-10" align="center" id="login-form">

                    <img class="img-responsive" src="images/login/logo-sss-poker.png" >
                    <ul id="webticker">
                        <asp:Literal ID="ltrNotification" runat="server"></asp:Literal>
                    </ul>
                    <fieldset class="admin">

                        <p class="col-lg-offset-3 col-lg-6 col-md-offset-3 col-md-6 col-sm-offset-3 col-sm-6 col-xs-10 col-xs-offset-1">Login ID</p>
                        <asp:TextBox ID="txtLoginID" runat="server" CssClass="col-lg-offset-3 col-lg-6 col-md-offset-3 col-md-6 col-sm-offset-3 col-sm-6 col-xs-10 col-xs-offset-1" placeholder="Login ID" AutoCompleteType="Disabled"></asp:TextBox>
                        <p class="col-lg-offset-3 col-lg-6 col-md-offset-3 col-md-6 col-sm-offset-3 col-sm-6 col-xs-10 col-xs-offset-1">Password</p>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="col-lg-offset-3 col-lg-6 col-md-offset-3 col-md-6 col-sm-offset-3 col-sm-6 col-xs-10 col-xs-offset-1" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <p class="col-lg-offset-3 col-lg-6 col-md-offset-3 col-md-6 col-sm-offset-3 col-sm-6 col-xs-10 col-xs-offset-1">Code</p>
                        <asp:TextBox ID="txtCode" runat="server" CssClass="col-lg-offset-3 col-lg-3 col-md-offset-3 col-md-3 col-sm-offset-3 col-sm-3 col-xs-4 col-xs-offset-1" placeholder="Code" AutoCompleteType="Disabled"></asp:TextBox>
                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-6" style="padding: 0px">
                            <img id="img_vcode" src="vcode.aspx?r=<%Response.Write(func())%>" style="margin: 0px 5px">
                            <a href="#"  onclick="refreshcode()">
                                <img src="images/refresh.png"></a>
                        </div>
                    </fieldset>
                    <div class="col-lg-12">
                        <asp:LinkButton ID="btnSubmit" runat="server"><img id="hover" src="images/login/login-button.png" alt="Login Now" title="Login Now"></asp:LinkButton>
                    
                    </div>
                    <div class="col-lg-12"><asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="10"></asp:Label></div>
                </div>
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1" style="padding: 0px;">
                    <img src="images/login/bar-right.png">
                </div>

            </div>
        </div>
    </form>
</body>
</html>
