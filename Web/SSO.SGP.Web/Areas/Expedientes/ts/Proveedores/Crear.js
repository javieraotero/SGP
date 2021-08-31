/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Proveedores;
(function (Proveedores) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.CUIT = $("#CUIT" + hash);
                this.Nombre = $("#Nombre" + hash);
                this.RazonSocial = $("#RazonSocial" + hash);
                this.NumeroAcreedor = $("#NumeroAcreedor" + hash);
                this.NombreFantasia = $("#NombreFantasia" + hash);
                this.DomicilioReal = $("#DomicilioReal" + hash);
                this.CodigoPostal = $("#CodigoPostal" + hash);
                this.IngresosBrutos = $("#IngresosBrutos" + hash);
                this.ExentoGanancias = $("#ExentoGanancias" + hash);
                this.ExentoIngresosBrutos = $("#ExentoIngresosBrutos" + hash);
                this.AjustePorInflacion = $("#AjustePorInflacion" + hash);
                this.ExentoSellos = $("#ExentoSellos" + hash);
                this.InscriptoEnGanancias = $("#InscriptoEnGanancias" + hash);
                this.FechaInscripcion = $("#FechaInscripcion" + hash);
                this.FechaReInscripcion = $("#FechaReInscripcion" + hash);
                this.FechaFinExentoSellado = $("#FechaFinExentoSellado" + hash);
                this.FechaFinSuspension = $("#FechaFinSuspension" + hash);
                this.FechaFinExentoGanancias = $("#FechaFinExentoGanancias" + hash);
                this.FechaFinExentoIngresosBrutos = $("#FechaFinExentoIngresosBrutos" + hash);
                this.FormaDePago = $("#FormaDePago" + hash);
                this.NumeroDeCuenta = $("#NumeroDeCuenta" + hash);
                this.CBU = $("#CBU" + hash);
                this.TipoDeCuenta = $("#TipoDeCuenta" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.CUIT.focus();
            }
            Crear.prototype.limpiar = function () {
                this.CUIT.val("");
                this.Nombre.val("");
                this.RazonSocial.val("");
                this.NumeroAcreedor.val("");
                this.NombreFantasia.val("");
                this.DomicilioReal.val("");
                this.CodigoPostal.val("");
                this.IngresosBrutos.val("");
                this.ExentoGanancias.removeAttr('checked');
                this.ExentoIngresosBrutos.removeAttr('checked');
                this.AjustePorInflacion.removeAttr('checked');
                this.ExentoSellos.removeAttr('checked');
                this.InscriptoEnGanancias.removeAttr('checked');
                this.FechaInscripcion.val("");
                this.FechaReInscripcion.val("");
                this.FechaFinExentoSellado.val("");
                this.FechaFinSuspension.val("");
                this.FechaFinExentoGanancias.val("");
                this.FechaFinExentoIngresosBrutos.val("");
                this.FormaDePago.val('').trigger("liszt:updated");
                this.NumeroDeCuenta.val("");
                this.CBU.val("");
                this.TipoDeCuenta.val('').trigger("liszt:updated");
            };
            //--- Funciones para seteo de Datatables ---/
            Crear.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
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
        }()); //JS
        ts.Crear = Crear;
    })(ts = Proveedores.ts || (Proveedores.ts = {}));
})(Proveedores || (Proveedores = {})); // module
