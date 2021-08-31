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
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
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
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
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
    })(ts = AgentesDocencia.ts || (AgentesDocencia.ts = {}));
})(AgentesDocencia || (AgentesDocencia = {})); // module
