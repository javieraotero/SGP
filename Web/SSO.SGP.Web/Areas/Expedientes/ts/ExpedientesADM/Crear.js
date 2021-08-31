/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroSelect.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //public afacturas: Facturas[];
            //public aactuaciones: Actuaciones[];
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Tipo = $("#TiposExpedienteADMRef" + hash);
                //this.Categoria = $("#CategoriasExpedienteADMRef"+hash);
                this.Categoria = new SyncroSelect("CategoriasExpedienteADMRef" + hash, true);
                this.Numero = $("#Numero" + hash);
                this.NumeroDeCorresponde = $("#NumeroDeCorresponde" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.OrganismoIniciador = $("#OrganismoIniciador" + hash);
                this.TextoIniciador = $("#TextoIniciador" + hash);
                this.Caratula = $("#Caratula" + hash);
                this.Destino = $("#Destino" + hash);
                this.divDetalle = $("#divDetalle" + hash);
                this.EsCorreponde = $("#chkCorresponde" + hash);
                this.hidCorresponde = $("#hidCorresponde");
                this.hidNumero = $("#hidNumero");
                this.spNumeroExpediente = $("#spNumeroExpediente");
                this.divDetalle.hide();
                this.Modal = new SyncroModal($("#MainModal"));
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Imprimir = $("#Imprmir" + hash);
                this.NuevaActuacion = $("#NuevaActuacion" + hash);
                this.NuevaFactura = $("#NuevaFactura" + hash);
                this.Id = $("#Id" + hash);
                this.Imprimir.hide();
                //this.afacturas = [];
                //this.aactuaciones = [];
                //Establece el foco
                this.Tipo.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Tipo.val('').trigger("liszt:updated");
                //this.Categoria.val('').trigger("liszt:updated");
                this.Numero.val("");
                this.NumeroDeCorresponde.val("");
                this.Fecha.val("");
                this.OrganismoIniciador.val('').trigger("liszt:updated");
                this.TextoIniciador.val("");
                this.Caratula.val("");
                this.Destino.val('').trigger("liszt:updated");
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
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
