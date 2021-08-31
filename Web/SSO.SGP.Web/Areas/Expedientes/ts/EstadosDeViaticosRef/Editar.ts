/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module EstadosDeViaticosRef.ts {
	
	export class Editar implements IControlador {
		
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public Id:JQuery;
		public Descripcion:JQuery;
		public EditaOrganismo:JQuery;
		public EditaEconomia:JQuery;
		public Cancelar:JQuery;
		public Guardar:JQuery;
		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];
			this.Id = $('#Id'+hash);
			this.Descripcion = $('#Descripcion'+hash);
			this.EditaOrganismo = $('#EditaOrganismo'+hash);
			this.EditaEconomia = $('#EditaEconomia'+hash);
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);


			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    Id:{required:true, number:true, maxlength:4 },                
                    Descripcion:{required:true, number:false, maxlength:50 },                
                    EditaOrganismo:{required:true, number:false, maxlength:1 },                
                    EditaEconomia:{required:true, number:false, maxlength:1 },                },
                messages: {
 
                    Id: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 4 caracteres"}, 
                    Descripcion: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 50 caracteres"}, 
                    EditaOrganismo: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 1 caracteres"}, 
                    EditaEconomia: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 1 caracteres"},                }
            });

        }

		public limpiar() {
			this.Id.val("");
			this.Descripcion.val("");
			this.EditaOrganismo.removeAttr('checked');
			this.EditaEconomia.removeAttr('checked');
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