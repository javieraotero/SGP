
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module FeriasRef.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public Nuevo: JQuery;
        public Modal: SyncroModal;
        public index: number;
		
		 
		public FeriasRef:DataTables.DataTable;
		public FeriasRef_Id:number;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
            this.Nuevo = $("#Nuevo" + hash);
            this.Modal = new SyncroModal($("#ModalFerias" + hash));    		
			//operaciones			
		}
		
		public limpiar():void {
			
			this.FeriasRef.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setFeriasRef(dt: DataTables.DataTable):void {
            var that = this;
            this.FeriasRef = dt;

            $("#dtFeriasRef tbody").click(function (event) {
                $(that.FeriasRef.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');

                var id = that.FeriasRef.fnGetData($(event.target).closest("tr").index())[0]; // getting the value of the first (invisible) column
                that.FeriasRef_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }

        public getData(col: number): any {
            //var anSelected = app.fnGetSelected(this.Agentes);
            return (this.FeriasRef.fnGetData(this.index)[col]);
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
