/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var MontosDeViaticos;
(function (MontosDeViaticos) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.FechaInicioVigencia = $('#FechaInicioVigencia' + hash);
                this.FuncionarioProvinciaUnDia = $('#FuncionarioProvinciaUnDia' + hash);
                this.FuncionarioProvinciaMasUnDia = $('#FuncionarioProvinciaMasUnDia' + hash);
                this.FuncionarioFueraUnDia = $('#FuncionarioFueraUnDia' + hash);
                this.FuncionarioFueraMasUnDia = $('#FuncionarioFueraMasUnDia' + hash);
                this.FuncionarioProvincia25Mayo = $('#FuncionarioProvincia25Mayo' + hash);
                this.AgenteProvinciaUnDia1 = $('#AgenteProvinciaUnDia1' + hash);
                this.AgenteProvinciaMasUnDia1 = $('#AgenteProvinciaMasUnDia1' + hash);
                this.AgenteFueraUnDia1 = $('#AgenteFueraUnDia1' + hash);
                this.AgenteProvincia25Mayo1 = $('#AgenteProvincia25Mayo1' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.validacion();
            }
            Crear.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        FechaInicioVigencia: { required: true, number: false, maxlength: 12 },
                        FuncionarioProvinciaUnDia: { required: true, decimal: true, maxlength: 9 },
                        FuncionarioProvinciaMasUnDia: { required: true, decimal: true, maxlength: 9 },
                        FuncionarioFueraUnDia: { required: true, decimal: true, maxlength: 9 },
                        FuncionarioFueraMasUnDia: { required: true, decimal: true, maxlength: 9 },
                        FuncionarioProvincia25Mayo: { required: true, decimal: true, maxlength: 9 },
                        AgenteProvinciaUnDia1: { required: true, decimal: true, maxlength: 9 },
                        AgenteProvinciaMasUnDia1: { required: true, decimal: true, maxlength: 9 },
                        AgenteFueraUnDia1: { required: true, decimal: true, maxlength: 9 },
                        AgenteProvincia25Mayo1: { required: true, decimal: true, maxlength: 9 },
                    },
                    messages: {
                        FechaInicioVigencia: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 12 caracteres" },
                        FuncionarioProvinciaUnDia: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        FuncionarioProvinciaMasUnDia: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        FuncionarioFueraUnDia: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        FuncionarioFueraMasUnDia: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        FuncionarioProvincia25Mayo: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        AgenteProvinciaUnDia1: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        AgenteProvinciaMasUnDia1: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        AgenteFueraUnDia1: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                        AgenteProvincia25Mayo1: { required: "Debe ingresar un valor", number: "Ingrese un valor n??merico", maxlength: "El campo no puede superar los 9 caracteres" },
                    }
                });
            };
            Crear.prototype.limpiar = function () {
                this.FechaInicioVigencia.val("");
                this.FuncionarioProvinciaUnDia.val("");
                this.FuncionarioProvinciaMasUnDia.val("");
                this.FuncionarioFueraUnDia.val("");
                this.FuncionarioFueraMasUnDia.val("");
                this.FuncionarioProvincia25Mayo.val("");
                this.AgenteProvinciaUnDia1.val("");
                this.AgenteProvinciaMasUnDia1.val("");
                this.AgenteFueraUnDia1.val("");
                this.AgenteProvincia25Mayo1.val("");
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
    })(ts = MontosDeViaticos.ts || (MontosDeViaticos.ts = {}));
})(MontosDeViaticos || (MontosDeViaticos = {})); // module
