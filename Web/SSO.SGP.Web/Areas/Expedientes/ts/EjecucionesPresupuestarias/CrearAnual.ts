/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module EjecucionesPresupuestarias.ts {
	
	export class CrearAnual implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Anio:JQuery; 
        public Errores: JQuery;
		public UnidadDeOrganizacion: JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        public verEjecucion: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Anio = $("#Anio"+hash); 
            this.Errores = $("#errores");
			this.UnidadDeOrganizacion = $("#UnidadesDeOrganizacionRef"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
            this.verEjecucion = $("#VerEjecucionesPresupuestarias" + hash);
			
			//Establece el foco
			this.Anio.focus();
		}
		
		public limpiar():void {
			
            this.Anio.val("");
            this.Resultado.html("");
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
