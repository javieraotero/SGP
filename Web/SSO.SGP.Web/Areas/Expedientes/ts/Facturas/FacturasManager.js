/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="asignar.ts"/>
/// <reference path="../ExpedientesADM/ExpedientesADMManager.ts"/>
var Facturas;
(function (Facturas) {
    var ts;
    (function (ts) {
        var FacturasManager = /** @class */ (function () {
            function FacturasManager() {
                // Constructor
            }
            FacturasManager.prototype.setAsignar = function (v) {
                var that = this;
                this.ViewAsignar = v;
                var total;
                total = 0.0;
                this.refrescarPartidas();
                $("input[data-tipo=importe]").die("keyup");
                $("input[data-tipo=importe]").live("keyup", function (e) {
                    console.log("se ejecuta keyup de importe");
                    v.Partidas.find("tr").each(function () {
                        var $el = $(this);
                        if ($el.find("td input").val())
                            total += parseFloat($el.find("td input").val());
                    });
                    v.spResta.html((parseFloat(v.spImporte.html().replace(",", ".")) - total).toFixed(2));
                    total = 0;
                });
                console.log("3 evento keyup de input tipo = imoprte");
                //$.get("Expedientes/Facturas/ObtenerAsiganacion", { id: v.Id.val() }, function (data) {
                //    if (data.length > 0) {
                //        $.each(data, function (index, value) {
                //            $("#importe_" + value.Partida).val(value.Importe);
                //            $("#div_" + value.Partida).find("option[value=" + value.Division + "]").prop("selected", "selected");
                //        });
                //    }
                //    console.log("4 Obtener asignacion desde setasignar");
                //});
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    var resta = parseFloat(v.spResta.html());
                    if (resta != 0) {
                        bootbox.confirm("Ooops.. el importe asignado no concuerda con el importe de la factura. Desea marcarla igualmente como asignada?", function (result) {
                            if (result) {
                                that.guardarImputacion("Guardar Asignación", resultado).done(function (e) {
                                    if (resultado.estado) {
                                        app.modal.cerrar();
                                        console.log(v.bVistaExpediente);
                                        if (!v.bVistaExpediente) {
                                            if (that.ViewSinOP)
                                                that.ViewSinOP.dtSinOP.fnDraw();
                                            if (that.ViewSinAsignacion)
                                                that.ViewSinAsignacion.dtSinAsignacion.fnDraw();
                                            if (that.ViewIndex)
                                                that.ViewIndex.Facturas.fnDraw();
                                        }
                                        else {
                                            //var manager = <ExpedientesADM.ts.ExpedientesADMManager>app.getManager("ExpedientesADM");
                                            //manager.refreshFacturas(manager.ViewDetalle.Id.val());
                                            app.modal.cerrar();
                                            app.tabs.reloadCurrent();
                                        }
                                    }
                                });
                            }
                        });
                    }
                    else {
                        that.guardarImputacion("Guardar Asignación", resultado).done(function (e) {
                            if (resultado.estado) {
                                app.modal.cerrar();
                                if (!v.bVistaExpediente) {
                                    if (that.ViewSinOP)
                                        that.ViewSinOP.dtSinOP.fnDraw();
                                    if (that.ViewSinAsignacion)
                                        that.ViewSinAsignacion.dtSinAsignacion.fnDraw();
                                    if (that.ViewIndex)
                                        that.ViewIndex.Facturas.fnDraw();
                                }
                                else {
                                    app.modal.cerrar();
                                    app.tabs.reloadCurrent();
                                }
                            }
                        });
                    }
                });
                v.UnidadOrganizacion.change(function (e) {
                    that.refrescarPartidas();
                });
            };
            //--- Inicialización de la vista Index
            FacturasManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            FacturasManager.prototype.setArmarExpediente = function (v) {
                var that = this;
                this.ViewArmarExpediente = v;
                that.aFacturas = [];
                that.aPartidas = [];
                // Eventos de la vista
                $.get("Expedientes/Facturas/FacturasSinExpedienteJson2", null, function (data) {
                    that.aFacturas = data;
                    that.refrescarFacturas();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.armarExpediente(v, "Resultado", resultado);
                });
            };
            FacturasManager.prototype.refrescarFacturas = function () {
                var that = this;
                var t = this.ViewArmarExpediente.body_facturas.empty();
                var r = "";
                var filtro = this.aFacturas;
                if (this.aPartidas.length) {
                    filtro = Enumerable.From(that.aFacturas).Where(function (x) { return Enumerable.From(x.Asignacion).Any(function (z) { return z.Numero == that.aPartidas[0]; }); }).ToArray();
                }
                if (filtro.length > 0) {
                    filtro.forEach(function (v, i) {
                        r = "<tr data-id='" + v.Id + "'><td><input type='checkbox' data-type='check' onclick='oFacturas.seleccionarFactura(this)' class='form-control'></td><td>" + v.Numero + "</td><td>" + v.Identificador + "</td><td>" + app.formatearFecha(v.Fecha.toString()) + "</td><td>" + v.Proveedor + "</td><td>" + v.Descripcion + "</td><td>" + v.Importe + "</td><td><button class='btn green' data-factura='" + v.Id + "' onclick='return oFacturas.verPartida(this)' data-type='ver'>+</button></td></tr>";
                        t.append(r);
                        if (v.Asignacion.length) {
                            var r2 = "";
                            r2 = r2 + "<tr data-factura='" + v.Id + "' style='display:none'><td colspan='8'><table data-factura='" + v.Id + "' class='table table-bordered'><thead><tr><th>Partida</th><th>Importe</th></tr></thead><tbody>";
                            v.Asignacion.forEach(function (v2, i2) {
                                r2 = r2 + "<tr data-partida='" + v2.Partida + "' data-importe='" + v2.Importe + "'><td>" + v2.Partida + "</td><td>" + v2.Importe + "</td></tr>";
                            });
                            r2 = r2 + "</tbody></table></td></tr>";
                            t.append(r2);
                        }
                    });
                }
                else {
                    r = "<tr><td colspan='6'>No se han encontrado resultados</td></t>";
                    t.append(r);
                }
            };
            FacturasManager.prototype.verPartida = function (el) {
                var id = $(el).data("factura");
                $("tr[data-factura=" + id + "]").show();
                return false;
            };
            FacturasManager.prototype.seleccionarFactura = function (el) {
                var that = this;
                this.aTotal = [];
                this.ViewArmarExpediente.body_partidas.empty();
                this.ViewArmarExpediente.body_facturas.find("tr").each(function (i, v) {
                    if ($(v).data("id")) {
                        console.log("Procesando factura: " + $(v).data("id"));
                        if ($(v).find("td input:checkbox")[0].checked) {
                            //console.log("entra a if checked " + $(v).data("id"));
                            $("table[data-factura=" + $(v).data("id") + "]").find("tr").each(function (i2, v2) {
                                if ($(v2).data("partida")) {
                                    var p = {
                                        partida: $(v2).data("partida"),
                                        importe: $(v2).data("importe")
                                    };
                                    console.log(p);
                                    that.aTotal.push(p);
                                }
                            });
                        }
                        console.log(that.aTotal);
                    }
                });
                console.log("Partidas:");
                console.log(that.aTotal.length);
                if (that.aTotal.length) {
                    console.log("entra a partidas");
                    //var resultado = Enumerable.From(that.aTotal).GroupBy("$.partida", "$.importe", "{partida:$.partida, total:$$.Sum()}").ToArray();
                    var resultado = Enumerable.From(that.aTotal).GroupBy("$.partida", null, function (key, e) {
                        return {
                            partida: key,
                            total: e.Sum("$.importe")
                        };
                    }).ToArray();
                    resultado.forEach(function (v, i) {
                        that.ViewArmarExpediente.body_partidas.append("<tr><td>" + v.partida + "</td><td>" + v.total + "</td></tr>");
                    });
                }
            };
            FacturasManager.prototype.setSinAsignacion = function (v) {
                var that = this;
                this.ViewSinAsignacion = v;
                // Eventos de la vista
            };
            FacturasManager.prototype.setSinOP = function (v) {
                var that = this;
                this.ViewSinOP = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            FacturasManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    if (v.Proveedor.hidden.val() != "") {
                        v.Guardar.hide();
                        var res = new Resultado();
                        that.ajaxPost(that.ViewCrear, "Resultado", res).done(function () {
                            if (res.estado) {
                                if (that.ViewIndex) {
                                    app.tabs.reloadCurrent();
                                    app.irATab(0);
                                    that.ViewIndex.Facturas.fnDraw();
                                }
                                else {
                                    app.tabs.reloadCurrent();
                                }
                            }
                        });
                    }
                    else {
                        app.crearNotificacionError("Error", "No ha seleccionado ningún proveedor");
                    }
                });
                v.GuardarYNuevo.click(function (e) {
                    var res = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Resultado", res).done(function () {
                        if (res.estado) {
                            app.tabs.reloadCurrent();
                            that.ViewIndex.Facturas.fnDraw();
                        }
                    });
                });
            };
            //--- Inicialización de la vista Editar
            FacturasManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Expediente.txt.blur(function (e) {
                    if ($(this).val() == "") {
                        v.Expediente.hidden.val("");
                    }
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.Actualizar(that.ViewEditar, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            app.closeCurrentTab();
                            that.ViewIndex.Facturas.fnDraw();
                        }
                    });
                });
                app.setValidadorDecimal();
            };
            FacturasManager.prototype.refrescarPartidas = function () {
                var that = this;
                var p = this.ViewAsignar;
                //p.Partidas.empty();
                p.UnidadOrganizacion.find("option[value=1]").prop("selected", "selected");
                p.UnidadOrganizacion.trigger("liszt:updated");
                p.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if (!$el.find("td input").val())
                        $el.remove();
                });
                $.get("Expedientes/PartidasPresupuestarias/partidas", { unidad: p.UnidadOrganizacion.val() }, function (data) {
                    $.each(data, function (index, value) {
                        var row = "";
                        row = "<tr data-partida='" + value.Id + "'><td>" + value.NumeroDePartida + "</td>";
                        row += "<td><select data-tipo='division' id='div_" + value.Id + "' class='form-control col-md-12'>";
                        $.each(value.DivisionesExtraPresupuestarias, function (index, division) {
                            row += "<option value='" + division.Id + "'>" + division.Nombre + "</option>";
                        });
                        //row += "</td><td><input type='text' class='form-control' data-tipo='importe' id='importe_" + value.Id + "' value='0'></td></tr>";
                        row += "</td><td><input type='text' class='form-control col-md-10' data-tipo='importe' id='importe_" + value.Id + "' value='0'><a href='#' onclick='add(this)'>+</a></td></tr>";
                        p.Partidas.append(row);
                    });
                    $.get("Expedientes/Facturas/ObtenerAsiganacion", { id: that.ViewAsignar.Id.val() }, function (data) {
                        if (data) {
                            $.each(data, function (index, value) {
                                if ($("#importe_" + value.Partida).val() == "0") {
                                    $("#importe_" + value.Partida).val(value.Importe).attr("data-imputaciondetalle_" + value.Partida, value.Id);
                                    $("#div_" + value.Partida).find("option[value=" + value.Division + "]").prop("selected", "selected");
                                }
                                else {
                                    var el = that.ViewAsignar.Partidas.find("tr[data-partida=" + value.Partida + "]");
                                    var $tr = $(el);
                                    $tr.clone().insertAfter($tr);
                                    $tr.find("input[type=text]").val(value.Importe);
                                    $tr.find("input[type=text]").attr("id", "importe_" + value.Partida + "_" + value.Division);
                                    $tr.find("select").attr("id", "div_" + value.Partida + "_" + value.Division);
                                    $tr.find("select").find("option[value=" + value.Division + "]").prop("selected", "selected");
                                    //$("#importe_" + value.Partida).val(value.Importe).attr("data-imputaciondetalle_" + value.Partida, value.Id);
                                    //$("#div_" + value.Partida).find("option[value=" + value.Division + "]").prop("selected", "selected");
                                }
                            });
                        }
                    });
                });
            };
            //--- Función editar de Datatable Facturas
            FacturasManager.prototype.editar_dtFacturas = function () {
                var id = this.ViewIndex.getData(0);
                app.createTab("Editar", "Expedientes/Facturas/Editar/" + id, true, true, true);
            };
            FacturasManager.prototype.asignar_dtFacturas = function () {
                var id = this.ViewIndex.getData(0);
                var proveedor = this.ViewIndex.getData(5);
                app.modal.cargar("Asignar Factura de " + proveedor, "Expedientes/Facturas/Asignar/?factura=" + id);
                //app.createTab("Editar", "Facturas/Editar/" + id, true, true, true);
            };
            FacturasManager.prototype.asignar_dtFacturasSinAsignar = function () {
                var id = this.ViewSinAsignacion.getData(0);
                var proveedor = this.ViewSinAsignacion.getData(5);
                app.modal.cargar("Asignar Factura de " + proveedor, "Expedientes/Facturas/Asignar/?factura=" + id);
                //app.createTab("Editar", "Facturas/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable Facturas
            FacturasManager.prototype.eliminar_dtFacturas = function () {
                var id = this.ViewIndex.getData(0);
                var resultado = new Resultado();
                this.eliminar("Facturas/Eliminar", { id: id }, resultado).done(function () {
                    if (resultado.estado) {
                        app.crearNotificacionSuccess("Eliminar factura", "La factura ha sido eliminada satisfactoriamente");
                    }
                    else {
                        app.crearNotificacionError("Eliminar factura", "La factura no ha podido ser eliminada");
                    }
                });
            };
            FacturasManager.prototype.guardarImputacion = function (titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                var imputacion;
                imputacion = {
                    Factura: that.ViewAsignar.Id.val(),
                    FacturasImputadasDetalle: new Array()
                };
                that.ViewAsignar.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if ($el.find("td input").val()) {
                        var detalle;
                        var id = $el.find("td input").data("imputaciondetalle_" + $el.data("partida"));
                        if (!id)
                            id = 0;
                        detalle = {
                            Id: id,
                            Partida: $el.data("partida"),
                            Division: $el.find("select").val(),
                            Importe: $el.find("td input").val().replace(".", ",")
                        };
                        if (parseFloat(detalle.Importe) > 0)
                            imputacion.FacturasImputadasDetalle.push(detalle);
                    }
                });
                console.log(imputacion);
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "Expedientes/Facturas/AsignarFactura",
                    data: JSON.stringify({ imputacion: imputacion }),
                    contentType: "application/json",
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
                return (df.promise());
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            FacturasManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                that.ViewCrear.Importe.val(that.ViewCrear.Importe.val().replace(".", ","));
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
            FacturasManager.prototype.Actualizar = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                that.ViewEditar.Importe.val(that.ViewEditar.Importe.val().replace(".", ","));
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
            FacturasManager.prototype.armarExpediente = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                var facturas = [];
                that.ViewArmarExpediente.body_facturas.find("tr[data-id]").each(function (i, v) {
                    if ($(v).find("td input:checkbox")[0].checked) {
                        facturas.push($(v).data("id"));
                        $("tr[data-factura=" + $(v).data("id") + "]").remove();
                        $(v).remove();
                    }
                });
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: "Expedientes/Facturas/ArmarExpediente",
                        data: JSON.stringify({ facturas: facturas }),
                        dataType: "json",
                        contentType: "application/json",
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
                }
                return (df.promise());
            };
            FacturasManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            FacturasManager.prototype.eliminar = function (url, data, resultado) {
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
            return FacturasManager;
        }()); //JS	
        ts.FacturasManager = FacturasManager;
        var FacturasCustom = /** @class */ (function () {
            function FacturasCustom() {
                this.Asignacion = [];
            }
            return FacturasCustom;
        }());
        var AsignacionCustom = /** @class */ (function () {
            function AsignacionCustom() {
            }
            return AsignacionCustom;
        }());
    })(ts = Facturas.ts || (Facturas.ts = {}));
})(Facturas || (Facturas = {}));
