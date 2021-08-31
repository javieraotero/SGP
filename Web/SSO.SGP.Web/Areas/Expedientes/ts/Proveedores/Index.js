/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Proveedores;
(function (Proveedores) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Nuevo = $("#Nuevo" + hash);
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.Proveedores.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setProveedores = function (dt) {
                var that = this;
                this.Proveedores = dt;
                $("#dtProveedores tbody").click(function (event) {
                    $(that.Proveedores.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.Proveedores.fnGetData($(event.target).closest("tr").index())[0];
                    that.Proveedores_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
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
        }()); //JS
        ts.Index = Index;
    })(ts = Proveedores.ts || (Proveedores.ts = {}));
})(Proveedores || (Proveedores = {})); // module
