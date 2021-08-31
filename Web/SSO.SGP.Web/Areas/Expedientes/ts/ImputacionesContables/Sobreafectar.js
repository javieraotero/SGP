/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var ImputacionesContables;
(function (ImputacionesContables) {
    var ts;
    (function (ts) {
        var Sobreafectar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Sobreafectar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.UnidadOrganizacion = $("#UnidadDeOrganizacionRef" + hash);
                this.Partidas = $("#body_partidas" + hash);
                this.spFactura = $("#spFactura" + hash);
                this.spImporte = $("#spImporte" + hash);
                this.Id = $("#Id" + hash);
                this.Guardar = $("#Guardar" + hash);
                //operaciones
                //Establece el foco
                this.UnidadOrganizacion.focus();
            }
            Sobreafectar.prototype.limpiar = function () {
                this.UnidadOrganizacion.val('').trigger("liszt:updated");
                //this.Partidas.limpiar();
            };
            //--- Funciones para seteo de Datatables ---/
            //public getData(col: number): any {
            //          return(this.Agentes.fnGetData(this.index)[col]); 
            //      }
            //--- /Funciones para seteo de Datatables ---/
            Sobreafectar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Sobreafectar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Sobreafectar;
        }()); //JS
        ts.Sobreafectar = Sobreafectar;
    })(ts = ImputacionesContables.ts || (ImputacionesContables.ts = {}));
})(ImputacionesContables || (ImputacionesContables = {})); // module
