/// <reference path="../../../../ts/types/chosen.jquery.d.ts" />
/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
var ConcursosDeIngreso;
(function (ConcursosDeIngreso) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Nombre = $('#Nombre' + hash);
                this.Descripcion = $('#Descripcion' + hash);
                this.FechaInicio = $('#FechaInicio' + hash);
                this.FechaFin = $('#FechaFin' + hash);
                this.Organismo = $('#Organismo' + hash);
                this.Cargo = $('#Cargo' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Url = $('#url' + hash);
                this.Id = $('#Id' + hash);
                //this.validacion();
            }
            //public validacion() {
            //	this.form.validate({
            //		errorClass: "field-validation-error",
            //		rules: {
            //			Nombre: { required: true, number: false, maxlength: 150 },
            //			Descripcion: { required: false, number: false, maxlength: 250 },
            //			FechaInicio: { required: true, number: false, maxlength: 10 },
            //			FechaFin: { required: true, number: false, maxlength: 10 },
            //			Organismo: { required: true, number: true, maxlength: 4 },
            //			Cargo: { required: true, number: true, maxlength: 4 },
            //		},
            //		messages: {
            //			Nombre: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
            //			Descripcion: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 250 caracteres" },
            //			FechaInicio: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
            //			FechaFin: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 8 caracteres" },
            //			Organismo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
            //			Cargo: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
            //		}
            //	});
            //}
            Crear.prototype.limpiar = function () {
                this.Nombre.val("");
                this.Descripcion.val("");
                this.FechaInicio.val("");
                this.FechaFin.val("");
                this.Organismo.val('').trigger("liszt:updated");
                this.Cargo.val('').trigger("liszt:updated");
            };
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
    })(ts = ConcursosDeIngreso.ts || (ConcursosDeIngreso.ts = {}));
})(ConcursosDeIngreso || (ConcursosDeIngreso = {})); // module
