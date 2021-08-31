/// <reference path="../../../../ts/types/chosen.jquery.d.ts" />
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
var ConcursosDeIngreso;
(function (ConcursosDeIngreso) {
    var ts;
    (function (ts) {
        var Index = (function () {
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //this.validacion();
            }
            Index.prototype.getData = function (col) {
                //var anSelected = app.fnGetSelected(this.Agentes);
                return (this.ConcursosDeIngreso.fnGetData(this.ConcursosDeIngreso_index)[col]);
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setConcursosDeIngreso = function (dt) {
                var self = this;
                this.ConcursosDeIngreso = dt;
                $("#dtConcursosDeIngreso tbody").click(function (event) {
                    $(self.ConcursosDeIngreso.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.ConcursosDeIngreso.fnGetData($(event.target).closest("tr").index())[0];
                    self.ConcursosDeIngreso_id = id;
                    self.ConcursosDeIngreso_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_ConcursosDeIngreso = function (col) {
                return (this.ConcursosDeIngreso.fnGetData(this.ConcursosDeIngreso_index)[col]);
            };
            Index.prototype.selectRow_ConcursosDeIngreso = function (event) {
                var self = this;
                $(self.ConcursosDeIngreso.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.ConcursosDeIngreso.fnGetData($(event).closest("tr").index())[0];
                self.ConcursosDeIngreso_id = id;
                self.ConcursosDeIngreso_index = $(event).closest("tr").index();
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
    })(ts = ConcursosDeIngreso.ts || (ConcursosDeIngreso.ts = {}));
})(ConcursosDeIngreso || (ConcursosDeIngreso = {})); // module
