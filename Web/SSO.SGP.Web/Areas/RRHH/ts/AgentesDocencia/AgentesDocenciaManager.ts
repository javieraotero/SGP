
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="Eliminar.ts"/>
/// <reference path="Detalle.ts"/>
module AgentesDocencia.ts {

    export class AgentesDocenciaManager {

        public ViewIndex: Index;
        public ViewCrear: Crear;
        public ViewEditar: Crear;
        public ViewEliminar: Eliminar;
        public ViewDetalle: Detalle;

        constructor() {
            // Constructor
        }
	
        //--- Inicialización de la vista Index
        public setIndex(v: Index) {
            var that = this;
            this.ViewIndex = v;
            // Eventos de la vista
			
            v.Nuevo.click(function (e) {
                e.preventDefault();
                app.modal.cargar("Nuevo informe de docencia","RRHH/AgentesDocencia/Crear/" + v.Agente.val());
            });
        }
	
        //--- Inicialización de la vista Crear
        public setCrear(v: Crear) {
            var that = this;
            this.ViewCrear = v;
            // Eventos de la vista
			
            v.Cancelar.click(function (e) {
                app.modal.cerrar();
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewCrear, "Resultado", resultado).done(function () {
                    if (resultado.estado) {
                        app.modal.cerrar();
                        that.ViewIndex.AgentesDocencia.fnDraw();
                    }                        
                });
            });

        }
	
        //--- Inicialización de la vista Editar
        public setEditar(v: Crear) {
            var that = this;
            this.ViewEditar = v;
            // Eventos de la vista
			
            v.Cancelar.click(function (e) {
                app.modal.cerrar();
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewEditar, "Resultado", resultado).done(function () {
                    if (resultado.estado) {
                        app.modal.cerrar();
                        that.ViewIndex.AgentesDocencia.fnDraw();
                    }                        
                });
            });

        }
	
        //--- Inicialización de la vista Eliminar
        public setEliminar(v: Eliminar) {
            var that = this;
            this.ViewEliminar = v;
            // Eventos de la vista
			
        }
	
        //--- Inicialización de la vista Detalle
        public setDetalle(v: Detalle) {
            var that = this;
            this.ViewDetalle = v;
            // Eventos de la vista
			
        }
	
        //--- Función editar de Datatable AgentesDocencia
        public editar_dtAgentesDocencia(): void {
            var id = this.ViewIndex.getData(0);
            app.modal.cargar("Editar", "RRHH/AgentesDocencia/Editar/" + id);
        }
		
        //--- Función eliminar de Datatable AgentesDocencia
        public eliminar_dtAgentesDocencia(): void {
            var id = this.ViewIndex.getData(0);
            var resultado = new Resultado();
            this.eliminar("AgentesDocencia/Eliminar", { id: id }, resultado);
        }
		
	
        //-- Método para pasar Vistas por Post según URL de formulario
        public ajaxPost(v: IControlador, titulo: string, resultado?: Resultado): JQueryDeferred {
            var that = this;
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

        public eliminar(url: string, data: any, resultado: Resultado): JQueryDeferred {
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
                            res.Mensaje(data[1]);
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