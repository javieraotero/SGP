/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module MontosDeViaticos.ts {

    export class Index implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public MontosDeViaticos: DataTables.DataTable;
        public MontosDeViaticos_id: number;
        public MontosDeViaticos_index: number;
        constructor(hash: string) {
            this.form = $("#" + hash);
            this.datatables = [];


            this.validacion();
        }

        public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",
                rules: {

                    MontosDeViaticos: { required: true, number: false, maxlength: 0 },
                },
                messages: {

                    MontosDeViaticos: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                }
            });

        }

        public limpiar() {
        }

        public setMontosDeViaticos(dt: DataTables.DataTable): void {
            var self = this;
            this.MontosDeViaticos = dt;

            $("#dtMontosDeViaticos tbody").click(function (event) {
                $(self.MontosDeViaticos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.MontosDeViaticos.fnGetData($(event.target).closest("tr").index())[0];
                self.MontosDeViaticos_id = id;
                self.MontosDeViaticos_index = $(event.target).closest("tr").index();
            });
        }

        public getData_MontosDeViaticos(col: number): any {
            return (this.MontosDeViaticos.fnGetData(this.MontosDeViaticos_index)[col]);
        }

        public selectRow_MontosDeViaticos(event) {
            var self = this;
            $(self.MontosDeViaticos.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.MontosDeViaticos.fnGetData($(event).closest("tr").index())[0];
            self.MontosDeViaticos_id = id;
            self.MontosDeViaticos_index = $(event).closest("tr").index();
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