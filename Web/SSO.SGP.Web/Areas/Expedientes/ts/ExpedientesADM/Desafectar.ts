/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
module ExpedientesADM.ts {
	
	export class Desafectar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public UnidadOrganizacion:JQuery; 
        public Partidas: JQuery;
        public spFactura: JQuery;
        public spImporte: JQuery;
		public Id: JQuery;
        public Guardar: JQuery;
        public ModificarCompromiso: JQuery;

		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
						
			this.UnidadOrganizacion = $("#UnidadDeOrganizacionRef"+hash); 
            this.Partidas = $("#body_partidas" + hash);
            this.spFactura = $("#spFactura" + hash);
            this.spImporte = $("#spImporte" + hash);
			this.Id = $("#Id"+hash);

            this.Guardar = $("#Guardar" + hash);
            this.ModificarCompromiso = $("#modificarcompromiso" + hash);
			//operaciones
			
			//Establece el foco
			this.UnidadOrganizacion.focus();
		}
		
		public limpiar():void {
			
			this.UnidadOrganizacion.val('').trigger("liszt:updated");
			//this.Partidas.limpiar();
		}
		
		//--- Funciones para seteo de Datatables ---/
		
		//public getData(col: number): any {
  //          return(this.Agentes.fnGetData(this.index)[col]); 
  //      }
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
