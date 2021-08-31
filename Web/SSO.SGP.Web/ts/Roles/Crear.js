/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var Roles;
(function (Roles) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Descripcion = $('#Descripcion' + hash);
                this.MenuInicial = $('#MenuInicial' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.validacion();
            }
            Crear.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Descripcion: { required: true, number: false, maxlength: 250 },
                    },
                    messages: {
                        Descripcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 250 caracteres" },
                    }
                });
            };
            Crear.prototype.limpiar = function () {
                this.Descripcion.val("");
                this.MenuInicial.val('').trigger("liszt:updated");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        })();
        ts.Crear = Crear; //JS
    })(ts = Roles.ts || (Roles.ts = {}));
})(Roles || (Roles = {})); // module
