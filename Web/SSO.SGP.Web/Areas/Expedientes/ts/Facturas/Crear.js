/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Proveedor = new SyncroAutocomplete("Proveedor" + hash, "Expedientes/Proveedores/Autocomplete");
                this.Proveedor.setAppendTo("#Proveedor");
                this.Tipo = $("#Tipo" + hash);
                this.NumeroDeFactura = $("#NumeroDeFactura" + hash);
                this.IdentificacionDeFactura = $("#IdentificacionDeFactura" + hash);
                this.Expediente = new SyncroAutocomplete("Expediente" + hash, "Expedientes/ExpedientesADM/Autocomplete");
                this.Fecha = $("#Fecha" + hash);
                this.Importe = $("#Importe" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Organismo = $("#Organismo" + hash);
                this.DeImpuestosMunicipales = $("#DeImpuestosMunicipales" + hash);
                this.Comprobante2 = $("#Comprobante2" + hash);
                this.Comprobante3 = $("#Comprobante3" + hash);
                this.DeServicios = $("#DeServicios" + hash);
                this.FechaDesde = $("#FechaDesde" + hash);
                this.FechaHasta = $("#FechaHasta" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Proveedor.txt.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Proveedor.limpiar();
                this.Tipo.val("");
                this.NumeroDeFactura.val("");
                this.IdentificacionDeFactura.val("");
                this.Expediente.limpiar();
                this.Fecha.val("");
                this.Importe.val("");
                this.Descripcion.val("");
                this.Organismo.val('').trigger("liszt:updated");
                this.DeImpuestosMunicipales.removeAttr('checked');
                this.Comprobante2.val("");
                this.Comprobante3.val("");
                this.DeServicios.removeAttr('checked');
                this.FechaDesde.val("");
                this.FechaHasta.val("");
            };
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
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
