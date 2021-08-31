/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var CargosRef;
(function (CargosRef) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Descripcion = $("#Descripcion" + hash);
                this.Grupo = $("#Grupo" + hash);
                this.Orden = $("#Orden" + hash);
                this.CodigoRRHH = $("#CodigoRRHH" + hash);
                this.Presupuesto = $("#Presupuesto" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Descripcion.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Descripcion.val("");
                this.Grupo.val('').trigger("liszt:updated");
                this.Orden.val("");
                this.CodigoRRHH.val("");
                this.Presupuesto.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        })();
        ts.Crear = Crear; //JS
    })(ts = CargosRef.ts || (CargosRef.ts = {}));
})(CargosRef || (CargosRef = {})); // module
