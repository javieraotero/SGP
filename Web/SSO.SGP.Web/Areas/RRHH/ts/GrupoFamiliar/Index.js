var GrupoFamiliar;
(function (GrupoFamiliar) {
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
                this.modal = new SyncroModal($("#ModalGrupoFamiliar" + hash));
                this.GrupoFamiliar = new SyncroTable($("#GrupoFamiliar" + hash));
                this.Agente = $("#Agente" + hash);

                //operaciones
                this.Nuevo = $("#Nuevo" + hash);
                this.Cancelar = $("#Cancelar" + hash);
                //this.GrupoFamiliar.refrescar();
            }
            Index.prototype.limpiar = function () {
            };

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
    })(GrupoFamiliar.ts || (GrupoFamiliar.ts = {}));
    var ts = GrupoFamiliar.ts;
})(GrupoFamiliar || (GrupoFamiliar = {}));
