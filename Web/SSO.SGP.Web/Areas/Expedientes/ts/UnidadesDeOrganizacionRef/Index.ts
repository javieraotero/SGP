/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module UnidadesDeOrganizacionRef.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public index: number;
		
		 
		public UnidadesDeOrganizacionRef:DataTables.DataTable;
		public UnidadesDeOrganizacionRef_Id:number;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		
			//operaciones
			
		}
		
		public limpiar():void {
			
			this.UnidadesDeOrganizacionRef.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setUnidadesDeOrganizacionRef(dt: DataTables.DataTable):void {
            var that = this;
            this.UnidadesDeOrganizacionRef = dt;

            $("#dtUnidadesDeOrganizacionRef tbody").click(function (event) {
                $(that.UnidadesDeOrganizacionRef.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
         
                var id = that.UnidadesDeOrganizacionRef.fnGetData($(event.target).closest("tr").index())[0];
                that.UnidadesDeOrganizacionRef_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }
		
		public getData(col: number): any {
            return(this.UnidadesDeOrganizacionRef.fnGetData(this.index)[col]); 
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
