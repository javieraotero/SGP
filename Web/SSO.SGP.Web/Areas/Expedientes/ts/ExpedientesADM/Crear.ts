/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
module ExpedientesADM.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
				 
		public Tipo:JQuery; 
		public Categoria:SyncroSelect; 
		public Numero:JQuery; 
		public NumeroDeCorresponde:JQuery; 
		public Fecha:JQuery; 
		public OrganismoIniciador:JQuery; 
		public TextoIniciador:JQuery; 
		public Caratula:JQuery; 
		public Destino:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        public Imprimir: JQuery;
        public NuevaFactura: JQuery;
        public NuevaActuacion: JQuery;
		public EsCorreponde: JQuery;
		public spNumeroExpediente: JQuery;
		public hidNumero:JQuery;
		public hidCorresponde:JQuery;
        public Modal: SyncroModal;
        public divDetalle: JQuery;
        public Id: JQuery;

        //public afacturas: Facturas[];
        //public aactuaciones: Actuaciones[];
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Tipo = $("#TiposExpedienteADMRef"+hash); 
			//this.Categoria = $("#CategoriasExpedienteADMRef"+hash);
            this.Categoria = new SyncroSelect("CategoriasExpedienteADMRef" + hash, true);
			this.Numero = $("#Numero"+hash); 
			this.NumeroDeCorresponde = $("#NumeroDeCorresponde"+hash); 
			this.Fecha = $("#Fecha"+hash); 
			this.OrganismoIniciador = $("#OrganismoIniciador"+hash); 
			this.TextoIniciador = $("#TextoIniciador"+hash); 
			this.Caratula = $("#Caratula"+hash); 
            this.Destino = $("#Destino" + hash);
            this.divDetalle = $("#divDetalle" + hash);
			this.EsCorreponde = $("#chkCorresponde" + hash);
			this.hidCorresponde = $("#hidCorresponde");
			this.hidNumero = $("#hidNumero");
			this.spNumeroExpediente = $("#spNumeroExpediente");

            this.divDetalle.hide();

            this.Modal = new SyncroModal($("#MainModal"));

			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
            this.Imprimir = $("#Imprmir" + hash);
            this.NuevaActuacion = $("#NuevaActuacion" + hash);
            this.NuevaFactura = $("#NuevaFactura" + hash);
            this.Id = $("#Id" + hash);

            this.Imprimir.hide();

            //this.afacturas = [];
            //this.aactuaciones = [];
			
			//Establece el foco
			this.Tipo.focus();
		}
		
		public limpiar():void {
			
			this.Tipo.val('').trigger("liszt:updated");
			//this.Categoria.val('').trigger("liszt:updated");
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
