/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module VehiculosOficialesRef.ts {
	
	export class Index implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public VehiculosOficialesRef:DataTables.DataTable;
		public VehiculosOficialesRef_id: number;
		public VehiculosOficialesRef_index: number;
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];


			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    VehiculosOficialesRef:{required:true, number:false, maxlength:0 },                },
                messages: {
 
                    VehiculosOficialesRef: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},                }
            });

        }

		public limpiar() {
		}

		public setVehiculosOficialesRef(dt: DataTables.DataTable):void {
            var self = this;
            this.VehiculosOficialesRef = dt;

            $("#dtVehiculosOficialesRef tbody").click(function (event) {
                $(self.VehiculosOficialesRef.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.VehiculosOficialesRef.fnGetData($(event.target).closest("tr").index())[0];
                self.VehiculosOficialesRef_id = id;
                self.VehiculosOficialesRef_index = $(event.target).closest("tr").index();
            });			
        }
		
		public getData_VehiculosOficialesRef(col: number): any {
            return(this.VehiculosOficialesRef.fnGetData(this.VehiculosOficialesRef_index)[col]); 
        }

		public selectRow_VehiculosOficialesRef(event) {
            var self = this;
            $(self.VehiculosOficialesRef.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.VehiculosOficialesRef.fnGetData($(event).closest("tr").index())[0];
            self.VehiculosOficialesRef_id = id;
            self.VehiculosOficialesRef_index = $(event).closest("tr").index();
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