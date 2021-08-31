
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module ExpedientesADM.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Tipo:JQuery; 
		public Categoria:JQuery; 
		public Numero:JQuery; 
		public NumeroDeTramite:JQuery; 
		public NumeroDeCorresponde:JQuery; 
		public FechaDeAlta:JQuery; 
		public Fecha:JQuery; 
		public UsuarioAlta:JQuery; 
		public UsuarioBaja:JQuery; 
		public FechaDeBaja:JQuery; 
		public Caratula:JQuery; 
		public OrganismoIniciador:JQuery; 
		public TextoIniciador:JQuery; 
		public ExpedienteAcumulado:JQuery; 
		public FechaAcumulado:JQuery; 
		public UsuarioAcumulado:JQuery; 
		public ExpedientePadre:JQuery; 
		public UltimoCorresponde:JQuery; 
		public Archivado:JQuery; 
		public FechaArchivado:JQuery; 
		public UsuarioArchiva:JQuery; 
		public AnioContable:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Tipo = $("#Tipo"+hash); 
			this.Categoria = $("#Categoria"+hash); 
			this.Numero = $("#Numero"+hash); 
			this.NumeroDeTramite = $("#NumeroDeTramite"+hash); 
			this.NumeroDeCorresponde = $("#NumeroDeCorresponde"+hash); 
			this.FechaDeAlta = $("#FechaDeAlta"+hash); 
			this.Fecha = $("#Fecha"+hash); 
			this.UsuarioAlta = $("#UsuarioAlta"+hash); 
			this.UsuarioBaja = $("#UsuarioBaja"+hash); 
			this.FechaDeBaja = $("#FechaDeBaja"+hash); 
			this.Caratula = $("#Caratula"+hash); 
			this.OrganismoIniciador = $("#OrganismoIniciador"+hash); 
			this.TextoIniciador = $("#TextoIniciador"+hash); 
			this.ExpedienteAcumulado = $("#ExpedienteAcumulado"+hash); 
			this.FechaAcumulado = $("#FechaAcumulado"+hash); 
			this.UsuarioAcumulado = $("#UsuarioAcumulado"+hash); 
			this.ExpedientePadre = $("#ExpedientePadre"+hash); 
			this.UltimoCorresponde = $("#UltimoCorresponde"+hash); 
			this.Archivado = $("#Archivado"+hash); 
			this.FechaArchivado = $("#FechaArchivado"+hash); 
			this.UsuarioArchiva = $("#UsuarioArchiva"+hash); 
			this.AnioContable = $("#AnioContable"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Tipo.val('').trigger("liszt:updated");
			this.Categoria.val('').trigger("liszt:updated");
			this.Numero.val("");
			this.NumeroDeTramite.val("");
			this.NumeroDeCorresponde.val("");
			this.FechaDeAlta.val("");
			this.Fecha.val("");
			this.UsuarioAlta.val("");
			this.UsuarioBaja.val("");
			this.FechaDeBaja.val("");
			this.Caratula.val("");
			this.OrganismoIniciador.val('').trigger("liszt:updated");
			this.TextoIniciador.val("");
			this.ExpedienteAcumulado.val('').trigger("liszt:updated");
			this.FechaAcumulado.val("");
			this.UsuarioAcumulado.val('').trigger("liszt:updated");
			this.ExpedientePadre.val('').trigger("liszt:updated");
			this.UltimoCorresponde.val("");
			this.Archivado.removeAttr('checked');
			this.FechaArchivado.val("");
			this.UsuarioArchiva.val('').trigger("liszt:updated");
			this.AnioContable.val("");
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
