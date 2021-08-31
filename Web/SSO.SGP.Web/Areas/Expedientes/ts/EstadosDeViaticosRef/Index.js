/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var EstadosDeViaticosRef;
(function (EstadosDeViaticosRef) {
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
                        EstadosDeViaticosRef: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        EstadosDeViaticosRef: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setEstadosDeViaticosRef = function (dt) {
                var self = this;
                this.EstadosDeViaticosRef = dt;
                $("#dtEstadosDeViaticosRef tbody").click(function (event) {
                    $(self.EstadosDeViaticosRef.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.EstadosDeViaticosRef.fnGetData($(event.target).closest("tr").index())[0];
                    self.EstadosDeViaticosRef_id = id;
                    self.EstadosDeViaticosRef_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_EstadosDeViaticosRef = function (col) {
                return (this.EstadosDeViaticosRef.fnGetData(this.EstadosDeViaticosRef_index)[col]);
            };
            Index.prototype.selectRow_EstadosDeViaticosRef = function (event) {
                var self = this;
                $(self.EstadosDeViaticosRef.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.EstadosDeViaticosRef.fnGetData($(event).closest("tr").index())[0];
                self.EstadosDeViaticosRef_id = id;
                self.EstadosDeViaticosRef_index = $(event).closest("tr").index();
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
    })(ts = EstadosDeViaticosRef.ts || (EstadosDeViaticosRef.ts = {}));
})(EstadosDeViaticosRef || (EstadosDeViaticosRef = {})); // module
