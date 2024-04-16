<%@ Page Language="VB" AutoEventWireup="false" CodeFile="home.aspx.vb" Inherits="home" %>

<style type="text/css">
    body {
        font-family: 'Malgun Gothic' !important;
    }
</style>
<style type="text/css">
    body {
        font-family: 'Malgun Gothic' !important;
    }
</style>
<!DOCTYPE html>
<!--[if lt IE 7]>
<html class="no-js lt-ie9 lt-ie8 lt-ie7">
<![endif]-->
<!--[if IE 7]>
<html class="no-js lt-ie9 lt-ie8">
<![endif]-->
<!--[if IE 8]>
<html class="no-js lt-ie9">
<![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js" lang="en">
<!--<![endif]-->
<head>
    <!--[if lt IE 11]>
    		<script>
    			ie = 10;
			</script>
		<![endif]-->

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>SSS POKER</title>
    <script>
        var j_register = "";
        var j_deposit = "";
        var j_withdraw = "";
    </script>
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
    <meta name="viewport" content="width=device-width,initial-scale=1">

    <!-- Favicon -->
    <link rel="apple-touch-icon" sizes="57x57" href="../assets/img/favicon/apple-icon-57x57.png">
    <link rel="apple-touch-icon" sizes="60x60" href="../assets/img/favicon/apple-icon-60x60.png">
    <link rel="apple-touch-icon" sizes="72x72" href="../assets/img/favicon/apple-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/favicon/apple-icon-76x76.png">
    <link rel="apple-touch-icon" sizes="114x114" href="../assets/img/favicon/apple-icon-114x114.png">
    <link rel="apple-touch-icon" sizes="120x120" href="../assets/img/favicon/apple-icon-120x120.png">
    <link rel="apple-touch-icon" sizes="144x144" href="../assets/img/favicon/apple-icon-144x144.png">
    <link rel="apple-touch-icon" sizes="152x152" href="../assets/img/favicon/apple-icon-152x152.png">
    <link rel="apple-touch-icon" sizes="180x180" href="../assets/img/favicon/apple-icon-180x180.png">
    <link rel="icon" type="image/png" sizes="192x192" href="/resources/images/android-icon-192x192.png">
    <link rel="icon" type="image/png" sizes="32x32" href="/resources/images/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="96x96" href="../assets/img/favicon/favicon-96x96.png">
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/img/favicon/favicon-16x16.png">
    <link rel="manifest" href="../assets/img/favicon/manifest.json">
    <meta name="msapplication-TileColor" content="#ffffff">
    <meta name="msapplication-TileImage" content="../assets/img/favicon/ms-icon-144x144.png">
    <meta name="theme-color" content="#ffffff">

    <!-- Stylesheet -->

    <!-- Bootstrap -->
    <link href="/resources/css/bootstrap.min.css" rel="stylesheet">
    <link href="/resources/js/bootstrap.min.js" rel="stylesheet">

    <!-- <link rel="stylesheet" href="assets/css/normalize.css"> -->
    <link rel="stylesheet" href="/resources/css/main.css">
    <!-- <link rel="stylesheet" href="assets/css/SBOK.css"> -->

    <!-- tabs css -->
    <link rel="stylesheet" href="/resources/css/tabs.css" />

    <!-- Jquery -->
    <!--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="assets/js/jquery-1.10.2.min.js"><\/script>')</script>-->


    <!-- ############################################################################################################# -->
    <!-- <script src="assets/js/jquery-form.js"></script> -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="/resources/js/jquery.show-more.js"></script>

    <!-- <script src="assets/js/jquery.form.2.93.js"></script> -->

    <script src="/resources/js/jquery-ui-1.8.16.custom.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha256-eZrrJcwDc/3uDhsdt61sL2oOBY362qM3lon1gyExkL0=" crossorigin="anonymous" />
    <!--JQUERYUI-->
    <!-- <link rel="stylesheet" href="assets/js/jquery-ui-1.8.16.custom/css/smoothness/jquery-ui-1.8.16.custom.css" />
		<script src="assets/js/jquery-ui-1.8.16.custom/js/jquery-ui-1.8.16.custom.min.js"></script> -->

    <!-- Modernizr -->
    <!-- <script src="assets/js/modernizr-2.6.2.min.js"></script> -->

    <!-- Superfish -->
    <!--  <link rel="stylesheet" href="assets/js/superfish/superfish.css" />
        <link rel="stylesheet" href="assets/js/superfish/superfish-navbar.css" />
        <script src="assets/js/superfish/superfish.js"></script> -->

    <!-- Liscroller -->
    <!--  <link rel="stylesheet" href="assets/js/liScroller/li-scroller.css" />
        <script src="assets/js/liScroller/jquery.li-scroller.1.0.js"></script> -->

    <!-- Plugins -->
    <!-- <script src="assets/js/plugins.js"></script>
        <script src="assets/js/jquery_cycle_all_pack.js"></script>
 -->
    <!--NYROMODAL-->
    <link rel="stylesheet" type="text/css" href="/resources/css/nyroModal.full.css" />
    <script language="JavaScript" type="text/javascript" src="/resources/js/jquery.nyroModal-1.6.2.pack.js"></script>

    <!--NIVO SLIDER-->
    <!-- <link rel="stylesheet" href="assets/js/nivoSlider/nivo-slider.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="assets/js/nivoSlider/themes/default/default.css" type="text/css" media="screen" />
		<script src="assets/js/nivoSlider/jquery.nivo.slider.pack.js"></script>
 -->
    <!--QUICKACCESS-->
    <!-- <link rel="stylesheet" type="text/css" href="assets/js/quickAccess/quickAccess.css" />
		<script language="JavaScript" type="text/javascript" src="assets/js/quickAccess/quickAccess.min.js"></script> -->

    <script language="JavaScript" type="text/javascript">
        $(document).ready(function () {
            $(".flag-img").mouseover(function () {
                $(this).attr("src", $(this).attr("src").replace(".svg", "-colored.svg"));
            }).mouseout(function () {
                $(this).attr("src", $(this).attr("src").replace("-colored.svg", ".svg"));
            });
        });
        /*jQuery(document).ready(function(){
            jQuery("body").append("<div id='uialert' class='uialert'></div>");
            jQuery(".popup").nyroModal({
                bgColor: "#000000",
                modal: false
            });
            jQuery('.popup_ads').nyroModal();
            jQuery("#popup_ads").click();

            //jQuery('#slider').nivoSlider();
         //    setTimeout(function(){
            // 	jQuery("#slider").nivoSlider({
            // 		effect: "random",
            // 		pauseTime: 5000,
            // 		controlNav: true,
            // 		captionOpacity: 1,
         //            directionNav:true,
            // 		directionNavHide: false
            // 	});
            // }, 2000);

            jQuery('.tabs .tab-links a').on('click', function(e)  {
                var currentAttrValue = jQuery(this).attr('href');

                // Show/Hide Tabs

                //Default Animation
                //jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

                //Fade Animation
                //jQuery('.tabs ' + currentAttrValue).fadeIn(400).siblings().hide();

                //Slide1 Animation
                //jQuery('.tabs ' + currentAttrValue).siblings().slideUp(400);
                //jQuery('.tabs ' + currentAttrValue).delay(400).slideDown(400);

                //Slide2 Animation
                jQuery('.tabs ' + currentAttrValue).slideDown(400).siblings().slideUp(400);

                // Change/remove current tab to active
                jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

                e.preventDefault();
            });
        });*/

        jQuery(document).ready(function () {
            $("#myModal").modal('show');
            jQuery("body").append("<div id='uialert' class='uialert'></div>");
            jQuery(".popup").nyroModal({
                bgColor: "#000000",
                modal: false
            });
            jQuery('.popup_ads').nyroModal();
            jQuery("#popup_ads").click();

            jQuery('.tabs .tab-links a').on('click', function (e) {
                var currentAttrValue = jQuery(this).attr('href');

                // Show/Hide Tabs

                //Default Animation
                //jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

                //Fade Animation
                //jQuery('.tabs ' + currentAttrValue).fadeIn(400).siblings().hide();

                //Slide1 Animation
                //jQuery('.tabs ' + currentAttrValue).siblings().slideUp(400);
                //jQuery('.tabs ' + currentAttrValue).delay(400).slideDown(400);

                //Slide2 Animation
                jQuery('.tabs ' + currentAttrValue).slideDown(400).siblings().slideUp(400);

                // Change/remove current tab to active
                jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

                e.preventDefault();
            });
        });

        /*CUSTOM POPUP*/
        uialert = function (msg, onclose) {
            jQuery("#uialert").html(msg).css({
                "left": "50%",
                "top": "40%",
                "z-index": "10000",
                "marginLeft": "-" + Math.floor((jQuery("#uialert").width() / 2) + 20) + "px",
                "marginTop": "-" + Math.floor(jQuery("#uialert").height() / 2) + "px"
            }).fadeIn();
            setTimeout(
                function () {
                    jQuery('#uialert').fadeOut();
                    if (onclose != null) { onclose(); }
                }, 3000
            );
        }

        /*TABLE FIX*/
        fixtable = function (table, cellpadding) {
            var bgcolor = "#f5f5f5";
            var cellpad = cellpadding || 7;
            jQuery(table).attr({
                "cellpadding": cellpad,
                "cellspacing": "0",
                "border": "0",
                "bgcolor": "#cacaca"
            });
            jQuery(table + " thead tr:first").addClass("ui-widget-header");
            jQuery(table + " tfoot tr:first").addClass("ui-widget-header");
            jQuery(table + " tbody tr:even").css({
                "background-color": bgcolor
            });
            jQuery(table + " tbody tr:odd").css({
                "background-color": "#ffffff"
            });
        }

        /*AJAX URL & FORM*/
        setform = function (form, target, loader, fn) {
            jQuery("#" + form).ajaxForm({
                target: "#" + target,
                beforeSubmit: function () {
                    jQuery("#" + target).html("");
                    jQuery("#" + loader).html(loader_img);
                },
                success: function (r) {
                    jQuery("#" + loader).html("");
                    init();
                    if (fn != null) { fn(r); }
                }
            });
        }
        request = function (url, obj, loader, fn) {
            if (!loader) { loader = obj; }
            if (!obj) { obj = "contentbox"; }
            jQuery("#" + loader).html(loader_img);
            jQuery.get(url, function (res) {
                jQuery("#" + loader).html("");
                jQuery("#" + obj).html(res);
                init();
                if (fn != null) { fn(); }
            });
        }

        /*LIMIT CHARS*/
        limitchars = function (textid, limit, infodiv) {
            var text = jQuery("#" + textid).val();
            var textlength = text.length;
            if (textlength > limit) {
                jQuery("#" + infodiv).html("0");
                jQuery("#" + textid).val(text.substr(0, limit));
                return false;
            } else {
                jQuery("#" + infodiv).html(limit - textlength);
                return true;
            }
        }
        countchars = function (textid, infodiv) {
            var text = jQuery("#" + textid).val();
            var textlength = text.length;
            jQuery("#" + infodiv).html(textlength + " / " + parseInt(((textlength / 160)) + 1) + " sms");
        }

        /*DIALOGS*/
        opendialog = function (param) {
            var loader = param.loader;
            var width = param.width || "auto";
            var temp_date = new Date();
            var temp_id = "dialog_" + jQuery.trim((((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1));
            jQuery("body").append("<div class='dialog' id='" + temp_id + "'></div>");
            jQuery("#" + loader).html(loader_img);
            if (param.url != null) {
                jQuery.get(param.url, function (data) {
                    jQuery("#" + temp_id).append(data).dialog({
                        title: param.title || jQuery("#" + temp_id + " h1.title").html(),
                        open: function () {
                            jQuery("#" + loader).html("");
                            jQuery("#" + temp_id + " h1.title").hide();
                            if (param.open != null) { param.open(); }
                        },
                        close: function () {
                            jQuery(this).empty().remove();
                            if (param.close != null) { param.close(); }
                        },
                        modal: false,
                        minHeight: 25,
                        minWidth: 25,
                        resizable: false,
                        autoResize: true,
                        width: width
                    }).append("<div style='display:none;' id='temp_id'>" + temp_id + "</div>");
                });
            } else {
                jQuery("#" + temp_id).append(param.content).dialog({
                    title: param.title || jQuery("#" + temp_id + " div.title").html(),
                    open: function () {
                        jQuery("#" + loader).html("");
                        if (param.open != null) { param.open(); }
                    },
                    close: function () {
                        jQuery(this).empty().remove();
                        if (param.close != null) { param.close(); }
                    },
                    modal: true,
                    minHeight: 25,
                    minWidth: 25,
                    resizable: false,
                    autoResize: true,
                    buttons: {
                        "Ok": function () {
                            jQuery(this).dialog("close");
                        }
                    },
                    width: width
                });
            }
        }
        closedialog = function (obj) {
            /*
            if(obj==null){obj="dummy";}
            jQuery("#"+obj).animate({opacity:1.0},1500,function(){
                jQuery.nyroModalRemove();
            });
            */
            //jQuery.nyroModalRemove();
        }
        function logFirst() {
            $("#logfirst").modal('show');
        }
    </script>

</head>
﻿
<%--<meta property="og:image" content="https://www.kaypoker.com/wp-content/uploads/2023/09/first.png" />--%>
<body>
    <nav class="navbar navbar-fixed-top topheader">

        <div class="container-fluid" style="padding: 10px;">
            <div class="container">
                <div class="row">
                    <div class="col-lg-4">
                        <span style="font-size: 10px; color: white;">언어</span>
                        <a href="?lang=kr">
                            <img src="/resources/images/kr-colored.svg" width="30px"></a>
                        <a href="?lang=en">
                            <img src="/resources/images/en.svg" class="flag-img" width="30px"></a>

                        <!-- <span class="base-color cur_crypt" onclick="openLinkPopUp('http://extra88.com/bitcoin/','Coin Price')">현재 실시간 코인가격</span> -->
                    </div>
                    <div class="col-md-1"></div>
                    <div class="col-md-7">
                        <form action="/home.aspx?aff=<%= Request.QueryString("aff")%>" method="post" class="form-inline headtopmenu">
                            <input id="membername" type="text" class="" required size='12' name="entered_login" autocomplete="off" placeholder="아이디">
                            <input id="j_plain_password" type="password" class="" required autocomplete="off" name="entered_password" size='12' placeholder="비밀번호">
                            <input id="membervalidation" type="text" required autocomplete="off" name="entered_val" size='15' class="" placeholder="오른쪽숫자입력" maxlength="5">
                            <img src="/resources/images/captcha.png" alt="VALIDATION" title="VALIDATION" class="form-captcha" style="vertical-align: top; border-radius: 0;" />
                            <button type="submit" class="nbtn nbtn-login">로그인</button>
                            <!-- <button type="submit" class="btn btn-default btn-login">LOG IN</button> !-->
                            <button onclick="window.location.href = '/registration.aspx?aff=<%= Request.QueryString("aff")%>'" class="nbtn nbtn-register">가입하기 </button>
                            <!-- <span class="forget-pass"><a href="forget-password.php">비밀번호 찾기</a></span> -->
                        </form>
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid navbar-default ">
            <div class="container">
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <div class="nav navbar-nav navbar-right login-mobile">
                        <form action="/home.aspx?aff=<%= Request.QueryString("aff")%>" method="post">
                            <span class="forget-pass"><a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">비밀번호 찾기</a></span>
                            <input id="membername" type="text" class="form-control" required size='16' name="entered_login" autocomplete="off" placeholder="아이디">
                            <input id="j_plain_password" type="password" class="form-control" required autocomplete="off" name="entered_password" size='16' placeholder="비밀번호">
                            <input id="membervalidation" type="text" required autocomplete="off" name="entered_val" size='16' class="form-control" placeholder="오른쪽숫자입력" maxlength="5">
                            <img src="/resources/images/captcha.png" alt="VALIDATION" title="VALIDATION" class="form-captcha" />
                            <button type="submit" class="btn btn-default btn-login">로그인</button>
                            <!-- <button type="submit" class="btn btn-default btn-login">LOG IN</button> !-->
                            <a href="/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                <div type="submit" class="btn btn-default btn-register">가입하기</div>
                            </a>
                        </form>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-md-4">
                                <a class="nvbar-brand" href="/home.aspx?aff=<%= Request.QueryString("aff")%>">
                                    <img src="/resources/images/logo.png"></a>
                            </div>
                            <div class="col-md-1" style="padding-right: 0;">
                            </div>
                            <div class="col-md-7" style="padding-right: 0;">
                                <ul class="nav navbar-nav topnavbar">
                                    <!-- <li><a href="index.php"><span class="glyphicon glyphicon-home"></span></a></li> -->
                                    <li><a href="/registration.aspx?aff=<%= Request.QueryString("aff")%>">가입하기</a></li>
                                    <li><a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">친구추천</a></li>
                                    <li><a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">프로모션</a></li>
                                    <li><a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">모바일</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </nav>



    <div class="latest-news news_info">
        <div class="container" style="height: 20px;">
            <marquee><span>2024-04-04</span>&nbsp;&nbsp;  3월의 다양한 이벤트 내용은 프로모션 페이지에서 확인하시어 많은 혜택 받으시기 바랍니다. 현재 아이폰 어플 이용이 불가하오니 사파리로 모바일 웹 이용 부탁 드립니다.</marquee>
        </div>
    </div>
    <!-- IMG SLIDER -->
    <link rel="stylesheet" href="/resources/css/reset.css" />
    <script src="/resources/js/Carousel.js"></script>
    <!-- END IMG SLIDER -->

    <!-- MARQUEE GAME -->
    <link rel="stylesheet" href="/resources/css/jquery.picMarque.css" />
    <script src="/resources/js/jquery.marquee.js"></script>
    <script src="/resources/js/jquery.pause.js"></script>
    <script src="/resources/js/jquery.easing.1.3.js"></script>
    <!-- END MARQUEE GAME -->


    <!-- POP UP -->
    <div id="myModal" class="modal fade" role="dialog">
        <center style='margin: 15%;'>
            <img src="/resources/images/popupbanner.png?v=1693756831">
            <br>
                <a href="/registration.aspx?aff=<%= Request.QueryString("aff")%>" style="padding: 10px 20px;color: white;margin-top: 17px;display: inline-block;"><!-- 프로모션 확인 -->
                    <img src="/resources/images/sssbutton.png">
                </a>
        </center>
    </div>
    <div id="logfirst" class="modal fade" role="dialog">
        <center style='margin: 15% auto; width: 25%;'>
            <div class="modal-content" style="padding: 20px">
                <h4>회원님, 로그인 후 이용 부탁 드립니다.</h4>
            </div>
        </center>
    </div>
    <!-- END -->

    <div class="contenttop" style="margin-top: 0;">
        <!-- BIG BANNER -->
        <!-- END BIG BANNER -->

        <script>
            $(document).ready(function () {
                Carousel.init($("#carousel"));
                $("#carousel").init();
            });
        </script>

        <div class="poster-main" id="carousel" data-setting='{
                        "width":1200,
                        "height":282,
                        "posterWidth":1000,
                        "posterHeight":282,
                        "scale":0.7,
                        "speed":1000,
                        "autoPlay":true,
                        "delay":3000,
                        "verticalAlign":"middle"
                        }'>
            <div class="poster-btn poster-prev-btn"></div>
            <ul class="poster-list" style="left: -99px; position: relative;">
                <li class="poster-item"><a href="#"><img src="https://www.kaypoker.com/wp-content/uploads/2023/09/first.png" width="100%" /></a></li>
                <li class="poster-item"><a href="#"><img src="https://www.kaypoker.com/wp-content/uploads/2023/09/main12.png" width="100%" /></a></li>
                <li class="poster-item"><a href="#"><img src="https://www.kaypoker.com/wp-content/uploads/2024/01/dailybonus2.png" width="100%" /></a></li>
                <li class="poster-item"><a href="#"><img src="/resources/images/slider-1.jpg" alt="" width="100%" /></a></li>
                <li class="poster-item"><a href="#"><img src="/resources/images/slider-2.jpg" alt="" width="100%" /></a></li>
                <li class="poster-item"><a href="#"><img src="/resources/images/slider-3.jpg" alt="" width="100%" /></a></li>
                <li class="poster-item"><a href="#"><img src="/resources/images/slider-4.jpg" alt="" width="100%" /></a></li>
                <li class="poster-item"><a href="#"><img src="/resources/images/slider-5.jpg" alt="" width="100%" /></a></li>
                <li class="poster-item"><a href="#"><img src="/resources/images/slider-6.jpg" alt="" width="100%" /></a></li>
                <li class="poster-item"><a href="#"><img src="/resources/images/slider-7.jpg" alt="" width="100%" /></a></li>
            </ul>
            <div class="poster-btn poster-next-btn"></div>
        </div>

        <div id="container-jackpot" class="container-fluid contentmiddle">
            <div class="container">
                <div class="row">
                    <div class="font-paladins">
                        <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                            <h4 class="white">Progressive Jackpot</h4>
                            <p class="jacknum">837,456,620</p>
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="contentmiddlescnd">
            <div class="container">
                <div class="row">
                    <center>
                        <div class="col-md-12">
                            <div class="col-md-4">
                                <div class="col-md-3 p-0">
                                    <img src="/resources/images/apple1.svg" style="height: 50px;">
                                </div>
                                <div class="col-md-8">
                                    <h5 class="white">iOS 다운로드</h5>
                                    <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">
                                        <p style="font-size: 11px; color: #B571D8;">클릭하여 다운로드!</p>
                                    </a>
                                    <!-- <a href="javascript:void(0)" class="downloadbtn white">Play Now</a> -->
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-3 p-0">
                                    <img src="/resources/images/android1.svg" style="height: 50px;">
                                </div>
                                <div class="col-md-8">
                                    <h5 class="white">안드로이드 다운로드</h5>
                                    <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">
                                        <p style="font-size: 11px; color: #1DC1A6;">클릭하여 다운로드!</p>
                                    </a>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-3 p-0">
                                    <img src="/resources/images/windows.svg" style="height: 50px;">
                                </div>
                                <div class="col-md-8">
                                    <h5 class="white">웹 플레이</h5>
                                    <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');">
                                        <p style="font-size: 11px; color: #C3850F;">플레이 하기!</p>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </center>
                </div>
            </div>
        </div>
        <div class="ourgames_box">
            <div class="container">
                <div class="row">
                    <center>
                        <h3 class="white mtb-30">
                            <u class="undermenu">이용가능 게임</u>
                        </h3>
                        <div class="col-md-12 mtb-30">
                            <div class="col-md-3">
                                <a href="/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                    <img src="/resources/images/poker.png" height="120px">
                                    <h4 class="white">텍사스 홀덤</h4>
                                </a>
                            </div>
                            <div class="col-md-3">
                                <a href="/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                    <img src="/resources/images/omaha.png" height="120px">
                                    <h4 class="white">오마하</h4>
                                </a>
                            </div>
                            <div class="col-md-3">
                                <a href="/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                    <img src="/resources/images/super10.png" height="120px">
                                    <h4 class="white">슈퍼 10</h4>
                                </a>
                            </div>
                            
                            <div class="col-md-3">
                                <a href="/registration.aspx?aff=<%= Request.QueryString("aff")%>">
                                    <img src="/resources/images/tournament.png" height="120px">
                                    <h4 class="white">홀덤 토너먼트</h4>
                                </a>
                            </div>
                        </div>
                    </center>
                </div>
            </div>
        </div>

        <div class="latest-news">
            <div class="container">
                <div class="row">
                    <center>
                        <h3 class="white mtb-30">
                            <u class="undermenu">공지사항</u>
                        </h3>
                        <div class="col-md-12 mtb-30">
                            <div class="col-md-6" align="left">
                                <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                    <div class="col-md-2">
                                    <span>07/05 &nbsp;</span>
                                </div>
                                <div class="col-md-10">
                                    <span>※중요※ 최신 구글 크롬, 파이어폭스, 모바일 어플 관련</span>
                                </div>
                                </a>
                            </div>
                            <div class="col-md-6" align="left">
                                <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                    <div class="col-md-2">
                                    <span>07/05 &nbsp;</span>
                                </div>
                                <div class="col-md-10">
                                    <span>※중요※ 계정 보안에 관한 안내</span>
                                </div>
                                </a>
                            </div>
                            <div class="col-md-6" align="left">
                                <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                    <div class="col-md-2">
                                    <span>07/05 &nbsp;</span>
                                </div>
                                <div class="col-md-10">
                                    <span>※중요※ 매주 목요일 정기점검</span>
                                </div>
                                </a>
                            </div>
                            <div class="col-md-6" align="left">
                                <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                    <div class="col-md-2">
                                    <span>07/05 &nbsp;</span>
                                </div>
                                <div class="col-md-10">
                                    <span>※중요※ 게임상의 오류 문의 방법</span>
                                </div>
                                </a>
                            </div>
                            <div class="col-md-6" align="left">
                                <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                    <div class="col-md-2">
                                    <span>05/04 &nbsp;</span>
                                </div>
                                <div class="col-md-10">
                                    <span>※중요※ 회원간 칩 이동에 대한 규정</span>
                                </div>
                                </a>
                            </div>
                            <div class="col-md-6" align="left">
                                <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                    <div class="col-md-2">
                                    <span>31/08 &nbsp;</span>
                                </div>
                                <div class="col-md-10">
                                    <span>※안내※ Direpay (암호화폐) 입금 런칭!!</span>
                                </div>
                                </a>
                            </div>
                            <div class="col-md-6" align="left">
                                <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                    <div class="col-md-2">
                                    <span>21/10 &nbsp;</span>
                                </div>
                                <div class="col-md-10">
                                    <span>※중요※ 입금 및 출금 안내</span>
                                </div>
                                </a>
                            </div>
                            <div class="col-md-6" align="left">
                                <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="white">
                                    <div class="col-md-2">
                                    <span>29/12 &nbsp;</span>
                                </div>
                                <div class="col-md-10">
                                    <span>※안내※ 게임 내 칩 환산 안내 현재 11배 변경</span>
                                </div>
                                </a>
                            </div>
                        </div>
                    </center>
                </div>
            </div>
        </div>

        <div class="promotion_box">
            <div class="container">
                <div class="row">
                    <center>
                        <h3 class="white mtb-30">
                            <u class="undermenu">프로모션</u>
                        </h3>
                    </center>
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <img src="https://www.kaypoker.com/wp-content/uploads/2020/11/leikeubaek4.png" width="100%">
                            <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" style="cursor: pointer;">
                                <div class="promoname" align='left' style="padding: 25px 15px;">
                                    <h4 class="white">매주 무제한 레이크백 보너스! VIP 혜택 추가!</h4>
                                    <span class="promoreadmore">확인하기</span>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-4">
                            <img src="https://www.kaypoker.com/wp-content/uploads/2020/11/sinkyu3.png" width="100%">
                            <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" style="cursor: pointer;">
                                <div class="promoname" align='left' style="padding: 25px 15px;">
                                    <h4 class="white">12월의 신규 회원 첫 입금 보너스 50% 및 토너먼트 참가권!</h4>
                                    <span class="promoreadmore">확인하기</span>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-4">
                            <img src="https://www.kaypoker.com/wp-content/uploads/2023/03/daily_promo.png" width="100%">
                            <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" style="cursor: pointer;">
                                <div class="promoname" align='left' style="padding: 25px 15px;">
                                    <h4 class="white">12월의 매일 매일 데일리 보너스! 최대 10%!!</h4>
                                    <span class="promoreadmore">확인하기</span>
                                </div>
                            </a>
                        </div>

                    </div>

                    <div class="col-md-12 mtb-30">
                        <br>
                        <center>
                            <a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" class="downloadbtn white">모든 프로모션 확인</a>
                        </center>
                    </div>
                </div>
            </div>
        </div>

        <div class="bottom_download">
            <div class="container-fluid">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 phonebottom">
                            <div class="col-md-7"></div>
                            <div class="col-md-5">
                                <h4 class="hover-color">포커게임을 손안에서 간편하게!</h4>
                                <p class="white" style="font-size: 15px;">SSS POKER를 손안의 모바일에서 즐겨보세요! 언제나 어디서나 즐겁게 즐길 수 있는 모바일 앱을 다운로드 받으세요!</p>
                                <div class="bottomdwnld">
                                    <img src="/resources/images/apple1.svg" height="20px">
                                    <span class="white">아이폰 다운로드</span>
                                </div>
                                <div class="bottomdwnld">
                                    <img src="/resources/images/android2.svg" height="20px">
                                    <span class="white">안드로이드 다운로드</span>
                                </div>
                            </div>
                            <!-- <img src="assets/img/phonebottom.png"> -->
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <script type="text/javascript">
            $(document).ready(function () {
                $(".contact-hover").mouseover(function () {
                    $(this).attr("src", $(this).attr("src").replace(".svg", ".png"));
                }).mouseout(function () {
                    $(this).attr("src", $(this).attr("src").replace(".png", ".svg"));
                });
            });
        </script>
        <div class="contact-us">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            <h4 class="white" style="display: inline-block;">24/7 고객센터</h4>
                        </div>
                        <div class="col-md-9">
                            <a href="https://t.me/SSSPOKER1" target="_blank">
                                <img src="/resources/images/telegram.svg" class="contact-hover" height="40px">
                                <span class="white">SSSPOKER1</span>
                            </a>

                            <a href="https://open.kakao.com/o/sC4eLaJ" target="_blank">
                                <img src="/resources/images/kakaotalk.svg" class="contact-hover" height="40px">
                                <span class="white">SSSHOLDEM</span>
                            </a>

                            <a href="https://www.kaypoker.com/" target="_blank">
                                <img src="/resources/images/kpokerm.svg" class="contact-hover" height="40px">
                                <span class="white">KAYPOKER.COM</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="legals_box">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <img class="legals_logo" src="/resources/images/logo-bw.png">
                        </div>
                        <div class="col-md-8">
                            <div class="col-md-4 text-left">
                                <h4 class="white"><b>How To Play</b></h4>
                                <br>
                                <a href="https://lobby6.lobbyplay.com/misc/tutorial_kr.php?lang=kr#poker" target="_blank">
                                    <p class="white">Texas Hold'em Poker</p>
                                </a>
                                <a href="https://lobby6.lobbyplay.com/misc/tutorial_kr.php?lang=kr#PokerOmaha" target="_blank">
                                    <p class="white">Pot Limit Omaha</p>
                                </a>
                                <a href="https://lobby6.lobbyplay.com/misc/tutorial_kr.php?lang=kr#superten" target="_blank">
                                    <p class="white">Super10</p>
                                </a>
                                <a href="https://lobby6.lobbyplay.com/misc/tutorial_kr.php?lang=kr#trnrules" target="_blank">
                                    <p class="white">Poker Tournament</p>
                                </a>
                            </div>
                            <div class="col-md-4 text-left">
                                <h4 class="white"><b>Legal</b></h4>
                                <br>
                                <a href="https://lobby6.lobbyplay.com/misc/help.php#privacypolicy" target="_blank">
                                    <p class="white">Privacy Policy</p>
                                </a>
                                <a href="https://lobby6.lobbyplay.com/misc/help.php#disclaimer" target="_blank">
                                    <p class="white">Disclaimer</p>
                                </a>
                                <a href="https://lobby6.lobbyplay.com//misc/terms.php?lang=kr" target="_blank">
                                    <p class="white">Terms & Conditions</p>
                                </a>
                            </div>
                            <div class="col-md-4 text-left">
                                <h4 class="white"><b>Safety & Security</b></h4>
                                <br>
                                <a href="https://idnplay.com/certificate/BMM_EN.html" target="_blank">
                                    <p class="white">Random Number Generator</p>
                                </a>
                                <a href="https://lobby6.lobbyplay.com/misc/help.php#security" target="_blank">
                                    <p class="white">Security</p>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer>
            <div class="container">
                <div class="row">
                    <div class="col-md-6 col-sm-4">
                        <img src="/resources/images/logo-footer.png" style="width: 60%;">
                    </div>
                    <div class="col-md-6 col-sm-8" align="right">
                        <h5 class="white">COPYRIGHT 2024</h5>
                    </div>

                </div>
            </div>
        </footer>


        <script type="text/javascript">
            function openRequestedPopup(link, title) {
                var windowObjectReference;
                var strWindowFeatures = "toolbar=0,location=0,directories=0,status=0,menubar=0,resizable=1,scrollbars=1";
                var w = window.screen.width - 100;
                var h = window.screen.height - 100;
                var windowX = Math.ceil((window.screen.width - (w)) / 2);
                var windowY = Math.ceil((window.screen.height - (h)) / 2);
                splash = windowObjectReference = window.open(link, title, strWindowFeatures);
                splash.resizeTo(Math.ceil(w), Math.ceil(h));
                splash.moveTo(Math.ceil(windowX), Math.ceil(windowY));
            }

            function openLinkPopUp(link, title) {
                var windowObjectReference;
                var strWindowFeatures = "toolbar=0,location=0,directories=0,status=0,menubar=0,resizable=1,scrollbars=1";
                var w = 800;
                var h = 730;
                var windowX = Math.ceil((window.screen.width - (w)) / 2);
                var windowY = Math.ceil((window.screen.height - (h)) / 2);
                splash = windowObjectReference = window.open(link, title, strWindowFeatures);
                splash.resizeTo(Math.ceil(w), Math.ceil(h));
                splash.moveTo(Math.ceil(windowX), Math.ceil(windowY));
            }


        </script>
        <script src="/resources/js/modernizr.js" type="text/javascript"></script>
        <script src="/resources/js/tabs.js" type="text/javascript"></script>
        <script src="/resources/js/bootstrap.js"></script>
        <script type="text/javascript">
            // A $( document ).ready() block.
            $(document).ready(function () {
                if (document.cookie.indexOf('visited=true') == -1) {
                    // load the overlay
                    $('#myModal1').modal({ show: true });

                    var year = 1000 * 60 * 60 * 24 * 365;
                    var expires = new Date((new Date()).valueOf() + year);
                    document.cookie = "visited=true;expires=" + expires.toUTCString();

                }
            });
        </script>
</body>
</html>
