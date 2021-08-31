
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
module Usuarios.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
        public ApellidoYNombre:JQuery; 
		public Usuario:JQuery; 
		public Correo:JQuery; 
		public Cargo:JQuery; 
		public Estado:JQuery; 
        public Organismo: JQuery;
        public Circunscripcion: JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        public BuscarPersona: JQuery;
        public Detalle: JQuery;
        public IdPersona: JQuery;
        public spDetalle: JQuery;
        public Persona: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.ApellidoYNombre = $("#ApellidoYNombre"+hash); 
			this.Usuario = $("#Usuario"+hash); 
			this.Correo = $("#Correo"+hash); 
			this.Estado = $("#Estado"+hash); 
            this.Organismo = $("#OrganismoUltimoIngreso"+hash); 
            this.Cargo = $("#Cargo" + hash);
            this.Circunscripcion = $("#Circunscripcion" + hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
            this.BuscarPersona = $("#BuscarPersona" + hash);
            this.Detalle = $("#DetalleAgente");
            this.IdPersona = $("#Persona" + hash);
            this.spDetalle = $("#detalle");
            this.Persona = $("#Persona" + hash);

			
			//Establece el foco
			this.ApellidoYNombre.focus();
		}
		
		public limpiar():void {
			
            this.ApellidoYNombre.val("");
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
