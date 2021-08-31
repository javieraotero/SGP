/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var ExpedientesADM;
(function (ExpedientesADM) {
    var ts;
    (function (ts) {
        var ExpedientesADMManager = /** @class */ (function () {
            function ExpedientesADMManager() {
                // Constructor
            }
            ExpedientesADMManager.prototype.setAsignar = function (v) {
                var that = this;
                this.ViewAsignar = v;
                var total;
                total = 0.0;
                this.refrescarPartidas();
                $("input[data-tipo=importe]").die("keyup");
                $("input[data-tipo=importe]").live("keyup", function (e) {
                    v.Partidas.find("tr").each(function () {
                        var $el = $(this);
                        if ($el.find("td input").val())
                            total += parseFloat($el.find("td input").val());
                    });
                    v.spImporte.html(total.toFixed(2));
                    total = 0;
                });
                $.get("/Expedientes/ExpedientesADM/obtenerAsignacion", { expediente: v.Id.val() }, function (data) {
                    if (data.length > 0) {
                        $.each(data, function (index, value) {
                            $("#importe_" + value.Partida).val(value.Importe);
                            $("#div_" + value.Partida).find("option[value=" + value.Division + "]").prop("selected", "selected");
                        });
                    }
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.guardarImputacion("Guardar Asignación", resultado).done(function (e) {
                        if (resultado.estado) {
                            app.modal.cerrar();
                            that.ViewIndex.ExpedientesADM.fnDraw();
                            if (that.ViewDetalle) {
                                app.tabs.reloadCurrent();
                            }
                        }
                    });
                });
                v.UnidadOrganizacion.change(function (e) {
                    that.refrescarPartidas();
                });
            };
            ExpedientesADMManager.prototype.setSobreafectar = function (v) {
                var that = this;
                this.ViewSobreafectar = v;
                var total;
                total = 0.0;
                this.refrescarPartidasSobreafectar();
                $("input[data-tipo=importe]").die("keyup");
                $("input[data-tipo=importe]").live("keyup", function (e) {
                    v.Partidas.find("tr").each(function () {
                        var $el = $(this);
                        if ($el.find("td input").val())
                            total += parseFloat($el.find("td input").val());
                    });
                    v.spImporte.html(total.toFixed(2));
                    total = 0;
                });
                //$.get("Expedientes/Expedientesadm/ObtenerAsiganacion", { id: v.Id.val() }, function (data) {
                //    if (data.length > 0) {
                //        $.each(data.FacturasImputadasDetalle, function (index, value) {
                //            $("#importe_" + value.Partida).val(value.Importe);
                //            $("#div_" + value.Partida).find("option[value=" + value.Division + "]").prop("selected", "selected");
                //        });
                //    }
                //});
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.guardarSobreAfectacion("Guardar sobreafectación", resultado).done(function (e) {
                        if (resultado.estado) {
                            app.tabs.reloadCurrent();
                        }
                    });
                });
                v.UnidadOrganizacion.change(function (e) {
                    that.refrescarPartidasSobreafectar();
                });
            };
            ExpedientesADMManager.prototype.setDesafectar = function (v) {
                var that = this;
                this.ViewDesafectar = v;
                var total;
                total = 0.0;
                this.refrescarPartidasDesafectar();
                $("input[data-tipo=importe]").die("keyup");
                $("input[data-tipo=importe]").live("keyup", function (e) {
                    v.Partidas.find("tr").each(function () {
                        var $el = $(this);
                        if ($el.find("td input").val())
                            total += parseFloat($el.find("td input").val());
                    });
                    v.spImporte.html(total.toFixed(2));
                    total = 0;
                });
                //$.get("Expedientes/Expedientesadm/ObtenerAsiganacion", { id: v.Id.val() }, function (data) {
                //    if (data.length > 0) {
                //        $.each(data.FacturasImputadasDetalle, function (index, value) {
                //            $("#importe_" + value.Partida).val(value.Importe);
                //            $("#div_" + value.Partida).find("option[value=" + value.Division + "]").prop("selected", "selected");
                //        });
                //    }
                //});
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.guardarDesafectacion("Guardar desafectación", resultado).done(function (e) {
                        if (resultado.estado) {
                            app.tabs.reloadCurrent();
                        }
                    });
                });
                v.UnidadOrganizacion.change(function (e) {
                    that.refrescarPartidasDesafectar();
                });
            };
            ExpedientesADMManager.prototype.refrescarPartidas = function () {
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
                        row += "</td><td><input type='text' class='form-control col-md-10' data-tipo='importe' id='importe_" + value.Id + "' value'0'><a href='#' onclick='add(this)'>+</a></td></tr>";
                        p.Partidas.append(row);
                    });
                });
            };
            ExpedientesADMManager.prototype.refrescarPartidasSobreafectar = function () {
                var p = this.ViewSobreafectar;
                //p.Partidas.empty();
                p.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if (!$el.find("td input").val())
                        $el.remove();
                });
                $.get("Expedientes/PartidasPresupuestarias/partidas", { unidad: p.UnidadOrganizacion.val() }, function (data) {
                    $.each(data, function (index, value) {
                        console.log("prueba");
                        var row = "";
                        row = "<tr data-partida='" + value.Id + "'><td>" + value.NumeroDePartida + "</td>";
                        row += "<td><select data-tipo='division' id='div_" + value.Id + "' class='form-control col-md-12'>";
                        $.each(value.DivisionesExtraPresupuestarias, function (index, division) {
                            row += "<option value='" + division.Id + "'>" + division.Nombre + "</option>";
                        });
                        row += "</td><td><input type='text' class='form-control col-md-10' data-tipo='importe' id='importe_" + value.Id + "' value'0'><a href='#' onclick='add(this)'>+</a></td></tr>";
                        p.Partidas.append(row);
                    });
                });
            };
            ExpedientesADMManager.prototype.refrescarPartidasDesafectar = function () {
                var p = this.ViewDesafectar;
                //p.Partidas.empty();
                p.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if (!$el.find("td input").val())
                        $el.remove();
                });
                $.get("Expedientes/PartidasPresupuestarias/partidas", { unidad: p.UnidadOrganizacion.val() }, function (data) {
                    $.each(data, function (index, value) {
                        console.log("prueba");
                        var row = "";
                        row = "<tr data-partida='" + value.Id + "'><td>" + value.NumeroDePartida + "</td>";
                        row += "<td><select data-tipo='division' id='div_" + value.Id + "' class='form-control col-md-12'>";
                        $.each(value.DivisionesExtraPresupuestarias, function (index, division) {
                            row += "<option value='" + division.Id + "'>" + division.Nombre + "</option>";
                        });
                        row += "</td><td><input type='text' class='form-control col-md-10' data-tipo='importe' id='importe_" + value.Id + "' value'0'><a href='#' onclick='add(this)'>+</a></td></tr>";
                        p.Partidas.append(row);
                    });
                });
            };
            //--- Inicialización de la vista Index
            ExpedientesADMManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Index
            ExpedientesADMManager.prototype.setIndexSinAsignar = function (v) {
                var that = this;
                this.ViewIndexSinAsignar = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Index
            ExpedientesADMManager.prototype.setIndexConCargo = function (v) {
                var that = this;
                this.ViewIndexConCargo = v;
                // Eventos de la vista
            };
            //--- Inicialización de la vista Crear
            ExpedientesADMManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Tipo.change(function (e) {
                    var numero = "";
                    if (v.Numero.val() != "0")
                        numero = v.Numero.val();
                    $.get("/Expedientes/ExpedientesADM/obtenerNumero", { tipo: $(this).val(), numero: numero, corresponde: v.EsCorreponde.is(":checked") }, function (data) {
                        v.spNumeroExpediente.html(data.numero);
                        v.hidNumero.val(data.numero);
                        v.hidCorresponde.val(data.nro_corresponde);
                    });
                });
                v.EsCorreponde.change(function (e) {
                    if (this.checked) {
                        v.Numero.removeAttr("disabled");
                        v.Numero.focus();
                    }
                    else {
                        v.Numero.prop("disabled", "disabled");
                        v.Numero.val("0");
                    }
                });
                v.Numero.keyup(function (e) {
                    if (e.which == 13) {
                        $.get("/Expedientes/ExpedientesADM/obtenerNumero", { tipo: v.Tipo.val(), numero: v.Numero.val(), corresponde: v.EsCorreponde.is(":checked") }, function (data) {
                            if (data.numero == "") {
                                app.crearNotificacionWarning("Atención", "No existe el Número de Expediente");
                            }
                            else {
                                v.spNumeroExpediente.html(data.numero);
                                v.hidNumero.val(data.numero);
                                v.hidCorresponde.val(data.nro_corresponde);
                            }
                        });
                    }
                });
                v.Numero.blur(function (e) {
                    $.get("/Expedientes/ExpedientesADM/obtenerNumero", { tipo: v.Tipo.val(), numero: v.Numero.val(), corresponde: v.EsCorreponde.is(":checked") }, function (data) {
                        if (data.numero == "") {
                            app.crearNotificacionWarning("Atención", "No existe el Número de Expediente");
                        }
                        else {
                            v.spNumeroExpediente.html(data.numero);
                            v.hidNumero.val(data.numero);
                            v.hidCorresponde.val(data.nro_corresponde);
                        }
                    });
                });
                v.NuevaActuacion.click(function (e) {
                    v.Modal.cargar("Nueva Actuación", "Expedientes/ActuacionesADM/Crear");
                });
                v.NuevaFactura.click(function (e) {
                    v.Modal.cargar("Nueva Factura", "Expedientes/Facturas/Crear/?expediente=" + v.Id.val() + "&numero=" + v.spNumeroExpediente.html());
                });
                v.Guardar.click(function (e) {
                    v.Guardar.hide();
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Expediente", resultado).done(function () {
                        if (resultado.estado) {
                            //v.limpiar();
                            v.divDetalle.show();
                            v.Imprimir.show();
                            v.Id.val(resultado.id.toString());
                            var lMargin = 15; //left margin in mm
                            var rMargin = 15; //right margin in mm
                            var pdfInMM = 150; // width of A4 in mm
                            var doc = new jsPDF('p', 'mm', [150, 170]);
                            doc.text(20, 20, v.Numero.val());
                            var lines = doc.splitTextToSize(v.Caratula.val(), (pdfInMM - lMargin - rMargin));
                            doc.text(15, 50, lines);
                            //doc.addPage();
                            //doc.text(20, 20, 'Do you like that?');
                            app.tabs.reloadCurrent();
                            doc.autoPrint();
                            window.open(doc.output('bloburl'), '_blank');
                            // Save the PDF
                            //doc.save('Test.pdf');               
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Guardar Expediente", resultado).done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Crear
            ExpedientesADMManager.prototype.setDetalle = function (v) {
                var that = this;
                this.ViewDetalle = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    //app.irATab(0);
                    //var editor = new FormatEditor(that.expediente, 1007);
                    //console.log(that.expediente);
                    //editor.test();
                });
                v.NuevoAdjunto.click(function (e) {
                    app.modal.cargar("Adjuntar", "ArchivosAdjuntos/File/?expediente=" + v.Id.val());
                });
                $("a[data-tipo=contabilidad]").die("click");
                $("a[data-tipo=contabilidad]").live("click", function (e) {
                    e.preventDefault();
                    $("#tr_" + $(this).data("id")).show();
                });
                $("a[data-tipo=ver_asignacion_factura]").die("click");
                $("a[data-tipo=ver_asignacion_factura]").live("click", function (e) {
                    e.preventDefault();
                    $("#asignacion_factura_" + $(this).data("id")).show();
                });
                $("button[data-tipo=asignar]").die("click");
                $("button[data-tipo=asignar]").live("click", function (e) {
                    e.preventDefault();
                    app.modal.cargar("Asignar Factura", "/Expedientes/Facturas/Asignar/?factura=" + $(this).data("id") + "&vista=expediente").done(function () {
                        var manager = app.getManager("Facturas");
                        manager.ViewAsignar.bVistaExpediente = true;
                    });
                    ;
                });
                v.Asignar.click(function (e) {
                    app.modal.cargar("Asignar Expediente Nro: " + v.Numero.val(), "/Expedientes/ExpedientesADM/Asignar/?expediente=" + v.Id.val());
                });
                v.Afectar.click(function (e) {
                    // el expediente tiene facturas...
                    v.operacion = "afectar";
                    if (that.expediente.facturas.length > 0) {
                        app.getData("Expedientes/Expedientesadm/FacturasPendientesDeAfectar", { expediente: v.Id.val() }).then(function (e) {
                            v.body_facturas_pendientes.empty();
                            if (e.length > 0) {
                                $(e).each(function (i, o) {
                                    v.body_facturas_pendientes.append("<tr data-importe='" + o.Importe + "' data-id='" + o.Id + "'><td>" + o.NumeroDeFactura + "</td><td>" + o.Proveedor + "</td><td>$" + o.Importe + "</td><td><input type='checkbox' data-tipo='check' checked data-id='" + o.Id + "'></td></tr>");
                                });
                            }
                            else {
                                v.body_facturas_pendientes.append("<tr><td colspan='4'>No hay facturas pendientes de afectación</td></tr>");
                            }
                            v.modalFacturas.mostrar();
                        });
                    }
                    else {
                        var resultado = new Resultado();
                        var id = 0;
                        console.log("previo llamar a afectar");
                        that.postAfectar(v, "Resultado", [], resultado).done(function () {
                            if (resultado.estado) {
                                id = resultado.id;
                                app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                    that.expediente = e;
                                }).done(function () {
                                    console.log("imputacion: " + id);
                                    //var editor = new FormatEditor(that.expediente, 1007, id);
                                    //editor.test();
                                });
                                app.tabs.reloadCurrent();
                            }
                        });
                    }
                });
                v.Ordenado.click(function (e) {
                    // el expediente tiene facturas...
                    v.operacion = "compromiso_y_ordenado";
                    if (that.expediente.facturas.length > 0) {
                        app.getData("Expedientes/Expedientesadm/FacturasPendientesDeOP", { expediente: v.Id.val() }).then(function (e) {
                            v.body_facturas_pendientes.empty();
                            if (e.length > 0) {
                                $(e).each(function (i, o) {
                                    v.body_facturas_pendientes.append("<tr data-importe='" + o.Importe + "' data-id='" + o.Id + "'><td>" + o.NumeroDeFactura + "</td><td>" + o.Proveedor + "</td><td>$" + o.Importe + "</td><td><input type='checkbox' data-tipo='check' checked data-id='" + o.Id + "'></td></tr>");
                                });
                            }
                            else {
                                v.body_facturas_pendientes.append("<tr><td colspan='4'>No hay facturas pendientes de Orden de Pago</td></tr>");
                            }
                            v.modalFacturas.mostrar();
                        });
                    }
                    else {
                        var resultado = new Resultado();
                        var id = 0;
                        console.log("previo llamar a orden de pago");
                        that.postCompromisoYOrdenadoAPagar(v, "Resultado", [], resultado).done(function () {
                            if (resultado.estado) {
                                id = resultado.id;
                                app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                    that.expediente = e;
                                }).done(function () {
                                    console.log("imputacion: " + id);
                                });
                                app.tabs.reloadCurrent();
                            }
                        });
                    }
                });
                v.SobreAfectar.click(function (e) {
                    app.modal.cargar("Sobreafectar", "/Expedientes/expedientesadm/Sobreafectar/?expediente=" + v.Id.val());
                });
                v.Desafectar.click(function (e) {
                    app.modal.cargar("Desafectar", "/Expedientes/expedientesadm/Desafectar/?expediente=" + v.Id.val());
                });
                v.ConfirmarAfectacion.click(function (e) {
                    var resultado = new Resultado();
                    var id = 0;
                    console.log("previo llamar a orden de pago");
                    var f = [];
                    v.table_facturas_pendientes.find("input[type=checkbox]").each(function (i, o) {
                        if (this.checked)
                            f.push($(this).attr("data-id"));
                    });
                    console.log(v.operacion);
                    if (v.operacion == "afectar") {
                        that.postAfectar(v, "Resultado", f, resultado).done(function () {
                            if (resultado.estado) {
                                id = resultado.id;
                                app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                    that.expediente = e;
                                }).done(function () {
                                    console.log("imputacion: " + id);
                                    //var editor = new FormatEditor(that.expediente, 1007, id);
                                    //editor.test();
                                });
                                var tr = "<tr><td>Hace un momento</td><td>Afectación Preventiva</td><td>$" + resultado.anexos.total + "</td><td>" + app.global.nombre + "</td><td><a href='#'>ver</a></td></tr>";
                                v.body_contabilidad.append(tr);
                                //app.modal.cerrar();
                                app.tabs.reloadCurrent();
                            }
                        });
                    }
                    else if (v.operacion == "compromiso_y_ordenado") {
                        that.postCompromisoYOrdenadoAPagar(v, "Resultado", f, resultado).done(function () {
                            if (resultado.estado) {
                                id = resultado.id;
                                app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                    that.expediente = e;
                                }).done(function () {
                                    console.log("imputacion: " + id);
                                    //var editor = new FormatEditor(that.expediente, 1007, id);
                                    //editor.test();
                                });
                                var tr = "<tr><td>Hace un momento</td><td>Ordenado a Pagar</td><td>$" + resultado.anexos.total + "</td><td>" + app.global.nombre + "</td><td><a href='#'>ver</a></td></tr>";
                                v.body_contabilidad.append(tr);
                                app.tabs.reloadCurrent();
                            }
                        });
                    }
                    else {
                        if (v.operacion == "ordenado") {
                            that.postOrdenadoAPagar(v, "Resultado", f, resultado).done(function () {
                                if (resultado.estado) {
                                    id = resultado.id;
                                    app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                        that.expediente = e;
                                    }).done(function () {
                                        console.log("imputacion: " + id);
                                        //var editor = new FormatEditor(that.expediente, 1007, id);
                                        //editor.test();
                                    });
                                    var tr = "<tr><td>Hace un momento</td><td>Ordenado a Pagar</td><td>$" + resultado.anexos.total + "</td><td>" + app.global.nombre + "</td><td><a href='#'>ver</a></td></tr>";
                                    v.body_contabilidad.append(tr);
                                    app.tabs.reloadCurrent();
                                }
                            });
                        }
                        else {
                            if (v.operacion == "aco") {
                                that.postAfectar(v, "Resultado", f, resultado).done(function () {
                                    if (resultado.estado) {
                                        id = resultado.id;
                                        app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                            that.expediente = e;
                                        }).done(function () {
                                            console.log("imputacion: " + id);
                                            //var editor = new FormatEditor(that.expediente, 1007, id);
                                            //editor.test();
                                        });
                                        var tr = "<tr><td>Hace un momento</td><td>Afectación Preventiva</td><td>$" + resultado.anexos.total + "</td><td>" + app.global.nombre + "</td><td><a href='#'>ver</a></td></tr>";
                                        v.body_contabilidad.append(tr);
                                        //app.modal.cerrar();
                                        that.postCompromisoYOrdenadoAPagar(v, "Resultado", f, resultado).done(function () {
                                            if (resultado.estado) {
                                                id = resultado.id;
                                                app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                                    that.expediente = e;
                                                }).done(function () {
                                                    console.log("imputacion: " + id);
                                                    //var editor = new FormatEditor(that.expediente, 1007, id);
                                                    //editor.test();
                                                });
                                                var tr = "<tr><td>Hace un momento</td><td>Ordenado a Pagar</td><td>$" + resultado.anexos.total + "</td><td>" + app.global.nombre + "</td><td><a href='#'>ver</a></td></tr>";
                                                v.body_contabilidad.append(tr);
                                                app.tabs.reloadCurrent();
                                            }
                                        });
                                    }
                                });
                            }
                        }
                    }
                });
                v.AfectacionCompromisoOrdenado.click(function (e) {
                    v.operacion = "aco";
                    if (that.expediente.facturas.length > 0) {
                        app.getData("Expedientes/Expedientesadm/FacturasPendientesDeAfectar", { expediente: v.Id.val() }).then(function (e) {
                            v.body_facturas_pendientes.empty();
                            if (e.length > 0) {
                                $(e).each(function (i, o) {
                                    v.body_facturas_pendientes.append("<tr data-importe='" + o.Importe + "' data-id='" + o.Id + "'><td>" + o.NumeroDeFactura + "</td><td>" + o.Proveedor + "</td><td>$" + o.Importe + "</td><td><input type='checkbox' data-tipo='check' checked data-id='" + o.Id + "'></td></tr>");
                                });
                            }
                            else {
                                v.body_facturas_pendientes.append("<tr><td colspan='4'>No hay facturas pendientes de afectación</td></tr>");
                            }
                            v.modalFacturas.mostrar();
                        });
                    }
                    else {
                        var resultado = new Resultado();
                        var id = 0;
                        console.log("previo llamar a afectar");
                        that.postAfectar(v, "Resultado", [], resultado).done(function () {
                            if (resultado.estado) {
                                id = resultado.id;
                                //app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                //    that.expediente = e;
                                //}).done(function () {
                                //    console.log("imputacion: " + id);
                                //    //var editor = new FormatEditor(that.expediente, 1007, id);
                                //    //editor.test();
                                //});
                                that.postCompromisoYOrdenadoAPagar(v, "Resultado", [], resultado).done(function () {
                                    if (resultado.estado) {
                                        id = resultado.id;
                                        //app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                                        //    that.expediente = e;
                                        //}).done(function () {
                                        //    console.log("imputacion: " + id);
                                        //    //var editor = new FormatEditor(that.expediente, 1007, id);
                                        //    //editor.test();
                                        //});
                                        var tr = "<tr><td>Hace un momento</td><td>Ordenado a Pagar</td><td>$" + resultado.anexos.total + "</td><td>" + app.global.nombre + "</td><td><a href='#'>ver</a></td></tr>";
                                        v.body_contabilidad.append(tr);
                                        v.modalFacturas.cerrar();
                                        app.tabs.reloadCurrent().done(function () {
                                            console.log("Luego de hacer reload con compromiso y ordenado a pagar");
                                        });
                                    }
                                });
                            }
                        });
                    }
                });
                v.Seleccionar_Todas.click(function (e) {
                    if (this.checked) {
                        $("input[data-tipo=check]").each(function (i, o) {
                            $(this).prop("checked", "checked");
                        });
                    }
                    else {
                        $("input[data-tipo=check]").each(function (i, o) {
                            $(this).removeProp("checked");
                        });
                    }
                });
                v.NuevaActuacion.click(function (e) {
                    app.modal.cargar("Nueva Actuación", "Expedientes/Actuacionesadm/Crear/?expediente=" + v.Id.val());
                    //console.log("imputacion: " + id);
                    // var editor = new FormatEditor(that.expediente, 1007, id);
                    // editor.test();
                });
                app.getData("Expedientes/Expedientesadm/getdata", { id: v.Id.val() }).then(function (e) {
                    that.expediente = e;
                });
                app.getData("Expedientes/Expedientesadm/ObtenerPendienteDeOP", { expediente: v.Id.val() }).then(function (e) {
                    if (e.length > 0) {
                        v.table_pendiente_op.show();
                        $(e).each(function (i, o) {
                            v.body_pendiente_op.append("<tr><td>" + o.descripcion + "</td><td>$" + o.total + "</td></tr>");
                        });
                    }
                    else {
                        v.body_pendiente_op.append("<tr><td colspan='2'>No hay pendiente de Orden de Pago</td></tr>");
                    }
                });
            };
            ExpedientesADMManager.prototype.verActuacion = function (el) {
                var id = $(el).data("id");
                console.log("ANTES DE APP.MODAL.CARGAR");
                app.modal.cargar("Ver actuación", "Expedientes/actuacionesadm/editar/" + id);
                console.log("DESPUES DEL APP.MODAL CARGAR");
                return false;
            };
            ExpedientesADMManager.prototype.anularActuacion = function (el) {
                var id = $(el).data("id");
                bootbox.confirm("¿Está seguro que va desea anular esta actuación?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: 'Expedientes/Expedientesadm/anularactuacion',
                            data: { actuacion: id },
                            success: function (data) {
                                if (data[0]) {
                                    app.crearNotificacionSuccess("La actuación se anuló", data[1]);
                                    app.tabs.reloadCurrent();
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
                        }));
                    }
                });
                return false;
            };
            //--- Inicialización de la vista Editar
            ExpedientesADMManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Editar Expediente").done(function () {
                    });
                });
            };
            ExpedientesADMManager.prototype.refreshFacturas = function (id) {
                var self = this;
                self.ViewDetalle.body_facturas.empty();
                $.get("/expedientes/expedientesadm/facturas/?expediente=" + id, null, function (data) {
                    console.log(data);
                    $.each(data, function (i, o) {
                        var tr = "<tr>";
                        tr += "<td>" + app.formatearFecha(o.Fecha) + "</td>";
                        tr += "<td>" + o.Proveedor + "</td>";
                        tr += "<td>" + o.NumeroDeFactura + "</td>";
                        tr += "<td>" + o.Importe + "</td>";
                        tr += "<td>" + o.EstaAsignada + "</td>";
                        tr += !o.EstaAsignada ? "<td><button class='btn info btn- xs' data-id='" + o.Id + "' data-tipo='asignar'>Asignar</button></td>" : "<td>&nbsp;</td>";
                        self.ViewDetalle.body_facturas.append(tr);
                    });
                });
            };
            //--- Función editar de Datatable ExpedientesADM
            ExpedientesADMManager.prototype.detalle_dtExpedientesADM = function () {
                var id = this.ViewIndex.getData(0);
                var numero = this.ViewIndex.getData(2);
                app.createTab("Detalle " + numero, "/Expedientes/ExpedientesADM/detalle/?id=" + id, true, true, true);
            };
            ExpedientesADMManager.prototype.aceptar_dtExpedientesConCargoPendiente = function () {
                var self = this;
                var id = this.ViewIndexConCargo.getData(0);
                var numero = this.ViewIndexConCargo.getData(2);
                bootbox.confirm("¿Está seguro que va a aceptar el cargo del expediente " + numero + "?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: 'Expedientes/Expedientesadm/aceptarcargo',
                            data: { expediente: id, organismo: global.organismo },
                            success: function (data) {
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                    self.ViewIndexConCargo.ExpedientesADM.fnDraw();
                                    CheckCargos();
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
                        }));
                    }
                });
            };
            ExpedientesADMManager.prototype.detalle_dtExpedientesConCargoPendiente = function () {
                var id = this.ViewIndex.getData(0);
                var numero = this.ViewIndex.getData(2);
            };
            ExpedientesADMManager.prototype.editar_dtExpedientesADM = function () {
                var id = this.ViewIndex.getData(0);
                var numero = this.ViewIndex.getData(2);
                app.createTab("Editar " + numero, "/Expedientes/ExpedientesADM/Editar/" + id, true, true, true);
            };
            ExpedientesADMManager.prototype.asignar_dtExpedientesADM = function () {
                var id = this.ViewIndex.getData(0);
                var numero = this.ViewIndex.getData(2);
                app.modal.cargar("Asignar Expediente Nro: " + numero, "/Expedientes/ExpedientesADM/Asignar/?expediente=" + id);
                //app.createTab("Editar " + numero, , true, true, true);
            };
            //--- Función eliminar de Datatable ExpedientesADM
            ExpedientesADMManager.prototype.eliminar_dtExpedientesADM = function () {
                var id = this.ViewIndex.getData(0);
                //this.eliminar("ExpedientesADM/Eliminar", { id: id });
            };
            ExpedientesADMManager.prototype.guardarSobreAfectacion = function (titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                var imputacion;
                var compromiso_y_ordenado = false;
                if (that.ViewSobreafectar.ModificarCompromiso.is(":checked"))
                    compromiso_y_ordenado = true;
                imputacion = {
                    ExpedienteAImputar: that.ViewSobreafectar.Id.val(),
                    Operacion: 5,
                    ImputacionesContablesDetalle: new Array()
                };
                that.ViewSobreafectar.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if ($el.find("td input").val()) {
                        var detalle;
                        detalle = {
                            Partida: $el.data("partida"),
                            Division: $el.find("select").val(),
                            Importe: $el.find("td input").val().replace(".", ","),
                            //TODO: Obtener le año contable por usuario
                            AnioContable: 2016
                        };
                        imputacion.ImputacionesContablesDetalle.push(detalle);
                    }
                });
                console.log(imputacion);
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "Expedientes/Expedientesadm/Sobreafectar",
                    data: JSON.stringify({ imputacion: imputacion, compromiso_y_ordenado: compromiso_y_ordenado }),
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
            ExpedientesADMManager.prototype.guardarDesafectacion = function (titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                var imputacion;
                var compromiso_y_ordenado = false;
                if (that.ViewSobreafectar.ModificarCompromiso.is(":checked"))
                    compromiso_y_ordenado = true;
                imputacion = {
                    ExpedienteAImputar: that.ViewDesafectar.Id.val(),
                    Operacion: 5,
                    ImputacionesContablesDetalle: new Array()
                };
                that.ViewDesafectar.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if ($el.find("td input").val()) {
                        var detalle;
                        detalle = {
                            Partida: $el.data("partida"),
                            Division: $el.find("select").val(),
                            Importe: $el.find("td input").val().replace(".", ","),
                            //TODO: Obtener le año contable por usuario
                            AnioContable: 2016
                        };
                        imputacion.ImputacionesContablesDetalle.push(detalle);
                    }
                });
                console.log(imputacion);
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "Expedientes/Expedientesadm/Desafectar",
                    data: JSON.stringify({ imputacion: imputacion, compromiso_y_ordenado: compromiso_y_ordenado }),
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
            ExpedientesADMManager.prototype.guardarImputacion = function (titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                var imputacion;
                imputacion = {
                    ExpedienteAImputar: that.ViewAsignar.Id.val(),
                    Operacion: 1,
                    ImputacionesContablesDetalle: new Array()
                };
                that.ViewAsignar.Partidas.find("tr").each(function () {
                    var $el = $(this);
                    if ($el.find("td input").val()) {
                        var detalle;
                        detalle = {
                            Partida: $el.data("partida"),
                            Division: $el.find("select").val(),
                            Importe: $el.find("td input").val().replace(".", ","),
                            //TODO: Obtener le año contable por usuario
                            AnioContable: 2016
                        };
                        if (detalle.Importe > 0)
                            imputacion.ImputacionesContablesDetalle.push(detalle);
                    }
                });
                console.log(imputacion);
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "Expedientes/Expedientesadm/AsignarExpdiente",
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
            ExpedientesADMManager.prototype.postAfectar = function (v, titulo, facturas, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: "Expedientes/Expedientesadm/Afectar",
                        data: JSON.stringify({ expediente: that.ViewDetalle.Id.val(), facturas: facturas }),
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
            ExpedientesADMManager.prototype.postCompromisoYOrdenadoAPagar = function (v, titulo, facturas, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: "Expedientes/Expedientesadm/OrdenadoAPagar",
                        data: JSON.stringify({ expediente: that.ViewDetalle.Id.val(), facturas: facturas, compromiso: true }),
                        dataType: "json",
                        contentType: "application/json",
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.anexos.total = data[2];
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
            ExpedientesADMManager.prototype.postOrdenadoAPagar = function (v, titulo, facturas, resultado) {
                var that = this;
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
                if (v.form.valid()) {
                    app.Bloquear();
                    $.when($.ajax({
                        type: "POST",
                        url: "Expedientes/Expedientesadm/OrdenadoAPagar",
                        data: JSON.stringify({ expediente: that.ViewDetalle.Id.val(), facturas: facturas, compromiso: false }),
                        dataType: "json",
                        contentType: "application/json",
                        success: function (data) {
                            resultado.estado = data[0];
                            resultado.Mensaje(data[1]);
                            if (data[0]) {
                                app.crearNotificacionSuccess(titulo, data[1]);
                                resultado.anexos.total = data[2];
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
            //-- Método para pasar Vistas por Post según URL de formulario
            ExpedientesADMManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
            ExpedientesADMManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
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
            ExpedientesADMManager.prototype.eliminar = function (url, data, resultado) {
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
            return ExpedientesADMManager;
        }()); //JS	
        ts.ExpedientesADMManager = ExpedientesADMManager;
        var FacturasView = /** @class */ (function () {
            function FacturasView() {
            }
            return FacturasView;
        }());
        ts.FacturasView = FacturasView;
        var Facturas = /** @class */ (function () {
            function Facturas() {
            }
            return Facturas;
        }());
        ts.Facturas = Facturas;
        var ActuacionesView = /** @class */ (function () {
            function ActuacionesView() {
            }
            return ActuacionesView;
        }());
        ts.ActuacionesView = ActuacionesView;
    })(ts = ExpedientesADM.ts || (ExpedientesADM.ts = {}));
})(ExpedientesADM || (ExpedientesADM = {}));
