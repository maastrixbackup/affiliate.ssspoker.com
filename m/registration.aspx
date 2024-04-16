<%@ Page Language="VB" AutoEventWireup="false" CodeFile="registration.aspx.vb" Inherits="registrationMobile" %>

<!DOCTYPE HTML>

<html lang="en">
<head>
    <title>SSS POKER</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="apple-mobile-web-app-title" content="Mobile Poker">

    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="../resources/images/apple-icon-57x57.png">
    <link rel="shortcut icon" href="../resources/images/favicon-32x32.png" />
    <link rel="apple-touch-startup-image" href="img/splash/splash-screen.png" media="screen and (max-device-width: 320px)" />
    <link rel="apple-touch-startup-image" href="img/splash/splash-screen_2x.png" media="(max-device-width: 480px) and (-webkit-min-device-pixel-ratio: 2)" />
    <link rel="apple-touch-startup-image" sizes="640x1096" href="img/splash/splash-screen_3x.png" />
    <link rel="apple-touch-startup-image" sizes="1024x748" href="img/splash/splash-screen-ipad-landscape.png" media="screen and (min-device-width : 481px) and (max-device-width : 1024px) and (orientation : landscape)" />
    <link rel="apple-touch-startup-image" sizes="768x1004" href="img/splash/splash-screen-ipad-portrait.png" media="screen and (min-device-width : 481px) and (max-device-width : 1024px) and (orientation : portrait)" />
    <link rel="apple-touch-startup-image" sizes="1536x2008" href="img/splash/splash-screen-ipad-portrait-retina.png" media="(device-width: 768px) and (orientation: portrait) and (-webkit-device-pixel-ratio: 2)" />
    <link rel="apple-touch-startup-image" sizes="1496x2048" href="img/splash/splash-screen-ipad-landscape-retina.png" media="(device-width: 768px) and (orientation: landscape)	and (-webkit-device-pixel-ratio: 2)" />
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="../../assets/img/favicon/apple-icon-57x57.png">

    <link rel="shortcut icon" href="../resources/images/favicon-32x32.png" />

    <link rel="stylesheet" href="../resources/css/fontawesome-free-5.15.4-web.css" crossorigin="anonymous" />
    <script defer src="../resources/js/fontawesome-free-5.15.4-web.js"></script>
    <!-- <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha256-eZrrJcwDc/3uDhsdt61sL2oOBY362qM3lon1gyExkL0=" crossorigin="anonymous" /> -->
    <link href="../resources/css/bootstrap.min.css" rel="stylesheet">
    <link href="../resources/css/style.css" rel="stylesheet" type="text/css">
    <link href="../resources/css/framework.css" rel="stylesheet" type="text/css">
    <link href="../resources/css/owl.carousel.css" rel="stylesheet" type="text/css">
    <link href="../resources/css/owl.theme.css" rel="stylesheet" type="text/css">
    <link href="../resources/css/swipebox.css" rel="stylesheet" type="text/css">
    <link href="../resources/css/colorbox.css" rel="stylesheet" type="text/css">
    <link href="../resources/css/li-scroller.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../resources/js/jquery.js"></script>
    <!--<script type="text/javascript" src="/resources/js/bootstrap.min.js"></script>-->
    <script type="text/javascript" src="../resources/js/jqueryui.js"></script>
    <script type="text/javascript" src="../resources/js/owl.carousel.min.js"></script>
    <script type="text/javascript" src="../resources/js/jquery.swipebox.js"></script>
    <script type="text/javascript" src="../resources/js/jquery.colorbox.js"></script>
    <script type="text/javascript" src="../resources/js/snap.js"></script>
    <script type="text/javascript" src="../resources/js/contact.js"></script>
    <script type="text/javascript" src="../resources/js/custom.js"></script>
    <script type="text/javascript" src="../resources/js/framework.js"></script>
    <script type="text/javascript" src="../resources/js/framework.launcher.js"></script>
    <script type="text/javascript" src="../resources/js/jquery.form.2.93.js"></script>
    <script type="text/javascript" src="../resources/js/jquery.maskedinput-1.3.min.js"></script>
    <script type="text/javascript" src="../resources/js/framework.launcher.js"></script>

    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-36423566-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>

    <script language="JavaScript" type="text/javascript">
        //<!--
        function removecomma(a) {
            var res = '';
            for (i = 0; i < a.length; i++) {
                if (a.substr(i, 1) == ".") { }
                else { res += a.substr(i, 1) }
            }
            return res;
        }

        function Comma(number) {
            number = '' + number;
            if (number.length > 3) {
                var mod = number.length % 3;
                var output = (mod > 0 ? (number.substring(0, mod)) : '');
                for (i = 0; i < Math.floor(number.length / 3); i++) {
                    if ((mod == 0) && (i == 0))
                        output += number.substring(mod + 3 * i, mod + 3 * i + 3);
                    else
                        output += '.' + number.substring(mod + 3 * i, mod + 3 * i + 3);
                }
                return (output);
            }
            else return number;
        }

        function clickBank(a) {

            var fom = document.fdeposit;       /*nama form */
            var s = fom.tBName;
            //var ada = eval("fom.data");
            //var pilih = eval("fom.pilih");


            var tmp = s.selectedIndex;
            var hb = eval("fom.hBNo" + tmp);
            var hc = eval("fom.hBAcc" + tmp);
            var hbx = eval("fom.hBNo");
            var hcx = eval("fom.hBAcc");
            //var tb = eval("fom.tBNo");

            var tb = document.getElementById("tBNo");
            var tc = document.getElementById("tBAcc");

            //alert(document.getElementById("tBNo"))

            tb.innerHTML = hb.value;
            tc.innerHTML = hc.value;
            hbx.value = hb.value;
            hcx.value = hc.value;
            //tb.value = hb.value;
            //fom.tBAcc.value = hc.value;

        }

        function depAmount(a) {
            var fom = document.fdeposit;       /*nama form */
            var amt = eval("fom.amount");
            var am = document.getElementById("amnt");
            var val = amt.value;
            am.innerHTML = 'IDR ' + Comma(val);
        }
