/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
var LicenciasAgente;
(function (LicenciasAgente) {
    var ts;
    (function (ts) {
        var Consulta = (function () {
            //---  /Propiedades de Formulario --- //
            function Consulta(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Agente = new SyncroAutocomplete("Agente" + hash, "Agentes/GetJson");
                this.Licencias = new SyncroTable($("#Licencias" + hash));
                this.FechaDesde = $("#FechaDesde" + hash);
                this.FechaHasta = $("#FechaHasta" + hash);
                this.Licencia = $("#LicenciasRef" + hash);
                this.Modal = new SyncroModal($("#MainModal"));
                this.Buscar = $("#Buscar" + hash);
                //operaciones
                //Establece el foco
                this.Agente.txt.focus();
            }
            Consulta.prototype.limpiar = function () {
                this.Agente.limpiar();
                this.Licencias.limpiar();
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Consulta.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Consulta.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Consulta;
        })();
        ts.Consulta = Consulta; //JS
    })(ts = LicenciasAgente.ts || (LicenciasAgente.ts = {}));
})(LicenciasAgente || (LicenciasAgente = {})); // module
