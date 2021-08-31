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

class AppManager {

    public tab: JQuery;
    public page_container: JQuery;
    public controlador: any;
    public tab_count: number;
    public tab_previo: number[];
    public tabs: SyncroTab;
    public block: SyncroBlock;
    public modal: SyncroModal;
    public hub: any;
    public global: Global;
    public current_view: string;

    //public controller: any; 

    constructor() {

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
        }

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

    public byString(o: Object, s: string): string {
        s = s.replace(/\[(\w+)\]/g, '.$1'); // convert indexes to properties
        s = s.replace(/^\./, '');           // strip a leading dot
        var a = s.split('.');
        for (var i = 0, n = a.length; i < n; ++i) {
            var k = a[i];
            if (k in o) {
                o = o[k];
            } else {
                return;
            }
        }
        return o.toString();
    }

    public initSignalR() {
        var self = this;
        this.hub = $.connection.serviciosHub;
        $.connection.hub.logging = true;

        self.hub.client.recibirMensaje = function (x: string) {
            alert(x);
        };

        self.hub.client.mostrarNotificacionPorOrganismo = function (title:string, x: string, oficina: number) {
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
                $("#notificaciones_lista").append("<li><a href='#' onclick='abrir(this)'><span class='task'>"+title+"</span></a></li>");
                $("#notificaciones_total").html(tot.toString());
                
                if (tot == 0) {
                    $("#badge_notificaciones").hide('slow');
                } else {
                    $("#badge_notificaciones").show('slow');
                }

            }
        };

