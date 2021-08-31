
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module CargosRef.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Descripcion:JQuery; 
		public Grupo:JQuery; 
		public Orden:JQuery; 
		public CodigoRRHH:JQuery; 
		public Presupuesto:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Descripcion = $("#Descripcion"+hash); 
			this.Grupo = $("#Grupo"+hash); 
			this.Orden = $("#Orden"+hash); 
			this.CodigoRRHH = $("#CodigoRRHH"+hash); 
			this.Presupuesto = $("#Presupuesto"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.Descripcion.focus();
		}
		
		public limpiar():void {
			
			this.Descripcion.val("");
			this.Grupo.val('').trigger("liszt:updated");
			this.Orden.val("");
			this.CodigoRRHH.val("");
			this.Presupuesto.val("");
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
