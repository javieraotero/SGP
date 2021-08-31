/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module SolicitudesDeViaticosRendicionesAgentes.ts {
	
	export class Index implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public SolicitudesDeViaticosRendicionesAgentes:DataTables.DataTable;
		public SolicitudesDeViaticosRendicionesAgentes_id: number;
		public SolicitudesDeViaticosRendicionesAgentes_index: number;
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];


			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    SolicitudesDeViaticosRendicionesAgentes:{required:true, number:false, maxlength:0 },                },
                messages: {
 
                    SolicitudesDeViaticosRendicionesAgentes: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},                }
            });

        }

		public limpiar() {
		}

		public setSolicitudesDeViaticosRendicionesAgentes(dt: DataTables.DataTable):void {
            var self = this;
            this.SolicitudesDeViaticosRendicionesAgentes = dt;

            $("#dtSolicitudesDeViaticosRendicionesAgentes tbody").click(function (event) {
                $(self.SolicitudesDeViaticosRendicionesAgentes.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosRendicionesAgentes.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticosRendicionesAgentes_id = id;
                self.SolicitudesDeViaticosRendicionesAgentes_index = $(event.target).closest("tr").index();
            });			
        }
		
		public getData_SolicitudesDeViaticosRendicionesAgentes(col: number): any {
            return(this.SolicitudesDeViaticosRendicionesAgentes.fnGetData(this.SolicitudesDeViaticosRendicionesAgentes_index)[col]); 
        }

		public selectRow_SolicitudesDeViaticosRendicionesAgentes(event) {
            var self = this;
            $(self.SolicitudesDeViaticosRendicionesAgentes.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.SolicitudesDeViaticosRendicionesAgentes.fnGetData($(event).closest("tr").index())[0];
            self.SolicitudesDeViaticosRendicionesAgentes_id = id;
            self.SolicitudesDeViaticosRendicionesAgentes_index = $(event).closest("tr").index();
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