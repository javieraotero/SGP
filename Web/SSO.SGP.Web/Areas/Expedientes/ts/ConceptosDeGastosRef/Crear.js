/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var ConceptosDeGastosRef;
(function (ConceptosDeGastosRef) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Descripcion = $('#Descripcion' + hash);
                this.Partida = $('#Partida' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.validacion();
            }
            Crear.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Descripcion: { required: true, number: false, maxlength: 150 },
                        Partida: { required: true, number: true, maxlength: 4 },
                    },
                    messages: {
                        Descripcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        Partida: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                    }
                });
            };
            Crear.prototype.limpiar = function () {
                this.Descripcion.val("");
                this.Partida.val("");
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
    })(ts = ConceptosDeGastosRef.ts || (ConceptosDeGastosRef.ts = {}));
})(ConceptosDeGastosRef || (ConceptosDeGastosRef = {})); // module
