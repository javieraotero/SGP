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
        var Crear = /** @class */ (function () {
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.SolicitudDeViatico = $('#SolicitudDeViatico' + hash);
                this.FechaDeInicio = $('#FechaDeInicio' + hash);
                this.FechaDeFin = $('#FechaDeFin' + hash);
                this.TotalBienesDeConsumo = $('#TotalBienesDeConsumo' + hash);
                this.TotalServiciosNoPersonales = $('#TotalServiciosNoPersonales' + hash);
                this.TotalOtros = $('#TotalOtros' + hash);
                this.FechaDeAlta = $('#FechaDeAlta' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.validacion();
            }
            Crear.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        SolicitudDeViatico: { required: true, number: true, maxlength: 4 },
                        FechaDeInicio: { required: true, number: false, maxlength: 12 },
                        FechaDeFin: { required: true, number: false, maxlength: 12 },
                        TotalBienesDeConsumo: { required: true, decimal: true, maxlength: 9 },
                        TotalServiciosNoPersonales: { required: true, decimal: true, maxlength: 9 },
                        TotalOtros: { required: true, decimal: true, maxlength: 9 },
                        FechaDeAlta: { required: true, number: false, maxlength: 12 },
                    },
                    messages: {
                        SolicitudDeViatico: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        FechaDeInicio: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        FechaDeFin: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        TotalBienesDeConsumo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        TotalServiciosNoPersonales: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        TotalOtros: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        FechaDeAlta: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                    }
                });
            };
            Crear.prototype.limpiar = function () {
                this.SolicitudDeViatico.val('').trigger("liszt:updated");
                this.FechaDeInicio.val("");
                this.FechaDeFin.val("");
                this.TotalBienesDeConsumo.val("");
                this.TotalServiciosNoPersonales.val("");
                this.TotalOtros.val("");
                this.FechaDeAlta.val("");
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
    })(ts = SolicitudesDeViaticosRendiciones.ts || (SolicitudesDeViaticosRendiciones.ts = {}));
})(SolicitudesDeViaticosRendiciones || (SolicitudesDeViaticosRendiciones = {})); // module
