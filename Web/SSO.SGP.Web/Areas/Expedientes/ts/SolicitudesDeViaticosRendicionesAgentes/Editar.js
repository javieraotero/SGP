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
        var Editar = /** @class */ (function () {
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $('#Id' + hash);
                this.Rendicion = $('#Rendicion' + hash);
                this.Agente = $('#Agente' + hash);
                this.Dias = $('#Dias' + hash);
                this.ImportePorDia = $('#ImportePorDia' + hash);
                this.Subtotal = $('#Subtotal' + hash);
                this.Gastos = $('#Gastos' + hash);
                this.Anticipo = $('#Anticipo' + hash);
                this.Cobrar = $('#Cobrar' + hash);
                this.Devolver = $('#Devolver' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.validacion();
            }
            Editar.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Id: { required: true, number: true, maxlength: 4 },
                        Rendicion: { required: true, number: true, maxlength: 4 },
                        Agente: { required: true, number: true, maxlength: 4 },
                        Dias: { required: true, decimal: true, maxlength: 9 },
                        ImportePorDia: { required: true, decimal: true, maxlength: 9 },
                        Subtotal: { required: true, decimal: true, maxlength: 9 },
                        Gastos: { required: true, decimal: true, maxlength: 9 },
                        Anticipo: { required: true, decimal: true, maxlength: 9 },
                        Cobrar: { required: true, decimal: true, maxlength: 9 },
                        Devolver: { required: true, decimal: true, maxlength: 9 },
                    },
                    messages: {
                        Id: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Rendicion: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Agente: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Dias: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        ImportePorDia: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        Subtotal: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        Gastos: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        Anticipo: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        Cobrar: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        Devolver: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                    }
                });
            };
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Rendicion.val('').trigger("liszt:updated");
                this.Agente.val('').trigger("liszt:updated");
                this.Dias.val("");
                this.ImportePorDia.val("");
                this.Subtotal.val("");
                this.Gastos.val("");
                this.Anticipo.val("");
                this.Cobrar.val("");
                this.Devolver.val("");
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
    })(ts = SolicitudesDeViaticosRendicionesAgentes.ts || (SolicitudesDeViaticosRendicionesAgentes.ts = {}));
})(SolicitudesDeViaticosRendicionesAgentes || (SolicitudesDeViaticosRendicionesAgentes = {})); // module
