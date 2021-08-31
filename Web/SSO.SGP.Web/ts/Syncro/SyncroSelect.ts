/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
class SyncroSelect {

    public el: JQuery;
    public chosen: boolean;

    constructor(elemento: string, chosen?:boolean) {
        var that = this;
        this.el = $("#" + elemento);

        this.chosen = (chosen != null && chosen) ? true : false;
    }

    public agregar(value: any, text: string):void {
        var o = new Option(text, value);
        $(o).html(text);
        this.el.append(o);

        if (this.chosen)
            this.el.trigger("liszt:updated");
    }

    public quitar(value: any): void {
        this.el.find("option[value='"+value+"']").remove();
    }

    public valor(): any {
        return this.el.val();
    }

    public texto(): string {
        return this.el.find("option:selected").text();
    }

    public bind(event: string, fun: (e: Event) => void ):void {
        this.el.bind(event, fun);
    } 

    public habilitado(enable: boolean): void {
        if (enable)
            this.el.prop("disabled", false);
        else
            this.el.prop("disabled", "disabled");

        if (this.chosen)
            this.el.trigger("liszt:updated");
    }

    public ajax(url: string, param: any):void {
        var that = this;
        $.post(url, param,
            function (data) {
                var sel = that.el;
                sel.empty();
                for (var i = 0; i < data.length; i++) {
                    sel.append('<option value="' + data[i].value + '">' + data[i].text + '</option>');
                }
            }, "json");
    }

}
