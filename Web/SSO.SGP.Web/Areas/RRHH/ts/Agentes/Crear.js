/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Agentes;
(function (Agentes) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                var that = this;
                this.form = $("#" + hash);
                this.datatables = [];
                this.Legajo = $("#Legajo" + hash);
                this.Telefono = $("#Telefono" + hash);
                this.Profesion = $("#Profesion" + hash);
                this.EstudiosCursados = $("#EstudiosCursados" + hash);
                this.AfiliadoISS = $("#AfiliadoISS" + hash);
                this.FechaDeCasamiento = $("#FechaDeCasamiento" + hash);
                this.Persona = $("#BuscarPersona" + hash);
                this.NumeroPS = $("#NumeroPS" + hash);
                this.Domicilio = $("#Domicilio" + hash);
                this.FechaUltimoAscenso = $("#FechaUltimoAscenso" + hash);
                this.UltimoCargo = $("#UltimoCargo" + hash);
                this.DetalleAgente = $("#DetalleAgente");
                this.detalle = $("#detalle");
                this.PersonaId = $("#Persona");
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Modal = new SyncroModal($("#ModalAgentes"));
                //Establece el foco
                this.Legajo.focus();
            }
            Crear.prototype.limpiar = function () {
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
    })(ts = Agentes.ts || (Agentes.ts = {}));
})(Agentes || (Agentes = {})); // module
