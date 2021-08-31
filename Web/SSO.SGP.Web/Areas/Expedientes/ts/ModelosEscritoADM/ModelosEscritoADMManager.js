/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var ModelosEscritoADM;
(function (ModelosEscritoADM) {
    var ts;
    (function (ts) {
        var ModelosEscritoADMManager = /** @class */ (function () {
            function ModelosEscritoADMManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            ModelosEscritoADMManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ModelosEscritoADMManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Oficina.find("option[value=" + app.global.organismo + "]").prop("selected", "selected");
                v.Oficina.trigger("liszt:updated");
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    tinymce.triggerSave();
                    var data = v.form.serializeObject();
                    that.ajaxPostURL("ModelosEscritoADM/Crear", data, "Guardar Modelo", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewIndex.ModelosEscritoADM.fnDraw();
                            app.irATab(0);
                            v.limpiar();
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    tinymce.triggerSave();
                    that.ajaxPost(that.ViewCrear, "Guardar Modelo", resultado).done(function () {
                        that.ViewCrear.limpiar();
                        v.Titulo.focus();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            ModelosEscritoADMManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista			
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    tinymce.triggerSave();
                    var data = v.form.serializeObject();
                    that.ajaxPostURL("ModelosEscritoADM/Editar", data, "Guardar Modelo", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewIndex.ModelosEscritoADM.fnDraw();
                            app.closeCurrentTab();
                            app.irATab(0);
                        }
                    });
                });
            };
            //--- Función editar de Datatable ModelosEscritoADM
            ModelosEscritoADMManager.prototype.editar_dtModelosEscritoADM = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "Expedientes/ModelosEscritoADM/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable ModelosEscritoADM
            ModelosEscritoADMManager.prototype.eliminar_dtModelosEscritoADM = function () {
                var self = this;
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("ModelosEscritoADM/Eliminar", { id: id }, resultado).done(function () {
                    if (resultado.estado)
                        self.ViewIndex.ModelosEscritoADM.fnDraw();
                });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            ModelosEscritoADMManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
                                resultado.anexos.texto = data[3];
                                resultado.anexos.modelo = data[4];
                                resultado.anexos.fecha = data[5];
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
            ModelosEscritoADMManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            ModelosEscritoADMManager.prototype.eliminar = function (url, data, resultado) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar este modelo?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                resultado.estado = data[0];
                                resultado.mensaje = data[1];
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
            return ModelosEscritoADMManager;
        }()); //JS	
        ts.ModelosEscritoADMManager = ModelosEscritoADMManager;
    })(ts = ModelosEscritoADM.ts || (ModelosEscritoADM.ts = {}));
})(ModelosEscritoADM || (ModelosEscritoADM = {}));
