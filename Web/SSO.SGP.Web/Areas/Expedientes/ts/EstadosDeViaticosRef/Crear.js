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
        var Crear = /** @class */ (function () {
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Descripcion = $('#Descripcion' + hash);
                this.EditaOrganismo = $('#EditaOrganismo' + hash);
                this.EditaEconomia = $('#EditaEconomia' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.validacion();
            }
            Crear.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Descripcion: { required: true, number: false, maxlength: 50 },
                        EditaOrganismo: { required: true, number: false, maxlength: 1 },
                        EditaEconomia: { required: true, number: false, maxlength: 1 },
                    },
                    messages: {
                        Descripcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 50 caracteres" },
                        EditaOrganismo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 1 caracteres" },
                        EditaEconomia: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 1 caracteres" },
                    }
                });
            };
            Crear.prototype.limpiar = function () {
                this.Descripcion.val("");
                this.EditaOrganismo.removeAttr('checked');
                this.EditaEconomia.removeAttr('checked');
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
        }()); //JS
        ts.Crear = Crear;
    })(ts = EstadosDeViaticosRef.ts || (EstadosDeViaticosRef.ts = {}));
})(EstadosDeViaticosRef || (EstadosDeViaticosRef = {})); // module
