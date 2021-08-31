/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Agentes;
(function (Agentes) {
    var ts;
    (function (ts) {
        var Resumen = (function () {
            //public Nombramientos:SyncroTable; 
            //public Medidas:SyncroTable; 
            //public Dias:JQuery;
            //---  /Propiedades de Formulario --- //
            function Resumen(hash) {
                var that = this;
                this.form = $("#" + hash);
                this.datatables = [];
                this.Nombre = $("#Nombre" + hash);
                this.Documento = $("#Documento" + hash);
                this.Legajo = $("#Legajo" + hash);
                this.Domicilio = $("#Domicilio" + hash);
                this.Telefono = $("#Telefono" + hash);
                this.DiasDisponibles = new SyncroTable($("#DiasDisponibles" + hash));
                this.Id = $("#Agente" + hash);
                //this.Nombramientos = new SyncroTable($("#Nombramientos"+hash)); 
                //this.Medidas = new SyncroTable($("#Medidas"+hash)); 
                //operaciones
                this.fileArchivo = new SyncroUpload($("#fileuploadArchivo" + hash));
                this.Archivo = $("#Archivo" + hash);
                this.fileArchivo.setOnUploadDone(function (e, file) {
                    that.Archivo.val(file.Id).attr("data-nombre", file.Name);
                    $("#img_profile").attr("scr", "/files/perfiles/" + file.Name);
                });
                //Establece el foco
                this.Nombre.focus();
            }
            Resumen.prototype.limpiar = function () {
                this.Nombre.val("");
                this.Documento.val("");
                this.Legajo.val("");
                this.Domicilio.val("");
                this.Telefono.val("");
                this.DiasDisponibles.limpiar();
                //this.Nombramientos.limpiar();
                //this.Medidas.limpiar();
                //this.Dias.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Resumen.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Resumen.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Resumen;
        })();
        ts.Resumen = Resumen; //JS
    })(ts = Agentes.ts || (Agentes.ts = {}));
})(Agentes || (Agentes = {})); // module
