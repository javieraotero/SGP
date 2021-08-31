
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module ImputacionesContables.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public ExpedienteAImputar:JQuery; 
		public Fecha:JQuery; 
		public UsuarioAlta:JQuery; 
		public FechaElimina:JQuery; 
		public Operacion:JQuery; 
		public ExpedienteIndirecto:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.ExpedienteAImputar = $("#ExpedienteAImputar"+hash); 
			this.Fecha = $("#Fecha"+hash); 
			this.UsuarioAlta = $("#UsuarioAlta"+hash); 
			this.FechaElimina = $("#FechaElimina"+hash); 
			this.Operacion = $("#Operacion"+hash); 
			this.ExpedienteIndirecto = $("#ExpedienteIndirecto"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.ExpedienteAImputar.val('').trigger("liszt:updated");
			this.Fecha.val("");
			this.UsuarioAlta.val("");
			this.FechaElimina.val("");
			this.Operacion.val('').trigger("liszt:updated");
			this.ExpedienteIndirecto.val('').trigger("liszt:updated");
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
