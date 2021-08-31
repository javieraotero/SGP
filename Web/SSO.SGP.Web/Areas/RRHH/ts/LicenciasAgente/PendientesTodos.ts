/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>

module LicenciasAgente.ts {
	
	export class PendientesTodos implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public LicenciasAgente:DataTables.DataTable;
        public LicenciasAgente_Id: number;
        public index: number;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		
			//operaciones
			
		}
		
		public limpiar():void {
			
			this.LicenciasAgente.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setPendientesTodos(dt: DataTables.DataTable):void {
            var that = this;
            this.LicenciasAgente = dt;

            $("#dtPendientesTodos tbody").click(function (event) {
                $(that.LicenciasAgente.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = that.LicenciasAgente.fnGetData($(event.target).closest("tr").index())[0];
                that.LicenciasAgente_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }
		//--- /Funciones para seteo de Datatables ---/
		
		public fnRegistrarDataTable(d: DataTables.DataTable): void {
			this.datatables.push(d);
        }

        public getData(col: number): any {
            //var anSelected = app.fnGetSelected(this.Agentes);
            return (this.LicenciasAgente.fnGetData(this.index)[col]);
        }

        public selectRow_Licencia(event) {
            var self = this;
			$(self.LicenciasAgente.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
			var id = self.LicenciasAgente.fnGetData($(event).closest("tr").index())[0];
			self.LicenciasAgente_Id = id;
			self.index = $(event).closest("tr").index();
        }


		public fnRefrescarDataTables():void {
			var that = this;
			this.datatables.forEach(function (d) {
				d.fnDraw();
			});    
		}
	} //JS
} // module
