/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ArchivosAdjuntos;
(function (ArchivosAdjuntos) {
    var ts;
    (function (ts) {
        var File = (function () {
            function File(hash) {
                var self = this;
                this.form = $("#" + hash);
                this.datatables = [];
                this.Path = $('#Path' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.Descripcion = $("#Descripcion");
                this.fileArchivo = new SyncroUpload($("#fileuploadArchivo" + hash));
                this.Archivo = $("#Archivo" + hash);
                this.fileArchivo.setOnUploadDone(function (e, file) {
                    self.Archivo.val(file.Id).attr("data-nombre", file.Name);
                });
                //this.validacion();
            }
            //public validacion() {
            //    this.form.validate({
            //        errorClass: "field-validation-error",
            //        rules: {
            //            Archivo: { required: true, number: false, maxlength: 150 }                
            //        },
            //        messages: {
            //            Archivo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
            //        }
            //    });
            //}
            File.prototype.limpiar = function () {
                this.Path.val("");
            };
            File.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            File.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return File;
        })();
        ts.File = File; //JS
    })(ts = ArchivosAdjuntos.ts || (ArchivosAdjuntos.ts = {}));
})(ArchivosAdjuntos || (ArchivosAdjuntos = {})); // module
