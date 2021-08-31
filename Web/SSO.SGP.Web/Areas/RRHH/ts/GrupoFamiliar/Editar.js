var GrupoFamiliar;
(function (GrupoFamiliar) {
    /// <reference path="../../ts/types/jquery.d.ts"/>
    /// <reference path="../../ts/IControlador.ts"/>
    /// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
    (function (ts) {
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.Id = $("#Id" + hash);
                this.Agente = $("#Agente" + hash);
                this.ApellidosYNombre = $("#ApellidosYNombre" + hash);
                this.FechaDeNacimiento = $("#FechaDeNacimiento" + hash);
                this.Documento = $("#Documento" + hash);
                this.TipoMiembro = $("#TipoMiembro" + hash);

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);

                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Agente.val("");
                this.ApellidosYNombre.val("");
                this.FechaDeNacimiento.val("");
                this.Documento.val("");
                this.TipoMiembro.val('').trigger("liszt:updated");
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
        ts.Editar = Editar;
    })(GrupoFamiliar.ts || (GrupoFamiliar.ts = {}));
    var ts = GrupoFamiliar.ts;
})(GrupoFamiliar || (GrupoFamiliar = {}));
