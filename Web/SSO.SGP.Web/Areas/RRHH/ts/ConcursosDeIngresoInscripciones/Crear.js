/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var ConcursosDeIngresoInscripciones;
(function (ConcursosDeIngresoInscripciones) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.ConcursoDeIngreso = $('#ConcursoDeIngreso' + hash);
                this.FechaPreinscripcion = $('#FechaPreinscripcion' + hash);
                this.Apellido = $('#Apellido' + hash);
                this.Nombres = $('#Nombres' + hash);
                this.DNI = $('#DNI' + hash);
                this.FechaDeNacimiento = $('#FechaDeNacimiento' + hash);
                this.Domicilio = $('#Domicilio' + hash);
                this.Ciudad = $('#Ciudad' + hash);
                this.Provincia = $('#Provincia' + hash);
                this.Telefono = $('#Telefono' + hash);
                this.Email = $('#Email' + hash);
                this.TituloSecundario = $('#TituloSecundario' + hash);
                this.ExpedidoPor = $('#ExpedidoPor' + hash);
                this.FechaExpedido = $('#FechaExpedido' + hash);
                this.TituloUniversitario = $('#TituloUniversitario' + hash);
                this.TituloUniversitarioFecha = $('#TituloUniversitarioFecha' + hash);
                this.TituloUniversitarioExpedido = $('#TituloUniversitarioExpedido' + hash);
                this.AntecedentesAcademicos = $('#AntecedentesAcademicos' + hash);
                this.AntecedentesLaborales = $('#AntecedentesLaborales' + hash);
                this.FechaRecepcion = $('#FechaRecepcion' + hash);
                this.UsuarioRecepcion = $('#UsuarioRecepcion' + hash);
                this.Token = $('#Token' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.validacion();
            }
            Crear.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        ConcursoDeIngreso: { required: true, number: true, maxlength: 4 },
                        FechaPreinscripcion: { required: false, number: false, maxlength: 8 },
                        Apellido: { required: false, number: false, maxlength: 50 },
                        Nombres: { required: false, number: false, maxlength: 70 },
                        DNI: { required: false, number: false, maxlength: 8 },
                        FechaDeNacimiento: { required: false, number: false, maxlength: 8 },
                        Domicilio: { required: false, number: false, maxlength: 150 },
                        Ciudad: { required: false, number: false, maxlength: 150 },
                        Provincia: { required: false, number: false, maxlength: 50 },
                        Telefono: { required: false, number: false, maxlength: 20 },
                        Email: { required: false, number: false, maxlength: 150 },
                        TituloSecundario: { required: false, number: false, maxlength: 150 },
                        ExpedidoPor: { required: false, number: false, maxlength: 100 },
                        FechaExpedido: { required: false, number: false, maxlength: 8 },
                        TituloUniversitario: { required: false, number: false, maxlength: 150 },
                        TituloUniversitarioFecha: { required: false, number: false, maxlength: 8 },
                        TituloUniversitarioExpedido: { required: false, number: false, maxlength: 150 },
                        AntecedentesAcademicos: { required: false, number: false, maxlength: -1 },
                        AntecedentesLaborales: { required: false, number: false, maxlength: -1 },
                        FechaRecepcion: { required: false, number: false, maxlength: 8 },
                        UsuarioRecepcion: { required: false, number: true, maxlength: 4 },
                        Token: { required: false, number: false, maxlength: 150 },
                    },
                    messages: {
                        ConcursoDeIngreso: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        FechaPreinscripcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                        Apellido: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 50 caracteres" },
                        Nombres: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 70 caracteres" },
                        DNI: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                        FechaDeNacimiento: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                        Domicilio: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        Ciudad: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        Provincia: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 50 caracteres" },
                        Telefono: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 20 caracteres" },
                        Email: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        TituloSecundario: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        ExpedidoPor: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 100 caracteres" },
                        FechaExpedido: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                        TituloUniversitario: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        TituloUniversitarioFecha: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                        TituloUniversitarioExpedido: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        AntecedentesAcademicos: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los -1 caracteres" },
                        AntecedentesLaborales: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los -1 caracteres" },
                        FechaRecepcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                        UsuarioRecepcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Token: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                    }
                });
            };
            Crear.prototype.limpiar = function () {
                this.ConcursoDeIngreso.val("");
                this.FechaPreinscripcion.val("");
                this.Apellido.val("");
                this.Nombres.val("");
                this.DNI.val("");
                this.FechaDeNacimiento.val("");
                this.Domicilio.val("");
                this.Ciudad.val("");
                this.Provincia.val("");
                this.Telefono.val("");
                this.Email.val("");
                this.TituloSecundario.val("");
                this.ExpedidoPor.val("");
                this.FechaExpedido.val("");
                this.TituloUniversitario.val("");
                this.TituloUniversitarioFecha.val("");
                this.TituloUniversitarioExpedido.val("");
                this.AntecedentesAcademicos.val("");
                this.AntecedentesLaborales.val("");
                this.FechaRecepcion.val("");
                this.UsuarioRecepcion.val("");
                this.Token.val("");
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
    })(ts = ConcursosDeIngresoInscripciones.ts || (ConcursosDeIngresoInscripciones.ts = {}));
})(ConcursosDeIngresoInscripciones || (ConcursosDeIngresoInscripciones = {})); // module
