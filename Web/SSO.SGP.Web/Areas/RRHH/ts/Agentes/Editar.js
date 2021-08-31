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
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
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
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Legajo.val("");
                this.Telefono.val("");
                this.Profesion.val("");
                this.EstudiosCursados.val("");
                this.AfiliadoISS.val("");
                this.FechaDeCasamiento.val("");
                this.Persona.val('').trigger("liszt:updated");
                this.Activo.val("");
                this.FechaBaja.val("");
                this.FechaAlta.val("");
                this.NumeroPS.val("");
                this.Domicilio.val("");
                this.FechaUltimoAscenso.val("");
                this.UltimoCargo.val('').trigger("liszt:updated");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        })();
        ts.Editar = Editar; //JS
    })(ts = Agentes.ts || (Agentes.ts = {}));
})(Agentes || (Agentes = {})); // module
