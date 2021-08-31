/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module PartidasPresupuestarias.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public NumeroDePartida:JQuery; 
		public Descripcion:JQuery; 
		public Mnemo:JQuery; 
		public UnidadDeOrganizacion:JQuery; 
		public Prioridad:JQuery; 
		public DivisionesExtraPresupuestarias:SyncroTable; 
        public AsociarDivision: JQuery;
        public adivisiones: Divisiones[];
        public Modal: SyncroModal;
		public NombreDivision: JQuery;
		public CodigoCesida: JQuery;
		public AgregarDivision:JQuery;

		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.NumeroDePartida = $("#NumeroDePartida"+hash); 
			this.Descripcion = $("#Descripcion"+hash); 
			this.Mnemo = $("#Mnemo"+hash); 
			this.UnidadDeOrganizacion = $("#UnidadDeOrganizacion"+hash); 
			this.Prioridad = $("#Prioridad"+hash); 
			this.DivisionesExtraPresupuestarias = new SyncroTable($("#DivisionesExtraPresupuestarias"+hash)); 
            this.AsociarDivision = $("#AsociarDivision" + hash);
            this.adivisiones = [];
            this.Modal = new SyncroModal($("#MainModal"));

			this.NombreDivision = $("#NombrePartida"+hash);
			this.CodigoCesida = $("#CodigoCesida"+hash);
			this.AgregarDivision = $("#AgregarDivision" + hash);

			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.NumeroDePartida.focus();
		}
		
		public limpiar():void {
			
			this.NumeroDePartida.val("");
			this.Descripcion.val("");
			this.Mnemo.val("");
			this.UnidadDeOrganizacion.val('').trigger("liszt:updated");
			this.Prioridad.removeAttr('checked');
			this.DivisionesExtraPresupuestarias.limpiar();
            this.AsociarDivision.val("");
            this.adivisiones = [];
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
