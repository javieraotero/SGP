/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
var SyncroUpload = (function () {
    function SyncroUpload(el) {
        var that = this;
        this.e = el;
        this.txtFileName = $("#txt" + this.e.attr("id"));
        $(this.e).fileupload({
            formData: { expediente: 'test' },
            dataType: 'json'
        }).on('fileuploadprogressall', function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress .progress-bar').css('width', progress + '%');
        });
    }
    SyncroUpload.prototype.setOnUploadDoneWithUrl = function (url, funcion) {
        var that = this;
        $(this.e).fileupload({
            dataType: 'json', url: url
        }).on('fileuploadprogressall', function (es, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            console.log("progress: ", '#progress' + that.e.attr("id"), progress);
            $('#progress' + that.e.attr("id") + " .progress-bar").css('width', progress + '%');
        }).on('fileuploaddone', function (es, data) {
            $.each(data.result.files, function (index, file) {
                that.txtFileName.text(file.Name);
                funcion(index, file);
            });
        });
    };
    SyncroUpload.prototype.setOnUploadDone = function (funcion) {
        var that = this;
        $(this.e).fileupload({
            dataType: 'json'
        }).on('fileuploadprogressall', function (es, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress .progress-bar').css('width', progress + '%');
        }).on('fileuploaddone', function (es, data) {
            $.each(data.result.files, function (index, file) {
                that.txtFileName.text(file.Name);
                funcion(index, file);
            });
        });
    };
    SyncroUpload.prototype.Bloquear = function () {
        var centerY = false;
        //var el: JQuery;
        //el = this.page_container;
        if (this.t.height() <= 400) {
            centerY = true;
        }
        this.e.block({
            message: '<img src="./assets/img/ajax-loading.gif" align="">',
            centerY: centerY != undefined ? centerY : true,
            css: {
                top: '10%',
                border: 'none',
                padding: '2px',
                backgroundColor: 'none'
            },
            overlayCSS: {
                backgroundColor: '#000',
                opacity: 0.05,
                cursor: 'wait'
            }
        });
    };
    SyncroUpload.prototype.Desbloquear = function () {
        var el;
        el = this.t;
        $(this.t).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    };
    return SyncroUpload;
})();
