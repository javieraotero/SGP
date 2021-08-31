/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module Facturas.ts {
	
	export class SinOP implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public index: number;
		
		 
		public dtSinOP:DataTables.DataTable;
		public Facturas_Id:number;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		
			//operaciones
			
		}
		
		public limpiar():void {
			
			this.dtSinOP.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setdtSinAsignacion(dt: DataTables.DataTable):void {
            var that = this;
            this.dtSinOP = dt;

            $("#dtSinOP tbody").click(function (event) {
                $(that.dtSinOP.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
         
                var id = that.dtSinOP.fnGetData($(event.target).closest("tr").index())[0];
                that.Facturas_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }
		
		public getData(col: number): any {
            return(this.dtSinOP.fnGetData(this.index)[col]); 
        }
		//--- /Funciones para seteo de Datatables ---/
		
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
