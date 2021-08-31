/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var EjecucionesPresupuestarias;
(function (EjecucionesPresupuestarias) {
    var ts;
    (function (ts) {
        var CrearAnual = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function CrearAnual(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Anio = $("#Anio" + hash);
                this.Errores = $("#errores");
                this.UnidadDeOrganizacion = $("#UnidadesDeOrganizacionRef" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.verEjecucion = $("#VerEjecucionesPresupuestarias" + hash);
                //Establece el foco
                this.Anio.focus();
            }
            CrearAnual.prototype.limpiar = function () {
                this.Anio.val("");
                this.Resultado.html("");
            };
            CrearAnual.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            CrearAnual.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return CrearAnual;
        }()); //JS
        ts.CrearAnual = CrearAnual;
    })(ts = EjecucionesPresupuestarias.ts || (EjecucionesPresupuestarias.ts = {}));
})(EjecucionesPresupuestarias || (EjecucionesPresupuestarias = {})); // module
