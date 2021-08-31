/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var Agentes;
(function (Agentes) {
    var ts;
    (function (ts) {
        var IndexBonificaciones = (function () {
            //---  /Propiedades de Formulario --- //
            function IndexBonificaciones(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones			
            }
            IndexBonificaciones.prototype.limpiar = function () {
                this.Agentes.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            IndexBonificaciones.prototype.setBonificaciones = function (dt) {
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
            };
            IndexBonificaciones.prototype.getData = function (col) {
                //var anSelected = app.fnGetSelected(this.Agentes);
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            IndexBonificaciones.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            IndexBonificaciones.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return IndexBonificaciones;
        })();
        ts.IndexBonificaciones = IndexBonificaciones; //JS
    })(ts = Agentes.ts || (Agentes.ts = {}));
})(Agentes || (Agentes = {})); // module
