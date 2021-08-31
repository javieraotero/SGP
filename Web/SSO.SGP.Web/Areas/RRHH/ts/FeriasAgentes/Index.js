/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../ts/Syncro/SyncroAutocomplete.ts"/>
var FeriasAgentes;
(function (FeriasAgentes) {
    var ts;
    (function (ts) {
        var Index = (function () {
            //---  /Propiedades de Formulario --- //
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Organismo = new SyncroAutocomplete("Organismo" + hash, "Agentes/OrganismosJson");
                this.Feria_Id = $("#Feria" + hash).val();
                this.Desde = $("#Desde" + hash).val();
                this.Hasta = $("#Hasta" + hash).val();
                //operaciones
                this.Guardar = $("input[data-tipo=guardar]");
                this.Instancia = $("#Paso" + hash);
            }
            Index.prototype.limpiar = function () {
                this.FeriasAgentes.fnDraw();
            };
            //--- Funciones para seteo de Datatables ---/
            Index.prototype.setFeriasAgentes = function (dt) {
                var that = this;
                this.FeriasAgentes = dt;
                $("#dtFeriasAgentes tbody").click(function (event) {
                    $(that.FeriasAgentes.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var anSelected = app.fnGetSelected(that.FeriasAgentes);
                    that.FeriasAgentes_Id = anSelected[0].cells[0].textContent;
                });
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
    })(ts = FeriasAgentes.ts || (FeriasAgentes.ts = {}));
})(FeriasAgentes || (FeriasAgentes = {})); // module
