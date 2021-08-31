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
        var Eliminar = (function () {
            //---  /Propiedades de Formulario --- //
            function Eliminar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Legajo = $("#Legajo" + hash);
                this.Telefono = $("#Telefono" + hash);
                this.Profesion = $("#Profesion" + hash);
                this.EstudiosCursados = $("#EstudiosCursados" + hash);
                this.AfiliadoISS = $("#AfiliadoISS" + hash);
                this.FechaDeCasamiento = $("#FechaDeCasamiento" + hash);
                this.Persona = $("#Persona" + hash);
                this.Activo = $("#Activo" + hash);
                this.FechaBaja = $("#FechaBaja" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                this.NumeroPS = $("#NumeroPS" + hash);
                this.Domicilio = $("#Domicilio" + hash);
                this.FechaUltimoAscenso = $("#FechaUltimoAscenso" + hash);
                this.UltimoCargo = $("#UltimoCargo" + hash);
                //operaciones
                //Establece el foco
                this.Id.focus();
            }
            Eliminar.prototype.limpiar = function () {
                this.Id.val("");
                this.Legajo.val("");
                this.Telefono.val("");
                this.Profesion.val("");
                this.EstudiosCursados.val("");
                this.AfiliadoISS.val("");
                this.FechaDeCasamiento.val("");
                this.Persona.val("");
                this.Activo.val("");
                this.FechaBaja.val("");
                this.FechaAlta.val("");
                this.NumeroPS.val("");
                this.Domicilio.val("");
                this.FechaUltimoAscenso.val("");
                this.UltimoCargo.val("");
            };
            //--- Funciones para seteo de Datatables ---/
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
        })();
        ts.Eliminar = Eliminar; //JS
    })(ts = Agentes.ts || (Agentes.ts = {}));
})(Agentes || (Agentes = {})); // module
