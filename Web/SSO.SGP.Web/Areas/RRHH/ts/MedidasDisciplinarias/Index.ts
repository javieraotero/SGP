
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module MedidasDisciplinarias.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
        public MedidasDisciplinarias: SyncroTable;
        public Nuevo: JQuery;
        public Cancelar: JQuery;
        public modal: SyncroModal;
        public Agente: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
            this.MedidasDisciplinarias = new SyncroTable($("#MedidasDisciplinarias" + hash));
            this.modal = new SyncroModal($("#ModalMedidasDisciplinarias" + hash));
            this.Agente = $("#Agente" + hash);
            //operaciones
            this.Nuevo = $("#Nuevo" + hash);
            this.Cancelar = $("#Cancelar" + hash);
		}
		
		public limpiar():void {
			
			this.MedidasDisciplinarias.limpiar();
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
