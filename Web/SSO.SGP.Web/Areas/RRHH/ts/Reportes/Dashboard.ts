/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module Reportes.ts {
	
	export class Dashborad implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public TotalNombramientos:JQuery; 
		public TotalLicencias:JQuery; 
		public TotalPlanta:JQuery; 
		public TotalContratado:JQuery; 
		public TotalBaja:JQuery; 
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];			

            this.TotalNombramientos = $("#TotalNombramientos");
            this.TotalLicencias = $("#TotalLicencias");
            this.TotalPlanta = $("#TotalPlanta");
            this.TotalContratado = $("#TotalContratado");
            this.TotalBaja = $("#TotalBaja");		 

		}
		
		public limpiar():void {
			
		}
		
		//--- Funciones para seteo de Datatables ---/
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
