/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
var SyncroSelect = (function () {
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
})();
