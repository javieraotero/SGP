/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module Agentes.ts {
	
	export class IndexBonificaciones implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Agentes:DataTables.DataTable;
        public Agentes_Id: number;
        public index: number;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
					
			//operaciones			
		}
		
		public limpiar():void {
			
			this.Agentes.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setBonificaciones(dt: DataTables.DataTable):void {
            var that = this;
            this.Agentes = dt;
            //dt.fnSetColumnVis(0, false);
            //$(".dataTable tr > :nth-child(1)").hide();

            $("#dtBonificaciones tbody").click(function (event) {
                console.log("click en la grilla");
                $(that.Agentes.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
         
                var id = that.Agentes.fnGetData($(event.target).closest("tr").index())[0]; // getting the value of the first (invisible) column
                that.Agentes_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }

        public getData(col: number): any {
            //var anSelected = app.fnGetSelected(this.Agentes);
            return(this.Agentes.fnGetData(this.index)[col]); 
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
