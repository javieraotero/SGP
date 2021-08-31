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
        var Eliminar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Eliminar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombre = $("#Nombre" + hash);
                //operaciones
                //Establece el foco
                this.Id.focus();
            }
            Eliminar.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombre.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Eliminar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
            Eliminar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Eliminar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Eliminar;
        }()); //JS
        ts.Eliminar = Eliminar;
    })(ts = UnidadesDeOrganizacionRef.ts || (UnidadesDeOrganizacionRef.ts = {}));
})(UnidadesDeOrganizacionRef || (UnidadesDeOrganizacionRef = {})); // module
