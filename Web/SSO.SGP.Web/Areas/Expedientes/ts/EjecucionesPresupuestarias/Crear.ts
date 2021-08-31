/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module EjecucionesPresupuestarias.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Anio:JQuery; 
		public PartidaPresupuestaria:JQuery; 
		public EstaBloqueada:JQuery; 
		public CreditoActual:JQuery; 
		public CreditoDisponible:JQuery; 
		public CreditoHabilitado:JQuery; 
		public MontoPreventiva:JQuery; 
		public MontoCompromiso:JQuery; 
		public MontoOrdenadoAPagar:JQuery; 
		public PresupuestoSolicitado:JQuery; 
		public Presupuestado:JQuery; 
		public ReestructuraMas:JQuery; 
		public ReestructuraMenos:JQuery; 
		public Factibilidad:JQuery; 
		public FactibilidadHabilitada:JQuery; 
		public ReservaMas:JQuery; 
		public ReservaMenos:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        public verEjecucion: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Anio = $("#Anio"+hash); 
			this.PartidaPresupuestaria = $("#PartidaPresupuestaria"+hash); 
			this.EstaBloqueada = $("#EstaBloqueada"+hash); 
			this.CreditoActual = $("#CreditoActual"+hash); 
			this.CreditoDisponible = $("#CreditoDisponible"+hash); 
			this.CreditoHabilitado = $("#CreditoHabilitado"+hash); 
			this.MontoPreventiva = $("#MontoPreventiva"+hash); 
			this.MontoCompromiso = $("#MontoCompromiso"+hash); 
			this.MontoOrdenadoAPagar = $("#MontoOrdenadoAPagar"+hash); 
			this.PresupuestoSolicitado = $("#PresupuestoSolicitado"+hash); 
			this.Presupuestado = $("#Presupuestado"+hash); 
			this.ReestructuraMas = $("#ReestructuraMas"+hash); 
			this.ReestructuraMenos = $("#ReestructuraMenos"+hash); 
			this.Factibilidad = $("#Factibilidad"+hash); 
			this.FactibilidadHabilitada = $("#FactibilidadHabilitada"+hash); 
			this.ReservaMas = $("#ReservaMas"+hash); 
			this.ReservaMenos = $("#ReservaMenos"+hash);
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
			this.PartidaPresupuestaria.val('').trigger("liszt:updated");
			this.EstaBloqueada.removeAttr('checked');
			this.CreditoActual.val("");
			this.CreditoDisponible.val("");
			this.CreditoHabilitado.val("");
			this.MontoPreventiva.val("");
			this.MontoCompromiso.val("");
			this.MontoOrdenadoAPagar.val("");
			this.PresupuestoSolicitado.val("");
			this.Presupuestado.val("");
			this.ReestructuraMas.val("");
			this.ReestructuraMenos.val("");
			this.Factibilidad.val("");
			this.FactibilidadHabilitada.val("");
			this.ReservaMas.val("");
			this.ReservaMenos.val("");
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
