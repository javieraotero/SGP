/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
var SyncroModal = (function () {
    function SyncroModal(el) {
        this.modal = el;
    }
    SyncroModal.prototype.getBody = function () {
        return this.modal.find(".modal-body").first();
    };
    SyncroModal.prototype.loadAjax = function (url) {
        app.Bloquear();
        var d = $.Deferred();
        this.getBody().empty().load(url, function () {
            app.Desbloquear();
            d.resolve();
        });
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
        console.log("ANTES DE LOADAJAX DE SYNCROMODAL");
        return this.loadAjax(url);
        console.log("DESPUES DE LOADAJAX DE SYNCROMODAL");
    };
    return SyncroModal;
})();
