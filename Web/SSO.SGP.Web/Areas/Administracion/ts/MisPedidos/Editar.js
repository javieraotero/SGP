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
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);                
                this.OrganismoDestino = $("#OrganismoDestino" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Numero = $("#Numero" + hash);
                this.Activo = $("#Activo" + hash);                

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);

                this.Detalle = new SyncroTable($("#Detalle"));
                //Establece el foco
                //this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Organismo.val('').trigger("liszt:updated");
                this.OrganismoDestino.val("");
                this.Descripcion.val("");
                this.Numero.val("");
                this.Activo.val("");
                
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
        }());
        ts.Editar = Editar; //JS
    })(ts = MisPedidos.ts || (MisPedidos.ts = {}));
})(MisPedidos || (MisPedidos = {})); // module