//-->
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".dropdown img.flag").addClass("flagvisibility");

            $(".dropdown dt a").click(function () {
                $(".dropdown dd ul").toggle();
            });

            $(".dropdown dd ul li a").click(function () {
                var text = $(this).html();
                $(".dropdown dt a span").html(text);
                $(".dropdown dd ul").hide();
            });

            function getSelectedValue(id) {
                return $("#" + id).find("dt a span.value").html();
            }

            $(document).bind('click', function (e) {
                var $clicked = $(e.target);
                if (!$clicked.parents().hasClass("dropdown"))
                    $(".dropdown dd ul").hide();
            });

            $(".forlogin").click(function () {
                $('.clicklog').click();
            });

            $("#flagSwitcher").click(function () {
                $(".dropdown img.flag").toggleClass("flagvisibility");
            });

            $('.deploy-sidebar').click(function () {
                $('.page-sidebar').toggle();
                $(".page-content").toggleClass("opa02");
            });

            $('.shortcut-close').click(function () {
                $('.page-sidebar').toggle();
                if ($(".page-content").hasClass("opa02")) {
                    $(".page-content").removeClass("opa02");
                }
            });
        });
    </script>


</head>

<!--livechat-->
<!--Start of Tawk.to Script-->
<script type="text/javascript">
    var Tawk_API = Tawk_API || {}, Tawk_LoadStart = new Date();
    (function () {
        var s1 = document.createElement("script"), s0 = document.getElementsByTagName("script")[0];
        s1.async = true;
        s1.src = 'https://embed.tawk.to/60e57341d6e7610a49aa0812/1fa04keor';
        s1.charset = 'UTF-8';
        s1.setAttribute('crossorigin', '*');
        s0.parentNode.insertBefore(s1, s0);
    })();
</script>
<!--End of Tawk.to Script-->
<!--livechat-->
<body>
    <!--
<div id="preloader">
	<div id="status">
    	<p class="center-text">
			Loading the content...
            <em>Loading depends on your connection speed!</em>
        </p>
    </div>
