/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Solicitudes;
(function (Solicitudes) {
    var ts;
    (function (ts) {
        var Recibir = (function () {
            //---  /Propiedades de Formulario --- //
            function Recibir(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);                
                this.OrganismoDestino = $("#OrganismoDestino" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Numero = $("#Numero" + hash);
                this.Activo = $("#Activo" + hash);                

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Recibir= $("#Recibir" + hash);
                //Establece el foco
                //this.Id.focus();
            }
            Recibir.prototype.limpiar = function () {
                this.Id.val("");
                this.Organismo.val('').trigger("liszt:updated");
                this.OrganismoDestino.val("");
                this.Descripcion.val("");
                this.Numero.val("");
                this.Activo.val("");
                
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Recibir.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Recibir.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Recibir;
        }());
        ts.Recibir = Recibir; //JS
    })(ts = Solicitudes.ts || (Solicitudes.ts = {}));
})(Solicitudes || (Solicitudes = {})); // module
