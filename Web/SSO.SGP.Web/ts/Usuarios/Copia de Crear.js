var Usuarios;
(function (Usuarios) {
    /// <reference path="../../ts/types/jquery.d.ts"/>
    /// <reference path="../../ts/IControlador.ts"/>
    /// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../ts/Syncro/SyncroModal.ts"/>
    (function (ts) {
        var CambiarClave = (function () {
            //---  /Propiedades de Formulario --- //
            function CambiarClave(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.NombrePersona = $("#NombrePersona" + hash);
                this.Documento = $("#Documento" + hash);
                this.Domicilio = $("#Domicilio" + hash);
                this.Telefono = $("#Telefono" + hash);
                this.Celular = $("#Celular" + hash);
                this.Email = $("#Email" + hash);

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);

                //Establece el foco
                this.NombrePersona.focus();
            }
            CambiarClave.prototype.limpiar = function () {
                this.NombrePersona.val("");
                this.Documento.val("");
                this.Domicilio.val("");
                this.Telefono.val("");
                this.Celular.val("");
                this.Email.val("");
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
        ts.CambiarClave = CambiarClave;
    })(Usuarios.ts || (Usuarios.ts = {}));
    var ts = Usuarios.ts;
})(Usuarios || (Usuarios = {}));
