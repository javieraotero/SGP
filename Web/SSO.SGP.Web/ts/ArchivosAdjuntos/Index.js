/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var ArchivosAdjuntos;
(function (ArchivosAdjuntos) {
    var ts;
    (function (ts) {
        var Index = (function () {
            function Index(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                //this.validacion();
            }
            //public validacion() {
            //          this.form.validate({
            //              errorClass: "field-validation-error",                
            //              rules: {
            //			ArchivosAdjuntos:{required:true, number:false, maxlength:0 },
            //			                },
            //              messages: {
            //			ArchivosAdjuntos: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},
            //			                }
            //          });
            //      }
            Index.prototype.limpiar = function () {
            };
            Index.prototype.setArchivosAdjuntos = function (dt) {
                var self = this;
                this.ArchivosAdjuntos = dt;
                $("#dtArchivosAdjuntos tbody").click(function (event) {
                    $(self.ArchivosAdjuntos.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = self.ArchivosAdjuntos.fnGetData($(event.target).closest("tr").index())[0];
                    self.ArchivosAdjuntos_id = id;
                    self.ArchivosAdjuntos_index = $(event.target).closest("tr").index();
                });
            };
            Index.prototype.getData_ArchivosAdjuntos = function (col) {
                return (this.ArchivosAdjuntos.fnGetData(this.ArchivosAdjuntos_index)[col]);
            };
            Index.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Index.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Index;
        })();
        ts.Index = Index; //JS
    })(ts = ArchivosAdjuntos.ts || (ArchivosAdjuntos.ts = {}));
})(ArchivosAdjuntos || (ArchivosAdjuntos = {})); // module
