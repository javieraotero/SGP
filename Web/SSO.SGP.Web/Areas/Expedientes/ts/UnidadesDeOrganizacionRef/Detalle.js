/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var UnidadesDeOrganizacionRef;
(function (UnidadesDeOrganizacionRef) {
    var ts;
    (function (ts) {
        var Detalle = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Detalle(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombre = $("#Nombre" + hash);
                //operaciones
                //Establece el foco
                this.Id.focus();
            }
            Detalle.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombre.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Detalle.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Detalle.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Detalle.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Detalle;
        }()); //JS
        ts.Detalle = Detalle;
    })(ts = UnidadesDeOrganizacionRef.ts || (UnidadesDeOrganizacionRef.ts = {}));
})(UnidadesDeOrganizacionRef || (UnidadesDeOrganizacionRef = {})); // module
