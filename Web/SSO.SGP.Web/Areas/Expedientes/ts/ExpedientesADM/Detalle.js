/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var Detalle = /** @class */ (function () {
            //public afacturas: Facturas[];
            //public aactuaciones: Actuaciones[];
            //---  /Propiedades de Formulario --- //
            function Detalle(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Tipo = $("#Tipo" + hash);
                this.Categoria = $("#Categoria" + hash);
                this.Numero = $("#Numero" + hash);
                this.NumeroDeCorresponde = $("#NumeroDeCorresponde" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.OrganismoIniciador = $("#OrganismoIniciador" + hash);
                this.TextoIniciador = $("#TextoIniciador" + hash);
                this.Caratula = $("#Caratula" + hash);
                this.Destino = $("#Destino" + hash);
                this.divDetalle = $("#divDetalle" + hash);
                this.Afectar = $("#Afectar" + hash);
                this.Id = $("#Id" + hash);
                this.body_facturas = $("#body_facturas" + hash);
                this.NuevoAdjunto = $("#NuevoAdjunto" + hash);
                this.table_pendiente_op = $("#table_pendiente_op" + hash);
                this.body_pendiente_op = $("#body_pendiente_op" + hash);
                this.table_facturas_pendientes = $("#table_facturas_pendientes" + hash);
                this.body_facturas_pendientes = $("#body_facturas_pendientes" + hash);
                this.modalFacturas = new SyncroModal($("#ModalFacturas"));
                this.ConfirmarAfectacion = $("#ConfirmarAfectacion" + hash);
                this.Seleccionar_Todas = $("#todas" + hash);
                this.Ordenado = $("#Ordenado" + hash);
                this.body_contabilidad = $("#body_contabilidad" + hash);
                this.SobreAfectar = $("#Sobreafectar" + hash);
                this.Asignar = $("#NuevoMovimiento" + hash);
                this.Desafectar = $("#Desafectar" + hash);
                this.AfectacionCompromisoOrdenado = $("#AfectacionCompromisoOrdenado" + hash);
                //this.divDetalle.hide();
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.NuevaActuacion = $("#Pase" + hash);
                this.NuevaFactura = $("#NuevaFactura" + hash);
                //this.afacturas = [];
                //this.aactuaciones = [];
                //Establece el foco
                this.Tipo.focus();
            }
            Detalle.prototype.limpiar = function () {
                this.Tipo.val('').trigger("liszt:updated");
                this.Categoria.val('').trigger("liszt:updated");
                this.Numero.val("");
                this.NumeroDeCorresponde.val("");
                this.Fecha.val("");
                this.OrganismoIniciador.val('').trigger("liszt:updated");
                this.TextoIniciador.val("");
                this.Caratula.val("");
                this.Destino.val('').trigger("liszt:updated");
            };
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
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
