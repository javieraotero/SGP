/// <reference path="../../../../ts/types/chosen.jquery.d.ts" />
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
var ConcursosDeIngreso;
(function (ConcursosDeIngreso) {
    var ts;
    (function (ts) {
        var EnviarNotificaciones = (function () {
            function EnviarNotificaciones(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Titulo = $("#Titulo" + hash);
                this.Mensaje = $("#Mensaje" + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Enviar = $("#Enviar" + hash);
                // this.validacion();
            }
            //public validacion() {
            //	this.form.validate({
            //		errorClass: "field-validation-error",
            //		rules: {
            //			Titulo: { required: true, number: false, maxlength: 150 },
            //			//Mensaje: { required: true, number: false }
            //		},
            //		messages: {
            //			Titulo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
            //			//Mensaje: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8000 caracteres" }		
            //		}
            //	});
            //}
            EnviarNotificaciones.prototype.limpiar = function () {
                this.Titulo.val("");
                this.Mensaje.val("");
            };
            EnviarNotificaciones.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            EnviarNotificaciones.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return EnviarNotificaciones;
        })();
        ts.EnviarNotificaciones = EnviarNotificaciones; //JS
    })(ts = ConcursosDeIngreso.ts || (ConcursosDeIngreso.ts = {}));
})(ConcursosDeIngreso || (ConcursosDeIngreso = {})); // module
