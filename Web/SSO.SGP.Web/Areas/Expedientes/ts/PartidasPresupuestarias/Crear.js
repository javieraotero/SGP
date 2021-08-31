/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var PartidasPresupuestarias;
(function (PartidasPresupuestarias) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.NumeroDePartida = $("#NumeroDePartida" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Mnemo = $("#Mnemo" + hash);
                this.UnidadDeOrganizacion = $("#UnidadDeOrganizacion" + hash);
                this.Prioridad = $("#Prioridad" + hash);
                this.DivisionesExtraPresupuestarias = new SyncroTable($("#DivisionesExtraPresupuestarias" + hash));
                this.AsociarDivision = $("#AsociarDivision" + hash);
                this.adivisiones = [];
                this.Modal = new SyncroModal($("#MainModal"));
                this.NombreDivision = $("#NombrePartida" + hash);
                this.CodigoCesida = $("#CodigoCesida" + hash);
                this.AgregarDivision = $("#AgregarDivision" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.NumeroDePartida.focus();
            }
            Crear.prototype.limpiar = function () {
                this.NumeroDePartida.val("");
                this.Descripcion.val("");
                this.Mnemo.val("");
                this.UnidadDeOrganizacion.val('').trigger("liszt:updated");
                this.Prioridad.removeAttr('checked');
                this.DivisionesExtraPresupuestarias.limpiar();
                this.AsociarDivision.val("");
                this.adivisiones = [];
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
    })(ts = PartidasPresupuestarias.ts || (PartidasPresupuestarias.ts = {}));
})(PartidasPresupuestarias || (PartidasPresupuestarias = {})); // module
