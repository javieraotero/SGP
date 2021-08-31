/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var Roles;
(function (Roles) {
    var ts;
    (function (ts) {
        var Index = (function () {
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.validacion();
            }
            Index.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Roles: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        Roles: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setRoles = function (dt) {
                var self = this;
                this.Roles = dt;
                $("#dtRoles tbody").click(function (event) {
                    $(self.Roles.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.Roles.fnGetData($(event.target).closest("tr").index())[0];
                    self.Roles_id = id;
                    self.Roles_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_Roles = function (col) {
                return (this.Roles.fnGetData(this.Roles_index)[col]);
            };
            Index.prototype.selectRow_Roles = function (event) {
                var self = this;
                $(self.Roles.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.Roles.fnGetData($(event).closest("tr").index())[0];
                self.Roles_id = id;
                self.Roles_index = $(event).closest("tr").index();
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
        })();
        ts.Index = Index; //JS
    })(ts = Roles.ts || (Roles.ts = {}));
})(Roles || (Roles = {})); // module
