/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module EjecucionesPresupuestariasReestructuras.ts {

    export class Index implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public EjecucionesPresupuestariasReestructuras: DataTables.DataTable;
								public EjecucionesPresupuestariasReestructuras_id: number;
        public EjecucionesPresupuestariasReestructuras_index: number;

        constructor(hash: string) {
            this.form = $("#" + hash);
            this.datatables = [];
            this.validacion();
        }

        public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",
                rules: {

                    EjecucionesPresupuestariasReestructuras: { required: true, number: false, maxlength: 0 },
                },
                messages: {

                    EjecucionesPresupuestariasReestructuras: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                }
            });

        }

        public limpiar() {
        }

        public setEjecucionesPresupuestariasReestructuras(dt: DataTables.DataTable): void {
            var self = this;
            this.EjecucionesPresupuestariasReestructuras = dt;

            $("#dtEjecucionesPresupuestariasReestructuras tbody").click(function (event) {
                $(self.EjecucionesPresupuestariasReestructuras.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.EjecucionesPresupuestariasReestructuras.fnGetData($(event.target).closest("tr").index())[0];
                self.EjecucionesPresupuestariasReestructuras_id = id;
                self.EjecucionesPresupuestariasReestructuras_index = $(event.target).closest("tr").index();
            });
        }

        public getData_EjecucionesPresupuestariasReestructuras(col: number): any {
            return (this.EjecucionesPresupuestariasReestructuras.fnGetData(this.EjecucionesPresupuestariasReestructuras_index)[col]);
        }

        public selectRow_EjecucionesPresupuestariasReestructuras(event) {
            var self = this;
            $(self.EjecucionesPresupuestariasReestructuras.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.EjecucionesPresupuestariasReestructuras.fnGetData($(event).closest("tr").index())[0];
            self.EjecucionesPresupuestariasReestructuras_id = id;
            self.EjecucionesPresupuestariasReestructuras_index = $(event).closest("tr").index();
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