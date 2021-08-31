/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var ConcursosDeIngresoInscripciones;
(function (ConcursosDeIngresoInscripciones) {
    var ts;
    (function (ts) {
        var ConcursosDeIngresoInscripcionesManager = (function () {
            function ConcursosDeIngresoInscripcionesManager() {
                //this.initHandler();
            }
            ConcursosDeIngresoInscripcionesManager.prototype.setIndex = function (v) {
                var self = this;
                this.ViewIndex = v;
            };
            ConcursosDeIngresoInscripcionesManager.prototype.editar_dtConcursosDeIngresoInscripciones = function (el) {
                this.ViewIndex.selectRow_ConcursosDeIngresoInscripciones(el);
                var id = this.ViewIndex.getData_ConcursosDeIngresoInscripciones(0);
                app.createTab("Editar", "/RRHH/ConcursosDeIngresoInscripciones/Editar/" + id, true, true, true);
            };
            ConcursosDeIngresoInscripcionesManager.prototype.confirmar_dtConcursosDeIngresoInscripciones = function (el) {
                this.ViewIndex.selectRow_ConcursosDeIngresoInscripciones(el);
                var id = this.ViewIndex.getData_ConcursosDeIngresoInscripciones(0);
                this.confirmar("/RRHH/ConcursosDeIngresoInscripciones/Confirmar", { id: id });
            };
            ConcursosDeIngresoInscripcionesManager.prototype.eliminar_dtConcursosDeIngresoInscripciones = function (el) {
                var id = this.ViewIndex.getData_ConcursosDeIngresoInscripciones(0);
                this.eliminar("/RRHH/ConcursosDeIngresoInscripciones/Eliminar", { id: id });
            };
            ConcursosDeIngresoInscripcionesManager.prototype.setCrear = function (v) {
                var self = this;
                this.ViewCrear = v;
                v.Cancelar.click(function (e) {
                    self.ViewCrear.limpiar();
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () { self.ViewIndex.ConcursosDeIngresoInscripciones.fnDraw(); self.ViewCrear.limpiar(); app.irATab(0); });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () {
                        self.ViewCrear.limpiar(); //self.ViewCrear.Descripcion.focus(); 
                    });
                });
            };
            ConcursosDeIngresoInscripcionesManager.prototype.setEditar = function (v) {
                var self = this;
                this.ViewEditar = v;
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewEditar, "Resultado", resultado).done(function () { self.ViewIndex.ConcursosDeIngresoInscripciones.fnDraw(); self.ViewCrear.limpiar(); app.irATab(0); });
                });
            };
            ConcursosDeIngresoInscripcionesManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
            ConcursosDeIngresoInscripcionesManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            ConcursosDeIngresoInscripcionesManager.prototype.confirmar = function (url, data) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea confirmar la pre-inscripción?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                    that.ViewIndex.ConcursosDeIngresoInscripciones.fnDraw();
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
            ConcursosDeIngresoInscripcionesManager.prototype.eliminar = function (url, data) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar esta inscripción?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                    that.ViewIndex.ConcursosDeIngresoInscripciones.fnDraw();
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
            return ConcursosDeIngresoInscripcionesManager;
        })();
        ts.ConcursosDeIngresoInscripcionesManager = ConcursosDeIngresoInscripcionesManager; //JS
    })(ts = ConcursosDeIngresoInscripciones.ts || (ConcursosDeIngresoInscripciones.ts = {}));
})(ConcursosDeIngresoInscripciones || (ConcursosDeIngresoInscripciones = {})); // module
