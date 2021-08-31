var PedidosDeSuministros;
(function (PedidosDeSuministros) {
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

                this.Organismo = $("#Organismo" + hash);
                this.FechaDePedido = $("#FechaDePedido" + hash);
                this.Entregado = $("#Entregado" + hash);
                this.Articulo = new SyncroAutocomplete("Articulo" + hash, "ArticulosDeSuministros/JsonAutocomplete");
                this.CantidadEntregada = $("#CantidadEntregada" + hash);
                this.CantidadSolicitada = $("#CantidadSolicitada" + hash);
                this.Pedido = $("#Pedido" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.Detalle = new SyncroTable($("#Detalle" + hash));

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Agregar = $("#Agregar" + hash);
                this.spNumero = $("#Numero" + hash);
                this.Imprimir = $("#Imprimir" + hash);

                this.adetalle = [];

                //Establece el foco
                this.Organismo.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Organismo.val('').trigger("liszt:updated");
                this.FechaDePedido.val("");
                this.Entregado.removeAttr('checked');
                this.Articulo.limpiar();
                this.Entregado.val("");
                this.Pedido.val("");
                this.spNumero.html("");
                this.Detalle.limpiar();
                this.adetalle = [];
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
    })(PedidosDeSuministros.ts || (PedidosDeSuministros.ts = {}));
    var ts = PedidosDeSuministros.ts;
})(PedidosDeSuministros || (PedidosDeSuministros = {}));
