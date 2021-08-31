
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module GrupoFamiliar.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public modal: SyncroModal;		 
        public GrupoFamiliar: SyncroTable;
        public Nuevo: JQuery;
        public Cancelar: JQuery;
        public Agente: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
            this.modal = new SyncroModal($("#ModalGrupoFamiliar" + hash));
            this.GrupoFamiliar = new SyncroTable($("#GrupoFamiliar" + hash));		
            this.Agente = $("#Agente" + hash);   
            //operaciones
            this.Nuevo = $("#Nuevo" + hash);
            this.Cancelar = $("#Cancelar" + hash);

            //this.GrupoFamiliar.refrescar();
		}
		
		public limpiar():void {
			
			
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
