
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module Proveedores.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Nombre:JQuery; 
		public NumeroAcreedor:JQuery; 
		public RazonSocial:JQuery; 
		public NombreFantasia:JQuery; 
		public DomicilioReal:JQuery; 
		public CodigoPostal:JQuery; 
		public CUIT:JQuery; 
		public IngresosBrutos:JQuery; 
		public ExentoGanancias:JQuery; 
		public ExentoIngresosBrutos:JQuery; 
		public InscriptoEnGanancias:JQuery; 
		public Estado:JQuery; 
		public FechaInscripcion:JQuery; 
		public FechaReInscripcion:JQuery; 
		public FechaFinExentoSellado:JQuery; 
		public FechaFinSuspension:JQuery; 
		public FechaFinExentoGanancias:JQuery; 
		public FechaFinExentoIngresosBrutos:JQuery; 
		public FechaBaja:JQuery; 
		public ExentoSellos:JQuery; 
		public AjustePorInflacion:JQuery; 
		public FormaDePago:JQuery; 
		public NumeroDeCuenta:JQuery; 
		public CBU:JQuery; 
		public TipoDeCuenta:JQuery; 
		public FechaAlta:JQuery; 
		public FechaModifica:JQuery; 
		public UsuarioAlta:JQuery; 
		public UsuarioBaja:JQuery; 
		public UsuarioModifica:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Nombre = $("#Nombre"+hash); 
			this.NumeroAcreedor = $("#NumeroAcreedor"+hash); 
			this.RazonSocial = $("#RazonSocial"+hash); 
			this.NombreFantasia = $("#NombreFantasia"+hash); 
			this.DomicilioReal = $("#DomicilioReal"+hash); 
			this.CodigoPostal = $("#CodigoPostal"+hash); 
			this.CUIT = $("#CUIT"+hash); 
			this.IngresosBrutos = $("#IngresosBrutos"+hash); 
			this.ExentoGanancias = $("#ExentoGanancias"+hash); 
			this.ExentoIngresosBrutos = $("#ExentoIngresosBrutos"+hash); 
			this.InscriptoEnGanancias = $("#InscriptoEnGanancias"+hash); 
			this.Estado = $("#Estado"+hash); 
			this.FechaInscripcion = $("#FechaInscripcion"+hash); 
			this.FechaReInscripcion = $("#FechaReInscripcion"+hash); 
			this.FechaFinExentoSellado = $("#FechaFinExentoSellado"+hash); 
			this.FechaFinSuspension = $("#FechaFinSuspension"+hash); 
			this.FechaFinExentoGanancias = $("#FechaFinExentoGanancias"+hash); 
			this.FechaFinExentoIngresosBrutos = $("#FechaFinExentoIngresosBrutos"+hash); 
			this.FechaBaja = $("#FechaBaja"+hash); 
			this.ExentoSellos = $("#ExentoSellos"+hash); 
			this.AjustePorInflacion = $("#AjustePorInflacion"+hash); 
			this.FormaDePago = $("#FormaDePago"+hash); 
			this.NumeroDeCuenta = $("#NumeroDeCuenta"+hash); 
			this.CBU = $("#CBU"+hash); 
			this.TipoDeCuenta = $("#TipoDeCuenta"+hash); 
			this.FechaAlta = $("#FechaAlta"+hash); 
			this.FechaModifica = $("#FechaModifica"+hash); 
			this.UsuarioAlta = $("#UsuarioAlta"+hash); 
			this.UsuarioBaja = $("#UsuarioBaja"+hash); 
			this.UsuarioModifica = $("#UsuarioModifica"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Nombre.val("");
			this.NumeroAcreedor.val("");
			this.RazonSocial.val("");
			this.NombreFantasia.val("");
			this.DomicilioReal.val("");
			this.CodigoPostal.val("");
			this.CUIT.val("");
			this.IngresosBrutos.val("");
			this.ExentoGanancias.removeAttr('checked');
			this.ExentoIngresosBrutos.removeAttr('checked');
			this.InscriptoEnGanancias.removeAttr('checked');
			this.Estado.val("");
			this.FechaInscripcion.val("");
			this.FechaReInscripcion.val("");
			this.FechaFinExentoSellado.val("");
			this.FechaFinSuspension.val("");
			this.FechaFinExentoGanancias.val("");
			this.FechaFinExentoIngresosBrutos.val("");
			this.FechaBaja.val("");
			this.ExentoSellos.removeAttr('checked');
			this.AjustePorInflacion.removeAttr('checked');
			this.FormaDePago.val('').trigger("liszt:updated");
			this.NumeroDeCuenta.val("");
			this.CBU.val("");
			this.TipoDeCuenta.val('').trigger("liszt:updated");
			this.FechaAlta.val("");
			this.FechaModifica.val("");
			this.UsuarioAlta.val("");
			this.UsuarioBaja.val("");
			this.UsuarioModifica.val("");
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
