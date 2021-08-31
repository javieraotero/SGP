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
        var Editar = /** @class */ (function () {
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $('#Id' + hash);
                this.Descripcion = $('#Descripcion' + hash);
                this.Partida = $('#Partida' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.validacion();
            }
            Editar.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Id: { required: true, number: true, maxlength: 4 },
                        Descripcion: { required: true, number: false, maxlength: 150 },
                        Partida: { required: true, number: true, maxlength: 4 },
                    },
                    messages: {
                        Id: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Descripcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        Partida: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                    }
                });
            };
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Descripcion.val("");
                this.Partida.val("");
            };
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = ConceptosDeGastosRef.ts || (ConceptosDeGastosRef.ts = {}));
})(ConceptosDeGastosRef || (ConceptosDeGastosRef = {})); // module
