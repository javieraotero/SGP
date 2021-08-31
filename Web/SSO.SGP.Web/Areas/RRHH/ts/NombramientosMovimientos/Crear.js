/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
var NombramientosMovimientos;
(function (NombramientosMovimientos) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Desde = $("#Desde" + hash);
                this.Hasta = $("#Hasta" + hash);
                this.Cargo = $("#Cargo" + hash);
                this.Todos = $("#TodosLosOrganismos" + hash);
                this.SituacionRevista = $("#SituacionRevista" + hash);
                this.Organismo = $("#OrganismosRef" + hash);
                this.Modal = new SyncroModal($("#ModalNombramiento" + hash));
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Desde.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Desde.val("");
                this.Hasta.val("");
                this.Cargo.val('').trigger("liszt:updated");
                this.SituacionRevista.val('').trigger("liszt:updated");
                this.Organismo.val('').trigger("liszt:updated");
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
    })(ts = NombramientosMovimientos.ts || (NombramientosMovimientos.ts = {}));
})(NombramientosMovimientos || (NombramientosMovimientos = {})); // module
