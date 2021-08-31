/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var Agentes;
(function (Agentes) {
    var ts;
    (function (ts) {
        var CrearMovimientoCesida = (function () {
            //---  /Propiedades de Formulario --- //		
            function CrearMovimientoCesida(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Agente = $("#Agente" + hash);
                this.Movimiento = $("#Movimiento" + hash);
                this.body_parametros = $("#body_parametros" + hash);
                this.row_parametros = $("#row_parametros" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Modal = new SyncroModal($("#ModalAgentes"));
            }
            CrearMovimientoCesida.prototype.limpiar = function () {
                this.Legajo.val("");
                this.Telefono.val("");
                this.Profesion.val("");
                this.EstudiosCursados.val("");
                this.AfiliadoISS.val("");
                this.FechaDeCasamiento.val("");
                this.Persona.val('').trigger("liszt:updated");
                this.NumeroPS.val("");
                this.Domicilio.val("");
                this.FechaUltimoAscenso.val("");
                this.UltimoCargo.val('').trigger("liszt:updated");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/	
            CrearMovimientoCesida.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            CrearMovimientoCesida.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return CrearMovimientoCesida;
        })();
        ts.CrearMovimientoCesida = CrearMovimientoCesida; //JS
    })(ts = Agentes.ts || (Agentes.ts = {}));
})(Agentes || (Agentes = {})); // module
