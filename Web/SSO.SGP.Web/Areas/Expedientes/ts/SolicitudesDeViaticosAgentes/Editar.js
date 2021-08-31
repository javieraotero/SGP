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
        var Editar = /** @class */ (function () {
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $('#Id' + hash);
                this.SolicitudDeViatico = $('#SolicitudDeViatico' + hash);
                this.Agente = $('#Agente' + hash);
                this.Dias = $('#Dias' + hash);
                this.ImportePorDia = $('#ImportePorDia' + hash);
                this.Subtotal = $('#Subtotal' + hash);
                this.ImporteGastos = $('#ImporteGastos' + hash);
                this.ImporteTotal = $('#ImporteTotal' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.validacion();
            }
            Editar.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Id: { required: true, number: true, maxlength: 4 },
                        SolicitudDeViatico: { required: true, number: true, maxlength: 4 },
                        Agente: { required: true, number: true, maxlength: 4 },
                        Dias: { required: true, number: true, maxlength: 4 },
                        ImportePorDia: { required: true, decimal: true, maxlength: 9 },
                        Subtotal: { required: true, decimal: true, maxlength: 9 },
                        ImporteGastos: { required: true, decimal: true, maxlength: 9 },
                        ImporteTotal: { required: true, decimal: true, maxlength: 9 },
                    },
                    messages: {
                        Id: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        SolicitudDeViatico: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Agente: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Dias: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        ImportePorDia: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        Subtotal: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        ImporteGastos: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        ImporteTotal: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                    }
                });
            };
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.SolicitudDeViatico.val('').trigger("liszt:updated");
                this.Agente.val('').trigger("liszt:updated");
                this.Dias.val("");
                this.ImportePorDia.val("");
                this.Subtotal.val("");
                this.ImporteGastos.val("");
                this.ImporteTotal.val("");
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
    })(ts = SolicitudesDeViaticosAgentes.ts || (SolicitudesDeViaticosAgentes.ts = {}));
})(SolicitudesDeViaticosAgentes || (SolicitudesDeViaticosAgentes = {})); // module
