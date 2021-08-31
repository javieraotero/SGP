var MedidasDisciplinarias;
(function (MedidasDisciplinarias) {
    /// <reference path="../../ts/types/jquery.d.ts"/>
    /// <reference path="../../ts/IControlador.ts"/>
    /// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.Agente = $("#Agente" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.Causa = $("#Causa" + hash);

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);

                //Establece el foco
                this.Agente.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Agente.val("");
                this.Fecha.val("");
                this.Causa.val("");
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
        ts.Crear = Crear;
    })(MedidasDisciplinarias.ts || (MedidasDisciplinarias.ts = {}));
    var ts = MedidasDisciplinarias.ts;
})(MedidasDisciplinarias || (MedidasDisciplinarias = {}));