        $.connection.hub.start().done(function () { console.log("Conectado con signalR...") });
    }

    public desktopNotification(message: string, onclick: () => void ) {

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

    }

    public currentTab(): number {
        return ($('.ui-tabs-panel:not(.ui-tabs-hide)').parent("li").index());
    }

    public currentTabIndex(): number {
        return ($('.ui-tabs-active').index());
    }

    public closeCurrentTab() {
        this.closeTab($("#tabs li.active").find("a"));
    }

    public reloadCurrentTab(): JQueryDeferred {
        var def = $.Deferred();
        var url = $("#tabs li.active").find("a").data("url");
        var index = $("#tabs li.active").find("a").data("index");
        $("#tab-" + index).empty().load($("#a-" + index).data("url"), function () { def.resolve(); });
        return def;
    }

    public setActiveTab(el: JQuery): JQueryDeferred {

        var def = $.Deferred();

        var load: boolean = $(el).data("load");
        //console.log("load: " + load);
        var cache: boolean = $(el).data("cache");
        var cargar: boolean = false;
        this.tab_previo.push($("ul.nav-tabs li.active").find("a").data("index"));

        $('ul.nav-tabs li.active').removeClass('active');
        if ($(el).prop("tagName") != "LI") {
            $(el).parent('li').addClass('active');
        } else {
            $(el).addClass('active');
        }
        //actualizar la referencia al form en el Controlador Javascript en el caso que la página esté cacheada

        if ($(el).data("cache") == "false") {
            this.Bloquear();
        } else {
            if ($(el).data("load") == "false") {
                this.Desbloquear();
                $(el).data("load", "true");
            }
        }

        var index: number = $(el).data("index")

        if (!load) {
            cargar = true;
            $(el).data("load", true);
        } else {
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
    }

    public closeTab(el: JQuery) {
        //$($(el).closest("li").find("a").data("href")).remove();
        //$(el).closest("li").remove();
        ////(this.tab_previo >= 0) ? this.setActiveTab($("#a-" + this.tab_previo)) : this.setActiveTab($("#a-0")); 
        //this.setActiveTab($("#a-" + this.tab_previo.pop()));
        //this.tab_count--;
        this.tabs.cerrarTab(el);
    }

    public mensajex(): void {
        alert("mensaje de prueba desde app");
    }

    public inicializarTab() {

        var primero: boolean = true;
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
    }

    public showTab(index: number): void {

        //oculta todos los contenedores
        $("div[data-type=contenedor]").hide();
        //muestra el indice seleccionado
        $($("#tabs ul > li:eq(" + index + ")").find("a").data("href")).show();
    }

    public irATab(index: number, load?: boolean): any {
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
    }

    public createTab(titulo: string, url: string, cache: boolean, close: boolean, redirect: boolean, load?: boolean): JQueryDeferred {

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
    }

    public existsTab(nombre: string): boolean {
        var existe: boolean = false;
        $('#tabs ul li a').each(function (i) {
            if (this.text == nombre) {
                existe = true;
            }
        });
        return (existe);
    }

    public postCall(form: JQuery, funcok?: (r?: any) => any) {
        var that = this;
        form.validate();
        var success = false;
        var retorno: number = 0;
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
                    } else {
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
    }

    public listTab() {
        this.tab.tabs('select', 0);
    }

    public selectTab(i: number) {
        this.tab.tabs('select', i);
        //alert($("#tabs ul li").eq(1).prop("tabindex"));
        this.setActiveTab($("#tabs ul li").eq(i));
    }

    //public closeMe(el) {
    //    this.closeCurrentTab($(el).closest('li').index());
    //    this.listTab();
    //}

    /* Get the rows which are currently selected */
    public fnGetSelected(oTableLocal: DataTables.DataTable): any[] {
        var aReturn = new Array();
        var aTrs = oTableLocal.fnGetNodes();

        for (var i = 0; i < aTrs.length; i++) {
            if ($(aTrs[i]).hasClass('row_selected')) {
                aReturn.push(aTrs[i]);
            }
        }
        return aReturn;
    }

    public Bloquear(centerY?: boolean) {

        var el: JQuery;
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
    }

    public Desbloquear() {
        var el: JQuery;
        el = this.page_container;
        $(this.page_container).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    }

    public crearNotificacionSuccess(titulo: string, mensaje: string): void {
        toastr.success(mensaje, titulo, { showEasing: "swing", showDuration: 1500, hideDuration: 7000, timeOut: 1500, positionClass: "toast-top-right", extendedTimeOut: 1500, hideEasing: "linear", showMethod: "fadeIn" });
    }

    public crearNotificacionError(titulo: string, mensaje: string): void {
        toastr.error(mensaje, titulo, { showEasing: "swing", showDuration: 1500, hideDuration: 80000, timeOut: 1500, positionClass: "toast-top-right", extendedTimeOut: 1500, hideEasing: "linear", showMethod: "fadeIn" });
    }

    public crearNotificacionWarning(titulo: string, mensaje: string): void
    {
        toastr.warning(mensaje, titulo), { showEasing: "swing", showDuration: 1500, hideDuration: 80000, timeOut: 1500, positionClass: "toast-top-right", extendedTimeOut: 1500, hideEasing: "linear", showMethod: "fadeIn" };
    }

    public crearNotificacionInfo(titulo: string, mensaje: string): void {
        toastr.info(mensaje, titulo, { showEasing: "swing", showDuration: 1500, hideDuration: 7000, timeOut: 1500, positionClass: "toast-top-right", extendedTimeOut: 1500, hideEasing: "linear", showMethod: "fadeIn" });
    }


    public confirmacionSiNo(mensaje: string, func: (r: boolean) => any): void {
        bootbox.confirm(mensaje, function (result) {
            func(result);
        });
    }

    public formatearFecha(date: string): string {
        //debugger;
        console.log("fecha: ");
        console.log(date);
        if (date != null) {
            var d: Date;
            var x: string = date.toString();
            if (x.indexOf("Date") > 0) {
                d = new Date(parseInt(date.substr(6)));
            }
            else
                d = new Date(date);

            var month = '' + (d.getMonth() + 1),
                day = '' + d.getDate(),
                year = d.getFullYear();

            if (month.length < 2) month = '0' + month;
            if (day.length < 2) day = '0' + day;

            return [day, month, year].join('/');
        } else
            return "";
    }

    public formatearFechaYHora(date: string): string {
        //debugger;
        console.log("fecha: ");
        console.log(date);
        if (date != null) {
            var d: Date;
            var x: string = date.toString();
            if (x.indexOf("Date") > 0) {
                d = new Date(parseInt(date.substr(6)));
            }
            else
                d = new Date(date);

            var month = '' + (d.getMonth() + 1),
                day = '' + d.getDate(),
                year = d.getFullYear(),
                minutes = d.getMinutes(),
                hour = d.getHours();

            if (month.length < 2) month = '0' + month;
            if (day.length < 2) day = '0' + day;

            var fecha = [day, month, year].join('/') + ' ' + (hour < 10 ? '0' + hour : hour) + ":" + (minutes < 10 ? '0' + minutes : minutes);

            return fecha;
        } else
            return "";
    }

    public setDecimal(numero: string): number {
        var res = parseFloat(numero.replace(",", "."));

        if (isNaN(res))
            return 0;
        else
            return res;
    }

    public postify(value) {
        var result = {};

        var buildResult = function (object, prefix) {
            for (var key in object) {

                var postKey = isFinite(+key)
                    ? (prefix != "" ? prefix : "") + "[" + key + "]"
                    : (prefix != "" ? prefix + "." : "") + key;

                switch (typeof (object[key])) {
                    case "number": case "string": case "boolean":
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
    }

    public getManager(name: string) {
        return window["o" + name];
    }

    public mapByNamePost(url: string, data: any): JQueryDeferred {
        var el: JQuery;
        var def = $.Deferred();
        $.post(url, data).done(function (result) {
            $.each(result, function (key, value) {
                el = $("[name=" + key + "]");
                el.each(function () {
                    if ($(this).is("input")) {
                        $(this).val(value);
                    } else {
                        $(this).html(value);
                    }
                });
            }); def.resolve();
        });
        return def.promise();
    }

    public mapByNameGet(url: string, data: any) {
        var el: JQuery;
        $.get(url, data).done(function (result) {
            $.each(result, function (key, value) {
                el = $("[name=" + key + "]");
                el.each(function () {
                    if ($(this).is("input")) {
                        $(this).val(value);
                    } else {
                        $(this).html(value);
                    }
                });
            });
        });
    }

    public elementVisible(element, valorScroll) {
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
    }

    public getData(url: string, data?: any): JQueryDeferred {

        var r: any;
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
        })).done(function (response) { df.resolve(response) })
            .fail(function () { df.reject() });

        return df;

    }

    public getAllUrlParams(url?: string) : any {

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
                // if array index number specified...
                else {
                    // put the value at that index number
                    obj[paramName][paramNum] = paramValue;
                }
            }
            // if param name doesn't exist yet, set it
            else {
                obj[paramName] = paramValue;
            }
        }
    }

    return obj;
}


    public setValidadorDecimal() {
        jQuery.extend(jQuery.validator.methods, {
            decimal: function (value, element) {
                return this.optional(element)
                    || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:[,.]\d+)?$/.test(value);
            }
        });
    }

}


