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
        var IndexConCargo = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function IndexConCargo(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            IndexConCargo.prototype.limpiar = function () {
                this.ExpedientesADM.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            IndexConCargo.prototype.setExpedientesADM = function (dt) {
                var that = this;
                this.ExpedientesADM = dt;
                $("#dtExpedientesConCargoPendiente tbody").click(function (event) {
                    $(that.ExpedientesADM.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[0];
                    that.ExpedientesADM_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            IndexConCargo.prototype.getData = function (col) {
                return (this.ExpedientesADM.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            IndexConCargo.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            IndexConCargo.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return IndexConCargo;
        }()); //JS
        ts.IndexConCargo = IndexConCargo;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
