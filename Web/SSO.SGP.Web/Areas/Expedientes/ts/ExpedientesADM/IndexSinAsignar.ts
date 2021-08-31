/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module ExpedientesADM.ts {
	
	export class IndexSinAsignar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public index: number;
        public index_multi: Array<number>;
		
		 
		public ExpedientesADM:DataTables.DataTable;
        public ExpedientesADM_Id: number;
        public ExpedientesADM_Id_multi: Array<number>;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
            this.datatables = [];
            this.index_multi = [];		
            this.ExpedientesADM_Id_multi = [];
			//operaciones			
		}
		
		public limpiar():void {			
			this.ExpedientesADM.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setExpedientesADM(dt: DataTables.DataTable):void {
            var that = this;
            this.ExpedientesADM = dt;

            $("#dtExpedientesSinAsignar tbody").click(function (event) {
                $(that.ExpedientesADM.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
         
                var id = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[0];
                that.ExpedientesADM_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }

        public setExpedientesADMMulti(dt: DataTables.DataTable, id: string): void {
            var that = this;
            this.ExpedientesADM = dt;

            $("#" + id + " tbody").click(function (event) {
                //$(that.ExpedientesADM.fnSettings().aoData).each(function () {
                //    $(this.nTr).removeClass('row_selected');
                //});
                that.index = $(event.target).closest("tr").index();
                if (Enumerable.From(that.index_multi).Where(function (x) { return x == that.index }).Count() == 0) {
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[0];
                    that.ExpedientesADM_Id = id;

                    that.index_multi.push(that.index);
                    that.ExpedientesADM_Id_multi.push(that.ExpedientesADM_Id);
                } else {
                    $(event.target).closest("tr").removeClass('row_selected');                    
                }

            });
        }
		
		public getData(col: number): any {
            return(this.ExpedientesADM.fnGetData(this.index)[col]); 
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
