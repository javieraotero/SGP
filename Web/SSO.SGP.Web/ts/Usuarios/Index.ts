
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
module Usuarios.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public modal: SyncroModal; 
		
		 
		public Usuarios:DataTables.DataTable;
        public Usuarios_Id: number;
        public index: number;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
            this.modal = new SyncroModal($("#modalUsuarios" + hash));
		
			//operaciones
			
		}
		
		public limpiar():void {
			
			this.Usuarios.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
        public setUsuarios(dt: DataTables.DataTable): void {
            var that = this;
            this.Usuarios = dt;
            //dt.fnSetColumnVis(0, false);
            //$(".dataTable tr > :nth-child(1)").hide();

            $("#dtUsuarios tbody").click(function (event) {
                $(that.Usuarios.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');

                var id = that.Usuarios.fnGetData($(event.target).closest("tr").index())[0]; // getting the value of the first (invisible) column
                that.Usuarios_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }

        public getData(col: number): any {
            //var anSelected = app.fnGetSelected(this.Agentes);
            return (this.Usuarios.fnGetData(this.index)[col]);
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
