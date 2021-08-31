
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module FeriasAgentes.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Agente:JQuery; 
		public Feria:JQuery; 
		public Dias:JQuery; 
		public Desde1:JQuery; 
		public Desde2:JQuery; 
		public Desde3:JQuery; 
		public Hasta1:JQuery; 
		public Hasta2:JQuery; 
		public Hasta3:JQuery; 
		public Instancia:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Agente = $("#Agente"+hash); 
			this.Feria = $("#Feria"+hash); 
			this.Dias = $("#Dias"+hash); 
			this.Desde1 = $("#Desde1"+hash); 
			this.Desde2 = $("#Desde2"+hash); 
			this.Desde3 = $("#Desde3"+hash); 
			this.Hasta1 = $("#Hasta1"+hash); 
			this.Hasta2 = $("#Hasta2"+hash); 
			this.Hasta3 = $("#Hasta3"+hash); 
			this.Instancia = $("#Instancia"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Agente.val('').trigger("liszt:updated");
			this.Feria.val('').trigger("liszt:updated");
			this.Dias.val("");
			this.Desde1.val("");
			this.Desde2.val("");
			this.Desde3.val("");
			this.Hasta1.val("");
			this.Hasta2.val("");
			this.Hasta3.val("");
			this.Instancia.val("");
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
