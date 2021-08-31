/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
var Usuarios;
(function (Usuarios) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.ApellidoYNombre = $("#ApellidoYNombre" + hash);
                this.Usuario = $("#Usuario" + hash);
                this.Correo = $("#Correo" + hash);
                this.Estado = $("#Estado" + hash);
                this.Organismo = $("#OrganismoUltimoIngreso" + hash);
                this.Cargo = $("#Cargo" + hash);
                this.Circunscripcion = $("#Circunscripcion" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.BuscarPersona = $("#BuscarPersona" + hash);
                this.Detalle = $("#DetalleAgente");
                this.IdPersona = $("#Persona" + hash);
                this.spDetalle = $("#detalle");
                this.Persona = $("#Persona" + hash);
                //Establece el foco
                this.ApellidoYNombre.focus();
            }
            Crear.prototype.limpiar = function () {
                this.ApellidoYNombre.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        })();
        ts.Crear = Crear; //JS
    })(ts = Usuarios.ts || (Usuarios.ts = {}));
})(Usuarios || (Usuarios = {})); // module
