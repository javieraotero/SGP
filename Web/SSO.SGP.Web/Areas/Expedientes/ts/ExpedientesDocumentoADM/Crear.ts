/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module ExpedientesDocumentoADM.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Archivo:SyncroUpload; 
		public Confirmado:JQuery; 
		public Actuacion:JQuery; 
		public NombreOriginal:JQuery; 
		public Extension:JQuery; 
		public Descripcion:JQuery; 
		public Usuario:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		public GuardarYNuevo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Archivo = new SyncroUpload($("#Archivo"+hash)); 
			this.Confirmado = $("#Confirmado"+hash); 
			this.Actuacion = $("#Actuacion"+hash); 
			this.NombreOriginal = $("#NombreOriginal"+hash); 
			this.Extension = $("#Extension"+hash); 
			this.Descripcion = $("#Descripcion"+hash); 
			this.Usuario = $("#Usuario"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);
			
			//Establece el foco
			this.Archivo.focus();
		}
		
		public limpiar():void {
			
			this.Archivo.val("");
			this.Confirmado.removeAttr('checked');
			this.Actuacion.val("");
			this.NombreOriginal.val("");
			this.Extension.val("");
			this.Descripcion.val("");
			this.Usuario.val("");
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
