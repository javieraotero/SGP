var GrupoFamiliar;
(function (GrupoFamiliar) {
    /// <reference path="../../ts/types/jquery.d.ts"/>
    /// <reference path="../../ts/IControlador.ts"/>
    /// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.Agente = $("#Agente" + hash);
                this.ApellidosYNombre = $("#ApellidosYNombre" + hash);
                this.FechaDeNacimiento = $("#FechaDeNacimiento" + hash);
                this.Documento = $("#Documento" + hash);
                this.TipoMiembro = $("#TipoMiembro" + hash);

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);

                //Establece el foco
                this.Agente.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Agente.val("");
                this.ApellidosYNombre.val("");
                this.FechaDeNacimiento.val("");
                this.Documento.val("");
                this.TipoMiembro.val('').trigger("liszt:updated");
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
        ts.Crear = Crear;
    })(GrupoFamiliar.ts || (GrupoFamiliar.ts = {}));
    var ts = GrupoFamiliar.ts;
})(GrupoFamiliar || (GrupoFamiliar = {}));
