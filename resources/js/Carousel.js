/**
 * jQuery Carousel.js 
 * æ—‹è½¬æœ¨é©¬
 * https://github.com/LikaiLee/Carousel
 * MIT licensed
 * 
 * Author LikaiLee  HDU
 * Copyright (C) 2016 
 */
; (function ($) {
    var Carousel = function (poster) {
        var me = this;
        this.poster = poster;
        this.posterItemMain = poster.find(".poster-list");
        this.nextBtn = poster.find(".poster-next-btn");
        this.prevBtn = poster.find(".poster-prev-btn");
        this.posterItems = poster.find(".poster-item");
        //å¶æ•°å¼ 
        if (this.posterItems.size() % 2 == 0) {
            this.posterItemMain.append(this.posterItems.eq(0).clone());
            this.posterItems = this.posterItemMain.children();
        };
        this.posterFirstItem = this.posterItems.first(); //ç¬¬ä¸€ä¸ªå¹»ç¯ç‰‡
        this.posterLastItem = this.posterItems.last(); //æœ€åŽ/ä¸Šä¸€ä¸ªå¹»ç¯ç‰‡
        this.rotateFlag = true;

        //é»˜è®¤é…ç½®å‚æ•°
        this.setting = {
            "width": 1000,//å¹»ç¯ç‰‡æ€»å®½
            "height": 270,//å¹»ç¯ç‰‡æ€»é«˜
            "posterWidth": 640, //ç¬¬ä¸€å¸§å®½åº¦ --> å½“å‰æ˜¾ç¤º
            "posterHeight": 270, //ç¬¬ä¸€å¸§é«˜åº¦ --> å½“å‰æ˜¾ç¤º
            "scale": 0.8, //è®°å½•æ˜¾ç¤ºæ¯”ä¾‹å…³ç³»	
            "speed": 1000,
            "autoPlay": true,
            "delay": 2000,//è‡ªåŠ¨æ’­æ”¾é—´éš”æ—¶é—´
            "verticalAlign": "bottom" //top bottom middle
        };
        $.extend(this.setting, this.getSetting());
        this.setSettingValue();
        this.setPosterPos();
        this.nextBtn.click(function () {
            if (me.rotateFlag) {
                me.rotateFlag = false;
                me.carouselRotate("right");
            };

        });
        this.prevBtn.click(function () {
            if (me.rotateFlag) {
                me.rotateFlag = false;
                me.carouselRotate("left");
            };
        });
        if (this.setting.autoPlay) {
            this.autoPlay();
            this.poster.hover(function () {
                clearInterval(me.timer);
            },
                function () {
                    me.autoPlay();
                });
        };

    };
    Carousel.prototype = {
        autoPlay: function () {
            var self = this;
            this.timer = setInterval(function () {
                self.nextBtn.click();
            },
                this.setting.delay);
        },

        //
        /**
         * [carouselRotate æ—‹è½¬åˆ‡æ¢æ•ˆæžœ]
         * @param  {[type]} dir [æ–¹å‘]
         * @return {[type]}     [description]
         */
        carouselRotate: function (dir) {
            var _this_ = this;
            var zIndexArr = [];
            if (dir === "left") {
                this.posterItems.each(function () {
                    var self = $(this),
                        prev = self.prev().get(0) ? self.prev() : _this_.posterLastItem,
                        width = prev.width(),
                        height = prev.height(),
                        zIndex = prev.css("z-index"),
                        opacity = prev.css("opacity"),
                        left = prev.css("left"),
                        top = prev.css("top");
                    zIndexArr.push(zIndex);
                    self.animate({
                        width: width,
                        height: height,
                        //zIndex:zIndex,
                        opacity: opacity,
                        left: left,
                        top: top
                    },
                        _this_.setting.speed,
                        function () {
                            _this_.rotateFlag = true;
                        });
                });
                //zIndexéœ€è¦å•ç‹¬ä¿å­˜å†è®¾ç½®ï¼Œé˜²æ­¢å¾ªçŽ¯æ—¶å€™è®¾ç½®å†å–çš„æ—¶å€™å€¼æ°¸è¿œæ˜¯æœ€åŽä¸€ä¸ªçš„zindex
                this.posterItems.each(function (i) {
                    $(this).css("zIndex", zIndexArr[i]);
                });
            } else if (dir === "right") {
                this.posterItems.each(function () {
                    var self = $(this),
                        next = self.next().get(0) ? self.next() : _this_.posterFirstItem,
                        width = next.width(),
                        height = next.height(),
                        zIndex = next.css("z-index"),
                        opacity = next.css("opacity"),
                        left = next.css("left"),
                        top = next.css("top");
                    zIndexArr.push(zIndex);
                    self.animate({
                        width: width,
                        height: height,
                        //zIndex:zIndex,
                        opacity: opacity,
                        left: left,
                        top: top
                    },
                        _this_.setting.speed,
                        function () {
                            _this_.rotateFlag = true;
                        });
                });
                //zIndexéœ€è¦å•ç‹¬ä¿å­˜å†è®¾ç½®ï¼Œé˜²æ­¢å¾ªçŽ¯æ—¶å€™è®¾ç½®å†å–çš„æ—¶å€™å€¼æ°¸è¿œæ˜¯æœ€åŽä¸€ä¸ªçš„zindex
                this.posterItems.each(function (i) {
                    $(this).css("zIndex", zIndexArr[i]);
                });
            }
        },

        /**
         * [setPosterPos è®¾ç½®å‰©ä½™å¸§çš„ä½ç½®å…³ç³»]
         * 
         */
        setPosterPos: function () {
            var self = this;
            //è¿”å›žæ‰€æœ‰li  ä»Žå·²æœ‰çš„æ•°ç»„ä¸­è¿”å›žé€‰å®šçš„å…ƒç´  
            var sliceItems = this.posterItems.slice(1),
                sliceSize = sliceItems.size() / 2,
                //è¿”å›žç¬¬ 0 - 2ä¸ªli å³è¾¹å¹»ç¯ç‰‡
                rightSlice = sliceItems.slice(0, sliceSize),
                //z-index 
                level = Math.floor(this.posterItems.size() / 2),
                //å·¦è¾¹ä¸ªæ•°
                leftSlice = sliceItems.slice(sliceSize);
            //è®¾ç½®å³è¾¹å¸§çš„ä½ç½®å…³ç³» å®½åº¦ é«˜åº¦ top
            var rw = this.setting.posterWidth, //å®½åº¦
                rh = this.setting.posterHeight,//é«˜åº¦
                //é—´éš™ = ((æ€»å®½ - é¦–å¼ )/2)/å³è¾¹å¼ æ•°
                gap = ((this.setting.width - this.setting.posterWidth) / 2) / level;
            //é™¤åŽ»ç¬¬ä¸€å¼ åŽå·¦å³çš„å®½åº¦
            var firstLeft = (this.setting.width - this.setting.posterWidth) / 2;
            var fixOffsetLeft = firstLeft + rw; //ç¬¬ä¸€å¼  + å·¦è¾¹å®½åº¦
            rightSlice.each(function (i) {
                level--; //z-index é€ä¸ªé€’å‡
                rw = rw * self.setting.scale; //ç¼©æ”¾
                rh = rh * self.setting.scale; //ç¼©æ”¾
                var j = i;
                $(this).css({
                    zIndex: level,
                    width: rw,
                    height: rh,
                    opacity: 1 / (++j),
                    // 1ã€1/1 2ã€1/2 
                    left: fixOffsetLeft + (++i) * gap - rw,
                    //ç¬¬ä¸€å¼  + å·¦è¾¹å®½åº¦ + æ€»gap - å½“å‰å®½åº¦
                    top: self.setVerticalAlign(rh)
                    //(self.setting.height - rh)/2 		//æ€»é«˜ - ç¬¬ä¸€å¼ é«˜åº¦
                });
            });
            /**
             * [è®¾ç½®å·¦è¾¹å¸§çš„ä½ç½®å…³ç³» å®½åº¦ é«˜åº¦ top]
             * @param  {[type]} i) {     å¾ªçŽ¯æ¬¡æ•°   }
             * @return {[type]}    [description]
             */
            var lw = rightSlice.last().width(),
                lh = rightSlice.last().height(),
                oloop = Math.floor(this.posterItems.size() / 2);

            leftSlice.each(function (i) {

                $(this).css({
                    zIndex: i,
                    width: lw,
                    height: lh,
                    opacity: 1 / oloop,
                    // 1ã€1/1 2ã€1/2 
                    left: i * gap,
                    //ä¸ªæ•° * gap
                    top: self.setVerticalAlign(lh)
                    //(self.setting.height - lh)/2 	//æ€»é«˜ - ç¬¬ä¸€å¼ é«˜åº¦
                });
                lw = lw / self.setting.scale;
                lh = lh / self.setting.scale;
                oloop--;
            });
        },
        /**
         * [setVerticalAlign è®¾ç½®åž‚ç›´æŽ’åˆ—å¯¹é½]
         * @param {[type]} height [å¹»ç¯ç‰‡é«˜åº¦]
         * 
         */
        setVerticalAlign: function (height) {
            var verticalType = this.setting.verticalAlign,
                top = 0;
            if (verticalType === "middle") {
                top = (this.setting.height - height) / 2;
            } else if (verticalType === "top") {
                top = 0;
            } else if (verticalType === "bottom") {
                top = this.setting.height - height;
            } else {
                top = (this.setting.height - height) / 2;
            };

            return top;
        },

        /**
         * [setSettingValue ä½¿ç”¨é…ç½®æ•°å€¼æŽ§åˆ¶åŸºæœ¬æ•°å€¼ ]
         * 
         */
        setSettingValue: function () {
            //å¹»ç¯ç‰‡å®½é«˜
            this.poster.css({
                width: this.setting.width,
                height: this.setting.height,
                zIndex: this.posterItems.size() / 2,
            });
            //å¯ä½¿ç”¨ ul{width:100%;height:100%;}ä»£æ›¿
            this.posterItemMain.css({
                width: this.setting.width,
                height: this.setting.height,

            });
            //è®¡ç®—æŒ‰é’®å®½åº¦
            var w = (this.setting.width - this.setting.posterWidth) / 2;
            //alert(this.posterItems.size()/2);
            this.prevBtn.css({
                width: w,
                height: this.setting.height,
                zIndex: Math.ceil(this.posterItems.size() / 2),
            });
            this.nextBtn.css({
                width: w,
                height: this.setting.height,
                zIndex: Math.ceil(this.posterItems.size() / 2),
            });
            //ç¬¬ä¸€å¼ 
            this.posterFirstItem.css({
                width: this.setting.posterWidth,
                height: this.setting.posterHeight,
                left: w,
                zIndex: Math.floor(this.posterItems.size() / 2),
            });
        },
        getSetting: function () {
            var setting = this.poster.attr("data-setting");
            if (setting && setting != "") {
                return $.parseJSON(setting);
            } else {
                return [];
            }
        }
    };
    Carousel.init = function (posters) {
        var _this_ = this;
        posters.each(function () {
            new _this_($(this));
        });
    };
    window.Carousel = Carousel;
})(jQuery);
