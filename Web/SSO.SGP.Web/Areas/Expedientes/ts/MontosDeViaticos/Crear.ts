/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module MontosDeViaticos.ts {

    export class Crear implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public FechaInicioVigencia: JQuery;
        public FuncionarioProvinciaUnDia: JQuery;
        public FuncionarioProvinciaMasUnDia: JQuery;
        public FuncionarioFueraUnDia: JQuery;
        public FuncionarioFueraMasUnDia: JQuery;
        public FuncionarioProvincia25Mayo: JQuery;
        public AgenteProvinciaUnDia1: JQuery;
        public AgenteProvinciaMasUnDia1: JQuery;
        public AgenteFueraUnDia1: JQuery;
        public AgenteProvincia25Mayo1: JQuery;
        public Cancelar: JQuery;
        public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        constructor(hash: string) {
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

        public validacion() {
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

                    FechaInicioVigencia: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                    FuncionarioProvinciaUnDia: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                    FuncionarioProvinciaMasUnDia: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                    FuncionarioFueraUnDia: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                    FuncionarioFueraMasUnDia: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                    FuncionarioProvincia25Mayo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                    AgenteProvinciaUnDia1: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                    AgenteProvinciaMasUnDia1: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                    AgenteFueraUnDia1: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                    AgenteProvincia25Mayo1: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 9 caracteres" },
                }
            });

        }

        public limpiar() {
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
        }


        public fnRegistrarDataTable(d: DataTables.DataTable): void {
            this.datatables.push(d);
        }

        public fnRefrescarDataTables(): void {
            var that = this;
            this.datatables.forEach(function (d) {
                d.fnDraw();
            });
        }
    } //JS
} // module