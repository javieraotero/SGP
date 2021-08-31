/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
var LicenciasAgente;
(function (LicenciasAgente) {
    var ts;
    (function (ts) {
        var Excepcion = (function () {
            //---  /Propiedades de Formulario --- //
            function Excepcion(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Observaciones = $("#Observaciones" + hash);
                this.Resolucion = $("#Resolucion" + hash);
                this.Dias = $("#DiasOtorgados" + hash);
                //operaciones
                this.Guardar = $("#Guardar" + hash);
                this.Cancelar = $("#Cancelar" + hash);
                //Establece el foco
                this.Resolucion.focus();
            }
            Excepcion.prototype.limpiar = function () {
                this.Observaciones.val("");
                this.Dias.val("");
                this.Resolucion.val("");
            };
            Excepcion.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Excepcion.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Excepcion;
        })();
        ts.Excepcion = Excepcion; //JS
    })(ts = LicenciasAgente.ts || (LicenciasAgente.ts = {}));
})(LicenciasAgente || (LicenciasAgente = {})); // module
