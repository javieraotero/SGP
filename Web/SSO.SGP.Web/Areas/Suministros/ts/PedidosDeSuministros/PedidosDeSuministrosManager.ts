/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
module PedidosDeSuministros.ts {

    export class PedidosDeSuministrosManager {

        public ViewIndex: Index;
        public ViewCrear: Crear;
        public ViewEditar: Crear;
        public stock: number;

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

            v.Agregar.click(function (e) {

                var match = that.buscarArticulo(v.Articulo.hidden.val(), v.adetalle);

                // el articulo ya existe en la colección
                if (match.length) {
                    that.cambiarCantidad(match[0].idarticulo, v.CantidadEntregada.val(), v.CantidadSolicitada.val(), v.adetalle);
                } else {
                    var det = new DetalleDePedido();
                    det.articulo = v.Articulo.txt.val();
                    det.idarticulo = v.Articulo.hidden.val();
                    det.entregado = v.CantidadEntregada.val();
                    det.solicitado = v.CantidadSolicitada.val();
                    det.nuevo = true;

                    v.adetalle.push(det);
                }

                v.Detalle.fromArray(v.adetalle);

                v.CantidadEntregada.val("");
                v.CantidadSolicitada.val("");
                v.Articulo.txt.select();
                v.Articulo.txt.focus();                
            });

            v.Articulo.setCallback(function (ui: any) {
                that.stock = ui.item.stock;
                v.CantidadEntregada.focus();
            });

            v.CantidadEntregada.keyup(function (e) {
                if (v.CantidadEntregada.val() > that.stock) {
                    bootbox.alert("Atención! No hay suficiente stock del producto (stock: " + that.stock + ")");
                    v.Agregar.prop("disabled", "true");
                } else {
                    v.Agregar.prop("disabled", false);
                }
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

            v.CantidadSolicitada.click(function (e) {
                if (e.which == 13)
                    bootbox.alert("Se presiona enter");
            });

            v.Cancelar.click(function (e) {
                v.limpiar();
                v.Guardar.prop("disabled", false);
                app.irATab(0);
                v.Guardar.val("Guardar");
            });

            v.Imprimir.click(function (e) {
                app.createTab("Comprobande", "Suministros/Reportes/Pedido/?pedido=" + v.spNumero.html(), true, true, true);
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado()

                var data = v.form.serializeObject();
                data.Detalle = v.adetalle;
                $.when(that.ajaxPostURL("PedidosDeSuministros/Crear", data, "Guardar", resultado)).done(function () {
                    that.ViewIndex.PedidosDeSuministros.fnDraw();
                    v.spNumero.html(resultado.id.toString());

                    // la llamada esta ok
                    if (resultado.estado)
                        v.Guardar.prop("disabled", true);
                });
            });

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado()

                var data = v.form.serializeObject();
                data.Detalle = v.adetalle;
                $.when(that.ajaxPostURL("PedidosDeSuministros/Crear", data, "Guardar", resultado)).done(function () {
                    that.ViewIndex.PedidosDeSuministros.fnDraw();
                    v.limpiar();
                    v.Organismo.focus();
                });
            });

        }

        public buscarArticulo(id:number, array:any): DetalleDePedido {
            return $.grep(array, function (item) {
                return item.idarticulo == id;
            });
        }

        public cambiarCantidad(id:number, entregado:number, solicitado: number, array:any): void {
            for (var i in array) {
                if (array[i].idarticulo == id) { 
                    if (this.stock < parseFloat(array[i].entregado) + parseFloat(entregado)) {
                        bootbox.alert("ATENCIÓN! No hay stock de " + (parseFloat(array[i].entregado) + parseFloat(entregado)) + " unidades para el artículo " + array[i].articulo);
                    } else {
                        array[i].entregado = parseFloat(array[i].entregado) + parseFloat(entregado);
                        array[i].solicitado = parseFloat(array[i].solicitado) + parseFloat(solicitado);
                    }
                    break; 
                }
            }
        }

        //--- Inicialización de la vista Editar
        public setEditar(v: Crear) {
            var that = this;
            this.ViewEditar = v;
            // Eventos de la vista

            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
            });

            v.Articulo.setCallback(function (ui: any) {
                that.stock = ui.item.stock;
                v.CantidadEntregada.focus();
            });

            v.CantidadEntregada.keyup(function (e) {
                if (v.CantidadEntregada.val() > that.stock) {
                    bootbox.alert("Atención! No hay suficiente stock del producto (stock: " + that.stock + ")");
                }
            });

            v.adetalle = $.parseJSON($("#DetalleData").val());
            v.Detalle.fromArray(v.adetalle);

            v.Detalle.setearSeleccionable(true);

            v.Agregar.click(function (e) {

                var match = that.buscarArticulo(v.Articulo.hidden.val(), v.adetalle);

                // el articulo ya existe en la colección
                if (match.length) {
                    that.cambiarCantidad(match[0].idarticulo, v.CantidadEntregada.val(), v.CantidadSolicitada.val(), v.adetalle);
                } else {
                    var det = new DetalleDePedido();
                    det.articulo = v.Articulo.txt.val();
                    det.idarticulo = v.Articulo.hidden.val();
                    det.entregado = v.CantidadEntregada.val();
                    det.solicitado = v.CantidadSolicitada.val();
                    det.nuevo = true;

                    v.adetalle.push(det);
                }

                v.Detalle.fromArray(v.adetalle);

                v.CantidadEntregada.val("");
                v.CantidadSolicitada.val("");
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

            v.Imprimir.click(function (e) {
                app.createTab("Comprobande", "Suministros/Reportes/Pedido/?pedido=" + v.spNumero.html(), true, true, true);
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado()
              
                var data = v.form.serializeObject();
                data.Detalle = v.adetalle;
                $.when(that.ajaxPostURL("PedidosDeSuministros/Editar", data, "Actualizar", resultado)).done(function () {
                    that.ViewIndex.PedidosDeSuministros.fnDraw();
                    v.spNumero.html(resultado.id.toString());
                });
            });

        }

        //--- Función editar de Datatable PedidosDeSuministros
        public editar_dtPedidosDeSuministros(): void {
            var id = this.ViewIndex.getData(0);
            app.createTab("Editar", "Suministros/PedidosDeSuministros/Editar/" + id, true, true, true);
        }

        //--- Función eliminar de Datatable PedidosDeSuministros
        public eliminar_dtPedidosDeSuministros(): void {
            var that = this;
            var id = this.ViewIndex.getData(0);
            var resultado = new Resultado();
            $.when(this.eliminar("Suministros/PedidosDeSuministros/Eliminar", { id: id }, resultado)).done(function () {
                that.ViewIndex.PedidosDeSuministros.fnDraw();
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

    export class DetalleDePedido {

        public id: number;
        public articulo: string;
        public idarticulo: number
        public solicitado: number;
        public entregado: number;
        public nuevo: boolean;

    }
}