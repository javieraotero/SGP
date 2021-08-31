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
        var Crear = (function () {
            function Crear(hash) {
                var self = this;
                this.form = $("#" + hash);
                this.datatables = [];
                this.Path = $('#Path' + hash);
                this.Nombre = $('#Nombre' + hash);
                this.Descripcion = $('#Descripcion' + hash);
                this.Sentencia = $('#Sentencia' + hash);
                this.Sumario = $('#Sumario' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.fileArchivo = new SyncroUpload($("#fileuploadArchivo" + hash));
                this.Archivo = $("#Archivo" + hash);
                this.fileArchivo.setOnUploadDone(function (e, file) {
                    self.Archivo.val(file.Id).attr("data-nombre", file.Name);
                    self.Descripcion.focus();
                });
                //this.validacion();
            }
            //public validacion() {
            //    this.form.validate({
            //        errorClass: "field-validation-error",
            //        rules: {
            //            Archivo: { required: true, number: false, maxlength: 150 },
            //            Descripcion: { required: false, number: false, maxlength: 250 },
            //        },
            //        messages: {
            //            Archivo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
            //            Descripcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 250 caracteres" },                 
            //        }
            //    });
            //}
            Crear.prototype.limpiar = function () {
                this.Path.val("");
                this.Nombre.val("");
                this.Descripcion.val("");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        })();
        ts.Crear = Crear; //JS
    })(ts = ArchivosAdjuntos.ts || (ArchivosAdjuntos.ts = {}));
})(ArchivosAdjuntos || (ArchivosAdjuntos = {})); // module
