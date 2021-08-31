/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var FeriasAgentes;
(function (FeriasAgentes) {
    var ts;
    (function (ts) {
        var FeriasAgentesManager = (function () {
            function FeriasAgentesManager() {
                // Constructor
            }
            //--- Inicialización de la vista Index
            FeriasAgentesManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                var from = v.Desde.split("/");
                var f = new Date(from[2], from[1] - 1, from[0]);
                var to = v.Hasta.split("/");
                var t = new Date(to[2], to[1] - 1, to[0]);
                $.datepicker.regional['es'] = {
                    closeText: 'Cerrar',
                    prevText: '<Ant',
                    nextText: 'Sig>',
                    currentText: 'Hoy',
                    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
                    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                    weekHeader: 'Sm',
                    dateFormat: 'dd/mm/yy',
                    firstDay: 1,
                    isRTL: false,
                    showMonthAfterYear: false,
                    yearSuffix: ''
                };
                $.datepicker.setDefaults($.datepicker.regional['es']);
                $("input[data-type=fecha]").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: f,
                    maxDate: t
                });
                // Eventos de la vista
                //Al seleccionar organismo del autocomplete de filtro
                v.Organismo.setCallback(function (ui) {
                    $("#Organismo-" + ui.item.id).show();
                    $("div[data-id]").not("[data-id=" + ui.item.id + "]").hide();
                });
                $("input[data-tipo=hasta]").change(function () {
                    var idc = $(this).closest("tr").data("agente");
                    that.controlarFechas($(this).data("orden"), idc, $(this).val(), $(this));
                    that.sumarDias(idc);
                });
                $("input[data-tipo=desde]").change(function () {
                    var idc = $(this).closest("tr").data("agente");
                    that.controlarFechas($(this).data("orden"), idc, $(this).val(), $(this));
                    that.sumarDias(idc);
                });
                v.Guardar.click(function (e) {
                    var organismo = $(this).data("id");
                    var feria = v.Feria_Id;
                    $("tr[data-organismo=" + organismo + "]").each(function (index, elem) {
                        var desde1 = $(this).find("input[name=desde1]").val();
                        var resultado = new Resultado();
                        if (desde1 != "") {
                            app.Bloquear();
                            var desde2 = $(this).find("input[name=desde2]").val();
                            var desde3 = $(this).find("input[name=desde3]").val();
                            var hasta1 = $(this).find("input[name=hasta1]").val();
                            var hasta2 = $(this).find("input[name=hasta2]").val();
                            var hasta3 = $(this).find("input[name=hasta3]").val();
                            var agente = $(this).data("agente");
                            var dias = $(this).find("input[name=dias]").val();
                            var id = $(this).find("input[name=id]").val();
                            var observaciones = "";
                            var sinefecto = false;
                            if (that.ViewIndex.Instancia.val() == 2) {
                                observaciones = $("tr[data-paso2=paso2_" + agente + "]").find("input[name=observaciones]").val();
                                sinefecto = $("tr[data-paso2=paso2_" + agente + "]").find("input[name=sinefecto]").is(':checked');
                            }
                            that.ajaxPostURL("RRHH/FeriasAgentes/AsignarFeria", { dias: dias, agente: agente, desde1: desde1, desde2: desde2, desde3: desde3, hasta1: hasta1, hasta2: hasta2, hasta3: hasta3, instancia: that.ViewIndex.Instancia.val(), feria: feria, id: id, observaciones: observaciones, sinefecto: sinefecto }, "Guardando feria", resultado).done(function () { app.Desbloquear(); });
                        }
                    });
                });
            };
            FeriasAgentesManager.prototype.diferencia = function (d1, d2, id) {
                var dias = parseInt($("#dias_" + id).val());
                var from = d1.split("/");
                var date1 = new Date(from[2], from[1] - 1, from[0]);
                from = d2.split("/");
                var date2 = new Date(from[2], from[1] - 1, from[0]);
                var timeDiff = Math.abs(date2.getTime() - date1.getTime());
                var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
                $("#dias_" + id).val(dias + diffDays + 1);
            };
            FeriasAgentesManager.prototype.sumarDias = function (id) {
                $("#dias_" + id).val("0");
                if ($("#hasta1_" + id).val().length > 0)
                    this.diferencia($("#desde1_" + id).val(), $("#hasta1_" + id).val(), id);
                if ($("#hasta2_" + id).val().length > 0)
                    this.diferencia($("#desde2_" + id).val(), $("#hasta2_" + id).val(), id);
                if ($("#hasta3_" + id).val().length > 0)
                    this.diferencia($("#desde3_" + id).val(), $("#hasta3_" + id).val(), id);
            };
            FeriasAgentesManager.prototype.controlarFechas = function (orden, idc, hasta, el) {
                var desde = $("input[name=desde" + orden + "][data-agente=" + idc + "]").val();
                if (desde > hasta) {
                    bootbox.alert("Error en la fecha de cierre de la licencia");
                    $(el).focus().val("");
                }
            };
            //--- Inicialización de la vista Crear
            FeriasAgentesManager.prototype.setCrear = function (v) {
                var that = this;
                this.ViewCrear = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    that.ajaxPost(that.ViewCrear, "Modificar título").done(function () {
                        that.ViewCrear.limpiar();
                    });
                });
            };
            //--- Inicialización de la vista Editar
            FeriasAgentesManager.prototype.setEditar = function (v) {
                var that = this;
                this.ViewEditar = v;
                // Eventos de la vista
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                v.Guardar.click(function (e) {
                    that.ajaxPost(that.ViewEditar, "Modificar título").done(function () {
                    });
                });
            };
            //--- Función editar de Datatable FeriasAgentes
            FeriasAgentesManager.prototype.editar_dtFeriasAgentes = function (id) {
                app.createTab("Editar", "RRHH/FeriasAgentes/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable FeriasAgentes
            FeriasAgentesManager.prototype.eliminar_dtFeriasAgentes = function (id) {
                this.eliminar("RRHH/FeriasAgentes/Eliminar", { id: id });
            };
            //-- Método para pasar Vistas por Post según URL de formulario
            FeriasAgentesManager.prototype.ajaxPost = function (v, titulo) {
                var that = this;
                var resultado = new Resultado();
                var df = $.Deferred();
                v.form.validate();
                var success = false;
                var retorno = 0;
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
            FeriasAgentesManager.prototype.ajaxPostURL = function (url, datapost, titulo, res) {
                var that = this;
                var df = $.Deferred();
                var success = false;
                var retorno = 0;
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: url,
                    data: datapost,
                    success: function (data) {
                        res.estado = data[0];
                        res.Mensaje(data[1]);
                        if (data[0]) {
                            that.confirmarOK("tr[data-agente=" + datapost.agente + "]");
                            $("#id_" + datapost.agente).val(data[2]);
                            $("#estado_" + datapost.agente).show();
                        }
                        else {
                            that.confirmarError("tr[data-agente=" + datapost.agente + "] td");
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
            FeriasAgentesManager.prototype.confirmarOK = function (elemento) {
                $(elemento).find("td").animate({ backgroundColor: '#CCFFCC' }, "slow");
                //$(elemento).find("td").animate({ backgroundColor: '#ffffff' }, "slow"); //original color
            };
            FeriasAgentesManager.prototype.confirmarError = function (elemento) {
                $(elemento).find("td").animate({ backgroundColor: '#CC3300' }, "slow");
                //$(elemento).find("td").animate({ backgroundColor: '#ffffff' }, "slow"); //original color
            };
            FeriasAgentesManager.prototype.eliminar = function (url, data) {
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
            return FeriasAgentesManager;
        })();
        ts.FeriasAgentesManager = FeriasAgentesManager; //JS	
    })(ts = FeriasAgentes.ts || (FeriasAgentes.ts = {}));
})(FeriasAgentes || (FeriasAgentes = {}));
