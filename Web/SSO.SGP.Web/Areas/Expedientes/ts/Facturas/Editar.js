/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.NumeroDeFactura = $("#NumeroDeFactura" + hash);
                this.IdentificacionDeFactura = $("#IdentificacionDeFactura" + hash);
                this.Tipo = $("#Tipo" + hash);
                this.Expediente = $("#Expediente" + hash);
                this.Proveedor = $("#Proveedor" + hash);
                this.txtProveedor = $("#txtProveedor" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Importe = $("#Importe" + hash);
                this.Organismo = $("#Organismo" + hash);
                this.Agente = $("#Agente" + hash);
                this.TextoAgente = $("#TextoAgente" + hash);
                this.EsFactura = $("#EsFactura" + hash);
                this.EstaAsignada = $("#EstaAsignada" + hash);
                this.EstaPagada = $("#EstaPagada" + hash);
                this.DeImpuestosMunicipales = $("#DeImpuestosMunicipales" + hash);
                this.Comprobante2 = $("#Comprobante2" + hash);
                this.Comprobante3 = $("#Comprobante3" + hash);
                this.DeServicios = $("#DeServicios" + hash);
                this.FechaDesde = $("#FechaDesde" + hash);
                this.FechaHasta = $("#FechaHasta" + hash);
                this.Afectada = $("#Afectada" + hash);
                this.Compromiso = $("#Compromiso" + hash);
                this.OrdenadoAPagar = $("#OrdenadoAPagar" + hash);
                this.Grupo = $("#Grupo" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                this.FechaModifica = $("#FechaModifica" + hash);
                this.FechaElimina = $("#FechaElimina" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.UsuarioModifica = $("#UsuarioModifica" + hash);
                this.UsuarioElimina = $("#UsuarioElimina" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.NumeroDeFactura.val("");
                this.IdentificacionDeFactura.val("");
                this.Tipo.val("");
                this.Expediente.val('').trigger("liszt:updated");
                this.Proveedor.val('').trigger("liszt:updated");
                this.txtProveedor.val("");
                this.Fecha.val("");
                this.Descripcion.val("");
                this.Importe.val("");
                this.Organismo.val('').trigger("liszt:updated");
                this.Agente.val("");
                this.TextoAgente.val("");
                this.EsFactura.removeAttr('checked');
                this.EstaAsignada.removeAttr('checked');
                this.EstaPagada.removeAttr('checked');
                this.DeImpuestosMunicipales.removeAttr('checked');
                this.Comprobante2.val("");
                this.Comprobante3.val("");
                this.DeServicios.removeAttr('checked');
                this.FechaDesde.val("");
                this.FechaHasta.val("");
                this.Afectada.removeAttr('checked');
                this.Compromiso.removeAttr('checked');
                this.OrdenadoAPagar.removeAttr('checked');
                this.Grupo.val("");
                this.FechaAlta.val("");
                this.FechaModifica.val("");
                this.FechaElimina.val("");
                this.UsuarioAlta.val("");
                this.UsuarioModifica.val("");
                this.UsuarioElimina.val("");
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
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {})); // module
