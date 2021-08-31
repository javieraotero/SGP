
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module GrupoFamiliar.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Agente:JQuery; 
		public ApellidosYNombre:JQuery; 
		public FechaDeNacimiento:JQuery; 
		public Documento:JQuery; 
		public TipoMiembro:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Agente = $("#Agente"+hash); 
			this.ApellidosYNombre = $("#ApellidosYNombre"+hash); 
			this.FechaDeNacimiento = $("#FechaDeNacimiento"+hash); 
			this.Documento = $("#Documento"+hash); 
			this.TipoMiembro = $("#TipoMiembro"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.Agente.focus();
		}
		
		public limpiar():void {
			
			this.Agente.val("");
			this.ApellidosYNombre.val("");
			this.FechaDeNacimiento.val("");
			this.Documento.val("");
			this.TipoMiembro.val('').trigger("liszt:updated");
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
