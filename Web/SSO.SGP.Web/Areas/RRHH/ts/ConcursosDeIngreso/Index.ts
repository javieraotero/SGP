/// <reference path="../../../../ts/types/chosen.jquery.d.ts" />
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
module ConcursosDeIngreso.ts {

    export class Index implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public ConcursosDeIngreso: DataTables.DataTable;
        public ConcursosDeIngreso_id: number;
        public ConcursosDeIngreso_index: number;

        constructor(hash: string) {
            this.form = $("#" + hash);
            this.datatables = [];
            //this.validacion();
        }

        public getData(col: number): any {
            //var anSelected = app.fnGetSelected(this.Agentes);
            return (this.ConcursosDeIngreso.fnGetData(this.ConcursosDeIngreso_index)[col]);
        }
       

        public limpiar() {
        }

        public setConcursosDeIngreso(dt: DataTables.DataTable): void {
            var self = this;
            this.ConcursosDeIngreso = dt;

            $("#dtConcursosDeIngreso tbody").click(function (event) {
                $(self.ConcursosDeIngreso.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.ConcursosDeIngreso.fnGetData($(event.target).closest("tr").index())[0];
                self.ConcursosDeIngreso_id = id;
                self.ConcursosDeIngreso_index = $(event.target).closest("tr").index();
            });
        }
     
        public getData_ConcursosDeIngreso(col: number): any {
            return (this.ConcursosDeIngreso.fnGetData(this.ConcursosDeIngreso_index)[col]);
        }

        public selectRow_ConcursosDeIngreso(event) {
            var self = this;
            $(self.ConcursosDeIngreso.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.ConcursosDeIngreso.fnGetData($(event).closest("tr").index())[0];
            self.ConcursosDeIngreso_id = id;
            self.ConcursosDeIngreso_index = $(event).closest("tr").index();
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