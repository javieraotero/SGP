/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module EjecucionesPresupuestarias.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public index: number;
		
		 
		public Anio:JQuery; 
		public Ver:JQuery; 
		public CrearAnual: JQuery;
		public EjecucionesPresupuestarias:DataTables.DataTable;
		public EjecucionesPresupuestarias_Id:number;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Anio = $("#Anio"+hash); 
			this.Ver = $("#Ver"+hash);
			this.CrearAnual = $("#CrearPresupuesto" + hash);
			//operaciones
			
			//Establece el foco
			this.Anio.focus();
		}
		
		public limpiar():void {
			this.EjecucionesPresupuestarias.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setEjecucionesPresupuestarias(dt: DataTables.DataTable):void {
            var that = this;
            this.EjecucionesPresupuestarias = dt;

            $("#dtEjecucionesPresupuestarias tbody").click(function (event) {
                $(that.EjecucionesPresupuestarias.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
         
                var id = that.EjecucionesPresupuestarias.fnGetData($(event.target).closest("tr").index())[0];
                that.EjecucionesPresupuestarias_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }
		
		public getData(col: number): any {
            return(this.EjecucionesPresupuestarias.fnGetData(this.index)[col]); 
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
