var Sustituciones;
(function (Sustituciones) {
    /// <reference path="../../ts/types/jquery.d.ts"/>
    /// <reference path="../../ts/IControlador.ts"/>
    /// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
    (function (ts) {
        var Index = (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.Modal = new SyncroModal($("#ModalSustituciones" + hash));
                this.Agente = $("#Agente" + hash);

                //operaciones
                this.Nuevo = $("#Nuevo" + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Sustituciones = new SyncroTable($("#Sustituciones" + hash));
                //Establece el foco
                //this.Sustituciones.focus();
            }
            Index.prototype.limpiar = function () {
                this.Sustituciones.limpiar();
            };

            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };

            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        })();
        ts.Index = Index;
    })(Sustituciones.ts || (Sustituciones.ts = {}));
    var ts = Sustituciones.ts;
})(Sustituciones || (Sustituciones = {}));
