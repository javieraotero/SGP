/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/tinymce.d.ts"/>
class SyncroTinyMCE {

    public tiny: TinyMceEditor;
    //Id de registro
    public nId: number;
    public bAutoguardar: boolean;
    public sUrlAutoGuardado: string;

    constructor(tiny: TinyMceEditor) {
        this.tiny = tiny;
        this.bAutoguardar = false;
        this.nId = 0;
    }

    public setAutoSave(url: string, id: number, timeout:number) {
        this.bAutoguardar = true;
        this.nId = id;
        this.sUrlAutoGuardado = url;

        setTimeout(this.autoSave(), timeout);
    }

    public setContent(contenido: string):void {
        this.tiny.setContent(contenido);
    }

    public getConent(): string {
        return this.tiny.getContent();
    }  

    //-- Aplicar contenido retornado por URL
    public setContentAjax(url: string):void {
        var that = this;
        $.getJSON(url, null, function (data: any) {
            that.setContent(data.html);
        });
    }

    public autoSave():void {
        var that = this;
        $.ajax({
            url: that.sUrlAutoGuardado,
            data: { id: that.nId, html: that.getConent() },
            success: function (result) {
                if (result.ok) {
                    console.log("Autoguardado a las " + new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString());
                } else {
                    console.log("Ocurrió error en autoguardado!");
                }
            }
        });
    }

    public save(url:string, id:number): void {
        var that = this;
        $.ajax({
            url: url,
            data: { id: id, html: that.getConent() },
            success: function (result) {
                if (result.ok) {
                    console.log("Guardado a las " + new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString());
                } else {
                    console.log("Ocurrió error en autoguardado!");
                }
            }
        });
    }

}
