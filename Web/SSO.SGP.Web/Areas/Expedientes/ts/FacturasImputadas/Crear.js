/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var FacturasImputadas;
(function (FacturasImputadas) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Factura = new SyncroAutocomplete("#Factura" + hash, "url");
                this.Fecha = $("#Fecha" + hash);
                this.AnioContable = $("#AnioContable" + hash);
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
                this.Factura.txt.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Factura.limpiar();
                this.Fecha.val("");
                this.AnioContable.val("");
                this.Partida.limpiar();
                this.Division.val('').trigger("liszt:updated");
                this.Importe.val("");
                this.Agregar.val("");
                this.Detalle.limpiar();
            };
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
        }()); //JS
        ts.Crear = Crear;
    })(ts = FacturasImputadas.ts || (FacturasImputadas.ts = {}));
})(FacturasImputadas || (FacturasImputadas = {})); // module
