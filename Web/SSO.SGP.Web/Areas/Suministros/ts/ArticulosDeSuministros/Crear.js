/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ArticulosDeSuministros;
(function (ArticulosDeSuministros) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Nombre = $("#Nombre" + hash);
                this.Codigo = $("#Codigo" + hash);
                this.StockMinimo = $("#StockMinimo" + hash);
                this.Stock = $("#Stock" + hash);
                this.UltimoCosto = $("#UltimoCosto" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Nombre.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Nombre.val("");
                this.Codigo.val("");
                this.StockMinimo.val("");
                this.Stock.val("");
                this.UltimoCosto.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Crear.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
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
        })();
        ts.Crear = Crear; //JS
    })(ts = ArticulosDeSuministros.ts || (ArticulosDeSuministros.ts = {}));
})(ArticulosDeSuministros || (ArticulosDeSuministros = {})); // module
