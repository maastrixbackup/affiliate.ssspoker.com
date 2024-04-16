<%@ Page Language="VB" AutoEventWireup="false" CodeFile="registration-test.aspx.vb" Inherits="registration_test" %>

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
    <link rel="icon" type="image/png" sizes="192x192" href="../assets/img/favicon/android-icon-192x192.png">
    <link rel="icon" type="image/png" sizes="32x32" href="../assets/img/favicon/favicon-32x32.png">
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
                        <form class="form-inline headtopmenu">
                            <input id="membername" type="text" class="" required size='12' name="entered_login" autocomplete="off" placeholder="아이디">
                            <input id="j_plain_password" type="password" class="" required autocomplete="off" name="entered_password" size='12' placeholder="비밀번호">
                            <input id="membervalidation" type="text" required autocomplete="off" name="entered_val" size='15' class="" placeholder="오른쪽숫자입력" maxlength="5">
                            <img src="/resources/images/captcha.png" alt="VALIDATION" title="VALIDATION" class="form-captcha" style="vertical-align: top; border-radius: 0;" />
                            <button type="submit" class="nbtn nbtn-login">로그인</button>
                            <!-- <button type="submit" class="btn btn-default btn-login">LOG IN</button> !-->
                            <button onclick="window.location.href = 'register.aspx'" class="nbtn nbtn-register">가입하기 </button>
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
                        <form>
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
    <div class="title-page">
        <div class="container">
            <h2><u class="undermenu white" hidden>가입하기</u></h2>
        </div>
    </div>
    <div class="contentone">
        <div class="container">
            <div class="register">
                <form runat="server" id="form1" class="form-horizontal">
                    <div class="row">
                        <div class="col-md-6">
                            <h4 class="mtb-15 white">회원 정보</h4>
                            <br>
                            <div class="col-md-12 p-0">
                                <span class="base-size lightbase-color">아이디* (알파벳과 숫자의 조합 8자리 이하로 구성되어야 합니다.)</span>
                                <asp:TextBox runat="server" ID="txtUsername" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                <div id="ceklis1" class="alert-btn"></div>
                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revUsername" runat="server" ControlToValidate="txtUsername" ValidationExpression="^[a-zA-Z0-9_]{5,255}$" ErrorMessage="Please input without whitespace." ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-12 p-0 mt-15">
                                <span class="base-size lightbase-color">별명* (알파벳과 숫자의 조합 8자리 이하로 구성되어야 하며 아이디와 다르게 입력하여야 합니다.)</span>
                                <asp:TextBox runat="server" ID="txtNickname" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                <div id="ceklis2" class="alert-btn"></div>
                                <asp:RequiredFieldValidator ID="rfvNickname" runat="server" ControlToValidate="txtNickname" ErrorMessage="Nickname is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12 p-0 mt-15">
                                <span class="base-size lightbase-color">이메일*</span>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                <div id="ceklis6" class="alert-btn"></div>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Address is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12 p-0 mt-15" style="display:none;">
                                <span class="base-size lightbase-color">이름*</span>
                                <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" onkeypress='return (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122) || event.charCode = 32'></asp:TextBox>
                                <div id="ceklis10" class="alert-btn"></div>
                            </div>
                            <div class="col-md-12 p-0 mt-15">
                                <span class="base-size lightbase-color">비밀번호* (비밀번호는 영문+숫자+"@" 조합으로 10자리 이상이어야 합니다.)</span>
                                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <div id="ceklis3" class="alert-btn"></div>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z@\d]{6,}$" ErrorMessage="Password must be alphanumeric and no symbol allowed." ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-12 p-0 mt-15">
                                <span class="base-size lightbase-color">비밀 번호 확인*</span>
                                <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <div id="ceklis4" class="alert-btn"></div>
                                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator runat="server" ID="cvPassword" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password NOT match." ForeColor="Red"></asp:CompareValidator>
                            </div>
                            <!--<div class="col-md-12 p-0 mt-15">
                                <span class="base-size lightbase-color">보안문자를 입력해 주세요*</span>
                                <div class="col-md-12 p-0">
                                    <div class="col-md-8 p-0">
                                        <asp:TextBox runat="server" ID="txtCaptcha" MaxLength="5" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 p-0">
                                        <img src='http://ssspk88.com/kr/captcha/captcha.php?.png?a=1' style="width: 90%; border-radius: 0; float: right; padding-top: 1px; height: 36px;" alt='CAPTCHA' class="form-captcha" />
                                    </div>
                                </div>
                            </div>-->
                        </div>
                        <div class="col-md-6">
                            <h4 class="mtb-15 white">은행 이름*</h4>
                            <br>
                            <div class="col-md-12 p-0">
                                <span class="base-size lightbase-color">은행 이름*</span>
                                <asp:DropDownList runat="server" ID="ddlBank" CssClass="form-control" DataTextField="BankName" DataValueField="BankDetails"></asp:DropDownList>
                            </div>
                            <div class="col-md-12 p-0 mt-15">
                                <span class="base-size lightbase-color">계좌 번호*</span>
                                <asp:TextBox runat="server" ID="txtBankAccount" CssClass="form-control" MaxLength="16" onkeypress='return event.charCode >= 48 && event.charCode <= 57'></asp:TextBox>
                                <div id="ceklis9" class="alert-btn"></div>
                            </div>
                            <div class="col-md-12 p-0 mt-15">
                                <i class="base-size warning">중요*<br>
                                    정확한 계좌정보를 입력해 주세요 , 입출금시 불이익을 받을수 있습니다							</i>
                            </div>
                            <div class="col-md-12 p-0 mt-15">
                                <span class="base-size lightbase-color">예금주*</span>
                                <asp:TextBox runat="server" ID="txtBankName" CssClass="form-control" onkeypress='return (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122) || event.charCode = 32'></asp:TextBox>
                                <div id="ceklis8" class="alert-btn"></div>
                            </div>
                            <div class="col-md-12 p-0 mt-15">
                                <span class="base-size lightbase-color">전화*</span>
                                <div class="col-md-12 p-0">
                                    <asp:DropDownList runat="server" ID="ddlContactNo" CssClass="form-control" Style="width: 8%; float: left;">
                                        <asp:ListItem Value="82">+82</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" style="float: left; width: 92%;" onkeypress='return event.charCode >= 48 && event.charCode <= 57'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Contact No. is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                    <div id="ceklis7" class="alert-btn"></div>
                                </div>
                            </div>
                            <div class="col-md-12 p-0 mt-15">
                                <span class="base-size lightbase-color">추천인*</span>
                                <asp:TextBox runat="server" ID="txtAffCode" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row mtb-30">
                        <div class="col-md-12">
                            <center>
                                <div class="col-md-12">
                                    <div class="round" style="height: 20px; width: 2%; position: relative; display: inline-block; border-radius: 27px;">
                                        <input type="checkbox" id="checkbox" />
                                        <label for="checkbox" id='testsaa'></label>
                                    </div>
                                    <span
                                        class="form-text white"
                                        style="font-style: italic; font-size: 12px; display: inline-block; vertical-align: top;"><a href="https://lobby6.lobbyplay.com/misc/help.php#terms" target="_blank">이용약관 동의</a></span>
                                </div>
                                <button runat="server" id="btnSubmit" class="nbtn nbtn-login" style="width: 43%; padding: 10px 0;" value="SUBMIT" onserverclick="btnSubmit_ServerClick">가입하기</button>
                            </center>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script src="assets/js/fast-checker-validation-native.js"></script>

    <script>
        $(document).ready(function () {
            $("#the_phone").on("input", function () {
                if (/^0/.test(this.value)) {
                    this.value = this.value.replace(/^0/, "")
                }
            })
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
            // 	fast_checking('the_pass', 'ceklis3', 'user_name');
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

            $('#' + id_div2).html("<img src='assets/img/loader.gif' width='30' title='checking...' />");
            //alert(id_val2);
            $.post("fast_checking.php", { id_div: id_div, id_val: id_val, id_val2: id_val2 },
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

                        //show that the username is available  
                        $('#' + id_div).css({ "color": "#DD5B5B" });
                        $('#' + id_div2).css({ "background": "#DD5B5B" });
                        $('#' + id_div2).html("<img src='assets/img/close.svg' style='margin-top:5px;' title='" + inresult[1] + "' />");
                        $('#' + id_div).val(inresult[1]);
                    } else {
                        if (id_div.length > 0) checkValidation(id_div, id_val, true); // check the validation

                        //show that the username is NOT available  
                        $('#' + id_div).css({ "color": "#777777" });
                        $('#' + id_div2).css({ "background": "#83CC7A" });
                        $('#' + id_div2).html("<img src='assets/img/check.svg' style='margin-top:6px;' title='" + inresult[1] + "' />");

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
                        <a href="https://telegram.org/dl" target="_blank">
                            <img src="/resources/images/telegram.svg" class="contact-hover" height="40px">
                            <span class="white">SSSPOKER1</span>
                        </a>

                        <%--<a href="javascript:uialert('회원가입 후 이용가능합니다 ! <br />감사합니다.');" target="_blank">
                            <img src="/resources/images/wechat.svg" class="contact-hover" height="40px">
                            <span class="white">SSSPOKER2</span>
                        </a>--%>

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
                    <div class="col-md-4 text-left">
                        <h4 class="" style="color: #406daa;"><b>How To Play</b></h4>
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
                        <h4 class="" style="color: #406daa;"><b>Legal</b></h4>
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
                        <h4 class="" style="color: #406daa;"><b>Safety & Security</b></h4>
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
