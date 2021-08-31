//================================
//== MANEJO DE TABS
//===============================

function currentTab() {
    //return ($('.ui-tabs-panel:not(.ui-tabs-hide)').index() - 1);
    return ($('.ui-tabs-panel:not(.ui-tabs-hide)').parent("li").index());
}

function currentTabIndex() {
    return ($('.ui-tabs-panel:not(.ui-tabs-hide)').index() - 1);
    //return ($("li.current").parent("li"));
}

function closeTab(index) {
    var $tabs = $('#tabs').tabs();
    $tabs.tabs("remove", index);
    $tabs.tabs('select', 0);
}

function setActiveTab(el) {

    $('ul.nav-tabs li.active').removeClass('active').removeClass('ui-tabs-selected').removeClass('ui-state-active');
    if ($(el).prop("tagName") != "LI") {
        $(el).parent('li').addClass('active');
    } else {
        $(el).addClass('active');
    }

    if ($(el).data("cache") == "false") {
        var el = $("#page-container");
        App.blockUI(el);
    } else {
        if ($(el).data("load") == "false") {
            var el = $("#page-container");
            App.blockUI(el);
            $(el).data("load", "true");
        }
    }

}

function inicializarTab() {
    $("#tab1").attr("href", $.cookie("vista"));

    $("a[data-toggle=tab]").click(function () {
        setActiveTab(this);
    });

    if ($.cookie("tabs") != "") {
        var arr = JSON.parse($.cookie("tabs"));
        $.each(arr, function (i, item) {
            //createTab(item.label, item.url, item.close, item.cache, false);
            app.addTab(item.url);
        });
    }
    setActiveTab($("#tabs ul li").eq(0));
}


function closeMe(el) {
    closeCurrentTab($(el).closest('li').index());
    listTab(1);
}

function createTab(title, url, close, pcache, redireccionar) {


    var plantilla = "";
    if (close) {
        plantilla = '<li><a onclick="setActiveTab(this)" data-toggle="tab" data-cache="'+pcache+'" data-load="false" href="#{href}">#{label}</a>' + '<span t="close" onclick="closeMe(this);" class="ui-icon ui-icon-close">Cerrar Pestaña</span></li>';
    } else {
        plantilla = '<li><a onclick="setActiveTab(this)" data-toggle="tab" data-cache="'+pcache+'" data-load="false" href="#{href}">#{label}</a></li>';
    }

    var $tabs = $('#tabs').tabs({
        tabTemplate: plantilla,
        beforeActivate: function (event, ui) {
            //ui.newPanel.find('form').find('input').first().focus();
            //aca hay que implementar que se ponga el foco al primer elemento del formulario seleccionado. PROBLEMA!: cuando corre este evento se está cargando el formulario
        },
        beforeLoad: function (event, ui) {
            if (ui.tab.data("loaded")) {
                event.preventDefault();
                return;
            }
            ui.jqXHR.success(function () {
                ui.tab.data("loaded", pcache);
            });
        },
        ajaxOptions: { cache: pcache },
        spinner: 'Cargando...'
    });

    $tabs.tabs('add', url, title);

    if (redireccionar) {
        $tabs.tabs('select', $tabs.tabs('length') - 1);
        var el = $("#page-container");
        App.blockUI(el);
    }

}

function createTabReturn(title, url, close, pcache, pcontrolId, pcontrolValue, tabIndex) {


    var plantilla = "";
    if (close) {
        plantilla = '<li><a onclick="setActiveTab(this)" data-toggle="tab" href="#{href}">#{label}</a>' + '<span t="close" onclick="closeMe(this);" class="ui-icon ui-icon-close">Cerrar Pestaña</span></li>';
    } else {
        plantilla = '<li><a onclick="setActiveTab(this)" data-toggle="tab" href="#{href}">#{label}</a></li>';
    }

    var $tabs = $('#tabs').tabs({
        tabTemplate: plantilla,
        beforeActivate: function (event, ui) {
            //ui.newPanel.find('form').find('input').first().focus();
            //aca hay que implementar que se ponga el foco al primer elemento del formulario seleccionado. PROBLEMA!: cuando corre este evento se está cargando el formulario
        },
        beforeLoad: function (event, ui) {
            if (ui.tab.data("loaded")) {
                event.preventDefault();
                return;
            }
            ui.jqXHR.success(function () {
                ui.tab.data("loaded", pcache);
            });
        },
        ajaxOptions: { cache: pcache },
        spinner: 'Cargando...'
    });

    $tabs.tabs('add', url, title);

    $tabs.tabs('select', $tabs.tabs('length') - 1);
    
    
}


function closeCurrentTab(id) {
    var $tabs = $('#tabs').tabs();
    $tabs.tabs("remove", id);
    //$tabs.tabs('select', 0);
}

function closeCurrentTabAndGo(goto) {
    closeCurrentTab(currentTabIndex());
    selectTab(goto);
}

function listTab() {
    var $tabs = $('#tabs').tabs();
    $tabs.tabs('select', 0);
}

function selectTab(i) {
    var $tabs = $('#tabs').tabs();
    $tabs.tabs('select', i);
    //alert($("#tabs ul li").eq(1).prop("tabindex"));
    setActiveTab($("#tabs ul li").eq(i));
}

