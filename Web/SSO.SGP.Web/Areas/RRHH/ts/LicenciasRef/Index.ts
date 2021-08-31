
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module LicenciasRef.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
        public modal: SyncroModal; 
        public Nuevo: JQuery;
        public index: number;
		 
		public LicenciasRef:DataTables.DataTable;
		public LicenciasRef_Id:number;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			this.modal = new SyncroModal($("#ModalIndexLicenciasRef"+hash));
            this.Nuevo = $("#Nuevo" + hash);
			//operaciones
			
		}
		
		public limpiar():void {
			
			this.LicenciasRef.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setLicenciasRef(dt: DataTables.DataTable):void {
            var that = this;
            this.LicenciasRef = dt;

            $("#dtLicenciasRef tbody").click(function (event) {
                $(that.LicenciasRef.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');

                var id = that.LicenciasRef.fnGetData($(event.target).closest("tr").index())[0]; // getting the value of the first (invisible) column
                that.LicenciasRef_Id = id;
                that.index = $(event.target).closest("tr").index();
            });
        }

        public getData(col: number): any {
            return (this.LicenciasRef.fnGetData(this.index)[col]);
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
