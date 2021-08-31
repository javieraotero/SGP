
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module ActuacionesADM.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Expediente:JQuery; 
		public Descripcion:JQuery; 
		public Fecha:JQuery; 
		public UsuarioAlta:JQuery; 
		public Observaciones:JQuery; 
		public FechaRecepcion:JQuery; 
		public UsuarioRecepcion:JQuery; 
		public OficinaOrigen:JQuery; 
		public SubAmbitoOrigen:JQuery; 
		public Anulado:JQuery; 
		public FechaAnulado:JQuery; 
		public UsuarioAnulacion:JQuery; 
		public MotivoAnulacion:JQuery; 
		public Texto:JQuery; 
		public FechaPublicacion:JQuery; 
		public UsuarioPublica:JQuery; 
		public FechaUltimaModificacion:JQuery; 
		public TipoActuacion:JQuery; 
		public ModeloAplicado:JQuery; 
		public Firmante1:JQuery; 
		public FechaFirmante1:JQuery; 
		public Firmante2:JQuery; 
		public FechaFirmante2:JQuery; 
		public Firmante3:JQuery; 
		public FechaFirmante3:JQuery; 
		public Firmante4:JQuery; 
		public FechaFirmante4:JQuery; 
		public Firmante5:JQuery; 
		public FechaFirmante5:JQuery; 
		public RequiereCargo:JQuery; 
		public SubAmbitoCargo:JQuery; 
		public FechaCargo:JQuery; 
		public UsuarioCargo:JQuery; 
		public Fojas:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Expediente = $("#Expediente"+hash); 
			this.Descripcion = $("#Descripcion"+hash); 
			this.Fecha = $("#Fecha"+hash); 
			this.UsuarioAlta = $("#UsuarioAlta"+hash); 
			this.Observaciones = $("#Observaciones"+hash); 
			this.FechaRecepcion = $("#FechaRecepcion"+hash); 
			this.UsuarioRecepcion = $("#UsuarioRecepcion"+hash); 
			this.OficinaOrigen = $("#OficinaOrigen"+hash); 
			this.SubAmbitoOrigen = $("#SubAmbitoOrigen"+hash); 
			this.Anulado = $("#Anulado"+hash); 
			this.FechaAnulado = $("#FechaAnulado"+hash); 
			this.UsuarioAnulacion = $("#UsuarioAnulacion"+hash); 
			this.MotivoAnulacion = $("#MotivoAnulacion"+hash); 
			this.Texto = $("#Texto"+hash); 
			this.FechaPublicacion = $("#FechaPublicacion"+hash); 
			this.UsuarioPublica = $("#UsuarioPublica"+hash); 
			this.FechaUltimaModificacion = $("#FechaUltimaModificacion"+hash); 
			this.TipoActuacion = $("#TipoActuacion"+hash); 
			this.ModeloAplicado = $("#ModeloAplicado"+hash); 
			this.Firmante1 = $("#Firmante1"+hash); 
			this.FechaFirmante1 = $("#FechaFirmante1"+hash); 
			this.Firmante2 = $("#Firmante2"+hash); 
			this.FechaFirmante2 = $("#FechaFirmante2"+hash); 
			this.Firmante3 = $("#Firmante3"+hash); 
			this.FechaFirmante3 = $("#FechaFirmante3"+hash); 
			this.Firmante4 = $("#Firmante4"+hash); 
			this.FechaFirmante4 = $("#FechaFirmante4"+hash); 
			this.Firmante5 = $("#Firmante5"+hash); 
			this.FechaFirmante5 = $("#FechaFirmante5"+hash); 
			this.RequiereCargo = $("#RequiereCargo"+hash); 
			this.SubAmbitoCargo = $("#SubAmbitoCargo"+hash); 
			this.FechaCargo = $("#FechaCargo"+hash); 
			this.UsuarioCargo = $("#UsuarioCargo"+hash); 
			this.Fojas = $("#Fojas"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Expediente.val('').trigger("liszt:updated");
			this.Descripcion.val("");
			this.Fecha.val("");
			this.UsuarioAlta.val("");
			this.Observaciones.val("");
			this.FechaRecepcion.val("");
			this.UsuarioRecepcion.val('').trigger("liszt:updated");
			this.OficinaOrigen.val('').trigger("liszt:updated");
			this.SubAmbitoOrigen.val('').trigger("liszt:updated");
			this.Anulado.removeAttr('checked');
			this.FechaAnulado.val("");
			this.UsuarioAnulacion.val('').trigger("liszt:updated");
			this.MotivoAnulacion.val("");
			this.Texto.val("");
			this.FechaPublicacion.val("");
			this.UsuarioPublica.val('').trigger("liszt:updated");
			this.FechaUltimaModificacion.val("");
			this.TipoActuacion.val('').trigger("liszt:updated");
			this.ModeloAplicado.val('').trigger("liszt:updated");
			this.Firmante1.val('').trigger("liszt:updated");
			this.FechaFirmante1.val("");
			this.Firmante2.val('').trigger("liszt:updated");
			this.FechaFirmante2.val("");
			this.Firmante3.val('').trigger("liszt:updated");
			this.FechaFirmante3.val("");
			this.Firmante4.val('').trigger("liszt:updated");
			this.FechaFirmante4.val("");
			this.Firmante5.val('').trigger("liszt:updated");
			this.FechaFirmante5.val("");
			this.RequiereCargo.removeAttr('checked');
			this.SubAmbitoCargo.val('').trigger("liszt:updated");
			this.FechaCargo.val("");
			this.UsuarioCargo.val('').trigger("liszt:updated");
			this.Fojas.val("");
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
