/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
module FacturasImputadas.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Factura:SyncroAutocomplete; 
		public Fecha:JQuery; 
		public AnioContable:JQuery; 
		public Partida:SyncroAutocomplete; 
		public Division:JQuery; 
		public Importe:JQuery; 
		public Agregar:JQuery; 
		public Detalle:SyncroTable;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Factura = new SyncroAutocomplete("#Factura"+hash, "url"); 
			this.Fecha = $("#Fecha"+hash); 
			this.AnioContable = $("#AnioContable"+hash); 
			this.Partida = new SyncroAutocomplete("#Partida"+hash, "url"); 
			this.Division = $("#Division"+hash); 
			this.Importe = $("#Importe"+hash); 
			this.Agregar = $("#Agregar"+hash); 
			this.Detalle = new SyncroTable($("#Detalle"+hash));
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.Factura.txt.focus();
		}
		
		public limpiar():void {
			
			this.Factura.limpiar();
			this.Fecha.val("");
			this.AnioContable.val("");
			this.Partida.limpiar();
			this.Division.val('').trigger("liszt:updated");
			this.Importe.val("");
			this.Agregar.val("");
			this.Detalle.limpiar();
		}
		
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
