
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module ArticulosDeSuministros.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Nombre:JQuery; 
		public Codigo:JQuery; 
		public StockMinimo:JQuery; 
		public Stock:JQuery; 
		public UltimoCosto:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Nombre = $("#Nombre"+hash); 
			this.Codigo = $("#Codigo"+hash); 
			this.StockMinimo = $("#StockMinimo"+hash); 
			this.Stock = $("#Stock"+hash); 
			this.UltimoCosto = $("#UltimoCosto"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.Nombre.focus();
		}
		
		public limpiar():void {
			
			this.Nombre.val("");
			this.Codigo.val("");
			this.StockMinimo.val("");
			this.Stock.val("");
			this.UltimoCosto.val("");
		}
		
		//--- Funciones para seteo de Datatables ---/
		
		public getData(col: number): any {
            return(this.Agentes.fnGetData(this.index)[col]); 
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
