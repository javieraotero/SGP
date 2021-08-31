/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
module NombramientosMovimientos.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Desde:JQuery; 
		public Hasta:JQuery; 
		public Cargo:JQuery; 
		public SituacionRevista:JQuery; 
        public Organismo: JQuery;
        public Todos: JQuery;
		public Cancelar: JQuery;
        public Guardar: JQuery;
        public Modal: SyncroModal;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Desde = $("#Desde"+hash); 
			this.Hasta = $("#Hasta"+hash); 
            this.Cargo = $("#Cargo" + hash); 
            this.Todos = $("#TodosLosOrganismos" + hash);
			this.SituacionRevista = $("#SituacionRevista"+hash); 
            this.Organismo = $("#OrganismosRef" + hash);
            this.Modal = new SyncroModal($("#ModalNombramiento" + hash));
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.Desde.focus();
		}
		
		public limpiar():void {
			
			this.Desde.val("");
			this.Hasta.val("");
			this.Cargo.val('').trigger("liszt:updated");
			this.SituacionRevista.val('').trigger("liszt:updated");
			this.Organismo.val('').trigger("liszt:updated");
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
