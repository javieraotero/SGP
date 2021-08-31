/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
module PedidosDeSuministros.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Organismo:JQuery; 
		public FechaDePedido:JQuery; 
		public Entregado:JQuery; 
		public Articulo:SyncroAutocomplete; 
		public Pedido:JQuery; 
		public Agregar:JQuery; 
		public Detalle:SyncroTable;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        public CantidadEntregada: JQuery;
        public CantidadSolicitada: JQuery; 
        public spNumero: JQuery;
        public Imprimir: JQuery;

        public adetalle: DetalleDePedido[];

		//---  /Propiedades de Formulario --- //
		
        constructor(hash: string) {

			this.form = $("#" + hash);
			this.datatables = [];
					 
			this.Organismo = $("#Organismo"+hash); 
			this.FechaDePedido = $("#FechaDePedido"+hash); 
			this.Entregado = $("#Entregado"+hash); 
			this.Articulo = new SyncroAutocomplete("Articulo"+hash, "ArticulosDeSuministros/JsonAutocomplete"); 
			this.CantidadEntregada = $("#CantidadEntregada"+hash); 
            this.CantidadSolicitada = $("#CantidadSolicitada" + hash); 
            this.Pedido = $("#Pedido" + hash); 
			this.Guardar = $("#Guardar"+hash); 
			this.Detalle = new SyncroTable($("#Detalle"+hash));
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
            this.Agregar = $("#Agregar" + hash);
            this.spNumero = $("#Numero" + hash);
            this.Imprimir = $("#Imprimir" + hash);

            this.adetalle = [];
			
			//Establece el foco
			this.Organismo.focus();
		}
		
		public limpiar():void {
			
			this.Organismo.val('').trigger("liszt:updated");
			this.FechaDePedido.val("");
			this.Entregado.removeAttr('checked');
			this.Articulo.limpiar();
			this.Entregado.val("");
			this.Pedido.val("");
            this.spNumero.html("");
            this.Detalle.limpiar();
            this.adetalle = [];

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
