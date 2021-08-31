var CompraDeSuministros;
(function (CompraDeSuministros) {
    /// <reference path="../../../../ts/types/jquery.d.ts"/>
    /// <reference path="../../../../ts/IControlador.ts"/>
    /// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
    /// <reference path="../../../../ts/Syncro/SyncroAutocomplete.ts"/>
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.Articulo = new SyncroAutocomplete("Articulo" + hash, "ArticulosDeSuministros/JsonAutocomplete");
                this.Cantidad = $("#Cantidad" + hash);
                this.Precio = $("#Precio" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.Detalle = new SyncroTable($("#Detalle" + hash));
                this.Fecha = $("#Fecha" + hash);
                this.Comprobante = $("#Comprobante" + hash);

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Agregar = $("#Agregar" + hash);

                this.adetalle = [];

                //Establece el foco
                this.Fecha.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Fecha.val("");
                this.Comprobante.val("");
                this.Precio.val("");
                this.Articulo.limpiar();
                this.Cantidad.val("");
                this.Detalle.limpiar();
                this.adetalle = [];

                this.Fecha.focus();
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
        })();
        ts.Crear = Crear;
    })(CompraDeSuministros.ts || (CompraDeSuministros.ts = {}));
    var ts = CompraDeSuministros.ts;
})(CompraDeSuministros || (CompraDeSuministros = {}));
