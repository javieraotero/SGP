/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var MontosDeViaticos;
(function (MontosDeViaticos) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.validacion();
            }
            Index.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        MontosDeViaticos: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        MontosDeViaticos: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setMontosDeViaticos = function (dt) {
                var self = this;
                this.MontosDeViaticos = dt;
                $("#dtMontosDeViaticos tbody").click(function (event) {
                    $(self.MontosDeViaticos.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.MontosDeViaticos.fnGetData($(event.target).closest("tr").index())[0];
                    self.MontosDeViaticos_id = id;
                    self.MontosDeViaticos_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_MontosDeViaticos = function (col) {
                return (this.MontosDeViaticos.fnGetData(this.MontosDeViaticos_index)[col]);
            };
            Index.prototype.selectRow_MontosDeViaticos = function (event) {
                var self = this;
                $(self.MontosDeViaticos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.MontosDeViaticos.fnGetData($(event).closest("tr").index())[0];
                self.MontosDeViaticos_id = id;
                self.MontosDeViaticos_index = $(event).closest("tr").index();
            };
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
    })(ts = MontosDeViaticos.ts || (MontosDeViaticos.ts = {}));
})(MontosDeViaticos || (MontosDeViaticos = {})); // module
