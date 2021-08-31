/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var SinOP = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function SinOP(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            SinOP.prototype.limpiar = function () {
                this.dtSinOP.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            SinOP.prototype.setdtSinAsignacion = function (dt) {
                var that = this;
                this.dtSinOP = dt;
                $("#dtSinOP tbody").click(function (event) {
                    $(that.dtSinOP.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.dtSinOP.fnGetData($(event.target).closest("tr").index())[0];
                    that.Facturas_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            SinOP.prototype.getData = function (col) {
                return (this.dtSinOP.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            SinOP.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            SinOP.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return SinOP;
        }()); //JS
        ts.SinOP = SinOP;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
