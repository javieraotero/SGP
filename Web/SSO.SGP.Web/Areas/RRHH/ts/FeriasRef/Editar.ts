
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module FeriasRef.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Descripcion:JQuery; 
		public FechaDesde:JQuery; 
		public FechaHasta:JQuery; 
		public Anio:JQuery; 
		public DiaDesde:JQuery; 
		public MesDesde:JQuery; 
		public DiaHasta:JQuery; 
		public MesHasta:JQuery; 
		public Paso1:JQuery; 
		public Paso2:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Descripcion = $("#Descripcion"+hash); 
			this.FechaDesde = $("#FechaDesde"+hash); 
			this.FechaHasta = $("#FechaHasta"+hash); 
			this.Anio = $("#Anio"+hash); 
			this.DiaDesde = $("#DiaDesde"+hash); 
			this.MesDesde = $("#MesDesde"+hash); 
			this.DiaHasta = $("#DiaHasta"+hash); 
			this.MesHasta = $("#MesHasta"+hash); 
			this.Paso1 = $("#Paso1"+hash); 
			this.Paso2 = $("#Paso2"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Descripcion.val("");
			this.FechaDesde.val("");
			this.FechaHasta.val("");
			this.Anio.val("");
			this.DiaDesde.val("");
			this.MesDesde.val("");
			this.DiaHasta.val("");
			this.MesHasta.val("");
			this.Paso1.removeAttr('checked');
			this.Paso2.removeAttr('checked');
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
