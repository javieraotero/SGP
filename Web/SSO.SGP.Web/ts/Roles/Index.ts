/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module Roles.ts {

    export class Index implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public Roles: DataTables.DataTable;
        public Roles_id: number;
        public Roles_index: number;

        constructor(hash: string) {
            this.form = $("#" + hash);
            this.datatables = [];
            this.validacion();
        }

        public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",
                rules: {

                    Roles: { required: true, number: false, maxlength: 0 },
                },
                messages: {

                    Roles: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                }
            });

        }

        public limpiar() {
        }

        public setRoles(dt: DataTables.DataTable): void {
            var self = this;
            this.Roles = dt;

            $("#dtRoles tbody").click(function (event) {
                $(self.Roles.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.Roles.fnGetData($(event.target).closest("tr").index())[0];
                self.Roles_id = id;
                self.Roles_index = $(event.target).closest("tr").index();
            });
        }

        public getData_Roles(col: number): any {
            return (this.Roles.fnGetData(this.Roles_index)[col]);
        }

        public selectRow_Roles(event) {
            var self = this;
            $(self.Roles.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.Roles.fnGetData($(event).closest("tr").index())[0];
            self.Roles_id = id;
            self.Roles_index = $(event).closest("tr").index();
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