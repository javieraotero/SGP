/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
module ExpedientesADM.ts {
	
	export class Detalle implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
				 
		public Tipo:JQuery; 
		public Categoria:JQuery; 
		public Numero:JQuery; 
		public NumeroDeCorresponde:JQuery; 
		public Fecha:JQuery; 
		public OrganismoIniciador:JQuery; 
		public TextoIniciador:JQuery; 
		public Caratula:JQuery; 
		public Destino:JQuery;
		public Cancelar: JQuery;
        public NuevaFactura: JQuery;
        public NuevaActuacion: JQuery;
        public NuevoAdjunto: JQuery;
        public divDetalle: JQuery;
		public Id: JQuery;
        public Afectar: JQuery;
        public body_facturas: JQuery;
        public table_pendiente_op: JQuery;
        public body_pendiente_op: JQuery;
        public table_facturas_pendientes: JQuery;
        public body_facturas_pendientes: JQuery;
        public modalFacturas: SyncroModal;
        public Seleccionar_Todas: JQuery;
        public ConfirmarAfectacion: JQuery;
        public Ordenado: JQuery;
        public operacion: string;
        public body_contabilidad: JQuery;
        public SobreAfectar: JQuery;
        public Asignar: JQuery;
        public Desafectar: JQuery;
        public AfectacionCompromisoOrdenado: JQuery;

        //public afacturas: Facturas[];
        //public aactuaciones: Actuaciones[];
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Tipo = $("#Tipo"+hash); 
			this.Categoria = $("#Categoria"+hash); 
			this.Numero = $("#Numero"+hash); 
			this.NumeroDeCorresponde = $("#NumeroDeCorresponde"+hash); 
			this.Fecha = $("#Fecha"+hash); 
			this.OrganismoIniciador = $("#OrganismoIniciador"+hash); 
			this.TextoIniciador = $("#TextoIniciador"+hash); 
			this.Caratula = $("#Caratula"+hash); 
            this.Destino = $("#Destino" + hash);
            this.divDetalle = $("#divDetalle" + hash);
			this.Afectar = $("#Afectar" + hash);
            this.Id = $("#Id" + hash);
            this.body_facturas = $("#body_facturas" + hash);
            this.NuevoAdjunto = $("#NuevoAdjunto" + hash);
            this.table_pendiente_op = $("#table_pendiente_op" + hash);
            this.body_pendiente_op = $("#body_pendiente_op" + hash);
            this.table_facturas_pendientes = $("#table_facturas_pendientes" + hash);
            this.body_facturas_pendientes = $("#body_facturas_pendientes" + hash);
            this.modalFacturas = new SyncroModal($("#ModalFacturas"));
            this.ConfirmarAfectacion = $("#ConfirmarAfectacion" + hash);
            this.Seleccionar_Todas = $("#todas" + hash);
            this.Ordenado = $("#Ordenado" + hash);
            this.body_contabilidad = $("#body_contabilidad" + hash);
            this.SobreAfectar = $("#Sobreafectar" + hash);
            this.Asignar = $("#NuevoMovimiento" + hash);
            this.Desafectar = $("#Desafectar" + hash);
            this.AfectacionCompromisoOrdenado = $("#AfectacionCompromisoOrdenado" + hash);

            //this.divDetalle.hide();
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
            this.NuevaActuacion = $("#Pase" + hash);
            this.NuevaFactura = $("#NuevaFactura" + hash);

            //this.afacturas = [];
            //this.aactuaciones = [];
			
			//Establece el foco
			this.Tipo.focus();
		}
		
		public limpiar():void {
			
			this.Tipo.val('').trigger("liszt:updated");
			this.Categoria.val('').trigger("liszt:updated");
			this.Numero.val("");
			this.NumeroDeCorresponde.val("");
			this.Fecha.val("");
			this.OrganismoIniciador.val('').trigger("liszt:updated");
			this.TextoIniciador.val("");
			this.Caratula.val("");
			this.Destino.val('').trigger("liszt:updated");
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
