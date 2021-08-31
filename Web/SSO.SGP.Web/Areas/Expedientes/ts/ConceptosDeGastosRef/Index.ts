/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module ConceptosDeGastosRef.ts {
	
	export class Index implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public ConceptosDeGastosRef:DataTables.DataTable;
		public ConceptosDeGastosRef_id: number;
		public ConceptosDeGastosRef_index: number;
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];


			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    ConceptosDeGastosRef:{required:true, number:false, maxlength:0 },                },
                messages: {
 
                    ConceptosDeGastosRef: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},                }
            });

        }

		public limpiar() {
		}

		public setConceptosDeGastosRef(dt: DataTables.DataTable):void {
            var self = this;
            this.ConceptosDeGastosRef = dt;

            $("#dtConceptosDeGastosRef tbody").click(function (event) {
                $(self.ConceptosDeGastosRef.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.ConceptosDeGastosRef.fnGetData($(event.target).closest("tr").index())[0];
                self.ConceptosDeGastosRef_id = id;
                self.ConceptosDeGastosRef_index = $(event.target).closest("tr").index();
            });			
        }
		
		public getData_ConceptosDeGastosRef(col: number): any {
            return(this.ConceptosDeGastosRef.fnGetData(this.ConceptosDeGastosRef_index)[col]); 
        }

		public selectRow_ConceptosDeGastosRef(event) {
            var self = this;
            $(self.ConceptosDeGastosRef.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.ConceptosDeGastosRef.fnGetData($(event).closest("tr").index())[0];
            self.ConceptosDeGastosRef_id = id;
            self.ConceptosDeGastosRef_index = $(event).closest("tr").index();
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