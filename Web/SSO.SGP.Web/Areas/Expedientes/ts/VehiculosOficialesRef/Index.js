/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var VehiculosOficialesRef;
(function (VehiculosOficialesRef) {
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
                        VehiculosOficialesRef: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        VehiculosOficialesRef: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setVehiculosOficialesRef = function (dt) {
                var self = this;
                this.VehiculosOficialesRef = dt;
                $("#dtVehiculosOficialesRef tbody").click(function (event) {
                    $(self.VehiculosOficialesRef.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.VehiculosOficialesRef.fnGetData($(event.target).closest("tr").index())[0];
                    self.VehiculosOficialesRef_id = id;
                    self.VehiculosOficialesRef_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_VehiculosOficialesRef = function (col) {
                return (this.VehiculosOficialesRef.fnGetData(this.VehiculosOficialesRef_index)[col]);
            };
            Index.prototype.selectRow_VehiculosOficialesRef = function (event) {
                var self = this;
                $(self.VehiculosOficialesRef.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.VehiculosOficialesRef.fnGetData($(event).closest("tr").index())[0];
                self.VehiculosOficialesRef_id = id;
                self.VehiculosOficialesRef_index = $(event).closest("tr").index();
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
    })(ts = VehiculosOficialesRef.ts || (VehiculosOficialesRef.ts = {}));
})(VehiculosOficialesRef || (VehiculosOficialesRef = {})); // module
