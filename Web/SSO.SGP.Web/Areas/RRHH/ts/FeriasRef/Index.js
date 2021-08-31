/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var FeriasRef;
(function (FeriasRef) {
    var ts;
    (function (ts) {
        var Index = (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Nuevo = $("#Nuevo" + hash);
                this.Modal = new SyncroModal($("#ModalFerias" + hash));
                //operaciones			
            }
            Index.prototype.limpiar = function () {
                this.FeriasRef.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setFeriasRef = function (dt) {
                var that = this;
                this.FeriasRef = dt;
                $("#dtFeriasRef tbody").click(function (event) {
                    $(that.FeriasRef.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.FeriasRef.fnGetData($(event.target).closest("tr").index())[0]; // getting the value of the first (invisible) column
                    that.FeriasRef_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                //var anSelected = app.fnGetSelected(this.Agentes);
                return (this.FeriasRef.fnGetData(this.index)[col]);
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
    })(ts = FeriasRef.ts || (FeriasRef.ts = {}));
})(FeriasRef || (FeriasRef = {})); // module
