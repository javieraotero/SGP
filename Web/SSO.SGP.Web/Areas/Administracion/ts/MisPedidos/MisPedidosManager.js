/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="Eliminar.ts"/>
/// <reference path="Detalle.ts"/>
/// <reference path="Resumen.ts"/>
/// <reference path="Bonificaciones.ts"/>
/// <reference path="IndexBonificaciones.ts"/>
/// <reference path="CrearMovimientoCesida.ts"/>
var MisPedidos;
(function (MisPedidos) {
    var ts;
    (function (ts) {
        var MisPedidosManager = (function () {
            function MisPedidosManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            MisPedidosManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            
            
            //--- Inicialización de la vista Crear
            MisPedidosManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewCrear.limpiar();
                            that.ViewIndex.MisPedidos.fnDraw();
                            //app.closeCurrentTab();                            
                            app.irATab(0);                            
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Resultado", resultado).done(function () {
                        that.ViewCrear.limpiar();
                    });
                });

                /*v.Persona.click(function (e) {
                    v.Modal.setearTitulo("Seleccionar Persona");
                    v.Modal.loadAjax("Personas/Buscar");
                    v.Modal.mostrar();
                });*/
            };

            //--- Inicialización de la vista Editar
            MisPedidosManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewEditar, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewIndex.MisPedidos.fnDraw();
                            app.closeCurrentTab();
                            app.irATab(0);
                        }
                    });
                });
               
            };

            //--- Función editar de Datatable Pedidos
            MisPedidosManager.prototype.editar_dtMisPedidos = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "Administracion/MisPedidos/Editar/" + id, true, true, true);
            };

            //--- Inicialización de la vista Eliminar          
            MisPedidosManager.prototype.setEliminar = function (v) {
                var that = this;
                this.ViewEliminar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Eliminar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewEliminar, "Resultado", resultado).done(function () {
                        if(resultado.estado)
                        {
                            that.ViewIndex.MisPedidos.fnDraw();
                            app.closeCurrentTab();
                            app.irATab(0);
                        }
                    });
                });

            };

            //--- Función eliminar de Datatable Pedidos
            MisPedidosManager.prototype.eliminar_dtMisPedidos = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Eliminar", "Administracion/MisPedidos/Eliminar/" + id, true, true, true);
            };

            /*MisPedidosManager.prototype.eliminar_dtMisPedidos = function (id) {
                var res = new Resultado();
                this.eliminar("Administracion/MisPedidos/Eliminar", { id: id }, res);
                if (res.estado)
                    this.ViewIndex.MisPedidos.fnDraw();
            };*/
                      
           
            //-- Método para pasar Vistas por Post según URL de formulario
            MisPedidosManager.prototype.ajaxPost = function (v, titulo, resultado) {
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

            MisPedidosManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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

           /* MisPedidosManager.prototype.eliminar = function (url, data, res) {
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
                                res.estado = data[0];
                                res.mensaje = data[1];
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
            };*/

            MisPedidosManager.prototype.daysInMonth = function (month, year) {
                return new Date(year, month, 0).getDate();
            };

            MisPedidosManager.prototype.getDaysInMonth = function (m, y) {
                return /8|3|5|10/.test(--m) ? 30 : m == 1 ? (!(y % 4) && y % 100) || !(y % 400) ? 29 : 28 : 31;
            };

            return MisPedidosManager;
        })();
        ts.MisPedidosManager = MisPedidosManager; //JS	
    })(ts = MisPedidos.ts || (MisPedidos.ts = {}));
})(MisPedidos || (MisPedidos = {}));
