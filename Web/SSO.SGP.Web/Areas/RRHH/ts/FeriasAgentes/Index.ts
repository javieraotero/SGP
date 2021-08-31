
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../ts/Syncro/SyncroAutocomplete.ts"/>
module FeriasAgentes.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public FeriasAgentes:DataTables.DataTable;
        public FeriasAgentes_Id: number;
        public Organismo: SyncroAutocomplete;
        public Guardar: JQuery;
        public Feria_Id: number;
        public Desde: string;
        public Hasta: string;
        public Instancia: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
            this.Organismo = new SyncroAutocomplete("Organismo" + hash, "Agentes/OrganismosJson");
            this.Feria_Id = $("#Feria" + hash).val();
            this.Desde = $("#Desde" + hash).val();
            this.Hasta = $("#Hasta" + hash).val();
            //operaciones
            this.Guardar = $("input[data-tipo=guardar]");
            this.Instancia = $("#Paso" + hash);
		}
		
		public limpiar():void {
			
			this.FeriasAgentes.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setFeriasAgentes(dt: DataTables.DataTable):void {
            var that = this;
            this.FeriasAgentes = dt;

            $("#dtFeriasAgentes tbody").click(function (event) {
                $(that.FeriasAgentes.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var anSelected = app.fnGetSelected(that.FeriasAgentes);
                that.FeriasAgentes_Id = anSelected[0].cells[0].textContent;
            });
        }
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
