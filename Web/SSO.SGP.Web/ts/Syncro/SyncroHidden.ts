/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
class SyncroHidden {

    public el: JQuery;
    public value: any;


    constructor(el: JQuery) {
        this.el = el;
    }

    //
    // setear propiedad valor
    //
    public setear(value:any): void {
        this.value = value;
        this.el.val(value);
    }

    //
    // setear data-atributo al control hidden
    //
    public setdata(name: string, value: any) {
        this.el.data(name, value);
    }

    //
    // devuelve el valor de data-atributo
    //
    public getdata(name): any {
        return this.el.data(name);
    }

    //
    // true si el control no tiene valor
    //
    public isempty(): boolean {
        return (this.el.val() == "");
    }



}
