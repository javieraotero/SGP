
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module Agentes.ts {
	
	export class CrearMovimientoCesida implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		

        //TODO: Legajo es secuencial.. se debe traer de la base el último + 1
		 
		public Agente:JQuery; 
        public Movimiento: JQuery;
        public body_parametros: JQuery;
        public row_parametros: JQuery;

		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        public Modal: SyncroModal;
        public DetalleAgente: JQuery;
        public detalle: JQuery;
        public PersonaId: JQuery;
        public Nombramiento: any;

		//---  /Propiedades de Formulario --- //		
		constructor(hash: string){
			this.form = $("#" + hash);
            this.datatables = [];	
		 
			this.Agente = $("#Agente"+hash); 

            this.Movimiento = $("#Movimiento" + hash);
            this.body_parametros = $("#body_parametros" + hash);
            this.row_parametros = $("#row_parametros" + hash);
            
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);

            this.Modal = new SyncroModal($("#ModalAgentes"));
			
			
		}
		
		public limpiar():void {
			
			this.Legajo.val("");
			this.Telefono.val("");
			this.Profesion.val("");
			this.EstudiosCursados.val("");
			this.AfiliadoISS.val("");
			this.FechaDeCasamiento.val("");
			this.Persona.val('').trigger("liszt:updated");
			this.NumeroPS.val("");
			this.Domicilio.val("");
			this.FechaUltimoAscenso.val("");
			this.UltimoCargo.val('').trigger("liszt:updated");
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
