/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var CargosRef;
(function (CargosRef) {
    var ts;
    (function (ts) {
        var Index = (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.modal = new SyncroModal($("#ModalIndexCargosRef" + hash));
                this.Nuevo = $("#Nuevo" + hash);
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.CargosRef.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setCargosRef = function (dt) {
                var that = this;
                this.CargosRef = dt;
                $("#dtCargosRef tbody").click(function (event) {
                    $(that.CargosRef.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.CargosRef.fnGetData($(event.target).closest("tr").index())[0]; // getting the value of the first (invisible) column
                    that.CargosRef_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                return (this.CargosRef.fnGetData(this.index)[col]);
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
    })(ts = CargosRef.ts || (CargosRef.ts = {}));
})(CargosRef || (CargosRef = {})); // module
