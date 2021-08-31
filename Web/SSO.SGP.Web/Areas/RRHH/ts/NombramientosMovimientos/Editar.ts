/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module NombramientosMovimientos.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Nombramiento:JQuery; 
		public Desde:JQuery; 
		public Hasta:JQuery; 
		public Cargo:JQuery; 
		public SituacionRevista:JQuery; 
		public Organismo:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Nombramiento = $("#Nombramiento"+hash); 
			this.Desde = $("#Desde"+hash); 
			this.Hasta = $("#Hasta"+hash); 
			this.Cargo = $("#Cargo"+hash); 
			this.SituacionRevista = $("#SituacionRevista"+hash); 
			this.Organismo = $("#Organismo"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Nombramiento.val('').trigger("liszt:updated");
			this.Desde.val("");
			this.Hasta.val("");
			this.Cargo.val('').trigger("liszt:updated");
			this.SituacionRevista.val('').trigger("liszt:updated");
			this.Organismo.val('').trigger("liszt:updated");
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
