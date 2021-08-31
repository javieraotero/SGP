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
        var Editar = /** @class */ (function () {
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $('#Id' + hash);
                this.SolicitudDeViatico = $('#SolicitudDeViatico' + hash);
                this.FechaDeInicio = $('#FechaDeInicio' + hash);
                this.FechaDeFin = $('#FechaDeFin' + hash);
                this.TotalBienesDeConsumo = $('#TotalBienesDeConsumo' + hash);
                this.TotalServiciosNoPersonales = $('#TotalServiciosNoPersonales' + hash);
                this.TotalOtros = $('#TotalOtros' + hash);
                this.FechaDeAlta = $('#FechaDeAlta' + hash);
                this.UsuarioAlta = $('#UsuarioAlta' + hash);
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
                        FechaDeInicio: { required: true, number: false, maxlength: 12 },
                        FechaDeFin: { required: true, number: false, maxlength: 12 },
                        TotalBienesDeConsumo: { required: true, decimal: true, maxlength: 9 },
                        TotalServiciosNoPersonales: { required: true, decimal: true, maxlength: 9 },
                        TotalOtros: { required: true, decimal: true, maxlength: 9 },
                        FechaDeAlta: { required: true, number: false, maxlength: 12 },
                        UsuarioAlta: { required: true, number: true, maxlength: 4 },
                    },
                    messages: {
                        Id: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        SolicitudDeViatico: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        FechaDeInicio: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        FechaDeFin: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        TotalBienesDeConsumo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        TotalServiciosNoPersonales: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        TotalOtros: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        FechaDeAlta: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        UsuarioAlta: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                    }
                });
            };
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.SolicitudDeViatico.val('').trigger("liszt:updated");
                this.FechaDeInicio.val("");
                this.FechaDeFin.val("");
                this.TotalBienesDeConsumo.val("");
                this.TotalServiciosNoPersonales.val("");
                this.TotalOtros.val("");
                this.FechaDeAlta.val("");
                this.UsuarioAlta.val("");
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
    })(ts = SolicitudesDeViaticosRendiciones.ts || (SolicitudesDeViaticosRendiciones.ts = {}));
})(SolicitudesDeViaticosRendiciones || (SolicitudesDeViaticosRendiciones = {})); // module
