/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
module LicenciasAgente.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
        public AgenteRRHH: SyncroAutocomplete; 
        public AgenteRRHHOrganismo: SyncroAutocomplete; 
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
        public IdSuperior: JQuery;
        public Nombramiento: JQuery;
        public AgenteSolicita: JQuery;
        public FuncionarioAprueba: SyncroAutocomplete;
        public ApruebaDGA: JQuery;
        public ApruebaDGA2: JQuery;
        public TablaApruebaFuncionario: JQuery;

        public OtroFuncionarioAprueba: SyncroAutocomplete;
        public OtroAprueba: JQuery;
        public TablaApruebaOtroFuncionario: JQuery;
        public fileArchivo: SyncroUpload;
        public fileArchivo2: SyncroUpload;
        public Archivo: JQuery;
        public Archivo2: JQuery;
        public fileCertificado1: SyncroUpload;
        public fileCertificado2: SyncroUpload;
        public Certificado1: JQuery;
        public Certificado2: JQuery;
        public divDias: JQuery;
        public divFechaHasta: JQuery;
        public Confirmar: JQuery;
        public Cerrar: JQuery;

		//---  /Propiedades de Formulario --- //
		
        constructor(hash: string) {
            var self = this;
			this.form = $("#" + hash);
			this.datatables = [];					    
            this.AgenteRRHH = new SyncroAutocomplete("AgenteRRHH" + hash, "Agentes/GetJson");
            this.AgenteRRHHOrganismo = new SyncroAutocomplete("AgenteRRHHOrganismo" + hash, "Agentes/GetJsonOrganismo");
			this.FechaDesde = $("#FechaDesde"+hash); 
			this.FechaHasta = $("#FechaHasta"+hash); 
            this.Licencia = new SyncroSelect("LicenciasRef"+hash, true); 
			this.Observaciones = $("#Observaciones"+hash); 
            this.Licencias = new SyncroTable($("#Licencias" + hash));
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
            this.SubroganteRRHH = new SyncroAutocomplete("SubroganteRRHH" + hash, "Agentes/GetFuncionariosJson");
            this.divSubrogante = $("#divSubrogante");
            this.IdSuperior = $("#Superior");
            this.Nombramiento = $("#Nombramiento");
            this.AgenteSolicita = $("#AgenteSolicita");
            this.FuncionarioAprueba = new SyncroAutocomplete("FuncionariosRRHH" + hash, "Agentes/GetFuncionariosJson");
            this.ApruebaDGA = $("#dga");
            this.ApruebaDGA2 = $("#dga2");
            this.TablaApruebaFuncionario = $("#SeleccionaFuncionario");

            this.OtroFuncionarioAprueba = new SyncroAutocomplete("OtrosFuncionariosRRHH" + hash, "Agentes/GetFuncionariosJson");
            this.OtroAprueba = $("#Otro_Superior");
            this.TablaApruebaOtroFuncionario = $("#SeleccionaOtroFuncionario");

			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
            this.Denegar = $("#Denegar" + hash);
            this.Cerrar = $("#Cerrar" + hash);
            this.Confirmar = $("#Confirmar" + hash);

            this.divDias = $("#divDias");
            this.divFechaHasta = $("#divFechaHasta");
			
            this.AgenteRRHHOrganismo.setCallback(function (ui) {
                console.log("cambio el agente para hacer upload");
                self.fileArchivo.setOnUploadDoneWithUrl('ArchivosAdjuntos/UploadFilesLicencia/?agente=' + ui.item.id, function (e, file) {
                    self.Archivo.val(file.Id).attr("data-nombre", file.Name);
                });
                self.fileArchivo2.setOnUploadDoneWithUrl('ArchivosAdjuntos/UploadFilesLicencia/?agente=' + ui.item.id, function (e, file) {
                    self.Archivo2.val(file.Id).attr("data-nombre", file.Name);
                });
            });

            this.fileCertificado1 = new SyncroUpload($("#fileCertificado1" + hash));
            this.Certificado1 = $("#Certificado1" + hash);

            this.fileCertificado1.setOnUploadDoneWithUrl(self.fileCertificado1.e.data("url"), function (e, file) {
                self.Certificado1.val(file.Id).attr("data-nombre", file.Name);
            });

            this.fileCertificado2 = new SyncroUpload($("#fileCertificado2" + hash));
            this.Certificado2 = $("#Certificado2" + hash);

            this.fileCertificado2.setOnUploadDoneWithUrl(self.fileCertificado2.e.data("url"), function (e, file) {
                self.Certificado2.val(file.Id).attr("data-nombre", file.Name);
            });

			//Establece el foco
			this.AgenteRRHH.txt.focus();
		}
		
		public limpiar():void {
			
			this.AgenteRRHH.limpiar();
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
            this.Licencias.limpiar();
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
