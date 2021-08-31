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
var Solicitudes;
(function (Solicitudes) {
    var ts;
    (function (ts) {
        var SolicitudesManager = (function () {
            function SolicitudesManager() {
                // Constructor
            }
            //--- Inicialización de la vista IndexRecepcion
            SolicitudesManager.prototype.setIndexRecepcion = function (v) {
                var that = this;
                this.ViewIndexRecepcion = v;
                // Eventos de la vista
            };

            //--- Inicialización de la vista Index
            //--- Aca estan las ya recibidas
            SolicitudesManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            
            
            //--- Inicialización de la vista Crear
            SolicitudesManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Resultado", resultado).done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Resultado", resultado).done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
                
            };

            //--- Inicialización de la vista Recibir
            SolicitudesManager.prototype.setRecibir = function (v) {
                var that = this;
                this.ViewRecibir = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Recibir.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewRecibir, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewIndexRecepcion.Solicitudes.fnDraw();
                            app.closeCurrentTab();
                            app.irATab(0);
                        }
                    });
                });
               
            };

            //--- Función Recibir de Datatable Solicitudes
            SolicitudesManager.prototype.recibir_dtSolicitudesRecepcion = function () {
                var id = this.ViewIndexRecepcion.getData(0);
                app.createTab("Recibir", "Administracion/Solicitudes/Recibir/" + id, true, true, true);
            };

            //--- Inicialización de la vista Rechazar          
            SolicitudesManager.prototype.setRechazar = function (v) {
                var that = this;
                this.ViewRechazar= v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Rechazar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewRechazar, "Resultado", resultado).done(function () {
                        if(resultado.estado)
                        {
                            that.ViewIndexRecepcion.Solicitudes.fnDraw();
                            app.closeCurrentTab();
                            app.irATab(0);
                        }
                    });
                });

            };

            //--- Función Rechazar de Datatable Solicitudes
            SolicitudesManager.prototype.rechazar_dtSolicitudesRecepcion = function () {
                var id = this.ViewIndexRecepcion.getData(0);
                app.createTab("Rechazar", "Administracion/Solicitudes/Rechazar/" + id, true, true, true);
            };

            //--- Inicialización de la vista Editar Solicitudes
            SolicitudesManager.prototype.setEditar = function (v) {
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
                            that.ViewIndex.Solicitudes.fnDraw();
                            app.closeCurrentTab();
                            app.irATab(0);
                        }
                    });
                });

                v.NuevaActuacion.click(function (e) {

                    var that = this;
                    this.ViewEditarActuacion = e;
                    console.log("nueva actuacion"  );
                    app.modal.setearTitulo("Nueva Actuación");
                    app.modal.loadAjax("/Administracion/Solicitudes/EditarActuacion/?id=0&idpedido="+v.Id.val());
                    //app.modal.loadAjax("Personas/Buscar/?usuario=true");
                    app.modal.mostrar();
                });

            };

            //--- Función editar de Datatable Solicitudes
            SolicitudesManager.prototype.editar_dtSolicitudes = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "Administracion/Solicitudes/Editar/" + id, true, true, true);
            };

            //--- Inicialización de la vista Editar Actuacion
            SolicitudesManager.prototype.setEditarActuacion = function (v) {
                var that = this;
                this.ViewEditarActuacion = v;

                // Eventos de la vista

                v.Cancelar.click(function (e) {
                    var manager = app.getManager("Solicitudes");
                    manager.ViewEditarActuacion.Modal.cerrar();
                    that.ViewIndex.Solicitudes.fnDraw();

                    //app.closeCurrentTab();
                });

                v.Guardar.click(function (e) {                    
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewEditarActuacion, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            //that.ViewIndex.Solicitudes.fnDraw();
                            //app.closeCurrentTab();

                           // var manager = app.getManager("Solicitudes");
                            that.ViewEditar.Detalle.refrescar();
                            //manager.ViewEditarActuacion.Modal.cerrar();
                            //manager.ViewCrear.Legajo.focus();
                            app.modal.cerrar();
                            //app.irATab(0);
                        }
                    });
                    
                });

            };

            /*MisPedidosManager.prototype.eliminar_dtMisPedidos = function (id) {
                var res = new Resultado();
                this.eliminar("Administracion/MisPedidos/Eliminar", { id: id }, res);
                if (res.estado)
                    this.ViewIndex.MisPedidos.fnDraw();
            };*/
                      
           
            //-- Método para pasar Vistas por Post según URL de formulario
            SolicitudesManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
                        app.Desbloquear();
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

            SolicitudesManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
                    

            SolicitudesManager.prototype.daysInMonth = function (month, year) {
                return new Date(year, month, 0).getDate();
            };

            SolicitudesManager.prototype.getDaysInMonth = function (m, y) {
                return /8|3|5|10/.test(--m) ? 30 : m == 1 ? (!(y % 4) && y % 100) || !(y % 400) ? 29 : 28 : 31;
            };

            return SolicitudesManager;
        })();
        ts.SolicitudesManager = SolicitudesManager; //JS	
    })(ts = Solicitudes.ts || (Solicitudes.ts = {}));
})(Solicitudes || (Solicitudes = {}));
