/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var EjecucionesPresupuestarias;
(function (EjecucionesPresupuestarias) {
    var ts;
    (function (ts) {
        var Index = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Anio = $("#Anio" + hash);
                this.Ver = $("#Ver" + hash);
                this.CrearAnual = $("#CrearPresupuesto" + hash);
                //operaciones
                //Establece el foco
                this.Anio.focus();
            }
            Index.prototype.limpiar = function () {
                this.EjecucionesPresupuestarias.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setEjecucionesPresupuestarias = function (dt) {
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
            };
            Index.prototype.getData = function (col) {
                return (this.EjecucionesPresupuestarias.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        }()); //JS
        ts.Index = Index;
    })(ts = EjecucionesPresupuestarias.ts || (EjecucionesPresupuestarias.ts = {}));
})(EjecucionesPresupuestarias || (EjecucionesPresupuestarias = {})); // module
