/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
/// <reference path="../../ts/Syncro/SyncroAutocomplete.ts"/>
var Personas;
(function (Personas) {
    var ts;
    (function (ts) {
        var Buscar = (function () {
            //---  /Propiedades de Formulario --- //
            function Buscar(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Documento = $("#Documento" + hash);
                this.Apellidos = $("#Apellidos" + hash);
                this.Nombre = $("#Nombre" + hash);
                this.Sexo = $("#Sexo" + hash);
                //this.Localidad = new SyncroAutocomplete("#Localidad"+hash, "Personas/LocalidadesJson"); 
                this.Localidad = $("#Localidad" + hash);
                this.Buscar = $("#Buscar" + hash);
                this.Personas = new SyncroTable($("#Personas" + hash));
                //operaciones
                //Establece el foco
                this.Documento.focus();
            }
            Buscar.prototype.limpiar = function () {
                this.Documento.val("");
                this.Apellidos.val("");
                this.Nombre.val("");
                this.Sexo.val('').trigger("liszt:updated");
                this.Localidad.limpiar();
                this.Buscar.val("");
                this.Personas.limpiar();
            };
            //--- Funciones para seteo de Datatables ---/
            //--- /Funciones para seteo de Datatables ---/		
            Buscar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Buscar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Buscar;
        })();
        ts.Buscar = Buscar; //JS
    })(ts = Personas.ts || (Personas.ts = {}));
})(Personas || (Personas = {})); // module
