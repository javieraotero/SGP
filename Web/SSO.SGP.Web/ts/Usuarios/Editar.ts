
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
module Usuarios.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public NombreUsuario:JQuery; 
		public NombrePersona:JQuery; 
		public Documento:JQuery; 
		public Domicilio:JQuery; 
		public Telefono:JQuery; 
		public Celular:JQuery; 
		public Email:JQuery; 
		public Activo:JQuery; 
		public UsuarioAlta:JQuery; 
		public FechaAlta:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public Resetear: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.NombreUsuario = $("#NombreUsuario"+hash); 
			this.NombrePersona = $("#NombrePersona"+hash); 
			this.Documento = $("#Documento"+hash); 
			this.Domicilio = $("#Domicilio"+hash); 
			this.Telefono = $("#Telefono"+hash); 
			this.Celular = $("#Celular"+hash); 
			this.Email = $("#Email"+hash); 
			this.Activo = $("#Activo"+hash); 
			this.UsuarioAlta = $("#UsuarioAlta"+hash); 
			this.FechaAlta = $("#FechaAlta"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.Resetear = $("#Resetear" + hash);

			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.NombreUsuario.val("");
			this.NombrePersona.val("");
			this.Documento.val("");
			this.Domicilio.val("");
			this.Telefono.val("");
			this.Celular.val("");
			this.Email.val("");
			this.Activo.val("");
			this.UsuarioAlta.val("");
			this.FechaAlta.val("");
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
