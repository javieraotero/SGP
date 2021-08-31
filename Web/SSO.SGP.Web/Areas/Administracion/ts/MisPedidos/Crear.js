/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var oMisPedidos;
(function (oMisPedidos) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                var that = this;
                this.form = $("#" + hash);
                this.datatables = [];
                this.OrganismoDestino = $("#OrganismoDestino" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Numero = $("#Numero" + hash);
                this.Activo = $("#Activo" + hash);
                
                //this.Organismos = new SyncroAutocomplete("OrganismosRef" + hash, true);
                //this.Organismos = new SyncroAutocomplete("Organismos" + hash, "OrgasnimosRef/GetJson");
                //this.Organismo = $("#Organismo" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Modal = new SyncroModal($("#ModalMisPedidos"));
                //Establece el foco
                this.OrganismoDestino.focus();
            }
            Crear.prototype.limpiar = function () {
                //this.Organismo.val('').trigger("liszt:updated");
                this.OrganismoDestino.val('').trigger("liszt:updated");
                this.Descripcion.val("");
                this.Numero.val("");
                //this.Activo.val("");
                
            };
            //--- Funciones para seteo de Datatables ---/
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
        ts.Crear = Crear; //JS
    })(ts = MisPedidos.ts || (MisPedidos.ts = {}));
})(MisPedidos || (MisPedidos = {})); // module
