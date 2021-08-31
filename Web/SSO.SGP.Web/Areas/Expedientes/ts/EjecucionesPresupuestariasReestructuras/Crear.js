/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var EjecucionesPresupuestariasReestructuras;
(function (EjecucionesPresupuestariasReestructuras) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Anio = $('#Anio' + hash);
                this.PartidaPresupuestaria = $('#PartidaPresupuestaria' + hash);
                this.Importe = $('#Importe' + hash);
                this.Fecha = $('#Fecha' + hash);
                this.Observaciones = $('#Observaciones' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.validacion();
            }
            Crear.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Anio: { required: true, number: true, maxlength: 4 },
                        PartidaPresupuestaria: { required: true, number: true, maxlength: 4 },
                        Importe: { required: true, decimal: true, maxlength: 9 },
                        Fecha: { required: true, number: false, maxlength: 8 },
                        Observaciones: { required: true, number: false, maxlength: 250 },
                    },
                    messages: {
                        Anio: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        PartidaPresupuestaria: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Importe: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                        Fecha: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                        Observaciones: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 250 caracteres" },
                    }
                });
            };
            Crear.prototype.limpiar = function () {
                this.Anio.val("");
                this.PartidaPresupuestaria.val("");
                this.Importe.val("");
                this.Fecha.val("");
                this.Observaciones.val("");
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
    })(ts = EjecucionesPresupuestariasReestructuras.ts || (EjecucionesPresupuestariasReestructuras.ts = {}));
})(EjecucionesPresupuestariasReestructuras || (EjecucionesPresupuestariasReestructuras = {})); // module
