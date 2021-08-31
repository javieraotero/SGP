/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ActuacionesADM;
(function (ActuacionesADM) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Expediente = $("#Expediente" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.Observaciones = $("#Observaciones" + hash);
                this.FechaRecepcion = $("#FechaRecepcion" + hash);
                this.UsuarioRecepcion = $("#UsuarioRecepcion" + hash);
                this.OficinaOrigen = $("#OficinaOrigen" + hash);
                this.SubAmbitoOrigen = $("#SubAmbitoOrigen" + hash);
                this.Anulado = $("#Anulado" + hash);
                this.FechaAnulado = $("#FechaAnulado" + hash);
                this.UsuarioAnulacion = $("#UsuarioAnulacion" + hash);
                this.MotivoAnulacion = $("#MotivoAnulacion" + hash);
                this.Texto = $("#Texto" + hash);
                this.FechaPublicacion = $("#FechaPublicacion" + hash);
                this.UsuarioPublica = $("#UsuarioPublica" + hash);
                this.FechaUltimaModificacion = $("#FechaUltimaModificacion" + hash);
                this.TipoActuacion = $("#TipoActuacion" + hash);
                this.ModeloAplicado = $("#ModeloAplicado" + hash);
                this.Firmante1 = $("#Firmante1" + hash);
                this.FechaFirmante1 = $("#FechaFirmante1" + hash);
                this.Firmante2 = $("#Firmante2" + hash);
                this.FechaFirmante2 = $("#FechaFirmante2" + hash);
                this.Firmante3 = $("#Firmante3" + hash);
                this.FechaFirmante3 = $("#FechaFirmante3" + hash);
                this.Firmante4 = $("#Firmante4" + hash);
                this.FechaFirmante4 = $("#FechaFirmante4" + hash);
                this.Firmante5 = $("#Firmante5" + hash);
                this.FechaFirmante5 = $("#FechaFirmante5" + hash);
                this.RequiereCargo = $("#RequiereCargo" + hash);
                this.SubAmbitoCargo = $("#SubAmbitoCargo" + hash);
                this.FechaCargo = $("#FechaCargo" + hash);
                this.UsuarioCargo = $("#UsuarioCargo" + hash);
                this.Fojas = $("#Fojas" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Expediente.val('').trigger("liszt:updated");
                this.Descripcion.val("");
                this.Fecha.val("");
                this.UsuarioAlta.val("");
                this.Observaciones.val("");
                this.FechaRecepcion.val("");
                this.UsuarioRecepcion.val('').trigger("liszt:updated");
                this.OficinaOrigen.val('').trigger("liszt:updated");
                this.SubAmbitoOrigen.val('').trigger("liszt:updated");
                this.Anulado.removeAttr('checked');
                this.FechaAnulado.val("");
                this.UsuarioAnulacion.val('').trigger("liszt:updated");
                this.MotivoAnulacion.val("");
                this.Texto.val("");
                this.FechaPublicacion.val("");
                this.UsuarioPublica.val('').trigger("liszt:updated");
                this.FechaUltimaModificacion.val("");
                this.TipoActuacion.val('').trigger("liszt:updated");
                this.ModeloAplicado.val('').trigger("liszt:updated");
                this.Firmante1.val('').trigger("liszt:updated");
                this.FechaFirmante1.val("");
                this.Firmante2.val('').trigger("liszt:updated");
                this.FechaFirmante2.val("");
                this.Firmante3.val('').trigger("liszt:updated");
                this.FechaFirmante3.val("");
                this.Firmante4.val('').trigger("liszt:updated");
                this.FechaFirmante4.val("");
                this.Firmante5.val('').trigger("liszt:updated");
                this.FechaFirmante5.val("");
                this.RequiereCargo.removeAttr('checked');
                this.SubAmbitoCargo.val('').trigger("liszt:updated");
                this.FechaCargo.val("");
                this.UsuarioCargo.val('').trigger("liszt:updated");
                this.Fojas.val("");
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
    })(ts = ActuacionesADM.ts || (ActuacionesADM.ts = {}));
})(ActuacionesADM || (ActuacionesADM = {})); // module
