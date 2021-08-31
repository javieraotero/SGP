
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
module Usuarios.ts {
	
	export class EditarRoles implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public modal: SyncroModal; 
		 
		public IdUsuario:JQuery; 
		public Roles:JQuery;
		public Cancelar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			this.modal = new SyncroModal($("#ModalEditarRolesUsuarios"+hash));
		 
			this.IdUsuario = $("#IdUsuario"+hash); 
			this.Roles = $("#Roles"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			
			//Establece el foco
			this.IdUsuario.focus();
		}
		
		public limpiar():void {
			
			this.IdUsuario.val("");
			this.Roles.removeAttr('checked');
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
