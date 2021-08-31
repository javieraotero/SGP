/// <reference path="../../../../ts/types/chosen.jquery.d.ts" />
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
module ConcursosDeIngreso.ts {

	export class EnviarNotificaciones implements IControlador {

		public form: JQuery;
		public datatables: DataTables.DataTable[];
		public Titulo: JQuery;
		public Mensaje: JQuery;	
		public Cancelar: JQuery;
		public Enviar: JQuery;

		constructor(hash: string) {
			this.form = $("#" + hash);
			this.datatables = [];
            this.Titulo = $("#Titulo" + hash);
            this.Mensaje = $("#Mensaje" + hash);
			this.Cancelar = $("#Cancelar" + hash);
			this.Enviar = $("#Enviar" + hash);


			// this.validacion();
		}

		//public validacion() {
		//	this.form.validate({
		//		errorClass: "field-validation-error",
		//		rules: {

		//			Titulo: { required: true, number: false, maxlength: 150 },

		//			//Mensaje: { required: true, number: false }

				
		//		},
		//		messages: {

		//			Titulo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },

		//			//Mensaje: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8000 caracteres" }		
		//		}
		//	});

		//}

		public limpiar() {
			this.Titulo.val("");
			this.Mensaje.val("");
			
		}


		public fnRegistrarDataTable(d: DataTables.DataTable): void {
			this.datatables.push(d);
		}

		public fnRefrescarDataTables(): void {
			var that = this;
			this.datatables.forEach(function (d) {
				d.fnDraw();
			});
		}
	} //JS
} // module