/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
module LicenciasRef.ts {

    export class LicenciasRefManager {

        public ViewIndex: Index;
        public ViewCrear: Crear;
        public ViewEditar: Editar;

        constructor() {
            // Constructor
        }

        //--- Inicialización de la vista Index
        public setIndex(v: Index) {
            var that = this;
            this.ViewIndex = v;
            // Eventos de la vista

            v.Nuevo.click(function (e) {
                v.modal.cargar("Nueva Licencia", "RRHH/LicenciasRef/Crear");
            });

        }

        //--- Inicialización de la vista Crear
        public setCrear(v: Crear) {
            var that = this;
            this.ViewCrear = v;
            // Eventos de la vista

            v.Cancelar.click(function (e) {
                app.irATab(0);
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewCrear, "Guardar Licencia", resultado).done(function () {
                    if (resultado.estado) {
                        that.ViewIndex.LicenciasRef.fnDraw();
                        that.ViewIndex.modal.cerrar();
                    }                        
                });
            });

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewCrear, "Guardar Licencia", resultado).done(function () {
                    if (resultado.estado) {
                        that.ViewCrear.limpiar();
                        that.ViewIndex.LicenciasRef.fnDraw();
                    }
                });
            });

        }

        //--- Inicialización de la vista Editar
        public setEditar(v: Editar) {
            var that = this;
            this.ViewEditar = v;
            // Eventos de la vista

            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewEditar, "Actualizar Licencia", resultado).done(function () {
                    if (resultado.estado) {
                        that.ViewIndex.modal.cerrar();
                        that.ViewIndex.LicenciasRef.fnDraw();
                    }
                });
            });

        }

        //--- Función editar de Datatable LicenciasRef
        public editar_dtLicenciasRef(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(1);
            this.ViewIndex.modal.cargar("Editar Licencia " + descripcion, "RRHH/LicenciasRef/Editar/" + id);
        }

        //--- Función eliminar de Datatable LicenciasRef
        public eliminar_dtLicenciasRef(): void {
            var id = this.ViewIndex.getData(0);
            this.eliminar("RRHH/LicenciasRef/Eliminar", { id: id });
        }


        //-- Método para pasar Vistas por Post según URL de formulario
        public ajaxPost(v: IControlador, titulo: string, resultado?:Resultado): JQueryDeferred {
            var that = this;
            var resultado = new Resultado();
            var df = $.Deferred();
            v.form.validate();
            var success = false;
            var retorno: number = 0;
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
                })).done(function () { df.resolve() })
                    .fail(function () { df.reject() }); //end ajax
            }
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

    }//JS	
}