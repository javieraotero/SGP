/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="File.ts"/>
var ArchivosAdjuntos;
(function (ArchivosAdjuntos) {
    var ts;
    (function (ts) {
        var ArchivosAdjuntosManager = (function () {
            function ArchivosAdjuntosManager() {
                //this.initHandler();
            }
            ArchivosAdjuntosManager.prototype.setFile = function (v) {
                var self = this;
                this.ViewFile = v;
                v.Guardar.click(function (e) {
                    var doc = v.Archivo.data("nombre");
                    $.get("/ArchivosAdjuntos/gethtml/?doc=" + doc, function (data) {
                        tinyMCE.activeEditor.setContent('<body class="document"><div class="page" contenteditable = "true" >' + data + '</div></body>');
                        app.modal.cerrar();
                    });
                });
                v.Cancelar.click(function (e) {
                    app.modal.cerrar();
                });
            };
            ArchivosAdjuntosManager.prototype.setIndex = function (v) {
                var self = this;
                this.ViewIndex = v;
            };
            ArchivosAdjuntosManager.prototype.abrir_dtArchivosAdjuntos = function (agente) {
                var id = this.ViewIndex.getData_ArchivosAdjuntos(0);
                var archivo = this.ViewIndex.getData_ArchivosAdjuntos(1);
                window.open("/files/" + agente + "_" + archivo);
            };
            ArchivosAdjuntosManager.prototype.editar_dtArchivosAdjuntos = function () {
                var id = this.ViewIndex.getData_ArchivosAdjuntos(0);
                app.createTab("Editar", "ArchivosAdjuntos/Editar/" + id, true, true, true);
            };
            ArchivosAdjuntosManager.prototype.eliminar_dtArchivosAdjuntos = function () {
                var id = this.ViewIndex.getData_ArchivosAdjuntos(0);
                this.eliminar("/RRHH/Agentes/EliminarAdjunto", { id: id });
            };
            ArchivosAdjuntosManager.prototype.setCrear = function (v) {
                var self = this;
                this.ViewCrear = v;
                //console.log(typeof app.modal.obj);
                v.Cancelar.click(function (e) {
                    app.modal.cerrar();
                });
                v.Guardar.click(function (e) {
                    //var archivo = new model.ArchivosAdjuntos();
                    //archivo.Descripcion = v.Descripcion.val();
                    //archivo.Path = v.Archivo.data("nombre");
                    //archivo.Id = v.Archivo.val();
                    //var oSentenciaManager = <Sentencias.ts.SentenciasManager>app.getManager("Sentencias");
                    //app.modal.obj.Sentencia.ArchivosAdjuntos.push(archivo);
                    ////if (app.modal.obj) 
                    ////    oSentenciaManager.ViewEditar.Sentencia.ArchivosAdjuntos.push(archivo);
                    ////else
                    ////    oSentenciaManager.ViewCrear.Sentencia.ArchivosAdjuntos.push(archivo);
                    //oSentenciaManager.refrescar_archivos_editar(app.modal.obj);
                    //app.modal.cerrar();
                });
                v.GuardarYNuevo.click(function (e) {
                    //var archivo = new model.ArchivosAdjuntos();
                    //archivo.Descripcion = v.Descripcion.val();
                    //archivo.Path = v.Archivo.data("nombre");
                    //archivo.Id = v.Archivo.val();
                    //var oSentenciaManager = <Sentencias.ts.SentenciasManager>app.getManager("Sentencias");
                    //oSentenciaManager.ViewCrear.Sentencia.ArchivosAdjuntos.push(archivo);
                    //v.limpiar();
                });
            };
            ArchivosAdjuntosManager.prototype.setEditar = function (v) {
                var self = this;
                this.ViewEditar = v;
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewEditar, "Resultado", resultado).done(function () { self.ViewIndex.ArchivosAdjuntos.fnDraw(); self.ViewCrear.limpiar(); app.irATab(0); });
                });
            };
            ArchivosAdjuntosManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                //v.form.validate();
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
            ArchivosAdjuntosManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            ArchivosAdjuntosManager.prototype.eliminar = function (url, data) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar el adjunto?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: url,
                            data: data,
                            success: function (data) {
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                    that.ViewIndex.ArchivosAdjuntos.fnDraw();
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
            return ArchivosAdjuntosManager;
        })();
        ts.ArchivosAdjuntosManager = ArchivosAdjuntosManager; //JS
    })(ts = ArchivosAdjuntos.ts || (ArchivosAdjuntos.ts = {}));
})(ArchivosAdjuntos || (ArchivosAdjuntos = {})); // module
