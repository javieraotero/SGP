/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Buscar.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="../Agentes/AgentesManager.ts"/>
var Personas;
(function (Personas) {
    var ts;
    (function (ts) {
        var PersonasManager = (function () {
            function PersonasManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            PersonasManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            PersonasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.NroDocumento.blur(function (e) {
                    $.get("/Personas/existeDocumento/?documento=" + v.NroDocumento.val(), function (data) {
                        if (data.existe) {
                            v.NroDocumento.val("").focus();
                            alert("El documento ya existe!");
                        }
                    });
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Nueva Persona", resultado).done(function () {
                        if (resultado.estado)
                            v.limpiar();
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Nueva Persona", resultado).done(function () {
                        v.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Buscar
            PersonasManager.prototype.setBuscar = function (v) {
                var that = this;
                this.ViewBuscar = v;
                v.Personas.setearSeleccionable(true);
                // Eventos de la vista
                $.contextMenu({
                    selector: "#" + v.Personas.Id,
                    items: {
                        "Seleccionar": {
                            name: "Seleccionar",
                            callback: function () {
                                //obtener datos de la persona seleccionada id, nombre, apellido y domicilio
                                $.getJSON("Personas/getPersona/?id=" + v.Personas.id, null, function (data) {
                                    //Se obitne la vista de Agentes/Nuevo
                                    //var manager: Agentes.ts.AgentesManager;
                                    //Asigna la persona seleccionada a la vista de nuevo agente, focos en proximo control y cierra modal 
                                    var manager = app.getManager("Agentes");
                                    if (manager.ViewCrear) {
                                        manager.ViewCrear.DetalleAgente.show();
                                        manager.ViewCrear.detalle.text(data.apellido.trim() + ", " + data.nombre.trim() + " (Documento: " + data.documento + ")");
                                        manager.ViewCrear.PersonaId.val(data.id.toString());
                                        manager.ViewCrear.Modal.cerrar();
                                        manager.ViewCrear.Legajo.focus();
                                    }
                                    else {
                                        manager.ViewEditar.DetalleAgente.show();
                                        manager.ViewEditar.detalle.text(data.apellido.trim() + ", " + data.nombre.trim() + " (Documento: " + data.documento + ")");
                                        manager.ViewEditar.PersonaId.val(data.id.toString());
                                        manager.ViewEditar.Modal.cerrar();
                                        manager.ViewEditar.Legajo.focus();
                                    }
                                });
                            }
                        }
                    }
                });
                v.Buscar.click(function (e) {
                    v.Personas.refrescarPost(v.form.serialize(), "Personas/Buscar");
                    $.post("Personas/BuscarPersona", { documento: v.Documento.val() }, function (data) {
                        console.log(data);
                    });
                });
            };
            //--- Inicialización de la vista Buscar
            PersonasManager.prototype.setBuscarPorUsuario = function (v) {
                var that = this;
                this.ViewBuscar = v;
                v.Personas.setearSeleccionable(true);
                // Eventos de la vista
                $.contextMenu({
                    selector: "#" + v.Personas.Id,
                    items: {
                        "Seleccionar": {
                            name: "Seleccionar",
                            callback: function () {
                                //obtener datos de la persona seleccionada id, nombre, apellido y domicilio
                                $.getJSON("Personas/getPersona/?id=" + v.Personas.id, null, function (data) {
                                    //console.log("devolver a ventana usuario");
                                    //Se obitne la vista de Agentes/Nuevo
                                    var manager;
                                    //Asigna la persona seleccionada a la vista de nuevo agente, focos en proximo control y cierra modal 
                                    manager = app.getManager("Usuarios");
                                    if (manager.ViewCrear) {
                                        manager.ViewCrear.Detalle.show();
                                        manager.ViewCrear.spDetalle.text(data.apellido.trim() + ", " + data.nombre.trim() + " (Documento: " + data.documento + ")");
                                        manager.ViewCrear.IdPersona.val(data.id.toString());
                                    }
                                    else {
                                        manager.ViewEditar.Detalle.show();
                                        manager.ViewEditar.spDetalle.text(data.apellido.trim() + ", " + data.nombre.trim() + " (Documento: " + data.documento + ")");
                                        manager.ViewEditar.IdPersona.val(data.id.toString());
                                    }
                                    app.modal.cerrar();
                                });
                            }
                        }
                    }
                });
                v.Buscar.click(function (e) {
                    v.Personas.refrescarPost(v.form.serialize(), "Personas/Buscar");
                    $.post("Personas/BuscarPersona", { documento: v.Documento.val() }, function (data) {
                        console.log(data);
                    });
                });
            };
            //--- Función editar de Datatable Personas
            PersonasManager.prototype.editar_dtPersonas = function (id) {
                app.createTab("Editar", "Personas/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable Personas
            PersonasManager.prototype.eliminar_dtPersonas = function (id) {
                this.eliminar("Personas/Eliminar", { id: id });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            PersonasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                //var resultado = new Resultado();
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
            PersonasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            PersonasManager.prototype.eliminar = function (url, data) {
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
            return PersonasManager;
        })();
        ts.PersonasManager = PersonasManager; //JS	
        var Persona = (function () {
            function Persona() {
            }
            return Persona;
        })();
        ts.Persona = Persona;
    })(ts = Personas.ts || (Personas.ts = {}));
})(Personas || (Personas = {}));
