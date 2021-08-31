/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module ArchivosAdjuntos.ts {
	
	export class Editar implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
				public Id:JQuery;
				public Path:JQuery;
				public Nombre:JQuery;
				public Descripcion:JQuery;
				public Sentencia:JQuery;
				public Sumario:JQuery;
						public Cancelar:JQuery;
				public Guardar:JQuery;
				
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];
						this.Id = $('#Id'+hash);
						this.Path = $('#Path'+hash);
						this.Nombre = $('#Nombre'+hash);
						this.Descripcion = $('#Descripcion'+hash);
						this.Sentencia = $('#Sentencia'+hash);
						this.Sumario = $('#Sumario'+hash);
									this.Cancelar = $("#Cancelar"+hash);
						this.Guardar = $("#Guardar"+hash);
						//this.validacion();
		}

		//public validacion() {
  //          this.form.validate({
  //              errorClass: "field-validation-error",                
  //              rules: {
				                    
		//			Id:{required:true, number:true, maxlength:4 },
					                
		//			Path:{required:true, number:false, maxlength:200 },
					                
		//			Nombre:{required:true, number:false, maxlength:150 },
					                
		//			Descripcion:{required:false, number:false, maxlength:250 },
					                
		//			Sentencia:{required:false, number:true, maxlength:4 },
					                
		//			Sumario:{required:false, number:true, maxlength:4 },
		//			                },
  //              messages: {
					 
		//			Id: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"},
					 
		//			Path: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 200 caracteres"},
					 
		//			Nombre: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 150 caracteres"},
					 
		//			Descripcion: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 250 caracteres"},
					 
		//			Sentencia: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"},
					 
		//			Sumario: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"},
		//			                }
  //          });

  //      }

		public limpiar() {
					this.Id.val("");
					this.Path.val("");
					this.Nombre.val("");
					this.Descripcion.val("");
					this.Sentencia.val('').trigger("liszt:updated");
					this.Sumario.val('').trigger("liszt:updated");
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