class SyncroBlock {

    public container: JQuery;

    constructor(container: JQuery) {
        var that = this;
        this.container = container;
    }

    public Bloquear(container?: JQuery) {

        var centerY;
        var el: JQuery;
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
    }

    public Desbloquear() {
        var el: JQuery;
        el = this.container;
        $(this.container).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    }

};

class SyncroTab {

    public id: string;
    public tab_count: number;
    public block: SyncroBlock;

    constructor(id: string, block: SyncroBlock) {
        this.id = id;
        this.tab_count = 0;
        this.block = block;
    }

    //jtabs: [{item.label, item.url, item.close, item.cache}, {...} ...]
    public iniciarTab(jtabs: any): void {
        var arr: ItemMenu[];
        var that = this;
        var primero = true;
        arr = JSON.parse(jtabs);
        $.each(arr, function (i, item: ItemMenu) {
            that.crearTab(item, primero);
            primero = false;
        });
        this.activarTab($("#tabs ul > li:eq(0)").find("a"));
    }

    public reloadCurrent(): JQueryDeferred {
        var def = $.Deferred();
        var index = $("#ul li.active").find("a").data("index");
        app.Bloquear();        
        $("#tab-" + index).load($("#a-" + index).data("url"), function () { app.Desbloquear(); $(".modal-backdrop").remove();def.resolve(); });
        return (def.promise());
    }

    //agrega un nuevo tab al final de la lista
    //PENDIENTE: abrir un item de menú en una posición específica
    public crearTab(item: ItemMenu, redirect: boolean, load?: boolean): JQueryDeferred {

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
            $.when(this.activarTab($("#a-" + this.tab_count))).done(function () { that.block.Desbloquear(); def.resolve() });
        } else {
            if (load) {
                //var index = $("#a-" + this.tab_count);
                var index: number = $("#a-" + this.tab_count).data("index");
                $("#tab-" + index).load($("#a-" + index).data("url"), function () { def.resolve(); });
                $("#a-" + this.tab_count).data("load", "true");
            }
        }
        this.tab_count++;
        return (def.promise());
    }

    // activa y muestra un tab ya creado
    public activarTab(el: JQuery): JQueryDeferred {
        var def = $.Deferred();

        var load: boolean = $(el).data("load");
        //console.log("load: " + load);
        var cache: boolean = $(el).data("cache");
        var cargar: boolean = false;

        $('ul.nav-tabs li.active').removeClass('active');
        if ($(el).prop("tagName") != "LI") {
            $(el).parent('li').addClass('active');
        } else {
            $(el).addClass('active');
        }

        //actualizar la referencia al form en el Controlador Javascript en el caso que la página esté cacheada
        if ($(el).data("cache") == "false") {
            this.block.Bloquear();
        } else {
            if ($(el).data("load") == "false") {
                this.block.Desbloquear();
                $(el).data("load", "true");
            }
        }

        var index: number = $(el).data("index");

        if (!load) {
            cargar = true;
            $(el).data("load", true);
        } else {
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
    }

    public refrescarActual(url: string) {
        var self = this;
        var a = $("#tabs li.active").find("a");
        this.block.Bloquear($(a.data("href")));
        $(a.data("href")).load(url, function () {
            self.block.Desbloquear();
        })
    }

    public mostrarTab(index: number): void {
        //oculta todos los contenedores
        $("div[data-type=contenedor]").hide();
        //muestra el indice seleccionado
        $($("#a-" + index).data("href")).show();
    }

    public cerrarTab(el: JQuery) {

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
    }

    private _ocultar(el: JQuery) {

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
    }

    private _mostrar(el: JQuery) {

        if (!(el instanceof jQuery))
            el = $(el);

        var padre = el.closest("li").find("a").data("padre");

        if (padre != null) {

            $(el.closest("li").find("a").data("href")).show();
            el.closest("li").show();

        }
    }

    public mostrar(index: number) {
        this._mostrar($("#tabs ul li").eq(index).find("a"));
    }

    public ocultar(index: number) {
        this._ocultar($("#tabs ul li").eq(index).find("a"));
    }

    public cerrarTabIndex(index: number) {
        this.cerrarTab($("#tabs ul li").eq(index).find("a"));
    }

    public irATab(index: number, load?: boolean): JQueryDeferred {
        var def = $.Deferred();
        this.activarTab($("#tabs ul > li:eq(" + index + ")").find("a"));

        if (load != null) {
            if (load) {
                $("#tab-" + index).load($("#a-" + index).data("url"), function () { def.resolve(); });
            }
        } else
            def.resolve();

        return def;
    }

};



