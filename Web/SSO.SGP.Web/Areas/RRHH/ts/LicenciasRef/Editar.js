var LicenciasRef;
(function (LicenciasRef) {
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
                this.Descripcion = $("#Descripcion" + hash);
                this.PorAnio = $("#PorAnio" + hash);
                this.PorLicencia = $("#PorLicencia" + hash);
                this.Observaciones = $("#Observaciones" + hash);
                this.DiasAcumulables = $("#DiasAcumulables" + hash);
                this.CodigoRRHH = $("#CodigoRRHH" + hash);

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);

                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Descripcion.val("");
                this.PorAnio.val("");
                this.PorLicencia.val("");
                this.Observaciones.val("");
                this.DiasAcumulables.removeAttr('checked');
                this.CodigoRRHH.val("");
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
    })(LicenciasRef.ts || (LicenciasRef.ts = {}));
    var ts = LicenciasRef.ts;
})(LicenciasRef || (LicenciasRef = {}));
