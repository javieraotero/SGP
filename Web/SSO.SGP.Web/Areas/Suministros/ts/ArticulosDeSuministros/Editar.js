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
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombre = $("#Nombre" + hash);
                this.Codigo = $("#Codigo" + hash);
                this.StockMinimo = $("#StockMinimo" + hash);
                this.Stock = $("#Stock" + hash);
                this.UltimoCosto = $("#UltimoCosto" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombre.val("");
                this.Codigo.val("");
                this.StockMinimo.val("");
                this.Stock.val("");
                this.UltimoCosto.val("");
            };
            //--- /Funciones para seteo de Datatables ---/		
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        })();
        ts.Editar = Editar; //JS
    })(ts = ArticulosDeSuministros.ts || (ArticulosDeSuministros.ts = {}));
})(ArticulosDeSuministros || (ArticulosDeSuministros = {})); // module
