
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module FeriasRef.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Descripcion:JQuery; 
		public FechaDesde:JQuery; 
		public FechaHasta:JQuery; 
		public Anio:JQuery; 
		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
					 
			this.Descripcion = $("#Descripcion"+hash); 
			this.FechaDesde = $("#FechaDesde"+hash); 
			this.FechaHasta = $("#FechaHasta"+hash); 
            this.Anio = $("#Anio" + hash); 

			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.Descripcion.focus();
		}
		
		public limpiar():void {			
			this.Descripcion.val("");
			this.FechaDesde.val("");
			this.FechaHasta.val("");
			this.Anio.val("");
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
