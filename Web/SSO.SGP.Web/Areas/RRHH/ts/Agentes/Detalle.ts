
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module Agentes.ts {
	
	export class Detalle implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Legajo:JQuery; 
		public Telefono:JQuery; 
		public Profesion:JQuery; 
		public EstudiosCursados:JQuery; 
		public AfiliadoISS:JQuery; 
		public FechaDeCasamiento:JQuery; 
		public Persona:JQuery; 
		public Activo:JQuery; 
		public FechaBaja:JQuery; 
		public FechaAlta:JQuery; 
		public NumeroPS:JQuery; 
		public Domicilio:JQuery; 
		public FechaUltimoAscenso:JQuery; 
		public UltimoCargo:JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Legajo = $("#Legajo"+hash); 
			this.Telefono = $("#Telefono"+hash); 
			this.Profesion = $("#Profesion"+hash); 
			this.EstudiosCursados = $("#EstudiosCursados"+hash); 
			this.AfiliadoISS = $("#AfiliadoISS"+hash); 
			this.FechaDeCasamiento = $("#FechaDeCasamiento"+hash); 
			this.Persona = $("#Persona"+hash); 
			this.Activo = $("#Activo"+hash); 
			this.FechaBaja = $("#FechaBaja"+hash); 
			this.FechaAlta = $("#FechaAlta"+hash); 
			this.NumeroPS = $("#NumeroPS"+hash); 
			this.Domicilio = $("#Domicilio"+hash); 
			this.FechaUltimoAscenso = $("#FechaUltimoAscenso"+hash); 
			this.UltimoCargo = $("#UltimoCargo"+hash);
			//operaciones
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Legajo.val("");
			this.Telefono.val("");
			this.Profesion.val("");
			this.EstudiosCursados.val("");
			this.AfiliadoISS.val("");
			this.FechaDeCasamiento.val("");
			this.Persona.val("");
			this.Activo.val("");
			this.FechaBaja.val("");
			this.FechaAlta.val("");
			this.NumeroPS.val("");
			this.Domicilio.val("");
			this.FechaUltimoAscenso.val("");
			this.UltimoCargo.val("");
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
