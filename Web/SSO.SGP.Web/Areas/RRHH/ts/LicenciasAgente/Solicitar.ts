/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
module LicenciasAgente.ts {
	
	export class Solicitar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];	
		 
		public AgenteRRHH:SyncroAutocomplete; 
		public FechaDesde:JQuery; 
		public FechaHasta:JQuery; 
		public Licencia:SyncroSelect; 
		public Observaciones:JQuery; 
        public Licencias: SyncroTable;
        public ResumenDias: SyncroTable;
        public EnElAnio: JQuery;
        public EnTotal: JQuery;
        public Dias: JQuery;
        public txtLegajo: JQuery;
        public Legajo: JQuery;
        public Codigo: JQuery;
        public Expediente: JQuery;
        public AnioExpediente: JQuery;
        public FiltroDesde: JQuery;
        public FiltroHasta: JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;  
        public Denegar: JQuery;
        public divSubrogante: JQuery;
        public SubroganteRRHH: SyncroAutocomplete; 
        public div_subrogante: JQuery;
        public fileCertificado1: SyncroUpload;
        public fileCertificado2: SyncroUpload;
        public Certificado1: JQuery;
        public Certificado2: JQuery;
		//---  /Propiedades de Formulario --- //
		
        constructor(hash: string) {
            var self = this;
			this.form = $("#" + hash);
			this.datatables = [];					    
            //this.AgenteRRHH = new SyncroAutocomplete("AgenteRRHH" + hash, "Agentes/GetJson");
			this.FechaDesde = $("#FechaDesde"+hash); 
			this.FechaHasta = $("#FechaHasta"+hash); 
            this.Licencia = new SyncroSelect("LicenciasRef"+hash, true); 
			this.Observaciones = $("#Observaciones"+hash); 
            //this.Licencias = new SyncroTable($("#Licencias" + hash));
            this.ResumenDias = new SyncroTable($("#ResumenDias" + hash));
            this.EnElAnio = $("#EnElAnio");
            this.EnTotal = $("#EnTotal");
            this.Dias = $("#Dias" + hash);
            this.Legajo = $("#Legajo" + hash);
            this.Codigo = $("#Licencia" + hash);
            this.txtLegajo = $("#txtLegajo" + hash);
            this.Expediente = $("#Expediente" + hash);
            this.AnioExpediente = $("#AnioExpediente" + hash);
            this.FiltroDesde = $("#FiltroDesde" + hash);
            this.FiltroHasta = $("#FiltroHasta" + hash);
            this.SubroganteRRHH = new SyncroAutocomplete("SubroganteRRHH" + hash, "Agentes/GetJsonFuncionarios");
            this.div_subrogante = $("#div_subrogante" + hash);

			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
            this.Denegar = $("#Denegar" + hash);

            this.fileCertificado1 = new SyncroUpload($("#fileCertificado1" + hash));
            this.Certificado1 = $("#Certificado1" + hash);

            this.fileCertificado1.setOnUploadDoneWithUrl(self.fileCertificado1.e.data("url"), function (e, file) {
                self.Certificado1.val(file.Id).attr("data-nombre", file.Name);
            });
			
			//Establece el foco
			this.AgenteRRHH.txt.focus();
		}
		
		public limpiar():void {
			
			//this.AgenteRRHH.limpiar();
			this.FechaDesde.val("");
			this.FechaHasta.val("");
			//this.Licencia.val('').trigger("liszt:updated");
            this.Observaciones.val("");
            this.Dias.val("");
            this.EnElAnio.val("");
            this.EnTotal.val("");
            this.Codigo.val("");
            this.AnioExpediente.val("");
            this.Expediente.html("");
            //this.Licencias.limpiar();
            this.ResumenDias.limpiar();
            this.SubroganteRRHH.limpiar();
            //this.AnioExpediente.pulsate("destroy");
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
