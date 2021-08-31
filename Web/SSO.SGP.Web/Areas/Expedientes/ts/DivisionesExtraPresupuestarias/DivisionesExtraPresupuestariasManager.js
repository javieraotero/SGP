/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="../PartidasPresupuestarias/PartidasPresupuestariasManager.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var DivisionesExtraPresupuestarias;
(function (DivisionesExtraPresupuestarias) {
    var ts;
    (function (ts) {
        var DivisionesExtraPresupuestariasManager = /** @class */ (function () {
            function DivisionesExtraPresupuestariasManager() {
                // Constructor
            }
            //--- Inicialización de la vista Crear
            DivisionesExtraPresupuestariasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.getManager("PartidasPresupuestarias").ViewCrear.Modal.cerrar();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    v.form.validate();
                    if (v.form.valid()) {
                        //that.ajaxPost(that.ViewCrear, "Guardar División", resultado).done(function () {
                        //    if (resultado.estado) {
                        var x = app.getManager("PartidasPresupuestarias");
                        var a = new PartidasPresupuestarias.ts.Divisiones();
                        //a.id = resultado.id;
                        a.nombre = v.Nombre.val();
                        a.nuevo = true;
                        a.codigocesida = v.CodigoCESIDA.val();
                        //a.partida = resultado.anexos.partida;
                        x.ViewCrear.adivisiones.push(a);
                        alert(a.nombre);
                        //refrescar la tabla de divisiones.
                        x.ViewCrear.DivisionesExtraPresupuestarias.aSource = x.ViewCrear.adivisiones;
                        x.ViewCrear.DivisionesExtraPresupuestarias.fromArray(x.ViewCrear.adivisiones);
                        x.ViewCrear.Modal.cerrar();
                    }
                    //    }
                    //});
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar División", resultado).done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            DivisionesExtraPresupuestariasManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Modificar título").done(function () {
                    });
                });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            DivisionesExtraPresupuestariasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: v.form.attr("action"),
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.id = data[2];
                            }
                            else {
                                app.crearNotificacionError("Error", data[1]);
                            }
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert("Error al procesar formulario ajax");
                            resultado.excepcion = textStatus + " - " + errorThrown;
                        },
                        complete: function () {
                            app.Desbloquear();
                        }
                    })).done(function () { df.resolve(); })
                        .fail(function () { df.reject(); }); //end ajax
                }
                return (df.promise());
            };
            DivisionesExtraPresupuestariasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: data,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            res.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        res.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            DivisionesExtraPresupuestariasManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el registro?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                res.Mensaje(data[1]);
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return DivisionesExtraPresupuestariasManager;
        }()); //JS	
        ts.DivisionesExtraPresupuestariasManager = DivisionesExtraPresupuestariasManager;
    })(ts = DivisionesExtraPresupuestarias.ts || (DivisionesExtraPresupuestarias.ts = {}));
})(DivisionesExtraPresupuestarias || (DivisionesExtraPresupuestarias = {}));
