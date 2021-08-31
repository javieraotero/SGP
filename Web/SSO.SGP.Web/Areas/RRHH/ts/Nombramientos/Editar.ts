
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module Nombramientos.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Agente:JQuery; 
		public FechaDeAlta:JQuery; 
		public FechaDeBaja:JQuery; 
		public Motivo:JQuery; 
		public Organismo:JQuery; 
		public Cargo:JQuery; 
		public SituacionRevista:JQuery; 
		public FechaFinContrato:JQuery; 
		public FechaFinSustitucion:JQuery; 
		public FechaRenuncia:JQuery; 
		public FechaPaseAPlanta:JQuery; 
        public FechaUltimoAscenso: JQuery;
        public TodosLosOrganismos: JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Agente = $("#Agente"+hash); 
			this.FechaDeAlta = $("#FechaDeAlta"+hash); 
			this.FechaDeBaja = $("#FechaDeBaja"+hash); 
			this.Motivo = $("#Motivo"+hash); 
            this.Organismo = $("#OrganismosRef" + hash);
			this.Cargo = $("#Cargo"+hash); 
			this.SituacionRevista = $("#SituacionRevista"+hash); 
			this.FechaFinContrato = $("#FechaFinContrato"+hash); 
			this.FechaFinSustitucion = $("#FechaFinSustitucion"+hash); 
			this.FechaRenuncia = $("#FechaRenuncia"+hash); 
			this.FechaPaseAPlanta = $("#FechaPaseAPlanta"+hash); 
            this.FechaUltimoAscenso = $("#FechaUltimoAscenso" + hash);
            this.TodosLosOrganismos = $("#TodosLosOrganismos" + hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Agente.val("");
			this.FechaDeAlta.val("");
			this.FechaDeBaja.val("");
			this.Motivo.val("");
			//this.Organismo.limpiar();
			this.Cargo.val('').trigger("liszt:updated");
			this.SituacionRevista.val("");
			this.FechaFinContrato.val("");
			this.FechaFinSustitucion.val("");
			this.FechaRenuncia.val("");
			this.FechaPaseAPlanta.val("");
			this.FechaUltimoAscenso.val("");
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
