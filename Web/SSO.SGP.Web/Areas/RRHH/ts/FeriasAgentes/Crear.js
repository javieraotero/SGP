/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var FeriasAgentes;
(function (FeriasAgentes) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Agente = $("#Agente" + hash);
                this.Feria = $("#Feria" + hash);
                this.Dias = $("#Dias" + hash);
                this.Desde1 = $("#Desde1" + hash);
                this.Desde2 = $("#Desde2" + hash);
                this.Desde3 = $("#Desde3" + hash);
                this.Hasta1 = $("#Hasta1" + hash);
                this.Hasta2 = $("#Hasta2" + hash);
                this.Hasta3 = $("#Hasta3" + hash);
                this.Instancia = $("#Instancia" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Agente.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Agente.val('').trigger("liszt:updated");
                this.Feria.val('').trigger("liszt:updated");
                this.Dias.val("");
                this.Desde1.val("");
                this.Desde2.val("");
                this.Desde3.val("");
                this.Hasta1.val("");
                this.Hasta2.val("");
                this.Hasta3.val("");
                this.Instancia.val("");
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
    })(ts = FeriasAgentes.ts || (FeriasAgentes.ts = {}));
})(FeriasAgentes || (FeriasAgentes = {})); // module
