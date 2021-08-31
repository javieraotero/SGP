/// <reference path="../../../../ts/types/chosen.jquery.d.ts" />
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
module ConcursosDeIngresoInscripciones.ts {

    export class Index implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public ConcursosDeIngresoInscripciones: DataTables.DataTable;
        public ConcursosDeIngresoInscripciones_id: number;
        public ConcursosDeIngresoInscripciones_index: number;

        constructor(hash: string) {
            this.form = $("#" + hash);
            this.datatables = [];
            //this.validacion();
        }

        

        public limpiar() {
        }

        public setConcursosDeIngresoInscripciones(dt: DataTables.DataTable): void {
            var self = this;
            this.ConcursosDeIngresoInscripciones = dt;

            $("#dtConcursosDeIngresoInscripciones tbody").click(function (event) {
                $(self.ConcursosDeIngresoInscripciones.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.ConcursosDeIngresoInscripciones.fnGetData($(event.target).closest("tr").index())[0];
                self.ConcursosDeIngresoInscripciones_id = id;
                self.ConcursosDeIngresoInscripciones_index = $(event.target).closest("tr").index();
            });
        }

        public getData_ConcursosDeIngresoInscripciones(col: number): any {
            return (this.ConcursosDeIngresoInscripciones.fnGetData(this.ConcursosDeIngresoInscripciones_index)[col]);
        }

        public selectRow_ConcursosDeIngresoInscripciones(event) {
            var self = this;
            $(self.ConcursosDeIngresoInscripciones.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.ConcursosDeIngresoInscripciones.fnGetData($(event).closest("tr").index())[0];
            self.ConcursosDeIngresoInscripciones_id = id;
            self.ConcursosDeIngresoInscripciones_index = $(event).closest("tr").index();
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