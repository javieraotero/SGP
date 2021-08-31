/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module ArchivosAdjuntos.ts {

    export class Index implements IControlador {

        public form: JQuery;
        public datatables: DataTables.DataTable[];
        public ArchivosAdjuntos: DataTables.DataTable;
								public ArchivosAdjuntos_id: number;
        public ArchivosAdjuntos_index: number;

        constructor(hash: string) {
            this.form = $("#" + hash);
            this.datatables = [];
            //this.validacion();
        }

        //public validacion() {
        //          this.form.validate({
        //              errorClass: "field-validation-error",                
        //              rules: {
				                    
        //			ArchivosAdjuntos:{required:true, number:false, maxlength:0 },
        //			                },
        //              messages: {
					 
        //			ArchivosAdjuntos: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},
        //			                }
        //          });

        //      }

        public limpiar() {
        }

        public setArchivosAdjuntos(dt: DataTables.DataTable): void {
            var self = this;
            this.ArchivosAdjuntos = dt;

            $("#dtArchivosAdjuntos tbody").click(function (event) {
                $(self.ArchivosAdjuntos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.ArchivosAdjuntos.fnGetData($(event.target).closest("tr").index())[0];
                self.ArchivosAdjuntos_id = id;
                self.ArchivosAdjuntos_index = $(event.target).closest("tr").index();
            });
        }

        public getData_ArchivosAdjuntos(col: number): any {
            return (this.ArchivosAdjuntos.fnGetData(this.ArchivosAdjuntos_index)[col]);
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