/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var DivisionesExtraPresupuestarias;
(function (DivisionesExtraPresupuestarias) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Nombre = $("#Nombre" + hash);
                this.CodigoCESIDA = $("#CodigoCESIDA" + hash);
                this.PartidaPresupuestaria = $("#PartidaPresupuestaria" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Nombre.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Nombre.val("");
                this.CodigoCESIDA.val("");
                this.PartidaPresupuestaria.val('').trigger("liszt:updated");
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
        }()); //JS
        ts.Crear = Crear;
    })(ts = DivisionesExtraPresupuestarias.ts || (DivisionesExtraPresupuestarias.ts = {}));
})(DivisionesExtraPresupuestarias || (DivisionesExtraPresupuestarias = {})); // module
