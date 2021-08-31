/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module VehiculosOficialesRef.ts {

    export class Crear implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public Legajo: JQuery;
        public Patente: JQuery;
        public Descripcion: JQuery;
        public Cancelar: JQuery;
        public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        constructor(hash: string) {
            this.form = $("#" + hash);
            this.datatables = [];
            this.Legajo = $('#Legajo' + hash);
            this.Patente = $('#Patente' + hash);
            this.Descripcion = $('#Descripcion' + hash);
            this.Cancelar = $("#Cancelar" + hash);
            this.Guardar = $("#Guardar" + hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);


            this.validacion();
        }

        public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",
                rules: {

                    Legajo: { required: true, number: false, maxlength: 8 },
                    Patente: { required: false, number: false, maxlength: 10 },
                    Descripcion: { required: true, number: false, maxlength: 150 },
                },
                messages: {

                    Legajo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
                    Patente: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 10 caracteres" },
                    Descripcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                }
            });

        }

        public limpiar() {
            this.Legajo.val("");
            this.Patente.val("");
            this.Descripcion.val("");
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