/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Consulta.ts"/>
/// <reference path="Limitar.ts"/>
/// <reference path="Excepcion.ts"/>
/// <reference path="ResumenOrganizacion.ts"/>
/// <reference path="Pendientes.ts"/>
/// <reference path="PendientesTodos.ts"/>
var LicenciasAgente;
(function (LicenciasAgente) {
    var ts;
    (function (ts) {
        var LicenciasAgenteManager = (function () {
            function LicenciasAgenteManager() {
                // Constructor
            }
            LicenciasAgenteManager.prototype.setResumenOrganizacion = function (v) {
                this.ViewResumenOrganizacion = v;
                v.Organismo.change(function (e) {
                    v.Resultados.refrescar("RRHH/LicenciasAgente/ResumenOrganismo/?organismo=" + v.Organismo.val());
                    //alert()
                    v.lblOrganismo.text(v.Organismo.find("option[value=" + v.Organismo.val() + "]").text());
                });
            };
            //--- Inicialización de la vista Index
            LicenciasAgenteManager.prototype.setIndex = function (v) {
                var that = this;
                this.ViewIndex = v;
                // Eventos de la vista
            };
            LicenciasAgenteManager.prototype.setPendientes = function (v) {
                var that = this;
                this.ViewPendientesAprobar = v;
                // Eventos de la vista
            };
            LicenciasAgenteManager.prototype.setPendientesTodos = function (v) {
                var that = this;
                this.ViewPendientesTodos = v;
                // Eventos de la vista
            };
            LicenciasAgenteManager.prototype.setExcepcion = function (v) {
                var self = this;
                this.ViewExcepcion = v;
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPostURL("RRHH/LicenciasAgente/CrearExcepcion", v.form.serialize(), "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            app.modal.cerrar();
                        }
                    });
                });
            };
            LicenciasAgenteManager.prototype.setLimitar = function (v) {
                var that = this;
                this.ViewLimitar = v;
                v.Cancelar.click(function (e) {
                    that.ViewConsulta.Modal.cerrar();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(v, "Limitar licencia", resultado).done(function (e) {
                        if (resultado.estado) {
                            that.ViewConsulta.Buscar.click();
                            that.ViewConsulta.Modal.cerrar();
                        }
                    });
                });
            };
            LicenciasAgenteManager.prototype.setEditarSolicitud = function (v) {
                var that = this;
                var tiene_expediente = false;
                this.ViewSolicitar = v;
                var licenciaMedica = [8, 9, 10, 11, 12, 49, 46];
                v.Dias.keypress(function (e) {
                    if (e.which != 8 && isNaN(String.fromCharCode(e.which))) {
                        e.preventDefault(); //stop character from entering input
                    }
                    if (e.which == 13 && v.Dias.val() != "") {
                        v.Codigo.focus();
                    }
                });
                v.Codigo.keyup(function (e) {
                    if (e.which == 13 && v.Codigo.val() != "") {
                        v.Observaciones.focus();
                    }
                });
                v.Observaciones.keyup(function (e) {
                    if (e.which == 13) {
                        v.GuardarYNuevo.click();
                    }
                });
                v.FechaDesde.change(function (e) {
                    var carpetaMedica = licenciaMedica.indexOf(parseInt(v.Licencia.valor())) >= 0;
                    if (!carpetaMedica) {
                        console.log("Update FechaDesde -> No es una carpeta médica");
                        v.Dias.val("");
                        v.FechaHasta.val("");
                        v.Dias.focus();
                    }
                    else {
                        console.log("Se debe actualizar la fechahasta");
                        //v.Dias.val("1");
                        var from = v.FechaDesde.val().split("/");
                        var desde = new Date(from[2], from[1] - 1, from[0]);
                        var hasta = new Date();
                        hasta.setTime(desde.getTime() + (v.Dias.val() - 1) * 86400000);
                        v.FechaHasta.val(that.convertDate(hasta));
                    }
                });
                v.Dias.keyup(function (e) {
                    //asignar a fechahasta x dias a fechadesde
                    var from = v.FechaDesde.val().split("/");
                    var desde = new Date(from[2], from[1] - 1, from[0]);
                    var hasta = new Date();
                    hasta.setTime(desde.getTime() + (v.Dias.val() - 1) * 86400000);
                    v.FechaHasta.val(that.convertDate(hasta));
                });
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.FiltroDesde.focusin(function (e) {
                    $(this).select();
                });
                v.FiltroHasta.focusin(function (e) {
                    $(this).select();
                });
                v.Guardar.click(function (e) {
                    v.Guardar.hide();
                    if (v.Dias.val() != "" && v.Licencia.valor() > 0) {
                        if ($("#Es_Funcionario").val() == "true" && that.ViewSolicitar.SubroganteRRHH.hidden.val() == "") {
                            bootbox.confirm("Usted es funcionario y no ha especificado un subrogante/suplente ¿Desea continuar sin subrogante/suplente?", function (result) {
                                if (result) {
                                    bootbox.prompt({
                                        title: "Por favor ingrese su clave de acceso",
                                        inputType: 'password',
                                        callback: function (result) {
                                            if (result) {
                                                $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                                    if (data) {
                                                        //está marcada la opción con chofer o medio de transporte es Auto Poder Judicial y no está asignado
                                                        var resultado = new ResultadoApp();
                                                        that.ajaxSolicitar(that.ViewSolicitar, "Nueva Licencia", resultado).done(function () {
                                                            if (resultado.state) {
                                                                that.ViewSolicitar.Licencias.refrescar();
                                                                if (that.ViewPendientesAprobar)
                                                                    that.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                                                console.log("tiene expediente: " + tiene_expediente);
                                                            }
                                                            else {
                                                                console.log(resultado.message.indexOf("se supera el límite"));
                                                                v.Guardar.show();
                                                            }
                                                        });
                                                    }
                                                    else {
                                                        app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                                        v.Guardar.show();
                                                    }
                                                });
                                            }
                                        }
                                    });
                                }
                                else {
                                    v.Guardar.show();
                                }
                            });
                        }
                        else {
                            bootbox.prompt({
                                title: "Por favor ingrese su clave de acceso",
                                inputType: 'password',
                                callback: function (result) {
                                    if (result) {
                                        $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                            if (data) {
                                                //está marcada la opción con chofer o medio de transporte es Auto Poder Judicial y no está asignado
                                                var resultado = new ResultadoApp();
                                                that.ajaxSolicitar(that.ViewSolicitar, "Nueva Licencia", resultado).done(function () {
                                                    if (resultado.state) {
                                                        that.ViewSolicitar.Licencias.refrescar();
                                                        if (that.ViewPendientesAprobar)
                                                            that.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                                        console.log("tiene expediente: " + tiene_expediente);
                                                    }
                                                    else {
                                                        console.log(resultado.message.indexOf("se supera el límite"));
                                                        v.Guardar.show();
                                                    }
                                                });
                                            }
                                            else {
                                                app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                                v.Guardar.show();
                                            }
                                        });
                                    }
                                    else {
                                        v.Guardar.show();
                                    }
                                }
                            });
                        }
                    }
                    else {
                        app.crearNotificacionError("Atención", "Debe ingresar la cantidad de días y el tipo de licencia a solicitar");
                        v.Guardar.show();
                    }
                });
            };
            LicenciasAgenteManager.prototype.setSolicitar = function (v) {
                var that = this;
                var tiene_expediente = false;
                this.ViewSolicitar = v;
                var licenciaMedica = [8, 9, 10, 11, 12, 49, 46];
                if (!global.email_agente || global.email_agente == "") {
                    bootbox.confirm("<strong>Atención!, no tenemos su email registrado</strong>. Por favor, ingrese a la opción <strong>Mis Datos</strong> de este sistema e indique su email. Es importante contar con email para poder recibir las notificaciones de licencias. Gracias.", function (result) {
                        $("a[data-title='Mis datos']").click();
                    });
                }
                v.ApruebaDGA.change(function (e) {
                    if (!this.checked) {
                        //v.TablaApruebaFuncionario.show();
                        v.ApruebaDGA2.prop("checked", "checked");
                        $("#tr_otro_funcionario").show();
                    }
                    else {
                        //v.TablaApruebaFuncionario.hide();
                        v.ApruebaDGA2.removeProp("checked");
                        $("#tr_otro_funcionario").hide();
                    }
                });
                v.ApruebaDGA2.change(function (e) {
                    if (!this.checked) {
                        //v.TablaApruebaFuncionario.show();
                        v.ApruebaDGA.prop("checked", "checked");
                        $("#tr_otro_funcionario").hide();
                    }
                    else {
                        //v.TablaApruebaFuncionario.hide();
                        v.ApruebaDGA.removeProp("checked");
                        $("#tr_otro_funcionario").show();
                    }
                });
                v.OtroAprueba.change(function (e) {
                    if (this.checked)
                        v.TablaApruebaOtroFuncionario.show();
                    else {
                        v.TablaApruebaOtroFuncionario.hide();
                        v.OtroFuncionarioAprueba.txt.val("");
                        v.OtroFuncionarioAprueba.hidden.val("");
                    }
                });
                v.Dias.keypress(function (e) {
                    if (e.which != 8 && isNaN(String.fromCharCode(e.which))) {
                        e.preventDefault(); //stop character from entering input
                    }
                    if (e.which == 13 && v.Dias.val() != "") {
                        v.Codigo.focus();
                    }
                });
                v.OtroFuncionarioAprueba.setCallback(function (data) {
                    $("#otro_funcionario_organismo").text("Organismo: " + data.item.organismo);
                    $("#otro_funcionario_cargo").text("Cargo: " + data.item.cargo.Descripcion);
                    if (data.item.email) {
                        $("#otro_funcionario_email").text("El mail será enviado a: " + data.item.email);
                        console.log(data);
                    }
                    else {
                        $("#otro_funcionario_email").text("El funcionario no tiene email asignado");
                        $.get("rrhh/restservices/agentedisponible/?agente=" + data.item.id, null, function (disponible) {
                            if (disponible) {
                                app.crearNotificacionError("Atención", "El agente " + data.item.label + " está de licencia y no puede aprobar la solicitud");
                                v.OtroFuncionarioAprueba.limpiar();
                                $("#otro_funcionario_email").text("");
                            }
                        });
                    }
                });
                v.FuncionarioAprueba.setCallback(function (data) {
                    $("#otro_funcionario_organismo_2").text("Organismo: " + data.item.organismo);
                    $("#otro_funcionario_cargo_2").text("Cargo: " + data.item.cargo.Descripcion);
                    if (data.item.email) {
                        $("#otro_funcionario_email_2").text("Email: " + data.item.email);
                        console.log(data);
                    }
                    else {
                        $("#otro_funcionario_email_2").text("El funcionario no tiene email asignado");
                        $.get("rrhh/restservices/agentedisponible/?agente=" + data.item.id, null, function (disponible) {
                            if (!disponible) {
                                app.crearNotificacionError("Atención", "El agente " + data.item.label + " está de licencia y no puede aprobar la solicitud");
                                v.FuncionarioAprueba.limpiar();
                                $("#otro_funcionario_email_2").text("");
                            }
                        });
                    }
                });
                v.Licencia.el.change(function () {
                    $("#panel_informacion").show();
                    v.Licencias.refrescar("RRHH/LicenciasAgente/JsonT/?agente=" + $("#AgenteSolicita").val() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    v.ResumenDias.refrescar("RRHH/LicenciasAgente/JsonTotales/?agente=" + $("#AgenteSolicita").val() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    //obtener el resumen de licencia
                    $.getJSON("RRHH/LicenciasAgente/ResumenLicenciaJson/?agente=" + $("#AgenteSolicita").val() + "&licencia=" + v.Licencia.valor(), null, function (data) {
                        v.EnElAnio.val(data.enelanio);
                        v.EnTotal.val(data.entotal);
                    });
                    if (v.Licencia.valor() != "7" && v.Licencia.valor() != "24" && v.Licencia.valor() != "47") {
                        var mensaje = $("#es_mp").val() == "true" ? "Deberá presentar la constancia o certificado correspondiente en Procuración General (enviarlo a procuracion-licencias@juslapampa.gob.ar)" : "Deberá presentar la constancia o certificado correspondiente en la Secretaría de Recursos Humanos (enviarlo a rrhh-licencias@juslapampa.gob.ar)";
                        $("#mensaje_certificado").show();
                        bootbox.confirm({
                            message: mensaje,
                            callback: function (result) {
                                console.log('This was logged in the callback: ' + result);
                            }
                        });
                    }
                    else {
                        $("#mensaje_certificado").hide();
                    }
                    console.log("Licencia: ", v.Licencia.valor());
                    var carpetaMedica = licenciaMedica.indexOf(parseInt(v.Licencia.valor())) >= 0;
                    if (carpetaMedica) {
                        v.divDias.hide();
                        v.divFechaHasta.hide();
                        v.Dias.val("1");
                        var from = v.FechaDesde.val().split("/");
                        var desde = new Date(from[2], from[1] - 1, from[0]);
                        var hasta = new Date();
                        hasta.setTime(desde.getTime() + (v.Dias.val() - 1) * 86400000);
                        v.FechaHasta.val(that.convertDate(hasta));
                    }
                    else {
                        v.divDias.val("").show();
                        v.divFechaHasta.val("").show();
                    }
                    v.fileCertificado1.setOnUploadDoneWithUrl(v.fileCertificado1.e.data("url") + "&carpetaMedica=" + carpetaMedica, function (e, file) {
                        v.Certificado1.val(file.Id).attr("data-nombre", file.Name);
                    });
                    v.fileCertificado2.setOnUploadDoneWithUrl(v.fileCertificado2.e.data("url") + "&carpetaMedica=" + carpetaMedica, function (e, file) {
                        v.Certificado2.val(file.Id).attr("data-nombre", file.Name);
                    });
                });
                v.Codigo.change(function (e) {
                    v.Licencia.el.find("option[data-codigo=" + v.Codigo.val() + "]").prop("selected", "selected");
                    v.Licencia.el.trigger("liszt:updated");
                    v.Licencias.refrescar("RRHH/LicenciasAgente/JsonT/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    v.ResumenDias.refrescar("RRHH/LicenciasAgente/JsonTotales/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    //obtener el resumen de licencia
                    $.getJSON("RRHH/LicenciasAgente/ResumenLicenciaJson/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor(), null, function (data) {
                        that.ViewCrear.EnElAnio.val(data.enelanio);
                        that.ViewCrear.EnTotal.val(data.entotal);
                    });
                    var carpetaMedica = licenciaMedica.indexOf(parseInt(v.Licencia.valor())) >= 0;
                    v.fileCertificado1.setOnUploadDoneWithUrl(v.fileCertificado1.e.data("url") + "&carpetaMedica=" + carpetaMedica, function (e, file) {
                        v.Certificado1.val(file.Id).attr("data-nombre", file.Name);
                    });
                    v.fileCertificado2.setOnUploadDoneWithUrl(v.fileCertificado2.e.data("url") + "&carpetaMedica=" + carpetaMedica, function (e, file) {
                        v.Certificado2.val(file.Id).attr("data-nombre", file.Name);
                    });
                });
                v.Codigo.keyup(function (e) {
                    if (e.which == 13 && v.Codigo.val() != "") {
                        v.Observaciones.focus();
                    }
                });
                v.Observaciones.keyup(function (e) {
                    if (e.which == 13) {
                        v.GuardarYNuevo.click();
                    }
                });
                v.FechaDesde.change(function (e) {
                    var carpetaMedica = licenciaMedica.indexOf(parseInt(v.Licencia.valor())) >= 0;
                    if (!carpetaMedica) {
                        console.log("Update FechaDesde -> No es una carpeta médica");
                        v.Dias.val("");
                        v.FechaHasta.val("");
                        v.Dias.focus();
                    }
                    else {
                        console.log("Se debe actualizar la fechahasta");
                        //v.Dias.val("1");
                        var from = v.FechaDesde.val().split("/");
                        var desde = new Date(from[2], from[1] - 1, from[0]);
                        var hasta = new Date();
                        hasta.setTime(desde.getTime() + (v.Dias.val() - 1) * 86400000);
                        v.FechaHasta.val(that.convertDate(hasta));
                    }
                });
                v.Dias.keyup(function (e) {
                    //asignar a fechahasta x dias a fechadesde
                    var from = v.FechaDesde.val().split("/");
                    var desde = new Date(from[2], from[1] - 1, from[0]);
                    var hasta = new Date();
                    hasta.setTime(desde.getTime() + (v.Dias.val() - 1) * 86400000);
                    v.FechaHasta.val(that.convertDate(hasta));
                });
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.FiltroDesde.focusin(function (e) {
                    $(this).select();
                });
                v.FiltroHasta.focusin(function (e) {
                    $(this).select();
                });
                v.Guardar.click(function (e) {
                    v.Guardar.hide();
                    if (v.Dias.val() != "" && v.Licencia.valor() > 0) {
                        if ($("#Es_Funcionario").val() == "true" && that.ViewSolicitar.SubroganteRRHH.hidden.val() == "") {
                            bootbox.confirm("Usted es funcionario y no ha especificado un subrogante/suplente ¿Desea continuar sin subrogante/suplente?", function (result) {
                                if (result) {
                                    bootbox.prompt({
                                        title: "Por favor ingrese su clave de acceso",
                                        inputType: 'password',
                                        callback: function (result) {
                                            if (result) {
                                                $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                                    if (data) {
                                                        //está marcada la opción con chofer o medio de transporte es Auto Poder Judicial y no está asignado
                                                        var resultado = new ResultadoApp();
                                                        that.ajaxSolicitar(that.ViewSolicitar, "Nueva Licencia", resultado).done(function () {
                                                            if (resultado.state) {
                                                                that.ViewSolicitar.Licencias.refrescar();
                                                                if (that.ViewPendientesAprobar)
                                                                    that.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                                                console.log("tiene expediente: " + tiene_expediente);
                                                            }
                                                            else {
                                                                console.log(resultado.message.indexOf("se supera el límite"));
                                                                v.Guardar.show();
                                                            }
                                                        });
                                                    }
                                                    else {
                                                        app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                                        v.Guardar.show();
                                                    }
                                                });
                                            }
                                        }
                                    });
                                }
                                else {
                                    v.Guardar.show();
                                }
                            });
                        }
                        else {
                            bootbox.prompt({
                                title: "Por favor ingrese su clave de acceso",
                                inputType: 'password',
                                callback: function (result) {
                                    if (result) {
                                        $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                            if (data) {
                                                //está marcada la opción con chofer o medio de transporte es Auto Poder Judicial y no está asignado
                                                var resultado = new ResultadoApp();
                                                that.ajaxSolicitar(that.ViewSolicitar, "Nueva Licencia", resultado).done(function () {
                                                    if (resultado.state) {
                                                        that.ViewSolicitar.Licencias.refrescar();
                                                        if (that.ViewPendientesAprobar)
                                                            that.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                                        console.log("tiene expediente: " + tiene_expediente);
                                                    }
                                                    else {
                                                        console.log(resultado.message.indexOf("se supera el límite"));
                                                        v.Guardar.show();
                                                    }
                                                });
                                            }
                                            else {
                                                app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                                v.Guardar.show();
                                            }
                                        });
                                    }
                                    else {
                                        v.Guardar.show();
                                    }
                                }
                            });
                        }
                    }
                    else {
                        app.crearNotificacionError("Atención", "Debe ingresar la cantidad de días y el tipo de licencia a solicitar");
                        v.Guardar.show();
                    }
                });
            };
            LicenciasAgenteManager.prototype.changeFechaDesde = function () {
                var v = this.ViewSolicitar;
                var licenciaMedica = [8, 9, 10, 11, 12, 49, 46];
                var carpetaMedica = licenciaMedica.indexOf(parseInt(v.Licencia.valor())) >= 0;
                if (!carpetaMedica) {
                    console.log("Update FechaDesde -> No es una carpeta médica");
                    v.Dias.val("");
                    v.FechaHasta.val("");
                    v.Dias.focus();
                }
                else {
                    console.log("Se debe actualizar la fechahasta");
                    //v.Dias.val("1");
                    var from = v.FechaDesde.val().split("/");
                    var desde = new Date(from[2], from[1] - 1, from[0]);
                    var hasta = new Date();
                    hasta.setTime(desde.getTime() + (v.Dias.val() - 1) * 86400000);
                    v.FechaHasta.val(this.convertDate(hasta));
                }
            };
            LicenciasAgenteManager.prototype.setSolicitarPorEnfermedad = function (v) {
                var that = this;
                var tiene_expediente = false;
                this.ViewSolicitarPorEnfermedad = v;
                v.Licencia.el.change(function () {
                    $("#panel_informacion").show();
                    v.Licencias.refrescar("RRHH/LicenciasAgente/JsonT/?agente=" + $("#AgenteSolicita").val() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    v.ResumenDias.refrescar("RRHH/LicenciasAgente/JsonTotales/?agente=" + $("#AgenteSolicita").val() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    //obtener el resumen de licencia
                    $.getJSON("RRHH/LicenciasAgente/ResumenLicenciaJson/?agente=" + $("#AgenteSolicita").val() + "&licencia=" + v.Licencia.valor(), null, function (data) {
                        v.EnElAnio.val(data.enelanio);
                        v.EnTotal.val(data.entotal);
                    });
                    if (v.Licencia.valor() != "7" && v.Licencia.valor() != "24" && v.Licencia.valor() != "47") {
                        var mensaje = $("#es_mp").val() == "true" ? "Deberá presentar la constancia o certificado correspondiente en Procuración General (enviarlo a procuracion-licencias@juslapampa.gob.ar)" : "Deberá presentar la constancia o certificado correspondiente en la Secretaría de Recursos Humanos (enviarlo a rrhh-licencias@juslapampa.gob.ar)";
                        $("#mensaje_certificado").show();
                        bootbox.confirm({
                            message: mensaje,
                            callback: function (result) {
                                console.log('This was logged in the callback: ' + result);
                            }
                        });
                    }
                    else {
                        $("#mensaje_certificado").hide();
                    }
                });
                v.Codigo.change(function (e) {
                    v.Licencia.el.find("option[data-codigo=" + v.Codigo.val() + "]").prop("selected", "selected");
                    v.Licencia.el.trigger("liszt:updated");
                    v.Licencias.refrescar("RRHH/LicenciasAgente/JsonT/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    v.ResumenDias.refrescar("RRHH/LicenciasAgente/JsonTotales/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    //obtener el resumen de licencia
                    $.getJSON("RRHH/LicenciasAgente/ResumenLicenciaJson/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor(), null, function (data) {
                        that.ViewCrear.EnElAnio.val(data.enelanio);
                        that.ViewCrear.EnTotal.val(data.entotal);
                    });
                });
                v.Observaciones.keyup(function (e) {
                    if (e.which == 13) {
                        v.GuardarYNuevo.click();
                    }
                });
                v.FechaDesde.change(function (e) {
                    v.Dias.val("");
                    v.FechaHasta.val("");
                    v.Dias.focus();
                });
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.FiltroDesde.focusin(function (e) {
                    $(this).select();
                });
                v.FiltroHasta.focusin(function (e) {
                    $(this).select();
                });
                v.Guardar.click(function (e) {
                    v.Guardar.hide();
                    if (v.Dias.val() != "" && v.Licencia.valor() > 0) {
                        if ($("#Es_Funcionario").val() == "true" && that.ViewSolicitar.SubroganteRRHH.hidden.val() == "") {
                            bootbox.confirm("El Agente es funcinario/magistrado. Debe indicar el Subrogante", function (result) {
                                if (result) {
                                    bootbox.prompt({
                                        title: "Por favor ingrese su clave de acceso",
                                        inputType: 'password',
                                        callback: function (result) {
                                            if (result) {
                                                $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                                    if (data) {
                                                        //está marcada la opción con chofer o medio de transporte es Auto Poder Judicial y no está asignado
                                                        var resultado = new ResultadoApp();
                                                        that.ajaxSolicitarPorEnfermedad(that.ViewSolicitar, "Nueva solicitud por Enfermedad", resultado).done(function () {
                                                            if (resultado.state) {
                                                                that.ViewSolicitar.Licencias.refrescar();
                                                                if (that.ViewPendientesAprobar)
                                                                    that.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                                            }
                                                            else {
                                                                console.log(resultado.message.indexOf("se supera el límite"));
                                                                v.Guardar.show();
                                                            }
                                                        });
                                                    }
                                                    else {
                                                        app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                                        v.Guardar.show();
                                                    }
                                                });
                                            }
                                        }
                                    });
                                }
                                else {
                                    v.Guardar.show();
                                }
                            });
                        }
                        else {
                            bootbox.prompt({
                                title: "Por favor ingrese su clave de acceso",
                                inputType: 'password',
                                callback: function (result) {
                                    if (result) {
                                        $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                            if (data) {
                                                //está marcada la opción con chofer o medio de transporte es Auto Poder Judicial y no está asignado
                                                var resultado = new ResultadoApp();
                                                that.ajaxSolicitar(that.ViewSolicitar, "Nueva Licencia", resultado).done(function () {
                                                    if (resultado.state) {
                                                        that.ViewSolicitar.Licencias.refrescar();
                                                        if (that.ViewPendientesAprobar)
                                                            that.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                                        console.log("tiene expediente: " + tiene_expediente);
                                                    }
                                                    else {
                                                        console.log(resultado.message.indexOf("se supera el límite"));
                                                        v.Guardar.show();
                                                    }
                                                });
                                            }
                                            else {
                                                app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                                v.Guardar.show();
                                            }
                                        });
                                    }
                                    else {
                                        v.Guardar.show();
                                    }
                                }
                            });
                        }
                    }
                    else {
                        app.crearNotificacionError("Atención", "Debe ingresar la cantidad de días y el tipo de licencia a solicitar");
                        v.Guardar.show();
                    }
                });
                //v.GuardarYNuevo.click(function (e) {
                //    var resultado = new Resultado();
                //    that.ajaxPost(that.ViewCrear, "Nueva Licencia", resultado).done(function () {
                //        that.ViewCrear.limpiar();
                //        that.ViewCrear.AgenteRRHH.txt.val("").focus();
                //        that.ViewCrear.Licencias.refrescar();
                //    });
                //});
                //v.Denegar.click(function (e) {
                //    $.get("RRHH/LicenciasAgente/totalDeDiasOrdinaria/?agente=" + v.AgenteRRHH.valor(), function (data) {
                //        var saldo = data[0];
                //        alert(saldo);
                //        if (saldo != v.Dias.val()) {
                //            bootbox.confirm("Los días (" + v.Dias.val() + ") no coninciden con el saldo (" + saldo + "). Desea pasar igualmente la denegatoria?", function (result) {
                //                if (result) {
                //                    app.Bloquear();
                //                    $.ajax({
                //                        type: "POST",
                //                        url: "RRHH/LicenciasAgente/Denegar",
                //                        data: v.form.serialize(),
                //                        success: function (data) {
                //                            if (data[0]) {
                //                                app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                //                            } else {
                //                                app.crearNotificacionError("Error", data[1]);
                //                            }
                //                        },
                //                        error: function (jqXhr, textStatus, errorThrown) {
                //                            alert("Error al procesar formulario ajax");
                //                        },
                //                        complete: function () {
                //                            app.Desbloquear();
                //                        }
                //                    });
                //                }
                //            });
                //        } else {
                //            app.Bloquear();
                //            $.ajax({
                //                type: "POST",
                //                url: "RRHH/LicenciasAgente/Denegar",
                //                data: v.form.serialize(),
                //                success: function (data) {
                //                    if (data[0]) {
                //                        app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                //                    } else {
                //                        app.crearNotificacionError("Error", data[1]);
                //                    }
                //                },
                //                error: function (jqXhr, textStatus, errorThrown) {
                //                    alert("Error al procesar formulario ajax");
                //                },
                //                complete: function () {
                //                    app.Desbloquear();
                //                }
                //            });
                //        }
                //    });
                //});
            };
            //--- Inicialización de la vista Crear
            LicenciasAgenteManager.prototype.setCrear = function (v) {
                var that = this;
                var tiene_expediente = false;
                this.ViewCrear = v;
                // Eventos de la vista
                //v.AgenteRRHH.callback = (function (ui: any) {
                //    alert("probando callback");
                //});
                v.txtLegajo.keyup(function (e) {
                    if (e.which == 13) {
                        $.get("Agentes/GetPorLegajo", { legajo: v.txtLegajo.val() }, function (data) {
                            v.AgenteRRHH.txt.val(data.item.agente);
                            v.AgenteRRHH.hidden.val(data.item.idagente);
                        });
                    }
                });
                v.AgenteRRHH.setCallback(function (ui) {
                    v.Legajo.html("&nbsp;Legajo: " + ui.item.legajo + " | DNI: " + ui.item.documento);
                    v.Expediente.html(ui.item.legajo);
                    if (ui.item.cargo.Grupo == 1) {
                        v.divSubrogante.css("display", "block");
                    }
                    else {
                        v.divSubrogante.css("display", "none");
                    }
                    v.AnioExpediente.val(ui.item.expediente);
                    //v.Licencias.refrescar("RRHH/LicenciasAgente/JsonT/?agente=" + ui.item.id + "&licencia=0&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    //v.ResumenDias.refrescar("RRHH/LicenciasAgente/JsonTotales/?agente=" + ui.item.id + "&licencia=0&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    v.FechaDesde.focus();
                });
                v.Dias.keyup(function (e) {
                    if (e.which == 13 && v.Dias.val() != "") {
                        v.Codigo.focus();
                    }
                });
                v.Licencia.el.change(function () {
                    v.Licencias.refrescar("RRHH/LicenciasAgente/JsonT/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    v.ResumenDias.refrescar("RRHH/LicenciasAgente/JsonTotales/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    //obtener el resumen de licencia
                    $.getJSON("RRHH/LicenciasAgente/ResumenLicenciaJson/?agente=" + v.AgenteRRHH.hidden.val() + "&licencia=" + v.Licencia.valor(), null, function (data) {
                        that.ViewCrear.EnElAnio.val(data.enelanio);
                        that.ViewCrear.EnTotal.val(data.entotal);
                    });
                });
                v.Codigo.change(function (e) {
                    v.Licencia.el.find("option[data-codigo=" + v.Codigo.val() + "]").prop("selected", "selected");
                    v.Licencia.el.trigger("liszt:updated");
                    v.Licencias.refrescar("RRHH/LicenciasAgente/JsonT/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    v.ResumenDias.refrescar("RRHH/LicenciasAgente/JsonTotales/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor() + "&fechadesde=" + v.FiltroDesde.val() + "&fechahasta=" + v.FiltroHasta.val());
                    //obtener el resumen de licencia
                    $.getJSON("RRHH/LicenciasAgente/ResumenLicenciaJson/?agente=" + v.AgenteRRHH.valor() + "&licencia=" + v.Licencia.valor(), null, function (data) {
                        that.ViewCrear.EnElAnio.val(data.enelanio);
                        that.ViewCrear.EnTotal.val(data.entotal);
                    });
                });
                v.Codigo.keyup(function (e) {
                    if (e.which == 13 && v.Codigo.val() != "") {
                        v.Observaciones.focus();
                    }
                });
                v.Observaciones.keyup(function (e) {
                    if (e.which == 13) {
                        v.GuardarYNuevo.click();
                    }
                });
                v.Dias.change(function (e) {
                    //asignar a fechahasta x dias a fechadesde
                    var from = v.FechaDesde.val().split("/");
                    var desde = new Date(from[2], from[1] - 1, from[0]);
                    var hasta = new Date();
                    if (parseInt(from[2]) > parseInt(v.AnioExpediente.val())) {
                        tiene_expediente = false;
                        alert("Atención! El agente no tiene expediente para el año de la licencia");
                        v.AnioExpediente.val(desde.getFullYear().toString());
                        v.AnioExpediente.pulsate({ color: "#09f" });
                    }
                    else {
                        tiene_expediente = true;
                    }
                    //hasta.setDate(desde.getDate() + v.Dias.val()-1);
                    hasta.setTime(desde.getTime() + (v.Dias.val() - 1) * 86400000);
                    v.FechaHasta.val(that.convertDate(hasta));
                });
                v.Cancelar.click(function (e) {
                    app.irATab(0);
                });
                v.FiltroDesde.focusin(function (e) {
                    $(this).select();
                });
                v.FiltroHasta.focusin(function (e) {
                    $(this).select();
                });
                v.Guardar.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Nueva Licencia", resultado).done(function () {
                        if (resultado.estado) {
                            that.ViewCrear.Licencias.refrescar();
                            console.log("tiene expediente: " + tiene_expediente);
                            if (!tiene_expediente) {
                                app.getData("RRHH/Agentes/GetData/?agente=" + v.AgenteRRHH.hidden.val()).done(function (data) {
                                    var lMargin = 15; //left margin in mm
                                    var rMargin = 15; //right margin in mm
                                    var pdfInMM = 150; // width of A4 in mm
                                    var doc = new jsPDF('p', 'mm', [215, 345]);
                                    var d = new Date();
                                    var n = d.getFullYear();
                                    //46 -> 60
                                    //
                                    //27 -> 20
                                    //95
                                    doc.setFontSize(20);
                                    doc.text((100 * 27 / 27), (60 * 29 / 27), n.toString());
                                    doc.text((55 * 27 / 27), (75 * 29 / 27), data.legajo.toString());
                                    doc.text((30 * 27 / 27), (220 * 29 / 27), data.nombre);
                                    //organismo
                                    doc.setFontSize(18);
                                    doc.text((30 * 29 / 27), (235 * 29 / 27), "S/LICENCIA");
                                    doc.text((30 * 29 / 27), (310 * 29 / 27), data.nombre);
                                    doc.addPage();
                                    doc.setFontSize(16);
                                    doc.text((145 * 29 / 27), (17 * 29 / 27), data.legajo.toString() + '-' + n.toString());
                                    doc.text((170 * 29 / 27), (32 * 29 / 27), data.legajo.toString());
                                    doc.setFontSize(12);
                                    doc.text((70 * 29 / 27), (40 * 29 / 27), data.nombre);
                                    doc.text((57 * 29 / 27), (48 * 29 / 27), data.cargo_actual);
                                    doc.text((135 * 29 / 27), (48 * 29 / 27), data.organismo);
                                    doc.setFontSize(16);
                                    doc.text((135 * 29 / 27), (63 * 29 / 27), n.toString());
                                    doc.autoPrint();
                                    window.open(doc.output('bloburl'), '_blank');
                                });
                                that.ViewCrear.limpiar();
                                that.ViewCrear.AgenteRRHH.txt.val("").focus();
                            }
                        }
                        else {
                            console.log(resultado.mensaje.indexOf("se supera el límite"));
                            console.log(resultado.anexos.diastopeexcepcion);
                            if (resultado.mensaje.indexOf("Se supera el límite") > 0 && resultado.anexos.diastopeexcepcion >= 0) {
                                app.modal.cargar("Excepción", "RRHH/LicenciasAgente/Excepcion/?licencia=" + v.Licencia.valor() + "&agente=" + v.AgenteRRHH.valor());
                            }
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    that.ajaxPost(that.ViewCrear, "Nueva Licencia", resultado).done(function () {
                        that.ViewCrear.limpiar();
                        that.ViewCrear.AgenteRRHH.txt.val("").focus();
                        that.ViewCrear.Licencias.refrescar();
                    });
                });
                v.Denegar.click(function (e) {
                    $.get("RRHH/LicenciasAgente/totalDeDiasOrdinaria/?agente=" + v.AgenteRRHH.valor(), function (data) {
                        var saldo = data[0];
                        alert(saldo);
                        if (saldo != v.Dias.val()) {
                            bootbox.confirm("Los días (" + v.Dias.val() + ") no coninciden con el saldo (" + saldo + "). Desea pasar igualmente la denegatoria?", function (result) {
                                if (result) {
                                    app.Bloquear();
                                    $.ajax({
                                        type: "POST",
                                        url: "RRHH/LicenciasAgente/Denegar",
                                        data: v.form.serialize(),
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
                                    });
                                }
                            });
                        }
                        else {
                            app.Bloquear();
                            $.ajax({
                                type: "POST",
                                url: "RRHH/LicenciasAgente/Denegar",
                                data: v.form.serialize(),
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
                            });
                        }
                    });
                });
            };
            LicenciasAgenteManager.prototype.convertDate = function (inputFormat) {
                function pad(s) { return (s < 10) ? '0' + s : s; }
                var d = new Date(inputFormat);
                return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
            };
            //--- Inicialización de la vista Consulta
            LicenciasAgenteManager.prototype.setConsulta = function (v) {
                var that = this;
                this.ViewConsulta = v;
                // Eventos de la vista
                v.Licencias.setearSeleccionable(true);
                $.contextMenu({
                    selector: "#" + v.Licencias.Id,
                    items: {
                        "Eliminar": {
                            name: "Eliminar",
                            callback: function () {
                                if (!(v.Licencias.id > 0)) {
                                    app.crearNotificacionInfo("ATENCION", "Debe primero seleccionar una licencia");
                                }
                                else {
                                    $.when(that.eliminar("LicenciasAgente/Eliminar", { id: v.Licencias.id })).done(function () {
                                        v.Buscar.click();
                                    });
                                }
                            }
                        },
                        "Limitar": {
                            name: "Limitar",
                            callback: function () {
                                if (!(v.Licencias.id > 0)) {
                                    app.crearNotificacionInfo("ATENCION", "Debe primero seleccionar una licencia");
                                }
                                else {
                                    that.ViewConsulta.Modal.cargar("Limitar licencia", "RRHH/LicenciasAgente/Limitar/" + v.Licencias.id);
                                }
                            }
                        },
                        "Dejarsinefecto": {
                            name: "Dejar Sin Efecto",
                            callback: function () {
                                if (!(v.Licencias.id > 0)) {
                                    app.crearNotificacionInfo("ATENCION", "Debe primero seleccionar una licencia");
                                }
                                else {
                                    bootbox.confirm("Está seguro que desea dejar sin efecto esta licencia?", function (result) {
                                        if (result) {
                                            var resultado = new Resultado();
                                            that.ajaxPostURL("LicenciasAgente/DejarSinEfecto", { licencia: v.Licencias.id }, "Sin efecto", resultado).done(function () {
                                                v.Licencias.refrescarPost({ agente: v.Agente.hidden.val(), licencia: 0 }, "LicenciasAgente/JsonT");
                                            });
                                        }
                                    });
                                }
                            }
                        },
                        "detalle": {
                            name: "Ver solicitud",
                            callback: function () {
                                if (!(v.Licencias.id > 0)) {
                                    app.crearNotificacionInfo("ATENCION", "Debe primero seleccionar una licencia");
                                }
                                else {
                                    app.modal.cargar("Detalle de la solicitud", "/rrhh/licenciasagente/pendientesaprobartodosdetalle/?licencia=" + v.Licencias.id);
                                }
                            }
                        }
                    }
                });
                v.Licencia.append("<option value=0>Todas</option>").find("option[value=0]").prop("selected", "selected");
                v.Licencia.trigger("liszt:updated");
                v.Agente.txt.blur(function (e) {
                    v.Licencias.refrescarPost({ agente: v.Agente.hidden.val(), licencia: 0 }, "LicenciasAgente/JsonT");
                    v.Licencias.id = 0;
                });
                v.Buscar.click(function (e) {
                    v.Licencias.refrescarPost(v.form.serialize(), "LicenciasAgente/JsonT");
                    v.Licencias.id = 0;
                });
            };
            LicenciasAgenteManager.prototype.setMiConsulta = function (v) {
                var that = this;
                this.ViewConsulta = v;
                // Eventos de la vista
                v.Licencias.setearSeleccionable(true);
                v.Licencia.append("<option value=0>Todas</option>").find("option[value=0]").prop("selected", "selected");
                v.Licencia.trigger("liszt:updated");
                v.Agente.txt.blur(function (e) {
                    v.Licencias.refrescarPost({ agente: v.Agente.hidden.val(), licencia: 0 }, "LicenciasAgente/JsonT");
                    v.Licencias.id = 0;
                });
                v.Buscar.click(function (e) {
                    v.Licencias.refrescarPost(v.form.serialize(), "LicenciasAgente/JsonT");
                    v.Licencias.id = 0;
                });
            };
            LicenciasAgenteManager.prototype.setConsultaMM = function (v) {
                var that = this;
                this.ViewConsulta = v;
                // Eventos de la vista
                v.Licencias.setearSeleccionable(true);
                v.Licencia.append("<option value=0>Todas</option>").find("option[value=0]").prop("selected", "selected");
                v.Licencia.trigger("liszt:updated");
                v.Agente.txt.blur(function (e) {
                    v.Licencias.refrescarPost({ agente: v.Agente.hidden.val(), licencia: 0 }, "LicenciasAgente/JsonT");
                    v.Licencias.id = 0;
                });
                v.Buscar.click(function (e) {
                    v.Licencias.refrescarPost(v.form.serialize(), "LicenciasAgente/JsonT");
                    v.Licencias.id = 0;
                });
            };
            //--- Función editar de Datatable LicenciasAgente
            LicenciasAgenteManager.prototype.editar_dtLicenciasAgente = function (id) {
                app.createTab("Editar", "RRHH/LicenciasAgente/Editar/" + id, true, true, true);
            };
            //--- Función eliminar de Datatable LicenciasAgente
            LicenciasAgenteManager.prototype.eliminar_dtLicenciasAgente = function (id) {
                this.eliminar("RRHH/LicenciasAgente/Eliminar", { id: id });
            };
            LicenciasAgenteManager.prototype.aprobarlicencia_dtAgentes = function (el) {
                var self = this;
                this.ViewPendientesAprobar.selectRow_Licencia(el);
                var id = this.ViewPendientesAprobar.getData(0);
                var token = this.ViewPendientesAprobar.getData(10);
                //app.createTab("Resumen " + descripcion, "RRHH/Agentes/ResumenMM/?agente=" + id, true, true, true);
                bootbox.confirm("Usted CONCEDE la licencia y queda registrada y confimada en el sistema de RRHH. Acepta?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "GET",
                            url: "/rrhh/restservices/aprobar_web/?id=" + id,
                            success: function (data) {
                                if (data.state) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data.message);
                                    self.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                }
                                else {
                                    app.crearNotificacionError("Error", data.message);
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
            LicenciasAgenteManager.prototype.confirmalicencia_dtAgentes = function (el) {
                var self = this;
                this.ViewPendientesAprobar.selectRow_Licencia(el);
                var id = this.ViewPendientesAprobar.getData(0);
                var token = this.ViewPendientesAprobar.getData(10);
                //app.createTab("Resumen " + descripcion, "RRHH/Agentes/ResumenMM/?agente=" + id, true, true, true);
                bootbox.confirm("Usted TOMA CONOCIMIENTO de la licencia y la envía a otro funcionario para su revisión y/o aprobación. Acepta?", function (result) {
                    if (result) {
                        window.open("/home/ConfirmarLicencia/?token=" + token);
                    }
                });
            };
            LicenciasAgenteManager.prototype.editarLicencia_dtAgentes = function (el) {
                var self = this;
                this.ViewPendientesAprobar.selectRow_Licencia(el);
                var id = this.ViewPendientesAprobar.getData(0);
                var agente = this.ViewPendientesAprobar.getData(1);
                app.modal.cargar("Editar carpeta médica de " + agente, "/RRHH/LicenciasAgente/EditarSolicitud/" + id);
            };
            LicenciasAgenteManager.prototype.verSolicitud_dtAgentes = function (el) {
                var self = this;
                this.ViewPendientesTodos.selectRow_Licencia(el);
                var id = this.ViewPendientesTodos.getData(0);
                //var token = this.ViewPendientesTodos.getData(10);
                //app.createTab("Resumen " + descripcion, "RRHH/Agentes/ResumenMM/?agente=" + id, true, true, true);
                //bootbox.confirm("Usted TOMA CONOCIMIENTO de la licencia y la envía a otro funcionario para su revisión y/o aprobación. Acepta?", function (result) {
                //    if (result) {
                //        window.open("/home/ConfirmarLicencia/?token=" + token);
                //    }
                //});
                app.modal.cargar("Detalle de la solicitud", "/rrhh/licenciasagente/pendientesaprobartodosdetalle/?licencia=" + id);
            };
            LicenciasAgenteManager.prototype.cancelarSolicitud_dtAgentes = function (el) {
                var self = this;
                this.ViewPendientesAprobar.selectRow_Licencia(el);
                var id = this.ViewPendientesAprobar.getData(0);
                var token = this.ViewPendientesAprobar.getData(10);
                //app.createTab("Resumen " + descripcion, "RRHH/Agentes/ResumenMM/?agente=" + id, true, true, true);
                bootbox.confirm("Está seguro que va cancelar esta solicitud?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "GET",
                            url: "/rrhh/restservices/cancelarsolicitud/?token=" + token,
                            success: function (data) {
                                if (data.state) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data.message);
                                    self.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                }
                                else {
                                    app.crearNotificacionError("Error", data.message);
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
            LicenciasAgenteManager.prototype.aprobarsubrogancia_dtAgentes = function (el) {
                var self = this;
                this.ViewPendientesAprobar.selectRow_Licencia(el);
                var id = this.ViewPendientesAprobar.getData(0);
                var token = this.ViewPendientesAprobar.getData(10);
                //app.createTab("Resumen " + descripcion, "RRHH/Agentes/ResumenMM/?agente=" + id, true, true, true);
                bootbox.confirm("Está seguro que va a aceptar esta subrogancia?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "GET",
                            url: "/rrhh/restservices/Aprobar_Subrogante_web/?token=" + token,
                            success: function (data) {
                                if (data.result) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data.message);
                                    self.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                }
                                else {
                                    app.crearNotificacionError("Error", data.message);
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
            LicenciasAgenteManager.prototype.desaprobarlicencia_dtAgentes = function (el) {
                var self = this;
                this.ViewPendientesAprobar.selectRow_Licencia(el);
                var id = this.ViewPendientesAprobar.getData(0);
                var token = this.ViewPendientesAprobar.getData(10);
                //app.createTab("Resumen " + descripcion, "RRHH/Agentes/ResumenMM/?agente=" + id, true, true, true);
                bootbox.confirm("Está seguro que va a desaprobar esta licencia?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "GET",
                            url: "/rrhh/restservices/Desaprobar_Web/?id=" + id,
                            success: function (data) {
                                if (data.state) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data.message);
                                    self.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                }
                                else {
                                    app.crearNotificacionError("Error", data.message);
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
            ;
            LicenciasAgenteManager.prototype.desaprobarsubrogancia_dtAgentes = function (el) {
                var self = this;
                this.ViewPendientesAprobar.selectRow_Licencia(el);
                var id = this.ViewPendientesAprobar.getData(0);
                var token = this.ViewPendientesAprobar.getData(10);
                //app.createTab("Resumen " + descripcion, "RRHH/Agentes/ResumenMM/?agente=" + id, true, true, true);
                bootbox.confirm("Está seguro que va a rechazar esta subrogancia?", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "GET",
                            url: "/rrhh/restservices/Desaprobar_Subrogante_web/?token=" + token,
                            success: function (data) {
                                if (data.state) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data.message);
                                    self.ViewPendientesAprobar.LicenciasAgente.fnDraw();
                                }
                                else {
                                    app.crearNotificacionError("Error", data.message);
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
            ;
            //-- Método para pasar Vistas por Post según URL de formulario
            LicenciasAgenteManager.prototype.ajaxPost = function (v, titulo, resultado) {
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
                            resultado.anexos.diastopeexcepcion = data[2];
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
                //    }
                return (df.promise());
            };
            LicenciasAgenteManager.prototype.ajaxSolicitar = function (v, titulo, resultado) {
                var that = this;
                var view = that.ViewSolicitar;
                var df = $.Deferred();
                //v.form.validate();
                var success = false;
                var retorno = 0;
                var agente_aprueba = view.FuncionarioAprueba.valor();
                if (view.OtroFuncionarioAprueba.valor() > 0)
                    agente_aprueba = view.OtroFuncionarioAprueba.valor();
                //if (view.ApruebaDGA.is(":checked"))
                //    agente_aprueba = null;
                //if (v.form.valid()) { 
                app.Bloquear();
                $.when($.ajax({
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json",
                    url: "/RRHH/RestServices/solicitarLicencia?agente=" + view.AgenteSolicita.val() + "&sdesde=" + view.FechaDesde.val() + "&shasta=" + view.FechaHasta.val() + "&licencia=" + view.Licencia.valor() + "&nombramiento=" + view.Nombramiento.val() + "&idsuperior=" + view.IdSuperior.val() + "&subrogante=" + view.SubroganteRRHH.hidden.val() + "&agenteaprueba=" + agente_aprueba + "&dga=" + view.ApruebaDGA.is(":checked") + "&certificado1=" + view.Certificado1.val() + "&certificado2=" + view.Certificado2.val(),
                    //data: JSON.stringify({agente: view.AgenteSolicita.val(), sdesde: view.FechaDesde.val(), shasta: view.FechaHasta.val(), licencia: view.Licencia.valor(), nombramiento: view.Nombramiento.val(), idsuperior: view.IdSuperior.val()}),
                    success: function (data) {
                        resultado.state = data.state;
                        resultado.Mensaje(data.message);
                        if (data.state) {
                            app.crearNotificacionSuccess(titulo, data.message);
                            resultado.id = data.id;
                        }
                        else {
                            app.crearNotificacionError("Error", data.message);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        resultado.exception = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                //    }
                return (df.promise());
            };
            LicenciasAgenteManager.prototype.ajaxSolicitarPorEnfermedad = function (v, titulo, resultado) {
                var that = this;
                var view = that.ViewSolicitar;
                var df = $.Deferred();
                //v.form.validate();
                var success = false;
                var retorno = 0;
                var agente_aprueba = view.FuncionarioAprueba.valor();
                if (view.OtroFuncionarioAprueba.valor() > 0)
                    agente_aprueba = view.OtroFuncionarioAprueba.valor();
                //if (view.ApruebaDGA.is(":checked"))
                //    agente_aprueba = null;
                //if (v.form.valid()) { 
                app.Bloquear();
                $.when($.ajax({
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json",
                    url: "/RRHH/RestServices/solicitarLicenciaPorEnfermedad?agente=" + view.AgenteSolicita.val() + "&sdesde=" + view.FechaDesde.val() + "&licencia=" + view.Licencia.valor() + "&nombramiento=" + view.Nombramiento.val() + "&idsuperior=" + view.IdSuperior.val() + "&subrogante=" + view.SubroganteRRHH.hidden.val(),
                    //data: JSON.stringify({agente: view.AgenteSolicita.val(), sdesde: view.FechaDesde.val(), shasta: view.FechaHasta.val(), licencia: view.Licencia.valor(), nombramiento: view.Nombramiento.val(), idsuperior: view.IdSuperior.val()}),
                    success: function (data) {
                        resultado.state = data.state;
                        resultado.Mensaje(data.message);
                        if (data.state) {
                            app.crearNotificacionSuccess(titulo, data.message);
                            resultado.id = data.id;
                        }
                        else {
                            app.crearNotificacionError("Error", data.message);
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert("Error al procesar formulario ajax");
                        resultado.exception = textStatus + " - " + errorThrown;
                    },
                    complete: function () {
                        app.Desbloquear();
                    }
                })).done(function () { df.resolve(); })
                    .fail(function () { df.reject(); }); //end ajax
                //    }
                return (df.promise());
            };
            LicenciasAgenteManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            LicenciasAgenteManager.prototype.eliminar = function (url, data) {
                var that = this;
                var df = $.Deferred();
                bootbox.confirm("Está seguro que desea eliminar esta licencia?", function (result) {
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
            return LicenciasAgenteManager;
        })();
        ts.LicenciasAgenteManager = LicenciasAgenteManager; //JS	
    })(ts = LicenciasAgente.ts || (LicenciasAgente.ts = {}));
})(LicenciasAgente || (LicenciasAgente = {}));
