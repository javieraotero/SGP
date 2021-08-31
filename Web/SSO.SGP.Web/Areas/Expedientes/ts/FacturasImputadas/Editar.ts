/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
module FacturasImputadas.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Factura:JQuery; 
		public Fecha:JQuery; 
		public AnioContable:JQuery; 
		public Usuario:JQuery; 
		public FechaElimina:JQuery; 
		public UsuarioElimina:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Factura = $("#Factura"+hash); 
			this.Fecha = $("#Fecha"+hash); 
			this.AnioContable = $("#AnioContable"+hash); 
			this.Usuario = $("#Usuario"+hash); 
			this.FechaElimina = $("#FechaElimina"+hash); 
			this.UsuarioElimina = $("#UsuarioElimina"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Factura.val('').trigger("liszt:updated");
			this.Fecha.val("");
			this.AnioContable.val("");
			this.Usuario.val("");
			this.FechaElimina.val("");
			this.UsuarioElimina.val("");
		}
		
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
