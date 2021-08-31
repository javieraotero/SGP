/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ExpedientesDocumentoADM;
(function (ExpedientesDocumentoADM) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Archivo = new SyncroUpload($("#Archivo" + hash));
                this.Confirmado = $("#Confirmado" + hash);
                this.Actuacion = $("#Actuacion" + hash);
                this.NombreOriginal = $("#NombreOriginal" + hash);
                this.Extension = $("#Extension" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Usuario = $("#Usuario" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Archivo.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Archivo.val("");
                this.Confirmado.removeAttr('checked');
                this.Actuacion.val("");
                this.NombreOriginal.val("");
                this.Extension.val("");
                this.Descripcion.val("");
                this.Usuario.val("");
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
    })(ts = ExpedientesDocumentoADM.ts || (ExpedientesDocumentoADM.ts = {}));
})(ExpedientesDocumentoADM || (ExpedientesDocumentoADM = {})); // module
