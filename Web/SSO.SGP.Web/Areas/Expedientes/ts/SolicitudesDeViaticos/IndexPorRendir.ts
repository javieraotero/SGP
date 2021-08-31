/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module SolicitudesDeViaticos.ts {
	
	export class IndexPorRendir implements IControlador {
		
        public hash: string;
		public form: JQuery;
		public datatables: DataTables.DataTable[];
        public SolicitudesDeViaticos: DataTables.DataTable;

        public SolicitudesDeViaticos_id: number;
        public SolicitudesDeViaticos_index: number;

        public Comisiones: DataTables.DataTable;
        public Comisiones_id: number;
        public Comisiones_index: number;
        public Agente: SyncroAutocomplete;
        public Destino: SyncroAutocomplete;
        public Oficina: SyncroAutocomplete;
        public Buscar: JQuery;

        public Anticipos: DataTables.DataTable;
        public Anticipos_id: number;
        public Anticipos_index: number;

        constructor(hash: string) {
            this.Destino = new SyncroAutocomplete("Destino" + hash, "Expedientes/MontosDeViaticos/JsonOptionsLocalidades");
            this.Agente = new SyncroAutocomplete("Agente" + hash, "RRHH/Agentes/GetJson");
            this.Buscar = $("#Buscar" + hash);
            //this.Oficina = new SyncroAutocomplete("Oficina" + hash, "RRHH/OrganismosRef/GetJson");
			this.form = $("#" + hash);
            this.datatables = [];
            this.hash = hash;

			this.validacion();
		}

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    SolicitudesDeViaticos:{required:true, number:false, maxlength:0 },                },
                messages: {
 
                    SolicitudesDeViaticos: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},                }
            });

        }

		public limpiar() {
		}

		public setSolicitudesDeViaticos(dt: DataTables.DataTable):void {
            var self = this;
            this.SolicitudesDeViaticos = dt;

            $("#dtSolicitudesDeViaticos"+self.hash+" tbody").click(function (event) {
                $(self.SolicitudesDeViaticos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticos.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticos_id = id;
                self.SolicitudesDeViaticos_index = $(event.target).closest("tr").index();
            });			
        }

        public setSolicitudesDeViaticosAnticipo(dt: DataTables.DataTable): void {
            var self = this;
            this.Anticipos = dt;

            $("#dtSolicitudesDeViaticosAnticipo tbody").click(function (event) {
                $(self.Anticipos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.Anticipos.fnGetData($(event.target).closest("tr").index())[0];
                self.Anticipos_id = id;
                self.Anticipos_index = $(event.target).closest("tr").index();
            });
        }

        public setSolicitudesDeViaticosReintegro(dt: DataTables.DataTable): void {
            var self = this;
            this.SolicitudesDeViaticos = dt;

            $("#dtSolicitudesDeViaticosReintegro tbody").click(function (event) {
                $(self.SolicitudesDeViaticos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticos.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticos_id = id;
                self.SolicitudesDeViaticos_index = $(event.target).closest("tr").index();
            });
        }

        public setComisiones(dt: DataTables.DataTable): void {
            var self = this;
            this.Comisiones = dt;

            $("#dtComisiones tbody").click(function (event) {
                $(self.Comisiones.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.Comisiones.fnGetData($(event.target).closest("tr").index())[0];
                self.Comisiones_id = id;
                self.Comisiones_index = $(event.target).closest("tr").index();
            });
        }
		
		public getData_SolicitudesDeViaticos(col: number): any {
            return(this.SolicitudesDeViaticos.fnGetData(this.SolicitudesDeViaticos_index)[col]); 
        }

        public getData_SolicitudesDeViaticosAnticipo(col: number): any {
            return (this.Anticipos.fnGetData(this.Anticipos_index)[col]);
        }

        public getData_Comisiones(col: number): any {
            return (this.Comisiones.fnGetData(this.Comisiones_index)[col]);
        }

		public selectRow_SolicitudesDeViaticos(event) {
            var self = this;
            $(self.SolicitudesDeViaticos.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.SolicitudesDeViaticos.fnGetData($(event).closest("tr").index())[0];
            self.SolicitudesDeViaticos_id = id;
            self.SolicitudesDeViaticos_index = $(event).closest("tr").index();
        }

        public selectRow_SolicitudesDeViaticosAnticipo(event) {
            var self = this;
            $(self.Anticipos.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.Anticipos.fnGetData($(event).closest("tr").index())[0];
            self.Anticipos_id = id;
            self.Anticipos_index = $(event).closest("tr").index();
        }

        public selectRow_Comisiones(event) {
            var self = this;
            $(self.Comisiones.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.Comisiones.fnGetData($(event).closest("tr").index())[0];
            self.Comisiones_id = id;
            self.Comisiones_index = $(event).closest("tr").index();
        }
		
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