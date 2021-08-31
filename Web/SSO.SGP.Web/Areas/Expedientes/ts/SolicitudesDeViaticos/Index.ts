/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module SolicitudesDeViaticos.ts {
	
	export class Index implements IControlador {
		
        public hash: string;
		public form: JQuery;
		public datatables: DataTables.DataTable[];
        public SolicitudesDeViaticos: DataTables.DataTable;
        public SolicitudesDeViaticosBorrador: DataTables.DataTable;
        public SolicitudesDeViaticosPendientes: DataTables.DataTable;
        public SolicitudesDeViaticosPorRendir: DataTables.DataTable;
        public SolicitudesDeViaticosReintegro: DataTables.DataTable;
        public SolicitudesDeViaticosControlarRendicion: DataTables.DataTable;

        public SolicitudesDeViaticos_id: number;
        public SolicitudesDeViaticos_index: number;

        public SolicitudesDeViaticosBorrador_id: number;
        public SolicitudesDeViaticosBorrador_index: number;

        public SolicitudesDeViaticosPendientes_id: number;
        public SolicitudesDeViaticosPendientes_index: number

        public SolicitudesDeViaticosPorRendir_id: number;
        public SolicitudesDeViaticosPorRendir_index: number;

        public SolicitudesDeViaticosReintegro_id: number;
        public SolicitudesDeViaticosReintegro_index: number;

        public SolicitudesDeViaticosControlarRendicion_id: number;
        public SolicitudesDeViaticosControlarRendicion_index: number;

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

        public setSolicitudesDeViaticosControlarRendicion(dt: DataTables.DataTable): void {
            var self = this;
            this.SolicitudesDeViaticosControlarRendicion = dt;

            $("#dtSolicitudesDeViaticosControlarRendicion tbody").click(function (event) {
                $(self.SolicitudesDeViaticosControlarRendicion.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosControlarRendicion.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticosControlarRendicion_id = id;
                self.SolicitudesDeViaticosControlarRendicion_index = $(event.target).closest("tr").index();
            });
        }

        public setSolicitudesDeViaticosBorrador(dt: DataTables.DataTable): void {
            var self = this;
            this.SolicitudesDeViaticosBorrador = dt;

            $("#dtSolicitudesDeViaticos" + self.hash + " tbody").click(function (event) {
                $(self.SolicitudesDeViaticosBorrador.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosBorrador.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticosBorrador_id = id;
                self.SolicitudesDeViaticosBorrador_index = $(event.target).closest("tr").index();
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
            this.SolicitudesDeViaticosReintegro = dt;

            $("#dtSolicitudesDeViaticosReintegro tbody").click(function (event) {
                $(self.SolicitudesDeViaticosReintegro.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosReintegro.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticosReintegro_id = id;
                self.SolicitudesDeViaticosReintegro_index = $(event.target).closest("tr").index();
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

        public getData_SolicitudesDeViaticosControlarRendicion(col: number): any {
            return (this.SolicitudesDeViaticosControlarRendicion.fnGetData(this.SolicitudesDeViaticosControlarRendicion_index)[col]);
        }

        public getData_SolicitudesDeViaticosBorrador(col: number): any {
            return (this.SolicitudesDeViaticosBorrador.fnGetData(this.SolicitudesDeViaticosBorrador_index)[col]);
        }

        public getData_SolicitudesDeViaticosAnticipo(col: number): any {
            return (this.Anticipos.fnGetData(this.Anticipos_index)[col]);
        }

        public getData_SolicitudesDeViaticosReintegro(col: number): any {
            return (this.SolicitudesDeViaticosReintegro.fnGetData(this.SolicitudesDeViaticosReintegro_index)[col]);
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

        public selectRow_SolicitudesDeViaticosControlarRendicion(event) {
            var self = this;
            $(self.SolicitudesDeViaticosControlarRendicion.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.SolicitudesDeViaticosControlarRendicion.fnGetData($(event).closest("tr").index())[0];
            self.SolicitudesDeViaticosControlarRendicion_id = id;
            self.SolicitudesDeViaticosControlarRendicion_index = $(event).closest("tr").index();
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

        public selectRow_SolicitudesDeViaticosReintegro(event) {
            var self = this;
            $(self.SolicitudesDeViaticosReintegro.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.SolicitudesDeViaticosReintegro.fnGetData($(event).closest("tr").index())[0];
            self.SolicitudesDeViaticosReintegro_id = id;
            self.SolicitudesDeViaticosReintegro_index = $(event).closest("tr").index();
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