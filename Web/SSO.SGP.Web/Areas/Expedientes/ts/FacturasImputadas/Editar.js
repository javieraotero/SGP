/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
var FacturasImputadas;
(function (FacturasImputadas) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Factura = $("#Factura" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.AnioContable = $("#AnioContable" + hash);
                this.Usuario = $("#Usuario" + hash);
                this.FechaElimina = $("#FechaElimina" + hash);
                this.UsuarioElimina = $("#UsuarioElimina" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Factura.val('').trigger("liszt:updated");
                this.Fecha.val("");
                this.AnioContable.val("");
                this.Usuario.val("");
                this.FechaElimina.val("");
                this.UsuarioElimina.val("");
            };
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
    })(ts = FacturasImputadas.ts || (FacturasImputadas.ts = {}));
})(FacturasImputadas || (FacturasImputadas = {})); // module
