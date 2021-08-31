/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var NombramientosMovimientos;
(function (NombramientosMovimientos) {
    var ts;
    (function (ts) {
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombramiento = $("#Nombramiento" + hash);
                this.Desde = $("#Desde" + hash);
                this.Hasta = $("#Hasta" + hash);
                this.Cargo = $("#Cargo" + hash);
                this.SituacionRevista = $("#SituacionRevista" + hash);
                this.Organismo = $("#Organismo" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombramiento.val('').trigger("liszt:updated");
                this.Desde.val("");
                this.Hasta.val("");
                this.Cargo.val('').trigger("liszt:updated");
                this.SituacionRevista.val('').trigger("liszt:updated");
                this.Organismo.val('').trigger("liszt:updated");
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
    })(ts = NombramientosMovimientos.ts || (NombramientosMovimientos.ts = {}));
})(NombramientosMovimientos || (NombramientosMovimientos = {})); // module
