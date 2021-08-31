/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var FeriasRef;
(function (FeriasRef) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Descripcion = $("#Descripcion" + hash);
                this.FechaDesde = $("#FechaDesde" + hash);
                this.FechaHasta = $("#FechaHasta" + hash);
                this.Anio = $("#Anio" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Descripcion.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Descripcion.val("");
                this.FechaDesde.val("");
                this.FechaHasta.val("");
                this.Anio.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
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
    })(ts = FeriasRef.ts || (FeriasRef.ts = {}));
})(FeriasRef || (FeriasRef = {})); // module
