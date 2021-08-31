/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module ArchivosAdjuntos.ts {

    export class Crear implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public Path: JQuery;
        public Nombre: JQuery;
        public Descripcion: JQuery;
        public Sentencia: JQuery;
        public Sumario: JQuery;
        public Cancelar: JQuery;
        public Guardar: JQuery;
        public GuardarYNuevo: JQuery;

        public fileArchivo: SyncroUpload;
        public Archivo: JQuery;

        constructor(hash: string) {
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

        public limpiar() {
            this.Path.val("");
            this.Nombre.val("");
            this.Descripcion.val("");
        }


        public fnRegistrarDataTable(d: DataTables.DataTable): void {
            this.datatables.push(d);
        }

        public fnRefrescarDataTables(): void {
            var that = this;
            this.datatables.forEach(function (d) {
                d.fnDraw();
            });
        }
    } //JS
} // module