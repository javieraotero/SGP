/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ColaDeMovimientosCESIDA;
(function (ColaDeMovimientosCESIDA) {
    var ts;
    (function (ts) {
        var Index = (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.ColaDeMovimientosCESIDA.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setColaDeMovimientosCESIDA = function (dt) {
                var that = this;
                this.ColaDeMovimientosCESIDA = dt;
                $("#dtColaDeMovimientosCESIDA tbody").click(function (event) {
                    $(that.ColaDeMovimientosCESIDA.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ColaDeMovimientosCESIDA.fnGetData($(event.target).closest("tr").index())[0];
                    that.ColaDeMovimientosCESIDA_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.ColaDeMovimientosCESIDA.fnGetData(this.index)[col]);
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
        ts.Index = Index; //JS
    })(ts = ColaDeMovimientosCESIDA.ts || (ColaDeMovimientosCESIDA.ts = {}));
})(ColaDeMovimientosCESIDA || (ColaDeMovimientosCESIDA = {})); // module
