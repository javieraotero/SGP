/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
var LicenciasAgente;
(function (LicenciasAgente) {
    var ts;
    (function (ts) {
        var Limitar = (function () {
            //---  /Propiedades de Formulario --- //
            function Limitar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.FechaBaja = $("#FechaBaja" + hash);
                //operaciones
                this.Guardar = $("#Guardar" + hash);
                this.Cancelar = $("#Cancelar" + hash);
                //Establece el foco
                this.FechaBaja.focus();
            }
            Limitar.prototype.limpiar = function () {
                this.FechaBaja.val("");
            };
            Limitar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Limitar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Limitar;
        })();
        ts.Limitar = Limitar; //JS
    })(ts = LicenciasAgente.ts || (LicenciasAgente.ts = {}));
})(LicenciasAgente || (LicenciasAgente = {})); // module
