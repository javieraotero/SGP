var GrupoFamiliar;
(function (GrupoFamiliar) {
    /// <reference path="../../../../ts/IControlador.ts"/>
    /// <reference path="../../../../ts/AppManager.ts"/>
    /// <reference path="Index.ts"/>
    /// <reference path="Crear.ts"/>
    /// <reference path="Editar.ts"/>
    (function (ts) {
        var GrupoFamiliarManager = (function () {
            function GrupoFamiliarManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            GrupoFamiliarManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;

                v.GrupoFamiliar.setearSeleccionable(true);

                $.contextMenu({
                    selector: "#" + that.ViewIndex.GrupoFamiliar.Id,
                    items: {
                        "Bajar": {
                            name: "Bajar",
                            callback: function () {
                                $.when(that.eliminar("RRHH/GrupoFamiliar/Eliminar", { id: that.ViewIndex.GrupoFamiliar.id })).done(function () {
                                    that.ViewIndex.GrupoFamiliar.refrescar();
                                });
                            }
                        },
                        "Editar": {
                            name: "Editar",
                            callback: function () {
                                v.modal.setearTitulo("Editar Familiar");
                                v.modal.loadAjax("RRHH/GrupoFamiliar/Editar/?id=" + v.GrupoFamiliar.id);
                                v.modal.mostrar();
                            }
                        }
                    }
                });

                // Eventos de la vista
                v.Nuevo.click(function (e) {
                    v.modal.cargar("Nuevo Familiar", "RRHH/GrupoFamiliar/Crear/?agente=" + v.Agente.val());
                });

                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                    app.irATab(0);
                });
            };

            //--- Inicialización de la vista Crear
            GrupoFamiliarManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;

                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    that.ViewIndex.modal.cerrar();
                });

                v.Guardar.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Familiar", res).done(function () {
                        if (res.estado) {
                            that.ViewIndex.modal.cerrar();
                            that.ViewIndex.GrupoFamiliar.refrescar();
                        }
                    });
                });

                v.GuardarYNuevo.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Familiar").done(function () {
                        if (res.estado)
                            that.ViewCrear.limpiar();
                    });
                });
            };

            //--- Inicialización de la vista Editar
            GrupoFamiliarManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;

                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    that.ViewIndex.modal.cerrar();
                });

                v.Guardar.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewEditar, "Actualizar Familiar", res).done(function () {
                        if (res.estado)
                            that.ViewIndex.modal.cerrar();
                    });
                });
            };

            //--- Función editar de Datatable GrupoFamiliar
            GrupoFamiliarManager.prototype.editar_dtGrupoFamiliar = function (id) {
                app.createTab("Editar", "RRHH/GrupoFamiliar/Editar/" + id, true, true, true);
            };

            //--- Función eliminar de Datatable GrupoFamiliar
            GrupoFamiliarManager.prototype.eliminar_dtGrupoFamiliar = function (id) {
                this.eliminar("RRHH/GrupoFamiliar/Eliminar", { id: id });
            };

            //-- Método para pasar Vistas por Post según URL de formulario
            GrupoFamiliarManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;

                //var resultado = new Resultado();
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
                            } else {
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
                    })).done(function () {
                        df.resolve();
                    }).fail(function () {
                        df.reject();
                    }); //end ajax
                }
                return (df.promise());
            };

            GrupoFamiliarManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
                        } else {
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
                })).done(function () {
                    df.resolve();
                }).fail(function () {
                    df.reject();
                }); //end ajax
                return (df.promise());
            };

            GrupoFamiliarManager.prototype.eliminar = function (url, data) {
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
                                } else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () {
                            df.resolve();
                        }).fail(function () {
                            df.reject();
                        });
                    }
                });
                return (df.promise());
            };
            return GrupoFamiliarManager;
        })();
        ts.GrupoFamiliarManager = GrupoFamiliarManager;
    })(GrupoFamiliar.ts || (GrupoFamiliar.ts = {}));
    var ts = GrupoFamiliar.ts;
})(GrupoFamiliar || (GrupoFamiliar = {}));
