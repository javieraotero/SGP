/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/tinymce.d.ts"/>
var SyncroTinyMCE = (function () {
    function SyncroTinyMCE(tiny) {
        this.tiny = tiny;
        this.bAutoguardar = false;
        this.nId = 0;
    }
    SyncroTinyMCE.prototype.setAutoSave = function (url, id, timeout) {
        this.bAutoguardar = true;
        this.nId = id;
        this.sUrlAutoGuardado = url;
        setTimeout(this.autoSave(), timeout);
    };
    SyncroTinyMCE.prototype.setContent = function (contenido) {
        this.tiny.setContent(contenido);
    };
    SyncroTinyMCE.prototype.getConent = function () {
        return this.tiny.getContent();
    };
    //-- Aplicar contenido retornado por URL
    SyncroTinyMCE.prototype.setContentAjax = function (url) {
        var that = this;
        $.getJSON(url, null, function (data) {
            that.setContent(data.html);
        });
    };
    SyncroTinyMCE.prototype.autoSave = function () {
        var that = this;
        $.ajax({
            url: that.sUrlAutoGuardado,
            data: { id: that.nId, html: that.getConent() },
            success: function (result) {
                if (result.ok) {
                    console.log("Autoguardado a las " + new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString());
                }
                else {
                    console.log("Ocurrió error en autoguardado!");
                }
            }
        });
    };
    SyncroTinyMCE.prototype.save = function (url, id) {
        var that = this;
        $.ajax({
            url: url,
            data: { id: id, html: that.getConent() },
            success: function (result) {
                if (result.ok) {
                    console.log("Guardado a las " + new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString());
                }
                else {
                    console.log("Ocurrió error en autoguardado!");
                }
            }
        });
    };
    return SyncroTinyMCE;
})();
//# sourceMappingURL=SyncroTinyMCE.js.map