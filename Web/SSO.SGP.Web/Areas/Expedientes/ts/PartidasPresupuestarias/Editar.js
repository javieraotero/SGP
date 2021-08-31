/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var PartidasPresupuestarias;
(function (PartidasPresupuestarias) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.NumeroDePartida = $("#NumeroDePartida" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Mnemo = $("#Mnemo" + hash);
                this.UnidadDeOrganizacion = $("#UnidadDeOrganizacion" + hash);
                this.Prioridad = $("#Prioridad" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.NumeroDePartida.val("");
                this.Descripcion.val("");
                this.Mnemo.val("");
                this.UnidadDeOrganizacion.val('').trigger("liszt:updated");
                this.Prioridad.removeAttr('checked');
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
    })(ts = PartidasPresupuestarias.ts || (PartidasPresupuestarias.ts = {}));
})(PartidasPresupuestarias || (PartidasPresupuestarias = {})); // module
