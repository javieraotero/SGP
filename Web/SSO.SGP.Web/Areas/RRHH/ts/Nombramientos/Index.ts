/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module Nombramientos.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public Agente: JQuery;
        public Nuevo: JQuery;
        public Cancelar: JQuery;
        public Modal: SyncroModal;
		public Movimiento: JQuery;
		 
        public Nombramientos: SyncroTable;
        public Movimientos: SyncroTable;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
            this.datatables = [];
            this.Agente = $("#Agente" + hash);					 
            this.Nombramientos = new SyncroTable($("#Nombramientos" + hash));
            this.Movimientos = new SyncroTable($("#Movimientos" + hash));
            this.Modal = new SyncroModal($("#ModalNombramiento" + hash));
            //operaciones
            this.Nuevo = $("#Nuevo" + hash);
            this.Movimiento = $("#Movimiento" + hash);
            this.Cancelar = $("#Cancelar" + hash);
			
			//Establece el foco
			//this.Nombramientos.focus();
		}
		
		public limpiar():void {
			
			this.Nombramientos.limpiar();
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
