/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module SolicitudesDeViaticosAgentes.ts {
	
	export class Index implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public SolicitudesDeViaticosAgentes:DataTables.DataTable;
		public SolicitudesDeViaticosAgentes_id: number;
		public SolicitudesDeViaticosAgentes_index: number;
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];


			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    SolicitudesDeViaticosAgentes:{required:true, number:false, maxlength:0 },                },
                messages: {
 
                    SolicitudesDeViaticosAgentes: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},                }
            });

        }

		public limpiar() {
		}

		public setSolicitudesDeViaticosAgentes(dt: DataTables.DataTable):void {
            var self = this;
            this.SolicitudesDeViaticosAgentes = dt;

            $("#dtSolicitudesDeViaticosAgentes tbody").click(function (event) {
                $(self.SolicitudesDeViaticosAgentes.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosAgentes.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticosAgentes_id = id;
                self.SolicitudesDeViaticosAgentes_index = $(event.target).closest("tr").index();
            });			
        }
		
		public getData_SolicitudesDeViaticosAgentes(col: number): any {
            return(this.SolicitudesDeViaticosAgentes.fnGetData(this.SolicitudesDeViaticosAgentes_index)[col]); 
        }

		public selectRow_SolicitudesDeViaticosAgentes(event) {
            var self = this;
            $(self.SolicitudesDeViaticosAgentes.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.SolicitudesDeViaticosAgentes.fnGetData($(event).closest("tr").index())[0];
            self.SolicitudesDeViaticosAgentes_id = id;
            self.SolicitudesDeViaticosAgentes_index = $(event).closest("tr").index();
        }
		
		public fnRegistrarDataTable(d: DataTables.DataTable): void {
			this.datatables.push(d);
		}

		public fnRefrescarDataTables():void {
			var that = this;
			this.datatables.forEach(function (d) {
				d.fnDraw();
			});    
		}
	} //JS
} // module