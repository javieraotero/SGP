/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module SolicitudesDeViaticos.ts {
	
	export class Editar implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public Id:JQuery;
		public Fecha:JQuery;
		public OrganismoSolicitante:JQuery;
		public Destino:JQuery;
		public FechaDeInicio:JQuery;
		public FechaDeFin:JQuery;
		public MedioDeTransporte:JQuery;
		public AutoOficial:JQuery;
		public ConChofer:JQuery;
		public FechaAlta:JQuery;
		public UsuarioAlta:JQuery;
		public Estado:JQuery;
		public MotivoDeComision:JQuery;
		public Expediente:JQuery;
		public Identificador:JQuery;
		public Cancelar:JQuery;
		public GuardarBorrador:JQuery;
		public GuardarYConfirmar: JQuery;
		public Imprimir: JQuery;
		public ModalSolicitud: SyncroModal;

		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];
			this.Id = $('#Id'+hash);
			this.Fecha = $('#Fecha'+hash);
			this.OrganismoSolicitante = $('#OrganismoSolicitante'+hash);
			this.Destino = $('#Destino'+hash);
			this.FechaDeInicio = $('#FechaDeInicio'+hash);
			this.FechaDeFin = $('#FechaDeFin'+hash);
			this.MedioDeTransporte = $('#MedioDeTransporte'+hash);
			this.AutoOficial = $('#AutoOficial'+hash);
			this.ConChofer = $('#ConChofer'+hash);
			this.FechaAlta = $('#FechaAlta'+hash);
			this.UsuarioAlta = $('#UsuarioAlta'+hash);
			this.Estado = $('#Estado'+hash);
			this.MotivoDeComision = $('#MotivoDeComision'+hash);
			this.Expediente = $('#Expediente'+hash);
			this.Identificador = $('#Identificador'+hash);
			this.Cancelar = $("#Cancelar"+hash);
			this.GuardarBorrador = $("#Guardar"+hash);
			this.GuardarYConfirmar = $("#GuardarYNuevo"+hash);
			this.Imprimir = $("#ImprimirSolicitud" + hash);
			this.ModalSolicitud = new SyncroModal($("#ImprimirSolicitudModal" + hash));

			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    Id:{required:true, number:true, maxlength:4 },                
                    Fecha:{required:true, number:false, maxlength:12 },                
                    OrganismoSolicitante:{required:true, number:true, maxlength:4 },                
                    Destino:{required:true, number:true, maxlength:4 },                
                    FechaDeInicio:{required:true, number:false, maxlength:12 },                
                    FechaDeFin:{required:true, number:false, maxlength:12 },                
                    MedioDeTransporte:{required:true, number:true, maxlength:4 },                
                    AutoOficial:{required:false, number:true, maxlength:4 },                
                    ConChofer:{required:true, number:false, maxlength:1 },                
                    FechaAlta:{required:true, number:false, maxlength:12 },                
                    UsuarioAlta:{required:true, number:true, maxlength:4 },                
                    Estado:{required:true, number:true, maxlength:4 },                
                    MotivoDeComision:{required:true, number:false, maxlength:150 },                
                    Expediente:{required:false, number:false, maxlength:10 },                
                    Identificador:{required:true, number:true, maxlength:4 },                },
                messages: {
 
                    Id: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    Fecha: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 12 caracteres"}, 
                    OrganismoSolicitante: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    Destino: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    FechaDeInicio: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 12 caracteres"}, 
                    FechaDeFin: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 12 caracteres"}, 
                    MedioDeTransporte: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    AutoOficial: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    ConChofer: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 1 caracteres"}, 
                    FechaAlta: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 12 caracteres"}, 
                    UsuarioAlta: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    Estado: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    MotivoDeComision: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 150 caracteres"}, 
                    Expediente: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 10 caracteres"}, 
                    Identificador: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"},                }
            });

        }

		public limpiar() {
			this.Id.val("");
			this.Fecha.val("");
			this.OrganismoSolicitante.val("");
			this.Destino.val("");
			this.FechaDeInicio.val("");
			this.FechaDeFin.val("");
			this.MedioDeTransporte.val("");
			this.AutoOficial.val("");
			this.ConChofer.removeAttr('checked');
			this.FechaAlta.val("");
			this.UsuarioAlta.val("");
			this.Estado.val("");
			this.MotivoDeComision.val("");
			this.Expediente.val("");
			this.Identificador.val("");
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