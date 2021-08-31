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
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Nombre = $("#Nombre" + hash);
                this.NumeroAcreedor = $("#NumeroAcreedor" + hash);
                this.RazonSocial = $("#RazonSocial" + hash);
                this.NombreFantasia = $("#NombreFantasia" + hash);
                this.DomicilioReal = $("#DomicilioReal" + hash);
                this.CodigoPostal = $("#CodigoPostal" + hash);
                this.CUIT = $("#CUIT" + hash);
                this.IngresosBrutos = $("#IngresosBrutos" + hash);
                this.ExentoGanancias = $("#ExentoGanancias" + hash);
                this.ExentoIngresosBrutos = $("#ExentoIngresosBrutos" + hash);
                this.InscriptoEnGanancias = $("#InscriptoEnGanancias" + hash);
                this.Estado = $("#Estado" + hash);
                this.FechaInscripcion = $("#FechaInscripcion" + hash);
                this.FechaReInscripcion = $("#FechaReInscripcion" + hash);
                this.FechaFinExentoSellado = $("#FechaFinExentoSellado" + hash);
                this.FechaFinSuspension = $("#FechaFinSuspension" + hash);
                this.FechaFinExentoGanancias = $("#FechaFinExentoGanancias" + hash);
                this.FechaFinExentoIngresosBrutos = $("#FechaFinExentoIngresosBrutos" + hash);
                this.FechaBaja = $("#FechaBaja" + hash);
                this.ExentoSellos = $("#ExentoSellos" + hash);
                this.AjustePorInflacion = $("#AjustePorInflacion" + hash);
                this.FormaDePago = $("#FormaDePago" + hash);
                this.NumeroDeCuenta = $("#NumeroDeCuenta" + hash);
                this.CBU = $("#CBU" + hash);
                this.TipoDeCuenta = $("#TipoDeCuenta" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                this.FechaModifica = $("#FechaModifica" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.UsuarioBaja = $("#UsuarioBaja" + hash);
                this.UsuarioModifica = $("#UsuarioModifica" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Nombre.val("");
                this.NumeroAcreedor.val("");
                this.RazonSocial.val("");
                this.NombreFantasia.val("");
                this.DomicilioReal.val("");
                this.CodigoPostal.val("");
                this.CUIT.val("");
                this.IngresosBrutos.val("");
                this.ExentoGanancias.removeAttr('checked');
                this.ExentoIngresosBrutos.removeAttr('checked');
                this.InscriptoEnGanancias.removeAttr('checked');
                this.Estado.val("");
                this.FechaInscripcion.val("");
                this.FechaReInscripcion.val("");
                this.FechaFinExentoSellado.val("");
                this.FechaFinSuspension.val("");
                this.FechaFinExentoGanancias.val("");
                this.FechaFinExentoIngresosBrutos.val("");
                this.FechaBaja.val("");
                this.ExentoSellos.removeAttr('checked');
                this.AjustePorInflacion.removeAttr('checked');
                this.FormaDePago.val('').trigger("liszt:updated");
                this.NumeroDeCuenta.val("");
                this.CBU.val("");
                this.TipoDeCuenta.val('').trigger("liszt:updated");
                this.FechaAlta.val("");
                this.FechaModifica.val("");
                this.UsuarioAlta.val("");
                this.UsuarioBaja.val("");
                this.UsuarioModifica.val("");
            };
            //--- Funciones para seteo de Datatables ---/
            Editar.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
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
        }()); //JS
        ts.Editar = Editar;
    })(ts = Proveedores.ts || (Proveedores.ts = {}));
})(Proveedores || (Proveedores = {})); // module
