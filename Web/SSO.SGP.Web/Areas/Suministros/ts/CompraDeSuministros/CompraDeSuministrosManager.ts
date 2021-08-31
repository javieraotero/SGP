/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
module CompraDeSuministros.ts {

    export class CompraDeSuministrosManager {

        public ViewIndex: Index;
        public ViewCrear: Crear;
        public ViewEditar: Crear;

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
            // Eventos de la vista

            app.setValidadorDecimal();

            v.Agregar.click(function (e) {

                var match = that.buscarArticulo(v.Articulo.hidden.val(), v.adetalle);

                // el articulo ya existe en la colección
                if (match.length) {
                    that.cambiarCantidad(match[0].idarticulo, v.Cantidad.val(), v.adetalle);
                } else {

                    var det = new DetalleDeCompra();
                    det.articulo = v.Articulo.txt.val();
                    det.idarticulo = v.Articulo.hidden.val();
                    det.cantidad = v.Cantidad.val();
                    det.precio = v.Precio.val().replace(".", ",");
                    det.nuevo = true;

                    v.adetalle.push(det);
                }

                v.Detalle.fromArray(v.adetalle);

                v.Cantidad.val("");
                v.Articulo.txt.select();
                v.Articulo.txt.focus();
            });

            v.Detalle.setearSeleccionable(true);

            $.contextMenu({
                selector: "#" + v.Detalle.Id,
                items: {
                    "Eliminar": {
                        name: "Eliminar",
                        callback: function () {
                            //alert("eliminar item " + v.Detalle.index);
                            v.adetalle.splice(v.Detalle.index, 1);
                            v.Detalle.fromArray(v.adetalle);
                        }
                    }
                }
            });

            v.Cancelar.click(function (e) {
                app.irATab(0);
                v.limpiar();
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();

                var data = v.form.serializeObject();
                data.Detalle = v.adetalle;
                $.when(that.ajaxPostURL("CompraDeSuministros/Crear", data, "Guardar", resultado)).done(function () {
                    that.ViewIndex.CompraDeSuministros.fnDraw();
                    v.limpiar();
                });
            });

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado()

                v.Precio.val(v.Precio.val().replace(".", ","));

                var data = v.form.serializeObject();
                data.Detalle = v.adetalle;
                $.when(that.ajaxPostURL("CompraDeSuministros/Crear", data, "Guardar", resultado)).done(function () {
                    that.ViewIndex.CompraDeSuministros.fnDraw();
                    v.limpiar();
                });
            });

        }

        public buscarArticulo(id: number, array: any): DetalleDeCompra {
            return $.grep(array, function (item) {
                return item.idarticulo == id;
            });
        }

        public cambiarCantidad(id: number, cantidad: number, array: any): void {
            for (var i in array) {
                if (array[i].idarticulo == id) {
                    console.log("se encontro el articulo" + array[i].articulo);
                    array[i].cantidad = parseFloat(array[i].cantidad) + parseFloat(cantidad);
                    break;
                }
            }
        }

        //--- Inicialización de la vista Editar
        public setEditar(v: Crear) {
            var that = this;
            this.ViewEditar = v;

            console.log("set Editar");

            // Eventos de la vista
            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
            });

            v.adetalle = $.parseJSON($("#DetalleData").val());

            v.Detalle.fromArray(v.adetalle);

            v.Detalle.setearSeleccionable(true);

            v.Agregar.click(function (e) {
                var match = that.buscarArticulo(v.Articulo.hidden.val(), v.adetalle);

                // el articulo ya existe en la colección
                if (match.length) {
                    that.cambiarCantidad(match[0].idarticulo, v.Cantidad.val(), v.adetalle);
                } else {

                    var det = new DetalleDeCompra();
                    det.articulo = v.Articulo.txt.val();
                    det.idarticulo = v.Articulo.hidden.val();
                    det.cantidad = v.Cantidad.val();
                    det.precio = v.Precio.val();
                    det.nuevo = true;

                    v.adetalle.push(det);
                }

                v.Detalle.fromArray(v.adetalle);

                v.Cantidad.val("");
                v.Articulo.txt.select();
                v.Articulo.txt.focus();
            });

            $.contextMenu({
                selector: "#" + v.Detalle.Id,
                items: {
                    "Eliminar": {
                        name: "Eliminar",
                        callback: function () {
                            //alert("eliminar item " + v.Detalle.index);
                            v.adetalle.splice(v.Detalle.index, 1);
                            v.Detalle.fromArray(v.adetalle);
                        }
                    }
                }
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado()

                v.Precio.val(v.Precio.val().replace(".", ","));

                var data = v.form.serializeObject();
                data.Detalle = v.adetalle;
                $.when(that.ajaxPostURL("CompraDeSuministros/Editar", data, "Guardar", resultado)).done(function () {
                    that.ViewIndex.CompraDeSuministros.fnDraw();
                });
            });

        }

        //--- Función editar de Datatable PedidosDeSuministros
        public editar_dtCompraDeSuministros(): void {
            var id = this.ViewIndex.getData(0);
            app.createTab("Editar", "Suministros/CompraDeSuministros/Editar/" + id, true, true, true);
        }

        //--- Función eliminar de Datatable PedidosDeSuministros
        public eliminar_dtCompraDeSuministros(): void {
            var that = this;
            var id = this.ViewIndex.getData(0);
            var resultado = new Resultado();
            $.when(this.eliminar("Suministros/CompraDeSuministros/Eliminar", { id: id }, resultado)).done(function () {
                that.ViewIndex.CompraDeSuministros.fnDraw();
            });
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

    export class DetalleDeCompra {

        public id: number;
        public articulo: string;
        public idarticulo: number
        public cantidad: number;
        public precio: number;
        public nuevo: boolean;

    }
}