/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
var Usuarios;
(function (Usuarios) {
    var ts;
    (function (ts) {
        var EditarRoles = (function () {
            //---  /Propiedades de Formulario --- //
            function EditarRoles(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.modal = new SyncroModal($("#ModalEditarRolesUsuarios" + hash));
                this.IdUsuario = $("#IdUsuario" + hash);
                this.Roles = $("#Roles" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                //Establece el foco
                this.IdUsuario.focus();
            }
            EditarRoles.prototype.limpiar = function () {
                this.IdUsuario.val("");
                this.Roles.removeAttr('checked');
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            EditarRoles.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            EditarRoles.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return EditarRoles;
        })();
        ts.EditarRoles = EditarRoles; //JS
    })(ts = Usuarios.ts || (Usuarios.ts = {}));
})(Usuarios || (Usuarios = {})); // module
