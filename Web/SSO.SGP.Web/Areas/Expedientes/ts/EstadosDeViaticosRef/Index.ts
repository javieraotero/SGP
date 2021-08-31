/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module EstadosDeViaticosRef.ts {
	
	export class Index implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public EstadosDeViaticosRef:DataTables.DataTable;
		public EstadosDeViaticosRef_id: number;
		public EstadosDeViaticosRef_index: number;
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];


			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    EstadosDeViaticosRef:{required:true, number:false, maxlength:0 },                },
                messages: {
 
                    EstadosDeViaticosRef: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},                }
            });

        }

		public limpiar() {
		}

		public setEstadosDeViaticosRef(dt: DataTables.DataTable):void {
            var self = this;
            this.EstadosDeViaticosRef = dt;

            $("#dtEstadosDeViaticosRef tbody").click(function (event) {
                $(self.EstadosDeViaticosRef.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.EstadosDeViaticosRef.fnGetData($(event.target).closest("tr").index())[0];
                self.EstadosDeViaticosRef_id = id;
                self.EstadosDeViaticosRef_index = $(event.target).closest("tr").index();
            });			
        }
		
		public getData_EstadosDeViaticosRef(col: number): any {
            return(this.EstadosDeViaticosRef.fnGetData(this.EstadosDeViaticosRef_index)[col]); 
        }

		public selectRow_EstadosDeViaticosRef(event) {
            var self = this;
            $(self.EstadosDeViaticosRef.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.EstadosDeViaticosRef.fnGetData($(event).closest("tr").index())[0];
            self.EstadosDeViaticosRef_id = id;
            self.EstadosDeViaticosRef_index = $(event).closest("tr").index();
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