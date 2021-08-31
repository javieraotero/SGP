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
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.ExpedienteAImputar = $("#ExpedienteAImputar" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.FechaElimina = $("#FechaElimina" + hash);
                this.Operacion = $("#Operacion" + hash);
                this.ExpedienteIndirecto = $("#ExpedienteIndirecto" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.ExpedienteAImputar.val('').trigger("liszt:updated");
                this.Fecha.val("");
                this.UsuarioAlta.val("");
                this.FechaElimina.val("");
                this.Operacion.val('').trigger("liszt:updated");
                this.ExpedienteIndirecto.val('').trigger("liszt:updated");
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
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
        }()); //JS
        ts.Editar = Editar;
    })(ts = ImputacionesContables.ts || (ImputacionesContables.ts = {}));
})(ImputacionesContables || (ImputacionesContables = {})); // module
