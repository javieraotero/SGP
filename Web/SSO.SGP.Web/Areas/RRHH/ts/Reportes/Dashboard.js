var Reportes;
(function (Reportes) {
    /// <reference path="../../../../ts/types/jquery.d.ts"/>
    /// <reference path="../../../../ts/IControlador.ts"/>
    /// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
    (function (ts) {
        var Dashborad = (function () {
            //---  /Propiedades de Formulario --- //
            function Dashborad(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.TotalNombramientos = $("#TotalNombramientos");
                this.TotalLicencias = $("#TotalLicencias");
                this.TotalPlanta = $("#TotalPlanta");
                this.TotalContratado = $("#TotalContratado");
                this.TotalBaja = $("#TotalBaja");
            }
            Dashborad.prototype.limpiar = function () {
            };

            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Dashborad.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };

            Dashborad.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Dashborad;
        })();
        ts.Dashborad = Dashborad;
    })(Reportes.ts || (Reportes.ts = {}));
    var ts = Reportes.ts;
})(Reportes || (Reportes = {}));
