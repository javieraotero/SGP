/// <reference path="types/jquery.dataTables.d.ts" />
/// <reference path="types/jquery.d.ts"/>
/// <reference path="types/jqueryui.d.ts"/>
/// <reference path="types/blockui.d.ts"/>
/// <reference path="types/jquery.cookie.d.ts"/>
/// <reference path="types/jquery.validation.d.ts"/>
/// <reference path="types/toastr.d.ts"/>
/// <reference path="types/bootbox.d.ts"/>
/// <reference path="Syncro/SyncroModal.ts"/>
/// <reference path="types/linq/linq.d.ts" />
/// <reference path="Global.ts" />
var AppManager = (function () {
    //public controller: any; 
    function AppManager() {
        this.global = new Global();
        //referencia al contenedor tabs
        this.tab = $('#tabs').tabs();
        //$("#ul").addClass("ui-tabs-nav").addClass("ui-helper-reset").addClass("ui-helper-clearfix").addClass(" ui-widget-header").addClass("ui-corner-all");
        this.tab_count = 0;
        //referencia al contenedor APP 
        this.page_container = $("#page-container");
        this.tab_previo = [];
        this.tab_previo.push(0);
        this.block = new SyncroBlock($("#page-container"));
        this.tabs = new SyncroTab("#tabs", this.block);
        this.modal = new SyncroModal($("#MainModal"));
        //$(document).ajaxStart(this.Bloquear()).ajaxStop(this.Desbloquear());
        //Seteo de notificaciones por defecto
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": 1000,
            "hideDuration": 1000,
            "timeOut": 5000,
            "extendedTimeOut": 1000,
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
        //Seteo de opciones de datepicker
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
            yearRange: '1900:2025'
        };
        $.fn.datetimepicker.dates['en'] = {
            days: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"],
            daysShort: ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab", "Dom"],
            daysMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa", "Do"],
            months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
            monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
            today: "Hoy",
            meridiem: '',
        };
        $.datepicker.setDefaults(pickerOpts);
        $.datepicker.setDefaults($.datepicker.regional["es-AR"]);
        //this.controlador = new ControladoresManager();
        this.initSignalR();
        this.getData("Expedientes/SolicitudesDeViaticos/GetPartidas", null).done(function (data) {
            global.partidas = data;
        });
        //this.getData("Expedientes/SolicitudesDeViaticos/GetConceptos", null).done(function (data) {
        //    global.conceptos = data;
        //}); 
    }
    AppManager.prototype.byString = function (o, s) {
        s = s.replace(/\[(\w+)\]/g, '.$1'); // convert indexes to properties
        s = s.replace(/^\./, ''); // strip a leading dot
        var a = s.split('.');
        for (var i = 0, n = a.length; i < n; ++i) {
            var k = a[i];
            if (k in o) {
                o = o[k];
            }
            else {
                return;
            }
        }
        return o.toString();
    };
    AppManager.prototype.initSignalR = function () {
        var self = this;
        this.hub = $.connection.serviciosHub;
        $.connection.hub.logging = true;
        self.hub.client.recibirMensaje = function (x) {
            alert(x);
        };
        self.hub.client.mostrarNotificacionPorOrganismo = function (title, x, oficina) {
            if (oficina == global.organismo) {
                var options = {
                    title: title,
                    options: {
                        body: x,
                        lang: 'es-AR',
                    }
                };
                $("#easyNotify").easyNotify(options);
                var tot = parseInt($("#notificaciones_total").html());
                //$("#notificaciones_lista").empty();
                $("#notificaciones_lista").append("<li><a href='#' onclick='abrir(this)'><span class='task'>" + title + "</span></a></li>");
                $("#notificaciones_total").html(tot.toString());
                if (tot == 0) {
                    $("#badge_notificaciones").hide('slow');
                }
                else {
                    $("#badge_notificaciones").show('slow');
                }
            }
        };
        $.connection.hub.start().done(function () { console.log("Conectado con signalR..."); });
    };
    AppManager.prototype.desktopNotification = function (message, onclick) {
        var options = {
            title: $("#title").val(),
            options: {
                body: message,
                //icon: myImg,
                lang: 'en-US',
                onClick: onclick
            }
        };
        $("#easyNotify").easyNotify(options);
    };
    AppManager.prototype.currentTab = function () {
        return ($('.ui-tabs-panel:not(.ui-tabs-hide)').parent("li").index());
    };
    AppManager.prototype.currentTabIndex = function () {
        return ($('.ui-tabs-active').index());
    };
    AppManager.prototype.closeCurrentTab = function () {
        this.closeTab($("#tabs li.active").find("a"));
    };
    AppManager.prototype.reloadCurrentTab = function () {
        var def = $.Deferred();
        var url = $("#tabs li.active").find("a").data("url");
        var index = $("#tabs li.active").find("a").data("index");
        $("#tab-" + index).empty().load($("#a-" + index).data("url"), function () { def.resolve(); });
        return def;
    };
    AppManager.prototype.setActiveTab = function (el) {
        var def = $.Deferred();
        var load = $(el).data("load");
        //console.log("load: " + load);
        var cache = $(el).data("cache");
        var cargar = false;
        this.tab_previo.push($("ul.nav-tabs li.active").find("a").data("index"));
        $('ul.nav-tabs li.active').removeClass('active');
        if ($(el).prop("tagName") != "LI") {
            $(el).parent('li').addClass('active');
        }
        else {
            $(el).addClass('active');
        }
        //actualizar la referencia al form en el Controlador Javascript en el caso que la página esté cacheada
        if ($(el).data("cache") == "false") {
            this.Bloquear();
        }
        else {
            if ($(el).data("load") == "false") {
                this.Desbloquear();
                $(el).data("load", "true");
            }
        }
        var index = $(el).data("index");
        if (!load) {
            cargar = true;
            $(el).data("load", true);
        }
        else {
            if (!cache) {
                cargar = true;
            }
        }
        if (cargar) {
            $("#tab-" + index).load($("#a-" + index).data("url"), function () { def.resolve(); });
        }
        this.showTab($(el).data("index"));
        return (def.promise());
    };
    AppManager.prototype.closeTab = function (el) {
        //$($(el).closest("li").find("a").data("href")).remove();
        //$(el).closest("li").remove();
        ////(this.tab_previo >= 0) ? this.setActiveTab($("#a-" + this.tab_previo)) : this.setActiveTab($("#a-0")); 
        //this.setActiveTab($("#a-" + this.tab_previo.pop()));
        //this.tab_count--;
        this.tabs.cerrarTab(el);
    };
    AppManager.prototype.mensajex = function () {
        alert("mensaje de prueba desde app");
    };
    AppManager.prototype.inicializarTab = function () {
        var primero = true;
        this.tab.attr("href", $.cookie("vista"));
        $("a[data-toggle=tab]").click(function () {
            this.setActiveTab(this);
        });
        //var that = this;
        this.tabs.iniciarTab($.cookie("tabs"));
        //if ($.cookie("tabs") != "") {
        //    var arr = JSON.parse($.cookie("tabs"));
        //    $.each(arr, function (i, item) {
        //        //that.createTab(item.label, item.url, item.close, item.cache, false);
        //        if (primero) {
        //            that.tab_count = 0;
        //            primero = false;
        //        }
        //        that.createTab(item.label, item.url, item.cache, false, false);
        //    });
        //}
        //// alert("desde inicializar tab:"+ $("#tabs ul > li:eq(0)").find("a").attr("href"));
        //this.setActiveTab($("#tabs ul > li:eq(0)").find("a"));
    };
    AppManager.prototype.showTab = function (index) {
        //oculta todos los contenedores
        $("div[data-type=contenedor]").hide();
        //muestra el indice seleccionado
        $($("#tabs ul > li:eq(" + index + ")").find("a").data("href")).show();
    };
    AppManager.prototype.irATab = function (index, load) {
        //var def = $.Deferred();
        //this.setActiveTab($("#tabs ul > li:eq(" + index + ")").find("a"));
        //if (load != null) {
        //    if (load) {
        //        $("#tab-" + index).load($("#a-" + index).data("url"), function () { def.resolve(); });
        //    }
        //} else
        //    def.resolve();
        //return def;
        this.tabs.irATab(index, load);
    };
    AppManager.prototype.createTab = function (titulo, url, cache, close, redirect, load) {
        var df = $.Deferred();
        var i = new ItemMenu();
        i.label = titulo;
        i.cache = cache;
        i.close = close;
        i.url = url;
        return this.tabs.crearTab(i, redirect, load);
        //var cerrar = (close) ? "<span class='ui-icon ui-icon-close' onclick='app.closeTab(this);'>Cerrar</span>" : "";
        //$("#tabs > ul").append("<li class='ui-state-default ui-corner-top'><a data-toggle='tab' data-index='" + this.tab_count + "' data-load='false' data-cache='" + cache + "' data-toggle='tab' href='' data-url='" + url + "' data-href='#tab-" + this.tab_count + "' id='a-" + this.tab_count + "' onclick='app.setActiveTab(this)'>" + titulo + "</a>" + cerrar + "</li>");
        //$("#tabs").append("<div id='tab-" + this.tab_count + "' data-type='contenedor' class='ui-tabs-panel ui-widget-content ui-corner-bottom' style='display:none'></div>");
        //if (redirect) {
        //    $.when(this.setActiveTab($("#a-" + this.tab_count))).done(function () { df.resolve() });
        //}
        //this.tab_count++;
        //return (df.promise());
    };
    AppManager.prototype.existsTab = function (nombre) {
        var existe = false;
        $('#tabs ul li a').each(function (i) {
            if (this.text == nombre) {
                existe = true;
            }
        });
        return (existe);
    };
    AppManager.prototype.postCall = function (form, funcok) {
        var that = this;
        form.validate();
        var success = false;
        var retorno = 0;
        if (form.valid()) {
            this.Bloquear();
            $.ajax({
                type: "POST",
                url: form.attr("action"),
                data: form.serialize(),
                success: function (data) {
                    success = data[0];
                    if (data[0]) {
                        that.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                        retorno = data[2];
                        if (funcok != undefined) {
                            funcok;
                        }
                    }
                    else {
                        that.crearNotificacionError("Error", data[1]);
                    }
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    alert("Error al procesar formulario ajax");
                },
                complete: function () {
                    that.Desbloquear();
                }
            }); //end ajax
        }
    };
    AppManager.prototype.listTab = function () {
        this.tab.tabs('select', 0);
    };
    AppManager.prototype.selectTab = function (i) {
        this.tab.tabs('select', i);
        //alert($("#tabs ul li").eq(1).prop("tabindex"));
        this.setActiveTab($("#tabs ul li").eq(i));
    };
    //public closeMe(el) {
    //    this.closeCurrentTab($(el).closest('li').index());
    //    this.listTab();
    //}
    /* Get the rows which are currently selected */
    AppManager.prototype.fnGetSelected = function (oTableLocal) {
        var aReturn = new Array();
        var aTrs = oTableLocal.fnGetNodes();
        for (var i = 0; i < aTrs.length; i++) {
            if ($(aTrs[i]).hasClass('row_selected')) {
                aReturn.push(aTrs[i]);
            }
        }
        return aReturn;
    };
    AppManager.prototype.Bloquear = function (centerY) {
        var el;
        el = this.page_container;
        if (el.height() <= 400) {
            centerY = true;
        }
        el.block({
            message: '<img src="./assets/img/ajax-loading.gif" align="">',
            centerY: centerY != undefined ? centerY : true,
            css: {
                top: '10%',
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
    };
    AppManager.prototype.Desbloquear = function () {
        var el;
        el = this.page_container;
        $(this.page_container).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    };
    AppManager.prototype.crearNotificacionSuccess = function (titulo, mensaje) {
        toastr.success(mensaje, titulo, { showEasing: "swing", showDuration: 1500, hideDuration: 7000, timeOut: 1500, positionClass: "toast-top-right", extendedTimeOut: 1500, hideEasing: "linear", showMethod: "fadeIn" });
    };
    AppManager.prototype.crearNotificacionError = function (titulo, mensaje) {
        toastr.error(mensaje, titulo, { showEasing: "swing", showDuration: 1500, hideDuration: 80000, timeOut: 1500, positionClass: "toast-top-right", extendedTimeOut: 1500, hideEasing: "linear", showMethod: "fadeIn" });
    };
    AppManager.prototype.crearNotificacionWarning = function (titulo, mensaje) {
        toastr.warning(mensaje, titulo), { showEasing: "swing", showDuration: 1500, hideDuration: 80000, timeOut: 1500, positionClass: "toast-top-right", extendedTimeOut: 1500, hideEasing: "linear", showMethod: "fadeIn" };
    };
    AppManager.prototype.crearNotificacionInfo = function (titulo, mensaje) {
        toastr.info(mensaje, titulo, { showEasing: "swing", showDuration: 1500, hideDuration: 7000, timeOut: 1500, positionClass: "toast-top-right", extendedTimeOut: 1500, hideEasing: "linear", showMethod: "fadeIn" });
    };
    AppManager.prototype.confirmacionSiNo = function (mensaje, func) {
        bootbox.confirm(mensaje, function (result) {
            func(result);
        });
    };
    AppManager.prototype.formatearFecha = function (date) {
        //debugger;
        console.log("fecha: ");
        console.log(date);
        if (date != null) {
            var d;
            var x = date.toString();
            if (x.indexOf("Date") > 0) {
                d = new Date(parseInt(date.substr(6)));
            }
            else
                d = new Date(date);
            var month = '' + (d.getMonth() + 1), day = '' + d.getDate(), year = d.getFullYear();
            if (month.length < 2)
                month = '0' + month;
            if (day.length < 2)
                day = '0' + day;
            return [day, month, year].join('/');
        }
        else
            return "";
    };
    AppManager.prototype.formatearFechaYHora = function (date) {
        //debugger;
        console.log("fecha: ");
        console.log(date);
        if (date != null) {
            var d;
            var x = date.toString();
            if (x.indexOf("Date") > 0) {
                d = new Date(parseInt(date.substr(6)));
            }
            else
                d = new Date(date);
            var month = '' + (d.getMonth() + 1), day = '' + d.getDate(), year = d.getFullYear(), minutes = d.getMinutes(), hour = d.getHours();
            if (month.length < 2)
                month = '0' + month;
            if (day.length < 2)
                day = '0' + day;
            var fecha = [day, month, year].join('/') + ' ' + (hour < 10 ? '0' + hour : hour) + ":" + (minutes < 10 ? '0' + minutes : minutes);
            return fecha;
        }
        else
            return "";
    };
    AppManager.prototype.setDecimal = function (numero) {
        var res = parseFloat(numero.replace(",", "."));
        if (isNaN(res))
            return 0;
        else
            return res;
    };
    AppManager.prototype.postify = function (value) {
        var result = {};
        var buildResult = function (object, prefix) {
            for (var key in object) {
                var postKey = isFinite(+key)
                    ? (prefix != "" ? prefix : "") + "[" + key + "]"
                    : (prefix != "" ? prefix + "." : "") + key;
                switch (typeof (object[key])) {
                    case "number":
                    case "string":
                    case "boolean":
                        result[postKey] = object[key];
                        break;
                    case "object":
                        if (object[key].toUTCString)
                            result[postKey] = object[key].toUTCString().replace("UTC", "GMT");
                        else {
                            buildResult(object[key], postKey != "" ? postKey : key);
                        }
                }
            }
        };
        buildResult(value, "");
        return result;
    };
    AppManager.prototype.getManager = function (name) {
        return window["o" + name];
    };
    AppManager.prototype.mapByNamePost = function (url, data) {
        var el;
        var def = $.Deferred();
        $.post(url, data).done(function (result) {
            $.each(result, function (key, value) {
                el = $("[name=" + key + "]");
                el.each(function () {
                    if ($(this).is("input")) {
                        $(this).val(value);
                    }
                    else {
                        $(this).html(value);
                    }
                });
            });
            def.resolve();
        });
        return def.promise();
    };
    AppManager.prototype.mapByNameGet = function (url, data) {
        var el;
        $.get(url, data).done(function (result) {
            $.each(result, function (key, value) {
                el = $("[name=" + key + "]");
                el.each(function () {
                    if ($(this).is("input")) {
                        $(this).val(value);
                    }
                    else {
                        $(this).html(value);
                    }
                });
            });
        });
    };
    AppManager.prototype.elementVisible = function (element, valorScroll) {
        //detectar con jQuery si un elemento por su posición es visible en el navegador
        console.log(valorScroll);
        var visible = true;
        var windowTop = $(document).scrollTop();
        var windowBottom = windowTop + window.innerHeight;
        var elementPositionTop = element.offset().top + valorScroll;
        var elementPositionBottom = elementPositionTop + element.height();
        if (elementPositionTop >= windowBottom || elementPositionBottom <= windowTop) {
            visible = false;
        }
        return visible;
    };
    AppManager.prototype.getData = function (url, data) {
        var r;
        var df = $.Deferred();
        $.when($.ajax({
            type: "GET",
            url: url,
            data: data,
            success: function (ret) {
                //obj = ret;
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error al procesar formulario ajax");
            },
            complete: function () {
                //app.Desbloquear();
            }
        })).done(function (response) { df.resolve(response); })
            .fail(function () { df.reject(); });
        return df;
    };
    AppManager.prototype.getAllUrlParams = function (url) {
        // get query string from url (optional) or window
        var queryString = url ? url.split('?')[1] : window.location.search.slice(1);
        // we'll store the parameters here
        var obj = {};
        // if query string exists
        if (queryString) {
            // stuff after # is not part of query string, so get rid of it
            queryString = queryString.split('#')[0];
            // split our query string into its component parts
            var arr = queryString.split('&');
            for (var i = 0; i < arr.length; i++) {
                // separate the keys and the values
                var a = arr[i].split('=');
                // in case params look like: list[]=thing1&list[]=thing2
                var paramNum = undefined;
                var paramName = a[0].replace(/\[\d*\]/, function (v) {
                    paramNum = v.slice(1, -1);
                    return '';
                });
                // set parameter value (use 'true' if empty)
                var paramValue = typeof (a[1]) === 'undefined' ? true : a[1];
                // (optional) keep case consistent
                paramName = paramName.toLowerCase();
                paramValue = paramValue.toLowerCase();
                // if parameter name already exists
                if (obj[paramName]) {
                    // convert value to array (if still string)
                    if (typeof obj[paramName] === 'string') {
                        obj[paramName] = [obj[paramName]];
                    }
                    // if no array index number specified...
                    if (typeof paramNum === 'undefined') {
                        // put the value on the end of the array
                        obj[paramName].push(paramValue);
                    }
                    else {
                        // put the value at that index number
                        obj[paramName][paramNum] = paramValue;
                    }
                }
                else {
                    obj[paramName] = paramValue;
                }
            }
        }
        return obj;
    };
    AppManager.prototype.setValidadorDecimal = function () {
        jQuery.extend(jQuery.validator.methods, {
            decimal: function (value, element) {
                return this.optional(element)
                    || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:[,.]\d+)?$/.test(value);
            }
        });
    };
    return AppManager;
})();
var SyncroBlock = (function () {
    function SyncroBlock(container) {
        var that = this;
        this.container = container;
    }
    SyncroBlock.prototype.Bloquear = function (container) {
        var centerY;
        var el;
        el = (container != null) ? container : this.container;
        if (el.height() <= 400) {
            centerY = true;
        }
        el.block({
            message: '<img src="./assets/img/ajax-loading.gif" align="">',
            centerY: true,
            css: {
                top: '10%',
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
    };
    SyncroBlock.prototype.Desbloquear = function () {
        var el;
        el = this.container;
        $(this.container).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    };
    return SyncroBlock;
})();
;
var SyncroTab = (function () {
    function SyncroTab(id, block) {
        this.id = id;
        this.tab_count = 0;
        this.block = block;
    }
    //jtabs: [{item.label, item.url, item.close, item.cache}, {...} ...]
    SyncroTab.prototype.iniciarTab = function (jtabs) {
        var arr;
        var that = this;
        var primero = true;
        arr = JSON.parse(jtabs);
        $.each(arr, function (i, item) {
            that.crearTab(item, primero);
            primero = false;
        });
        this.activarTab($("#tabs ul > li:eq(0)").find("a"));
    };
    SyncroTab.prototype.reloadCurrent = function () {
        var def = $.Deferred();
        var index = $("#ul li.active").find("a").data("index");
        app.Bloquear();
        $("#tab-" + index).load($("#a-" + index).data("url"), function () { app.Desbloquear(); $(".modal-backdrop").remove(); def.resolve(); });
        return (def.promise());
    };
    //agrega un nuevo tab al final de la lista
    //PENDIENTE: abrir un item de menú en una posición específica
    SyncroTab.prototype.crearTab = function (item, redirect, load) {
        var def = $.Deferred();
        var tabactivo = $("ul.nav-tabs li.active").find("a");
        var padre = (tabactivo.data("index") != null) ? tabactivo.data("index") : "0";
        var that = this;
        //console.log($("ul.nav-tabs li.active").find("a").data("index"));
        var cerrar = (item.close) ? "<span class='ui-icon ui-icon-close' onclick='app.tabs.cerrarTab(this);'>Cerrar</span>" : "";
        $("#tabs > ul").append("<li class='ui-state-default ui-corner-top'><a data-toggle='tab' data-padre='" + padre + "' data-index='" + this.tab_count + "' data-load='false' data-cache='" + item.cache + "' data-toggle='tab' href='' data-url='" + item.url + "' data-href='#tab-" + this.tab_count + "' id='a-" + this.tab_count + "' onclick='app.tabs.activarTab(this)'>" + item.label + "</a>" + cerrar + "</li>");
        $("#tabs").append("<div id='tab-" + this.tab_count + "' data-type='contenedor' class='ui-tabs-panel ui-widget-content ui-corner-bottom' style='display:none'></div>");
        // si tiene que redireccionar al tab creado
        if (redirect) {
            this.block.Bloquear();
            $.when(this.activarTab($("#a-" + this.tab_count))).done(function () { that.block.Desbloquear(); def.resolve(); });
        }
        else {
            if (load) {
                //var index = $("#a-" + this.tab_count);
                var index = $("#a-" + this.tab_count).data("index");
                $("#tab-" + index).load($("#a-" + index).data("url"), function () { def.resolve(); });
                $("#a-" + this.tab_count).data("load", "true");
            }
        }
        this.tab_count++;
        return (def.promise());
    };
    // activa y muestra un tab ya creado
    SyncroTab.prototype.activarTab = function (el) {
        var def = $.Deferred();
        var load = $(el).data("load");
        //console.log("load: " + load);
        var cache = $(el).data("cache");
        var cargar = false;
        $('ul.nav-tabs li.active').removeClass('active');
        if ($(el).prop("tagName") != "LI") {
            $(el).parent('li').addClass('active');
        }
        else {
            $(el).addClass('active');
        }
        //actualizar la referencia al form en el Controlador Javascript en el caso que la página esté cacheada
        if ($(el).data("cache") == "false") {
            this.block.Bloquear();
        }
        else {
            if ($(el).data("load") == "false") {
                this.block.Desbloquear();
                $(el).data("load", "true");
            }
        }
        var index = $(el).data("index");
        if (!load) {
            cargar = true;
            $(el).data("load", true);
        }
        else {
            if (!cache) {
                cargar = true;
            }
        }
        if (cargar) {
            var a = $("#tabs li.active").find("a");
            this.block.Bloquear($(a.data("href")));
            $("#tab-" + index).load($("#a-" + index).data("url"), function () { def.resolve(); });
            app.current_view = $("#a-" + index).data("url");
            this.block.Desbloquear();
        }
        this.mostrarTab($(el).data("index"));
        return (def.promise());
    };
    SyncroTab.prototype.refrescarActual = function (url) {
        var self = this;
        var a = $("#tabs li.active").find("a");
        this.block.Bloquear($(a.data("href")));
        $(a.data("href")).load(url, function () {
            self.block.Desbloquear();
        });
    };
    SyncroTab.prototype.mostrarTab = function (index) {
        //oculta todos los contenedores
        $("div[data-type=contenedor]").hide();
        //muestra el indice seleccionado
        $($("#a-" + index).data("href")).show();
    };
    SyncroTab.prototype.cerrarTab = function (el) {
        if (!(el instanceof jQuery))
            el = $(el);
        var padre = el.closest("li").find("a").data("padre");
        if (padre != null) {
            $(el.closest("li").find("a").data("href")).remove();
            el.closest("li").remove();
            if (padre > 0) {
                this.activarTab($("#a-" + padre));
            }
            else {
                this.activarTab($("#a-0"));
            }
        }
    };
    SyncroTab.prototype._ocultar = function (el) {
        if (!(el instanceof jQuery))
            el = $(el);
        var padre = el.closest("li").find("a").data("padre");
        if (padre != null) {
            $(el.closest("li").find("a").data("href")).hide();
            el.closest("li").hide();
            if (padre > 0) {
                this.activarTab($("#a-" + padre));
            }
            else {
                this.activarTab($("#a-0"));
            }
        }
    };
    SyncroTab.prototype._mostrar = function (el) {
        if (!(el instanceof jQuery))
            el = $(el);
        var padre = el.closest("li").find("a").data("padre");
        if (padre != null) {
            $(el.closest("li").find("a").data("href")).show();
            el.closest("li").show();
        }
    };
    SyncroTab.prototype.mostrar = function (index) {
        this._mostrar($("#tabs ul li").eq(index).find("a"));
    };
    SyncroTab.prototype.ocultar = function (index) {
        this._ocultar($("#tabs ul li").eq(index).find("a"));
    };
    SyncroTab.prototype.cerrarTabIndex = function (index) {
        this.cerrarTab($("#tabs ul li").eq(index).find("a"));
    };
    SyncroTab.prototype.irATab = function (index, load) {
        var def = $.Deferred();
        this.activarTab($("#tabs ul > li:eq(" + index + ")").find("a"));
        if (load != null) {
            if (load) {
                $("#tab-" + index).load($("#a-" + index).data("url"), function () { def.resolve(); });
            }
        }
        else
            def.resolve();
        return def;
    };
    return SyncroTab;
})();
;
var ItemMenu = (function () {
    function ItemMenu() {
    }
    return ItemMenu;
})();
;
//$(document).ready(function () {
//});
var FormatEditor = (function () {
    function FormatEditor(o, model, id) {
        console.log("id de la imputacion: " + id);
        var self = this;
        this.loaded = false;
        self.model = model;
        this.id_imputacion = id;
        this.o = { expediente: o };
        this.o_original = { expediente: o };
        //if (id) {
        //    Enumerable.From(o.imputaciones).Delete(function (x) { return parseInt(x.id) != parseInt(self.id_imputacion) });
        //}
    }
    FormatEditor.prototype.test = function () {
        var self = this;
        console.log(this.o);
        //this.o = this.o_original;
        // Obtener el modelo de escrito
        $.get("Expedientes/ModelosEscritoADM/getText/?id=" + self.model, null, function (data) {
            self.html = data;
            self.loaded = true;
            $("#parsered").empty();
            $("#parsered").append($.parseHTML(self.html));
            console.log("Id de imputacion generada: " + self.id_imputacion);
            // Detalle de partidas imputadas
            if ($("#parsered").find("table[data-tipo=imputacion]").length) {
                var tr = $("#parsered").find("table[data-tipo=imputacion]").find("tbody").html();
                $("#parsered").find("table[data-tipo=imputacion]").find("tbody").empty();
                //Enumerable.From(self.o.expediente.imputaciones).Delete(function (x) { return parseInt(x.id) != parseInt(self.id_imputacion) });
                var imputacion = Enumerable.From(self.o.expediente.imputaciones).Where(function (x) { return x.id == self.id_imputacion; }).FirstOrDefault(null);
                console.log(self.o.expediente);
                $.each(imputacion.detalle, function (index, value) {
                    var r = tr.replace("{{expediente.imputacion.partida}}", value.partida).replace("{{expediente.imputacion.importe}}", value.importe);
                    $("#parsered").find("table[data-tipo=imputacion]").find("tbody").append(r);
                });
            }
            // Detalle de facturas imputadas
            if ($("#parsered").find("table[data-tipo=factura]").length) {
                var body = $("#parsered").find("table[data-tipo=factura]").find("tbody").html();
                var tr_proveedor = $("#parsered").find("tr[data-tipo=proveedor]").wrap('<p/>').parent().html();
                var tr_detalle = $("#parsered").find("tr[data-tipo=detalle]").wrap('<p/>').parent().html();
                var tr_total = $("#parsered").find("tr[data-tipo=factura][data-action=total]").wrap('<p/>').parent().html();
                ;
                $("#parsered").find("table[data-tipo=factura]").find("tbody").empty();
                var imputacion = Enumerable.From(self.o.expediente.imputaciones).Where(function (x) { return x.id == self.id_imputacion; }).FirstOrDefault(null);
                var sum_importe = 0.0;
                var i = 0;
                if (imputacion.facturas) {
                    var grupo = Enumerable.From(imputacion.facturas).FirstOrDefault(null).nombre_proveedor;
                    $.each(imputacion.facturas, function (index, value) {
                        if (grupo != value.nombre_proveedor) {
                            var t = tr_total.replace("{{sum(expediente.imputacion.facturas.importe)}}", sum_importe.toFixed(2));
                            $("#parsered").find("table[data-tipo=factura]").find("tbody").append(t);
                            sum_importe = 0.0;
                        }
                        var proveedor = tr_proveedor.replace("{{expediente.imputacion.facturas.nombre_proveedor}}", value.nombre_proveedor).replace("{{expediente.imputacion.facturas.importe}}", value.importe).replace("{{expediente.imputacion.facturas.numero}}", value.numero).replace("{{expediente.imputacion.facturas.concepto}}", value.concepto);
                        var detalle = tr_detalle.replace("{{expediente.imputacion.facturas.nombre_proveedor}}", value.nombre_proveedor).replace("{{expediente.imputacion.facturas.importe}}", value.importe).replace("{{expediente.imputacion.facturas.numero}}", value.numero).replace("{{expediente.imputacion.facturas.concepto}}", value.concepto);
                        sum_importe += parseFloat(value.importe);
                        grupo = value.nombre_proveedor;
                        $("#parsered").find("table[data-tipo=factura]").find("tbody").append(proveedor).append(detalle);
                    });
                    var t = tr_total.replace("{{sum(expediente.imputacion.facturas.importe)}}", sum_importe.toFixed(2));
                    $("#parsered").find("table[data-tipo=factura]").find("tbody").append(t);
                }
            }
            //var extract = $("#parsered").html().match(/{{(.*)}}/g);
            var pattern = /\{{(.*?)\}}/g;
            var match;
            var matches = [];
            while ((match = pattern.exec($("#parsered").html())) != null) {
                matches.push(match[1]);
            }
            matches.forEach(function (value, index) {
                $("#parsered").html($("#parsered").html().replace("{{" + value + "}}", self.byString(self.o, value)));
                //console.log("{{"+value+"}}");
                //console.log(value);
                //console.log(value.replace("{{","").replace("}}",""));
                //console.log(self.byString(self.o, value));
            });
            self.html = $("#parsered").html().toString();
            //console.log("Expediente: " + self.o.id);
            // $.post("Expedientes/ActuacionesADM/GuardarAutomatica", {texto:self.html, expediente: self.o.expediente.id, tipo:3, requierecargo:false, descripcion: "Nota de Afectación"}, function(data) {
            //     if (data[0]) {
            //         app.crearNotificacionSuccess("Resultado",data[1]);
            //         app.reloadCurrentTab();
            //     } else {
            //         app.crearNotificacionError("Resultado",data[1]);
            //     }
            // });
            // self.print();
            tinyMCE.activeEditor.setContent(self.html);
        });
        //console.log(this.byString(this.o, "expediente.fecha"));
    };
    FormatEditor.prototype.print = function () {
        var printWindow = window.open();
        printWindow.document.open('text/html');
        printWindow.document.write(this.html);
        printWindow.document.close();
        printWindow.focus();
        printWindow.print();
        printWindow.close();
    };
    FormatEditor.prototype.parse = function () {
        return "";
    };
    FormatEditor.prototype.byString = function (o, s) {
        s = s.replace(/\[(\w+)\]/g, '.$1'); // convert indexes to properties
        s = s.replace(/^\./, ''); // strip a leading dot
        var a = s.split('.');
        for (var i = 0, n = a.length; i < n; ++i) {
            var k = a[i];
            if (k in o) {
                o = o[k];
            }
            else {
                return;
            }
        }
        return o.toString();
    };
    return FormatEditor;
})();
var Resultado = (function () {
    function Resultado() {
        this.estado = false;
        this.mensaje = "";
        this.excepcion = "";
        this.id = 0;
        this.anexos = {};
    }
    Resultado.prototype.Mensaje = function (value) {
        this.mensaje = value;
    };
    return Resultado;
})();
var ResultadoApp = (function () {
    function ResultadoApp() {
        this.state = false;
        this.message = "";
        this.exception = "";
        this.id = 0;
        this.anexos = {};
    }
    ResultadoApp.prototype.Mensaje = function (value) {
        this.message = value;
    };
    return ResultadoApp;
})();
jQuery.fn.serializeObject = function () {
    var arrayData, objectData;
    arrayData = this.serializeArray();
    objectData = {};
    $.each(arrayData, function () {
        var value;
        if (this.value != null) {
            value = this.value;
        }
        else {
            value = '';
        }
        if (objectData[this.name] != null) {
            if (!objectData[this.name].push) {
                objectData[this.name] = [objectData[this.name]];
            }
            objectData[this.name].push(value);
        }
        else {
            objectData[this.name] = value;
        }
    });
    return objectData;
};
var Global = (function () {
    function Global() {
    }
    return Global;
})();
var app = new AppManager();
