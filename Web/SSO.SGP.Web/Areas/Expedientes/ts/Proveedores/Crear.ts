
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module Proveedores.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public CUIT:JQuery; 
		public Nombre:JQuery; 
		public RazonSocial:JQuery; 
		public NumeroAcreedor:JQuery; 
		public NombreFantasia:JQuery; 
		public DomicilioReal:JQuery; 
		public CodigoPostal:JQuery; 
		public IngresosBrutos:JQuery; 
		public ExentoGanancias:JQuery; 
		public ExentoIngresosBrutos:JQuery; 
		public AjustePorInflacion:JQuery; 
		public ExentoSellos:JQuery; 
		public InscriptoEnGanancias:JQuery; 
		public FechaInscripcion:JQuery; 
		public FechaReInscripcion:JQuery; 
		public FechaFinExentoSellado:JQuery; 
		public FechaFinSuspension:JQuery; 
		public FechaFinExentoGanancias:JQuery; 
		public FechaFinExentoIngresosBrutos:JQuery; 
		public FormaDePago:JQuery; 
		public NumeroDeCuenta:JQuery; 
		public CBU:JQuery; 
		public TipoDeCuenta:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.CUIT = $("#CUIT"+hash); 
			this.Nombre = $("#Nombre"+hash); 
			this.RazonSocial = $("#RazonSocial"+hash); 
			this.NumeroAcreedor = $("#NumeroAcreedor"+hash); 
			this.NombreFantasia = $("#NombreFantasia"+hash); 
			this.DomicilioReal = $("#DomicilioReal"+hash); 
			this.CodigoPostal = $("#CodigoPostal"+hash); 
			this.IngresosBrutos = $("#IngresosBrutos"+hash); 
			this.ExentoGanancias = $("#ExentoGanancias"+hash); 
			this.ExentoIngresosBrutos = $("#ExentoIngresosBrutos"+hash); 
			this.AjustePorInflacion = $("#AjustePorInflacion"+hash); 
			this.ExentoSellos = $("#ExentoSellos"+hash); 
			this.InscriptoEnGanancias = $("#InscriptoEnGanancias"+hash); 
			this.FechaInscripcion = $("#FechaInscripcion"+hash); 
			this.FechaReInscripcion = $("#FechaReInscripcion"+hash); 
			this.FechaFinExentoSellado = $("#FechaFinExentoSellado"+hash); 
			this.FechaFinSuspension = $("#FechaFinSuspension"+hash); 
			this.FechaFinExentoGanancias = $("#FechaFinExentoGanancias"+hash); 
			this.FechaFinExentoIngresosBrutos = $("#FechaFinExentoIngresosBrutos"+hash); 
			this.FormaDePago = $("#FormaDePago"+hash); 
			this.NumeroDeCuenta = $("#NumeroDeCuenta"+hash); 
			this.CBU = $("#CBU"+hash); 
			this.TipoDeCuenta = $("#TipoDeCuenta"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.CUIT.focus();
		}
		
		public limpiar():void {
			
			this.CUIT.val("");
			this.Nombre.val("");
			this.RazonSocial.val("");
			this.NumeroAcreedor.val("");
			this.NombreFantasia.val("");
			this.DomicilioReal.val("");
			this.CodigoPostal.val("");
			this.IngresosBrutos.val("");
			this.ExentoGanancias.removeAttr('checked');
			this.ExentoIngresosBrutos.removeAttr('checked');
			this.AjustePorInflacion.removeAttr('checked');
			this.ExentoSellos.removeAttr('checked');
			this.InscriptoEnGanancias.removeAttr('checked');
			this.FechaInscripcion.val("");
			this.FechaReInscripcion.val("");
			this.FechaFinExentoSellado.val("");
			this.FechaFinSuspension.val("");
			this.FechaFinExentoGanancias.val("");
			this.FechaFinExentoIngresosBrutos.val("");
			this.FormaDePago.val('').trigger("liszt:updated");
			this.NumeroDeCuenta.val("");
			this.CBU.val("");
			this.TipoDeCuenta.val('').trigger("liszt:updated");
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
