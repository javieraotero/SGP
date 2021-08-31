/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ArticulosDeSuministros;
(function (ArticulosDeSuministros) {
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
                this.ArticulosDeSuministros.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setArticulosDeSuministros = function (dt) {
                var that = this;
                this.ArticulosDeSuministros = dt;
                $("#dtArticulosDeSuministros tbody").click(function (event) {
                    $(that.ArticulosDeSuministros.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ArticulosDeSuministros.fnGetData($(event.target).closest("tr").index())[0];
                    that.ArticulosDeSuministros_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.ArticulosDeSuministros.fnGetData(this.index)[col]);
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
    })(ts = ArticulosDeSuministros.ts || (ArticulosDeSuministros.ts = {}));
})(ArticulosDeSuministros || (ArticulosDeSuministros = {})); // module
