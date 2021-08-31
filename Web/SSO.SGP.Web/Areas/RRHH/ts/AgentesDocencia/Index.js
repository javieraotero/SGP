/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var AgentesDocencia;
(function (AgentesDocencia) {
    var ts;
    (function (ts) {
        var Index = (function () {
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //operaciones
                this.Nuevo = $("#Nuevo" + hash);
                this.Agente = $("#Agente" + hash);
            }
            Index.prototype.limpiar = function () {
                this.AgentesDocencia.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setAgentesDocencia = function (dt) {
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
            };
            Index.prototype.getData = function (col) {
                return (this.AgentesDocencia.fnGetData(this.index)[col]);
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
    })(ts = AgentesDocencia.ts || (AgentesDocencia.ts = {}));
})(AgentesDocencia || (AgentesDocencia = {})); // module
