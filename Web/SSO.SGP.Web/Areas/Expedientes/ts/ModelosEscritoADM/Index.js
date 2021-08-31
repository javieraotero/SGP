/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ModelosEscritoADM;
(function (ModelosEscritoADM) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.ModelosEscritoADM.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setModelosEscritoADM = function (dt) {
                var that = this;
                this.ModelosEscritoADM = dt;
                $("#dtModelosEscritoADM tbody").click(function (event) {
                    $(that.ModelosEscritoADM.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ModelosEscritoADM.fnGetData($(event.target).closest("tr").index())[0];
                    that.ModelosEscritoADM_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.ModelosEscritoADM.fnGetData(this.index)[col]);
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
    })(ts = ModelosEscritoADM.ts || (ModelosEscritoADM.ts = {}));
})(ModelosEscritoADM || (ModelosEscritoADM = {})); // module
