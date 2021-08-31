/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="EnviarNotificaciones.ts"/>
module ConcursosDeIngreso.ts {

    export class ConcursosDeIngresoManager {

        public ViewIndex: Index;
        public ViewCrear: Crear;
        public ViewEditar: Crear;
        public ViewEnviar: EnviarNotificaciones;

        constructor() {
            //this.initHandler();
        }

        public setIndex(v: Index) { 
            var self = this;
            this.ViewIndex = v;
        }

        public setEnviar(v: EnviarNotificaciones) {
            var self = this;
            this.ViewEnviar = v;

            v.Cancelar.click(function (e) {
                app.modal.cerrar();
            });

            v.Enviar.click(function (e) {
                v.Enviar.hide();
                app.Bloquear();
                $.ajax({
                    type: "POST",
                    url: "RRHH/ConcursosDeIngreso/EnviarNotificaciones",
                    data: v.form.serialize(),
                    success: function (data) {                       
                        if (data[0]) {
                            app.crearNotificacionSuccess("OK", data[1]);
                        } else {
                            app.crearNotificacionError("Error", data[1]);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");                     
                    },
                    complete: function () {
                        app.Desbloquear();
                        app.modal.cerrar();
                    }
                });
            });
        }

        public editar_dtConcursosDeIngreso(el): void {
            this.ViewIndex.selectRow_ConcursosDeIngreso(el);
            var id = this.ViewIndex.getData_ConcursosDeIngreso(0);
            app.createTab("Editar", "RRHH/ConcursosDeIngreso/Editar/" + id, true, true, true);
        }
        public eliminar_dtConcursosDeIngreso(el): void {
            this.ViewIndex.selectRow_ConcursosDeIngreso(el);
            var id = this.ViewIndex.getData_ConcursosDeIngreso(0);
            this.eliminar("ConcursosDeIngreso/Eliminar", { id: id });
        }
        public inscriptos_dtConcursosDeIngreso(el): void {
            this.ViewIndex.selectRow_ConcursosDeIngreso(el);
            var id = this.ViewIndex.getData_ConcursosDeIngreso(0);
            //this.eliminar("ConcursosDeIngreso/Eliminar", { id: id }); 
            app.createTab("Inscriptos", "RRHH/ConcursosDeIngresoInscripciones/Index/"+id, true, true, true);
        }
        public enviar_dtConcursosDeIngreso(el): void {
            this.ViewIndex.selectRow_ConcursosDeIngreso(el);
            var id = this.ViewIndex.getData_ConcursosDeIngreso(0);
            //this.eliminar("ConcursosDeIngreso/Eliminar", { id: id }); 
            app.modal.cargar("Enviar Notificaciones", "RRHH/ConcursosDeIngreso/EnviarNotificaciones/" + id);
        }
        public evaluaciones_dtConcursosDeIngreso (el): void {
            this.ViewIndex.selectRow_ConcursosDeIngreso(el);
            var id = this.ViewIndex.getData_ConcursosDeIngreso(0);
            //this.eliminar("ConcursosDeIngreso/Eliminar", { id: id }); 
           // app.createTab("Inscriptos", "RRHH/ConcursosDeIngresoInscripciones/Index/" + id, true, true, true);
            app.modal.cargar("Evaluación", "RRHH/ConcursosDeIngreso/Evaluaciones/" + id);
        }

        public setCrear(v: Crear) {
            var self = this;
            this.ViewCrear = v;

            v.Cancelar.click(function (e) {
                self.ViewCrear.limpiar(); app.irATab(0);
            });
            v.Guardar.click(function (e) {
                console.log("se presiona guardar");
                var resultado = new Resultado(); self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () { self.ViewIndex.ConcursosDeIngreso.fnDraw(); self.ViewCrear.limpiar(); app.irATab(0); });
            });
            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado(); self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () {
                    self.ViewCrear.limpiar(); //self.ViewCrear.Descripcion.focus(); 
                });
            });

        }


        public setEditar(v: Crear) {
            var self = this;
            this.ViewEditar = v;            

            $.get("/RRHH/ConcursosDeIngreso/GetShortURL/?longurl=" + v.Url.html()).done(function (data) {
                v.Url.html(data.Id);
            });

            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                self.ajaxPost(self.ViewEditar, "Resultado", resultado).done(function () {
                    app.closeCurrentTab();
                    self.ViewIndex.ConcursosDeIngreso.fnDraw();
                    app.irATab(0);
                });
            });

        }



        public ajaxPost(v: IControlador, titulo: string, resultado: Resultado): JQueryDeferred<any> {
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
           // }
            return (df.promise());
        }

        public ajaxPostURL(url: string, data: any, titulo: string, res?: Resultado): JQueryDeferred<any> {
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

        public eliminar(url: string, data: any): JQueryDeferred<any> {
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
                                that.ViewIndex.ConcursosDeIngreso.fnDraw();
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