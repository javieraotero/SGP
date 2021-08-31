/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
var Usuarios;
(function (Usuarios) {
    var ts;
    (function (ts) {
        var CambiarClave = (function () {
            //---  /Propiedades de Formulario --- //
            function CambiarClave(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.ClaveActual = $("#ClaveActual" + hash);
                this.ClaveNueva = $("#ClaveNueva" + hash);
                this.ReClaveNueva = $("#ReClaveNueva" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.ClaveActual.focus();
            }
            CambiarClave.prototype.limpiar = function () {
                this.ClaveActual.val("");
                this.ClaveNueva.val("");
                this.ReClaveNueva.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            CambiarClave.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            CambiarClave.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return CambiarClave;
        })();
        ts.CambiarClave = CambiarClave; //JS
    })(ts = Usuarios.ts || (Usuarios.ts = {}));
})(Usuarios || (Usuarios = {})); // module
