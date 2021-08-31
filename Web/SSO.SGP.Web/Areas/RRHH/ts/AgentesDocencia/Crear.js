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
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Agente = $("#Agente" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.Institucion = $("#Institucion" + hash);
                this.CargaHoraria = $("#CargaHoraria" + hash);
                this.HorasCatedra = $("#HorasCatedra" + hash);
                this.HorasSemanales = $("#HorasSemanales" + hash);
                this.Observaciones = $("#Observaciones" + hash);
                this.Detalle = $("#Detalle" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Agente.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Agente.val('').trigger("liszt:updated");
                this.Fecha.val("");
                this.Institucion.val("");
                this.CargaHoraria.val("");
                this.HorasCatedra.removeAttr('checked');
                this.HorasSemanales.removeAttr('checked');
                this.Observaciones.val("");
                this.Detalle.val("");
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
    })(ts = AgentesDocencia.ts || (AgentesDocencia.ts = {}));
})(AgentesDocencia || (AgentesDocencia = {})); // module
