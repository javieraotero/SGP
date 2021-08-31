/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
var Usuarios;
(function (Usuarios) {
    var ts;
    (function (ts) {
        var InformarIncidencia = (function () {
            //---  /Propiedades de Formulario --- //
            function InformarIncidencia(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Titulo = $("#Titulo");
                this.Descripcion = $("#Descripcion");
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Titulo.focus();
            }
            InformarIncidencia.prototype.limpiar = function () {
                this.Titulo.val("");
                this.Descripcion.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            InformarIncidencia.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            InformarIncidencia.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return InformarIncidencia;
        })();
        ts.InformarIncidencia = InformarIncidencia; //JS
    })(ts = Usuarios.ts || (Usuarios.ts = {}));
})(Usuarios || (Usuarios = {})); // module
