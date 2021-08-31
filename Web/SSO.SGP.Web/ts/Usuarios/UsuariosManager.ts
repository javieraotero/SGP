
/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="EditarRoles.ts"/>
/// <reference path="CambiarClave.ts"/>
/// <reference path="InformarIncidencia.ts"/>
/// <reference path="../types/editable.d.ts"/>
module Usuarios.ts {

    export class UsuariosManager {

        public ViewIndex: Index;
        public ViewCrear: Crear;
        public ViewEditar: Editar;
        public ViewEditarRoles: EditarRoles;
        public ViewCambiarClave: CambiarClave;
        public ViewInformarIncidencia: InformarIncidencia;
        public Modal: SyncroModal;

        constructor() {
            // Constructor
            this.Modal = new SyncroModal($("#ModalLayout"));
        }
	
        //--- Inicialización de la vista Index
        public setIndex(v: Index) { 
            var that = this;
            this.ViewIndex = v;
            // Eventos de la vista			
        }

        public setInformarIncidencia(v: InformarIncidencia) {
            var that = this;
            this.ViewInformarIncidencia = v;

            v.Guardar.click(function (e) {
                v.Guardar.hide();
                var resultado = new Resultado();
                that.ajaxPostJson(that.ViewInformarIncidencia, "Informar Incidencia", resultado).done(function () {
                    if (resultado.estado) {
                        app.modal.cerrar();
                        //that.ViewIndex.Usuarios.fnDraw();
                    } else {
                        v.Guardar.show();
                    }
                });
            });

            v.Cancelar.click(function (e) {
                app.modal.cerrar();
            });

        }

        //--- Inicialización de la vista CambiarClave
        public setCambiarClave(v: CambiarClave) {
            var that = this;
            this.ViewCambiarClave = v;
            // Eventos de la vista
            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                $.when(that.ajaxPost(v, "Cambiar Clave", resultado)).done(function () {
                    if (resultado.estado) {
                        app.modal.cerrar();
                    }
                });
            });

            v.Cancelar.click(function (e) {
                that.Modal.cerrar();
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
                that.crear(that.ViewCrear, "Nuevo usuario", resultado).done(function () {
                    if (resultado.estado) {
                        that.ViewIndex.Usuarios.fnDraw();
                        that.ViewCrear.limpiar();
                        app.irATab(0);
                    }
                });
            });

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewCrear, "Modificar título", resultado).done(function () {
                    that.ViewCrear.limpiar();
                    that.ViewCrear.ApellidoYNombre.focus();
                });
            });

            v.BuscarPersona.click(function (e) {
                console.log("buscar persona");
                app.modal.setearTitulo("Seleccionar Persona");
                app.modal.loadAjax("Personas/Buscar/?usuario=true");
                app.modal.mostrar();
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
                that.ajaxPost(that.ViewEditar, "Actualizar Usuario", resultado).done(function () {
                    if (resultado.estado) {
                        app.closeCurrentTab();
                        app.irATab(0);
                        that.ViewIndex.Usuarios.fnDraw();
                    }
                });
            });

            v.Resetear.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPostURL("Usuarios/ResetearClave", { usuario: v.NombreUsuario.val() }, "Resetear Password", resultado);
            });

        }
	
        //--- Inicialización de la vista EditarRoles
        public setEditarRoles(v: EditarRoles) {
            var that = this;
            this.ViewEditarRoles = v;
            // Eventos de la vista
			
            v.Cancelar.click(function (e) {
                that.ViewIndex.modal.cerrar();
            });

        }
	
        //--- Función editar de Datatable Usuarios
        public editar_dtUsuarios(id: number): void {
            app.createTab("Editar", "Usuarios/Editar/" + id, true, true, true);
        }
		
        //--- Función eliminar de Datatable Usuarios
        public eliminar_dtUsuarios(id: number): void {
            this.eliminar("Usuarios/Eliminar", { id: id });
        }

        public editarRoles_dtUsuarios(id: number): void {
            //app.createTab("Editar Roles", "Usuarios/EditRoles/" + id, true, true, true);
            id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(1);
            //var i = new ItemMenu();
            //i.label = "Nombramientos de " + descripcion;
            //i.close = true;
            //i.url = "RRHH/Nombramientos/Index/?agente=" + id;
            //i.cache = true;
            //app.tabs.crearTab(i, true);

            app.modal.cargar("Editar Roles de " + descripcion, "Usuarios/EditarRoles/" + id);
        }

        public resetearClave_dtUsuarios(id: number): void {
            var usuario = this.ViewIndex.getData(2);
            this.resetearClave("Usuarios/resetearclave", { usuario: usuario });
        }

        public marcarRol(el: Element) {
            var resultado = new Resultado();
            var nomRol = $(el).data("id");
            var idUsu = this.ViewEditarRoles.IdUsuario.val(); //Aca le estabas pasando  this.ViewEditarRoles.IdUsuario... le estabas pasando un control HTML... 

            if ($(el).prop("checked"))
                $.when(this.ajaxPostURL("Usuarios/AsignarRol", { idUsuario: idUsu, nombreRol: nomRol }, "Roles", resultado)).done(function () { });
            else
                $.when(this.ajaxPostURL("Usuarios/DeleteRol", { idUsuario: idUsu, nombreRol: nomRol }, "Roles", resultado)).done(function () { });

        }
	
        //-- Método para pasar Vistas por Post según URL de formulario
        public ajaxPost(v: IControlador, titulo: string, resultado?: Resultado): JQueryDeferred {
            var that = this;
            //var resultado = new Resultado();
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

        //-- Método para pasar Vistas por Post según URL de formulario
        public crear(v: IControlador, titulo: string, resultado?: Resultado): JQueryDeferred {
            var that = this;
            //var resultado = new Resultado();
            var df = $.Deferred();
            v.form.validate();
            var success = false;
            var retorno: number = 0;

            var usuario = {
                ApellidoYNombre: that.ViewCrear.ApellidoYNombre.val(),
                Usuario: that.ViewCrear.Usuario.val(),
                Correo: that.ViewCrear.Correo.val(),
                OrganismoUltimoIngreso: that.ViewCrear.Organismo.val(),
                Estado: that.ViewCrear.Estado.val(),
                Circunscripcion: that.ViewCrear.Circunscripcion.val(),
                Persona: that.ViewCrear.Persona.val(),
                Cargo: that.ViewCrear.Cargo.val()
            };

            if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    url: "Usuarios/Crear",
                    data: JSON.stringify({ usuario: usuario}),
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

        public ajaxPostJson(v: IControlador, titulo: string, resultado?: Resultado): JQueryDeferred {
            var that = this;
            //var resultado = new Resultado();
            var df = $.Deferred();
           
            var success = false;
            var retorno: number = 0;
            //if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "/usuarios/informarincidencia",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({ titulo: that.ViewInformarIncidencia.Titulo.val(), descripcion: that.ViewInformarIncidencia.Descripcion.val(), vista: app.current_view}),
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
            bootbox.confirm("¿Confirma que desea activar/desactivar a este usuario?", function (result) {
                if (result) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: url,
                        data: data,
                        success: function (data) {
                            if (data[0]) {
                                app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                that.ViewIndex.Usuarios.fnDraw();
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

        public resetearClave(url: string, data: any): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            bootbox.confirm("¿Confirma que desea resetear la clave a este usuario?", function (result) {
                if (result) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: url,
                        data: data,
                        success: function (data) {
                            if (data[0]) {
                                app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                that.ViewIndex.Usuarios.fnDraw();
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