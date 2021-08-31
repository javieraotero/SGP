/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var EjecucionesPresupuestariasReestructuras;
(function (EjecucionesPresupuestariasReestructuras) {
    var ts;
    (function (ts) {
        var EjecucionesPresupuestariasReestructurasManager = /** @class */ (function () {
            function EjecucionesPresupuestariasReestructurasManager() {
                //this.initHandler();
            }
            EjecucionesPresupuestariasReestructurasManager.prototype.setIndex = function (v) {
                var self = this;
                this.ViewIndex = v;
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.editar_dtEjecucionesPresupuestariasReestructuras = function (el) {
                this.ViewIndex.selectRow_EjecucionesPresupuestariasReestructuras(el);
                var id = this.ViewIndex.getData_EjecucionesPresupuestariasReestructuras(0);
                app.createTab("Editar", "EjecucionesPresupuestariasReestructuras/Editar/" + id, true, true, true);
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.eliminar_dtEjecucionesPresupuestariasReestructuras = function (el) {
                this.ViewIndex.selectRow_EjecucionesPresupuestariasReestructuras(el);
                var id = this.ViewIndex.getData_EjecucionesPresupuestariasReestructuras(0);
                this.eliminar("EjecucionesPresupuestariasReestructuras/Eliminar", { id: id });
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.setCrear = function (v) {
                var self = this;
                this.ViewCrear = v;
                v.Cancelar.click(function (e) {
                    self.ViewCrear.limpiar();
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            self.ViewIndex.EjecucionesPresupuestariasReestructuras.fnDraw();
                            app.tabs.reloadCurrent();
                            app.irATab(0);
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            self.ViewCrear.limpiar(); //self.ViewCrear.Descripcion.focus(); 
                        }
                    });
                });
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.setEditar = function (v) {
                var self = this;
                this.ViewEditar = v;
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewEditar, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            self.ViewIndex.EjecucionesPresupuestariasReestructuras.fnDraw();
                            app.closeCurrentTab();
                            app.irATab(0);
                        }
                    });
                });
            };
            EjecucionesPresupuestariasReestructurasManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
            EjecucionesPresupuestariasReestructurasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            EjecucionesPresupuestariasReestructurasManager.prototype.eliminar = function (url, data) {
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
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                    that.ViewIndex.EjecucionesPresupuestariasReestructuras.fnDraw();
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
            return EjecucionesPresupuestariasReestructurasManager;
        }()); //JS
        ts.EjecucionesPresupuestariasReestructurasManager = EjecucionesPresupuestariasReestructurasManager;
    })(ts = EjecucionesPresupuestariasReestructuras.ts || (EjecucionesPresupuestariasReestructuras.ts = {}));
})(EjecucionesPresupuestariasReestructuras || (EjecucionesPresupuestariasReestructuras = {})); // module
