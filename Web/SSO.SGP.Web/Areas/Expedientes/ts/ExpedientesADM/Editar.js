/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Tipo = $("#Tipo" + hash);
                this.Categoria = $("#Categoria" + hash);
                this.Numero = $("#Numero" + hash);
                this.NumeroDeTramite = $("#NumeroDeTramite" + hash);
                this.NumeroDeCorresponde = $("#NumeroDeCorresponde" + hash);
                this.FechaDeAlta = $("#FechaDeAlta" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.UsuarioBaja = $("#UsuarioBaja" + hash);
                this.FechaDeBaja = $("#FechaDeBaja" + hash);
                this.Caratula = $("#Caratula" + hash);
                this.OrganismoIniciador = $("#OrganismoIniciador" + hash);
                this.TextoIniciador = $("#TextoIniciador" + hash);
                this.ExpedienteAcumulado = $("#ExpedienteAcumulado" + hash);
                this.FechaAcumulado = $("#FechaAcumulado" + hash);
                this.UsuarioAcumulado = $("#UsuarioAcumulado" + hash);
                this.ExpedientePadre = $("#ExpedientePadre" + hash);
                this.UltimoCorresponde = $("#UltimoCorresponde" + hash);
                this.Archivado = $("#Archivado" + hash);
                this.FechaArchivado = $("#FechaArchivado" + hash);
                this.UsuarioArchiva = $("#UsuarioArchiva" + hash);
                this.AnioContable = $("#AnioContable" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Tipo.val('').trigger("liszt:updated");
                this.Categoria.val('').trigger("liszt:updated");
                this.Numero.val("");
                this.NumeroDeTramite.val("");
                this.NumeroDeCorresponde.val("");
                this.FechaDeAlta.val("");
                this.Fecha.val("");
                this.UsuarioAlta.val("");
                this.UsuarioBaja.val("");
                this.FechaDeBaja.val("");
                this.Caratula.val("");
                this.OrganismoIniciador.val('').trigger("liszt:updated");
                this.TextoIniciador.val("");
                this.ExpedienteAcumulado.val('').trigger("liszt:updated");
                this.FechaAcumulado.val("");
                this.UsuarioAcumulado.val('').trigger("liszt:updated");
                this.ExpedientePadre.val('').trigger("liszt:updated");
                this.UltimoCorresponde.val("");
                this.Archivado.removeAttr('checked');
                this.FechaArchivado.val("");
                this.UsuarioArchiva.val('').trigger("liszt:updated");
                this.AnioContable.val("");
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
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {})); // module
