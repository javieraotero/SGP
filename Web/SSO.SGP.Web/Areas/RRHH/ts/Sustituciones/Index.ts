
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module Sustituciones.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public Modal: SyncroModal;
        public Nuevo: JQuery;
        public Cancelar: JQuery;
        public Agente: JQuery;
		
		 
		public Sustituciones:SyncroTable;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
					 
            this.Modal = new SyncroModal($("#ModalSustituciones" + hash));
            this.Agente = $("#Agente" + hash);
            //operaciones
            this.Nuevo = $("#Nuevo" + hash);
            this.Cancelar = $("#Cancelar" + hash);
            this.Sustituciones = new SyncroTable($("#Sustituciones" + hash));

			//Establece el foco
			//this.Sustituciones.focus();
		}
		
		public limpiar():void {
			
			this.Sustituciones.limpiar();
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
