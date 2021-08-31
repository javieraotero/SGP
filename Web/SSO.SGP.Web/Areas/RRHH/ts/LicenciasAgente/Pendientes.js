/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var LicenciasAgente;
(function (LicenciasAgente) {
    var ts;
    (function (ts) {
        var Pendientes = (function () {
            //---  /Propiedades de Formulario --- //
            function Pendientes(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
            }
            Pendientes.prototype.limpiar = function () {
                this.LicenciasAgente.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Pendientes.prototype.setPendientes = function (dt) {
                var that = this;
                this.LicenciasAgente = dt;
                $("#dtPendientes tbody").click(function (event) {
                    $(that.LicenciasAgente.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.LicenciasAgente.fnGetData($(event.target).closest("tr").index())[0];
                    that.LicenciasAgente_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            //--- /Funciones para seteo de Datatables ---/
            Pendientes.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Pendientes.prototype.getData = function (col) {
                //var anSelected = app.fnGetSelected(this.Agentes);
                return (this.LicenciasAgente.fnGetData(this.index)[col]);
            };
            Pendientes.prototype.selectRow_Licencia = function (event) {
                var self = this;
                $(self.LicenciasAgente.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.LicenciasAgente.fnGetData($(event).closest("tr").index())[0];
                self.LicenciasAgente_Id = id;
                self.index = $(event).closest("tr").index();
            };
            Pendientes.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Pendientes;
        })();
        ts.Pendientes = Pendientes; //JS
    })(ts = LicenciasAgente.ts || (LicenciasAgente.ts = {}));
})(LicenciasAgente || (LicenciasAgente = {})); // module
