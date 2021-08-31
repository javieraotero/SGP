/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module Agentes.ts {
	
	export class Bonificaciones implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		

        //TODO: Legajo es secuencial.. se debe traer de la base el último + 1
		 
		public Mes:JQuery; 
		public Anio:JQuery; 
		public Desde:JQuery; 
		public Hasta:JQuery; 
		public body_agentes:JQuery; 
		public Ver:JQuery; 
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public Modal: SyncroModal;
        public Excel: JQuery;
        public ExcelMP: JQuery;


		//---  /Propiedades de Formulario --- //		
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Mes = $("#Mes"+hash); 
            this.Anio = $("#Anio"+hash); 
            this.Desde = $("#Desde"+hash); 
            this.Hasta = $("#Hasta"+hash); 
            this.Ver = $("#Ver"+hash); 
            this.body_agentes = $("#body_agentes"+hash); 
			
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.Modal = new SyncroModal($("#ModalAgentes"));
            this.Excel = $("#Excel" + hash);
            this.ExcelMP = $("#ExcelMP" + hash);

			//Establece el foco
			this.Mes.focus();
		}
		
		public limpiar():void {
			
			this.Mes.val("");
			this.Anio.val("");
			
			//this.Desde.val("");
			//this.Hasta.val("");

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
