
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module Sustituciones.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Agente:JQuery; 
		public Acuerdo:JQuery; 
		public Desde:JQuery; 
		public Hasta:JQuery; 
		public Motivo:JQuery; 
		public Cargo:JQuery; 
		public Organismo:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Agente = $("#Agente"+hash); 
			this.Acuerdo = $("#Acuerdo"+hash); 
			this.Desde = $("#Desde"+hash); 
			this.Hasta = $("#Hasta"+hash); 
			this.Motivo = $("#Motivo"+hash); 
			this.Cargo = $("#Cargo"+hash); 
            this.Organismo = $("#Organismo" + hash);
			//operaciones
			this.Cancelar = $("#CancelarSustituciones"+hash);
			this.Guardar = $("#GuardarSustituciones"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevoSustituciones"+hash);
			
			//Establece el foco
			this.Acuerdo.focus();
		}
		
		public limpiar():void {
			
			this.Agente.val("");
			this.Acuerdo.val("");
			this.Desde.val("");
			this.Hasta.val("");
			this.Motivo.val("");
			this.Cargo.val('').trigger("liszt:updated");
			//this.Organismo.limpiar();

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
