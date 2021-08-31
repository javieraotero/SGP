/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
var SyncroAutocomplete = (function () {
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
})();
