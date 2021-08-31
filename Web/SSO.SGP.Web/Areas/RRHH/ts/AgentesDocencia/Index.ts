
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>

module AgentesDocencia.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public AgentesDocencia:DataTables.DataTable;
		public AgentesDocencia_Id:number;
        public index: number;
		//---  /Propiedades de Formulario --- //
        public Nuevo: JQuery;
        public Agente: JQuery;


		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		
			//operaciones
            this.Nuevo = $("#Nuevo" + hash);
            this.Agente = $("#Agente" + hash);

		}
		
		public limpiar():void {
			
			this.AgentesDocencia.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setAgentesDocencia(dt: DataTables.DataTable):void {
            var that = this;
            this.AgentesDocencia = dt;

            $("#dtAgentesDocencia tbody").click(function (event) {
                $(that.AgentesDocencia.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
         
                var id = that.AgentesDocencia.fnGetData($(event.target).closest("tr").index())[0];
                that.AgentesDocencia_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }
		
		public getData(col: number): any {
            return (this.AgentesDocencia.fnGetData(this.index)[col]); 
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
