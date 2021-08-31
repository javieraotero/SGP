/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var EjecucionesPresupuestarias;
(function (EjecucionesPresupuestarias) {
    var ts;
    (function (ts) {
        var EjecucionesPresupuestariasManager = /** @class */ (function () {
            function EjecucionesPresupuestariasManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            EjecucionesPresupuestariasManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista			
                v.CrearAnual.click(function (e) {
                    app.modal.cargar("Crear Presupuesto Anual", "/Expedientes/EjecucionesPresupuestarias/CrearAnual");
                });
            };
            EjecucionesPresupuestariasManager.prototype.setCrearAnual = function (v) {
                var that = this;
                this.ViewCrearAnual = v;
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.crearAnual("Crear", resultado);
                });
            };
            //--- Inicialización de la vista Crear
            EjecucionesPresupuestariasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Ejecución", resultado).done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Ejecución", resultado).done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            EjecucionesPresupuestariasManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                var preventiva = app.setDecimal(v.MontoPreventiva.data("valor"));
                var compromiso = app.setDecimal(v.MontoCompromiso.data("valor"));
                var presupuesto = app.setDecimal(v.Presupuestado.data("valor"));
                var reestructura_mas = app.setDecimal(v.ReestructuraMas.data("valor"));
                var reestructura_menos = app.setDecimal(v.ReestructuraMenos.data("valor"));
                var reserva_mas = app.setDecimal(v.ReservaMas.data("valor"));
                var reserva_menos = app.setDecimal(v.ReservaMenos.data("valor"));
                v.SaldoPreventiva.val((preventiva - compromiso).toFixed(2)).data("valor", (preventiva - compromiso).toFixed(2));
                v.CreditoPresupuestadoModificado.val(presupuesto.toFixed(2)).data("valor", presupuesto.toFixed(2));
                ;
                v.CreditoActual.val((presupuesto + reestructura_mas + reestructura_menos).toFixed(2)).data("valor", (presupuesto + reestructura_mas + reestructura_menos).toFixed(2));
                v.ReservaMas.val(presupuesto.toFixed(2)).data("valor", presupuesto.toFixed(2));
                v.ReservaNeta.val((reserva_mas - reserva_menos).toFixed(2)).data("valor", (reserva_mas - reserva_menos).toFixed(2));
                v.CreditoHabilitado.val((reserva_menos + reestructura_mas + reestructura_menos).toFixed(2)).data("valor", (reserva_menos + reestructura_mas + reestructura_menos).toFixed(2));
                var credito_habilitado = app.setDecimal(v.CreditoHabilitado.data("valor"));
                v.CreditoDisponible.val((credito_habilitado - preventiva).toFixed(2)).data("valor", (credito_habilitado - preventiva).toFixed(2));
                v.Presupuestado.keyup(function (e) {
                    var valor = $(this).val();
                    $(this).data("valor", valor);
                    if ($(this).val().length == 0)
                        $(this).val("0");
                    var presupuestado = app.setDecimal(v.Presupuestado.data("valor"));
                    var reestructura_mas = app.setDecimal(v.ReestructuraMas.data("valor"));
                    var reestructura_menos = app.setDecimal(v.ReestructuraMenos.data("valor"));
                    v.CreditoActual.val((presupuestado + reestructura_mas - reestructura_menos).toFixed(2)).data("valor", (presupuestado + reestructura_mas + reestructura_menos).toFixed(2));
                    v.CreditoPresupuestadoModificado.val(presupuestado.toFixed(2)).data("valor", presupuestado.toFixed(2));
                    v.ReservaMas.val(presupuestado.toFixed(2)).data("valor", presupuestado.toFixed(2));
                    var reserva_mas = app.setDecimal(v.ReservaMas.data("valor"));
                    var reserva_menos = app.setDecimal(v.ReservaMenos.data("valor"));
                    v.ReservaNeta.val((reserva_mas - reserva_menos).toFixed(2)).data("valor", (reserva_mas - reserva_menos).toFixed(2));
                });
                v.Presupuestado.change(function (e) {
                    $("input[data-type=decimal]").each(function (i, v) {
                        $(this).val(app.setDecimal($(this).data("valor")).toLocaleString("es"));
                    });
                });
                v.ReservaMenos.change(function (e) {
                    $("input[data-type=decimal]").each(function (i, v) {
                        $(this).val(app.setDecimal($(this).data("valor")).toLocaleString("es"));
                    });
                });
                v.ReservaMenos.keyup(function (e) {
                    var valor = $(this).val();
                    $(this).data("valor", valor);
                    if ($(this).val().length == 0)
                        $(this).val("0");
                    var reserva_mas = app.setDecimal(v.ReservaMas.data("valor"));
                    var reserva_menos = app.setDecimal(v.ReservaMenos.data("valor"));
                    var reestructura_mas = app.setDecimal(v.ReestructuraMas.data("valor"));
                    var reestructura_menos = app.setDecimal(v.ReestructuraMenos.data("valor"));
                    var monto_preventiva = app.setDecimal(v.MontoPreventiva.data("valor"));
                    console.log("Reserva mas: " + reserva_mas);
                    console.log("Reserva menos: " + reserva_menos);
                    console.log("Reestructura mas: " + reestructura_mas);
                    console.log("Reestructura menos: " + reestructura_menos);
                    console.log("Monto Preventiva: " + monto_preventiva);
                    v.CreditoHabilitado.val((reserva_menos + reestructura_mas + reestructura_menos).toFixed(2)).data("valor", (reserva_menos + reestructura_mas + reestructura_menos).toFixed(2));
                    v.ReservaNeta.val((reserva_mas - reserva_menos).toFixed(2)).data("valor", (reserva_mas - reserva_menos).toFixed(2));
                    v.CreditoDisponible.val(((reserva_menos + reestructura_mas + reestructura_menos) - (monto_preventiva)).toFixed(2)).data("valor", ((reserva_menos + reestructura_mas + reestructura_menos) - (monto_preventiva)).toFixed(2));
                });
                //$("input[data-type=decimal]").val($("input[data-type=decimal]").val().replace(",", "."));
                $("input[data-type=decimal]").each(function (i, v) {
                    $(this).val(app.setDecimal($(this).val()).toLocaleString("es"));
                });
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    $("input[data-type=decimal]").each(function (i, v) {
                        $(this).val(app.setDecimal($(this).val()).toLocaleString("es"));
                        $(this).val($(this).data("valor").replace(".", ","));
                    });
                    that.ajaxPost(that.ViewEditar, "Guardar Ejecución", resultado).done(function () {
                        if (resultado.estado) {
                            app.closeCurrentTab();
                            that.ViewIndex.EjecucionesPresupuestarias.fnDraw();
                        }
                    });
                });
            };
            //--- Función editar de Datatable EjecucionesPresupuestarias
            EjecucionesPresupuestariasManager.prototype.editar_dtEjecucionesPresupuestarias = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "/Expedientes/EjecucionesPresupuestarias/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable EjecucionesPresupuestarias
            EjecucionesPresupuestariasManager.prototype.eliminar_dtEjecucionesPresupuestarias = function () {
                var id = this.ViewIndex.EjecucionesPresupuestarias_Id; //getData(0);
                var resultado = new Resultado();
                this.eliminar("/Expedientes/EjecucionesPresupuestarias/Eliminar", { id: id }, resultado);
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            EjecucionesPresupuestariasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
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
                        }
                        else {
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
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                //}
                return (df.promise());
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            EjecucionesPresupuestariasManager.prototype.crearAnual = function (titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "/Expedientes/EjecucionesPresupuestarias/CrearAnual",
                    data: { anio: that.ViewCrearAnual.Anio.val(), unidad_de_organizacion: that.ViewCrearAnual.UnidadDeOrganizacion.val() },
                    success: function (data) {
                        if (data.length > 0) {
                            that.ViewCrearAnual.Errores.empty();
                            $.each(data, function (i, v) {
                                that.ViewCrearAnual.Errores.append("<tr><td>" + v + "</td></tr>");
                            });
                        }
                        else {
                            that.ViewCrearAnual.Errores.append("<tr><td>No se han encontrado errores</td></tr>");
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario");
                        resultado.excepcion = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            EjecucionesPresupuestariasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
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
                        }
                        else {
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
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                return (df.promise());
            };
            EjecucionesPresupuestariasManager.prototype.eliminar = function (url, data, resultado) {
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
                                    if (that.ViewIndex) {
                                        that.ViewIndex.EjecucionesPresupuestarias.fnDraw();
                                    }
                                }
                                else {
                                    app.crearNotificacionError("Error", data[1]);
                                }
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                alert("Error al procesar formulario ajax");
                            },
                            complete: function () {
                                app.Desbloquear();
                            }
                        })).done(function () { df.resolve(); })
                            .fail(function () { df.reject(); });
                    }
                });
                return (df.promise());
            };
            return EjecucionesPresupuestariasManager;
        }()); //JS	
        ts.EjecucionesPresupuestariasManager = EjecucionesPresupuestariasManager;
    })(ts = EjecucionesPresupuestarias.ts || (EjecucionesPresupuestarias.ts = {}));
})(EjecucionesPresupuestarias || (EjecucionesPresupuestarias = {}));
