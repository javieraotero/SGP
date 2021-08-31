var LicenciasAgente;
(function (LicenciasAgente) {
    /// <reference path="../../../../ts/types/jquery.d.ts"/>
    /// <reference path="../../../../ts/IControlador.ts"/>
    /// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
    (function (ts) {
        var ResumenOrganizacion = (function () {
            //---  /Propiedades de Formulario --- //
            function ResumenOrganizacion(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Organismo = $("#OrganismoRef" + hash);
                this.Resultados = $("#Resultados" + hash);

                //operaciones
                this.Buscar = $("#Buscar" + hash);
            }
            ResumenOrganizacion.prototype.limpiar = function () {
            };

            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            ResumenOrganizacion.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };

            ResumenOrganizacion.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return ResumenOrganizacion;
        })();
        ts.ResumenOrganizacion = ResumenOrganizacion;
    })(LicenciasAgente.ts || (LicenciasAgente.ts = {}));
    var ts = LicenciasAgente.ts;
})(LicenciasAgente || (LicenciasAgente = {}));
