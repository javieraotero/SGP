var MedidasDisciplinarias;
(function (MedidasDisciplinarias) {
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
                this.MedidasDisciplinarias = new SyncroTable($("#MedidasDisciplinarias" + hash));
                this.modal = new SyncroModal($("#ModalMedidasDisciplinarias" + hash));
                this.Agente = $("#Agente" + hash);

                //operaciones
                this.Nuevo = $("#Nuevo" + hash);
                this.Cancelar = $("#Cancelar" + hash);
            }
            Index.prototype.limpiar = function () {
                this.MedidasDisciplinarias.limpiar();
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
    })(MedidasDisciplinarias.ts || (MedidasDisciplinarias.ts = {}));
    var ts = MedidasDisciplinarias.ts;
})(MedidasDisciplinarias || (MedidasDisciplinarias = {}));
