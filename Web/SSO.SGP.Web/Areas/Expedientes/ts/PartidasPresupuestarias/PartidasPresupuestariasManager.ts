/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>

module PartidasPresupuestarias.ts {

    export class PartidasPresupuestariasManager {

        public ViewIndex: Index;
        public ViewCrear: Crear;
        public ViewEditar: Crear;

        constructor() {
            // Constructor
            console.log("constructor");
        }

        //--- Inicialización de la vista Index
        public setIndex(v: Index) {
            var that = this;
            this.ViewIndex = v;
            // Eventos de la vista

            v.Nuevo.click(function(e) {
                app.modal.cargar("Nueva Partida Presupuestaria", "/Expedientes/PartidasPresupuestarias/Crear");
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

            v.AsociarDivision.click(function (e) {
                v.Modal.cargar("Asociar División", "/Expedientes/DivisionesExtraPresupuestarias/Crear");
            });

            v.AgregarDivision.click(function(e) {
                e.preventDefault();
                $("#detalledivision").append("<tr><td>"+v.NombreDivision.val()+"</td><td>"+v.CodigoCesida.val()+"</td><td><button class='btn btn-xs red' data-type='quitardivision'>quitar</button</td></tr>");
            });


            $("button[data-type=quitardivision]").live("click", function(e) {
                e.preventDefault();
                $(this).closest("tr").remove();
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();

                $("#detalledivision").find("tr").each(function(i,value) {
                    var d = new Divisiones();
                    d.Id = $(this).data("id") ? $(this).data("id") : 0;
                    d.Nombre = $(value).find("td:eq(0)").html();
                    d.CodigoCESIDA = $(value).find("td:eq(1)").html();
                    
                    v.adivisiones.push(d);
                });

                var data = v.form.serializeObject();
                data.Divisiones = v.adivisiones;

                that.ajaxPostURL("/Expedientes/PartidasPresupuestarias/Crear",data, "Guardar Partida", resultado).done(function () {
                    if (resultado.estado)
                        app.modal.cerrar();
                });
            });

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewCrear, "Guardar Partida", resultado).done(function () {
                    if (resultado.estado) {
                        that.ViewCrear.limpiar();
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
                app.closeCurrentTab();
                //that.ViewIndex.Modal.cerrar();
                //that.ViewIndex.PartidasPresupuestarias.fnDraw();
            });

            v.Guardar.click(function (e) {

                var resultado = new Resultado();

                $("#detalledivision").find("tr").each(function (i, value) {
                    var d = new Divisiones();
                    d.Id = $(this).data("id") ? $(this).data("id") : 0;
                    d.Nombre = $(value).find("td:eq(0)").html();
                    d.CodigoCESIDA = $(value).find("td:eq(1)").html();

                    v.adivisiones.push(d);
                });

                var data = v.form.serializeObject();
                data.Divisiones = v.adivisiones;

                that.ajaxPostURL("/Expedientes/PartidasPresupuestarias/Crear", data, "Guardar Partida", resultado).done(function () {
                    if (resultado.estado) {
                        app.modal.cerrar();
                        that.ViewIndex.PartidasPresupuestarias.fnDraw();
                    }
                });

                //var resultado = new Resultado();
                //that.ajaxPost(that.ViewEditar, "Actualizar Partida", resultado).done(function () {
                //    if (resultado.estado) {
                //        app.modal.cerrar();
                //        that.ViewIndex.PartidasPresupuestarias.fnDraw();
                //    }
                //});
            });

        }

        //--- Función editar de Datatable PartidasPresupuestarias
        public editar_dtPartidasPresupuestarias(): void {
            var id = this.ViewIndex.getData(0);
            var numero = this.ViewIndex.getData(1);

            app.modal.cargar("Editar Partida "+numero, "/Expedientes/PartidasPresupuestarias/Editar/"+id );
        }

        //--- Función eliminar de Datatable PartidasPresupuestarias
        public eliminar_dtPartidasPresupuestarias(): void {
            var id = this.ViewIndex.getData(0);
            var resultado = new Resultado();
            this.eliminar("/Expedientes/PartidasPresupuestarias/Eliminar", { id: id }, resultado);
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

        public agregarDivision(a: Divisiones) {
            this.ViewCrear.adivisiones.push(a);
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
                contentType: 'application/json',
                data: JSON.stringify(data),
                //traditional:true,
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
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                that.ViewIndex.PartidasPresupuestarias.fnDraw();
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

    export class Divisiones {

        public Id: number;
        public Nombre: string;
        public CodigoCESIDA: string;
        public PartidaPresupuestaria: string;
        //public nuevo: boolean;

    }

}