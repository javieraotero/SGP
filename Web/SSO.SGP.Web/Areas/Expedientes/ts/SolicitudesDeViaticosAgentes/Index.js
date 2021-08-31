/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var SolicitudesDeViaticosAgentes;
(function (SolicitudesDeViaticosAgentes) {
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
                        SolicitudesDeViaticosAgentes: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        SolicitudesDeViaticosAgentes: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setSolicitudesDeViaticosAgentes = function (dt) {
                var self = this;
                this.SolicitudesDeViaticosAgentes = dt;
                $("#dtSolicitudesDeViaticosAgentes tbody").click(function (event) {
                    $(self.SolicitudesDeViaticosAgentes.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.SolicitudesDeViaticosAgentes.fnGetData($(event.target).closest("tr").index())[0];
                    self.SolicitudesDeViaticosAgentes_id = id;
                    self.SolicitudesDeViaticosAgentes_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_SolicitudesDeViaticosAgentes = function (col) {
                return (this.SolicitudesDeViaticosAgentes.fnGetData(this.SolicitudesDeViaticosAgentes_index)[col]);
            };
            Index.prototype.selectRow_SolicitudesDeViaticosAgentes = function (event) {
                var self = this;
                $(self.SolicitudesDeViaticosAgentes.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosAgentes.fnGetData($(event).closest("tr").index())[0];
                self.SolicitudesDeViaticosAgentes_id = id;
                self.SolicitudesDeViaticosAgentes_index = $(event).closest("tr").index();
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
    })(ts = SolicitudesDeViaticosAgentes.ts || (SolicitudesDeViaticosAgentes.ts = {}));
})(SolicitudesDeViaticosAgentes || (SolicitudesDeViaticosAgentes = {})); // module
