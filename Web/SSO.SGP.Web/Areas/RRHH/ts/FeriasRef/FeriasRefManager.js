/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var FeriasRef;
(function (FeriasRef) {
    var ts;
    (function (ts) {
        var FeriasRefManager = (function () {
            function FeriasRefManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            FeriasRefManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
                v.Nuevo.click(function (e) {
                    v.Modal.cargar("Nueva Feria", "RRHH/FeriasRef/Crear");
                });
            };
            //--- Inicialización de la vista Crear
            FeriasRefManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    that.ViewIndex.Modal.cerrar();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Feria", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewIndex.Modal.cerrar();
                            that.ViewIndex.FeriasRef.fnDraw();
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Actualizar Feria", res).done(function () {
                        if (res.estado) {
                            that.ViewCrear.limpiar();
                            that.ViewIndex.FeriasRef.fnDraw();
                        }
                    });
                });
            };
            //--- Inicialización de la vista Editar
            FeriasRefManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Actualizar Feria").done(function () {
                    });
                });
            };
            //--- Función editar de Datatable FeriasRef
            FeriasRefManager.prototype.editar_dtFeriasRef = function (el) {
                var id = this.ViewIndex.getData(0);
                var descripcion = this.ViewIndex.getData(1);
                app.createTab("Editar", "RRHH/FeriasRef/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable FeriasRef
            FeriasRefManager.prototype.eliminar_dtFeriasRef = function (el) {
                var id = this.ViewIndex.getData(0);
                var descripcion = this.ViewIndex.getData(1);
                this.eliminar("RRHH/FeriasRef/Eliminar", { id: id });
            };
            //--- Función paso1 de Datatable FeriasRef
            FeriasRefManager.prototype.paso1_dtFeriasRef = function (el) {
                var id = this.ViewIndex.getData(0);
                var descripcion = this.ViewIndex.getData(1);
                app.Bloquear();
                app.createTab("Paso 1 " + descripcion, "RRHH/FeriasAgentes/Index/?feria=" + id + "&paso=1", true, true, true);
            };
            //--- Función paso2 de Datatable FeriasRef
            FeriasRefManager.prototype.paso2_dtFeriasRef = function (el) {
                var id = this.ViewIndex.getData(0);
                var descripcion = this.ViewIndex.getData(1);
                app.Bloquear();
                app.createTab("Paso 2 " + descripcion, "RRHH/FeriasAgentes/Index/?feria=" + id + "&paso=2", true, true, true);
            };
            FeriasRefManager.prototype.juzgadodepaz_dtFeriasRef = function (el) {
                var id = this.ViewIndex.getData(0);
                this.asignarjuzgadosdepaz("RRHH/FeriasRef/AsignarJuzgadosDePag", { id: id });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            FeriasRefManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
            FeriasRefManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            FeriasRefManager.prototype.asignarjuzgadosdepaz = function (url, data) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea ejecutar este proceso?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                if (data[0]) {
                                    app.crearNotificacionSuccess("OK", data[1]);
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
            FeriasRefManager.prototype.eliminar = function (url, data) {
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
            return FeriasRefManager;
        })();
        ts.FeriasRefManager = FeriasRefManager; //JS	
    })(ts = FeriasRef.ts || (FeriasRef.ts = {}));
})(FeriasRef || (FeriasRef = {}));
