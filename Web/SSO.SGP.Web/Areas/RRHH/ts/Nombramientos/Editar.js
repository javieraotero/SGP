/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Nombramientos;
(function (Nombramientos) {
    var ts;
    (function (ts) {
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Agente = $("#Agente" + hash);
                this.FechaDeAlta = $("#FechaDeAlta" + hash);
                this.FechaDeBaja = $("#FechaDeBaja" + hash);
                this.Motivo = $("#Motivo" + hash);
                this.Organismo = $("#OrganismosRef" + hash);
                this.Cargo = $("#Cargo" + hash);
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
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Agente.val("");
                this.FechaDeAlta.val("");
                this.FechaDeBaja.val("");
                this.Motivo.val("");
                //this.Organismo.limpiar();
                this.Cargo.val('').trigger("liszt:updated");
                this.SituacionRevista.val("");
                this.FechaFinContrato.val("");
                this.FechaFinSustitucion.val("");
                this.FechaRenuncia.val("");
                this.FechaPaseAPlanta.val("");
                this.FechaUltimoAscenso.val("");
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
        })();
        ts.Editar = Editar; //JS
    })(ts = Nombramientos.ts || (Nombramientos.ts = {}));
})(Nombramientos || (Nombramientos = {})); // module
