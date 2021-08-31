/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
var SyncroModal = /** @class */ (function () {
    function SyncroModal(el) {
        this.modal = el;
    }
    SyncroModal.prototype.getBody = function () {
        return this.modal.find(".modal-body").first();
    };
    SyncroModal.prototype.loadAjax = function (url) {
        app.Bloquear();
        var d = $.Deferred();
        this.getBody().empty().load(url, function () { app.Desbloquear(); d.resolve(); });
        return d.promise();
    };
    SyncroModal.prototype.cerrar = function () {
        this.modal.modal('hide');
    };
    SyncroModal.prototype.mostrar = function () {
        this.modal.modal('show');
    };
    SyncroModal.prototype.setearTitulo = function (titulo) {
        this.modal.find(".modal-title").first().text(titulo);
    };
    SyncroModal.prototype.cargar = function (titulo, url) {
        this.setearTitulo(titulo);
        this.mostrar();
        return this.loadAjax(url);
    };
    return SyncroModal;
}());
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
var AppManager = /** @class */ (function () {
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
            "positionClass": "toast-bottom-full-width",
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
            yearRange: '1900:2020'
        };
        $.datepicker.setDefaults(pickerOpts);
        $.datepicker.setDefaults($.datepicker.regional["es-AR"]);
        //this.controlador = new ControladoresManager();
        this.initSignalR();
    }
    AppManager.prototype.initSignalR = function () {
        var self = this;
        this.hub = $.connection.serviciosHub;
        $.connection.hub.logging = true;
        self.hub.client.recibirMensaje = function (x) {
            alert(x);
        };
        $.connection.hub.start().done(function () { console.log("Conectado con signalR..."); });
        ;
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
            //console.log("se carga desde tab");
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
        toastr.warning(mensaje, titulo), { showEasing: "swing", showDuration: "1500", hideDuration: "1500", timeOut: "1500", positionClass: "toast-top-right", extendedTimeOut: "1500", hideEasing: "linear", showMethod: "fadeIn" };
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
}());
var SyncroBlock = /** @class */ (function () {
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
}());
;
var SyncroTab = /** @class */ (function () {
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
    /**
     * Recarga una determinada vista en el tab activo
     *
     * @param url Path del controlador con los parametros que requiera la acción (Ej. "Controlador/Accion?idAccion=x")
     */
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
                //console.log("padre > 0");
            }
            else {
                this.activarTab($("#a-0"));
                //console.log("padre <= 0");
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
                //console.log("padre > 0");
            }
            else {
                this.activarTab($("#a-0"));
                //console.log("padre <= 0");
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
}());
;
var ItemMenu = /** @class */ (function () {
    function ItemMenu() {
    }
    return ItemMenu;
}());
;
//$(document).ready(function () {
//});
var FormatEditor = /** @class */ (function () {
    function FormatEditor(o, model, id) {
        var self = this;
        this.loaded = false;
        self.model = model;
        this.id_imputacion = id;
        this.o = { expediente: o };
    }
    FormatEditor.prototype.test = function () {
        var self = this;
        console.log(this.o);
        // Obtener el modelo de escrito
        $.get("Expedientes/ModelosEscritoADM/getText/?id=" + self.model, null, function (data) {
            self.html = data;
            self.loaded = true;
            $("#parsered").empty();
            $("#parsered").append($.parseHTML(self.html));
            // Detalle de partidas imputadas
            if ($("#parsered").find("table[data-tipo=imputacion]").length) {
                var tr = $("#parsered").find("table[data-tipo=imputacion]").find("tbody").html();
                $("#parsered").find("table[data-tipo=imputacion]").find("tbody").empty();
                var imputacion = Enumerable.From(self.o.expediente.imputaciones).Where(function (x) { return x.id == self.id_imputacion; }).FirstOrDefault(null);
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
                console.log("{{" + value + "}}");
                console.log(value);
                //console.log(value.replace("{{","").replace("}}",""));
                console.log(self.byString(self.o, value));
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
}());
var Resultado = /** @class */ (function () {
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
}());
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
var Global = /** @class */ (function () {
    function Global() {
    }
    return Global;
}());
var app = new AppManager();
/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
var SyncroTable = /** @class */ (function () {
    function SyncroTable(el, noeditable) {
        var that = this;
        this.t = el;
        this.cols = [];
        this.ops = [];
        this.cargar = this.t.data("cargar");
        this.url = this.t.data("url");
        this.editable = this.t.data("editable");
        this.Id = this.t.attr("id");
        this.aSource = [];
        this.id = 0;
        // console.log("cargar la tabla: " + this.cargar);
        // columnas 
        this.t.find("thead tr th").each(function () {
            var tc = new TableCol($(this).data("propiedad"), $(this).data("propiedad"), that.editable);
            //console.log($(this).data("visible"));
            if (!$(this).data("visible")) {
                $(this).css("display", "none");
                tc.mostrar = false;
            }
            if (noeditable != null) {
                if (noeditable.indexOf(tc.propiedad) >= 0)
                    tc.editable = false;
            }
            that.cols.push(tc);
        });
        if (this.cargar) {
            this.refrescar();
        }
    }
    SyncroTable.prototype.limpiar = function () {
        this.t.find("tbody").empty();
    };
    SyncroTable.prototype.setearSeleccionable = function (sel) {
        var that = this;
        this.seleccionable = sel;
        this.t.find("tbody tr td").click(function () {
            //that.id = $(this).closest("tr").data("id");
            that.id = +$(this).closest("tr").find("td:eq(0)").text();
            that.index = $(this).closest("tr").index();
            that.t.find("tbody tr td").each(function () {
                $(this).removeClass("Seleccionado");
            });
            $(this).closest("tr").find("td").addClass("Seleccionado");
        });
    };
    SyncroTable.prototype.agregarOperacion = function (display, func) {
        var op = new ColOp();
        op.name = display;
        op.callback = func;
        this.ops.push(op);
    };
    SyncroTable.prototype.setearEditable = function (propiedad, editable, source) {
        this.cols.forEach(function (c) {
            if (c.propiedad == propiedad) {
                c.editable = editable;
                if (source != null) {
                    c.source = source;
                    c.tipo = "select";
                }
            }
        });
    };
    SyncroTable.prototype.fromArray = function (s) {
        var that = this;
        var str = "";
        //clean table
        this.t.find("tbody tr").remove();
        this.id = 0;
        s.forEach(function (value, index) {
            str += '<tr>';
            that.cols.forEach(function (c) {
                if (c.mostrar)
                    str += '<td>' + value[c.propiedad] + '</td>';
                else
                    str += '<td style="display:none">' + value[c.propiedad] + '</td>';
            });
            str += '</tr>';
        });
        this.t.append(str);
        if (this.seleccionable)
            this.setearSeleccionable(true);
    };
    SyncroTable.prototype.agregarFila = function (f) {
        var fila = "<tr>";
        f.forEach(function (value, index) {
            fila += "<td>" + value + "</td>";
        });
        fila += "</tr>";
    };
    SyncroTable.prototype.refrescar = function (newurl) {
        var that = this;
        var totrows = 0;
        var row = "<tr>";
        var obj;
        this.url = (newurl != null) ? newurl : this.url;
        this.Bloquear();
        this.id = 0;
        //limpiar la tabla
        this.t.find("tbody tr").remove();
        $.getJSON(this.url, function (data) {
            $.each(data, function (key, val) {
                that.cols.forEach(function (c) {
                    //console.log((c.propiedad.indexOf("Fecha") > -1) ? c.propiedad + " es fecha" : c.propiedad + " no es fecha");
                    var valor = (c.propiedad.indexOf("Fecha") > -1 || c.propiedad.indexOf("Desde") > -1 || c.propiedad.indexOf("Hasta") > -1) ? app.formatearFecha(val[c.propiedad]) : val[c.propiedad];
                    //row += (c.editable) ? "<td><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td>" + valor + "</td>";                
                    if (c.mostrar)
                        row += (c.editable) ? "<td><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td>" + valor + "</td>";
                    else
                        row += (c.editable) ? "<td style='display:none'><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td style='display:none'>" + valor + "</td>";
                });
                totrows++;
                that.t.find("tbody").append("<tr data-id='" + val["Id"] + "'>" + row + "</tr>");
                row = "";
            });
            if (totrows == 0) {
                that.t.find("tbody").append("<tr><td colspan='" + that.cols.length + "'>No se encontraron registros</td></tr>");
            }
            if (that.editable) {
                that.t.find("tbody tr td a").editable({ type: "text" });
            }
            if (that.seleccionable) {
                that.setearSeleccionable(true);
            }
        });
        this.Desbloquear();
    };
    SyncroTable.prototype.refrescarPost = function (data, newurl) {
        var that = this;
        var totrows = 0;
        var row = "<tr>";
        var obj;
        this.url = (newurl != null) ? newurl : this.url;
        this.Bloquear();
        //limpiar la tabla
        this.t.find("tbody tr").remove();
        this.id = 0;
        $.post(this.url, data).done(function (data) {
            $.each(data, function (key, val) {
                that.cols.forEach(function (c) {
                    var valor = (c.propiedad.indexOf("Fecha") > -1) ? app.formatearFecha(val[c.propiedad]) : val[c.propiedad];
                    if (c.mostrar)
                        row += (c.editable) ? "<td><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td>" + valor + "</td>";
                    else
                        row += (c.editable) ? "<td style='display:none'><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td style='display:none'>" + valor + "</td>";
                });
                totrows++;
                that.t.find("tbody").append("<tr data-id='" + val["Id"] + "'>" + row + "</tr>");
                row = "";
            });
            if (totrows == 0) {
                that.t.find("tbody").append("<tr><td colspan='" + that.cols.length + "'>No se encontraron registros</td></tr>");
            }
            if (that.editable) {
                that.t.find("tbody tr td a").editable({ type: "text" });
            }
            if (that.seleccionable) {
                that.setearSeleccionable(true);
            }
        });
        this.Desbloquear();
    };
    SyncroTable.prototype.Bloquear = function () {
        var centerY = false;
        if (this.t.height() <= 400) {
            centerY = true;
        }
        this.t.block({
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
    SyncroTable.prototype.Desbloquear = function () {
        var el;
        el = this.t;
        $(this.t).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    };
    return SyncroTable;
}());
var ColOp = /** @class */ (function () {
    function ColOp() {
    }
    return ColOp;
}());
var TableCol = /** @class */ (function () {
    function TableCol(propiedad, display, editable) {
        this.propiedad = propiedad;
        this.display = display;
        this.mostrar = true;
        this.editable = editable;
        this.tipo = "text";
    }
    return TableCol;
}());
/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
var SyncroUpload = /** @class */ (function () {
    function SyncroUpload(el) {
        var that = this;
        this.e = el;
        this.txtFileName = $("#txt" + this.e.attr("id"));
        $(this.e).fileupload({
            dataType: 'json'
        }).on('fileuploadprogressall', function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress .progress-bar').css('width', progress + '%');
        });
    }
    SyncroUpload.prototype.setOnUploadDone = function (funcion) {
        var that = this;
        $(this.e).fileupload({
            dataType: 'json'
        }).on('fileuploadprogressall', function (es, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress .progress-bar').css('width', progress + '%');
        }).on('fileuploaddone', function (es, data) {
            $.each(data.result.files, function (index, file) {
                that.txtFileName.text(file.Name);
                funcion(index, file);
            });
        });
    };
    SyncroUpload.prototype.Bloquear = function () {
        var centerY = false;
        //var el: JQuery;
        //el = this.page_container;
        if (this.t.height() <= 400) {
            centerY = true;
        }
        this.e.block({
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
    SyncroUpload.prototype.Desbloquear = function () {
        var el;
        el = this.t;
        $(this.t).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    };
    return SyncroUpload;
}());
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ActuacionesADM;
(function (ActuacionesADM) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.ActuacionesADM.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setActuacionesADM = function (dt) {
                var that = this;
                this.ActuacionesADM = dt;
                $("#dtActuacionesADM tbody").click(function (event) {
                    $(that.ActuacionesADM.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ActuacionesADM.fnGetData($(event.target).closest("tr").index())[0];
                    that.ActuacionesADM_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.ActuacionesADM.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = ActuacionesADM.ts || (ActuacionesADM.ts = {}));
})(ActuacionesADM || (ActuacionesADM = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ActuacionesADM;
(function (ActuacionesADM) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.TipoActuacion = $("#TipoActuacion" + hash);
                this.ModeloAplicado = $("#ModelosEscrito" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.Observaciones = $("#Observaciones" + hash);
                this.Texto = $("#Texto" + hash);
                this.RequiereCargo = $("#RequiereCargo" + hash);
                this.SubAmbitoCargo = $("#SubAmbitoCargo" + hash);
                this.Fojas = $("#Fojas" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Expediente = $("#Expediente" + hash);
                this.div_imputaciones = $("#div_imputaciones");
                this.tr_imputacion = $("tr[data-type=tr_imputacion]");
                this.RemoveTinymce();
                tinymce.init({
                    mode: "exact",
                    height: 600,
                    theme: 'modern',
                    language: "es",
                    selector: "#Texto" + hash,
                    valid_elements: '*[*]',
                    valid_children: "+body[style], +style[type]",
                    //elements: "Contenido" + hash,                
                    plugins: [
                        'advlist autolink lists link image charmap print preview hr anchor pagebreak',
                        'searchreplace wordcount visualblocks visualchars code fullscreen',
                        'insertdatetime media nonbreaking save table contextmenu directionality',
                        'emoticons template paste textcolor colorpicker textpattern imagetools',
                        "responsivefilemanager customtemplate propiedades"
                    ],
                    content_css: [
                        //'//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
                        '/Scripts/a4.css'
                    ],
                    toolbar1: "responsivefilemanager insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | variables",
                    toolbar2: 'print preview media | forecolor backcolor emoticons | sizeselect | fontselect  fontsizeselect',
                    external_filemanager_path: "/filemanager/",
                    templates: [
                        { title: 'A4', content: '<body class="document" ><div class="page" contenteditable = "true" ></div></body>' },
                        { title: 'Test template 2', content: 'Test 2' }
                    ],
                    contextmenu: "link image inserttable | cell row column deletetable customtemplate propiedades",
                    //valid_elements: "a[onclick|style],strong/b,div,br,link,img",
                    filemanager_title: "Responsive Filemanager",
                    external_plugins: { "filemanager": "/filemanager/plugin.min.js" },
                    mentions: {
                        source: [
                            { name: 'Valor 1' },
                            { name: 'Valor 2' },
                            { name: 'Valor 3' },
                            { name: 'Valor4 ' }
                        ]
                    },
                    setup: function (editor) {
                        editor.addMenuItem('example', {
                            text: 'Abrir Word',
                            context: 'file',
                            onclick: function () {
                                app.modal.cargar("prueba", "/expedientes/ModelosEscritoADM/files");
                            }
                        });
                        editor.addMenuItem('paper', {
                            text: 'Papel',
                            context: 'format',
                            menu: [
                                {
                                    text: 'A4',
                                    onclick: function () {
                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                    }
                                },
                                {
                                    text: 'Legal',
                                    onclick: function () {
                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Fecha_Expediente]</a>');
                                    }
                                }
                            ]
                        });
                        editor.addMenuItem('orientation', {
                            text: 'Orientaci�n',
                            context: 'format',
                            menu: [
                                {
                                    text: 'Vertical',
                                    onclick: function () {
                                        //tinymce.dom.DomQuery("link[data-mce-href]").remove();
                                        //editor.dom.loadCSS("/scripts/a4l.css");
                                    }
                                },
                                {
                                    text: 'Horizontal',
                                    onclick: function () {
                                        editor.formatter.register('div.page', {
                                            inline: 'div',
                                            styles: { color: '#ff0000' }
                                        });
                                        editor.formatter.apply('div.page');
                                    }
                                }
                            ]
                        });
                        editor.addButton('variables', {
                            text: 'Variables',
                            type: 'menubutton',
                            icon: false,
                            menu: [
                                {
                                    text: 'Expedientes',
                                    menu: [
                                        {
                                            text: 'N&uacute;mero',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: 'Fecha',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Fecha_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: 'Car&aacute;tula',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Caratula_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: 'Iniciador',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Iniciador_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: 'Imputado',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Imputado_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: "Detalle Imputaci&oacute;n",
                                            menu: [
                                                {
                                                    text: 'Partida',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Division',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Importe',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                            ]
                                        },
                                        {
                                            text: "Detalle Factura",
                                            menu: [
                                                {
                                                    text: 'N&uacute;mero',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Proveedor',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Importe',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                            ]
                                        }
                                    ]
                                },
                                {
                                    text: 'Agregar Campo',
                                    onclick: function () {
                                        bootbox.prompt("Ingrese el nombre del campo", function (result) {
                                            editor.insertContent('<a href="#" data-type="text" data-pk="1" data-title="' + result + '">' + result + '</a>');
                                        });
                                    }
                                }
                            ]
                        });
                    }
                });
                //Establece el foco
                this.TipoActuacion.focus();
            }
            Crear.prototype.RemoveTinymce = function () {
                //if (tinymce.editors.length > 0) {
                //    for (i = 0; i < tinymce.editors.length; i++) {
                //        tinymce.editors[i].remove();
                //    }
                //}
            };
            Crear.prototype.limpiar = function () {
                this.TipoActuacion.val('').trigger("liszt:updated");
                this.ModeloAplicado.val('').trigger("liszt:updated");
                this.Descripcion.val("");
                this.Fecha.val("");
                this.Observaciones.val("");
                this.Texto.val("");
                this.RequiereCargo.removeAttr('checked');
                this.SubAmbitoCargo.val('').trigger("liszt:updated");
                this.Expediente.val("");
                this.Fojas.val("");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = ActuacionesADM.ts || (ActuacionesADM.ts = {}));
})(ActuacionesADM || (ActuacionesADM = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ActuacionesADM;
(function (ActuacionesADM) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Expediente = $("#Expediente" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.Observaciones = $("#Observaciones" + hash);
                this.FechaRecepcion = $("#FechaRecepcion" + hash);
                this.UsuarioRecepcion = $("#UsuarioRecepcion" + hash);
                this.OficinaOrigen = $("#OficinaOrigen" + hash);
                this.SubAmbitoOrigen = $("#SubAmbitoOrigen" + hash);
                this.Anulado = $("#Anulado" + hash);
                this.FechaAnulado = $("#FechaAnulado" + hash);
                this.UsuarioAnulacion = $("#UsuarioAnulacion" + hash);
                this.MotivoAnulacion = $("#MotivoAnulacion" + hash);
                this.Texto = $("#Texto" + hash);
                this.FechaPublicacion = $("#FechaPublicacion" + hash);
                this.UsuarioPublica = $("#UsuarioPublica" + hash);
                this.FechaUltimaModificacion = $("#FechaUltimaModificacion" + hash);
                this.TipoActuacion = $("#TipoActuacion" + hash);
                this.ModeloAplicado = $("#ModeloAplicado" + hash);
                this.Firmante1 = $("#Firmante1" + hash);
                this.FechaFirmante1 = $("#FechaFirmante1" + hash);
                this.Firmante2 = $("#Firmante2" + hash);
                this.FechaFirmante2 = $("#FechaFirmante2" + hash);
                this.Firmante3 = $("#Firmante3" + hash);
                this.FechaFirmante3 = $("#FechaFirmante3" + hash);
                this.Firmante4 = $("#Firmante4" + hash);
                this.FechaFirmante4 = $("#FechaFirmante4" + hash);
                this.Firmante5 = $("#Firmante5" + hash);
                this.FechaFirmante5 = $("#FechaFirmante5" + hash);
                this.RequiereCargo = $("#RequiereCargo" + hash);
                this.SubAmbitoCargo = $("#SubAmbitoCargo" + hash);
                this.FechaCargo = $("#FechaCargo" + hash);
                this.UsuarioCargo = $("#UsuarioCargo" + hash);
                this.Fojas = $("#Fojas" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Expediente.val('').trigger("liszt:updated");
                this.Descripcion.val("");
                this.Fecha.val("");
                this.UsuarioAlta.val("");
                this.Observaciones.val("");
                this.FechaRecepcion.val("");
                this.UsuarioRecepcion.val('').trigger("liszt:updated");
                this.OficinaOrigen.val('').trigger("liszt:updated");
                this.SubAmbitoOrigen.val('').trigger("liszt:updated");
                this.Anulado.removeAttr('checked');
                this.FechaAnulado.val("");
                this.UsuarioAnulacion.val('').trigger("liszt:updated");
                this.MotivoAnulacion.val("");
                this.Texto.val("");
                this.FechaPublicacion.val("");
                this.UsuarioPublica.val('').trigger("liszt:updated");
                this.FechaUltimaModificacion.val("");
                this.TipoActuacion.val('').trigger("liszt:updated");
                this.ModeloAplicado.val('').trigger("liszt:updated");
                this.Firmante1.val('').trigger("liszt:updated");
                this.FechaFirmante1.val("");
                this.Firmante2.val('').trigger("liszt:updated");
                this.FechaFirmante2.val("");
                this.Firmante3.val('').trigger("liszt:updated");
                this.FechaFirmante3.val("");
                this.Firmante4.val('').trigger("liszt:updated");
                this.FechaFirmante4.val("");
                this.Firmante5.val('').trigger("liszt:updated");
                this.FechaFirmante5.val("");
                this.RequiereCargo.removeAttr('checked');
                this.SubAmbitoCargo.val('').trigger("liszt:updated");
                this.FechaCargo.val("");
                this.UsuarioCargo.val('').trigger("liszt:updated");
                this.Fojas.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = ActuacionesADM.ts || (ActuacionesADM.ts = {}));
})(ActuacionesADM || (ActuacionesADM = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var ActuacionesADM;
(function (ActuacionesADM) {
    var ts;
    (function (ts) {
        var ActuacionesADMManager = /** @class */ (function () {
            function ActuacionesADMManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            ActuacionesADMManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ActuacionesADMManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.ModeloAplicado.change(function (e) {
                    $.get("Expedientes/ModelosEscritoadm/gettext/?id=" + v.ModeloAplicado.val(), null, function (data) {
                        tinyMCE.activeEditor.setContent(data);
                    });
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Resultado", resultado).done(function () {
                        var id = resultado.id;
                        if (resultado.estado) {
                            app.getData("Expedientes/Expedientesadm/getdata", { id: v.Expediente.val() }).then(function (e) {
                                var expediente = e;
                                var editor = new FormatEditor(that.ViewCrear.Expediente.val(), parseInt(v.ModeloAplicado.val()), id);
                                editor.test();
                                app.modal.cerrar();
                            });
                        }
                    });
                });
                v.tr_imputacion.click(function (e) {
                    var tr = $(this);
                    app.getData("Expedientes/Expedientesadm/getdata", { id: v.Expediente.val() }).then(function (e) {
                        var expediente = e;
                        var id = tr.data("id");
                        console.log("Id de imputacion generada: " + id);
                        var editor = new FormatEditor(expediente, parseInt(v.ModeloAplicado.val()), id);
                        editor.test();
                        //app.modal.cerrar();   
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            ActuacionesADMManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Modificar título").done(function () {
                    });
                });
            };
            //--- Función editar de Datatable ActuacionesADM
            ActuacionesADMManager.prototype.editar_dtActuacionesADM = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "ActuacionesADM/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable ActuacionesADM
            ActuacionesADMManager.prototype.eliminar_dtActuacionesADM = function () {
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("ActuacionesADM/Eliminar", { id: id }, resultado);
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ActuacionesADMManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            ActuacionesADMManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            ActuacionesADMManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                resultado.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return ActuacionesADMManager;
        }()); //JS	
        ts.ActuacionesADMManager = ActuacionesADMManager;
    })(ts = ActuacionesADM.ts || (ActuacionesADM.ts = {}));
})(ActuacionesADM || (ActuacionesADM = {}));
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var DivisionesExtraPresupuestarias;
(function (DivisionesExtraPresupuestarias) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Nombre = $("#Nombre" + hash);
                this.CodigoCESIDA = $("#CodigoCESIDA" + hash);
                this.PartidaPresupuestaria = $("#PartidaPresupuestaria" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Nombre.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Nombre.val("");
                this.CodigoCESIDA.val("");
                this.PartidaPresupuestaria.val('').trigger("liszt:updated");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = DivisionesExtraPresupuestarias.ts || (DivisionesExtraPresupuestarias.ts = {}));
})(DivisionesExtraPresupuestarias || (DivisionesExtraPresupuestarias = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var PartidasPresupuestarias;
(function (PartidasPresupuestarias) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Modal = new SyncroModal($("#MainModal"));
                this.Nuevo = $("#Nuevo" + hash);
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.PartidasPresupuestarias.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setPartidasPresupuestarias = function (dt) {
                var that = this;
                this.PartidasPresupuestarias = dt;
                $("#dtPartidasPresupuestarias tbody").click(function (event) {
                    $(that.PartidasPresupuestarias.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.PartidasPresupuestarias.fnGetData($(event.target).closest("tr").index())[0];
                    that.PartidasPresupuestarias_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.PartidasPresupuestarias.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = PartidasPresupuestarias.ts || (PartidasPresupuestarias.ts = {}));
})(PartidasPresupuestarias || (PartidasPresupuestarias = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var PartidasPresupuestarias;
(function (PartidasPresupuestarias) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.NumeroDePartida = $("#NumeroDePartida" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Mnemo = $("#Mnemo" + hash);
                this.UnidadDeOrganizacion = $("#UnidadDeOrganizacion" + hash);
                this.Prioridad = $("#Prioridad" + hash);
                this.DivisionesExtraPresupuestarias = new SyncroTable($("#DivisionesExtraPresupuestarias" + hash));
                this.AsociarDivision = $("#AsociarDivision" + hash);
                this.adivisiones = [];
                this.Modal = new SyncroModal($("#MainModal"));
                this.NombreDivision = $("#NombrePartida" + hash);
                this.CodigoCesida = $("#CodigoCesida" + hash);
                this.AgregarDivision = $("#AgregarDivision" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.NumeroDePartida.focus();
            }
            Crear.prototype.limpiar = function () {
                this.NumeroDePartida.val("");
                this.Descripcion.val("");
                this.Mnemo.val("");
                this.UnidadDeOrganizacion.val('').trigger("liszt:updated");
                this.Prioridad.removeAttr('checked');
                this.DivisionesExtraPresupuestarias.limpiar();
                this.AsociarDivision.val("");
                this.adivisiones = [];
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = PartidasPresupuestarias.ts || (PartidasPresupuestarias.ts = {}));
})(PartidasPresupuestarias || (PartidasPresupuestarias = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var PartidasPresupuestarias;
(function (PartidasPresupuestarias) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.NumeroDePartida = $("#NumeroDePartida" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Mnemo = $("#Mnemo" + hash);
                this.UnidadDeOrganizacion = $("#UnidadDeOrganizacion" + hash);
                this.Prioridad = $("#Prioridad" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.NumeroDePartida.val("");
                this.Descripcion.val("");
                this.Mnemo.val("");
                this.UnidadDeOrganizacion.val('').trigger("liszt:updated");
                this.Prioridad.removeAttr('checked');
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = PartidasPresupuestarias.ts || (PartidasPresupuestarias.ts = {}));
})(PartidasPresupuestarias || (PartidasPresupuestarias = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var PartidasPresupuestarias;
(function (PartidasPresupuestarias) {
    var ts;
    (function (ts) {
        var PartidasPresupuestariasManager = /** @class */ (function () {
            function PartidasPresupuestariasManager() {
                // Constructor
                console.log("constructor");
            }
            //--- Inicialización de la vista Index
            PartidasPresupuestariasManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
                v.Nuevo.click(function (e) {
                    app.modal.cargar("Nueva Partida Presupuestaria", "/Expedientes/PartidasPresupuestarias/Crear");
                });
            };
            //--- Inicialización de la vista Crear
            PartidasPresupuestariasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.AsociarDivision.click(function (e) {
                    v.Modal.cargar("Asociar División", "/Expedientes/DivisionesExtraPresupuestarias/Crear");
                });
                v.AgregarDivision.click(function (e) {
                    e.preventDefault();
                    $("#detalledivision").append("<tr><td>" + v.NombreDivision.val() + "</td><td>" + v.CodigoCesida.val() + "</td><td><button class='btn btn-xs red' data-type='quitardivision'>quitar</button</td></tr>");
                });
                $("button[data-type=quitardivision]").live("click", function (e) {
                    e.preventDefault();
                    $(this).closest("tr").remove();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    $("#detalledivision").find("tr").each(function (i, value) {
                        var d = new Divisiones();
                        d.Id = $(this).data("id") ? $(this).data("id") : 0;
                        d.Nombre = $(value).find("td:eq(0)").html();
                        d.CodigoCESIDA = $(value).find("td:eq(1)").html();
                        v.adivisiones.push(d);
                    });
                    var data = v.form.serializeObject();
                    data.Divisiones = v.adivisiones;
                    that.ajaxPostURL("/Expedientes/PartidasPresupuestarias/Crear", data, "Guardar Partida", resultado).done(function () {
                        if (resultado.estado)
                            app.modal.cerrar();
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Partida", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewCrear.limpiar();
                        }
                    });
                });
            };
            //--- Inicialización de la vista Editar
            PartidasPresupuestariasManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                    //that.ViewIndex.Modal.cerrar();
                    //that.ViewIndex.PartidasPresupuestarias.fnDraw();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewEditar, "Actualizar Partida", resultado).done(function () {
                        if (resultado.estado) {
                            app.closeCurrentTab();
                            that.ViewIndex.PartidasPresupuestarias.fnDraw();
                        }
                    });
                });
            };
            //--- Función editar de Datatable PartidasPresupuestarias
            PartidasPresupuestariasManager.prototype.editar_dtPartidasPresupuestarias = function () {
                var id = this.ViewIndex.getData(0);
                var numero = this.ViewIndex.getData(1);
                app.modal.cargar("Editar Partida " + numero, "/Expedientes/PartidasPresupuestarias/Editar/" + id);
            };
            //--- Función eliminar de Datatable PartidasPresupuestarias
            PartidasPresupuestariasManager.prototype.eliminar_dtPartidasPresupuestarias = function () {
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("/Expedientes/PartidasPresupuestarias/Eliminar", { id: id }, resultado);
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            PartidasPresupuestariasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            PartidasPresupuestariasManager.prototype.agregarDivision = function (a) {
                this.ViewCrear.adivisiones.push(a);
            };
            PartidasPresupuestariasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    //traditional:true,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            PartidasPresupuestariasManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                resultado.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return PartidasPresupuestariasManager;
        }()); //JS	
        ts.PartidasPresupuestariasManager = PartidasPresupuestariasManager;
        var Divisiones = /** @class */ (function () {
            function Divisiones() {
            }
            return Divisiones;
        }());
        ts.Divisiones = Divisiones;
    })(ts = PartidasPresupuestarias.ts || (PartidasPresupuestarias.ts = {}));
})(PartidasPresupuestarias || (PartidasPresupuestarias = {}));
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var DivisionesExtraPresupuestarias;
(function (DivisionesExtraPresupuestarias) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombre = $("#Nombre" + hash);
                this.CodigoCESIDA = $("#CodigoCESIDA" + hash);
                this.PartidaPresupuestaria = $("#PartidaPresupuestaria" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombre.val("");
                this.CodigoCESIDA.val("");
                this.PartidaPresupuestaria.val('').trigger("liszt:updated");
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = DivisionesExtraPresupuestarias.ts || (DivisionesExtraPresupuestarias.ts = {}));
})(DivisionesExtraPresupuestarias || (DivisionesExtraPresupuestarias = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="../PartidasPresupuestarias/PartidasPresupuestariasManager.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var DivisionesExtraPresupuestarias;
(function (DivisionesExtraPresupuestarias) {
    var ts;
    (function (ts) {
        var DivisionesExtraPresupuestariasManager = /** @class */ (function () {
            function DivisionesExtraPresupuestariasManager() {
                // Constructor
            }
            //--- Inicialización de la vista Crear
            DivisionesExtraPresupuestariasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.getManager("PartidasPresupuestarias").ViewCrear.Modal.cerrar();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    v.form.validate();
                    if (v.form.valid()) {
                        //that.ajaxPost(that.ViewCrear, "Guardar División", resultado).done(function () {
                        //    if (resultado.estado) {
                        var x = app.getManager("PartidasPresupuestarias");
                        var a = new PartidasPresupuestarias.ts.Divisiones();
                        //a.id = resultado.id;
                        a.nombre = v.Nombre.val();
                        a.nuevo = true;
                        a.codigocesida = v.CodigoCESIDA.val();
                        //a.partida = resultado.anexos.partida;
                        x.ViewCrear.adivisiones.push(a);
                        alert(a.nombre);
                        //refrescar la tabla de divisiones.
                        x.ViewCrear.DivisionesExtraPresupuestarias.aSource = x.ViewCrear.adivisiones;
                        x.ViewCrear.DivisionesExtraPresupuestarias.fromArray(x.ViewCrear.adivisiones);
                        x.ViewCrear.Modal.cerrar();
                    }
                    //    }
                    //});
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar División", resultado).done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            DivisionesExtraPresupuestariasManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Modificar título").done(function () {
                    });
                });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            DivisionesExtraPresupuestariasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            DivisionesExtraPresupuestariasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            DivisionesExtraPresupuestariasManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                res.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return DivisionesExtraPresupuestariasManager;
        }()); //JS	
        ts.DivisionesExtraPresupuestariasManager = DivisionesExtraPresupuestariasManager;
    })(ts = DivisionesExtraPresupuestarias.ts || (DivisionesExtraPresupuestarias.ts = {}));
})(DivisionesExtraPresupuestarias || (DivisionesExtraPresupuestarias = {}));
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var EjecucionesPresupuestarias;
(function (EjecucionesPresupuestarias) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Anio = $("#Anio" + hash);
                this.PartidaPresupuestaria = $("#PartidaPresupuestaria" + hash);
                this.EstaBloqueada = $("#EstaBloqueada" + hash);
                this.CreditoActual = $("#CreditoActual" + hash);
                this.CreditoDisponible = $("#CreditoDisponible" + hash);
                this.CreditoHabilitado = $("#CreditoHabilitado" + hash);
                this.MontoPreventiva = $("#MontoPreventiva" + hash);
                this.MontoCompromiso = $("#MontoCompromiso" + hash);
                this.MontoOrdenadoAPagar = $("#MontoOrdenadoAPagar" + hash);
                this.PresupuestoSolicitado = $("#PresupuestoSolicitado" + hash);
                this.Presupuestado = $("#Presupuestado" + hash);
                this.ReestructuraMas = $("#ReestructuraMas" + hash);
                this.ReestructuraMenos = $("#ReestructuraMenos" + hash);
                this.Factibilidad = $("#Factibilidad" + hash);
                this.FactibilidadHabilitada = $("#FactibilidadHabilitada" + hash);
                this.ReservaMas = $("#ReservaMas" + hash);
                this.ReservaMenos = $("#ReservaMenos" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.verEjecucion = $("#VerEjecucionesPresupuestarias" + hash);
                //Establece el foco
                this.Anio.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Anio.val("");
                this.PartidaPresupuestaria.val('').trigger("liszt:updated");
                this.EstaBloqueada.removeAttr('checked');
                this.CreditoActual.val("");
                this.CreditoDisponible.val("");
                this.CreditoHabilitado.val("");
                this.MontoPreventiva.val("");
                this.MontoCompromiso.val("");
                this.MontoOrdenadoAPagar.val("");
                this.PresupuestoSolicitado.val("");
                this.Presupuestado.val("");
                this.ReestructuraMas.val("");
                this.ReestructuraMenos.val("");
                this.Factibilidad.val("");
                this.FactibilidadHabilitada.val("");
                this.ReservaMas.val("");
                this.ReservaMenos.val("");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = EjecucionesPresupuestarias.ts || (EjecucionesPresupuestarias.ts = {}));
})(EjecucionesPresupuestarias || (EjecucionesPresupuestarias = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var EjecucionesPresupuestarias;
(function (EjecucionesPresupuestarias) {
    var ts;
    (function (ts) {
        var CrearAnual = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function CrearAnual(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Anio = $("#Anio" + hash);
                this.Errores = $("#errores");
                this.UnidadDeOrganizacion = $("#UnidadesDeOrganizacionRef" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.verEjecucion = $("#VerEjecucionesPresupuestarias" + hash);
                //Establece el foco
                this.Anio.focus();
            }
            CrearAnual.prototype.limpiar = function () {
                this.Anio.val("");
                this.Resultado.html("");
            };
            CrearAnual.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            CrearAnual.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return CrearAnual;
        }()); //JS
        ts.CrearAnual = CrearAnual;
    })(ts = EjecucionesPresupuestarias.ts || (EjecucionesPresupuestarias.ts = {}));
})(EjecucionesPresupuestarias || (EjecucionesPresupuestarias = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var EjecucionesPresupuestarias;
(function (EjecucionesPresupuestarias) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Anio = $("#Anio" + hash);
                this.PartidaPresupuestaria = $("#PartidaPresupuestaria" + hash);
                this.Estado = $("#Estado" + hash);
                this.EstaBloqueada = $("#EstaBloqueada" + hash);
                this.CreditoActual = $("#CreditoActual" + hash);
                this.CreditoDisponible = $("#CreditoDisponible" + hash);
                this.CreditoHabilitado = $("#CreditoHabilitado" + hash);
                this.MontoPreventiva = $("#MontoPreventiva" + hash);
                this.MontoCompromiso = $("#MontoCompromiso" + hash);
                this.MontoOrdenadoAPagar = $("#MontoOrdenadoAPagar" + hash);
                this.PresupuestoSolicitado = $("#PresupuestoSolicitado" + hash);
                this.Presupuestado = $("#Presupuestado" + hash);
                this.ReestructuraMas = $("#ReestructuraMas" + hash);
                this.ReestructuraMenos = $("#ReestructuraMenos" + hash);
                this.Factibilidad = $("#Factibilidad" + hash);
                this.FactibilidadHabilitada = $("#FactibilidadHabilitada" + hash);
                this.ReservaMas = $("#ReservaMas" + hash);
                this.ReservaMenos = $("#ReservaMenos" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Anio.val("");
                this.PartidaPresupuestaria.val('').trigger("liszt:updated");
                this.Estado.val("");
                this.EstaBloqueada.removeAttr('checked');
                this.CreditoActual.val("");
                this.CreditoDisponible.val("");
                this.CreditoHabilitado.val("");
                this.MontoPreventiva.val("");
                this.MontoCompromiso.val("");
                this.MontoOrdenadoAPagar.val("");
                this.PresupuestoSolicitado.val("");
                this.Presupuestado.val("");
                this.ReestructuraMas.val("");
                this.ReestructuraMenos.val("");
                this.Factibilidad.val("");
                this.FactibilidadHabilitada.val("");
                this.ReservaMas.val("");
                this.ReservaMenos.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = EjecucionesPresupuestarias.ts || (EjecucionesPresupuestarias.ts = {}));
})(EjecucionesPresupuestarias || (EjecucionesPresupuestarias = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var EjecucionesPresupuestarias;
(function (EjecucionesPresupuestarias) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Anio = $("#Anio" + hash);
                this.Ver = $("#Ver" + hash);
                this.CrearAnual = $("#CrearPresupuesto" + hash);
                //operaciones
                //Establece el foco
                this.Anio.focus();
            }
            Index.prototype.limpiar = function () {
                this.EjecucionesPresupuestarias.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setEjecucionesPresupuestarias = function (dt) {
                var that = this;
                this.EjecucionesPresupuestarias = dt;
                $("#dtEjecucionesPresupuestarias tbody").click(function (event) {
                    $(that.EjecucionesPresupuestarias.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.EjecucionesPresupuestarias.fnGetData($(event.target).closest("tr").index())[0];
                    that.EjecucionesPresupuestarias_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.EjecucionesPresupuestarias.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = EjecucionesPresupuestarias.ts || (EjecucionesPresupuestarias.ts = {}));
})(EjecucionesPresupuestarias || (EjecucionesPresupuestarias = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var EjecucionesPresupuestarias;
(function (EjecucionesPresupuestarias) {
    var ts;
    (function (ts) {
        var EjecucionesPresupuestariasManager = /** @class */ (function () {
            function EjecucionesPresupuestariasManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            EjecucionesPresupuestariasManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista			
                v.CrearAnual.click(function (e) {
                    app.modal.cargar("Crear Presupuesto Anual", "/Expedientes/EjecucionesPresupuestarias/CrearAnual");
                });
            };
            EjecucionesPresupuestariasManager.prototype.setCrearAnual = function (v) {
                var that = this;
                this.ViewCrearAnual = v;
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.crearAnual("Crear", resultado);
                });
            };
            //--- Inicialización de la vista Crear
            EjecucionesPresupuestariasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Ejecución", resultado).done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Ejecución", resultado).done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            EjecucionesPresupuestariasManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                //$("input[data-type=decimal]").val($("input[data-type=decimal]").val().replace(",", "."));
                $("input[data-type=decimal]").each(function (i, v) {
                    $(this).val($(this).val().replace(",", "."));
                });
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    $("input[data-type=decimal]").each(function (i, v) {
                        $(this).val($(this).val().replace(".", ","));
                    });
                    that.ajaxPost(that.ViewEditar, "Guardar Ejecución", resultado).done(function () {
                        if (resultado.estado) {
                            app.closeCurrentTab();
                            that.ViewIndex.EjecucionesPresupuestarias.fnDraw();
                        }
                    });
                });
            };
            //--- Función editar de Datatable EjecucionesPresupuestarias
            EjecucionesPresupuestariasManager.prototype.editar_dtEjecucionesPresupuestarias = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "/Expedientes/EjecucionesPresupuestarias/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable EjecucionesPresupuestarias
            EjecucionesPresupuestariasManager.prototype.eliminar_dtEjecucionesPresupuestarias = function () {
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("/Expedientes/EjecucionesPresupuestarias/Eliminar", { id: id }, resultado);
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            EjecucionesPresupuestariasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                //if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: v.form.attr("action"),
                    data: v.form.serialize(),
                    success: function (data) {
                        resultado.estado = data[0];
                        resultado.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            resultado.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        resultado.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                //}
                return (df.promise());
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            EjecucionesPresupuestariasManager.prototype.crearAnual = function (titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "/Expedientes/EjecucionesPresupuestarias/CrearAnual",
                    data: { anio: that.ViewCrearAnual.Anio.val(), unidad_de_organizacion: that.ViewCrearAnual.UnidadDeOrganizacion.val() },
                    success: function (data) {
                        if (data.length > 0) {
                            that.ViewCrearAnual.Errores.empty();
                            $.each(data, function (i, v) {
                                that.ViewCrearAnual.Errores.append("<tr><td>" + v + "</td></tr>");
                            });
                        }
                        else {
                            that.ViewCrearAnual.Errores.append("<tr><td>No se han encontrado errores</td></tr>");
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario");
                        resultado.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            EjecucionesPresupuestariasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            EjecucionesPresupuestariasManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                resultado.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return EjecucionesPresupuestariasManager;
        }()); //JS	
        ts.EjecucionesPresupuestariasManager = EjecucionesPresupuestariasManager;
    })(ts = EjecucionesPresupuestarias.ts || (EjecucionesPresupuestarias.ts = {}));
})(EjecucionesPresupuestarias || (EjecucionesPresupuestarias = {}));
/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var EjecucionesPresupuestariasReestructuras;
(function (EjecucionesPresupuestariasReestructuras) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Anio = $('#Anio' + hash);
                this.PartidaPresupuestaria = $('#PartidaPresupuestaria' + hash);
                this.Importe = $('#Importe' + hash);
                this.Fecha = $('#Fecha' + hash);
                this.Observaciones = $('#Observaciones' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.validacion();
            }
            Crear.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Anio: { required: true, number: true, maxlength: 4 },
                        PartidaPresupuestaria: { required: true, number: true, maxlength: 4 },
                        Importe: { required: true, decimal: true, maxlength: 9 },
                        Fecha: { required: true, number: false, maxlength: 8 },
                        Observaciones: { required: true, number: false, maxlength: 250 },
                    },
                    messages: {
                        Anio: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        PartidaPresupuestaria: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Importe: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        Fecha: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                        Observaciones: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 250 caracteres" },
                    }
                });
            };
            Crear.prototype.limpiar = function () {
                this.Anio.val("");
                this.PartidaPresupuestaria.val("");
                this.Importe.val("");
                this.Fecha.val("");
                this.Observaciones.val("");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = EjecucionesPresupuestariasReestructuras.ts || (EjecucionesPresupuestariasReestructuras.ts = {}));
})(EjecucionesPresupuestariasReestructuras || (EjecucionesPresupuestariasReestructuras = {})); // module
/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var EjecucionesPresupuestariasReestructuras;
(function (EjecucionesPresupuestariasReestructuras) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $('#Id' + hash);
                this.Anio = $('#Anio' + hash);
                this.PartidaPresupuestaria = $('#PartidaPresupuestaria' + hash);
                this.Importe = $('#Importe' + hash);
                this.Fecha = $('#Fecha' + hash);
                this.Observaciones = $('#Observaciones' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.validacion();
            }
            Editar.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Id: { required: true, number: true, maxlength: 4 },
                        Anio: { required: true, number: true, maxlength: 4 },
                        PartidaPresupuestaria: { required: true, number: true, maxlength: 4 },
                        Importe: { required: true, decimal: true, maxlength: 9 },
                        Fecha: { required: true, number: false, maxlength: 8 },
                        Observaciones: { required: true, number: false, maxlength: 250 },
                    },
                    messages: {
                        Id: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Anio: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        PartidaPresupuestaria: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Importe: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        Fecha: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                        Observaciones: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 250 caracteres" },
                    }
                });
            };
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Anio.val("");
                this.PartidaPresupuestaria.val("");
                this.Importe.val("");
                this.Fecha.val("");
                this.Observaciones.val("");
            };
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = EjecucionesPresupuestariasReestructuras.ts || (EjecucionesPresupuestariasReestructuras.ts = {}));
})(EjecucionesPresupuestariasReestructuras || (EjecucionesPresupuestariasReestructuras = {})); // module
/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var EjecucionesPresupuestariasReestructuras;
(function (EjecucionesPresupuestariasReestructuras) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.validacion();
            }
            Index.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        EjecucionesPresupuestariasReestructuras: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        EjecucionesPresupuestariasReestructuras: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setEjecucionesPresupuestariasReestructuras = function (dt) {
                var self = this;
                this.EjecucionesPresupuestariasReestructuras = dt;
                $("#dtEjecucionesPresupuestariasReestructuras tbody").click(function (event) {
                    $(self.EjecucionesPresupuestariasReestructuras.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.EjecucionesPresupuestariasReestructuras.fnGetData($(event.target).closest("tr").index())[0];
                    self.EjecucionesPresupuestariasReestructuras_id = id;
                    self.EjecucionesPresupuestariasReestructuras_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_EjecucionesPresupuestariasReestructuras = function (col) {
                return (this.EjecucionesPresupuestariasReestructuras.fnGetData(this.EjecucionesPresupuestariasReestructuras_index)[col]);
            };
            Index.prototype.selectRow_EjecucionesPresupuestariasReestructuras = function (event) {
                var self = this;
                $(self.EjecucionesPresupuestariasReestructuras.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.EjecucionesPresupuestariasReestructuras.fnGetData($(event).closest("tr").index())[0];
                self.EjecucionesPresupuestariasReestructuras_id = id;
                self.EjecucionesPresupuestariasReestructuras_index = $(event).closest("tr").index();
            };
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = EjecucionesPresupuestariasReestructuras.ts || (EjecucionesPresupuestariasReestructuras.ts = {}));
})(EjecucionesPresupuestariasReestructuras || (EjecucionesPresupuestariasReestructuras = {})); // module
/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var EjecucionesPresupuestariasReestructuras;
(function (EjecucionesPresupuestariasReestructuras) {
    var ts;
    (function (ts) {
        var EjecucionesPresupuestariasReestructurasManager = /** @class */ (function () {
            function EjecucionesPresupuestariasReestructurasManager() {
                //this.initHandler();
            }
            EjecucionesPresupuestariasReestructurasManager.prototype.setIndex = function (v) {
                var self = this;
                this.ViewIndex = v;
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.editar_dtEjecucionesPresupuestariasReestructuras = function (el) {
                this.ViewIndex.selectRow_EjecucionesPresupuestariasReestructuras(el);
                var id = this.ViewIndex.getData_EjecucionesPresupuestariasReestructuras(0);
                app.createTab("Editar", "EjecucionesPresupuestariasReestructuras/Editar/" + id, true, true, true);
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.eliminar_dtEjecucionesPresupuestariasReestructuras = function (el) {
                this.ViewIndex.selectRow_EjecucionesPresupuestariasReestructuras(el);
                var id = this.ViewIndex.getData_EjecucionesPresupuestariasReestructuras(0);
                this.eliminar("EjecucionesPresupuestariasReestructuras/Eliminar", { id: id });
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.setCrear = function (v) {
                var self = this;
                this.ViewCrear = v;
                v.Cancelar.click(function (e) {
                    self.ViewCrear.limpiar();
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            self.ViewIndex.EjecucionesPresupuestariasReestructuras.fnDraw();
                            self.ViewCrear.limpiar();
                            app.irATab(0);
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            self.ViewCrear.limpiar(); //self.ViewCrear.Descripcion.focus(); 
                        }
                    });
                });
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.setEditar = function (v) {
                var self = this;
                this.ViewEditar = v;
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewEditar, "Resultado", resultado).done(function () { self.ViewIndex.EjecucionesPresupuestariasReestructuras.fnDraw(); self.ViewCrear.limpiar(); app.irATab(0); });
                });
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.eliminar = function (url, data) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                    that.ViewIndex.EjecucionesPresupuestariasReestructuras.fnDraw();
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return EjecucionesPresupuestariasReestructurasManager;
        }()); //JS
        ts.EjecucionesPresupuestariasReestructurasManager = EjecucionesPresupuestariasReestructurasManager;
    })(ts = EjecucionesPresupuestariasReestructuras.ts || (EjecucionesPresupuestariasReestructuras.ts = {}));
})(EjecucionesPresupuestariasReestructuras || (EjecucionesPresupuestariasReestructuras = {})); // module
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
var SyncroAutocomplete = /** @class */ (function () {
    function SyncroAutocomplete(elemento, url, callback) {
        var that = this;
        this.txt = $("#txt" + elemento);
        this.hidden = $("#" + elemento);
        this.url = url;
        if (callback != null)
            this.callback = callback;
        this.txt.autocomplete({
            source: url,
            //appendTo: '#demo',
            minLength: 2,
            select: function (event, ui) {
                $(this).val(ui.item.label);
                that.hidden.val(ui.item.id);
                console.log(this.callback);
                if (this.callback != null)
                    this.callback(ui);
            }
        });
    }
    SyncroAutocomplete.prototype.set = function (valor, texto) {
        this.txt.val(texto);
        this.hidden.val(valor);
    };
    SyncroAutocomplete.prototype.texto = function () {
        return this.txt.val();
    };
    SyncroAutocomplete.prototype.setCallback = function (callback) {
        var that = this;
        this.callback = callback;
        this.txt.autocomplete({
            source: that.url,
            //appendTo: '#demo',
            minLength: 2,
            select: function (event, ui) {
                $(this).val(ui.item.label);
                that.hidden.val(ui.item.id);
                //console.log(this.callback);
                if (that.callback != null) {
                    console.log("entra a callback");
                    that.callback(ui);
                }
            }
        });
    };
    SyncroAutocomplete.prototype.setAppendTo = function (append) {
        var that = this;
        this.txt.autocomplete({
            source: that.url,
            appendTo: append,
            minLength: 2,
            select: function (event, ui) {
                $(this).val(ui.item.label);
                that.hidden.val(ui.item.id);
                console.log(this.callback);
                if (that.callback != null)
                    that.callback(ui);
            }
        });
    };
    SyncroAutocomplete.prototype.valor = function () {
        return this.hidden.val();
    };
    SyncroAutocomplete.prototype.limpiar = function () {
        this.txt.val("");
        this.hidden.val("");
    };
    return SyncroAutocomplete;
}());
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var Asignar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Asignar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.UnidadOrganizacion = $("#UnidadDeOrganizacionRef" + hash);
                this.Partidas = $("#body_partidas" + hash);
                this.spFactura = $("#spFactura" + hash);
                this.spImporte = $("#spImporte" + hash);
                this.Id = $("#Id" + hash);
                this.Guardar = $("#Guardar" + hash);
                //operaciones
                //Establece el foco
                this.UnidadOrganizacion.focus();
            }
            Asignar.prototype.limpiar = function () {
                this.UnidadOrganizacion.val('').trigger("liszt:updated");
                //this.Partidas.limpiar();
            };
            //--- Funciones para seteo de Datatables ---/
            //public getData(col: number): any {
            //          return(this.Agentes.fnGetData(this.index)[col]); 
            //      }
            //--- /Funciones para seteo de Datatables ---/
            Asignar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Asignar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Asignar;
        }()); //JS
        ts.Asignar = Asignar;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
var SyncroSelect = /** @class */ (function () {
    function SyncroSelect(elemento, chosen) {
        var that = this;
        this.el = $("#" + elemento);
        this.chosen = (chosen != null && chosen) ? true : false;
    }
    SyncroSelect.prototype.agregar = function (value, text) {
        var o = new Option(text, value);
        $(o).html(text);
        this.el.append(o);
        if (this.chosen)
            this.el.trigger("liszt:updated");
    };
    SyncroSelect.prototype.quitar = function (value) {
        this.el.find("option[value='" + value + "']").remove();
    };
    SyncroSelect.prototype.valor = function () {
        return this.el.val();
    };
    SyncroSelect.prototype.texto = function () {
        return this.el.find("option:selected").text();
    };
    SyncroSelect.prototype.bind = function (event, fun) {
        this.el.bind(event, fun);
    };
    SyncroSelect.prototype.habilitado = function (enable) {
        if (enable)
            this.el.prop("disabled", false);
        else
            this.el.prop("disabled", "disabled");
        if (this.chosen)
            this.el.trigger("liszt:updated");
    };
    SyncroSelect.prototype.ajax = function (url, param) {
        var that = this;
        $.post(url, param, function (data) {
            var sel = that.el;
            sel.empty();
            for (var i = 0; i < data.length; i++) {
                sel.append('<option value="' + data[i].value + '">' + data[i].text + '</option>');
            }
        }, "json");
    };
    return SyncroSelect;
}());
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //public afacturas: Facturas[];
            //public aactuaciones: Actuaciones[];
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Tipo = $("#TiposExpedienteADMRef" + hash);
                //this.Categoria = $("#CategoriasExpedienteADMRef"+hash);
                this.Categoria = new SyncroSelect("CategoriasExpedienteADMRef" + hash, true);
                this.Numero = $("#Numero" + hash);
                this.NumeroDeCorresponde = $("#NumeroDeCorresponde" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.OrganismoIniciador = $("#OrganismoIniciador" + hash);
                this.TextoIniciador = $("#TextoIniciador" + hash);
                this.Caratula = $("#Caratula" + hash);
                this.Destino = $("#Destino" + hash);
                this.divDetalle = $("#divDetalle" + hash);
                this.EsCorreponde = $("#chkCorresponde" + hash);
                this.hidCorresponde = $("#hidCorresponde");
                this.hidNumero = $("#hidNumero");
                this.spNumeroExpediente = $("#spNumeroExpediente");
                this.divDetalle.hide();
                this.Modal = new SyncroModal($("#MainModal"));
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Imprimir = $("#Imprmir" + hash);
                this.NuevaActuacion = $("#NuevaActuacion" + hash);
                this.NuevaFactura = $("#NuevaFactura" + hash);
                this.Imprimir.hide();
                //this.afacturas = [];
                //this.aactuaciones = [];
                //Establece el foco
                this.Tipo.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Tipo.val('').trigger("liszt:updated");
                //this.Categoria.val('').trigger("liszt:updated");
                this.Numero.val("");
                this.NumeroDeCorresponde.val("");
                this.Fecha.val("");
                this.OrganismoIniciador.val('').trigger("liszt:updated");
                this.TextoIniciador.val("");
                this.Caratula.val("");
                this.Destino.val('').trigger("liszt:updated");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var Detalle = /** @class */ (function () {
            //public afacturas: Facturas[];
            //public aactuaciones: Actuaciones[];
            //---  /Propiedades de Formulario --- //
            function Detalle(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Tipo = $("#Tipo" + hash);
                this.Categoria = $("#Categoria" + hash);
                this.Numero = $("#Numero" + hash);
                this.NumeroDeCorresponde = $("#NumeroDeCorresponde" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.OrganismoIniciador = $("#OrganismoIniciador" + hash);
                this.TextoIniciador = $("#TextoIniciador" + hash);
                this.Caratula = $("#Caratula" + hash);
                this.Destino = $("#Destino" + hash);
                this.divDetalle = $("#divDetalle" + hash);
                this.Afectar = $("#Afectar" + hash);
                this.Id = $("#Id" + hash);
                this.body_facturas = $("#body_facturas" + hash);
                //this.divDetalle.hide();
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.NuevaActuacion = $("#Pase" + hash);
                this.NuevaFactura = $("#NuevaFactura" + hash);
                //this.afacturas = [];
                //this.aactuaciones = [];
                //Establece el foco
                this.Tipo.focus();
            }
            Detalle.prototype.limpiar = function () {
                this.Tipo.val('').trigger("liszt:updated");
                this.Categoria.val('').trigger("liszt:updated");
                this.Numero.val("");
                this.NumeroDeCorresponde.val("");
                this.Fecha.val("");
                this.OrganismoIniciador.val('').trigger("liszt:updated");
                this.TextoIniciador.val("");
                this.Caratula.val("");
                this.Destino.val('').trigger("liszt:updated");
            };
            Detalle.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Detalle.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Detalle;
        }()); //JS
        ts.Detalle = Detalle;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Tipo = $("#Tipo" + hash);
                this.Categoria = $("#Categoria" + hash);
                this.Numero = $("#Numero" + hash);
                this.NumeroDeTramite = $("#NumeroDeTramite" + hash);
                this.NumeroDeCorresponde = $("#NumeroDeCorresponde" + hash);
                this.FechaDeAlta = $("#FechaDeAlta" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.UsuarioBaja = $("#UsuarioBaja" + hash);
                this.FechaDeBaja = $("#FechaDeBaja" + hash);
                this.Caratula = $("#Caratula" + hash);
                this.OrganismoIniciador = $("#OrganismoIniciador" + hash);
                this.TextoIniciador = $("#TextoIniciador" + hash);
                this.ExpedienteAcumulado = $("#ExpedienteAcumulado" + hash);
                this.FechaAcumulado = $("#FechaAcumulado" + hash);
                this.UsuarioAcumulado = $("#UsuarioAcumulado" + hash);
                this.ExpedientePadre = $("#ExpedientePadre" + hash);
                this.UltimoCorresponde = $("#UltimoCorresponde" + hash);
                this.Archivado = $("#Archivado" + hash);
                this.FechaArchivado = $("#FechaArchivado" + hash);
                this.UsuarioArchiva = $("#UsuarioArchiva" + hash);
                this.AnioContable = $("#AnioContable" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Tipo.val('').trigger("liszt:updated");
                this.Categoria.val('').trigger("liszt:updated");
                this.Numero.val("");
                this.NumeroDeTramite.val("");
                this.NumeroDeCorresponde.val("");
                this.FechaDeAlta.val("");
                this.Fecha.val("");
                this.UsuarioAlta.val("");
                this.UsuarioBaja.val("");
                this.FechaDeBaja.val("");
                this.Caratula.val("");
                this.OrganismoIniciador.val('').trigger("liszt:updated");
                this.TextoIniciador.val("");
                this.ExpedienteAcumulado.val('').trigger("liszt:updated");
                this.FechaAcumulado.val("");
                this.UsuarioAcumulado.val('').trigger("liszt:updated");
                this.ExpedientePadre.val('').trigger("liszt:updated");
                this.UltimoCorresponde.val("");
                this.Archivado.removeAttr('checked');
                this.FechaArchivado.val("");
                this.UsuarioArchiva.val('').trigger("liszt:updated");
                this.AnioContable.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.ExpedientesADM.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setExpedientesADM = function (dt) {
                var that = this;
                this.ExpedientesADM = dt;
                $("#dtExpedientesADM tbody").click(function (event) {
                    $(that.ExpedientesADM.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[0];
                    that.ExpedientesADM_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.ExpedientesADM.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var ExpedientesADMManager = /** @class */ (function () {
            function ExpedientesADMManager() {
                // Constructor
            }
            ExpedientesADMManager.prototype.setAsignar = function (v) {
                var that = this;
                this.ViewAsignar = v;
                var total;
                total = 0.0;
                this.refrescarPartidas();
                $("input[data-tipo=importe]").die("keyup");
                $("input[data-tipo=importe]").live("keyup", function (e) {
                    v.Partidas.find("tr").each(function () {
                        var $el = $(this);
                        if ($el.find("td input").val())
                            total += parseFloat($el.find("td input").val());
                    });
                    v.spImporte.html(total.toFixed(2));
                    total = 0;
                });
                $.get("Expedientes/Expedientesadm/ObtenerAsiganacion", { id: v.Id.val() }, function (data) {
                    if (data.length > 0) {
                        $.each(data.FacturasImputadasDetalle, function (index, value) {
                            $("#importe_" + value.Partida).val(value.Importe);
                            $("#div_" + value.Partida).find("option[value=" + value.Division + "]").prop("selected", "selected");
                        });
                    }
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.guardarImputacion("Guardar Asignación", resultado).done(function (e) {
                    });
                });
                v.UnidadOrganizacion.change(function (e) {
                    that.refrescarPartidas();
                });
            };
            ExpedientesADMManager.prototype.refrescarPartidas = function () {
                var p = this.ViewAsignar;
                //p.Partidas.empty();
                p.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if (!$el.find("td input").val())
                        $el.remove();
                });
                $.get("Expedientes/PartidasPresupuestarias/partidas", { unidad: p.UnidadOrganizacion.val() }, function (data) {
                    $.each(data, function (index, value) {
                        var row = "";
                        row = "<tr data-partida='" + value.Id + "'><td>" + value.NumeroDePartida + "</td>";
                        row += "<td><select data-tipo='division' id='div_" + value.Id + "' class='form-control col-md-12'>";
                        $.each(value.DivisionesExtraPresupuestarias, function (index, division) {
                            row += "<option value='" + division.Id + "'>" + division.Nombre + "</option>";
                        });
                        row += "</td><td><input type='text' class='form-control' data-tipo='importe' id='importe_" + value.Id + "' value'0'></td></tr>";
                        p.Partidas.append(row);
                    });
                });
            };
            //--- Inicialización de la vista Index
            ExpedientesADMManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ExpedientesADMManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Tipo.change(function (e) {
                    var numero = "";
                    if (v.Numero.val() != "0")
                        numero = v.Numero.val();
                    $.get("/Expedientes/ExpedientesADM/obtenerNumero", { tipo: $(this).val(), numero: numero, corresponde: v.EsCorreponde.is(":checked") }, function (data) {
                        v.spNumeroExpediente.html(data.numero);
                        v.hidNumero.val(data.numero);
                        v.hidCorresponde.val(data.nro_corresponde);
                    });
                });
                v.EsCorreponde.change(function (e) {
                    if (this.checked) {
                        v.Numero.removeAttr("disabled");
                        v.Numero.focus();
                    }
                    else {
                        v.Numero.prop("disabled", "disabled");
                        v.Numero.val("0");
                    }
                });
                v.Numero.keyup(function (e) {
                    if (e.which == 13) {
                        $.get("/Expedientes/ExpedientesADM/obtenerNumero", { tipo: v.Tipo.val(), numero: v.Numero.val(), corresponde: v.EsCorreponde.is(":checked") }, function (data) {
                            v.spNumeroExpediente.html(data.numero);
                            v.hidNumero.val(data.numero);
                            v.hidCorresponde.val(data.nro_corresponde);
                        });
                    }
                });
                v.NuevaActuacion.click(function (e) {
                    v.Modal.cargar("Nueva Actuación", "Expedientes/ActuacionesADM/Crear");
                });
                v.NuevaFactura.click(function (e) {
                    v.Modal.cargar("Nueva Factura", "Expedientes/Facturas/Crear");
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Expediente", resultado).done(function () {
                        if (resultado.estado) {
                            //v.limpiar();
                            v.divDetalle.show();
                            v.Imprimir.show();
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Expediente", resultado).done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Crear
            ExpedientesADMManager.prototype.setDetalle = function (v) {
                var that = this;
                this.ViewDetalle = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    //app.irATab(0);
                    //var editor = new FormatEditor(that.expediente, 1007);
                    //console.log(that.expediente);
                    //editor.test();
                });
                $("a[data-tipo=contabilidad]").die("click");
                $("a[data-tipo=contabilidad]").live("click", function (e) {
                    e.preventDefault();
                    $("#tr_" + $(this).data("id")).show();
                });
                $("button[data-tipo=asignar]").die("click");
                $("button[data-tipo=asignar]").live("click", function (e) {
                    e.preventDefault();
                    app.modal.cargar("Asignar Factura", "/Expedientes/Facturas/Asignar/?factura=" + $(this).data("id") + "&vista=expediente").done(function () {
                        var manager = app.getManager("Facturas");
                        manager.ViewAsignar.bVistaExpediente = true;
                    });
                    ;
                });
                v.Afectar.click(function (e) {
                    var resultado = new Resultado();
                    var id = 0;
                    console.log("previo llamar a afectar");
                    that.postAfectar(v, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            id = resultado.id;
                            app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                that.expediente = e;
                            }).done(function () {
                                console.log("imputacion: " + id);
                                var editor = new FormatEditor(that.expediente, 1007, id);
                                editor.test();
                            });
                        }
                    });
                });
                v.NuevaActuacion.click(function (e) {
                    app.modal.cargar("Nueva Actuación", "Expedientes/Actuacionesadm/Crear/?expediente=" + v.Id.val());
                    //console.log("imputacion: " + id);
                    // var editor = new FormatEditor(that.expediente, 1007, id);
                    // editor.test();
                });
                app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                    that.expediente = e;
                });
            };
            ExpedientesADMManager.prototype.verActuacion = function (el) {
                var id = $(el).data("id");
                app.modal.cargar("Ver actuación", "Expedientes/actuacionesadm/editar/" + id);
                return false;
            };
            //--- Inicialización de la vista Editar
            ExpedientesADMManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Modificar título").done(function () {
                    });
                });
            };
            ExpedientesADMManager.prototype.refreshFacturas = function (id) {
                var self = this;
                self.ViewDetalle.body_facturas.empty();
                $.get("/expedientes/expedientesadm/facturas/?expediente=" + id, null, function (data) {
                    console.log(data);
                    $.each(data, function (i, o) {
                        var tr = "<tr>";
                        tr += "<td>" + app.formatearFecha(o.Fecha) + "</td>";
                        tr += "<td>" + o.Proveedor + "</td>";
                        tr += "<td>" + o.NumeroDeFactura + "</td>";
                        tr += "<td>" + o.Importe + "</td>";
                        tr += "<td>" + o.EstaAsignada + "</td>";
                        tr += !o.EstaAsignada ? "<td><button class='btn info btn- xs' data-id='" + o.Id + "' data-tipo='asignar'>Asignar</button></td>" : "<td>&nbsp;</td>";
                        self.ViewDetalle.body_facturas.append(tr);
                    });
                });
            };
            //--- Función editar de Datatable ExpedientesADM
            ExpedientesADMManager.prototype.detalle_dtExpedientesADM = function () {
                var id = this.ViewIndex.getData(0);
                var numero = this.ViewIndex.getData(2);
                app.createTab("Detalle " + numero, "/Expedientes/ExpedientesADM/detalle/?id=" + id, true, true, true);
            };
            ExpedientesADMManager.prototype.editar_dtExpedientesADM = function () {
                var id = this.ViewIndex.getData(0);
                var numero = this.ViewIndex.getData(2);
                app.createTab("Editar " + numero, "ExpedientesADM/Editar/" + id, true, true, true);
            };
            ExpedientesADMManager.prototype.asignar_dtExpedientesADM = function () {
                var id = this.ViewIndex.getData(0);
                var numero = this.ViewIndex.getData(2);
                app.modal.cargar("Asignar Expediente Nro: " + numero, "/Expedientes/ExpedientesADM/Asignar/?expediente=" + id);
                //app.createTab("Editar " + numero, , true, true, true);
            };
            //--- Función eliminar de Datatable ExpedientesADM
            ExpedientesADMManager.prototype.eliminar_dtExpedientesADM = function () {
                var id = this.ViewIndex.getData(0);
                //this.eliminar("ExpedientesADM/Eliminar", { id: id });
            };
            ExpedientesADMManager.prototype.guardarImputacion = function (titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                var imputacion;
                imputacion = {
                    ExpedienteAImputar: that.ViewAsignar.Id.val(),
                    Operacion: 1,
                    ImputacionesContablesDetalle: new Array()
                };
                that.ViewAsignar.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if ($el.find("td input").val()) {
                        var detalle;
                        detalle = {
                            Partida: $el.data("partida"),
                            Division: $el.find("select").val(),
                            Importe: $el.find("td input").val(),
                            //TODO: Obtener le año contable por usuario
                            AnioContable: 2016
                        };
                        imputacion.ImputacionesContablesDetalle.push(detalle);
                    }
                });
                console.log(imputacion);
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "Expedientes/Expedientesadm/AsignarExpdiente",
                    data: JSON.stringify({ imputacion: imputacion }),
                    contentType: "application/json",
                    success: function (data) {
                        resultado.estado = data[0];
                        resultado.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            resultado.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        resultado.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            ExpedientesADMManager.prototype.postAfectar = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: "Expedientes/Expedientesadm/Afectar",
                        data: { expediente: that.ViewDetalle.Id.val() },
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ExpedientesADMManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                //if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: v.form.attr("action"),
                    data: v.form.serialize(),
                    success: function (data) {
                        resultado.estado = data[0];
                        resultado.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            resultado.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        resultado.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                //}
                return (df.promise());
            };
            ExpedientesADMManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    //traditional:true,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            ExpedientesADMManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                resultado.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return ExpedientesADMManager;
        }()); //JS	
        ts.ExpedientesADMManager = ExpedientesADMManager;
        var FacturasView = /** @class */ (function () {
            function FacturasView() {
            }
            return FacturasView;
        }());
        ts.FacturasView = FacturasView;
        var Facturas = /** @class */ (function () {
            function Facturas() {
            }
            return Facturas;
        }());
        ts.Facturas = Facturas;
        var ActuacionesView = /** @class */ (function () {
            function ActuacionesView() {
            }
            return ActuacionesView;
        }());
        ts.ActuacionesView = ActuacionesView;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {}));
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ExpedientesDocumentoADM;
(function (ExpedientesDocumentoADM) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Archivo = new SyncroUpload($("#Archivo" + hash));
                this.Confirmado = $("#Confirmado" + hash);
                this.Actuacion = $("#Actuacion" + hash);
                this.NombreOriginal = $("#NombreOriginal" + hash);
                this.Extension = $("#Extension" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Usuario = $("#Usuario" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Archivo.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Archivo.val("");
                this.Confirmado.removeAttr('checked');
                this.Actuacion.val("");
                this.NombreOriginal.val("");
                this.Extension.val("");
                this.Descripcion.val("");
                this.Usuario.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Crear.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = ExpedientesDocumentoADM.ts || (ExpedientesDocumentoADM.ts = {}));
})(ExpedientesDocumentoADM || (ExpedientesDocumentoADM = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ExpedientesDocumentoADM;
(function (ExpedientesDocumentoADM) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.ExpedientesDocumentoADM.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setExpedientesDocumentoADM = function (dt) {
                var that = this;
                this.ExpedientesDocumentoADM = dt;
                $("#dtExpedientesDocumentoADM tbody").click(function (event) {
                    $(that.ExpedientesDocumentoADM.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ExpedientesDocumentoADM.fnGetData($(event.target).closest("tr").index())[0];
                    that.ExpedientesDocumentoADM_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = ExpedientesDocumentoADM.ts || (ExpedientesDocumentoADM.ts = {}));
})(ExpedientesDocumentoADM || (ExpedientesDocumentoADM = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
var ExpedientesDocumentoADM;
(function (ExpedientesDocumentoADM) {
    var ts;
    (function (ts) {
        var ExpedientesDocumentoADMManager = /** @class */ (function () {
            function ExpedientesDocumentoADMManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            ExpedientesDocumentoADMManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ExpedientesDocumentoADMManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Función editar de Datatable ExpedientesDocumentoADM
            ExpedientesDocumentoADMManager.prototype.editar_dtExpedientesDocumentoADM = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "ExpedientesDocumentoADM/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable ExpedientesDocumentoADM
            ExpedientesDocumentoADMManager.prototype.eliminar_dtExpedientesDocumentoADM = function () {
                var id = this.ViewIndex.getData(0);
                this.eliminar("ExpedientesDocumentoADM/Eliminar", { id: id });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ExpedientesDocumentoADMManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            ExpedientesDocumentoADMManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            ExpedientesDocumentoADMManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                res.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return ExpedientesDocumentoADMManager;
        }()); //JS	
        ts.ExpedientesDocumentoADMManager = ExpedientesDocumentoADMManager;
    })(ts = ExpedientesDocumentoADM.ts || (ExpedientesDocumentoADM.ts = {}));
})(ExpedientesDocumentoADM || (ExpedientesDocumentoADM = {}));
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var ArmarExpediente = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function ArmarExpediente(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.body_facturas = $("#body_facturas");
                this.body_partidas = $("#body_partidas");
                this.Guardar = $("#Guardar");
                //operaciones		
            }
            ArmarExpediente.prototype.refrescarFacturas = function () {
            };
            ArmarExpediente.prototype.limpiar = function () {
            };
            //--- Funciones para seteo de Datatables ---/
            //public getData(col: number): any {
            //          return(this.Agentes.fnGetData(this.index)[col]); 
            //      }
            //--- /Funciones para seteo de Datatables ---/
            ArmarExpediente.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            ArmarExpediente.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return ArmarExpediente;
        }()); //JS
        ts.ArmarExpediente = ArmarExpediente;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var Asignar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Asignar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.UnidadOrganizacion = $("#UnidadDeOrganizacionRef" + hash);
                this.Partidas = $("#body_partidas");
                this.spFactura = $("#spFactura" + hash);
                this.spImporte = $("#spImporte" + hash);
                this.spResta = $("#spResta" + hash);
                this.Id = $("#Id");
                this.bVistaExpediente = false;
                this.Guardar = $("#Guardar");
                //operaciones
                //Establece el foco
                this.UnidadOrganizacion.focus();
            }
            Asignar.prototype.limpiar = function () {
                this.UnidadOrganizacion.val('').trigger("liszt:updated");
                //this.Partidas.limpiar();
            };
            //--- Funciones para seteo de Datatables ---/
            //public getData(col: number): any {
            //          return(this.Agentes.fnGetData(this.index)[col]); 
            //      }
            //--- /Funciones para seteo de Datatables ---/
            Asignar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Asignar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Asignar;
        }()); //JS
        ts.Asignar = Asignar;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Proveedor = new SyncroAutocomplete("Proveedor" + hash, "Expedientes/Proveedores/Autocomplete");
                this.Proveedor.setAppendTo("#Proveedor");
                this.Tipo = $("#Tipo" + hash);
                this.NumeroDeFactura = $("#NumeroDeFactura" + hash);
                this.IdentificacionDeFactura = $("#IdentificacionDeFactura" + hash);
                this.Expediente = new SyncroAutocomplete("Expediente" + hash, "Expedientes/ExpedientesADM/Autocomplete");
                this.Fecha = $("#Fecha" + hash);
                this.Importe = $("#Importe" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Organismo = $("#Organismo" + hash);
                this.DeImpuestosMunicipales = $("#DeImpuestosMunicipales" + hash);
                this.Comprobante2 = $("#Comprobante2" + hash);
                this.Comprobante3 = $("#Comprobante3" + hash);
                this.DeServicios = $("#DeServicios" + hash);
                this.FechaDesde = $("#FechaDesde" + hash);
                this.FechaHasta = $("#FechaHasta" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Proveedor.txt.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Proveedor.limpiar();
                this.Tipo.val("");
                this.NumeroDeFactura.val("");
                this.IdentificacionDeFactura.val("");
                this.Expediente.limpiar();
                this.Fecha.val("");
                this.Importe.val("");
                this.Descripcion.val("");
                this.Organismo.val('').trigger("liszt:updated");
                this.DeImpuestosMunicipales.removeAttr('checked');
                this.Comprobante2.val("");
                this.Comprobante3.val("");
                this.DeServicios.removeAttr('checked');
                this.FechaDesde.val("");
                this.FechaHasta.val("");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.NumeroDeFactura = $("#NumeroDeFactura" + hash);
                this.IdentificacionDeFactura = $("#IdentificacionDeFactura" + hash);
                this.Tipo = $("#Tipo" + hash);
                this.Expediente = $("#Expediente" + hash);
                this.Proveedor = $("#Proveedor" + hash);
                this.txtProveedor = $("#txtProveedor" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Importe = $("#Importe" + hash);
                this.Organismo = $("#Organismo" + hash);
                this.Agente = $("#Agente" + hash);
                this.TextoAgente = $("#TextoAgente" + hash);
                this.EsFactura = $("#EsFactura" + hash);
                this.EstaAsignada = $("#EstaAsignada" + hash);
                this.EstaPagada = $("#EstaPagada" + hash);
                this.DeImpuestosMunicipales = $("#DeImpuestosMunicipales" + hash);
                this.Comprobante2 = $("#Comprobante2" + hash);
                this.Comprobante3 = $("#Comprobante3" + hash);
                this.DeServicios = $("#DeServicios" + hash);
                this.FechaDesde = $("#FechaDesde" + hash);
                this.FechaHasta = $("#FechaHasta" + hash);
                this.Afectada = $("#Afectada" + hash);
                this.Compromiso = $("#Compromiso" + hash);
                this.OrdenadoAPagar = $("#OrdenadoAPagar" + hash);
                this.Grupo = $("#Grupo" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                this.FechaModifica = $("#FechaModifica" + hash);
                this.FechaElimina = $("#FechaElimina" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.UsuarioModifica = $("#UsuarioModifica" + hash);
                this.UsuarioElimina = $("#UsuarioElimina" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.NumeroDeFactura.val("");
                this.IdentificacionDeFactura.val("");
                this.Tipo.val("");
                this.Expediente.val('').trigger("liszt:updated");
                this.Proveedor.val('').trigger("liszt:updated");
                this.txtProveedor.val("");
                this.Fecha.val("");
                this.Descripcion.val("");
                this.Importe.val("");
                this.Organismo.val('').trigger("liszt:updated");
                this.Agente.val("");
                this.TextoAgente.val("");
                this.EsFactura.removeAttr('checked');
                this.EstaAsignada.removeAttr('checked');
                this.EstaPagada.removeAttr('checked');
                this.DeImpuestosMunicipales.removeAttr('checked');
                this.Comprobante2.val("");
                this.Comprobante3.val("");
                this.DeServicios.removeAttr('checked');
                this.FechaDesde.val("");
                this.FechaHasta.val("");
                this.Afectada.removeAttr('checked');
                this.Compromiso.removeAttr('checked');
                this.OrdenadoAPagar.removeAttr('checked');
                this.Grupo.val("");
                this.FechaAlta.val("");
                this.FechaModifica.val("");
                this.FechaElimina.val("");
                this.UsuarioAlta.val("");
                this.UsuarioModifica.val("");
                this.UsuarioElimina.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.Facturas.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setFacturas = function (dt) {
                var that = this;
                this.Facturas = dt;
                $("#dtFacturas tbody").click(function (event) {
                    $(that.Facturas.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.Facturas.fnGetData($(event.target).closest("tr").index())[0];
                    that.Facturas_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.Facturas.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="asignar.ts"/>
/// <reference path="../ExpedientesADM/ExpedientesADMManager.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var FacturasManager = /** @class */ (function () {
            function FacturasManager() {
                // Constructor
            }
            FacturasManager.prototype.setAsignar = function (v) {
                var that = this;
                this.ViewAsignar = v;
                var total;
                total = 0.0;
                this.refrescarPartidas();
                $("input[data-tipo=importe]").die("keyup");
                $("input[data-tipo=importe]").live("keyup", function (e) {
                    v.Partidas.find("tr").each(function () {
                        var $el = $(this);
                        if ($el.find("td input").val())
                            total += parseFloat($el.find("td input").val());
                    });
                    v.spResta.html((parseFloat(v.spImporte.html().replace(",", ".")) - total).toFixed(2));
                    total = 0;
                });
                $.get("Expedientes/Facturas/ObtenerAsiganacion", { id: v.Id.val() }, function (data) {
                    if (data.length > 0) {
                        $.each(data.FacturasImputadasDetalle, function (index, value) {
                            $("#importe_" + value.Partida).val(value.Importe);
                            $("#div_" + value.Partida).find("option[value=" + value.Division + "]").prop("selected", "selected");
                        });
                    }
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    var resta = parseFloat(v.spResta.html());
                    if (resta != 0) {
                        bootbox.confirm("Ooops.. el importe asignado no concuerda con el importe de la factura. Desea marcarla igualmente como asignada?", function (result) {
                            if (result) {
                                that.guardarImputacion("Guardar Asignación", resultado).done(function (e) {
                                    if (resultado.estado) {
                                        app.modal.cerrar();
                                        if (!v.bVistaExpediente) {
                                            that.ViewSinAsignacion.dtSinAsignacion.fnDraw();
                                            if (that.ViewSinOP)
                                                that.ViewSinOP.dtSinOP.fnDraw();
                                        }
                                        else {
                                            var manager = app.getManager("ExpedientesADM");
                                            manager.refreshFacturas(manager.ViewDetalle.Id.val());
                                        }
                                    }
                                });
                            }
                        });
                    }
                    else {
                        that.guardarImputacion("Guardar Asignación", resultado).done(function (e) {
                            if (resultado.estado) {
                                app.modal.cerrar();
                                if (!v.bVistaExpediente) {
                                    that.ViewSinAsignacion.dtSinAsignacion.fnDraw();
                                    if (that.ViewSinOP)
                                        that.ViewSinOP.dtSinOP.fnDraw();
                                }
                                else {
                                    var manager = app.getManager("ExpedientesADM");
                                    manager.refreshFacturas(manager.ViewDetalle.Id.val());
                                }
                            }
                        });
                    }
                });
                v.UnidadOrganizacion.change(function (e) {
                    that.refrescarPartidas();
                });
            };
            //--- Inicialización de la vista Index
            FacturasManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            FacturasManager.prototype.setArmarExpediente = function (v) {
                var that = this;
                this.ViewArmarExpediente = v;
                that.aFacturas = [];
                that.aPartidas = [];
                // Eventos de la vista
                $.get("Expedientes/Facturas/FacturasSinExpedienteJson2", null, function (data) {
                    that.aFacturas = data;
                    that.refrescarFacturas();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.armarExpediente(v, "Resultado", resultado);
                });
            };
            FacturasManager.prototype.refrescarFacturas = function () {
                var that = this;
                var t = this.ViewArmarExpediente.body_facturas.empty();
                var r = "";
                var filtro = this.aFacturas;
                if (this.aPartidas.length) {
                    filtro = Enumerable.From(that.aFacturas).Where(function (x) { return Enumerable.From(x.Asignacion).Any(function (z) { return z.Numero == that.aPartidas[0]; }); }).ToArray();
                }
                filtro.forEach(function (v, i) {
                    r = "<tr data-id='" + v.Id + "'><td><input type='checkbox' data-type='check' onclick='oFacturas.seleccionarFactura(this)' class='form-control'></td><td>" + v.Numero + "</td><td>" + v.Identificador + "</td><td>" + app.formatearFecha(v.Fecha.toString()) + "</td><td>" + v.Proveedor + "</td><td>" + v.Descripcion + "</td><td>" + v.Importe + "</td><td><button class='btn green' data-factura='" + v.Id + "' onclick='return oFacturas.verPartida(this)' data-type='ver'>+</button></td></tr>";
                    t.append(r);
                    if (v.Asignacion.length) {
                        var r2 = "";
                        r2 = r2 + "<tr data-factura='" + v.Id + "' style='display:none'><td colspan='8'><table data-factura='" + v.Id + "' class='table table-bordered'><thead><tr><th>Partida</th><th>Importe</th></tr></thead><tbody>";
                        v.Asignacion.forEach(function (v2, i2) {
                            r2 = r2 + "<tr data-partida='" + v2.Partida + "' data-importe='" + v2.Importe + "'><td>" + v2.Partida + "</td><td>" + v2.Importe + "</td></tr>";
                        });
                        r2 = r2 + "</tbody></table></td></tr>";
                        t.append(r2);
                    }
                });
            };
            FacturasManager.prototype.verPartida = function (el) {
                var id = $(el).data("factura");
                $("tr[data-factura=" + id + "]").show();
                return false;
            };
            FacturasManager.prototype.seleccionarFactura = function (el) {
                var that = this;
                this.aTotal = [];
                this.ViewArmarExpediente.body_partidas.empty();
                this.ViewArmarExpediente.body_facturas.find("tr").each(function (i, v) {
                    if ($(v).data("id")) {
                        console.log("Procesando factura: " + $(v).data("id"));
                        if ($(v).find("td input:checkbox")[0].checked) {
                            //console.log("entra a if checked " + $(v).data("id"));
                            $("table[data-factura=" + $(v).data("id") + "]").find("tr").each(function (i2, v2) {
                                if ($(v2).data("partida")) {
                                    var p = {
                                        partida: $(v2).data("partida"),
                                        importe: $(v2).data("importe")
                                    };
                                    console.log(p);
                                    that.aTotal.push(p);
                                }
                            });
                        }
                        console.log(that.aTotal);
                    }
                });
                console.log("Partidas:");
                console.log(that.aTotal.length);
                if (that.aTotal.length) {
                    console.log("entra a partidas");
                    //var resultado = Enumerable.From(that.aTotal).GroupBy("$.partida", "$.importe", "{partida:$.partida, total:$$.Sum()}").ToArray();
                    var resultado = Enumerable.From(that.aTotal).GroupBy("$.partida", null, function (key, e) {
                        return {
                            partida: key,
                            total: e.Sum("$.importe")
                        };
                    }).ToArray();
                    resultado.forEach(function (v, i) {
                        that.ViewArmarExpediente.body_partidas.append("<tr><td>" + v.partida + "</td><td>" + v.total + "</td></tr>");
                    });
                }
            };
            FacturasManager.prototype.setSinAsignacion = function (v) {
                var that = this;
                this.ViewSinAsignacion = v;
                // Eventos de la vista
            };
            FacturasManager.prototype.setSinOP = function (v) {
                var that = this;
                this.ViewSinOP = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            FacturasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Resultado", res).done(function () {
                        if (res.estado) {
                            if (that.ViewIndex) {
                                app.irATab(0);
                                that.ViewIndex.Facturas.fnDraw();
                            }
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Resultado", res).done(function () {
                        if (res.estado) {
                            that.ViewCrear.limpiar();
                            that.ViewIndex.Facturas.fnDraw();
                        }
                    });
                });
            };
            //--- Inicialización de la vista Editar
            FacturasManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.Actualizar(that.ViewEditar, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            app.closeCurrentTab();
                            that.ViewIndex.Facturas.fnDraw();
                        }
                    });
                });
                app.setValidadorDecimal();
            };
            FacturasManager.prototype.refrescarPartidas = function () {
                var that = this;
                var p = this.ViewAsignar;
                //p.Partidas.empty();
                p.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if (!$el.find("td input").val())
                        $el.remove();
                });
                $.get("Expedientes/PartidasPresupuestarias/partidas", { unidad: p.UnidadOrganizacion.val() }, function (data) {
                    $.each(data, function (index, value) {
                        var row = "";
                        row = "<tr data-partida='" + value.Id + "'><td>" + value.NumeroDePartida + "</td>";
                        row += "<td><select data-tipo='division' id='div_" + value.Id + "' class='form-control col-md-12'>";
                        $.each(value.DivisionesExtraPresupuestarias, function (index, division) {
                            row += "<option value='" + division.Id + "'>" + division.Nombre + "</option>";
                        });
                        row += "</td><td><input type='text' class='form-control' data-tipo='importe' id='importe_" + value.Id + "' value'0'></td></tr>";
                        p.Partidas.append(row);
                    });
                    $.get("Expedientes/Facturas/ObtenerAsiganacion", { id: that.ViewAsignar.Id.val() }, function (data) {
                        if (data) {
                            $.each(data, function (index, value) {
                                $("#importe_" + value.Partida).val(value.Importe);
                                $("#div_" + value.Partida).find("option[value=" + value.Division + "]").prop("selected", "selected");
                            });
                        }
                    });
                });
            };
            //--- Función editar de Datatable Facturas
            FacturasManager.prototype.editar_dtFacturas = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "Expedientes/Facturas/Editar/" + id, true, true, true);
            };
            FacturasManager.prototype.asignar_dtFacturas = function () {
                var id = this.ViewIndex.getData(0);
                var proveedor = this.ViewIndex.getData(5);
                app.modal.cargar("Asignar Factura de " + proveedor, "Expedientes/Facturas/Asignar/?factura=" + id);
                //app.createTab("Editar", "Facturas/Editar/" + id, true, true, true);
            };
            FacturasManager.prototype.asignar_dtFacturasSinAsignar = function () {
                var id = this.ViewSinAsignacion.getData(0);
                var proveedor = this.ViewSinAsignacion.getData(5);
                app.modal.cargar("Asignar Factura de " + proveedor, "Expedientes/Facturas/Asignar/?factura=" + id);
                //app.createTab("Editar", "Facturas/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable Facturas
            FacturasManager.prototype.eliminar_dtFacturas = function () {
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("Facturas/Eliminar", { id: id }, resultado).done(function () {
                    if (resultado.estado) {
                        app.crearNotificacionSuccess("Eliminar factura", "La factura ha sido eliminada satisfactoriamente");
                    }
                    else {
                        app.crearNotificacionError("Eliminar factura", "La factura no ha podido ser eliminada");
                    }
                });
            };
            FacturasManager.prototype.guardarImputacion = function (titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                var imputacion;
                imputacion = {
                    Factura: that.ViewAsignar.Id.val(),
                    FacturasImputadasDetalle: new Array()
                };
                that.ViewAsignar.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if ($el.find("td input").val()) {
                        var detalle;
                        detalle = {
                            Partida: $el.data("partida"),
                            Division: $el.find("select").val(),
                            Importe: $el.find("td input").val()
                        };
                        imputacion.FacturasImputadasDetalle.push(detalle);
                    }
                });
                console.log(imputacion);
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "Expedientes/Facturas/AsignarFactura",
                    data: JSON.stringify({ imputacion: imputacion }),
                    contentType: "application/json",
                    success: function (data) {
                        resultado.estado = data[0];
                        resultado.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            resultado.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        resultado.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            FacturasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                that.ViewCrear.Importe.val(that.ViewCrear.Importe.val().replace(".", ","));
                //if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: v.form.attr("action"),
                    data: v.form.serialize(),
                    success: function (data) {
                        resultado.estado = data[0];
                        resultado.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            resultado.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        resultado.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                //}
                return (df.promise());
            };
            FacturasManager.prototype.Actualizar = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                that.ViewEditar.Importe.val(that.ViewEditar.Importe.val().replace(".", ","));
                //if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: v.form.attr("action"),
                    data: v.form.serialize(),
                    success: function (data) {
                        resultado.estado = data[0];
                        resultado.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            resultado.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        resultado.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                //}
                return (df.promise());
            };
            FacturasManager.prototype.armarExpediente = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                var facturas = [];
                that.ViewArmarExpediente.body_facturas.find("tr[data-id]").each(function (i, v) {
                    if ($(v).find("td input:checkbox")[0].checked) {
                        facturas.push($(v).data("id"));
                        $("tr[data-factura=" + $(v).data("id") + "]").remove();
                        $(v).remove();
                    }
                });
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: "Expedientes/Facturas/ArmarExpediente",
                        data: JSON.stringify({ facturas: facturas }),
                        dataType: "json",
                        contentType: "application/json",
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            FacturasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            FacturasManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                resultado.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return FacturasManager;
        }()); //JS	
        ts.FacturasManager = FacturasManager;
        var FacturasCustom = /** @class */ (function () {
            function FacturasCustom() {
                this.Asignacion = [];
            }
            return FacturasCustom;
        }());
        var AsignacionCustom = /** @class */ (function () {
            function AsignacionCustom() {
            }
            return AsignacionCustom;
        }());
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {}));
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var SinAsignacion = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function SinAsignacion(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            SinAsignacion.prototype.limpiar = function () {
                this.dtSinAsignacion.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            SinAsignacion.prototype.setdtSinAsignacion = function (dt) {
                var that = this;
                this.dtSinAsignacion = dt;
                $("#dtSinAsignacion tbody").click(function (event) {
                    $(that.dtSinAsignacion.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.dtSinAsignacion.fnGetData($(event.target).closest("tr").index())[0];
                    that.Facturas_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            SinAsignacion.prototype.getData = function (col) {
                return (this.dtSinAsignacion.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            SinAsignacion.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            SinAsignacion.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return SinAsignacion;
        }()); //JS
        ts.SinAsignacion = SinAsignacion;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var SinOP = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function SinOP(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            SinOP.prototype.limpiar = function () {
                this.dtSinOP.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            SinOP.prototype.setdtSinAsignacion = function (dt) {
                var that = this;
                this.dtSinOP = dt;
                $("#dtSinOP tbody").click(function (event) {
                    $(that.dtSinOP.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.dtSinOP.fnGetData($(event.target).closest("tr").index())[0];
                    that.Facturas_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            SinOP.prototype.getData = function (col) {
                return (this.dtSinOP.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            SinOP.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            SinOP.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return SinOP;
        }()); //JS
        ts.SinOP = SinOP;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var FacturasImputadas;
(function (FacturasImputadas) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Factura = new SyncroAutocomplete("#Factura" + hash, "url");
                this.Fecha = $("#Fecha" + hash);
                this.AnioContable = $("#AnioContable" + hash);
                this.Partida = new SyncroAutocomplete("#Partida" + hash, "url");
                this.Division = $("#Division" + hash);
                this.Importe = $("#Importe" + hash);
                this.Agregar = $("#Agregar" + hash);
                this.Detalle = new SyncroTable($("#Detalle" + hash));
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Factura.txt.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Factura.limpiar();
                this.Fecha.val("");
                this.AnioContable.val("");
                this.Partida.limpiar();
                this.Division.val('').trigger("liszt:updated");
                this.Importe.val("");
                this.Agregar.val("");
                this.Detalle.limpiar();
            };
            //--- /Funciones para seteo de Datatables ---/
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = FacturasImputadas.ts || (FacturasImputadas.ts = {}));
})(FacturasImputadas || (FacturasImputadas = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var FacturasImputadas;
(function (FacturasImputadas) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Factura = $("#Factura" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.AnioContable = $("#AnioContable" + hash);
                this.Usuario = $("#Usuario" + hash);
                this.FechaElimina = $("#FechaElimina" + hash);
                this.UsuarioElimina = $("#UsuarioElimina" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Factura.val('').trigger("liszt:updated");
                this.Fecha.val("");
                this.AnioContable.val("");
                this.Usuario.val("");
                this.FechaElimina.val("");
                this.UsuarioElimina.val("");
            };
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = FacturasImputadas.ts || (FacturasImputadas.ts = {}));
})(FacturasImputadas || (FacturasImputadas = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var FacturasImputadas;
(function (FacturasImputadas) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.FacturasImputadas.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setFacturasImputadas = function (dt) {
                var that = this;
                this.FacturasImputadas = dt;
                $("#dtFacturasImputadas tbody").click(function (event) {
                    $(that.FacturasImputadas.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.FacturasImputadas.fnGetData($(event.target).closest("tr").index())[0];
                    that.FacturasImputadas_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = FacturasImputadas.ts || (FacturasImputadas.ts = {}));
})(FacturasImputadas || (FacturasImputadas = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var FacturasImputadas;
(function (FacturasImputadas) {
    var ts;
    (function (ts) {
        var FacturasImputadasManager = /** @class */ (function () {
            function FacturasImputadasManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            FacturasImputadasManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            FacturasImputadasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            FacturasImputadasManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Modificar título").done(function () {
                    });
                });
            };
            //--- Función editar de Datatable FacturasImputadas
            FacturasImputadasManager.prototype.editar_dtFacturasImputadas = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "FacturasImputadas/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable FacturasImputadas
            FacturasImputadasManager.prototype.eliminar_dtFacturasImputadas = function () {
                var id = this.ViewIndex.getData(0);
                this.eliminar("FacturasImputadas/Eliminar", { id: id });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            FacturasImputadasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            FacturasImputadasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            FacturasImputadasManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                resultado.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return FacturasImputadasManager;
        }()); //JS	
        ts.FacturasImputadasManager = FacturasImputadasManager;
    })(ts = FacturasImputadas.ts || (FacturasImputadas.ts = {}));
})(FacturasImputadas || (FacturasImputadas = {}));
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ImputacionesContables;
(function (ImputacionesContables) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.ExpedienteAImputar = $("#ExpedienteAImputar" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.FechaElimina = $("#FechaElimina" + hash);
                this.Operacion = $("#Operacion" + hash);
                this.ExpedienteIndirecto = $("#ExpedienteIndirecto" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.ExpedienteAImputar.val('').trigger("liszt:updated");
                this.Fecha.val("");
                this.UsuarioAlta.val("");
                this.FechaElimina.val("");
                this.Operacion.val('').trigger("liszt:updated");
                this.ExpedienteIndirecto.val('').trigger("liszt:updated");
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = ImputacionesContables.ts || (ImputacionesContables.ts = {}));
})(ImputacionesContables || (ImputacionesContables = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ImputacionesContables;
(function (ImputacionesContables) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.ImputacionesContables.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setImputacionesContables = function (dt) {
                var that = this;
                this.ImputacionesContables = dt;
                $("#dtImputacionesContables tbody").click(function (event) {
                    $(that.ImputacionesContables.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ImputacionesContables.fnGetData($(event.target).closest("tr").index())[0];
                    that.ImputacionesContables_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = ImputacionesContables.ts || (ImputacionesContables.ts = {}));
})(ImputacionesContables || (ImputacionesContables = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ImputacionesContables;
(function (ImputacionesContables) {
    var ts;
    (function (ts) {
        var Imputar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Imputar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.ExpedienteAImputar = new SyncroAutocomplete("#ExpedienteAImputar" + hash, "url");
                this.Fecha = $("#Fecha" + hash);
                this.Afectacion = $("#Afectacion" + hash);
                this.Compromiso = $("#Compromiso" + hash);
                this.OrdenadoAPagar = $("#OrdenadoAPagar" + hash);
                this.Partida = new SyncroAutocomplete("#Partida" + hash, "url");
                this.Division = $("#Division" + hash);
                this.Importe = $("#Importe" + hash);
                this.Agregar = $("#Agregar" + hash);
                this.Detalle = new SyncroTable($("#Detalle" + hash));
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.ExpedienteAImputar.focus();
            }
            Imputar.prototype.limpiar = function () {
                this.ExpedienteAImputar.limpiar();
                this.Fecha.val("");
                this.Afectacion.removeAttr('checked');
                this.Compromiso.removeAttr('checked');
                this.OrdenadoAPagar.removeAttr('checked');
                this.Partida.limpiar();
                this.Division.val('').trigger("liszt:updated");
                this.Importe.val("");
                this.Agregar.val("");
                this.Detalle.limpiar();
            };
            //--- Funciones para seteo de Datatables ---/
            Imputar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Imputar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Imputar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Imputar;
        }()); //JS
        ts.Imputar = Imputar;
    })(ts = ImputacionesContables.ts || (ImputacionesContables.ts = {}));
})(ImputacionesContables || (ImputacionesContables = {})); // module
/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Imputar.ts"/>
/// <reference path="Editar.ts"/>
var ImputacionesContables;
(function (ImputacionesContables) {
    var ts;
    (function (ts) {
        var ImputacionesContablesManager = /** @class */ (function () {
            function ImputacionesContablesManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            ImputacionesContablesManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Imputar
            ImputacionesContablesManager.prototype.setImputar = function (v) {
                var that = this;
                this.ViewImputar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewImputar, "Modificar título").done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewImputar, "Modificar título").done(function () {
                        that.ViewImputar.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            ImputacionesContablesManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Modificar título").done(function () {
                    });
                });
            };
            //--- Función editar de Datatable ImputacionesContables
            ImputacionesContablesManager.prototype.editar_dtImputacionesContables = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "ImputacionesContables/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable ImputacionesContables
            ImputacionesContablesManager.prototype.eliminar_dtImputacionesContables = function () {
                var id = this.ViewIndex.getData(0);
                this.eliminar("ImputacionesContables/Eliminar", { id: id });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ImputacionesContablesManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            ImputacionesContablesManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            ImputacionesContablesManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                res.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return ImputacionesContablesManager;
        }()); //JS	
        ts.ImputacionesContablesManager = ImputacionesContablesManager;
    })(ts = ImputacionesContables.ts || (ImputacionesContables.ts = {}));
})(ImputacionesContables || (ImputacionesContables = {}));
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/types/tinymce.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ModelosEscritoADM;
(function (ModelosEscritoADM) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Oficina = $("#OrganismosRef" + hash);
                this.Titulo = $("#Titulo" + hash);
                this.TipoActuacion = $("#TipoActuacion" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Tipo = $("#Tipo" + hash);
                this.RemoveTinymce();
                tinymce.init({
                    mode: "exact",
                    height: 600,
                    theme: 'modern',
                    language: "es",
                    selector: "textarea",
                    valid_elements: '*[*]',
                    valid_children: "+body[style], +style[type]",
                    //elements: "Contenido" + hash,                
                    plugins: [
                        'advlist autolink lists link image charmap print preview hr anchor pagebreak',
                        'searchreplace wordcount visualblocks visualchars code fullscreen',
                        'insertdatetime media nonbreaking save table contextmenu directionality',
                        'emoticons template paste textcolor colorpicker textpattern imagetools',
                        "responsivefilemanager customtemplate propiedades"
                    ],
                    content_css: [
                        //'//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
                        '/Scripts/a4.css'
                    ],
                    toolbar1: "responsivefilemanager insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | variables",
                    toolbar2: 'print preview media | forecolor backcolor emoticons | sizeselect | fontselect  fontsizeselect',
                    external_filemanager_path: "/filemanager/",
                    templates: [
                        { title: 'A4', content: '<body class="document" ><div class="page" contenteditable = "true" ></div></body>' },
                        { title: 'Test template 2', content: 'Test 2' }
                    ],
                    contextmenu: "link image inserttable | cell row column deletetable customtemplate propiedades",
                    //valid_elements: "a[onclick|style],strong/b,div,br,link,img",
                    filemanager_title: "Responsive Filemanager",
                    external_plugins: { "filemanager": "/filemanager/plugin.min.js" },
                    mentions: {
                        source: [
                            { name: 'Valor 1' },
                            { name: 'Valor 2' },
                            { name: 'Valor 3' },
                            { name: 'Valor4 ' }
                        ]
                    },
                    setup: function (editor) {
                        editor.addMenuItem('example', {
                            text: 'Abrir Word',
                            context: 'file',
                            onclick: function () {
                                app.modal.cargar("prueba", "/expedientes/ModelosEscritoADM/files");
                            }
                        });
                        editor.addMenuItem('paper', {
                            text: 'Papel',
                            context: 'format',
                            menu: [
                                {
                                    text: 'A4',
                                    onclick: function () {
                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                    }
                                },
                                {
                                    text: 'Legal',
                                    onclick: function () {
                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Fecha_Expediente]</a>');
                                    }
                                }
                            ]
                        });
                        editor.addMenuItem('orientation', {
                            text: 'Orientaciòn',
                            context: 'format',
                            menu: [
                                {
                                    text: 'Vertical',
                                    onclick: function () {
                                        //tinymce.dom.DomQuery("link[data-mce-href]").remove();
                                        //editor.dom.loadCSS("/scripts/a4l.css");
                                    }
                                },
                                {
                                    text: 'Horizontal',
                                    onclick: function () {
                                        editor.formatter.register('div.page', {
                                            inline: 'div',
                                            styles: { color: '#ff0000' }
                                        });
                                        editor.formatter.apply('div.page');
                                    }
                                }
                            ]
                        });
                        editor.addButton('variables', {
                            text: 'Variables',
                            type: 'menubutton',
                            icon: false,
                            menu: [
                                {
                                    text: 'Expedientes',
                                    menu: [
                                        {
                                            text: 'Numero',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.numero}}');
                                            }
                                        },
                                        {
                                            text: 'Fecha',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.fecha}}');
                                            }
                                        },
                                        {
                                            text: 'Fecha en letras',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.hoy_en_letras}}');
                                            }
                                        },
                                        {
                                            text: 'Caratula',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.caratula}}');
                                            }
                                        },
                                        {
                                            text: 'Iniciador',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.iniciador}}');
                                            }
                                        },
                                        {
                                            text: "Imputacion",
                                            menu: [
                                                {
                                                    text: 'Tabla detalle',
                                                    onclick: function () {
                                                        editor.insertContent('<table data-tipo="imputacion" border="0" width="95%"><tbody data-action="repeat"><tr data-action="repeat"><td width="80%">{{expediente.imputacion.partida}}</td><td width="20%">{{expediente.imputacion.importe}}</td></tr></tbody></table>');
                                                    }
                                                },
                                                {
                                                    text: 'Total imputado',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputaciones[0].total}}');
                                                    }
                                                },
                                                {
                                                    text: 'Total imputado en letra',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputaciones[0].total_en_letras}}');
                                                    }
                                                },
                                                {
                                                    text: 'Año contable',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputaciones[0].anio_contable}}');
                                                    }
                                                },
                                                {
                                                    text: 'Fecha en letras',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.fecha_letras}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Division',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.division}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Importe',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.importe}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Partida',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.partida}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Nombre de Partida',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.nombre_partida}}');
                                                    }
                                                },
                                            ]
                                        },
                                        {
                                            text: 'Agregar Campo',
                                            onclick: function () {
                                                bootbox.prompt("Ingrese el nombre del campo", function (result) {
                                                    editor.insertContent('<a href="#" data-type="text" data-pk="1" data-title="' + result + '">' + result + '</a>');
                                                });
                                            }
                                        }
                                    ]
                                }
                            ]
                        });
                    }
                });
                //tinymce.init({
                //    mode: "exact",
                //    height: 500,
                //    language: "es",
                //    selector: "textarea",
                //    //elements: "Contenido" + hash,                
                //    plugins: [
                //        "advlist autolink lists link image charmap print preview anchor mention",
                //        "searchreplace visualblocks code fullscreen",
                //        "insertdatetime media table contextmenu paste responsivefilemanager"
                //    ],
                //    toolbar: "responsivefilemanager insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | variables",
                //    external_filemanager_path: "/filemanager/",
                //    filemanager_title: "Responsive Filemanager",
                //    external_plugins: { "filemanager": "/filemanager/plugin.min.js" },
                //    mentions: {
                //        source: [
                //            { name: 'Tyra Porcelli' },
                //            { name: 'Brigid Reddish' },
                //            { name: 'Ashely Buckler' },
                //            { name: 'Teddy Whelan' }
                //        ]
                //    },
                //    setup: function (editor) {
                //        editor.addButton('variables',
                //            {
                //                text: 'Variables',
                //                type: 'menubutton',
                //                icon: false,
                //                menu: [
                //                    {
                //                        text: 'Expedientes',
                //                        menu: [
                //                            {
                //                                text: 'N�mero',
                //                                onclick: function () {
                //                                    editor.insertContent('[Numero]');
                //                                }
                //                            },
                //                            {
                //                                text: 'Fecha',
                //                                onclick: function () {
                //                                    editor.insertContent('[Fecha]');
                //                                }
                //                            },
                //                            {
                //                                text: 'Car�tula',
                //                                onclick: function () {
                //                                    editor.insertContent('[Caratula]');
                //                                }
                //                            },
                //                            {
                //                                text: 'Iniciador',
                //                                onclick: function () {
                //                                    editor.insertContent('[Iniciador]');
                //                                }
                //                            },
                //                            {
                //                                text: 'Total Imputado',
                //                                onclick: function () {
                //                                    editor.insertContent('[TotalImputado]');
                //                                }
                //                            },
                //                            {
                //                                text: '�ltimo total imputado',
                //                                onclick: function () {
                //                                    editor.insertContent('[UltimoTotalImputado]');
                //                                }
                //                            },
                //                        ]
                //                    },
                //                    {
                //                        text: 'Agregar Campo',
                //                        onclick: function () {
                //                            bootbox.prompt("Ingrese el nombre del campo", function (result) {
                //                                editor.insertContent('<a href="#" data-type="text" data-pk="1" data-title="'+result+'">'+result+'</a>');
                //                            });
                //                        }
                //                    }
                //                ]
                //            });
                //    }
                //});
                //Establece el foco
                this.Oficina.focus();
            }
            Crear.prototype.RemoveTinymce = function () {
                //if (tinymce.editors.length > 0) {
                //    for (i = 0; i < tinymce.editors.length; i++) {
                //        tinymce.editors[i].remove();
                //    }
                //}
            };
            Crear.prototype.limpiar = function () {
                this.Oficina.val('').trigger("liszt:updated");
                this.Titulo.val("");
                this.TipoActuacion.val('').trigger("liszt:updated");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = ModelosEscritoADM.ts || (ModelosEscritoADM.ts = {}));
})(ModelosEscritoADM || (ModelosEscritoADM = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ModelosEscritoADM;
(function (ModelosEscritoADM) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Oficina = $("#Oficina" + hash);
                this.Titulo = $("#Titulo" + hash);
                this.TipoActuacion = $("#TipoActuacion" + hash);
                this.Contenido = $("#Contenido" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                tinymce.init({
                    mode: "exact",
                    height: 600,
                    theme: 'modern',
                    language: "es",
                    selector: "textarea",
                    valid_elements: '*[*]',
                    valid_children: "+body[style], +style[type]",
                    //elements: "Contenido" + hash,                
                    plugins: [
                        'advlist autolink lists link image charmap print preview hr anchor pagebreak',
                        'searchreplace wordcount visualblocks visualchars code fullscreen',
                        'insertdatetime media nonbreaking save table contextmenu directionality',
                        'emoticons template paste textcolor colorpicker textpattern imagetools',
                        "responsivefilemanager customtemplate propiedades"
                    ],
                    content_css: [
                        //'//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
                        '/Scripts/a4.css'
                    ],
                    toolbar1: "responsivefilemanager insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | variables",
                    toolbar2: 'print preview media | forecolor backcolor emoticons | sizeselect | fontselect  fontsizeselect',
                    external_filemanager_path: "/filemanager/",
                    templates: [
                        { title: 'A4', content: '<body class="document" ><div class="page" contenteditable = "true" ></div></body>' },
                        { title: 'Test template 2', content: 'Test 2' }
                    ],
                    contextmenu: "link image inserttable | cell row column deletetable customtemplate propiedades",
                    //valid_elements: "a[onclick|style],strong/b,div,br,link,img",
                    filemanager_title: "Responsive Filemanager",
                    external_plugins: { "filemanager": "/filemanager/plugin.min.js" },
                    mentions: {
                        source: [
                            { name: 'Valor 1' },
                            { name: 'Valor 2' },
                            { name: 'Valor 3' },
                            { name: 'Valor4 ' }
                        ]
                    },
                    setup: function (editor) {
                        editor.addMenuItem('example', {
                            text: 'Abrir Word',
                            context: 'file',
                            onclick: function () {
                                app.modal.cargar("prueba", "/expedientes/ModelosEscritoADM/files");
                            }
                        });
                        editor.addMenuItem('paper', {
                            text: 'Papel',
                            context: 'format',
                            menu: [
                                {
                                    text: 'A4',
                                    onclick: function () {
                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                    }
                                },
                                {
                                    text: 'Legal',
                                    onclick: function () {
                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Fecha_Expediente]</a>');
                                    }
                                }
                            ]
                        });
                        editor.addMenuItem('orientation', {
                            text: 'Orientación',
                            context: 'format',
                            menu: [
                                {
                                    text: 'Vertical',
                                    onclick: function () {
                                        //tinymce.dom.DomQuery("link[data-mce-href]").remove();
                                        //editor.dom.loadCSS("/scripts/a4l.css");
                                    }
                                },
                                {
                                    text: 'Horizontal',
                                    onclick: function () {
                                        editor.formatter.register('div.page', {
                                            inline: 'div',
                                            styles: { color: '#ff0000' }
                                        });
                                        editor.formatter.apply('div.page');
                                    }
                                }
                            ]
                        });
                        editor.addButton('variables', {
                            text: 'Variables',
                            type: 'menubutton',
                            icon: false,
                            menu: [
                                {
                                    text: 'Expedientes',
                                    menu: [
                                        {
                                            text: 'Numero',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.numero}}');
                                            }
                                        },
                                        {
                                            text: 'Fecha',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.fecha}}');
                                            }
                                        },
                                        {
                                            text: 'Fecha en letras',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.hoy_en_letras}}');
                                            }
                                        },
                                        {
                                            text: 'Caratula',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.caratula}}');
                                            }
                                        },
                                        {
                                            text: 'Iniciador',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.iniciador}}');
                                            }
                                        },
                                        {
                                            text: "Imputacion",
                                            menu: [
                                                {
                                                    text: 'Tabla detalle',
                                                    onclick: function () {
                                                        editor.insertContent('<table data-tipo="imputacion" border="0" width="95%"><tbody data-action="repeat"><tr data-action="repeat"><td width="80%">{{expediente.imputacion.partida}}</td><td width="20%">{{expediente.imputacion.importe}}</td></tr></tbody></table>');
                                                    }
                                                },
                                                {
                                                    text: 'Total imputado',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputaciones[0].total}}');
                                                    }
                                                },
                                                {
                                                    text: 'Total imputado en letra',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputaciones[0].total_en_letras}}');
                                                    }
                                                },
                                                {
                                                    text: 'Año contable',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputaciones[0].anio_contable}}');
                                                    }
                                                },
                                                {
                                                    text: 'Fecha en letras',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.fecha_letras}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Division',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.division}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Importe',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.importe}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Partida',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.partida}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Nombre de Partida',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.nombre_partida}}');
                                                    }
                                                },
                                            ]
                                        },
                                        {
                                            text: "Facturas",
                                            menu: [
                                                {
                                                    text: 'Tabla detalle',
                                                    onclick: function () {
                                                        editor.insertContent('<table data-tipo="factura" border="0" width="95%"><tbody data-action="repeat"><tr data-action="repeat" data-tipo="proveedor" data-sum="importe"><td colspan="3" width="100%">{{expediente.imputacion.facturas.nombre_proveedor}}</td></tr><tr data-tipo="detalle"><td>{{expediente.imputacion.facturas.numero}}</td><td>{{expediente.imputacion.facturas.concepto}}</td><td align="left">{{expediente.imputacion.facturas.importe}}</td></tr><tr data-tipo="factura" data-action="total"><td colspan="3" align="rigth">{{sum(expediente.imputacion.facturas.importe)}}</td></tr></tbody></table>');
                                                    }
                                                },
                                                {
                                                    text: 'Numero',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.numero}}');
                                                    }
                                                },
                                                {
                                                    text: 'Proveedor',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.nombre_proveedor}}');
                                                    }
                                                },
                                                {
                                                    text: 'Importe',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.importe}}');
                                                    }
                                                },
                                                {
                                                    text: 'Fecha',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.fecha}}');
                                                    }
                                                },
                                                {
                                                    text: 'Descripcion',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.concepto}}');
                                                    }
                                                },
                                            ]
                                        }
                                    ]
                                },
                                {
                                    text: 'Agregar Campo',
                                    onclick: function () {
                                        bootbox.prompt("Ingrese el nombre del campo", function (result) {
                                            editor.insertContent('<a href="#" data-type="text" data-pk="1" data-title="' + result + '">' + result + '</a>');
                                        });
                                    }
                                }
                            ]
                        });
                    }
                });
                //Establece el foco
                this.Titulo.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Oficina.val('').trigger("liszt:updated");
                this.Titulo.val("");
                this.TipoActuacion.val('').trigger("liszt:updated");
                this.Contenido.val("");
                this.FechaAlta.val("");
            };
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = ModelosEscritoADM.ts || (ModelosEscritoADM.ts = {}));
})(ModelosEscritoADM || (ModelosEscritoADM = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ModelosEscritoADM;
(function (ModelosEscritoADM) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.ModelosEscritoADM.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setModelosEscritoADM = function (dt) {
                var that = this;
                this.ModelosEscritoADM = dt;
                $("#dtModelosEscritoADM tbody").click(function (event) {
                    $(that.ModelosEscritoADM.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ModelosEscritoADM.fnGetData($(event.target).closest("tr").index())[0];
                    that.ModelosEscritoADM_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.ModelosEscritoADM.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = ModelosEscritoADM.ts || (ModelosEscritoADM.ts = {}));
})(ModelosEscritoADM || (ModelosEscritoADM = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var ModelosEscritoADM;
(function (ModelosEscritoADM) {
    var ts;
    (function (ts) {
        var ModelosEscritoADMManager = /** @class */ (function () {
            function ModelosEscritoADMManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            ModelosEscritoADMManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ModelosEscritoADMManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Oficina.find("option[value=" + app.global.organismo + "]").prop("selected", "selected");
                v.Oficina.trigger("liszt:updated");
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    tinymce.triggerSave();
                    var data = v.form.serializeObject();
                    that.ajaxPostURL("ModelosEscritoADM/Crear", data, "Guardar Modelo", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewIndex.ModelosEscritoADM.fnDraw();
                            app.irATab(0);
                            v.limpiar();
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    tinymce.triggerSave();
                    that.ajaxPost(that.ViewCrear, "Guardar Modelo", resultado).done(function () {
                        that.ViewCrear.limpiar();
                        v.Titulo.focus();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            ModelosEscritoADMManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista			
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    tinymce.triggerSave();
                    var data = v.form.serializeObject();
                    that.ajaxPostURL("ModelosEscritoADM/Editar", data, "Guardar Modelo", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewIndex.ModelosEscritoADM.fnDraw();
                            app.closeCurrentTab();
                            app.irATab(0);
                        }
                    });
                });
            };
            //--- Función editar de Datatable ModelosEscritoADM
            ModelosEscritoADMManager.prototype.editar_dtModelosEscritoADM = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "Expedientes/ModelosEscritoADM/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable ModelosEscritoADM
            ModelosEscritoADMManager.prototype.eliminar_dtModelosEscritoADM = function () {
                var self = this;
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("ModelosEscritoADM/Eliminar", { id: id }, resultado).done(function () {
                    if (resultado.estado)
                        self.ViewIndex.ModelosEscritoADM.fnDraw();
                });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ModelosEscritoADMManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                                resultado.anexos.texto = data[3];
                                resultado.anexos.modelo = data[4];
                                resultado.anexos.fecha = data[5];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            ModelosEscritoADMManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    //traditional:true,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            ModelosEscritoADMManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar este modelo?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                resultado.mensaje = data[1];
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return ModelosEscritoADMManager;
        }()); //JS	
        ts.ModelosEscritoADMManager = ModelosEscritoADMManager;
    })(ts = ModelosEscritoADM.ts || (ModelosEscritoADM.ts = {}));
})(ModelosEscritoADM || (ModelosEscritoADM = {}));
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Proveedores;
(function (Proveedores) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.CUIT = $("#CUIT" + hash);
                this.Nombre = $("#Nombre" + hash);
                this.RazonSocial = $("#RazonSocial" + hash);
                this.NumeroAcreedor = $("#NumeroAcreedor" + hash);
                this.NombreFantasia = $("#NombreFantasia" + hash);
                this.DomicilioReal = $("#DomicilioReal" + hash);
                this.CodigoPostal = $("#CodigoPostal" + hash);
                this.IngresosBrutos = $("#IngresosBrutos" + hash);
                this.ExentoGanancias = $("#ExentoGanancias" + hash);
                this.ExentoIngresosBrutos = $("#ExentoIngresosBrutos" + hash);
                this.AjustePorInflacion = $("#AjustePorInflacion" + hash);
                this.ExentoSellos = $("#ExentoSellos" + hash);
                this.InscriptoEnGanancias = $("#InscriptoEnGanancias" + hash);
                this.FechaInscripcion = $("#FechaInscripcion" + hash);
                this.FechaReInscripcion = $("#FechaReInscripcion" + hash);
                this.FechaFinExentoSellado = $("#FechaFinExentoSellado" + hash);
                this.FechaFinSuspension = $("#FechaFinSuspension" + hash);
                this.FechaFinExentoGanancias = $("#FechaFinExentoGanancias" + hash);
                this.FechaFinExentoIngresosBrutos = $("#FechaFinExentoIngresosBrutos" + hash);
                this.FormaDePago = $("#FormaDePago" + hash);
                this.NumeroDeCuenta = $("#NumeroDeCuenta" + hash);
                this.CBU = $("#CBU" + hash);
                this.TipoDeCuenta = $("#TipoDeCuenta" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.CUIT.focus();
            }
            Crear.prototype.limpiar = function () {
                this.CUIT.val("");
                this.Nombre.val("");
                this.RazonSocial.val("");
                this.NumeroAcreedor.val("");
                this.NombreFantasia.val("");
                this.DomicilioReal.val("");
                this.CodigoPostal.val("");
                this.IngresosBrutos.val("");
                this.ExentoGanancias.removeAttr('checked');
                this.ExentoIngresosBrutos.removeAttr('checked');
                this.AjustePorInflacion.removeAttr('checked');
                this.ExentoSellos.removeAttr('checked');
                this.InscriptoEnGanancias.removeAttr('checked');
                this.FechaInscripcion.val("");
                this.FechaReInscripcion.val("");
                this.FechaFinExentoSellado.val("");
                this.FechaFinSuspension.val("");
                this.FechaFinExentoGanancias.val("");
                this.FechaFinExentoIngresosBrutos.val("");
                this.FormaDePago.val('').trigger("liszt:updated");
                this.NumeroDeCuenta.val("");
                this.CBU.val("");
                this.TipoDeCuenta.val('').trigger("liszt:updated");
            };
            //--- Funciones para seteo de Datatables ---/
            Crear.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = Proveedores.ts || (Proveedores.ts = {}));
})(Proveedores || (Proveedores = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Proveedores;
(function (Proveedores) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombre = $("#Nombre" + hash);
                this.NumeroAcreedor = $("#NumeroAcreedor" + hash);
                this.RazonSocial = $("#RazonSocial" + hash);
                this.NombreFantasia = $("#NombreFantasia" + hash);
                this.DomicilioReal = $("#DomicilioReal" + hash);
                this.CodigoPostal = $("#CodigoPostal" + hash);
                this.CUIT = $("#CUIT" + hash);
                this.IngresosBrutos = $("#IngresosBrutos" + hash);
                this.ExentoGanancias = $("#ExentoGanancias" + hash);
                this.ExentoIngresosBrutos = $("#ExentoIngresosBrutos" + hash);
                this.InscriptoEnGanancias = $("#InscriptoEnGanancias" + hash);
                this.Estado = $("#Estado" + hash);
                this.FechaInscripcion = $("#FechaInscripcion" + hash);
                this.FechaReInscripcion = $("#FechaReInscripcion" + hash);
                this.FechaFinExentoSellado = $("#FechaFinExentoSellado" + hash);
                this.FechaFinSuspension = $("#FechaFinSuspension" + hash);
                this.FechaFinExentoGanancias = $("#FechaFinExentoGanancias" + hash);
                this.FechaFinExentoIngresosBrutos = $("#FechaFinExentoIngresosBrutos" + hash);
                this.FechaBaja = $("#FechaBaja" + hash);
                this.ExentoSellos = $("#ExentoSellos" + hash);
                this.AjustePorInflacion = $("#AjustePorInflacion" + hash);
                this.FormaDePago = $("#FormaDePago" + hash);
                this.NumeroDeCuenta = $("#NumeroDeCuenta" + hash);
                this.CBU = $("#CBU" + hash);
                this.TipoDeCuenta = $("#TipoDeCuenta" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                this.FechaModifica = $("#FechaModifica" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.UsuarioBaja = $("#UsuarioBaja" + hash);
                this.UsuarioModifica = $("#UsuarioModifica" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombre.val("");
                this.NumeroAcreedor.val("");
                this.RazonSocial.val("");
                this.NombreFantasia.val("");
                this.DomicilioReal.val("");
                this.CodigoPostal.val("");
                this.CUIT.val("");
                this.IngresosBrutos.val("");
                this.ExentoGanancias.removeAttr('checked');
                this.ExentoIngresosBrutos.removeAttr('checked');
                this.InscriptoEnGanancias.removeAttr('checked');
                this.Estado.val("");
                this.FechaInscripcion.val("");
                this.FechaReInscripcion.val("");
                this.FechaFinExentoSellado.val("");
                this.FechaFinSuspension.val("");
                this.FechaFinExentoGanancias.val("");
                this.FechaFinExentoIngresosBrutos.val("");
                this.FechaBaja.val("");
                this.ExentoSellos.removeAttr('checked');
                this.AjustePorInflacion.removeAttr('checked');
                this.FormaDePago.val('').trigger("liszt:updated");
                this.NumeroDeCuenta.val("");
                this.CBU.val("");
                this.TipoDeCuenta.val('').trigger("liszt:updated");
                this.FechaAlta.val("");
                this.FechaModifica.val("");
                this.UsuarioAlta.val("");
                this.UsuarioBaja.val("");
                this.UsuarioModifica.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = Proveedores.ts || (Proveedores.ts = {}));
})(Proveedores || (Proveedores = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Proveedores;
(function (Proveedores) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.Proveedores.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setProveedores = function (dt) {
                var that = this;
                this.Proveedores = dt;
                $("#dtProveedores tbody").click(function (event) {
                    $(that.Proveedores.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.Proveedores.fnGetData($(event.target).closest("tr").index())[0];
                    that.Proveedores_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = Proveedores.ts || (Proveedores.ts = {}));
})(Proveedores || (Proveedores = {})); // module
/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var Proveedores;
(function (Proveedores) {
    var ts;
    (function (ts) {
        var ProveedoresManager = /** @class */ (function () {
            function ProveedoresManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            ProveedoresManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ProveedoresManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            ProveedoresManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Modificar título").done(function () {
                    });
                });
            };
            //--- Función editar de Datatable Proveedores
            ProveedoresManager.prototype.editar_dtProveedores = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "Proveedores/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable Proveedores
            ProveedoresManager.prototype.eliminar_dtProveedores = function () {
                var id = this.ViewIndex.getData(0);
                this.eliminar("Proveedores/Eliminar", { id: id });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ProveedoresManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            ProveedoresManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            ProveedoresManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                res.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return ProveedoresManager;
        }()); //JS	
        ts.ProveedoresManager = ProveedoresManager;
    })(ts = Proveedores.ts || (Proveedores.ts = {}));
})(Proveedores || (Proveedores = {}));
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var UnidadesDeOrganizacionRef;
(function (UnidadesDeOrganizacionRef) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Nombre = $("#Nombre" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Nombre.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Nombre.val("");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = UnidadesDeOrganizacionRef.ts || (UnidadesDeOrganizacionRef.ts = {}));
})(UnidadesDeOrganizacionRef || (UnidadesDeOrganizacionRef = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var UnidadesDeOrganizacionRef;
(function (UnidadesDeOrganizacionRef) {
    var ts;
    (function (ts) {
        var Detalle = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Detalle(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombre = $("#Nombre" + hash);
                //operaciones
                //Establece el foco
                this.Id.focus();
            }
            Detalle.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombre.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Detalle.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Detalle.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Detalle.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Detalle;
        }()); //JS
        ts.Detalle = Detalle;
    })(ts = UnidadesDeOrganizacionRef.ts || (UnidadesDeOrganizacionRef.ts = {}));
})(UnidadesDeOrganizacionRef || (UnidadesDeOrganizacionRef = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var UnidadesDeOrganizacionRef;
(function (UnidadesDeOrganizacionRef) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombre = $("#Nombre" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombre.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = UnidadesDeOrganizacionRef.ts || (UnidadesDeOrganizacionRef.ts = {}));
})(UnidadesDeOrganizacionRef || (UnidadesDeOrganizacionRef = {})); // module
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var UnidadesDeOrganizacionRef;
(function (UnidadesDeOrganizacionRef) {
    var ts;
    (function (ts) {
        var Eliminar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Eliminar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombre = $("#Nombre" + hash);
                //operaciones
                //Establece el foco
                this.Id.focus();
            }
            Eliminar.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombre.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Eliminar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Eliminar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Eliminar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Eliminar;
        }()); //JS
        ts.Eliminar = Eliminar;
    })(ts = UnidadesDeOrganizacionRef.ts || (UnidadesDeOrganizacionRef.ts = {}));
})(UnidadesDeOrganizacionRef || (UnidadesDeOrganizacionRef = {})); // module
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var UnidadesDeOrganizacionRef;
(function (UnidadesDeOrganizacionRef) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.UnidadesDeOrganizacionRef.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setUnidadesDeOrganizacionRef = function (dt) {
                var that = this;
                this.UnidadesDeOrganizacionRef = dt;
                $("#dtUnidadesDeOrganizacionRef tbody").click(function (event) {
                    $(that.UnidadesDeOrganizacionRef.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.UnidadesDeOrganizacionRef.fnGetData($(event.target).closest("tr").index())[0];
                    that.UnidadesDeOrganizacionRef_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.UnidadesDeOrganizacionRef.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = UnidadesDeOrganizacionRef.ts || (UnidadesDeOrganizacionRef.ts = {}));
})(UnidadesDeOrganizacionRef || (UnidadesDeOrganizacionRef = {})); // module
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="Eliminar.ts"/>
/// <reference path="Detalle.ts"/>
var UnidadesDeOrganizacionRef;
(function (UnidadesDeOrganizacionRef) {
    var ts;
    (function (ts) {
        var UnidadesDeOrganizacionRefManager = /** @class */ (function () {
            function UnidadesDeOrganizacionRefManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            UnidadesDeOrganizacionRefManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            UnidadesDeOrganizacionRefManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            UnidadesDeOrganizacionRefManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Modificar título").done(function () {
                    });
                });
            };
            //--- Inicialización de la vista Eliminar
            UnidadesDeOrganizacionRefManager.prototype.setEliminar = function (v) {
                var that = this;
                this.ViewEliminar = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Detalle
            UnidadesDeOrganizacionRefManager.prototype.setDetalle = function (v) {
                var that = this;
                this.ViewDetalle = v;
                // Eventos de la vista
            };
            //--- Función editar de Datatable UnidadesDeOrganizacionRef
            UnidadesDeOrganizacionRefManager.prototype.editar_dtUnidadesDeOrganizacionRef = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "UnidadesDeOrganizacionRef/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable UnidadesDeOrganizacionRef
            UnidadesDeOrganizacionRefManager.prototype.eliminar_dtUnidadesDeOrganizacionRef = function () {
                var id = this.ViewIndex.getData(0);
                this.eliminar("UnidadesDeOrganizacionRef/Eliminar", { id: id });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            UnidadesDeOrganizacionRefManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            UnidadesDeOrganizacionRefManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            UnidadesDeOrganizacionRefManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                res.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return UnidadesDeOrganizacionRefManager;
        }()); //JS	
        ts.UnidadesDeOrganizacionRefManager = UnidadesDeOrganizacionRefManager;
    })(ts = UnidadesDeOrganizacionRef.ts || (UnidadesDeOrganizacionRef.ts = {}));
})(UnidadesDeOrganizacionRef || (UnidadesDeOrganizacionRef = {}));
