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
        var Eliminar = (function () {
            //---  /Propiedades de Formulario --- //
            function Eliminar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.OrganismoDestino = $("#OrganismoDestino" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Numero = $("#Numero" + hash);
                this.Activo = $("#Activo" + hash);
                //operaciones
                //Establece el foco
                //this.Id.focus();

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Eliminar = $("#Eliminar" + hash);
            }
            Eliminar.prototype.limpiar = function () {
                this.Organismo.val('').trigger("liszt:updated");
                this.OrganismoDestino.val("");
                this.Descripcion.val("");
                this.Numero.val("");
                this.Activo.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Eliminar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Eliminar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Eliminar;
        }());
        ts.Eliminar = Eliminar; //JS
    })(ts = MisPedidos.ts || (MisPedidos.ts = {}));
})(MisPedidos || (MisPedidos = {})); // module