//================================
//== AUXILIARES PARA DATATABLES
//===============================

function getData(el, i) {
    return ($(el).closest("tr").find("td:nth-child(" + i + ")").text());
}

function getId(el, i) {
    return ($(el).closest("tr").find("td:nth-child(" + i + ")").text());
}

function getCell(el, i) {
    return ($(el).closest("tr").find("td:nth-child(" + i + ")"));
}

//================================
//== NOTIFICACIONES
//===============================

function notificationError(mensaje) {
    $.gritter.add({
        title: 'Ocurrio un error!',
        text: mensaje,
        image: 'assets/img/icons/error.png'
    });
}

function notificationOk(mensaje) {
    $.gritter.add({
        title: 'Operacion correcta!',
        text: mensaje,
        image: 'assets/img/icons/ok.png'
    });
}




//================================
//== FORMATO DE CAMPOS
//===============================

var pickerOpts = {
    closeText: "Cerrar",
    monthNames: ["Enero", "Febrero", "Marzo", "Abril", "MaYo", "Junio",
    "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    monthNamesShort: ["En", "Feb", "Mar", "Abr", "May", "Jun", "Jul",
    "Ago", "Sep", "Oct", "Nov", "Dic"],
    dayNames: ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves",
    "Viernes", "Sábado"],
    dayNamesShort: ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab"],
    dayNamesMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
    dateFormat: 'dd/mm/yy',
    firstDay: 1,
    changeMonth: true,
    changeYear: true,
    yearRange: '1900:2030'
};

function setDatePicker(clase) {

    $(clase).datepicker(pickerOpts);

}

function setValidadorDecimal() {
    jQuery.extend(jQuery.validator.methods, {
        number: function (value, element) {
            return this.optional(element)
             || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:[,.]\d+)?$/.test(value);
        }
    });
}

function limpiarBusqueda(tabla) {

    $(".text_filter").val("");
    $(".date_range_filter").val("");
    $(".select_filter").val("");

    tabla.fnFilterClear();
    tabla.fnDraw();
}

function numFormat(valor, dec, miles) {
    var num = valor, signo = 3, expr;
    var cad = "" + valor;
    var ceros = "", pos, pdec, i;
    for (i = 0; i < dec; i++)
        ceros += '0';
    pos = cad.indexOf('.')
    if (pos < 0)
        cad = cad + "." + ceros;
    else {
        pdec = cad.length - pos - 1;
        if (pdec <= dec) {
            for (i = 0; i < (dec - pdec) ; i++)
                cad += '0';
        }
        else {
            num = num * Math.pow(10, dec);
            num = Math.round(num);
            num = num / Math.pow(10, dec);
            cad = new String(num);
        }
    }
    pos = cad.indexOf('.')
    if (pos < 0) pos = cad.lentgh
    if (cad.substr(0, 1) == '-' || cad.substr(0, 1) == '+')
        signo = 4;
    if (miles && pos > signo)
        do {
            expr = /([+-]?\d)(\d{3}[\.\,]\d*)/
            cad.match(expr)
            cad = cad.replace(expr, RegExp.$1 + ',' + RegExp.$2)
        }
        while (cad.indexOf(',') > signo)
    if (dec < 0)
        cad = cad.replace(/\./, '')

    return cad.replace(".", ",");
}

function formatearFecha(date) {
    if (date == null)
        return "-";
    else {
        var re = /-?\d+/;
        var m = re.exec(date);
        var d = new Date(parseInt(m[0]));
        return (d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear());
    }
}



//================================
//== AJAX
//===============================

function AjaxPost(url, data, okCallback, errorCallback) {

    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: function (data) {
            success = data[0];
            if (data[0]) {
                notificationOk(data[1]);
                okCallback();
            } else {
                error = 1;
                notificationError(data[1]);
                errorCallback();
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert("Error al procesar formulario ajax");
        },
        complete: function () {
            //$("#dialog-confirm").dialog("close");
        }
    }); //end ajax
}


//================================
//== FORMULARIO
//===============================

function limpiarFormulario(el) {
    $(el).closest('form').find("input[type=text],input[type=hidden],textarea").val("");
}

function formManager() {
    //al obtener el foco selecciona el texto
    $("input:text").focus(function () { $(this).select(); });

    //al presionar enter se posiciona en el proximo control
    $('input').bind('keypress', function (eInner) {
        if (eInner.keyCode == 13) //if its a enter key
        {
            var tabindex = $(this).attr('tabindex');
            tabindex++;

            $('[tabindex=' + tabindex + ']').focus();

            return false; 
        }
    });

}

function blockUI (el, loaderOnTop) {
    lastBlockedUI = el;
    jQuery(el).block({
        message: '<img src="./assets/img/loading.gif" align="absmiddle">',
        css: {
            border: 'none',
            padding: '2px',
            backgroundColor: 'none'
        },
        overlayCSS: {
            backgroundColor: '#000',
            opacity: 0.05,
            cursor: 'wait'
        }
    });
}

function unblockUI (el) {
    jQuery(el).unblock({
        onUnblock: function () {
            jQuery(el).removeAttr("style");
        }
    });
}