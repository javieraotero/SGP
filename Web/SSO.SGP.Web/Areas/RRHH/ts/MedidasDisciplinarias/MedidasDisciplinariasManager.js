var MedidasDisciplinarias;
(function (MedidasDisciplinarias) {
    /// <reference path="../../../../ts/IControlador.ts"/>
    /// <reference path="../../../../ts/AppManager.ts"/>
    /// <reference path="Index.ts"/>
    /// <reference path="Crear.ts"/>
    /// <reference path="Editar.ts"/>
    (function (ts) {
        var MedidasDisciplinariasManager = (function () {
            function MedidasDisciplinariasManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            MedidasDisciplinariasManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;

                v.MedidasDisciplinarias.setearSeleccionable(true);

                $.contextMenu({
                    selector: "#" + that.ViewIndex.MedidasDisciplinarias.Id,
                    items: {
                        "Bajar": {
                            name: "Bajar",
                            callback: function () {
                                $.when(that.eliminar("RRHH/MedidasDisciplinarias/Eliminar", { id: that.ViewIndex.MedidasDisciplinarias.id })).done(function () {
                                    that.ViewIndex.MedidasDisciplinarias.refrescar();
                                });
                            }
                        },
                        "Editar": {
                            name: "Editar",
                            callback: function () {
                                v.modal.setearTitulo("Editar Nombramiento");
                                v.modal.loadAjax("RRHH/MedidasDisciplinarias/Editar/?id=" + v.MedidasDisciplinarias.id);
                                v.modal.mostrar();
                            }
                        }
                    }
                });

                // Eventos de la vista
                v.Nuevo.click(function (e) {
                    v.modal.cargar("Nueva Medida Disciplinaria", "RRHH/MedidasDisciplinarias/Crear/?agente=" + v.Agente.val());
                });

                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                    app.irATab(0);
                });
            };

            //--- Inicialización de la vista Crear
            MedidasDisciplinariasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;

                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });

                v.Guardar.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Medida Disciplinaria", res).done(function () {
                        if (res.estado) {
                            that.ViewIndex.modal.cerrar();
                            that.ViewIndex.MedidasDisciplinarias.refrescar();
                        }
                    });
                });

                v.GuardarYNuevo.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Medida Disciplinaria", res).done(function () {
                        if (res.estado) {
                            that.ViewIndex.MedidasDisciplinarias.refrescar();
                            that.ViewCrear.limpiar();
                        }
                    });
                });
            };

            //--- Inicialización de la vista Editar
            MedidasDisciplinariasManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;

                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    that.ViewIndex.modal.cerrar();
                });

                v.Guardar.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewEditar, "Actualizar Medida Disciplinaria", res).done(function () {
                        if (res.estado) {
                            that.ViewIndex.MedidasDisciplinarias.refrescar();
                            that.ViewIndex.modal.cerrar();
                        }
                    });
                });
            };

            //-- Método para pasar Vistas por Post según URL de formulario
            MedidasDisciplinariasManager.prototype.ajaxPost = function (v, titulo, resultado) {
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

            MedidasDisciplinariasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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

            MedidasDisciplinariasManager.prototype.eliminar = function (url, data) {
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
            return MedidasDisciplinariasManager;
        })();
        ts.MedidasDisciplinariasManager = MedidasDisciplinariasManager;
    })(MedidasDisciplinarias.ts || (MedidasDisciplinarias.ts = {}));
    var ts = MedidasDisciplinarias.ts;
})(MedidasDisciplinarias || (MedidasDisciplinarias = {}));
