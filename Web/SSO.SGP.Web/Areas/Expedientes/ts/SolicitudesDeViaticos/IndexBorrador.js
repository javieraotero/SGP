/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var SolicitudesDeViaticos;
(function (SolicitudesDeViaticos) {
    var ts;
    (function (ts) {
        var IndexBorrador = /** @class */ (function () {
            function IndexBorrador(hash) {
                this.Destino = new SyncroAutocomplete("Destino" + hash, "Expedientes/MontosDeViaticos/JsonOptionsLocalidades");
                this.Agente = new SyncroAutocomplete("Agente" + hash, "RRHH/Agentes/GetJson");
                this.Buscar = $("#Buscar" + hash);
                //this.Oficina = new SyncroAutocomplete("Oficina" + hash, "RRHH/OrganismosRef/GetJson");
                this.form = $("#" + hash);
                this.datatables = [];
                this.hash = hash;
                this.validacion();
            }
            IndexBorrador.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        SolicitudesDeViaticos: { required: true, number: false, maxlength: 0 },
                    },
                    messages: {
                        SolicitudesDeViaticos: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 0 caracteres" },
                    }
                });
            };
            IndexBorrador.prototype.limpiar = function () {
            };
            IndexBorrador.prototype.setSolicitudesDeViaticos = function (dt) {
                var self = this;
                this.SolicitudesDeViaticos = dt;
                $("#dtSolicitudesDeViaticos" + self.hash + " tbody").click(function (event) {
                    $(self.SolicitudesDeViaticos.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.SolicitudesDeViaticos.fnGetData($(event.target).closest("tr").index())[0];
                    self.SolicitudesDeViaticos_id = id;
                    self.SolicitudesDeViaticos_index = $(event.target).closest("tr").index();
                });
            };
            IndexBorrador.prototype.setSolicitudesDeViaticosAnticipo = function (dt) {
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
            };
            IndexBorrador.prototype.setSolicitudesDeViaticosReintegro = function (dt) {
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
            };
            IndexBorrador.prototype.setComisiones = function (dt) {
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
            };
            IndexBorrador.prototype.getData_SolicitudesDeViaticos = function (col) {
                return (this.SolicitudesDeViaticos.fnGetData(this.SolicitudesDeViaticos_index)[col]);
            };
            IndexBorrador.prototype.getData_SolicitudesDeViaticosAnticipo = function (col) {
                return (this.Anticipos.fnGetData(this.Anticipos_index)[col]);
            };
            IndexBorrador.prototype.getData_Comisiones = function (col) {
                return (this.Comisiones.fnGetData(this.Comisiones_index)[col]);
            };
            IndexBorrador.prototype.selectRow_SolicitudesDeViaticos = function (event) {
                var self = this;
                $(self.SolicitudesDeViaticos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticos.fnGetData($(event).closest("tr").index())[0];
                self.SolicitudesDeViaticos_id = id;
                self.SolicitudesDeViaticos_index = $(event).closest("tr").index();
            };
            IndexBorrador.prototype.selectRow_SolicitudesDeViaticosAnticipo = function (event) {
                var self = this;
                $(self.Anticipos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.Anticipos.fnGetData($(event).closest("tr").index())[0];
                self.Anticipos_id = id;
                self.Anticipos_index = $(event).closest("tr").index();
            };
            IndexBorrador.prototype.selectRow_Comisiones = function (event) {
                var self = this;
                $(self.Comisiones.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.Comisiones.fnGetData($(event).closest("tr").index())[0];
                self.Comisiones_id = id;
                self.Comisiones_index = $(event).closest("tr").index();
            };
            IndexBorrador.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            IndexBorrador.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return IndexBorrador;
        }()); //JS
        ts.IndexBorrador = IndexBorrador;
    })(ts = SolicitudesDeViaticos.ts || (SolicitudesDeViaticos.ts = {}));
})(SolicitudesDeViaticos || (SolicitudesDeViaticos = {})); // module
