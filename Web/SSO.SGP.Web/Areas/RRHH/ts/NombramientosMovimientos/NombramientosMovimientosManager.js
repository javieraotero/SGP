/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="../Nombramientos/Index.ts"/>
/// <reference path="../Nombramientos/NombramientosManager.ts"/>
var NombramientosMovimientos;
(function (NombramientosMovimientos) {
    var ts;
    (function (ts) {
        var NombramientosMovimientosManager = (function () {
            function NombramientosMovimientosManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            NombramientosMovimientosManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            NombramientosMovimientosManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    that.Nombramientos = app.getManager("Nombramientos");
                    that.Nombramientos.ViewIndex.Modal.cerrar();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Actualizar Nombramiento", resultado).done(function () {
                        that.Nombramientos = app.getManager("Nombramientos");
                        that.Nombramientos.ViewIndex.Movimientos.refrescar();
                        that.Nombramientos.ViewIndex.Nombramientos.refrescar();
                        that.Nombramientos.ViewIndex.Modal.cerrar();
                    });
                });
                v.Todos.change(function (e) {
                    $.get("Nombramientos/JsonTodosLosOrganismos", { todos: this.checked }, function (data) {
                        v.Organismo.empty();
                        $.each(data, function (index, el) {
                            v.Organismo.append("<option value='" + el.value + "'>" + el.text + "</value>");
                        });
                        v.Organismo.trigger("liszt:updated");
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            NombramientosMovimientosManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                this.Nombramientos = app.getManager("Nombramientos");
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewEditar, "Modifcar Movimiento", resultado).done(function () {
                        if (resultado.estado) {
                            that.Nombramientos.ViewIndex.Movimientos.refrescar();
                        }
                    });
                });
            };
            //--- Función editar de Datatable NombramientosMovimientos
            NombramientosMovimientosManager.prototype.editar_dtNombramientosMovimientos = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "NombramientosMovimientos/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable NombramientosMovimientos
            NombramientosMovimientosManager.prototype.eliminar_dtNombramientosMovimientos = function () {
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("NombramientosMovimientos/Eliminar", { id: id }, resultado);
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            NombramientosMovimientosManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                //if (v.form.valid()) {
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
                //}
                return (df.promise());
            };
            NombramientosMovimientosManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            NombramientosMovimientosManager.prototype.eliminar = function (url, data, resultado) {
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
                                resultado.Mensaje(data[1]);
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
            return NombramientosMovimientosManager;
        })();
        ts.NombramientosMovimientosManager = NombramientosMovimientosManager; //JS	
    })(ts = NombramientosMovimientos.ts || (NombramientosMovimientos.ts = {}));
})(NombramientosMovimientos || (NombramientosMovimientos = {}));
