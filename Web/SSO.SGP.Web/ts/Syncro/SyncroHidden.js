/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
var SyncroHidden = (function () {
    function SyncroHidden(el) {
        this.el = el;
    }
    //
    // setear propiedad valor
    //
    SyncroHidden.prototype.setear = function (value) {
        this.value = value;
        this.el.val(value);
    };

    //
    // setear data-atributo al control hidden
    //
    SyncroHidden.prototype.setdata = function (name, value) {
        this.el.data(name, value);
    };

    //
    // devuelve el valor de data-atributo
    //
    SyncroHidden.prototype.getdata = function (name) {
        return this.el.data(name);
    };

    //
    // true si el control no tiene valor
    //
    SyncroHidden.prototype.isempty = function () {
        return (this.el.val() == "");
    };
    return SyncroHidden;
})();
