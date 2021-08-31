/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
module LicenciasAgente.ts {
	
	export class Consulta implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		 
		public Agente:SyncroAutocomplete; 
		public Licencias:SyncroTable;
        public FechaDesde: JQuery;
        public FechaHasta: JQuery;
        public Licencia: JQuery;
        public Modal: SyncroModal;
        public Buscar: JQuery;
        
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
		 
            this.Agente = new SyncroAutocomplete("Agente" + hash, "Agentes/GetJson"); 
			this.Licencias = new SyncroTable($("#Licencias"+hash));
            this.FechaDesde = $("#FechaDesde"+hash);
            this.FechaHasta = $("#FechaHasta"+hash);
            this.Licencia = $("#LicenciasRef" + hash);
            this.Modal = new SyncroModal($("#MainModal"));
            this.Buscar = $("#Buscar"+hash);
            //operaciones
			
			//Establece el foco
			this.Agente.txt.focus();
		}
		
		public limpiar():void {
			
			this.Agente.limpiar();
			this.Licencias.limpiar();
		}
		
		//--- Funciones para seteo de Datatables ---/
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
