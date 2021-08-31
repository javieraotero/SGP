var CompraDeSuministros;
(function (CompraDeSuministros) {
    /// <reference path="../../../../ts/IControlador.ts"/>
    /// <reference path="../../../../ts/AppManager.ts"/>
    /// <reference path="Index.ts"/>
    /// <reference path="Crear.ts"/>
    /// <reference path="Editar.ts"/>
    (function (ts) {
        var CompraDeSuministrosManager = (function () {
            function CompraDeSuministrosManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            CompraDeSuministrosManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };

            //--- Inicialización de la vista Crear
            CompraDeSuministrosManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;

                // Eventos de la vista
                app.setValidadorDecimal();

                v.Agregar.click(function (e) {
                    var match = that.buscarArticulo(v.Articulo.hidden.val(), v.adetalle);

                    // el articulo ya existe en la colección
                    if (match.length) {
                        that.cambiarCantidad(match[0].idarticulo, v.Cantidad.val(), v.adetalle);
                    } else {
                        var det = new DetalleDeCompra();
                        det.articulo = v.Articulo.txt.val();
                        det.idarticulo = v.Articulo.hidden.val();
                        det.cantidad = v.Cantidad.val();
                        det.precio = v.Precio.val().replace(".", ",");
                        det.nuevo = true;

                        v.adetalle.push(det);
                    }

                    v.Detalle.fromArray(v.adetalle);

                    v.Cantidad.val("");
                    v.Articulo.txt.select();
                    v.Articulo.txt.focus();
                });

                v.Detalle.setearSeleccionable(true);

                $.contextMenu({
                    selector: "#" + v.Detalle.Id,
                    items: {
                        "Eliminar": {
                            name: "Eliminar",
                            callback: function () {
                                //alert("eliminar item " + v.Detalle.index);
                                v.adetalle.splice(v.Detalle.index, 1);
                                v.Detalle.fromArray(v.adetalle);
                            }
                        }
                    }
                });

                v.Cancelar.click(function (e) {
                    app.irATab(0);
                    v.limpiar();
                });

                v.Guardar.click(function (e) {
                    var resultado = new Resultado();

                    var data = v.form.serializeObject();
                    data.Detalle = v.adetalle;
                    $.when(that.ajaxPostURL("CompraDeSuministros/Crear", data, "Guardar", resultado)).done(function () {
                        that.ViewIndex.CompraDeSuministros.fnDraw();
                        v.limpiar();
                    });
                });

                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();

                    v.Precio.val(v.Precio.val().replace(".", ","));

                    var data = v.form.serializeObject();
                    data.Detalle = v.adetalle;
                    $.when(that.ajaxPostURL("CompraDeSuministros/Crear", data, "Guardar", resultado)).done(function () {
                        that.ViewIndex.CompraDeSuministros.fnDraw();
                        v.limpiar();
                    });
                });
            };

            CompraDeSuministrosManager.prototype.buscarArticulo = function (id, array) {
                return $.grep(array, function (item) {
                    return item.idarticulo == id;
                });
            };

            CompraDeSuministrosManager.prototype.cambiarCantidad = function (id, cantidad, array) {
                for (var i in array) {
                    if (array[i].idarticulo == id) {
                        console.log("se encontro el articulo" + array[i].articulo);
                        array[i].cantidad = parseFloat(array[i].cantidad) + parseFloat(cantidad);
                        break;
                    }
                }
            };

            //--- Inicialización de la vista Editar
            CompraDeSuministrosManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;

                console.log("set Editar");

                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });

                v.adetalle = $.parseJSON($("#DetalleData").val());

                v.Detalle.fromArray(v.adetalle);

                v.Detalle.setearSeleccionable(true);

                v.Agregar.click(function (e) {
                    var match = that.buscarArticulo(v.Articulo.hidden.val(), v.adetalle);

                    // el articulo ya existe en la colección
                    if (match.length) {
                        that.cambiarCantidad(match[0].idarticulo, v.Cantidad.val(), v.adetalle);
                    } else {
                        var det = new DetalleDeCompra();
                        det.articulo = v.Articulo.txt.val();
                        det.idarticulo = v.Articulo.hidden.val();
                        det.cantidad = v.Cantidad.val();
                        det.precio = v.Precio.val();
                        det.nuevo = true;

                        v.adetalle.push(det);
                    }

                    v.Detalle.fromArray(v.adetalle);

                    v.Cantidad.val("");
                    v.Articulo.txt.select();
                    v.Articulo.txt.focus();
                });

                $.contextMenu({
                    selector: "#" + v.Detalle.Id,
                    items: {
                        "Eliminar": {
                            name: "Eliminar",
                            callback: function () {
                                //alert("eliminar item " + v.Detalle.index);
                                v.adetalle.splice(v.Detalle.index, 1);
                                v.Detalle.fromArray(v.adetalle);
                            }
                        }
                    }
                });

                v.Guardar.click(function (e) {
                    var resultado = new Resultado();

                    v.Precio.val(v.Precio.val().replace(".", ","));

                    var data = v.form.serializeObject();
                    data.Detalle = v.adetalle;
                    $.when(that.ajaxPostURL("CompraDeSuministros/Editar", data, "Guardar", resultado)).done(function () {
                        that.ViewIndex.CompraDeSuministros.fnDraw();
                    });
                });
            };

            //--- Función editar de Datatable PedidosDeSuministros
            CompraDeSuministrosManager.prototype.editar_dtCompraDeSuministros = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "Suministros/CompraDeSuministros/Editar/" + id, true, true, true);
            };

            //--- Función eliminar de Datatable PedidosDeSuministros
            CompraDeSuministrosManager.prototype.eliminar_dtCompraDeSuministros = function () {
                var that = this;
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                $.when(this.eliminar("Suministros/CompraDeSuministros/Eliminar", { id: id }, resultado)).done(function () {
                    that.ViewIndex.CompraDeSuministros.fnDraw();
                });
            };

            //-- Método para pasar Vistas por Post según URL de formulario
            CompraDeSuministrosManager.prototype.ajaxPost = function (v, titulo, resultado) {
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

            CompraDeSuministrosManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    //traditional:true,
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

            CompraDeSuministrosManager.prototype.eliminar = function (url, data, resultado) {
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
            return CompraDeSuministrosManager;
        })();
        ts.CompraDeSuministrosManager = CompraDeSuministrosManager;

        var DetalleDeCompra = (function () {
            function DetalleDeCompra() {
            }
            return DetalleDeCompra;
        })();
        ts.DetalleDeCompra = DetalleDeCompra;
    })(CompraDeSuministros.ts || (CompraDeSuministros.ts = {}));
    var ts = CompraDeSuministros.ts;
})(CompraDeSuministros || (CompraDeSuministros = {}));
