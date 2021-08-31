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
        var EditarActuacion = (function () {
            //---  /Propiedades de Formulario --- //
            function EditarActuacion(hash) {
                this.form = $("#" + hash);
                //this.datatables = [];
                this.Id = $("#Id" + hash); 
                this.Descripcion = $("#Descripcion" + hash);
                this.Pedido = $("#Pedido" + hash);                            

                //operaciones                
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                //this.Id.focus();
            }
            EditarActuacion.prototype.limpiar = function () {
                this.Id.val("");
                this.Pedido.val("");
                //this.Organismo.val('').trigger("liszt:updated");
                //this.OrganismoDestino.val("");
                this.Descripcion.val("");
                //this.Numero.val("");
                //this.Activo.val("");
                
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
           /* EditarActuacion.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            EditarActuacion.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                   d.fnDraw();
               });
            };*/
            return EditarActuacion;
        }());
        ts.EditarActuacion = EditarActuacion; //JS
    })(ts = Solicitudes.ts || (Solicitudes.ts = {}));
})(Solicitudes || (Solicitudes = {})); // module
