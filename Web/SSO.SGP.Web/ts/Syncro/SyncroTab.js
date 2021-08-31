/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="SyncroBlock.ts"/>
var SyncroTabx = (function () {
    function SyncroTabx() {
    }
    SyncroTabx.prototype.contructor = function (id) {
        this.id = id;
        this.tab_count = 0;
    };

    //jtabs: [{item.label, item.url, item.close, item.cache}, {...} ...]
    SyncroTabx.prototype.iniciarTab = function (jtabs) {
        var arr;
        var that = this;
        var primero = true;
        arr = JSON.parse(jtabs);
        $.each(arr, function (i, item) {
            that.crearTab(item, primero, null);
            primero = false;
        });
    };

    //agrega un nuevo tab al final de la lista
    //PENDIENTE: abrir un item de menú en una posición específica
    SyncroTabx.prototype.crearTab = function (item, redirect, idpadre) {
        var def = $.Deferred();

        var cerrar = (item.close) ? "<span class='ui-icon ui-icon-close' onclick='app.closeTab(this);'>Cerrar</span>" : "";

        $("#tabs > ul").append("<li class='ui-state-default ui-corner-top'><a data-toggle='tab' data-padre='" + (idpadre != null) ? idpadre : "" + "' data-index='" + this.tab_count + "' data-load='false' data-cache='" + item.cache + "' data-toggle='tab' href='' data-url='" + item.url + "' data-href='#tab-" + this.tab_count + "' id='a-" + this.tab_count + "' onclick='app.setActiveTab(this)'>" + item.label + "</a>" + cerrar + "</li>");
        $("#tabs").append("<div id='tab-" + this.tab_count + "' data-type='contenedor' class='ui-tabs-panel ui-widget-content ui-corner-bottom' style='display:none'></div>");
    };

    SyncroTabx.prototype.activarTab = function (el) {
        var def = $.Deferred();

        var load = $(el).data("load");

        //console.log("load: " + load);
        var cache = $(el).data("cache");
        var cargar = false;

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

        var index = $(el).data("index");

        if (!load) {
            cargar = true;
            $(el).data("load", true);
        } else {
            if (!cache) {
                cargar = true;
            }
        }

        if (cargar) {
            $("#tab-" + index).load($("#a-" + index).data("url"), function () {
                def.resolve();
            });
            //console.log("se carga desde tab");
        }

        this.showTab($(el).data("index"));

        return (def.promise());
    };
    return SyncroTabx;
})();

var ItemMenu = (function () {
    function ItemMenu() {
    }
    return ItemMenu;
})();
