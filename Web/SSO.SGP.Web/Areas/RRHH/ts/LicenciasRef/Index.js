var LicenciasRef;
(function (LicenciasRef) {
    /// <reference path="../../ts/types/jquery.d.ts"/>
    /// <reference path="../../ts/IControlador.ts"/>
    /// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
    (function (ts) {
        var Index = (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.modal = new SyncroModal($("#ModalIndexLicenciasRef" + hash));
                this.Nuevo = $("#Nuevo" + hash);
                //operaciones
            }
            Index.prototype.limpiar = function () {
                this.LicenciasRef.fnDraw();
            };

            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setLicenciasRef = function (dt) {
                var that = this;
                this.LicenciasRef = dt;

                $("#dtLicenciasRef tbody").click(function (event) {
                    $(that.LicenciasRef.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');

                    var id = that.LicenciasRef.fnGetData($(event.target).closest("tr").index())[0];
                    that.LicenciasRef_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };

            Index.prototype.getData = function (col) {
                return (this.LicenciasRef.fnGetData(this.index)[col]);
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
        ts.Index = Index;
    })(LicenciasRef.ts || (LicenciasRef.ts = {}));
    var ts = LicenciasRef.ts;
})(LicenciasRef || (LicenciasRef = {}));
