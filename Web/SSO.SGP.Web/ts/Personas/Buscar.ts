
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../ts/Syncro/SyncroAutocomplete.ts"/>
module Personas.ts {
	
	export class Buscar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Documento:JQuery; 
		public Apellidos:JQuery; 
		public Nombre:JQuery; 
		public Sexo:JQuery; 
		public Localidad:JQuery; 
		public Buscar:JQuery; 
		public Personas:SyncroTable;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Documento = $("#Documento"+hash); 
			this.Apellidos = $("#Apellidos"+hash); 
			this.Nombre = $("#Nombre"+hash); 
			this.Sexo = $("#Sexo"+hash); 
            //this.Localidad = new SyncroAutocomplete("#Localidad"+hash, "Personas/LocalidadesJson"); 
            this.Localidad = $("#Localidad" + hash);
            this.Buscar = $("#Buscar" + hash); 
			this.Personas = new SyncroTable($("#Personas"+hash));
			//operaciones
			
			//Establece el foco
			this.Documento.focus();
		}
		
		public limpiar():void {
			
			this.Documento.val("");
			this.Apellidos.val("");
			this.Nombre.val("");
			this.Sexo.val('').trigger("liszt:updated");
			this.Localidad.limpiar();
			this.Buscar.val("");
			this.Personas.limpiar();
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
