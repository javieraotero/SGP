/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module Roles.ts {

    export class Crear implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public Descripcion: JQuery;
        public MenuInicial: JQuery;
        public Cancelar: JQuery;
        public Guardar: JQuery;
        public GuardarYNuevo: JQuery;

        constructor(hash: string) {
            this.form = $("#" + hash);
            this.datatables = [];
            this.Descripcion = $('#Descripcion' + hash);
            this.MenuInicial = $('#MenuInicial' + hash);
            this.Cancelar = $("#Cancelar" + hash);
            this.Guardar = $("#Guardar" + hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
            this.validacion();
        }

        public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",
                rules: {

                    Descripcion: { required: true, number: false, maxlength: 250 },
                },
                messages: {

                    Descripcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 250 caracteres" },
                }
            });

        }

        public limpiar() {
            this.Descripcion.val("");
            this.MenuInicial.val('').trigger("liszt:updated");
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