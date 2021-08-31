/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
module Facturas.ts {
	
	export class ArmarExpediente implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		public body_facturas:JQuery;
		public body_partidas:JQuery;

		public Guardar: JQuery;

		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
						
			this.body_facturas = $("#body_facturas");
			this.body_partidas = $("#body_partidas");

			this.Guardar = $("#Guardar");
			//operaciones		
		}

		public refrescarFacturas() {
									
		}
		
		public limpiar():void {
			

		}
		
		//--- Funciones para seteo de Datatables ---/
		
		//public getData(col: number): any {
  //          return(this.Agentes.fnGetData(this.index)[col]); 
  //      }
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
