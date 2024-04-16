<%@ Page Language="VB" AutoEventWireup="false" CodeFile="home.aspx.vb" Inherits="homeMobile" %>

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
        <link rel="apple-touch-startup-image" href="img/splash/splash-screen.png" media="screen and (max-device-width: 320px)" />
        <link rel="apple-touch-startup-image" href="img/splash/splash-screen_2x.png" media="(max-device-width: 480px) and (-webkit-min-device-pixel-ratio: 2)" />
        <link rel="apple-touch-startup-image" sizes="640x1096" href="img/splash/splash-screen_3x.png" />
        <link rel="apple-touch-startup-image" sizes="1024x748" href="img/splash/splash-screen-ipad-landscape.png" media="screen and (min-device-width : 481px) and (max-device-width : 1024px) and (orientation : landscape)" />
        <link rel="apple-touch-startup-image" sizes="768x1004" href="img/splash/splash-screen-ipad-portrait.png" media="screen and (min-device-width : 481px) and (max-device-width : 1024px) and (orientation : portrait)" />
        <link rel="apple-touch-startup-image" sizes="1536x2008" href="img/splash/splash-screen-ipad-portrait-retina.png" media="(device-width: 768px) and (orientation: portrait) and (-webkit-device-pixel-ratio: 2)" />
        <link rel="apple-touch-startup-image" sizes="1496x2048" href="img/splash/splash-screen-ipad-landscape-retina.png" media="(device-width: 768px) and (orientation: landscape)	and (-webkit-device-pixel-ratio: 2)" />

        <link rel="shortcut icon" href="../resources/images/favicon-32x32.png" />

        <link rel="stylesheet" href="../resources/css/fontawesome-free-5.15.4-web.css" crossorigin="anonymous" />
        <script defer src="../resources/js/fontawesome-free-5.15.4-web.js"></script>
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
        <script type="text/javascript" src="../resources/js/snap.js?v=1639871280"></script>
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

                $(".forlogin").click(function () {
                    $('.clicklog').click();
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

                $("#flagSwitcher").click(function () {
                    $(".dropdown img.flag").toggleClass("flagvisibility");
                });

                $('.deploy-sidebar').click(function () {
                    $('.page-sidebar').toggle({ direction: "left" }, 500);
                    $(".page-content").toggleClass("opa02");
                });

                $('.shortcut-close').click(function () {
                    $('.page-sidebar').toggle({ direction: "left" }, 500);
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
                                <button class="nbtn nbtn-register" onclick='window.location.href = "/m/registration.aspx?aff=<%= Request.QueryString("aff")%>";'>가입하기</button>
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
                                <a class="new_register base-color" href="/m/registration.aspx?aff=<%= Request.QueryString("aff")%>">가입하기</a>

                            </form>
                        </div>
                    </div>
                </div>

                <div class="page-header-clear"></div>

                <div id="newsModal" class="modal">
                    <div style="padding: 0 7%; margin-top: 20%;">
                        <img src="../resources/images/popupbanner.png" style="width: 100%;">
                        <a href="/registration.aspx?aff=<%= Request.QueryString("aff")%>" style="width: 100%; text-align:-webkit-center; padding: 10px 20px;color: white;margin-top: 17px;display: inline-block;"><!-- 프로모션 확인 -->
                    <img src="../resources/images/sssbutton.png">
                </a>
                    </div>
                </div>

                <div class="content">
                    <div class="main2 no-bottom">

                        <div class="slider-container">
                            <div class="homepage-slider" data-snap-ignore="true">
                                <div>
                                    <img src="https://www.kaypoker.com/wp-content/uploads/2023/09/first.png" class="responsive-image">
                                </div>
                                <div>
                                    <img src="https://www.kaypoker.com/wp-content/uploads/2023/09/main12.png" class="responsive-image">
                                </div>
                                <div>
                                    <img src="https://www.kaypoker.com/wp-content/uploads/2024/01/dailybonus2.png" class="responsive-image">
                                </div>
                                <div><img src="../resources/images/slider-1.png?v=754166678" class="responsive-image" /> </div>
                                <div><img src="../resources/images/slider-2.png?v=754166678" class="responsive-image" /> </div>
                                <div><img src="../resources/images/slider-3.png?v=754166678" class="responsive-image" /> </div>
                                <div><img src="../resources/images/slider-4.png?v=754166678" class="responsive-image" /> </div>
                                <div><img src="../resources/images/slider-5.png?v=754166678" class="responsive-image" /> </div>
                                <div><img src="../resources/images/slider-6.png?v=754166678" class="responsive-image" /> </div>
                                <div><img src="../resources/images/slider-7.png?v=754166678" class="responsive-image" /> </div>
                            </div>
                            <div class="homepage-slider-controls">
                                <div class="the_right">
                                    <a href="#" class="prev-home"></a>
                                </div>
                                <div class="the_left">
                                    <a href="#" class="next-home"></a>
                                </div>
                            </div>
                        </div>


                        <br>
                        <div class="container">
                            <div class="col-xs-12 p-0">
                                <div class="col-xs-6 pl-0" style="padding-right: 5px;">
                                    <button class="nbtn nbtn-register" onclick='window.location.href = "/m/registration.aspx?aff=<%= Request.QueryString("aff")%>";'>가입하기</button>
                                </div>
                                <div class="col-xs-6 pr-0" style="padding-left: 5px;">
                                    <button class="forlogin nbtn nbtn-login">로그인</button>
                                </div>
                            </div>
                        </div>
                        <div class="container">
                            <div class="col-xs-12 p-0">
                                <div class="font-paladins white">
                                    <div class="col-xs-6 p-0">
                                        <span class="jackpot-text">진행중인 잭팟</span>
                                    </div>
                                    <div class="col-xs-6 p-0">
                                        <span class="jackpot-global">837,456,620</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="container">
                            <div class="col-xs-12 p-0">
                                <div class="col-xs-4 p-0 imgdownload">
                                    <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">
                                        <div class="col-xs-3 p-0">
                                            <img src="../resources/images/apple1.svg">
                                        </div>
                                        <div class="col-xs-9 p-0">
                                            <p class="white" style="font-size: 9px;">iOS 다운로드</p>
                                            <p>클릭하여 다운로드!</p>
                                        </div>
                                    </a>
                                </div>
                                <div class="col-xs-4 p-0 imgdownload">
                                    <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">
                                        <div class="col-xs-3 p-0">
                                            <img src="../resources/images/android1.svg">
                                        </div>
                                        <div class="col-xs-9 p-0">
                                            <p class="white lh-1">안드로이드 다운로드</p>
                                            <p style="color: #1DC1A6;">클릭하여 다운로드!</p>
                                        </div>
                                    </a>
                                </div>
                                <div class="col-xs-4 p-0 imgdownload">
                                    <a href="/m/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                        <div class="col-xs-3 p-0" style="margin-left: 10px;">
                                            <img src="../resources/images/windows.svg">
                                        </div>
                                        <div class="col-xs-9 p-0" style="margin-left: -10px;">
                                            <p class="white" style="font-size: 9px; padding-left: 10px;">웹 플레이</p>
                                            <p style="color: #C3850F; padding-left: 10px;">플레이 하기!</p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12 p-0 ourgames_box">
                            <div class="row">
                                <center>
                                    <h5 class="white mtb-15">
                                        <u class="undermenu">이용가능 게임</u>
                                    </h5>
                                    <div class="col-xs-12 mtb-15">
                                        <div class="col-xs-3 p-0">
                                            <a href="/m/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                                <img src="/resources/images/poker.png" style="height: 40px;">
                                                <span class="white" style="font-size: .65em;">텍사스 홀덤</span>
                                            </a>
                                        </div>
                                        <div class="col-xs-3 p-0">
                                            <a href="/m/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                                <img src="/resources/images/omaha.png" style="height: 40px;">
                                                <span class="white" style="font-size: .65em;">오마하</span>
                                            </a>
                                        </div>
                                        <div class="col-xs-3 p-0">
                                            <a href="/m/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                                <img src="/resources/images/super10.png" style="height: 40px;">
                                                <span class="white" style="font-size: .65em;">슈퍼 10</span>
                                            </a>
                                        </div>
                                        <div class="col-xs-3 p-0">
                                            <a href="/m/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                                <img src="/resources/images/tournament.png" style="height: 40px;">
                                                <span class="white" style="font-size: .65em;">홀덤 토너먼트</span>
                                            </a>
                                        </div>
                                    </div>
                                </center>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <center>
                                <h3 class="white mtb-30">
                                    <u class="undermenu">공지사항</u>
                                </h3>
                                <div class="col-xs-12 news-box">
                                    <div class="col-xs-12 highl-news" align="left">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                            <div class="col-xs-12 p-0">
                                        <span>07/05</span>
                                        <span>※중요※ 최신 구글 크롬, 파이어폭스, 모바일 어플 관련</span>
                                    </div>
                                        </a>
                                    </div>
                                    <div class="col-xs-12 highl-news" align="left">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                            <div class="col-xs-12 p-0">
                                        <span>07/05</span>
                                        <span>※중요※ 계정 보안에 관한 안내</span>
                                    </div>
                                        </a>
                                    </div>
                                    <div class="col-xs-12 highl-news" align="left">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                            <div class="col-xs-12 p-0">
                                        <span>07/05</span>
                                        <span>※중요※ 매주 목요일 정기점검</span>
                                    </div>
                                        </a>
                                    </div>
                                    <div class="col-xs-12 highl-news" align="left">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                            <div class="col-xs-12 p-0">
                                        <span>07/05</span>
                                        <span>※중요※ 게임상의 오류 문의 방법</span>
                                    </div>
                                        </a>
                                    </div>
                                    <div class="col-xs-12 highl-news" align="left">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                            <div class="col-xs-12 p-0">
                                        <span>05/04</span>
                                        <span>※중요※ 회원간 칩 이동에 대한 규정</span>
                                    </div>
                                        </a>
                                    </div>
                                    <div class="col-xs-12 highl-news" align="left">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                            <div class="col-xs-12 p-0">
                                        <span>31/08</span>
                                        <span>※안내※ Direpay (암호화폐) 입금 런칭!!</span>
                                    </div>
                                        </a>
                                    </div>
                                    <div class="col-xs-12 highl-news" align="left">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                            <div class="col-xs-12 p-0">
                                        <span>21/10</span>
                                        <span>※중요※ 입금 및 출금 안내</span>
                                    </div>
                                        </a>
                                    </div>
                                    <div class="col-xs-12 highl-news" align="left">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                            <div class="col-xs-12 p-0">
                                        <span>29/12</span>
                                        <span>※안내※ 게임 내 칩 환산 안내 현재 11배 변경</span>
                                    </div>
                                        </a>
                                    </div>
                                </div>
                            </center>
                        </div>

                        <div class="col-xs-12 promotion-bbox">
                            <center>
                                <h3 class="white mtb-30">
                                    <u class="undermenu">프로모션</u>
                                </h3>
                                <div class="x-scroller">
                                    <div class="sekc">
                                        <img src="https://www.kaypoker.com/wp-content/uploads/2020/11/leikeubaek4.png" width="100%">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="haras" style="cursor: pointer;">
                                            <div class="promoname" align='left' style="padding: 25px 15px;">
                                                <h6 class="white titlenews">매주 무제한 레이크백 보너스! VIP 혜택 추가!</h6>
                                                <!-- <div class="contentnews" style="display: none;"><p>◆ 레이크백 보너스 시스템 대한 자세한사항은 아래와 같습니다 ◆</p><p>1. 일주일간 턴오버별 산정되는 레이크백 시스템</p><p>&nbsp;(1) 턴오버 범위 0원 부터 10,000,000원 : 5% 적용</p><p>&nbsp;(2) 턴오버 범위 10,000,001원 부터 100,000,000원 : 10% 적용</p><p>&nbsp;(3) 턴오버 범위 100,000,001원 부터 : 15% 적용</p><p>&nbsp;(4) 턴오버 범위 (VIP 해당) 250,000,000원 부터 : 18% 적용</p><p>2. 정산기간 및 지급 일</p><p>&nbsp;(1) 정산기간 (한국시간 기준) : 매주 화요일 12시 부터 다음주 화요일 12시까지</p><p>&nbsp;&nbsp;예) 한국시간 : 2021년 9월 28일 12시 부터 2021년 10월 5일 12시 까지</p><p>&nbsp; &nbsp; &nbsp; &nbsp;시스템 시간 : 2021년 9월 28일 10시 부터 2021년 10월 5일 10시 까지</p><p>&nbsp;(2) 지급일 : 매주 수요일 ( 오후 3시부터 순차적으로 지급시작 / 당일 상황에 따라 1시간 ~ 2시간 소요 )</p><p>3. 지급 한도</p><p>&nbsp;(1) 최소 지급액 : 1만원</p><p>&nbsp;(2) 최대 지급액 : 무제한</p><p>4. 레이크백 요율은 회원마다 다를 수 있으니 본인 요율에 대해서는 라이브챗으로 직접 문의 하시기 바랍니다.</p><p>5. CS 상담원은 지급일 당일 이외의 날에는 레이크백 예상 지급액을 알 수 없습니다.</p><p>6. 레이크백 지급액은 아래와 같이 직접 확인 가능하니 참고하여 주시기 바랍니다.</p><p>&nbsp;(1) 아래 링크에서 파일을 다운로드 받아 사용하여도 됩니다.</p><p>&nbsp;&nbsp;(<a href="https://drive.google.com/file/d/1Cikggqgb-6FYVLfQujM5bhnbEDF805v7/view?usp=sharing">2021년 하반기용 파일 다운로드</a>)</p><p>&nbsp;(2) 게임로비의 입출금내역을 클릭 합니다.</p><p>&nbsp;(3) 입출금 내역에서 수익에 해당하는 금액을 클릭 합니다.</p><p>&nbsp;(4) 화면의 아래에 배팅내역이 확인 가능하며 "Bet"은 칩으로 해당게임에 배팅된 금액이고&nbsp;"통화 Amount"가 그 칩을 원화로 환산한 금액 입니다.</p><p>&nbsp;7. 레이크백 보너스는 1배 롤링 후 출금 가능합니다.</p><p>◆ 상기 이벤트는 12월 1일 이후로 발효 되며 상기 명시된 기간과 일정이 통보없이 변경 및 취소 될 수 있습니다. ◆</p></div> -->
                                                <span class="promoreadmore">확인하기</span>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="sekc">
                                        <img src="https://www.kaypoker.com/wp-content/uploads/2020/11/sinkyu3.png" width="100%">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="haras" style="cursor: pointer;">
                                            <div class="promoname" align='left' style="padding: 25px 15px;">
                                                <h6 class="white titlenews">12월의 신규 회원 첫 입금 보너스 50% 및 토너먼트 참가권!</h6>
                                                <!-- <div class="contentnews" style="display: none;"><p>◆ 12월 신규 회원 첫 입금 보너스 및 토너먼트 참가권 지급에 대한 자세한사항은 아래와 같습니다 ◆</p><p>1. 신규 첫 입금에 대하여 5% 혹은 10% 보너스 머니 선택이 가능합니다.</p><p>2. 최대 발급액은 5% 선택시 5만원이고 10% 선택시 10만원이며, 최소 1만원이상 입급 하신 회원 분들께 제공 됩니다 .</p><p>3. 지급받으신 금액은 5% 선택시 100% 롤링이고 10% 선택시 300% 롤링 완료 후 출금 가능 합니다 .&nbsp;&nbsp;</p><p>&nbsp; ▶ ex) 5% 선택시! 입금금액 100만원 + 추가보너스머니 5만원 총 105만원에 대한 100%인 105만원을 롤링 진행해주셔야 출금가능합니다.</p><p>&nbsp; &nbsp; &nbsp;10% 선택시! 입금금액 100만원 + 추가보너스머니 10만원 총 110만원에 대한 300%인 330만원을 롤링 진행해 주셔야 출금 가능합니다.</p><p>4. 토너먼트 참가권은 11월 22일부터 12월 21일까지 신규가입 후 10만원 이상 입금시 12월 27일에 진행하는 아듀 2021년 토너먼트 참가권이 지급 됩니다.</p><p>&nbsp; &nbsp;(토너먼트는 SSS POKER에서 직접 등록처리하고 회원에게 개별 안내 됩니다. 12월 21일 이후 신규는 2022년 1월 토너먼트 참가권 주어 집니다.)</p><p>5. 신규보너스는 가입 후 1회로 제한 됩니다 .&nbsp;</p><p>6. 이중 아이디는 보너스 발급이 제한됩니다 .&nbsp;</p><p>7. 신규보너스, 데일리 보너스 및 코인입금 50%보너스 는 중복 지급 되지 않습니다.</p><p>8. 보너스 지급 후 2주 이상 베팅이 진행 되지 않을 시 보너스는 몰수 처리 됩니다.</p><p>9. 해당이벤트는 라이브채팅 및 고객센터에 문의하여 선택하여 주셔야 정상 지급 처리 됩니다.</p><p>◆ 상기 이벤트는 12월 1일 이후로 발효 되며 사정에 의해 별도의 고지 없이 변경 또는 종료될 수 있습니다 . ◆</p></div> -->
                                                <span class="promoreadmore">확인하기</span>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="sekc">
                                        <img src="https://www.kaypoker.com/wp-content/uploads/2023/03/daily_promo.png" width="100%">
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="haras" style="cursor: pointer;">
                                            <div class="promoname" align='left' style="padding: 25px 15px;">
                                                <h6 class="white titlenews">12월의 매일 매일 데일리 보너스! 최대 10%!!</h6>
                                                <!-- <div class="contentnews" style="display: none;"><p>◆ 12월 매일 매일 데일리 보너스 지급에 대한 자세한사항은 아래와 같습니다 ◆</p><p><strong>1.1 전 회원 메인아이디에 동일하게 하루 한번 입금액의 3% 데일리 보너스가 지급 가능합니다.</strong></p><p><strong>1.2 전일 300만원 이상 입금 회원의 메인아이디에 당일 5% 데일리 보너스가 지급 가능합니다.</strong></p><p><strong>1.3 한국시간 오전 6시부터 오전 9시까지 입금시 모든 회원의 메인아이디에 당일 5% 데일리 보너스가 지급 가능합니다.</strong></p><p><strong>1.4 당일 데일리 보너스 지급 받은 후 당일 입금금액의 50% 이상 출금 시 당일 재입금에 대하여 데일리 보너스 1번 더 지급 가능합니다.</strong></p><p>2.1 3% 데일리 보너스의 최대 지급액은 VIP 6만원, 일반회원 3만원 입니다.</p><p>2.2 5% 데일리 보너스의 최대 지급액은 VIP 10만원, 일반회원 5만원 입니다.</p><p>3. VIP 등급 조건은 11월 턴오버 1억원 이상 회원이며 12월 1일 개별 안내되어 집니다.</p><p>&nbsp;(등급 문의는 라이브챗으로 문의 드립니다.)</p><p>4. 데일리 보너스는 신규가입 보너스와 중복으로 지급 되지 않습니다.</p><p>5. 턴오버는(롤링) 300% 완료 후 출금 가능 합니다 .&nbsp;&nbsp;</p><p>&nbsp; ▶ ex1) 입금금액 100만원 + 추가보너스머니 3만원 총 103만원에 대한 300% 롤링 (309만원)을 진행해주셔야 출금가능합니다.</p><p>&nbsp; (데일리 보너스를 받지 않을 경우에는 100%만 적용 되오니 참고 부탁 드립니다)</p><p>&nbsp; ▶ ex2) 회원이 재입금 시 잔액이 남아 있는 경우</p><p>&nbsp; &nbsp; &nbsp; &nbsp;- 이전 입금인 데일리 받은 입금 건에 대한 턴오버 : 입금 100만원 + 데일리 3만 인경우 309만원</p><p>&nbsp; &nbsp; &nbsp; &nbsp; 재 입금시에 충족한 턴오버 250만원</p><p>&nbsp; &nbsp; &nbsp; &nbsp; 재 입금 액 : 100 만원 (데일리 안 받을 경우)</p><p>&nbsp; &nbsp; &nbsp; &nbsp; =&gt; 출금 가능한 턴오버 : 이전 충족하여야 할 턴오버 309만원 - 충족한 턴오버 250만원 + 재 입금 액 100만원 = 159만원</p><p>&nbsp; &nbsp; &nbsp; &nbsp;(재 입금 시 잔액이 1만원 이하인 경우는 0원으로 간주하여 초기화 된 상태로 재 입금액에 대한 턴오버만 충족하면 됨)</p><p>6. 데일리보너스는 1일 1회로 제한 됩니다 .</p><p>7. 메인 아이디에만 보너스가 지급 됩니다.</p><p>8. 보너스 지급 후 2주 이상 베팅이 진행 되지 않을 시 보너스는 몰수 처리 됩니다.</p><p>9. 해당이벤트는 라이브채팅 및 고객센터에 요청 하셔야 정상 지급 처리 되며 10분 경과 후 해당 입금건에 대한 보너스 지급이 불가능합니다.</p><p>◆ 상기 이벤트는 12월 1일 이후로 발효 되며 사정에 의해 별도의 고지 없이 변경 또는 종료될 수 있습니다 . ◆</p></div> -->
                                                <span class="promoreadmore">확인하기</span>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-xs-12 mtb-15 seeall">
                                    <br>
                                    <center>
                                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="downloadbtn white" style="width: 70%;">모든 프로모션 확인
                                            <img src="../resources/images/right-arrow.png"></a>
                                    </center>
                                </div>
                            </center>
                        </div>

                    </div>
                </div>


                <script type="text/javascript">
                    /*$( document ).ready(function() {
                        $( ".haras" ).click(function() {
                            var gettile = $( this ).find( '.titlenews' ).text();
                            var getcontent = $( this ).find( '.contentnews' ).text();
                            $("#newsModal").fadeIn();
                            $(".fortitle").html(gettile);
                            $(".forcontent").html(getcontent);
                            $('#newsModal').click(function() {
                                $(this).fadeOut();
                            });
                        });
                    });*/
                    $(document).ready(function () {
                        $("#newsModal").fadeIn();
                        $('#newsModal').click(function () {
                            $(this).fadeOut();
                        });
                    });
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
