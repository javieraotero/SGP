/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var ActuacionesADM;
(function (ActuacionesADM) {
    var ts;
    (function (ts) {
        var ActuacionesADMManager = /** @class */ (function () {
            function ActuacionesADMManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            ActuacionesADMManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ActuacionesADMManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.ModeloAplicado.change(function (e) {
                    $.get("Expedientes/ModelosEscritoadm/gettext/?id=" + v.ModeloAplicado.val(), null, function (data) {
                        tinyMCE.activeEditor.setContent(data);
                    });
                    v.Descripcion.val(v.ModeloAplicado.find("option:selected").text());
                    var today = new Date();
                    var dd = today.getDate();
                    var mm = today.getMonth() + 1; //January is 0!
                    var yyyy = today.getFullYear();
                    if (dd < 10) {
                        dd = '0' + dd;
                    }
                    if (mm < 10) {
                        mm = '0' + mm;
                    }
                    //today = dd + '/' + mm + '/' + yyyy;
                    v.Fecha.val(dd + '/' + mm + '/' + yyyy);
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    tinyMCE.triggerSave();
                    that.ajaxPost(that.ViewCrear, "Resultado", resultado).done(function () {
                        var id = resultado.id;
                        if (resultado.estado) {
                            app.getData("Expedientes/Expedientesadm/getdata", { id: v.Expediente.val() }).then(function (e) {
                                var expediente = e;
                                var editor = new FormatEditor(that.ViewCrear.Expediente.val(), parseInt(v.ModeloAplicado.val()), id);
                                editor.test();
                                app.modal.cerrar();
                                app.tabs.reloadCurrent();
                            });
                        }
                    });
                });
                v.tr_imputacion.click(function (e) {
                    v.tr_imputacion.each(function (row, z) {
                        $(row).removeClass("seleccionado");
                    });
                    var tr = $(this);
                    $(this).addClass("seleccionado");
                    app.getData("Expedientes/Expedientesadm/getdata2", { id: v.Expediente.val(), imputacion: tr.data("id") }).then(function (e) {
                        var expediente = e;
                        var id = tr.data("id");
                        //console.log("Id de imputacion generada: " + id); 
                        var editor = new FormatEditor(expediente, parseInt(v.ModeloAplicado.val()), id);
                        editor.test();
                        //app.modal.cerrar();   
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            ActuacionesADMManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    tinyMCE.triggerSave();
                    that.actualizarActuacion(that.ViewEditar, "Resultado", resultado).done(function () {
                        var id = resultado.id;
                        if (resultado.estado) {
                            app.modal.cerrar();
                            app.tabs.reloadCurrent();
                            //app.getData("Expedientes/Expedientesadm/getdata", { id: v.Expediente.val() }).then(function (e) {
                            //    var expediente = e;
                            //    var editor = new FormatEditor(that.ViewCrear.Expediente.val(), parseInt(v.ModeloAplicado.val()), id);
                            //    editor.test();
                            //    app.modal.cerrar();
                            //    app.tabs.reloadCurrent();
                            //});
                        }
                    });
                });
            };
            //--- Función editar de Datatable ActuacionesADM
            ActuacionesADMManager.prototype.editar_dtActuacionesADM = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "ActuacionesADM/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable ActuacionesADM
            ActuacionesADMManager.prototype.eliminar_dtActuacionesADM = function () {
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("ActuacionesADM/Eliminar", { id: id }, resultado);
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ActuacionesADMManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
                                if (that.ViewCrear) {
                                    if (that.ViewCrear.OrganismoCargo.val() != "0") {
                                        app.hub.server.enviarNotificacion("Se ha recibido un nuevo cargo", that.ViewCrear.OrganismoCargo.val());
                                    }
                                }
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
            ActuacionesADMManager.prototype.actualizarActuacion = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: "/Expedientes/ActuacionesADM/Editar",
                        data: v.form.serialize(),
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                //resultado.id = data[2];
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
            ActuacionesADMManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            ActuacionesADMManager.prototype.eliminar = function (url, data, resultado) {
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
            return ActuacionesADMManager;
        }()); //JS	
        ts.ActuacionesADMManager = ActuacionesADMManager;
    })(ts = ActuacionesADM.ts || (ActuacionesADM.ts = {}));
})(ActuacionesADM || (ActuacionesADM = {}));
