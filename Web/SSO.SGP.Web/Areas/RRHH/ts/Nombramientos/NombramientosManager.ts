/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
module Nombramientos.ts {

    export class NombramientosManager {

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

            //refresca la grilla con los nombramientos del agente
            v.Nombramientos.refrescar("RRHH/Nombramientos/JsonT/?agente=" + v.Agente.val());
            v.Nombramientos.setearSeleccionable(true);

            $.contextMenu({
                selector: "#" + that.ViewIndex.Nombramientos.Id,
                items: {
                    "Movmientos": {
                        name: "Movimientos",
                        callback: function () {
                            v.Movimientos.refrescar("RRHH/NombramientosMovimientos/JsonT/?nombramiento=" + that.ViewIndex.Nombramientos.id);
                        }
                    },
                    "Bajar": {
                        name: "Bajar",
                        callback: function () {
                            $.when(that.eliminar("RRHH/Nombramientos/Eliminar", { id: that.ViewIndex.Nombramientos.id }))
                                .done(function () { that.ViewIndex.Nombramientos.refrescar() });
                        }
                    },
                    "Editar": {
                        name: "Editar",
                        callback: function () {
                            v.Modal.setearTitulo("Editar Nombramiento");
                            v.Modal.loadAjax("RRHH/Nombramientos/Editar/?id=" + v.Nombramientos.id);
                            v.Modal.mostrar();
                        }
                    }
                }
            });

            v.Movimientos.setearSeleccionable(true);


            $.contextMenu({
                selector: "#" + v.Movimientos.Id,
                items: {
                    "Eliminar": {
                        name: "Eliminar",
                        callback: function () {
                            if (!(v.Movimientos.id > 0)) {
                                app.crearNotificacionInfo("ATENCION","Debe primero seleccionar un movimiento!");
                            } else {
                                $.when(that.eliminar("NombramientosMovimientos/Eliminar", { id: v.Movimientos.id })).done(function () {
                                    v.Movimientos.refrescar("RRHH/NombramientosMovimientos/JsonT/?nombramiento=" + that.ViewIndex.Nombramientos.id);
                                });
                            }
                        }
                    },
                    "Editar": {
                        name: "Editar",
                        callback: function () {
                            if (!(v.Movimientos.id > 0)) {
                                app.crearNotificacionInfo("ATENCION", "Debe primero seleccionar un movimiento!");
                            } else {
                                v.Modal.cargar("Editar Movimiento", "RRHH/NombramientosMovimientos/Editar/" + v.Movimientos.id);
                            }
                        }
                    }
                }
            });

            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
                app.irATab(0);
            });

            v.Nuevo.click(function (e) {
                //app.createTab("Nuevo Nombramiento", "Nombramientos/Crear/?agente="+v.Agente.val(), true, true, true);
                v.Modal.setearTitulo("Nuevo Nombramiento");
                v.Modal.loadAjax("RRHH/Nombramientos/Crear/?agente=" + v.Agente.val());
                v.Modal.mostrar();
            });

            v.Movimiento.click(function (e) {
                v.Modal.setearTitulo("Informar Movimiento");
                v.Modal.loadAjax("RRHH/NombramientosMovimientos/Crear/?nombramiento=" + that.ViewIndex.Nombramientos.id);
                v.Modal.mostrar();
            });

            // Eventos de la vista
        }

        //--- Inicialización de la vista Crear
        public setCrear(v: Crear) {
            var that = this;
            this.ViewCrear = v;
            // Eventos de la vista

            v.Cancelar.click(function (e) {
                that.ViewIndex.Modal.cerrar();
            });

            v.Guardar.click(function (e) {
                var res = new Resultado();
                that.ajaxPost(that.ViewCrear, "Guardar Nombramiento", res).done(function () {
                    if (res.estado) {
                        that.ViewIndex.Modal.cerrar();
                        that.ViewIndex.Nombramientos.refrescar();
                    }

                });
            });

            v.TodosLosOrganismos.change(function (e) {
                $.get("Nombramientos/JsonTodosLosOrganismos", {todos: this.checked}, function (data) {
                    v.Organismo.empty();
                    $.each(data, function (index, el) {
                        v.Organismo.append("<option value='" + el.value + "'>" + el.text + "</value>");
                    });
                    v.Organismo.trigger("liszt:updated");
                });
            });

            v.GuardarYNuevo.click(function (e) {
                var res = new Resultado();
                that.ajaxPost(that.ViewCrear, "Guardar Nombramiento", res).done(function () {
                    if (res.estado) {
                        v.limpiar();
                        that.ViewIndex.Nombramientos.refrescar();
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
                that.ViewIndex.Modal.cerrar();
            });

            v.TodosLosOrganismos.change(function (e) {
                $.get("Nombramientos/JsonTodosLosOrganismos", { todos: this.checked }, function (data) {
                    v.Organismo.empty();
                    $.each(data, function (index, el) {
                        v.Organismo.append("<option value='" + el.value + "'>" + el.text + "</value>");
                    });
                    v.Organismo.trigger("liszt:updated");
                });
            });

            v.Guardar.click(function (e) {
                var res = new Resultado();
                that.ajaxPost(that.ViewEditar, "Guardar Nombramiento", res).done(function () {
                    if (res.estado) {
                        that.ViewIndex.Modal.cerrar();
                        that.ViewIndex.Nombramientos.refrescar();
                    }
                });
            });

        }


        //-- Método para pasar Vistas por Post según URL de formulario
        public ajaxPost(v: IControlador, titulo: string, res?: Resultado): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            v.form.validate();
            var success = false;
            var retorno: number = 0;
            //if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: v.form.attr("action"),
                    data: v.form.serialize(),
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