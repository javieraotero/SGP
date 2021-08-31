/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var SolicitudesDeViaticos;
(function (SolicitudesDeViaticos) {
    var ts;
    (function (ts) {
        var CrearRendicion = (function () {
            function CrearRendicion(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Fecha = $('#Fecha' + hash);
                this.OrganismoSolicitante = $('#OrganismoSolicitante' + hash);
                //this.Destino = new SyncroAutocomplete("Destino" + hash, "Expedientes/MontosDeViaticos/JsonOptionsLocalidades");
                this.FechaDeInicio = $('#FechaDeInicio' + hash);
                this.FechaDeFin = $('#FechaDeFin' + hash);
                this.MedioDeTransporte = $('#MedioDeTransporte' + hash);
                this.AutoOficial = $('#AutoOficial' + hash);
                this.ConChofer = $('#ConChofer' + hash);
                this.Estado = $('#Estado' + hash);
                this.MotivoDeComision = $('#MotivoDeComision' + hash);
                this.Expediente = $('#Expediente' + hash);
                this.Identificador = $('#Identificador' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.bodyAgente = $("#bodyAgentes" + hash);
                this.spTotalAnticipo = $("#TotalAnticipo" + hash);
                this.spTotalCobrar = $("#TotalCobrar" + hash);
                this.spTotalDevolver = $("#TotalDevolver" + hash);
                this.spTotalGastos = $("#TotalGastos" + hash);
                this.spTotalTotal = $("#TotalTotal" + hash);
                this.Id = $("#Id" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                //this.Agente = new SyncroAutocomplete("Agente" + hash, "RRHH/Agentes/GetJson");
                this.validacion();
            }
            CrearRendicion.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Fecha: { required: true, number: false, maxlength: 12 },
                        OrganismoSolicitante: { required: true, number: true, maxlength: 4 },
                        Destino: { required: true, number: true, maxlength: 4 },
                        FechaDeInicio: { required: true, number: false, maxlength: 12 },
                        FechaDeFin: { required: true, number: false, maxlength: 12 },
                        MedioDeTransporte: { required: true, number: true, maxlength: 4 },
                        AutoOficial: { required: false, number: true, maxlength: 4 },
                        ConChofer: { required: true, number: false, maxlength: 1 },
                        Estado: { required: true, number: true, maxlength: 4 },
                        MotivoDeComision: { required: true, number: false, maxlength: 150 },
                        Expediente: { required: false, number: false, maxlength: 10 },
                        Identificador: { required: true, number: true, maxlength: 4 }, },
                    messages: {
                        Fecha: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        OrganismoSolicitante: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Destino: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        FechaDeInicio: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        FechaDeFin: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        MedioDeTransporte: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        AutoOficial: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        ConChofer: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 1 caracteres" },
                        Estado: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        MotivoDeComision: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        Expediente: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 10 caracteres" },
                        Identificador: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" }, }
                });
            };
            CrearRendicion.prototype.limpiar = function () {
                this.Fecha.val("");
                this.OrganismoSolicitante.val("");
                this.Destino.val("");
                this.FechaDeInicio.val("");
                this.FechaDeFin.val("");
                this.MedioDeTransporte.val("");
                this.AutoOficial.val("");
                this.ConChofer.removeAttr('checked');
                this.Estado.val("");
                this.MotivoDeComision.val("");
                this.Expediente.val("");
                this.Identificador.val("");
            };
            CrearRendicion.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            CrearRendicion.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return CrearRendicion;
        })();
        ts.CrearRendicion = CrearRendicion; //JS
    })(ts = SolicitudesDeViaticos.ts || (SolicitudesDeViaticos.ts = {}));
})(SolicitudesDeViaticos || (SolicitudesDeViaticos = {})); // module
