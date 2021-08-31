/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var EjecucionesPresupuestariasReestructuras;
(function (EjecucionesPresupuestariasReestructuras) {
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
                        EjecucionesPresupuestariasReestructuras: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        EjecucionesPresupuestariasReestructuras: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setEjecucionesPresupuestariasReestructuras = function (dt) {
                var self = this;
                this.EjecucionesPresupuestariasReestructuras = dt;
                $("#dtEjecucionesPresupuestariasReestructuras tbody").click(function (event) {
                    $(self.EjecucionesPresupuestariasReestructuras.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.EjecucionesPresupuestariasReestructuras.fnGetData($(event.target).closest("tr").index())[0];
                    self.EjecucionesPresupuestariasReestructuras_id = id;
                    self.EjecucionesPresupuestariasReestructuras_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_EjecucionesPresupuestariasReestructuras = function (col) {
                return (this.EjecucionesPresupuestariasReestructuras.fnGetData(this.EjecucionesPresupuestariasReestructuras_index)[col]);
            };
            Index.prototype.selectRow_EjecucionesPresupuestariasReestructuras = function (event) {
                var self = this;
                $(self.EjecucionesPresupuestariasReestructuras.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.EjecucionesPresupuestariasReestructuras.fnGetData($(event).closest("tr").index())[0];
                self.EjecucionesPresupuestariasReestructuras_id = id;
                self.EjecucionesPresupuestariasReestructuras_index = $(event).closest("tr").index();
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
    })(ts = EjecucionesPresupuestariasReestructuras.ts || (EjecucionesPresupuestariasReestructuras.ts = {}));
})(EjecucionesPresupuestariasReestructuras || (EjecucionesPresupuestariasReestructuras = {})); // module
