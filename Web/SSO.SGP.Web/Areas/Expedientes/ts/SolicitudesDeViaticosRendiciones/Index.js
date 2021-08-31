/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var SolicitudesDeViaticosRendiciones;
(function (SolicitudesDeViaticosRendiciones) {
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
                        SolicitudesDeViaticosRendiciones: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        SolicitudesDeViaticosRendiciones: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setSolicitudesDeViaticosRendiciones = function (dt) {
                var self = this;
                this.SolicitudesDeViaticosRendiciones = dt;
                $("#dtSolicitudesDeViaticosRendiciones tbody").click(function (event) {
                    $(self.SolicitudesDeViaticosRendiciones.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.SolicitudesDeViaticosRendiciones.fnGetData($(event.target).closest("tr").index())[0];
                    self.SolicitudesDeViaticosRendiciones_id = id;
                    self.SolicitudesDeViaticosRendiciones_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_SolicitudesDeViaticosRendiciones = function (col) {
                return (this.SolicitudesDeViaticosRendiciones.fnGetData(this.SolicitudesDeViaticosRendiciones_index)[col]);
            };
            Index.prototype.selectRow_SolicitudesDeViaticosRendiciones = function (event) {
                var self = this;
                $(self.SolicitudesDeViaticosRendiciones.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosRendiciones.fnGetData($(event).closest("tr").index())[0];
                self.SolicitudesDeViaticosRendiciones_id = id;
                self.SolicitudesDeViaticosRendiciones_index = $(event).closest("tr").index();
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
    })(ts = SolicitudesDeViaticosRendiciones.ts || (SolicitudesDeViaticosRendiciones.ts = {}));
})(SolicitudesDeViaticosRendiciones || (SolicitudesDeViaticosRendiciones = {})); // module
