/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
/// <reference path="../types/jquery.inputmask.d.ts"/>
var SyncroTextbox = (function () {
    function SyncroTextbox(el) {
        this.el = el;
    }
    //
    // setear propiedad valor
    //
    SyncroTextbox.prototype.setear = function (value) {
        this.value = value;
        this.el.val(value);
    };
    //
    // setear data-atributo al control hidden
    //
    SyncroTextbox.prototype.setdata = function (name, value) {
        this.el.data(name, value);
    };
    //
    // devuelve el valor de data-atributo
    //
    SyncroTextbox.prototype.getdata = function (name) {
        return this.el.data(name);
    };
    //
    // true si el control no tiene valor
    //
    SyncroTextbox.prototype.isempty = function () {
        return (this.el.val() == "");
    };
    SyncroTextbox.prototype.hide = function () {
        this.el.hide();
    };
    SyncroTextbox.prototype.show = function () {
        this.el.show();
    };
    //
    // https://github.com/RobinHerbots/jquery.inputmask
    // setea una mascara de entrada para el control
    //
    SyncroTextbox.prototype.setmask = function (mask) {
        this.el.inputmask(mask);
    };
    return SyncroTextbox;
})();
