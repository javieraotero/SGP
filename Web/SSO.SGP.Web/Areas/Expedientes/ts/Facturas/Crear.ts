/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
module Facturas.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Proveedor:SyncroAutocomplete; 
		public Tipo:JQuery; 
		public NumeroDeFactura:JQuery; 
		public IdentificacionDeFactura:JQuery; 
		public Expediente:SyncroAutocomplete; 
		public Fecha:JQuery; 
		public Importe:JQuery; 
		public Descripcion:JQuery; 
		public Organismo:JQuery; 
		public DeImpuestosMunicipales:JQuery; 
		public Comprobante2:JQuery; 
		public Comprobante3:JQuery; 
		public DeServicios:JQuery; 
		public FechaDesde:JQuery; 
		public FechaHasta:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
					 
            this.Proveedor = new SyncroAutocomplete("Proveedor" + hash, "Expedientes/Proveedores/Autocomplete"); 
            this.Proveedor.setAppendTo("#Proveedor");
			this.Tipo = $("#Tipo"+hash); 
			this.NumeroDeFactura = $("#NumeroDeFactura"+hash); 
			this.IdentificacionDeFactura = $("#IdentificacionDeFactura"+hash); 
			this.Expediente = new SyncroAutocomplete("Expediente"+hash, "Expedientes/ExpedientesADM/Autocomplete"); 
			this.Fecha = $("#Fecha"+hash); 
			this.Importe = $("#Importe"+hash); 
			this.Descripcion = $("#Descripcion"+hash); 
			this.Organismo = $("#Organismo"+hash); 
			this.DeImpuestosMunicipales = $("#DeImpuestosMunicipales"+hash); 
			this.Comprobante2 = $("#Comprobante2"+hash); 
			this.Comprobante3 = $("#Comprobante3"+hash); 
			this.DeServicios = $("#DeServicios"+hash); 
			this.FechaDesde = $("#FechaDesde"+hash); 
			this.FechaHasta = $("#FechaHasta"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
			
			//Establece el foco
			this.Proveedor.txt.focus();
		}
		
		public limpiar():void {
			
			this.Proveedor.limpiar();
			this.Tipo.val("");
			this.NumeroDeFactura.val("");
			this.IdentificacionDeFactura.val("");
			this.Expediente.limpiar();
			this.Fecha.val("");
			this.Importe.val("");
			this.Descripcion.val("");
			this.Organismo.val('').trigger("liszt:updated");
			this.DeImpuestosMunicipales.removeAttr('checked');
			this.Comprobante2.val("");
			this.Comprobante3.val("");
			this.DeServicios.removeAttr('checked');
			this.FechaDesde.val("");
			this.FechaHasta.val("");
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
