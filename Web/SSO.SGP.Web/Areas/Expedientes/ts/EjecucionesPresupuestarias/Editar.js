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
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Anio = $("#Anio" + hash);
                this.PartidaPresupuestaria = $("#PartidaPresupuestaria" + hash);
                this.Estado = $("#Estado" + hash);
                this.EstaBloqueada = $("#EstaBloqueada" + hash);
                this.CreditoActual = $("#CreditoActual" + hash);
                this.CreditoDisponible = $("#CreditoDisponible" + hash);
                this.CreditoHabilitado = $("#CreditoHabilitado" + hash);
                this.MontoPreventiva = $("#MontoPreventiva" + hash);
                this.MontoCompromiso = $("#MontoCompromiso" + hash);
                this.MontoOrdenadoAPagar = $("#MontoOrdenadoAPagar" + hash);
                this.PresupuestoSolicitado = $("#PresupuestoSolicitado" + hash);
                this.Presupuestado = $("#Presupuestado" + hash);
                this.ReestructuraMas = $("#ReestructuraMas" + hash);
                this.ReestructuraMenos = $("#ReestructuraMenos" + hash);
                this.Factibilidad = $("#Factibilidad" + hash);
                this.FactibilidadHabilitada = $("#FactibilidadHabilitada" + hash);
                this.ReservaMas = $("#ReservaMas" + hash);
                this.ReservaMenos = $("#ReservaMenos" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.CreditoPresupuestadoModificado = $("#CreditoPresupuestadoModificado" + hash);
                this.MontoOrdenadoAPagarDF = $("#MontoOrdenadoAPagarDF" + hash);
                this.SaldoPreventiva = $("#SaldoPreventiva" + hash);
                this.ReservaNeta = $("#ReservaNeta" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Anio.val("");
                this.PartidaPresupuestaria.val('').trigger("liszt:updated");
                this.Estado.val("");
                this.EstaBloqueada.removeAttr('checked');
                this.CreditoActual.val("");
                this.CreditoDisponible.val("");
                this.CreditoHabilitado.val("");
                this.MontoPreventiva.val("");
                this.MontoCompromiso.val("");
                this.MontoOrdenadoAPagar.val("");
                this.PresupuestoSolicitado.val("");
                this.Presupuestado.val("");
                this.ReestructuraMas.val("");
                this.ReestructuraMenos.val("");
                this.Factibilidad.val("");
                this.FactibilidadHabilitada.val("");
                this.ReservaMas.val("");
                this.ReservaMenos.val("");
            };
            //--- Funciones para seteo de Datatables ---/
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
    })(ts = EjecucionesPresupuestarias.ts || (EjecucionesPresupuestarias.ts = {}));
})(EjecucionesPresupuestarias || (EjecucionesPresupuestarias = {})); // module
