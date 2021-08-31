/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var AgentesDocencia;
(function (AgentesDocencia) {
    var ts;
    (function (ts) {
        var Eliminar = (function () {
            //---  /Propiedades de Formulario --- //
            function Eliminar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Agente = $("#Agente" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.Institucion = $("#Institucion" + hash);
                this.CargaHoraria = $("#CargaHoraria" + hash);
                this.HorasCatedra = $("#HorasCatedra" + hash);
                this.HorasSemanales = $("#HorasSemanales" + hash);
                this.Observaciones = $("#Observaciones" + hash);
                this.Detalle = $("#Detalle" + hash);
                //operaciones
                //Establece el foco
                this.Id.focus();
            }
            Eliminar.prototype.limpiar = function () {
                this.Id.val("");
                this.Agente.val("");
                this.Fecha.val("");
                this.Institucion.val("");
                this.CargaHoraria.val("");
                this.HorasCatedra.val("");
                this.HorasSemanales.val("");
                this.Observaciones.val("");
                this.Detalle.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Eliminar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Eliminar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Eliminar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Eliminar;
        })();
        ts.Eliminar = Eliminar; //JS
    })(ts = AgentesDocencia.ts || (AgentesDocencia.ts = {}));
})(AgentesDocencia || (AgentesDocencia = {})); // module
