/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var IndexSinAsignar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function IndexSinAsignar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.index_multi = [];
                this.ExpedientesADM_Id_multi = [];
                //operaciones			
            }
            IndexSinAsignar.prototype.limpiar = function () {
                this.ExpedientesADM.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            IndexSinAsignar.prototype.setExpedientesADM = function (dt) {
                var that = this;
                this.ExpedientesADM = dt;
                $("#dtExpedientesSinAsignar tbody").click(function (event) {
                    $(that.ExpedientesADM.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[0];
                    that.ExpedientesADM_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            IndexSinAsignar.prototype.setExpedientesADMMulti = function (dt, id) {
                var that = this;
                this.ExpedientesADM = dt;
                $("#" + id + " tbody").click(function (event) {
                    //$(that.ExpedientesADM.fnSettings().aoData).each(function () {
                    //    $(this.nTr).removeClass('row_selected');
                    //});
                    that.index = $(event.target).closest("tr").index();
                    if (Enumerable.From(that.index_multi).Where(function (x) { return x == that.index; }).Count() == 0) {
                        $(event.target).closest("tr").addClass('row_selected');
                        var id = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[0];
                        that.ExpedientesADM_Id = id;
                        that.index_multi.push(that.index);
                        that.ExpedientesADM_Id_multi.push(that.ExpedientesADM_Id);
                    }
                    else {
                        $(event.target).closest("tr").removeClass('row_selected');
                    }
                });
            };
            IndexSinAsignar.prototype.getData = function (col) {
                return (this.ExpedientesADM.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            IndexSinAsignar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            IndexSinAsignar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return IndexSinAsignar;
        }()); //JS
        ts.IndexSinAsignar = IndexSinAsignar;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
