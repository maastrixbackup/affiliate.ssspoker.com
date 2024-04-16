$(document).ready(function () {
    //debugger;
    
    //setTimeout(function () { $(".message").fadeOut(); }, 5000);
    //setTimeout(function () {
    //    $('#ctl00_ContentPlaceHolder1_message').fadeIn('fast', function () {
            
    //        $(document).one('click', function (e) {
    //            debugger;
    //            $('#ctl00_ContentPlaceHolder1_message').fadeOut('fast');
    //        });
    //    });
    //}, 5000);
    $(document).one('click', function ()
    {
        $('.message').hide();
    }
    )

    $(".datetime-tb").datetimepicker({ defaultTime: '00:00', format: 'd/M/Y H:i:00 A' });
    $(".front-datetime-tb").datetimepicker({ timepicker: false, format: 'd/M/Y' });
    $(".time-tb").datetimepicker({ datepicker: false,
        format: 'H:i'
    });
    $(".editdatetime-tb").datetimepicker({ defaultTime: '00:00', format: 'd/M/Y H:i:00 A', validateOnBlur: false });

    $(".orderable").sortable({
        items: 'tbody tr',
        cursor: 'pointer',
        axis: 'y',
        dropOnEmpty: false,
        start: function (e, ui) {
            //ui.item.addClass("selected");
        },
        stop: function (e, ui) {
            //ui.item.removeClass("selected");
        },
        helper: function (e, tr) {
            var $originals = tr.children();
            var $helper = tr.clone();
            $helper.children().each(function (index) {
                // Set helper cell sizes to match the original sizes
                $(this).width($originals.eq(index).outerWidth());
            });
            return $helper;
        }
    });

    $("form.validable").validateWebForm();

    tinymce.init({
        selector: '.editor',
        theme: "modern",
        plugins: [
       'advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker',
       'searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking',
       'save table contextmenu directionality emoticons template paste textcolor'
        ],
        height: 300,
        content_css: 'css/content.css',
        toolbar: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | forecolor backcolor emoticons'

    });

    $(".script-check-cb input").click(function () {
        debugger;
        var the_cb = $(this);
        var id = the_cb.attr("id");
        var id_parts = id.split("_");
        var target = id_parts[2].replace(/Cb/, 'Ta');
        var chb = document.getElementById(id);
        //        if (chb.checked) {
        //            $("#" + id_parts[0] + "_" + id_parts[1] + "_" + target).show();
        //        }
        //        else {
        //            $("#" + id_parts[0] + "_" + id_parts[1] + "_" + target).hide();
        //                }
        $("#" + id_parts[0] + "_" + id_parts[1] + "_" + target).toggleClass("hidden");

    })


    //$("#ctl00_ContentPlaceHolder1_occurenceDd").on("change", function () {
    //    var value = $(this).val();

    //    if (value == "On a date") {
    //        $("#ctl00_ContentPlaceHolder1_occurenceDateTb").parent('div').parent('div').show();
    //        $("#ctl00_ContentPlaceHolder1_occurenceDayDd").parent('div').parent('div').parent('div').parent('div').hide();
    //        $("#ctl00_ContentPlaceHolder1_occurenceDateTb").removeClass('required').addClass('required');
    //        $("#ctl00_ContentPlaceHolder1_occurenceDayDd").removeClass('required');

    //    }
    //    else if (value == "Day of month") {
    //        $("#ctl00_ContentPlaceHolder1_occurenceDateTb").parent('div').parent('div').hide();
    //        $("#ctl00_ContentPlaceHolder1_occurenceDayDd").parent('div').parent('div').parent('div').parent('div').show();
    //        $("#ctl00_ContentPlaceHolder1_occurenceDateTb").removeClass('required');
    //        $("#ctl00_ContentPlaceHolder1_occurenceDayDd").removeClass('required').addClass('required');
    //    }
    //    else {
    //        $("#ctl00_ContentPlaceHolder1_occurenceDateTb").parent('div').parent('div').hide();
    //        $("#ctl00_ContentPlaceHolder1_occurenceDayDd").parent('div').parent('div').parent('div').parent('div').hide();
    //        $("#ctl00_ContentPlaceHolder1_occurenceDateTb").removeClass('required');
    //        $("#ctl00_ContentPlaceHolder1_occurenceDayDd").removeClass('required');
    //    }
    //})

    $("#ctl00_ContentPlaceHolder1_edOccurenceDd").on("change", function () {
        var value = $(this).val();
        if (value == "On a date") {
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDateTb").parent('div').parent('div').show();
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDayDd").parent('div').parent('div').parent('div').parent('div').hide();
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDateTb").removeClass('required').addClass('required');
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDayDd").removeClass('required');
        }

        else if (value == "Day of month") {
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDateTb").parent('div').parent('div').hide();
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDayDd").parent('div').parent('div').parent('div').parent('div').show();
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDateTb").removeClass('required');
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDayDd").removeClass('required').addClass('required');
        }
        else {
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDateTb").parent('div').parent('div').hide();
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDayDd").parent('div').parent('div').parent('div').parent('div').hide();
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDateTb").removeClass('required');
            $("#ctl00_ContentPlaceHolder1_edOccurrenceDayDd").removeClass('required');
        }
    })

    $("#ctl00_ContentPlaceHolder1_releaseOccuranceDd").on("change", function () {
        var value = $(this).val();

        if (value == "Day of month") {
            $("#ctl00_ContentPlaceHolder1_selectDayDd").parent('div').parent('div').parent('div').parent('div').show();
            $("#ctl00_ContentPlaceHolder1_selectDayDd").removeClass('required').addClass('required');
        }
        else {
            $("#ctl00_ContentPlaceHolder1_selectDayDd").parent('div').parent('div').hide();
            $("#ctl00_ContentPlaceHolder1_selectDayDd").removeClass('required');
        }
    })
    $("#ctl00_ContentPlaceHolder1_edReleaseOccuranceDd").on("change", function () {
        var value = $(this).val();

        if (value == "Day of month") {
            $("#ctl00_ContentPlaceHolder1_edSelectDayDd").parent('div').parent('div').parent('div').parent('div').show();
            $("#ctl00_ContentPlaceHolder1_edSelectDayDd").removeClass('required').addClass('required');
        }
        else {
            $("#ctl00_ContentPlaceHolder1_edSelectDayDd").parent('div').parent('div').hide();
            $("#ctl00_ContentPlaceHolder1_edSelectDayDd").removeClass('required');
        }
    })
    $('#ctl00_ContentPlaceHolder1_contentTb').on("input", function () {
        var desc = $('#ctl00_ContentPlaceHolder1_contentTb').val();
        var len = desc.length;
        if (desc.length >= 150) {
            this.value = this.value.substring(0, 150);
        }
    });
    $('#ctl00_ContentPlaceHolder1_edContentTb').on("input", function () {
        var desc = $('#ctl00_ContentPlaceHolder1_edContentTb').val();
        var len = desc.length;
        if (desc.length >= 150) {
            this.value = this.value.substring(0, 150);
        }
    });
    $(".editdatetime-tb").keypress(function (event) { event.preventDefault(); });

    var v=[];

    $(document).on("click", "[src*=plus]", function () {

        debugger;
        v.push($(this).next());
        

       
    
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        var id = $(this).next().attr('id');
      $(this).next().remove();
      
      var panel = document.getElementById(id);
   
          var id_parts = id.split("_");
          var chktitle;
          if (id_parts[2] == 'gvModules') {

              var subtableid = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'gvSubModules';
          }
          else {
              var subtableid = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'edGvSubModules';
          }

          var bool;
        
              var subtable = document.getElementById(subtableid);
              var count = subtable.rows.length;

              if (id_parts[2] == 'gvModules') {
                  if ((document.getElementById(id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'chkRowView')).checked) {
                      bool = true;
                      chktitle = 'chkRowView';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  else {
                      chktitle = 'chkRowView';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  if ((document.getElementById(id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'chkRowAdd')).checked) {
                      chktitle = 'chkRowAdd';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  else {
                      chktitle = 'chkRowAdd';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  if ((document.getElementById(id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'chkRowEdit')).checked) {
                      chktitle = 'chkRowEdit';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  else {
                      chktitle = 'chkRowEdit';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  if ((document.getElementById(id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'chkRowDelete')).checked) {
                      chktitle = 'chkRowDelete';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  else {
                      chktitle = 'chkRowDelete';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
              }
              else {
                  if ((document.getElementById(id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'edChkRowView')).checked) {
                      bool = true;
                      chktitle = 'edChkRowView';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  else {
                      chktitle = 'edChkRowView';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  if ((document.getElementById(id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'edChkRowAdd')).checked) {
                      chktitle = 'edChkRowAdd';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  else {
                      chktitle = 'edChkRowAdd';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  if ((document.getElementById(id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'edChkRowEdit')).checked) {
                      chktitle = 'edChkRowEdit';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  else {
                      chktitle = 'edChkRowEdit';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  if ((document.getElementById(id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'edChkRowDelete')).checked) {
                      chktitle = 'edChkRowDelete';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
                  else {
                      chktitle = 'edChkRowDelete';
                      check(count, id_parts[0], id_parts[1], id_parts[2], id_parts[3], chktitle);
                  }
              
          }
      
     
    
        $(this).attr("src", "../../Sources/Images/Menu_Icons/minus.png");


    });
    $(document).on("click", "[src*=minus]", function () {
        debugger;
        var x = $(this);
        var y = x.parent();
        var z = y.next().next().find('input')
        //var chk = z.getElementsByTagName('input');
        
        var id = z.attr('id');
        var idparts = id.split('_');
        var id_panel = idparts[0] + '_' + idparts[1] + '_' + idparts[2] + '_' + idparts[3] + '_' + 'panel1';
        for (var i = 0; i < v.length; i++)
        {
            if(v[i].attr('id')==id_panel)
            {
                $(this).after(v[i]);
                v.splice(i, 1);
            }
        }
        $(this).attr("src", "../../Sources/Images/Menu_Icons/plus.png");
       
        $(this).closest("tr").next().remove();
        
    });
    $(".document").on("click", function () {

        if ($('.checkbox').is(':checked')) {
            $('.checkbox').attr('checked', 'checked')
        }
        else {
            $('.checkbox').removeAttr('checked');
        }

    })
    //    debugger;
    //    $("#myModal").modal('show');

    $(".hello input").click(function () {
        debugger;
        var the_cb = $(this);
        var id = the_cb.attr("id");
        var spa = id.parentNode;
        if ($("spa").hasClass("checked")) {
            spa.removeAttribute('class');
        }
    });
    $("#ctl00_ContentPlaceHolder1_triggerDd").on("change", function () {
        debugger;
        var value = $(this).val();
        if (value == "Open page") {
            $("#ctl00_ContentPlaceHolder1_pageDd").parent('div').parent('div').parent('div').parent('div').show();

            $("#ctl00_ContentPlaceHolder1_pageDd").removeClass('required').addClass('required');


        }

        else {
            $("#ctl00_ContentPlaceHolder1_pageDd").parent('div').parent('div').parent('div').parent('div').hide();

            $("#ctl00_ContentPlaceHolder1_pageDd").removeClass('required');
        }
    });
    $("#ctl00_ContentPlaceHolder1_edTriggerDd").on("change", function () {
        debugger;
        var value = $(this).val();
        if (value == "Open page") {
            $("#ctl00_ContentPlaceHolder1_edPageDd").parent('div').parent('div').parent('div').show();

            $("#ctl00_ContentPlaceHolder1_edPageDd").removeClass('required').addClass('required');


        }

        else {
            $("#ctl00_ContentPlaceHolder1_edPageDd").parent('div').parent('div').parent('div').hide();

            $("#ctl00_ContentPlaceHolder1_edPageDd").removeClass('required');
        }
    });
    jQuery('.tabs .tab-links a').on('click', function (e) {
        debugger;
        var querystring = 'action';
        var value;
        function getParamValuesByName(querystring) {
            var qstring = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < qstring.length; i++) {
                var urlparam = qstring[i].split('=');
                if (urlparam[0] == querystring) {
                    return urlparam[1];
                }
            }
        }
        if (value == 'add' || value == 'edit')
        {
                
        }

        var currentAttrValue = jQuery(this).attr('href');
        // Show/Hide Tabs
        jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

        // Change/remove current tab to active
        jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

        e.preventDefault();
    });
    $(".parentcheck input").change(function () {
        debugger;
        var the_cb = $(this);
        var id = the_cb.attr("id");
        var parentchk = document.getElementById(id);
        var id_parts = id.split("_");
        if (id_parts[2] == 'gvModules') {
            var subid = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'gvSubModules';
        }
        else {
            var subid = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'edGvSubModules';
        }
       
      
        var subtable = document.getElementById(subid);
        var count = subtable.rows.length;
      
        for (var i = 2; i < 2 + (count - 1) ; i++) {
            if (id_parts[2] == 'gvModules') {
                var chkid = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'gvSubModules' + '_' + 'ctl0' + i + '_' + id_parts[4] + 'Page';
            }
            else {
                var chkid = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + 'edGvSubModules' + '_' + 'ctl0' + i + '_' + id_parts[4] + 'Page';
            }
           
            var childchk = document.getElementById(chkid);
            if (parentchk.checked) {
               
                    $("#" + chkid).prop("checked", true);

                }
                else {
                    childchk.checked = false;
                
            }
        }
           

    });
    $('.childcheck input').change(function () {
        debugger;
        var the_cb = $(this);
        var id = the_cb.attr("id");
        var id_parts = id.split("_");
        var childchk = document.getElementById(id);
        var len = childchk.closest('table').rows.length;
        var checkchecked = false;
        var checkunchecked = false;
        for (var i = 2; i < len + 2 - 1; i++) {
            idchk = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + id_parts[4] + '_' + 'ctl0' + i + '_' + id_parts[6];
            var childchks = document.getElementById(idchk);
            if (childchks.checked) {
                checkchecked = true;
            }
            else {
                checkunchecked = true;
            }
        }

        parentid_parts = id_parts[6].split('p');
        parentid = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + parentid_parts[0];
        parentchk = document.getElementById(parentid);
        if (checkchecked == false) {
            parentchk.checked = true;
        }
        else if (checkunchecked == false) {
            parentchk.checked = true;
        }

    });
   


})
function EnableCheckbox(object) {
    debugger;
    var the_cb = $(this);
    var id = object.id;
    var id_parts = id.split("_");
    var childchk = document.getElementById(id);
    var len = childchk.closest('table').rows.length;
    var checkchecked = false;
    var checkunchecked = false;
    for (var i = 2; i < len + 2 - 1; i++) {
        idchk = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + id_parts[4] + '_' + 'ctl0' + i + '_' + id_parts[6];
        var childchks = document.getElementById(idchk);
        if (childchks.checked) {
            checkchecked = true;
        }
        else {
            checkunchecked = true;
        }
    }


    parentid_parts = id_parts[6].split("P");
    parentid = id_parts[0] + '_' + id_parts[1] + '_' + id_parts[2] + '_' + id_parts[3] + '_' + parentid_parts[0];
    parentchk = document.getElementById(parentid);
    if (checkchecked == false) {
        parentchk.checked = false;
    }
    else if (checkunchecked == false) {
        parentchk.checked = true;
    }
}
//}
function check(count, part0, part1, part2, part3, chktitle)
{
    debugger;
    var parentchkid = part0 + '_' + part1 + '_' + part2 + '_' + part3 + '_' + chktitle;
    var parentchk = document.getElementById(parentchkid);
    var chkchecked=false;
    var chkunchecked;
    var childchkbox = [];
    for (var i = 2; i < 2 + (count - 1) ; i++) {
        var chkid;
        if (part2 == 'gvModules') {
            chkid = part0 + '_' + part1 + '_' + part2 + '_' + part3 + '_' + 'gvSubModules' + '_' + 'ctl0' + i + '_' + chktitle + 'Page';
            var childchk = document.getElementById(chkid);
            if (childchk.checked == false) {

                if (parentchk.checked) {

                    $("#" + chkid).prop("checked", true);

                }
                else {
                    childchk.checked = false;
                }
            }
           
        }
        else
        {
            chkid = part0 + '_' + part1 + '_' + part2 + '_' + part3 + '_' + 'edGvSubModules' + '_' + 'ctl0' + i + '_' + chktitle + 'Page';
            var child = document.getElementById(chkid);
            if (child.checked) {
                chkchecked = true;
            }
            else {
                chkunchecked = true;
            }
            childchkbox.push(chkid);
           
        }
      
      
    }
    if (part2 != 'gvModules') {

        for (var i = 0; i < childchkbox.length; i++) {

            if (chkchecked == false) {


                var childchk = document.getElementById(childchkbox[i]);
                if (childchk.checked == false) {

                    if (parentchk.checked) {

                        $("#" + childchkbox[i]).prop("checked", true);

                    }
                    else {
                        childchk.checked = false;
                    }
                }
            }

        }
    }
}




