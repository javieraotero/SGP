/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
module LicenciasAgente.ts {
	
	export class Excepcion implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public Guardar: JQuery;
        public Cancelar: JQuery;
		
		 
        public Resolucion: JQuery;
        public Dias: JQuery;
        public Observaciones: JQuery;
        public Licencia: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
            this.Observaciones = $("#Observaciones" + hash);
            this.Resolucion = $("#Resolucion" + hash);
            this.Dias = $("#DiasOtorgados" + hash);
            //operaciones
            this.Guardar = $("#Guardar" + hash);
            this.Cancelar = $("#Cancelar" + hash);

			//Establece el foco
			this.Resolucion.focus();
		}
		
		public limpiar():void {			
            this.Observaciones.val("");
            this.Dias.val("");
            this.Resolucion.val("");
		}
		
	
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
