
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module Agentes.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		

        //TODO: Legajo es secuencial.. se debe traer de la base el último + 1
		 
		public Legajo:JQuery; 
		public Telefono:JQuery; 
		public Profesion:JQuery; 
		public EstudiosCursados:JQuery; 
		public AfiliadoISS:JQuery; 
		public FechaDeCasamiento:JQuery; 
		public Persona:JQuery; 
		public NumeroPS:JQuery; 
		public Domicilio:JQuery; 
		public FechaUltimoAscenso:JQuery; 
		public UltimoCargo:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        public Modal: SyncroModal;
        public DetalleAgente: JQuery;
        public detalle: JQuery;
        public PersonaId: JQuery;


		//---  /Propiedades de Formulario --- //
		
        constructor(hash: string) {
            var that = this;
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Legajo = $("#Legajo"+hash); 
			this.Telefono = $("#Telefono"+hash); 
			this.Profesion = $("#Profesion"+hash); 
			this.EstudiosCursados = $("#EstudiosCursados"+hash); 
			this.AfiliadoISS = $("#AfiliadoISS"+hash); 
			this.FechaDeCasamiento = $("#FechaDeCasamiento"+hash); 
			this.Persona = $("#BuscarPersona"+hash); 
			this.NumeroPS = $("#NumeroPS"+hash); 
			this.Domicilio = $("#Domicilio"+hash); 
			this.FechaUltimoAscenso = $("#FechaUltimoAscenso"+hash); 
            this.UltimoCargo = $("#UltimoCargo" + hash);
            this.DetalleAgente = $("#DetalleAgente");
            this.detalle = $("#detalle");
            this.PersonaId = $("#Persona");
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);

            this.Modal = new SyncroModal($("#ModalAgentes"));
			
			//Establece el foco
			this.Legajo.focus();
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
