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
        var SinAsignacion = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function SinAsignacion(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            SinAsignacion.prototype.limpiar = function () {
                this.dtSinAsignacion.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            SinAsignacion.prototype.setdtSinAsignacion = function (dt) {
                var that = this;
                this.dtSinAsignacion = dt;
                $("#dtSinAsignacion tbody").click(function (event) {
                    $(that.dtSinAsignacion.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.dtSinAsignacion.fnGetData($(event.target).closest("tr").index())[0];
                    that.Facturas_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            SinAsignacion.prototype.getData = function (col) {
                return (this.dtSinAsignacion.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            SinAsignacion.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            SinAsignacion.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return SinAsignacion;
        }()); //JS
        ts.SinAsignacion = SinAsignacion;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