</div>
-->
    <div class="all-elements">

        <div id="sidebar" class="page-sidebar">

            <div class="page-sidebar-scroll">

                <div class="sidebar-shortcuts">
                    <a href="/m/home.aspx?aff=<%= Request.QueryString("aff")%>">
                        <img src="../resources/images/logo.png" class="side-logo"></a>
                    <a href="#" class="shortcut-close"></a>
                </div>


                <br>
                <div class="col-xs-12">
                    <div class="col-xs-12 p-0">
                        <a href="javascript:void(0)" class="white"><i class="fa fa-user" aria-hidden="true"></i><span style="font-size: 0.8em;">게임 이용을 위하여 로그인 혹은 가입하여 주시기 바랍니다.</span> </a>
                    </div>
                    <div class="col-xs-12 p-0" style="padding: 10px 0;">
                        <div class="col-xs-6 p-0" style="padding-right: 5px;">
                            <button class="nbtn nbtn-register" onclick='window.location.href = "/m/registrations.aspx?aff=<%= Request.QueryString("aff")%>";'>가입하기</button>
                        </div>
                        <div class="col-xs-6 p-0" style="padding-left: 5px;">
                            <button class="forlogin nbtn nbtn-login">로그인</button>
                        </div>
                    </div>
                </div>

                <br>
                <div class="col-xs-12 mtb-10">
                    <div class="col-xs-12 p-0">
                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white"><i class="fa fa-gamepad" aria-hidden="true"></i>이용가능 게임 </a>
                    </div>
                </div>

                <br>
                <div class="col-xs-12 mtb-10">
                    <div class="col-xs-12 p-0">
                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white"><i class="fa fa-users" aria-hidden="true"></i>친구추천</a>
                    </div>
                </div>

                <br>
                <div class="col-xs-12 mtb-10">
                    <div class="col-xs-12 p-0">
                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white"><i class="fa fa-bullhorn" aria-hidden="true"></i>프로모션 </a>
                    </div>
                </div>

                <br>
                <div class="col-xs-12 mtb-10">
                    <div class="col-xs-12 p-0">
                        <a href="javascript:void(0)" class="white"><i class="fa fa-download" aria-hidden="true"></i>모바일 </a>
                    </div>
                    <div class="col-xs-12 p-0 mt-10">
                        <div class="col-xs-6 p-0">
                            <a href="itms-services://?action=download-manifest&url=https://www.pyreneesakbash.com/iphone/manifest.plist">
                                <div class="bottomdwnld" style="margin-right: 13px;">
                                    <div class="col-xs-3 p-0">
                                        <img src="../resources/images/apple1.svg">
                                    </div>
                                    <div class="col-xs-9 p-0">
                                        <span class="white">아이폰 다운로드</span>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-xs-6 p-0">
                            <a href="https://www.pyreneesakbash.com/m-sbobet/android.php">
                                <div class="bottomdwnld">
                                    <div class="col-xs-3 p-0">
                                        <img src="../resources/images/android2.svg">
                                    </div>
                                    <div class="col-xs-9 p-0">
                                        <span class="white">안드로이드 다운로드</span>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>

                <br>
                <div class="col-xs-12 mtb-10">
                    <div class="col-xs-12 p-0">
                        <a href="javascript:void(0)" class="white getdwn"><i class="fa fa-phone" aria-hidden="true"></i>고객센터 <i class="fa fa-caret-down" aria-hidden="true" style="float: right; margin-top: 6px;"></i></a>
                    </div>
                    <div class="col-xs-12 pr-0 downst" style="margin-left: 20px; display: none;">

                        <div>
                            <img src="../resources/images/telegram.svg">
                            SSSPOKER1 
                        </div>

                        <%--<div>
                            <img src="/resources/images/wechat.svg">
                            SSSPOKER2 
                        </div>--%>

                        <div>
                            <img src="../resources/images/kakaotalk.svg">
                            SSSHOLDEM 
                        </div>

                        <div>
                            <img src="../resources/images/kpokerm.svg">
                            KAYPOKER.COM 
                        </div>
                    </div>
                </div>
                <script type="text/javascript">
                    $(".getdwn").on('click', function () {
                        $(".downst").toggle('slow');
                    });
                </script>

                <br>
                <div class="col-xs-12 mtb-10">
                    <div class="col-xs-12 p-0">
                        <a href="javascript:void(0)" class="white"><i class="fa fa-language" aria-hidden="true"></i>언어 선택 </a>
                        <div class="col-xs-12 p-0 moblang">
                            <a href="?lang=kr">
                                <img src="../resources/images/kr-colored.svg" width="25px"></a>
                            <a href="?lang=en">
                                <img src="../resources/images/en.svg" class="flag-img" width="25px"></a>
                        </div>
                    </div>
                </div>

                <!-- <div class="sidebar-breadcrumb">&copy; 2015 ssspk66.com. All Rights Reserved | 18+</div> -->

            </div>
        </div>

        <!--
    <div id="sidebar-right" class="page-sidebar-right">

        <div class="page-sidebar-scroll-right">

        	<div class="sidebar-shortcuts">
                <a href="#" class="shortcut-close"></a>
            </div>

            <div class="navigation-item">
                <div class="nav-items user-icon"></div>
            </div>

            <div class="sidebar-decoration"></div>

            <div class="navigation-item">
                <div class="nav-items chips-icon"><span class="orange">IDR 0</span></div>
            </div>

            <div class="sidebar-decoration"></div>

            <div class="navigation-item">
                <a href="../../logoff.php" class="nav-item logout-icon">LOG OUT</a>
            </div>

            <div class="sidebar-decoration"></div>

        </div>

    </div>
    -->
        <div id="content" class="page-content" data-snap-ignore="true">

            <div class="page-header">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="col-xs-2">
                            <a href="#" class="deploy-sidebar">
                                <i class="fa fa-bars fa-2x base-color" aria-hidden="true"></i>
                            </a>
                        </div>
                        <div class="col-xs-6 p-0">
                            <a href="/m/home.aspx?aff=<%= Request.QueryString("aff")%>">
                                <img src="../resources/images/logo.png" class="header-logo">
                            </a>
                        </div>
                        <div class="col-xs-4 ">
                            <div class="cur_crypt">
                                <a href="http://extra88.com/bitcoin/" target="_blank"><b>현재 실시간 코인가격</b></a>
                            </div>
                            <a href="#login_panel" class="clicklog deploy-login cboxElement"></a>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <marquee class='news-marq'>※공지※ [데일리 보너스 선택 : 롤링 3% 3배 / 5% 5배/ 10% 5배] 칩환율 현재 12배(1만원 = 12만칩)! 자세한 사항은 라이브쳇 문의 바랍니다. ※주의※ 비밀번호 노출에 대하여 유의하시기 바라며 비밀번호는 꼭 보안이 확실한 것으로 설정 바랍니다. 노출에 대한 피해는 회원의 부주의로 간주 될 수 있습니다. 현재 아이폰 어플 이용이 불가하오니 사파리로 모바일 웹 이용 부탁 드립니다.             </marquee>
                    </div>
                </div>
            </div>

            <div class="login_box" style="display: none;">
                <div id="login_panel" class="base-color">
                    <div class="container no-bottom">
                        <center>
                            <h3 class="base-color">로그인</h3>
                        </center>

                        <form method="post" action="/m/home.aspx?aff=<%= Request.QueryString("aff")%>">

                            <div class="form-group">
                                <span style="padding: 0 10px; font-size: 10px;">아이디</span>
                                <input id="아이디" class="input_me base-color" type="text" name="entered_login" value="" placeholder="아이디" onblur="if(this.value == '') { this.value='Username'}" onfocus="if (this.value == 'Username') {this.value=''}" required />
                            </div>

                            <div class="form-group">
                                <span style="padding: 0 10px; font-size: 10px;">비밀번호</span>
                                <input id="j_plain_password" class="input_me base-color" type="password" name="entered_password" value="Password" placeholder="Password" onblur="if(this.value == '') { this.value='Password'}" onfocus="if (this.value == 'Password') {this.value=''}" required />
                            </div>

                            <div class="form-group">
                                <span style="padding: 0 10px; font-size: 10px; float: left;">오른쪽숫자입력</span><br>
                                <input id="membervalidation" type="text" required autocomplete="off" name="entered_val" size='16' class="input_me base-color" placeholder="오른쪽숫자입력" maxlength="5" style="width: 53%; display: inline-block; float: left;">
                                <img src="../resources/images/captcha.png" alt="Validation Code" title="Validation Code" width="120" height="30" style="float: right; width: 45%; display: inline-block; -moz-border-radius: 4px; -webkit-border-radius: 4px; -khtml-border-radius: 4px; border-radius: 4px;" />
                            </div>

                            <!--<input id="mobile" type="hidden" name="mobile" value="mobile"  />-->

                            <div class="formSubmitButtonErrorsWrap">
                                <input type="submit" name="submit" class="forlogin nbtn nbtn-login" value="로그인" value="1" style="border-radius: 0;" />
                            </div>

                            <div class="decoration"></div>
                            <a class="forgot_pass base-color" href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">비밀번호 찾기</a>
                            <a class="new_register base-color" href="/m/registrations.aspx?aff=<%= Request.QueryString("aff")%>">가입하기</a>

                        </form>
                    </div>
                </div>
            </div>

            <div class="page-header-clear"></div>
            <div class="content">

                <div class="container main no-bottom">

                    <div class="wrapper">

                        <style type="text/css">
                            .big-notification {
                                position: sticky;
                                z-index: 9999;
                                width: 100%;
                                top: 70px;
                                margin-left: -10px;
                            }

                            .cekbtndong {
                                width: 40%;
                                font-size: 10px;
                                height: 25px;
                                border-radius: 5px;
                                background: #f2b61c;
                                background: -moz-linear-gradient(top, #f2b61c 0%, #cf8417 100%);
                                background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#f2b61c), color-stop(100%,#cf8417));
                                background: -webkit-linear-gradient(top, #f2b61c 0%,#cf8417 100%);
                                background: -o-linear-gradient(top, #f2b61c 0%,#cf8417 100%);
                                background: -ms-linear-gradient(top, #f2b61c 0%,#cf8417 100%);
                                background: linear-gradient(to bottom, #f2b61c 0%,#cf8417 100%);
                                filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f2b61c', endColorstr='#cf8417',GradientType=0 );
                            }
                        </style>

                        <div class="container no-bottom">
                            <h3>가입하기</h3>
                        </div>

                        <div class="decoration"></div>

                        <div class="res" id="res_reg" align="center">
                        </div>

                        <form runat="server" method="post" id="form_reg" style="margin-top: 14px;">

                            <div class="pg_1">
                                <div class="col-xs-12 p-0">
                                    <span>회원 정보</span>
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">아이디*</span>
                                    </div>
                                    <div class="col-xs-10 p-0">
                                        <asp:TextBox runat="server" ID="txtUsername" MaxLength="10" CssClass="no-br form-control" onfocus="this.value=''" onblur="fast_checking('user_name', 'txtUsername', 'txtNickname')" onkeyup="this.value=this.value.replace(/[^a-zA-Z0-9_]/g,'');" onkeypress="this.value=this.value.replace(/[^a-zA-Z0-9_]/g,'');" data-required="true" placeholder="아이디*"></asp:TextBox>
                                        <br>
                                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revUsername" runat="server" ControlToValidate="txtUsername" ValidationExpression="^[a-zA-Z0-9_]{5,255}$" ErrorMessage="Please input without whitespace." ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-xs-2 p-0">
                                        <div id="ceklis1" class="alert-btn"></div>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">별명은 알파벳과 숫자로 구성되어야 하며 아이디와 다르게 입력해 주세요.*</span>
                                    </div>
                                    <div class="col-xs-10 p-0">
                                        <asp:TextBox runat="server" ID="txtNickname" MaxLength="10" CssClass="no-br form-control" onfocus="this.value=''" onblur="fast_checking('user_nameid', 'txtNickname', 'txtUsername')" onkeyup="this.value=this.value.replace(/[^a-zA-Z0-9_]/g,'');" onkeypress="this.value=this.value.replace(/[^a-zA-Z0-9_]/g,'');" data-required="true" placeholder="별명은 알파벳과 숫자로 구성되어야 하며 아이디와 다르게 입력해 주세요.*"></asp:TextBox>
                                        <br>
                                        <asp:RequiredFieldValidator ID="rfvNickname" runat="server" ControlToValidate="txtNickname" ErrorMessage="Nickname is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-xs-2 p-0">
                                        <div id="ceklis2" class="alert-btn"></div>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0" style="display:none;">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">이름*</span>
                                    </div>
                                    <div class="col-xs-10 p-0">
                                        <asp:TextBox runat="server" ID="txtFullName" CssClass="no-br form-control" onkeypress='return (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122) || event.charCode = 32'></asp:TextBox>
                                        <br>
                                    </div>
                                    <div class="col-xs-2 p-0">
                                        <div id="ceklis2" class="alert-btn"></div>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">비밀번호*</span>
                                    </div>
                                    <div class="col-xs-10 p-0">
                                        <asp:TextBox runat="server" ID="txtPassword" CssClass="no-br form-control" TextMode="Password" onfocus="this.value=''" onblur="fast_checking('the_pass', 'txtPassword', '')" data-required="true" placeholder="알파벳, 숫자, @ 와 혼합하여 10자리로 입력해 주세요. 예) asdf12345@"></asp:TextBox>
                                        <br>
                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z@\d]{6,}$" ErrorMessage="Password must be alphanumeric and no symbol allowed." ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-xs-2 p-0">
                                        <div id="ceklis3" class="alert-btn"></div>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">비밀 번호 확인*</span>
                                    </div>
                                    <div class="col-xs-10 p-0">
                                        <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="no-br form-control" TextMode="Password" onfocus="this.value=''" onblur="fast_checking('the_cpass', 'txtConfirmPassword', 'txtPassword')" data-required="true" placeholder="비밀 번호 확인*"></asp:TextBox>
                                        <br>
                                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator runat="server" ID="cvPassword" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password NOT match." ForeColor="Red"></asp:CompareValidator>
                                    </div>
                                    <div class="col-xs-2 p-0">
                                        <div id="ceklis4" class="alert-btn"></div>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0 mtb-15">
                                    <a href="javascript:void(0)" class="cpg_1 white" align='right'><span>다음</span>&nbsp;&nbsp;&nbsp;<img src="../resources/images/right-arrow.png"></a>
                                </div>
                            </div>


                            <div class="pg_2" style="display: none;">
                                <span>계좌 정보</span>
                                <div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">은행 이름*</span>
                                    </div>
                                    <div class="col-xs-12 p-0">
                                        <asp:DropDownList runat="server" ID="ddlBank" CssClass="no-br form-control" style="width: 97%;" DataTextField="BankName" DataValueField="BankDetails"></asp:DropDownList>
                                        <br>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">계좌 번호*</span>
                                    </div>
                                    <div class="col-xs-10 p-0">
                                        <asp:TextBox runat="server" ID="txtBankAccount" CssClass="no-br form-control" MaxLength="16" onkeypress='return event.charCode >= 48 && event.charCode <= 57' onfocus="this.value=''" onblur="fast_checking('the_bano', 'txtBankAccount', '')" data-required="true"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2 p-0">
                                        <div id="ceklis9" class="alert-btn"></div>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <span style="color: red; font-size: 10px">중요*<br>
                                        정확한 계좌정보를 입력해 주세요 , 입출금시 불이익을 받을수 있습니다 </span>
                                    <br>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">예금주*</span>
                                    </div>
                                    <div class="col-xs-10 p-0">
                                        <asp:TextBox runat="server" ID="txtBankName" CssClass="no-br form-control" onkeypress='return (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122) || event.charCode = 32' onfocus="this.value=''" onblur="fast_checking('the_baname', 'txtBankName', '')" data-required="true"></asp:TextBox>
                                        <br>
                                    </div>
                                    <div class="col-xs-2 p-0">
                                        <div id="ceklis8" class="alert-btn"></div>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">이메일*</span>
                                    </div>
                                    <div class="col-xs-10 p-0">
                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="no-br form-control" TextMode="Email" onfocus="this.value=''" onblur="fast_checking('the_email', 'txtEmail', '')" data-required="true" placeholder="이메일*"></asp:TextBox>
                                        <br>
                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Address is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-xs-2 p-0">
                                        <div id="ceklis6" class="alert-btn"></div>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">전화*</span>
                                    </div>
                                    <div class="col-xs-10 p-0">
                                        <asp:DropDownList runat="server" ID="ddlContactNo" CssClass="no-br form-control" style="width: 20%; float: left;">
                                        <asp:ListItem Value="82">+82</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtContactNo" CssClass="no-br form-control" style="float: left; width: 80%;" onkeypress='return event.charCode >= 48 && event.charCode <= 57' onfocus="this.value=''" onblur="fast_checking('the_phone', 'txtContactNo', '')" data-required="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Contact No. is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-xs-2 p-0">
                                        <div id="ceklis7" class="alert-btn"></div>
                                        <br>
                                    </div>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">추천인*</span>
                                    </div>
                                    <div class="col-xs-12 p-0" style="width: 97%;">
                                        <asp:TextBox runat="server" ID="txtAffCode" CssClass="no-br form-control" onfocus="this.value=''" placeholder=""></asp:TextBox><br>
                                    </div>
                                </div>

                                <!--<div class="col-xs-12 p-0">
                                    <div class="col-xs-12 p-0">
                                        <span class='lightbase-color' style="font-size: 10px">보안문자를 입력해 주세요*</span>
                                    </div>
                                    <div class="col-xs-12 p-0">
                                        <asp:TextBox runat="server" ID="txtCaptcha" MaxLength="5" CssClass="no-br form-control" onfocus="this.value=''" onkeyup="this.value=this.value.replace(/[^0-9]/g,'');" onblur="this.value=this.value.replace(/[^0-9]/g,'');" onkeypress="this.value=this.value.replace(/[^0-9]/g,'');" data-required="true" placeholder="보안문자를 입력해 주세요*" style="width: 57%; float: left;"></asp:TextBox>
                                        <img src='../kr/captcha/captcha.php?.png?a=1' alt='CAPTCHA' height="34" style="width: 39%;">
                                        <br>
                                    </div>
                                </div>-->
                                <div class="col-xs-12 p-0">
                                    <a href="javascript:void(0)" class="cpg_2 white" align='left'>
                                        <img src="../resources/images/left-arrow.png">&nbsp;&nbsp;&nbsp;<span>뒤</span></a>
                                    <br>
                                    <br>
                                </div>

                                <div class="col-xs-12 p-0">
                                    <center>
                                        <div class="col-md-12">
                                            <div class="round" style="height: 20px; width: 9%; position: relative; display: inline-block; border-radius: 27px;">
                                                <input type="checkbox" id="checkbox" />
                                                <label for="checkbox" id='testsaa'></label>
                                            </div>
                                            <span
                                                class="form-text"
                                                style="font-style: italic; font-size: 12px; display: inline-block; vertical-align: top;"><a href="https://lobby6.lobbyplay.com/misc/help.php#terms" target="_blank">이용약관 동의</a> 
                                            </span>
                                        </div>
                                        <button runat="server" id="btnSubmit" class="nbtn nbtn-login" style="width: 43%; padding: 10px 0;" value="SUBMIT" onserverclick="btnSubmit_ServerClick">가입하기</button>
                                    </center>
                                </div>
                                <!--<input id="mobile" type="hidden" name="mobile" value="mobile"  />-->

                            </div>
                        </form>

                    </div>

                </div>
            </div>

            <script src="../resources/js/fast-checker-validation-native.js"></script>
            <script>
                $(document).ready(function () {
                    $(".cpg_1").click(function () {
                        $(".pg_1").hide();
                        $(".pg_2").fadeIn();
                    });
                    $(".cpg_2").click(function () {
                        $(".pg_2").hide();
                        $(".pg_1").fadeIn();
                    });
                    $("#the_phone").on("input", function () {
                        if (/^0/.test(this.value)) {
                            this.value = this.value.replace(/^0/, "")
                        }
                    })
                });

                $(document).ready(function () {
                    validate();
                    $('#user_name, #the_cap, #checkbox').change(validate);
                });
                $('#checkbox:checkbox').change(
                    function () {
                        $("#checkbox").prop("checked", true);
                    }
                );
                function validate() {
                    if ($('#user_name').val().length > 0 &&
                        $('#checkbox').not(':checked') &&
                        $('#the_cap').val().length > 0) {
                        $("#submit_button").prop("disabled", false);
                    }
                    else {
                        $("#submit_button").prop("disabled", true);
                    }
                }

                $(document).ready(function () {
                    //the min chars for username  
                    var min_chars = 3;

                    //result texts  
                    var characters_error = '<font color=red>Minimal 3 huruf</font>';
                    var checking_html = 'Checking...';

                    //when button is clicked  
                    $('#check_username_availability').click(function () {
                        //run the character number check  
                        if ($('#user_name').val().length < min_chars) {
                            //if it's bellow the minimum show characters_error text '  
                            $('#username_availability_result').html(characters_error);
                        } else {
                            //else show the cheking_text and run the function to check  
                            $('#username_availability_result').html(checking_html);
                            check_availability(1);
                        }
                    });
                    $('#check_nickname_availability').click(function () {
                        //run the character number check  
                        if ($('#user_nameid').val().length < min_chars) {
                            //if it's bellow the minimum show characters_error text '  
                            $('#nickname_availability_result').html(characters_error);
                        } else {
                            //else show the cheking_text and run the function to check  
                            $('#unickname_availability_result').html(checking_html);
                            check_availability(2);
                        }
                    });

                });

                //function to check username availability  
                function check_availability(pattern) {
                    //get the username  
                    if (pattern == 1) {
                        var username = $('#user_name').val();

                        //use ajax to run the check  
                        $.post("check_username.php?pattern=" + pattern, { username: username },
                            function (result) {
                                //if the result is 1 
                                if (result == 0) {
                                    //show that the username is available  
                                    $('#username_availability_result').html(username + ' is Available');
                                } else {
                                    //show that the username is NOT available  
                                    $('#username_availability_result').html(username + ' is not Available');
                                }
                            }
                        );
                    }
                    else {
                        var username = $('#user_nameid').val();
                        //use ajax to run the check  
                        $.post("check_username.php?pattern=" + pattern, { username: username },
                            function (result) {
                                //if the result is 1 
                                if (result == 0) {
                                    //show that the username is available  
                                    $('#nickname_availability_result').html(username + ' is Available');
                                } else {
                                    //show that the username is NOT available  
                                    $('#nickname_availability_result').html('<font color=red>' + username + ' is not Available</font>');
                                }
                            }
                        );
                    }
                }

                //setup before functions
                $(document).ready(function () {
                    $("input[type='text']").on("click", function () {
                        $(this).select();
                    });
                    // var typingTimer;                //timer identifier
                    // var doneTypingInterval = 500;  //time in ms, 0.5 second for example
                    // var $input = $('#the_pass');

                    // // on keyup, start the countdown
                    // $input.on('keyup', function () {
                    //   clearTimeout(typingTimer);
                    //   typingTimer = setTimeout(doneTyping, doneTypingInterval);
                    // });

                    // // on keydown, clear the countdown 
                    // $input.on('keydown', function () {
                    //   clearTimeout(typingTimer);
                    // });

                    // //user is "finished typing," do something
                    // function doneTyping () {
                    //  fast_checking('the_pass', 'ceklis3', 'user_name');
                    // }
                });

                function fast_checking(id_div, id_div2, id_div3) {
                    //use ajax to run the check
                    var id_val = $('#' + id_div).val();

                    if (id_div3 != "") {
                        var id_val2 = $('#' + id_div3).val();
                    }
                    else {
                        var id_val2 = "";
                    }

                    if (id_div.length > 0) addValidation(id_div, id_val); // add validation

                    $('#' + id_div2).html("<img src='../resources/images/loader.gif' width='30' title='checking...' />");
                    //alert(id_val2);
                    $.post("../fast_checking.aspx/RegisterValidation", { column: id_div, value1: id_val, value2: id_val2 },
                        function (result) {
                            var inresult = JSON.parse(result);

                            if (inresult[0] == "0") {
                                if (id_div.length > 0) checkValidation(id_div, id_val, false); // check the validation

                                if (id_div == "the_pass" || id_div == "the_cpass") {
                                    $('#' + id_div).get(0).type = 'text';
                                    $('#' + id_div).keyup(function () {
                                        $('#' + id_div).get(0).type = 'password';
                                    });
                                }

                                $('#' + id_div).keyup(function () {
                                    $('#' + id_div).css({ "color": "black" });
                                });

                                //show that the username is available  
                                $('#' + id_div).css({ "color": "#DD5B5B" });
                                $('#' + id_div2).css({ "background": "#DD5B5B" });
                                $('#' + id_div2).html("<img src='../resources/images/close.svg' width='25' title='" + inresult[1] + "' />");
                                $('#' + id_div).val(inresult[1]);
                            } else {
                                if (id_div.length > 0) checkValidation(id_div, id_val, true); // check the validation

                                //show that the username is NOT available  
                                $('#' + id_div).css({ "color": "#777777" });
                                $('#' + id_div2).css({ "background": "#83CC7A" });
                                $('#' + id_div2).html("<img src='../resources/images/check.svg' width='25' style='margin-top: 4px;' title='" + inresult[1] + "' />");

                                if (id_div == "the_pass") {
                                    $('.check').show();
                                    $('.check').parent().removeClass('err-pass');
                                    $('.cross').hide();
                                }
                            }
                        }
                    );
                }

            </script>
            <div class="content footer-box">
                <center class="mtb-15">
                    <div>
                        <div class="col-xs-12">
                            How To Play
                        </div>
                        <div class="col-xs-12">
                            <a href="https://lobby6.lobbyplay.com/misc/tutorial_kr.php?lang=kr#poker" target="_blank"><span class="white">Texas Hold'em Poker</span></a> | 
            <a href="https://lobby6.lobbyplay.com/misc/tutorial_kr.php?lang=kr#PokerOmaha" target="_blank"><span class="white">Pot Limit Omaha</span></a> | 
            <a href="https://lobby6.lobbyplay.com/misc/tutorial_kr.php?lang=kr#superten" target="_blank"><span class="white">Super10</span></a> | 
            <a href="https://lobby6.lobbyplay.com/misc/tutorial_kr.php?lang=kr#trnrules" target="_blank"><span class="white">Poker Tournament<span></a>
                        </div>
                    </div>
                    <br>
                    <div>
                        <div class="col-xs-12">
                            Legal
                        </div>
                        <div class="col-xs-12">
                            <a href="https://lobby6.lobbyplay.com/misc/help.php#privacypolicy" target="_blank"><span class="white">Privacy Policy</span></a> | 
            <a href="https://lobby6.lobbyplay.com/misc/help.php#disclaimer" target="_blank"><span class="white">Disclaimer</span></a> | 
            <a href="https://lobby6.lobbyplay.com/misc/terms.php?lang=kr" target="_blank"><span class="white">Terms & Conditions</span></a>
                        </div>
                    </div>
                    <br>
                    <div>
                        <div class="col-xs-12">
                            Safety & Security
                        </div>
                        <div class="col-xs-12">
                            <a href="http://idnplay.com/certificate/BMM_EN.html" target="_blank"><span class="white">Random Number Generator</span></a> | 
            <a href="https://lobby6.lobbyplay.com/misc/help.php#security" target="_blank"><span class="white">Security</span></a>
                        </div>
                    </div>
                </center>
                <div>
                    <div class="wrapper" style="background: #051629;">
                        <div class="col-xs-12 p-0">
                            <div class="col-xs-5">
                                <img src="../resources/images/logo-bw.png" style="width: 100%; text-align: left; padding-top: 4px;">
                            </div>
                            <div class="col-xs-7">
                                <img src="../resources/images/icons.png" style="width: 100%; text-align: right">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <script>
                function needtologin() {
                    alert("어플리케이션 다운로드는 로그인 후 가능합니다.");
                }
            </script>
</body>
</html>
