/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
var Usuarios;
(function (Usuarios) {
    var ts;
    (function (ts) {
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.NombreUsuario = $("#NombreUsuario" + hash);
                this.NombrePersona = $("#NombrePersona" + hash);
                this.Documento = $("#Documento" + hash);
                this.Domicilio = $("#Domicilio" + hash);
                this.Telefono = $("#Telefono" + hash);
                this.Celular = $("#Celular" + hash);
                this.Email = $("#Email" + hash);
                this.Activo = $("#Activo" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.Resetear = $("#Resetear" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.NombreUsuario.val("");
                this.NombrePersona.val("");
                this.Documento.val("");
                this.Domicilio.val("");
                this.Telefono.val("");
                this.Celular.val("");
                this.Email.val("");
                this.Activo.val("");
                this.UsuarioAlta.val("");
                this.FechaAlta.val("");
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
    })(ts = Usuarios.ts || (Usuarios.ts = {}));
})(Usuarios || (Usuarios = {})); // module
