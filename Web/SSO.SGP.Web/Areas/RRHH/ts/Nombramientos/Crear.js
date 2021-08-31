/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var Nombramientos;
(function (Nombramientos) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Agente = $("#Agente" + hash);
                this.FechaDeAlta = $("#FechaDeAlta" + hash);
                this.FechaDeBaja = $("#FechaDeBaja" + hash);
                this.Cargo = $("#Cargo" + hash);
                this.Motivo = $("#Motivo" + hash);
                this.Organismo = $("#OrganismosRef" + hash);
                this.SituacionRevista = $("#SituacionRevista" + hash);
                this.FechaFinContrato = $("#FechaFinContrato" + hash);
                this.FechaFinSustitucion = $("#FechaFinSustitucion" + hash);
                this.FechaRenuncia = $("#FechaRenuncia" + hash);
                this.FechaPaseAPlanta = $("#FechaPaseAPlanta" + hash);
                this.FechaUltimoAscenso = $("#FechaUltimoAscenso" + hash);
                this.TodosLosOrganismos = $("#TodosLosOrganismos" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Agente.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Agente.val("");
                this.FechaDeAlta.val("");
                this.FechaDeBaja.val("");
                this.Cargo.val('').trigger("liszt:updated");
                this.Motivo.val("");
                //this.Organismo.limpiar();
                this.SituacionRevista.val('').trigger("liszt:updated");
                this.FechaFinContrato.val("");
                this.FechaFinSustitucion.val("");
                this.FechaRenuncia.val("");
                this.FechaPaseAPlanta.val("");
                this.FechaUltimoAscenso.val("");
            };
            //--- Funciones para seteo de Datatables ---/
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
    })(ts = Nombramientos.ts || (Nombramientos.ts = {}));
})(Nombramientos || (Nombramientos = {})); // module
