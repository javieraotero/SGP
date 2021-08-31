
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module LicenciasRef.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Descripcion:JQuery; 
		public PorAnio:JQuery; 
		public PorLicencia:JQuery; 
		public Observaciones:JQuery; 
		public DiasAcumulables:JQuery; 
		public CodigoRRHH:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Descripcion = $("#Descripcion"+hash); 
			this.PorAnio = $("#PorAnio"+hash); 
			this.PorLicencia = $("#PorLicencia"+hash); 
			this.Observaciones = $("#Observaciones"+hash); 
			this.DiasAcumulables = $("#DiasAcumulables"+hash); 
			this.CodigoRRHH = $("#CodigoRRHH"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Descripcion.val("");
			this.PorAnio.val("");
			this.PorLicencia.val("");
			this.Observaciones.val("");
			this.DiasAcumulables.removeAttr('checked');
			this.CodigoRRHH.val("");
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
