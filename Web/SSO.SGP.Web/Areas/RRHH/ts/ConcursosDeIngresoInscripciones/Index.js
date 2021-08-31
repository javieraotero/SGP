/// <reference path="../../../../ts/types/chosen.jquery.d.ts" />
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
var ConcursosDeIngresoInscripciones;
(function (ConcursosDeIngresoInscripciones) {
    var ts;
    (function (ts) {
        var Index = (function () {
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //this.validacion();
            }
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setConcursosDeIngresoInscripciones = function (dt) {
                var self = this;
                this.ConcursosDeIngresoInscripciones = dt;
                $("#dtConcursosDeIngresoInscripciones tbody").click(function (event) {
                    $(self.ConcursosDeIngresoInscripciones.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.ConcursosDeIngresoInscripciones.fnGetData($(event.target).closest("tr").index())[0];
                    self.ConcursosDeIngresoInscripciones_id = id;
                    self.ConcursosDeIngresoInscripciones_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_ConcursosDeIngresoInscripciones = function (col) {
                return (this.ConcursosDeIngresoInscripciones.fnGetData(this.ConcursosDeIngresoInscripciones_index)[col]);
            };
            Index.prototype.selectRow_ConcursosDeIngresoInscripciones = function (event) {
                var self = this;
                $(self.ConcursosDeIngresoInscripciones.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.ConcursosDeIngresoInscripciones.fnGetData($(event).closest("tr").index())[0];
                self.ConcursosDeIngresoInscripciones_id = id;
                self.ConcursosDeIngresoInscripciones_index = $(event).closest("tr").index();
            };
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
    })(ts = ConcursosDeIngresoInscripciones.ts || (ConcursosDeIngresoInscripciones.ts = {}));
})(ConcursosDeIngresoInscripciones || (ConcursosDeIngresoInscripciones = {})); // module
