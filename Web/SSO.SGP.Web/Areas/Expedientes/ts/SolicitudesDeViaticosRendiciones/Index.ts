/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module SolicitudesDeViaticosRendiciones.ts {
	
	export class Index implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public SolicitudesDeViaticosRendiciones:DataTables.DataTable;
		public SolicitudesDeViaticosRendiciones_id: number;
		public SolicitudesDeViaticosRendiciones_index: number;
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];


			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    SolicitudesDeViaticosRendiciones:{required:true, number:false, maxlength:0 },                },
                messages: {
 
                    SolicitudesDeViaticosRendiciones: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},                }
            });

        }

		public limpiar() {
		}

		public setSolicitudesDeViaticosRendiciones(dt: DataTables.DataTable):void {
            var self = this;
            this.SolicitudesDeViaticosRendiciones = dt;

            $("#dtSolicitudesDeViaticosRendiciones tbody").click(function (event) {
                $(self.SolicitudesDeViaticosRendiciones.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosRendiciones.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticosRendiciones_id = id;
                self.SolicitudesDeViaticosRendiciones_index = $(event.target).closest("tr").index();
            });			
        }
		
		public getData_SolicitudesDeViaticosRendiciones(col: number): any {
            return(this.SolicitudesDeViaticosRendiciones.fnGetData(this.SolicitudesDeViaticosRendiciones_index)[col]); 
        }

		public selectRow_SolicitudesDeViaticosRendiciones(event) {
            var self = this;
            $(self.SolicitudesDeViaticosRendiciones.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.SolicitudesDeViaticosRendiciones.fnGetData($(event).closest("tr").index())[0];
            self.SolicitudesDeViaticosRendiciones_id = id;
            self.SolicitudesDeViaticosRendiciones_index = $(event).closest("tr").index();
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