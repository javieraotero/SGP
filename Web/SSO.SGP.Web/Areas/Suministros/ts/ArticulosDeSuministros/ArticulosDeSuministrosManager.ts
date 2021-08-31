
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
module ArticulosDeSuministros.ts {

    export class ArticulosDeSuministrosManager {

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

        }

        //--- Inicialización de la vista Crear
        public setCrear(v: Crear) {
            var that = this;
            this.ViewCrear = v;

            app.setValidadorDecimal();

            // Eventos de la vista

            v.Cancelar.click(function (e) {
                app.irATab(0);
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                v.UltimoCosto.val(v.UltimoCosto.val().replace(".", ","));
                that.ajaxPost(that.ViewCrear, "Guardar", resultado).done(function () {
                    that.ViewIndex.ArticulosDeSuministros.fnDraw();
                    v.limpiar();
                    app.irATab(0);
                });
            });

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado();

                v.UltimoCosto.val(v.UltimoCosto.val().replace(".", ","));

                that.ajaxPost(that.ViewCrear, "Guardar", resultado).done(function () {
                    that.ViewIndex.ArticulosDeSuministros.fnDraw();
                    that.ViewCrear.limpiar();
                });
            });

        }

        //--- Inicialización de la vista Editar
        public setEditar(v: Editar) {
            var that = this;
            this.ViewEditar = v;

            app.setValidadorDecimal();

            // Eventos de la vista

            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();

                v.UltimoCosto.val(v.UltimoCosto.val().replace(".", ","));

                that.ajaxPost(that.ViewEditar, "Actualizar artículo", resultado).done(function () {
                    that.ViewIndex.ArticulosDeSuministros.fnDraw();
                });
            });

        }

        //--- Función editar de Datatable ArticulosDeSuministros
        public editar_dtArticulosDeSuministros(): void {
            var id = this.ViewIndex.getData(0);
            app.createTab("Editar", "Suministros/ArticulosDeSuministros/Editar/" + id, true, true, true);
        }

        //--- Función eliminar de Datatable ArticulosDeSuministros
        public eliminar_dtArticulosDeSuministros(): void {
            var that = this;
            var id = this.ViewIndex.getData(0);
            var resultado = new Resultado();
            this.eliminar("Suministros/ArticulosDeSuministros/Eliminar", { id: id }, resultado).done(function () {
                that.ViewIndex.ArticulosDeSuministros.fnDraw();
            });;
        }


        //-- Método para pasar Vistas por Post según URL de formulario
        public ajaxPost(v: IControlador, titulo: string, resultado?: Resultado): JQueryDeferred {
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