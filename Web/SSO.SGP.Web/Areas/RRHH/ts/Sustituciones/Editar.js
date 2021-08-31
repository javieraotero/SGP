var Sustituciones;
(function (Sustituciones) {
    /// <reference path="../../ts/types/jquery.d.ts"/>
    /// <reference path="../../ts/IControlador.ts"/>
    /// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
    (function (ts) {
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.Id = $("#Id" + hash);
                this.Agente = $("#Agente" + hash);
                this.Acuerdo = $("#Acuerdo" + hash);
                this.Desde = $("#Desde" + hash);
                this.Hasta = $("#Hasta" + hash);
                this.Motivo = $("#Motivo" + hash);
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
                this.Agente.val("");
                this.Acuerdo.val("");
                this.Desde.val("");
                this.Hasta.val("");
                this.Motivo.val("");
                this.Cargo.val("").trigger("liszt:updated");
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
        ts.Editar = Editar;
    })(Sustituciones.ts || (Sustituciones.ts = {}));
    var ts = Sustituciones.ts;
})(Sustituciones || (Sustituciones = {}));
