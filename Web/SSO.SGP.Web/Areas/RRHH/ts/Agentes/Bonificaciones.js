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
        var Bonificaciones = (function () {
            //---  /Propiedades de Formulario --- //		
            function Bonificaciones(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Mes = $("#Mes" + hash);
                this.Anio = $("#Anio" + hash);
                this.Desde = $("#Desde" + hash);
                this.Hasta = $("#Hasta" + hash);
                this.Ver = $("#Ver" + hash);
                this.body_agentes = $("#body_agentes" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.Modal = new SyncroModal($("#ModalAgentes"));
                this.Excel = $("#Excel" + hash);
                this.ExcelMP = $("#ExcelMP" + hash);
                //Establece el foco
                this.Mes.focus();
            }
            Bonificaciones.prototype.limpiar = function () {
                this.Mes.val("");
                this.Anio.val("");
                //this.Desde.val("");
                //this.Hasta.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/	
            Bonificaciones.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Bonificaciones.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Bonificaciones;
        })();
        ts.Bonificaciones = Bonificaciones; //JS
    })(ts = Agentes.ts || (Agentes.ts = {}));
})(Agentes || (Agentes = {})); // module
