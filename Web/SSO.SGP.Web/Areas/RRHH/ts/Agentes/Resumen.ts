
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module Agentes.ts {
	
	export class Resumen implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		public Nombre:JQuery; 
		public Documento:JQuery; 
		public Legajo:JQuery; 
		public Domicilio:JQuery; 
		public Telefono:JQuery; 
        public DiasDisponibles: SyncroTable; 
        public fileArchivo: SyncroUpload;
        public Archivo: JQuery; 
        public Id: JQuery;
		//public Nombramientos:SyncroTable; 
		//public Medidas:SyncroTable; 
		//public Dias:JQuery;
		//---  /Propiedades de Formulario --- //
		
        constructor(hash: string) {
            var that = this;
			this.form = $("#" + hash);
			this.datatables = [];
			
			this.Nombre = $("#Nombre"+hash); 
			this.Documento = $("#Documento"+hash); 
			this.Legajo = $("#Legajo"+hash); 
			this.Domicilio = $("#Domicilio"+hash); 
			this.Telefono = $("#Telefono"+hash); 
            this.DiasDisponibles = new SyncroTable($("#DiasDisponibles" + hash));
            this.Id = $("#Agente" + hash); 
			//this.Nombramientos = new SyncroTable($("#Nombramientos"+hash)); 
			//this.Medidas = new SyncroTable($("#Medidas"+hash)); 
			//operaciones

            this.fileArchivo = new SyncroUpload($("#fileuploadArchivo" + hash));
            this.Archivo = $("#Archivo" + hash);
            this.fileArchivo.setOnUploadDone(function (e, file) {
                that.Archivo.val(file.Id).attr("data-nombre", file.Name);
                $("#img_profile").attr("scr", "/files/perfiles/"+file.Name);
            });
			
			//Establece el foco
			this.Nombre.focus();
		}
		
		public limpiar():void {
			
			this.Nombre.val("");
			this.Documento.val("");
			this.Legajo.val("");
			this.Domicilio.val("");
			this.Telefono.val("");
			this.DiasDisponibles.limpiar();
			//this.Nombramientos.limpiar();
			//this.Medidas.limpiar();
			//this.Dias.val("");
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
