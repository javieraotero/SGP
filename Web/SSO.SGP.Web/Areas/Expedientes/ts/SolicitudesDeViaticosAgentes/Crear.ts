/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module SolicitudesDeViaticosAgentes.ts {
	
	export class Crear implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public SolicitudDeViatico:JQuery;
		public Agente:JQuery;
		public Dias:JQuery;
		public ImportePorDia:JQuery;
		public Subtotal:JQuery;
		public ImporteGastos:JQuery;
		public ImporteTotal:JQuery;
		public Cancelar:JQuery;
		public Guardar:JQuery;
		public GuardarYNuevo:JQuery;
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];
			this.SolicitudDeViatico = $('#SolicitudDeViatico'+hash);
			this.Agente = $('#Agente'+hash);
			this.Dias = $('#Dias'+hash);
			this.ImportePorDia = $('#ImportePorDia'+hash);
			this.Subtotal = $('#Subtotal'+hash);
			this.ImporteGastos = $('#ImporteGastos'+hash);
			this.ImporteTotal = $('#ImporteTotal'+hash);
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			this.GuardarYNuevo = $("#GuardarYNuevo"+hash);


			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    SolicitudDeViatico:{required:true, number:true, maxlength:4 },                
                    Agente:{required:true, number:true, maxlength:4 },                
                    Dias:{required:true, number:true, maxlength:4 },                
                    ImportePorDia:{required:true, decimal:true, maxlength:9 },                
                    Subtotal:{required:true, decimal:true, maxlength:9 },                
                    ImporteGastos:{required:true, decimal:true, maxlength:9 },                
                    ImporteTotal:{required:true, decimal:true, maxlength:9 },                },
                messages: {
 
                    SolicitudDeViatico: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    Agente: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    Dias: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    ImportePorDia: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 9 caracteres"}, 
                    Subtotal: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 9 caracteres"}, 
                    ImporteGastos: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 9 caracteres"}, 
                    ImporteTotal: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 9 caracteres"},                }
            });

        }

		public limpiar() {
			this.SolicitudDeViatico.val('').trigger("liszt:updated");
			this.Agente.val('').trigger("liszt:updated");
			this.Dias.val("");
			this.ImportePorDia.val("");
			this.Subtotal.val("");
			this.ImporteGastos.val("");
			this.ImporteTotal.val("");
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