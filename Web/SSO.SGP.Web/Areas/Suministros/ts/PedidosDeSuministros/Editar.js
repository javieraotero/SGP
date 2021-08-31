var PedidosDeSuministros;
(function (PedidosDeSuministros) {
    /// <reference path="../../ts/types/jquery.d.ts"/>
    /// <reference path="../../ts/IControlador.ts"/>
    /// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
    /// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
    /// <reference path="../../ts/Syncro/SyncroModal.ts"/>
    /// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
    (function (ts) {
        var Editar = (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];

                this.Id = $("#Id" + hash);
                this.Organismo = $("#Organismo" + hash);
                this.FechaDePedido = $("#FechaDePedido" + hash);
                this.Usuario = $("#Usuario" + hash);
                this.FechaDeCarga = $("#FechaDeCarga" + hash);
                this.Entregado = $("#Entregado" + hash);
                this.FechaDeBaja = $("#FechaDeBaja" + hash);
                this.UsuarioBaja = $("#UsuarioBaja" + hash);

                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);

                //Establece el foco
                this.Id.focus();
            }
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Organismo.val('').trigger("liszt:updated");
                this.FechaDePedido.val("");
                this.Usuario.val('').trigger("liszt:updated");
                this.FechaDeCarga.val("");
                this.Entregado.removeAttr('checked');
                this.FechaDeBaja.val("");
                this.UsuarioBaja.val("");
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
        })();
        ts.Editar = Editar;
    })(PedidosDeSuministros.ts || (PedidosDeSuministros.ts = {}));
    var ts = PedidosDeSuministros.ts;
})(PedidosDeSuministros || (PedidosDeSuministros = {}));
