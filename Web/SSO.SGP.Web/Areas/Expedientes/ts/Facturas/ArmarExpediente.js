/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var ArmarExpediente = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function ArmarExpediente(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.body_facturas = $("#body_facturas");
                this.body_partidas = $("#body_partidas");
                this.Guardar = $("#Guardar");
                //operaciones		
            }
            ArmarExpediente.prototype.refrescarFacturas = function () {
            };
            ArmarExpediente.prototype.limpiar = function () {
            };
            //--- Funciones para seteo de Datatables ---/
            //public getData(col: number): any {
            //          return(this.Agentes.fnGetData(this.index)[col]); 
            //      }
            //--- /Funciones para seteo de Datatables ---/
            ArmarExpediente.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            ArmarExpediente.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return ArmarExpediente;
        }()); //JS
        ts.ArmarExpediente = ArmarExpediente;
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
