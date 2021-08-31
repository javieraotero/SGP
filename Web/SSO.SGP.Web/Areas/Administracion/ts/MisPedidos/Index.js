/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var MisPedidos;
(function (MisPedidos) {
    var ts;
    (function (ts) {
        var Index = (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones			
            }
            Index.prototype.limpiar = function () {
                this.MisPedidos.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setMisPedidos = function (dt) {
                var that = this;
                this.MisPedidos = dt;
                //dt.fnSetColumnVis(0, false);
                //$(".dataTable tr > :nth-child(1)").hide();
                $("#dtMisPedidos tbody").click(function (event) {
                    console.log("click en la grilla");
                    $(that.MisPedidos.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.MisPedidos.fnGetData($(event.target).closest("tr").index())[0]; // getting the value of the first (invisible) column
                    that.MisPedidos_Id = id;
                    that.index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData = function (col) {
                //var anSelected = app.fnGetSelected(this.Agentes);
                return (this.MisPedidos.fnGetData(this.index)[col]);
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
        })();
        ts.Index = Index; //JS
    })(ts = MisPedidos.ts || (MisPedidos.ts = {}));
})(MisPedidos || (MisPedidos = {})); // module
