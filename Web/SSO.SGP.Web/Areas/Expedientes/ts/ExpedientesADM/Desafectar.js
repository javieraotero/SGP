/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var Desafectar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Desafectar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.UnidadOrganizacion = $("#UnidadDeOrganizacionRef" + hash);
                this.Partidas = $("#body_partidas" + hash);
                this.spFactura = $("#spFactura" + hash);
                this.spImporte = $("#spImporte" + hash);
                this.Id = $("#Id" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.ModificarCompromiso = $("#modificarcompromiso" + hash);
                //operaciones
                //Establece el foco
                this.UnidadOrganizacion.focus();
            }
            Desafectar.prototype.limpiar = function () {
                this.UnidadOrganizacion.val('').trigger("liszt:updated");
                //this.Partidas.limpiar();
            };
            //--- Funciones para seteo de Datatables ---/
            //public getData(col: number): any {
            //          return(this.Agentes.fnGetData(this.index)[col]); 
            //      }
            //--- /Funciones para seteo de Datatables ---/
            Desafectar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Desafectar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Desafectar;
        }()); //JS
        ts.Desafectar = Desafectar;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
