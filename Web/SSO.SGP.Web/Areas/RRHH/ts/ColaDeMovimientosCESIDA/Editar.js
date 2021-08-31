/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ColaDeMovimientosCESIDA;
(function (ColaDeMovimientosCESIDA) {
    var ts;
    (function (ts) {
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombramiento = $("#Nombramiento" + hash);
                this.Agente = $("#Agente" + hash);
                this.Movimiento = $("#Movimiento" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.FechaEnvio = $("#FechaEnvio" + hash);
                this.IdRespuesta = $("#IdRespuesta" + hash);
                this.MensajeRespuesta = $("#MensajeRespuesta" + hash);
                this.Intentos = $("#Intentos" + hash);
                this.Licencia = $("#Licencia" + hash);
                this.IdRegistro = $("#IdRegistro" + hash);
                this.FechaDesde = $("#FechaDesde" + hash);
                this.FechaHasta = $("#FechaHasta" + hash);
                this.Cargo = $("#Cargo" + hash);
                this.Organismo = $("#Organismo" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombramiento.val("");
                this.Agente.val("");
                this.Movimiento.val('').trigger("liszt:updated");
                this.Fecha.val("");
                this.FechaEnvio.val("");
                this.IdRespuesta.val("");
                this.MensajeRespuesta.val("");
                this.Intentos.val("");
                this.Licencia.val("");
                this.IdRegistro.val("");
                this.FechaDesde.val("");
                this.FechaHasta.val("");
                this.Cargo.val("");
                this.Organismo.val("");
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
        })();
        ts.Editar = Editar; //JS
    })(ts = ColaDeMovimientosCESIDA.ts || (ColaDeMovimientosCESIDA.ts = {}));
})(ColaDeMovimientosCESIDA || (ColaDeMovimientosCESIDA = {})); // module
