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
        var Index = (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Agente = $("#Agente" + hash);
                this.Nombramientos = new SyncroTable($("#Nombramientos" + hash));
                this.Movimientos = new SyncroTable($("#Movimientos" + hash));
                this.Modal = new SyncroModal($("#ModalNombramiento" + hash));
                //operaciones
                this.Nuevo = $("#Nuevo" + hash);
                this.Movimiento = $("#Movimiento" + hash);
                this.Cancelar = $("#Cancelar" + hash);
                //Establece el foco
                //this.Nombramientos.focus();
            }
            Index.prototype.limpiar = function () {
                this.Nombramientos.limpiar();
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
        ts.Index = Index; //JS
    })(ts = Nombramientos.ts || (Nombramientos.ts = {}));
})(Nombramientos || (Nombramientos = {})); // module
