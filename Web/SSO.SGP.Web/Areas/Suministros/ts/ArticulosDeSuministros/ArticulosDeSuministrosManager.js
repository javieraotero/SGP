/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var ArticulosDeSuministros;
(function (ArticulosDeSuministros) {
    var ts;
    (function (ts) {
        var ArticulosDeSuministrosManager = (function () {
            function ArticulosDeSuministrosManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            ArticulosDeSuministrosManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ArticulosDeSuministrosManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                app.setValidadorDecimal();
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    v.UltimoCosto.val(v.UltimoCosto.val().replace(".", ","));
                    that.ajaxPost(that.ViewCrear, "Guardar", resultado).done(function () {
                        that.ViewIndex.ArticulosDeSuministros.fnDraw();
                        v.limpiar();
                        app.irATab(0);
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    v.UltimoCosto.val(v.UltimoCosto.val().replace(".", ","));
                    that.ajaxPost(that.ViewCrear, "Guardar", resultado).done(function () {
                        that.ViewIndex.ArticulosDeSuministros.fnDraw();
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            ArticulosDeSuministrosManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                app.setValidadorDecimal();
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    v.UltimoCosto.val(v.UltimoCosto.val().replace(".", ","));
                    that.ajaxPost(that.ViewEditar, "Actualizar artículo", resultado).done(function () {
                        that.ViewIndex.ArticulosDeSuministros.fnDraw();
                    });
                });
            };
            //--- Función editar de Datatable ArticulosDeSuministros
            ArticulosDeSuministrosManager.prototype.editar_dtArticulosDeSuministros = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "Suministros/ArticulosDeSuministros/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable ArticulosDeSuministros
            ArticulosDeSuministrosManager.prototype.eliminar_dtArticulosDeSuministros = function () {
                var that = this;
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("Suministros/ArticulosDeSuministros/Eliminar", { id: id }, resultado).done(function () {
                    that.ViewIndex.ArticulosDeSuministros.fnDraw();
                });
                ;
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ArticulosDeSuministrosManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
            ArticulosDeSuministrosManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            ArticulosDeSuministrosManager.prototype.eliminar = function (url, data, resultado) {
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
            return ArticulosDeSuministrosManager;
        })();
        ts.ArticulosDeSuministrosManager = ArticulosDeSuministrosManager; //JS	
    })(ts = ArticulosDeSuministros.ts || (ArticulosDeSuministros.ts = {}));
})(ArticulosDeSuministros || (ArticulosDeSuministros = {}));
