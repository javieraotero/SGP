
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module ImputacionesContables.ts {
	
	export class Imputar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public ExpedienteAImputar:SyncroAutocomplete; 
		public Fecha:JQuery; 
		public Afectacion:JQuery; 
		public Compromiso:JQuery; 
		public OrdenadoAPagar:JQuery; 
		public Partida:SyncroAutocomplete; 
		public Division:JQuery; 
		public Importe:JQuery; 
		public Agregar:JQuery; 
		public Detalle:SyncroTable;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.ExpedienteAImputar = new SyncroAutocomplete("#ExpedienteAImputar"+hash, "url"); 
			this.Fecha = $("#Fecha"+hash); 
			this.Afectacion = $("#Afectacion"+hash); 
			this.Compromiso = $("#Compromiso"+hash); 
			this.OrdenadoAPagar = $("#OrdenadoAPagar"+hash); 
			this.Partida = new SyncroAutocomplete("#Partida"+hash, "url"); 
			this.Division = $("#Division"+hash); 
			this.Importe = $("#Importe"+hash); 
			this.Agregar = $("#Agregar"+hash); 
			this.Detalle = new SyncroTable($("#Detalle"+hash));
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.ExpedienteAImputar.focus();
		}
		
		public limpiar():void {
			
			this.ExpedienteAImputar.limpiar();
			this.Fecha.val("");
			this.Afectacion.removeAttr('checked');
			this.Compromiso.removeAttr('checked');
			this.OrdenadoAPagar.removeAttr('checked');
			this.Partida.limpiar();
			this.Division.val('').trigger("liszt:updated");
			this.Importe.val("");
			this.Agregar.val("");
			this.Detalle.limpiar();
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
