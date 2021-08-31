/// <reference path="../../../../ts/types/chosen.jquery.d.ts" />
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
module ConcursosDeIngreso.ts {
	
	export class Editar implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
				public Id:JQuery;
				public Nombre:JQuery;
				public Descripcion:JQuery;
				public FechaInicio:JQuery;
				public FechaFin:JQuery;
				public Organismo:JQuery;
				public Cargo:JQuery;
						public Cancelar:JQuery;
				public Guardar:JQuery;
				
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];
						this.Id = $('#Id'+hash);
						this.Nombre = $('#Nombre'+hash);
						this.Descripcion = $('#Descripcion'+hash);
						this.FechaInicio = $('#FechaInicio'+hash);
						this.FechaFin = $('#FechaFin'+hash);
						this.Organismo = $('#Organismo'+hash);
						this.Cargo = $('#Cargo'+hash);
									this.Cancelar = $("#Cancelar"+hash);
						this.Guardar = $("#Guardar"+hash);
						this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
				                    
					Id:{required:true, number:true, maxlength:4 },
					                
					Nombre:{required:true, number:false, maxlength:150 },
					                
					Descripcion:{required:false, number:false, maxlength:250 },
					                
					FechaInicio:{required:true, number:false, maxlength:8 },
					                
					FechaFin:{required:true, number:false, maxlength:8 },
					                
					Organismo:{required:true, number:true, maxlength:4 },
					                
					Cargo:{required:true, number:true, maxlength:4 },
					                },
                messages: {
					 
					Id: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"},
					 
					Nombre: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 150 caracteres"},
					 
					Descripcion: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 250 caracteres"},
					 
					FechaInicio: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 8 caracteres"},
					 
					FechaFin: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 8 caracteres"},
					 
					Organismo: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"},
					 
					Cargo: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"},
					                }
            });

        }

		public limpiar() {
					this.Id.val("");
					this.Nombre.val("");
					this.Descripcion.val("");
					this.FechaInicio.val("");
					this.FechaFin.val("");
					this.Organismo.val('').trigger("liszt:updated");
					this.Cargo.val('').trigger("liszt:updated");
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