/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module SolicitudesDeViaticosRendiciones.ts {
	
	export class Editar implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public Id:JQuery;
		public SolicitudDeViatico:JQuery;
		public FechaDeInicio:JQuery;
		public FechaDeFin:JQuery;
		public TotalBienesDeConsumo:JQuery;
		public TotalServiciosNoPersonales:JQuery;
		public TotalOtros:JQuery;
		public FechaDeAlta:JQuery;
		public UsuarioAlta:JQuery;
		public Cancelar:JQuery;
		public Guardar:JQuery;
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];
			this.Id = $('#Id'+hash);
			this.SolicitudDeViatico = $('#SolicitudDeViatico'+hash);
			this.FechaDeInicio = $('#FechaDeInicio'+hash);
			this.FechaDeFin = $('#FechaDeFin'+hash);
			this.TotalBienesDeConsumo = $('#TotalBienesDeConsumo'+hash);
			this.TotalServiciosNoPersonales = $('#TotalServiciosNoPersonales'+hash);
			this.TotalOtros = $('#TotalOtros'+hash);
			this.FechaDeAlta = $('#FechaDeAlta'+hash);
			this.UsuarioAlta = $('#UsuarioAlta'+hash);
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);


			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    Id:{required:true, number:true, maxlength:4 },                
                    SolicitudDeViatico:{required:true, number:true, maxlength:4 },                
                    FechaDeInicio:{required:true, number:false, maxlength:12 },                
                    FechaDeFin:{required:true, number:false, maxlength:12 },                
                    TotalBienesDeConsumo:{required:true, decimal:true, maxlength:9 },                
                    TotalServiciosNoPersonales:{required:true, decimal:true, maxlength:9 },                
                    TotalOtros:{required:true, decimal:true, maxlength:9 },                
                    FechaDeAlta:{required:true, number:false, maxlength:12 },                
                    UsuarioAlta:{required:true, number:true, maxlength:4 },                },
                messages: {
 
                    Id: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    SolicitudDeViatico: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    FechaDeInicio: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 12 caracteres"}, 
                    FechaDeFin: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 12 caracteres"}, 
                    TotalBienesDeConsumo: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 9 caracteres"}, 
                    TotalServiciosNoPersonales: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 9 caracteres"}, 
                    TotalOtros: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 9 caracteres"}, 
                    FechaDeAlta: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 12 caracteres"}, 
                    UsuarioAlta: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"},                }
            });

        }

		public limpiar() {
			this.Id.val("");
			this.SolicitudDeViatico.val('').trigger("liszt:updated");
			this.FechaDeInicio.val("");
			this.FechaDeFin.val("");
			this.TotalBienesDeConsumo.val("");
			this.TotalServiciosNoPersonales.val("");
			this.TotalOtros.val("");
			this.FechaDeAlta.val("");
			this.UsuarioAlta.val("");
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