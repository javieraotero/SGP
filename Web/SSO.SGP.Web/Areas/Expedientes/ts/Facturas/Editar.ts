
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module Facturas.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public NumeroDeFactura:JQuery; 
		public IdentificacionDeFactura:JQuery; 
		public Tipo:JQuery; 
		public Expediente:JQuery; 
		public Proveedor:JQuery; 
		public txtProveedor:JQuery; 
		public Fecha:JQuery; 
		public Descripcion:JQuery; 
		public Importe:JQuery; 
		public Organismo:JQuery; 
		public Agente:JQuery; 
		public TextoAgente:JQuery; 
		public EsFactura:JQuery; 
		public EstaAsignada:JQuery; 
		public EstaPagada:JQuery; 
		public DeImpuestosMunicipales:JQuery; 
		public Comprobante2:JQuery; 
		public Comprobante3:JQuery; 
		public DeServicios:JQuery; 
		public FechaDesde:JQuery; 
		public FechaHasta:JQuery; 
		public Afectada:JQuery; 
		public Compromiso:JQuery; 
		public OrdenadoAPagar:JQuery; 
		public Grupo:JQuery; 
		public FechaAlta:JQuery; 
		public FechaModifica:JQuery; 
		public FechaElimina:JQuery; 
		public UsuarioAlta:JQuery; 
		public UsuarioModifica:JQuery; 
		public UsuarioElimina:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.NumeroDeFactura = $("#NumeroDeFactura"+hash); 
			this.IdentificacionDeFactura = $("#IdentificacionDeFactura"+hash); 
			this.Tipo = $("#Tipo"+hash); 
			this.Expediente = $("#Expediente"+hash); 
			this.Proveedor = $("#Proveedor"+hash); 
			this.txtProveedor = $("#txtProveedor"+hash); 
			this.Fecha = $("#Fecha"+hash); 
			this.Descripcion = $("#Descripcion"+hash); 
			this.Importe = $("#Importe"+hash); 
			this.Organismo = $("#Organismo"+hash); 
			this.Agente = $("#Agente"+hash); 
			this.TextoAgente = $("#TextoAgente"+hash); 
			this.EsFactura = $("#EsFactura"+hash); 
			this.EstaAsignada = $("#EstaAsignada"+hash); 
			this.EstaPagada = $("#EstaPagada"+hash); 
			this.DeImpuestosMunicipales = $("#DeImpuestosMunicipales"+hash); 
			this.Comprobante2 = $("#Comprobante2"+hash); 
			this.Comprobante3 = $("#Comprobante3"+hash); 
			this.DeServicios = $("#DeServicios"+hash); 
			this.FechaDesde = $("#FechaDesde"+hash); 
			this.FechaHasta = $("#FechaHasta"+hash); 
			this.Afectada = $("#Afectada"+hash); 
			this.Compromiso = $("#Compromiso"+hash); 
			this.OrdenadoAPagar = $("#OrdenadoAPagar"+hash); 
			this.Grupo = $("#Grupo"+hash); 
			this.FechaAlta = $("#FechaAlta"+hash); 
			this.FechaModifica = $("#FechaModifica"+hash); 
			this.FechaElimina = $("#FechaElimina"+hash); 
			this.UsuarioAlta = $("#UsuarioAlta"+hash); 
			this.UsuarioModifica = $("#UsuarioModifica"+hash); 
			this.UsuarioElimina = $("#UsuarioElimina"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.NumeroDeFactura.val("");
			this.IdentificacionDeFactura.val("");
			this.Tipo.val("");
			this.Expediente.val('').trigger("liszt:updated");
			this.Proveedor.val('').trigger("liszt:updated");
			this.txtProveedor.val("");
			this.Fecha.val("");
			this.Descripcion.val("");
			this.Importe.val("");
			this.Organismo.val('').trigger("liszt:updated");
			this.Agente.val("");
			this.TextoAgente.val("");
			this.EsFactura.removeAttr('checked');
			this.EstaAsignada.removeAttr('checked');
			this.EstaPagada.removeAttr('checked');
			this.DeImpuestosMunicipales.removeAttr('checked');
			this.Comprobante2.val("");
			this.Comprobante3.val("");
			this.DeServicios.removeAttr('checked');
			this.FechaDesde.val("");
			this.FechaHasta.val("");
			this.Afectada.removeAttr('checked');
			this.Compromiso.removeAttr('checked');
			this.OrdenadoAPagar.removeAttr('checked');
			this.Grupo.val("");
			this.FechaAlta.val("");
			this.FechaModifica.val("");
			this.FechaElimina.val("");
			this.UsuarioAlta.val("");
			this.UsuarioModifica.val("");
			this.UsuarioElimina.val("");
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
