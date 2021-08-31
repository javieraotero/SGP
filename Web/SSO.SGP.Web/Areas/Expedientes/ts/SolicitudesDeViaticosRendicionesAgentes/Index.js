/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var SolicitudesDeViaticosRendicionesAgentes;
(function (SolicitudesDeViaticosRendicionesAgentes) {
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
                        SolicitudesDeViaticosRendicionesAgentes: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        SolicitudesDeViaticosRendicionesAgentes: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setSolicitudesDeViaticosRendicionesAgentes = function (dt) {
                var self = this;
                this.SolicitudesDeViaticosRendicionesAgentes = dt;
                $("#dtSolicitudesDeViaticosRendicionesAgentes tbody").click(function (event) {
                    $(self.SolicitudesDeViaticosRendicionesAgentes.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.SolicitudesDeViaticosRendicionesAgentes.fnGetData($(event.target).closest("tr").index())[0];
                    self.SolicitudesDeViaticosRendicionesAgentes_id = id;
                    self.SolicitudesDeViaticosRendicionesAgentes_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_SolicitudesDeViaticosRendicionesAgentes = function (col) {
                return (this.SolicitudesDeViaticosRendicionesAgentes.fnGetData(this.SolicitudesDeViaticosRendicionesAgentes_index)[col]);
            };
            Index.prototype.selectRow_SolicitudesDeViaticosRendicionesAgentes = function (event) {
                var self = this;
                $(self.SolicitudesDeViaticosRendicionesAgentes.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosRendicionesAgentes.fnGetData($(event).closest("tr").index())[0];
                self.SolicitudesDeViaticosRendicionesAgentes_id = id;
                self.SolicitudesDeViaticosRendicionesAgentes_index = $(event).closest("tr").index();
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
    })(ts = SolicitudesDeViaticosRendicionesAgentes.ts || (SolicitudesDeViaticosRendicionesAgentes.ts = {}));
})(SolicitudesDeViaticosRendicionesAgentes || (SolicitudesDeViaticosRendicionesAgentes = {})); // module
