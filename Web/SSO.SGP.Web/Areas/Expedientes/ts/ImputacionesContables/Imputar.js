/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ImputacionesContables;
(function (ImputacionesContables) {
    var ts;
    (function (ts) {
        var Imputar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Imputar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.ExpedienteAImputar = new SyncroAutocomplete("#ExpedienteAImputar" + hash, "url");
                this.Fecha = $("#Fecha" + hash);
                this.Afectacion = $("#Afectacion" + hash);
                this.Compromiso = $("#Compromiso" + hash);
                this.OrdenadoAPagar = $("#OrdenadoAPagar" + hash);
                this.Partida = new SyncroAutocomplete("#Partida" + hash, "url");
                this.Division = $("#Division" + hash);
                this.Importe = $("#Importe" + hash);
                this.Agregar = $("#Agregar" + hash);
                this.Detalle = new SyncroTable($("#Detalle" + hash));
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.ExpedienteAImputar.focus();
            }
            Imputar.prototype.limpiar = function () {
                this.ExpedienteAImputar.limpiar();
                this.Fecha.val("");
                this.Afectacion.removeAttr('checked');
                this.Compromiso.removeAttr('checked');
                this.OrdenadoAPagar.removeAttr('checked');
                this.Partida.limpiar();
                this.Division.val('').trigger("liszt:updated");
                this.Importe.val("");
                this.Agregar.val("");
                this.Detalle.limpiar();
            };
            //--- Funciones para seteo de Datatables ---/
            Imputar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Imputar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Imputar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Imputar;
        }()); //JS
        ts.Imputar = Imputar;
    })(ts = ImputacionesContables.ts || (ImputacionesContables.ts = {}));
})(ImputacionesContables || (ImputacionesContables = {})); // module
