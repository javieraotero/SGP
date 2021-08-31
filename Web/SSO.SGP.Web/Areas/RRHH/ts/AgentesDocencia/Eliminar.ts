
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module AgentesDocencia.ts {
	
	export class Eliminar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Agente:JQuery; 
		public Fecha:JQuery; 
		public Institucion:JQuery; 
		public CargaHoraria:JQuery; 
		public HorasCatedra:JQuery; 
		public HorasSemanales:JQuery; 
		public Observaciones:JQuery; 
		public Detalle:JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Agente = $("#Agente"+hash); 
			this.Fecha = $("#Fecha"+hash); 
			this.Institucion = $("#Institucion"+hash); 
			this.CargaHoraria = $("#CargaHoraria"+hash); 
			this.HorasCatedra = $("#HorasCatedra"+hash); 
			this.HorasSemanales = $("#HorasSemanales"+hash); 
			this.Observaciones = $("#Observaciones"+hash); 
			this.Detalle = $("#Detalle"+hash);
			//operaciones
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Agente.val("");
			this.Fecha.val("");
			this.Institucion.val("");
			this.CargaHoraria.val("");
			this.HorasCatedra.val("");
			this.HorasSemanales.val("");
			this.Observaciones.val("");
			this.Detalle.val("");
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
