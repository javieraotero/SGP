/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="Eliminar.ts"/>
/// <reference path="Detalle.ts"/>
var ColaDeMovimientosCESIDA;
(function (ColaDeMovimientosCESIDA) {
    var ts;
    (function (ts) {
        var ColaDeMovimientosCESIDAManager = (function () {
            function ColaDeMovimientosCESIDAManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            ColaDeMovimientosCESIDAManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ColaDeMovimientosCESIDAManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            ColaDeMovimientosCESIDAManager.prototype.setEditar = function (v) {
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
            //--- Inicialización de la vista Eliminar
            ColaDeMovimientosCESIDAManager.prototype.setEliminar = function (v) {
                var that = this;
                this.ViewEliminar = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Detalle
            ColaDeMovimientosCESIDAManager.prototype.setDetalle = function (v) {
                var that = this;
                this.ViewDetalle = v;
                // Eventos de la vista
            };
            //--- Función editar de Datatable ColaDeMovimientosCESIDA
            ColaDeMovimientosCESIDAManager.prototype.editar_dtColaDeMovimientosCESIDA = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "ColaDeMovimientosCESIDA/Editar/" + id, true, true, true);
            };
            ColaDeMovimientosCESIDAManager.prototype.ejecutar = function () {
                var self = this;
                console.log("llamando a ejecutar");
                var id = this.ViewIndex.getData(0);
                var movimiento = this.ViewIndex.getData(2);
                app.Bloquear();
                $.post("/RRHH/ColaDeMovimientosCESIDA/EnviarMovimiento/", { id: id }, function (data) {
                    app.Desbloquear();
                    app.crearNotificacionInfo("Resultado", data.mensaje);
                    self.ViewIndex.ColaDeMovimientosCESIDA.fnDraw();
                });
            };
            //--- Función eliminar de Datatable ColaDeMovimientosCESIDA
            ColaDeMovimientosCESIDAManager.prototype.eliminar_dtColaDeMovimientosCESIDA = function () {
                var id = this.ViewIndex.getData(0);
                this.eliminar("ColaDeMovimientosCESIDA/Eliminar", { id: id });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ColaDeMovimientosCESIDAManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
            ColaDeMovimientosCESIDAManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            ColaDeMovimientosCESIDAManager.prototype.eliminar = function (url, data, resultado) {
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
            return ColaDeMovimientosCESIDAManager;
        })();
        ts.ColaDeMovimientosCESIDAManager = ColaDeMovimientosCESIDAManager; //JS	
    })(ts = ColaDeMovimientosCESIDA.ts || (ColaDeMovimientosCESIDA.ts = {}));
})(ColaDeMovimientosCESIDA || (ColaDeMovimientosCESIDA = {}));
