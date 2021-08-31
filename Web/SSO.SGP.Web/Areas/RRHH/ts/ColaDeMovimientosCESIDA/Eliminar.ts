
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module ColaDeMovimientosCESIDA.ts {
	
	export class Eliminar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Nombramiento:JQuery; 
		public Agente:JQuery; 
		public Movimiento:JQuery; 
		public Fecha:JQuery; 
		public FechaEnvio:JQuery; 
		public IdRespuesta:JQuery; 
		public MensajeRespuesta:JQuery; 
		public Intentos:JQuery; 
		public Licencia:JQuery; 
		public IdRegistro:JQuery; 
		public FechaDesde:JQuery; 
		public FechaHasta:JQuery; 
		public Cargo:JQuery; 
		public Organismo:JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Nombramiento = $("#Nombramiento"+hash); 
			this.Agente = $("#Agente"+hash); 
			this.Movimiento = $("#Movimiento"+hash); 
			this.Fecha = $("#Fecha"+hash); 
			this.FechaEnvio = $("#FechaEnvio"+hash); 
			this.IdRespuesta = $("#IdRespuesta"+hash); 
			this.MensajeRespuesta = $("#MensajeRespuesta"+hash); 
			this.Intentos = $("#Intentos"+hash); 
			this.Licencia = $("#Licencia"+hash); 
			this.IdRegistro = $("#IdRegistro"+hash); 
			this.FechaDesde = $("#FechaDesde"+hash); 
			this.FechaHasta = $("#FechaHasta"+hash); 
			this.Cargo = $("#Cargo"+hash); 
			this.Organismo = $("#Organismo"+hash);
			//operaciones
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Nombramiento.val("");
			this.Agente.val("");
			this.Movimiento.val("");
			this.Fecha.val("");
			this.FechaEnvio.val("");
			this.IdRespuesta.val("");
			this.MensajeRespuesta.val("");
			this.Intentos.val("");
			this.Licencia.val("");
			this.IdRegistro.val("");
			this.FechaDesde.val("");
			this.FechaHasta.val("");
			this.Cargo.val("");
			this.Organismo.val("");
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
