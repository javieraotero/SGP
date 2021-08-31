/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
class SyncroAutocomplete {

    public txt: JQuery;
    public hidden: JQuery;
    public callback: (ui: any) => any;
    public url: string;


    constructor(elemento: string, url: string, callback?: (ui:any) => any) {
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

    public set(valor: string, texto: string) {
        this.txt.val(texto);
        this.hidden.val(valor);
    }

    public texto(): string {
        return this.txt.val();
    } 

    public setCallback(callback: (ui: any) => any) {
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
    }

    public setAppendTo(append: string) {
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
    }

    public valor(): any {
        return this.hidden.val();
    }

    public limpiar(): void {
        this.txt.val("");
        this.hidden.val("");
    }
}
