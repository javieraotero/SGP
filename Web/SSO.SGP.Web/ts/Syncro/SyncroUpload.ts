/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
class SyncroUpload {

    public e: JQuery;
    public Id: string;
    public txtFileName: JQuery;

    constructor(el: JQuery) {
        var that = this;
        this.e = el;
        this.txtFileName = $("#txt" + this.e.attr("id"));

        $(this.e).fileupload({
            formData: { expediente: 'test' },
            dataType: 'json'
        }).on('fileuploadprogressall', function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .progress-bar').css(
                    'width',
                    progress + '%'
                    );
            })
    }

    public setOnUploadDoneWithUrl(url:any, funcion: (es: any, data: any) => any) {
        var that = this;
        $(this.e).fileupload({
            dataType: 'json', url: url
        }).on('fileuploadprogressall', function (es, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);            
            console.log("progress: ", '#progress' + that.e.attr("id"), progress);
            $('#progress' + that.e.attr("id") + " .progress-bar").css(
                'width',
                progress + '%'
                );
        }).on('fileuploaddone', function (es, data) {
            $.each(data.result.files, function (index, file) {
                that.txtFileName.text(file.Name);
                funcion(index, file);
            });
        });
    }

    public setOnUploadDone(funcion: (es: any, data: any) => any) {
        var that = this;
        $(this.e).fileupload({
            dataType: 'json'
        }).on('fileuploadprogressall', function (es, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .progress-bar').css(
                    'width',
                    progress + '%'
                    );
        }).on('fileuploaddone', function (es, data) { 
                $.each(data.result.files, function (index, file) {
                    that.txtFileName.text(file.Name);
                    funcion(index, file);
                });              
            });
    }

    public Bloquear() {

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
    }

    public Desbloquear() {
    var el: JQuery;
    el = this.t;
    $(this.t).unblock({
        onUnblock: function () {
            $(el).css('position', '');
            jQuery(el).css('zoom', '');
        }
    });
    }

}


