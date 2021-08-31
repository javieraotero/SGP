/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
module CompraDeSuministros.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Fecha:JQuery;  
		public Articulo:SyncroAutocomplete; 
		public Agregar:JQuery; 
		public Detalle:SyncroTable;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        public Cantidad: JQuery;
        public Precio: JQuery;
        public Comprobante: JQuery;

        public adetalle: DetalleDeCompra[];

		//---  /Propiedades de Formulario --- //
		
        constructor(hash: string) {

			this.form = $("#" + hash);
			this.datatables = [];
					 
			this.Articulo = new SyncroAutocomplete("Articulo"+hash, "ArticulosDeSuministros/JsonAutocomplete"); 
			this.Cantidad = $("#Cantidad"+hash); 
            this.Precio = $("#Precio" + hash); 
			this.Guardar = $("#Guardar"+hash); 
            this.Detalle = new SyncroTable($("#Detalle" + hash));
            this.Fecha = $("#Fecha" + hash);
            this.Comprobante = $("#Comprobante" + hash);

			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
            this.Agregar = $("#Agregar" + hash);

            this.adetalle = [];
			
			//Establece el foco
			this.Fecha.focus();
		}
		
		public limpiar():void {

            this.Fecha.val("");
			this.Comprobante.val("");
            this.Precio.val("");
			this.Articulo.limpiar();
			this.Cantidad.val("");
            this.Detalle.limpiar();
            this.adetalle = [];

            this.Fecha.focus();
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
