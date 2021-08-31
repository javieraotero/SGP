var Sustituciones;
(function (Sustituciones) {
    /// <reference path="../../ts/types/jquery.d.ts"/>
    /// <reference path="../../ts/IControlador.ts"/>
    /// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.Agente = $("#Agente" + hash);
                this.Acuerdo = $("#Acuerdo" + hash);
                this.Desde = $("#Desde" + hash);
                this.Hasta = $("#Hasta" + hash);
                this.Motivo = $("#Motivo" + hash);
                this.Cargo = $("#Cargo" + hash);
                this.Organismo = $("#Organismo" + hash);

                //operaciones
                this.Cancelar = $("#CancelarSustituciones" + hash);
                this.Guardar = $("#GuardarSustituciones" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevoSustituciones" + hash);

                //Establece el foco
                this.Acuerdo.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Agente.val("");
                this.Acuerdo.val("");
                this.Desde.val("");
                this.Hasta.val("");
                this.Motivo.val("");
                this.Cargo.val('').trigger("liszt:updated");
                //this.Organismo.limpiar();
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
        ts.Crear = Crear;
    })(Sustituciones.ts || (Sustituciones.ts = {}));
    var ts = Sustituciones.ts;
})(Sustituciones || (Sustituciones = {}));
