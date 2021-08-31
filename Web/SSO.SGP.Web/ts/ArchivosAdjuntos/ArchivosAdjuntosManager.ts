/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="File.ts"/>
module ArchivosAdjuntos.ts {

    export class ArchivosAdjuntosManager {

        public ViewIndex: Index;
        public ViewCrear: Crear;
        public ViewEditar: Editar;
        public ViewFile: File;

        constructor() {
            //this.initHandler();
        }

        public setFile(v: File) {
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

        }

        public setIndex(v: Index) {
            var self = this;
            this.ViewIndex = v;
        }

        public abrir_dtArchivosAdjuntos(agente): void {
            var id = this.ViewIndex.getData_ArchivosAdjuntos(0);
            var archivo = this.ViewIndex.getData_ArchivosAdjuntos(1);
            window.open("/files/" + agente + "_" + archivo);
        }

        public editar_dtArchivosAdjuntos(): void {
            var id = this.ViewIndex.getData_ArchivosAdjuntos(0);
            app.createTab("Editar", "ArchivosAdjuntos/Editar/" + id, true, true, true);
        }
        public eliminar_dtArchivosAdjuntos(): void {
            var id = this.ViewIndex.getData_ArchivosAdjuntos(0);
            this.eliminar("/RRHH/Agentes/EliminarAdjunto", { id: id });
        }

        public setCrear(v: Crear) {
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

        }


        public setEditar(v: Editar) {
            var self = this;
            this.ViewEditar = v;

            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
            });
            v.Guardar.click(function (e) {
                var resultado = new Resultado(); self.ajaxPost(self.ViewEditar, "Resultado", resultado).done(function () { self.ViewIndex.ArchivosAdjuntos.fnDraw(); self.ViewCrear.limpiar(); app.irATab(0); });
            });

        }



        public ajaxPost(v: IControlador, titulo: string, resultado: Resultado): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            //v.form.validate();
            var success = false;
            var retorno: number = 0;
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
                })).done(function () { df.resolve() })
                    .fail(function () { df.reject() }); //end ajax
            //}
            return (df.promise());
        }

        public ajaxPostURL(url: string, data: any, titulo: string, res?: Resultado): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            var success = false;
            var retorno: number = 0;
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
            })).done(function () { df.resolve() })
                .fail(function () { df.reject() }); //end ajax
            return (df.promise());
        }

        public eliminar(url: string, data: any): JQueryDeferred {
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
                    })).done(function () { df.resolve() })
                        .fail(function () { df.reject() });
                }
            });
            return (df.promise());
        }
    } //JS
} // module