class ItemMenu {
    public label: string;
    public url: string;
    public close: boolean;
    public cache: boolean;
};

//$(document).ready(function () {

//});

class FormatEditor {

    public model: number;
    public html: string;
    public o: any;
    public loaded: boolean;
    public html_parsered: any[];
    public id_imputacion: number;
    public o_original: any;

    constructor(o: any, model: number, id: number) {
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

    public test(): void {
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
                var imputacion = Enumerable.From(self.o.expediente.imputaciones).Where(function (x) { return x.id == self.id_imputacion }).FirstOrDefault(null);               

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
                var tr_total = $("#parsered").find("tr[data-tipo=factura][data-action=total]").wrap('<p/>').parent().html();;
                $("#parsered").find("table[data-tipo=factura]").find("tbody").empty();

                var imputacion = Enumerable.From(self.o.expediente.imputaciones).Where(function (x) { return x.id == self.id_imputacion }).FirstOrDefault(null);
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
            while ((match = pattern.exec($("#parsered").html())) != null)
            {
                matches.push(match[1]);
            }

            matches.forEach(function(value, index) {
                 $("#parsered").html($("#parsered").html().replace("{{"+value+"}}", self.byString(self.o, value)));
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

    }

    public print() {
        var printWindow = window.open();
        printWindow.document.open('text/html')
        printWindow.document.write(this.html);
        printWindow.document.close();
        printWindow.focus();
        printWindow.print();
        printWindow.close();
    }

    public parse(): string {

        return "";
    }

    public byString(o: Object, s: string): string {
        s = s.replace(/\[(\w+)\]/g, '.$1'); // convert indexes to properties
        s = s.replace(/^\./, '');           // strip a leading dot
        var a = s.split('.');
        for (var i = 0, n = a.length; i < n; ++i) {
            var k = a[i];
            if (k in o) {
                o = o[k];
            } else {
                return;
            }
        }
        return o.toString();
    }

}


class Resultado {

    public id: number;
    public estado: boolean
    public mensaje: string;
    public excepcion: string
    public anexos: any;

    constructor() {
        this.estado = false;
        this.mensaje = "";
        this.excepcion = "";
        this.id = 0;
        this.anexos = {};
    }

    public Mensaje(value: string): void {
        this.mensaje = value;
    }

}

class ResultadoApp {

    public id: number;
    public state: boolean
    public message: string;
    public exception: string
    public anexos: any;

    constructor() {
        this.state = false;
        this.message = "";
        this.exception = "";
        this.id = 0;
        this.anexos = {};
    } 

    public Mensaje(value: string): void {
        this.message = value;
    }

}

jQuery.fn.serializeObject = function () {
    var arrayData, objectData;
    arrayData = this.serializeArray();
    objectData = {};

    $.each(arrayData, function () {
        var value;

        if (this.value != null) {
            value = this.value;
        } else {
            value = '';
        }

        if (objectData[this.name] != null) {
            if (!objectData[this.name].push) {
                objectData[this.name] = [objectData[this.name]];
            }

            objectData[this.name].push(value);
        } else {
            objectData[this.name] = value;
        }
    });

    return objectData;
};

class Global {

    public idusuario: number;
    public nombre: string;
    public organismo: number;

}

var app = new AppManager();



