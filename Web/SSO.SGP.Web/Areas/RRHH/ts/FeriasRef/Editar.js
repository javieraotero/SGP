/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var FeriasRef;
(function (FeriasRef) {
    var ts;
    (function (ts) {
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.FechaDesde = $("#FechaDesde" + hash);
                this.FechaHasta = $("#FechaHasta" + hash);
                this.Anio = $("#Anio" + hash);
                this.DiaDesde = $("#DiaDesde" + hash);
                this.MesDesde = $("#MesDesde" + hash);
                this.DiaHasta = $("#DiaHasta" + hash);
                this.MesHasta = $("#MesHasta" + hash);
                this.Paso1 = $("#Paso1" + hash);
                this.Paso2 = $("#Paso2" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Descripcion.val("");
                this.FechaDesde.val("");
                this.FechaHasta.val("");
                this.Anio.val("");
                this.DiaDesde.val("");
                this.MesDesde.val("");
                this.DiaHasta.val("");
                this.MesHasta.val("");
                this.Paso1.removeAttr('checked');
                this.Paso2.removeAttr('checked');
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        })();
        ts.Editar = Editar; //JS
    })(ts = FeriasRef.ts || (FeriasRef.ts = {}));
})(FeriasRef || (FeriasRef = {})); // module
