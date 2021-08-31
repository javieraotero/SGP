/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
class SyncroModal {

    public modal: JQuery;

    constructor(el: JQuery) {
        this.modal = el;
    }

    public getBody(): JQuery {
        return this.modal.find(".modal-body").first();
    }

    public loadAjax(url: string): JQueryDeferred {
        app.Bloquear();
        var d = $.Deferred();
        this.getBody().empty().load(url, function () {
            app.Desbloquear();
            d.resolve();
        });
        return d.promise();
    }

    public cerrar() {
        this.modal.modal('hide');
    }

    public mostrar() {
        this.modal.modal('show');
    }

    public setearTitulo(titulo: string): void {
        this.modal.find(".modal-title").first().text(titulo);
    }

    public cargar(titulo: string, url: string): JQueryDeferred {
        this.setearTitulo(titulo);                
        this.mostrar();
        console.log("ANTES DE LOADAJAX DE SYNCROMODAL");
        return this.loadAjax(url);
        console.log("DESPUES DE LOADAJAX DE SYNCROMODAL");
    }

}
