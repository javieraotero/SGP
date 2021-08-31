/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="Eliminar.ts"/>
/// <reference path="Detalle.ts"/>
/// <reference path="Resumen.ts"/>
/// <reference path="Bonificaciones.ts"/>
/// <reference path="IndexBonificaciones.ts"/>
/// <reference path="CrearMovimientoCesida.ts"/>
module Agentes.ts {

    export class AgentesManager {

        public ViewIndex: Index;
        public ViewCrear: Crear;
        public ViewEditar: Crear;
        public ViewEliminar: Eliminar;
        public ViewDetalle: Detalle;
        public ViewResumen: Resumen;
        public ViewBonificaciones: Bonificaciones;
        public ViewCrearMovimientoCeida: CrearMovimientoCesida;
        public ViewIndexBonificaciones: IndexBonificaciones;

        constructor() {
            // Constructor
        }

        //--- Inicialización de la vista Index
        public setIndex(v: Index) {
            var that = this;
            this.ViewIndex = v;
            // Eventos de la vista

        }

        public setIndexBonificaciones(v: IndexBonificaciones) {
            var that = this;

            this.ViewIndexBonificaciones = v;


        }


        public setCrearMovimientoCesida(v: CrearMovimientoCesida) {
            var that = this;
            this.ViewCrearMovimientoCeida = v;
            
            app.getData("rrhh/nombramientos/getNombramiento/?agente=" + v.Agente.val(), null).done(function (data) {
                v.Nombramiento = data;
            });

            v.Movimiento.change(function (e) {
                v.body_parametros.empty();
                $.get("rrhh/agentes/GetParametrosDeMovimiento/?movimiento=" + v.Movimiento.val(), null, function (data) {
                    $.each(data, function (i, o) {
                        var tr = "<tr><td>" + o.Descripcion + "</td>";
                        tr += "<td>";

                        //campo que hay que obtener por autocomplete
                        if (o.Referencia != null) {
                            tr += "<input type='text' id='txt" + o.Descripcion+"' data-name='"+o.Descripcion+"' class='form-control' /><input type='hidden' id='"+o.Descripcion+"' />";
                        } else {
                            tr += "<input type='text' id='" + o.Descripcion +"' data-name='"+o.Descripcion+"' class='form-control' />";
                        }

                        tr += "</td></tr>";

                        v.body_parametros.append(tr);

                        //El elemento tiene valor predeterminado
                        if (o.Predeterminado != null) {
                            $("input[data-name="+o.Descripcion+"]").val(eval(o.Predeterminado));
                        }

                        //Hay que hacer un autocomplete
                        if (o.Referencia != null) {
                            console.log("referencia");
                            var x = new SyncroAutocomplete(o.Descripcion, o.Referencia);
                        }

                        //es un campo fecha
                        if (o.TipoDeDato == 2) {
                            $("#" + o.Descripcion).datepicker(pickerOpts); 
                        }
                    });
                    v.body_parametros.append("<tr><td colspan='2'><input type='button' class='btn blue' value='Guardar e informar'></button></td></tr>");
                    v.row_parametros.show();
                });
            });

        }

        public setBonificaciones(v: Bonificaciones) {

            var that = this;
            this.ViewBonificaciones = v;

            v.Mes.keyup(function (e) {
                if (e.which == 13) {
                    v.Anio.focus();
                }
            });

            v.Anio.keyup(function (e) {

                //console.log("Anio keyup");

                if (e.which == 13) {

                    var mes = parseInt(v.Mes.val());
                    var anio = parseInt(v.Anio.val());

                    console.log(anio + " / " + mes);

                    if (mes > 2)
                        mes = mes - 2;

                    var dias = that.daysInMonth(mes, anio);

                    var desde = "01/" + mes + "/" + anio;
                    var hasta = dias + "/" + mes + "/" + anio;



                    v.Desde.val(desde);
                    v.Hasta.val(hasta);
                }

            });

            $("input[data-tipo=dias]").die("change");
            $("input[data-tipo=dias]").live("change", function (e) {
                var input = $(this).closest("tr").find("input[data-tipo=txtdias]");
                $(input).val(30 - parseInt($(this).val()));
                $(this).closest("tr").data("diaslicencia", parseInt($(this).val()));

            });

            $("input[data-tipo=chklegajo]").die("click");
            $("input[data-tipo=chklegajo]").live("click", function (e) {
                console.log("change aplica");
                if (!this.checked) {
                    $(this).closest("tr").find("input[data-tipo=txtdias]").val("");
                    $(this).closest("tr").find("td").each(function (i, o) {
                        $(o).css("background-color", "#f9d895");
                    });
                } else {
                    $(this).closest("tr").find("input[data-tipo=txtdias]").val("25");
                    $(this).closest("tr").find("td").each(function (i, o) {
                        $(o).css("background-color", "");
                    });
                }
            });

            v.Ver.click(function (e) {
                e.preventDefault();

                $.get("rrhh/agentes/GetAgentesConBonificaciones", { desde: v.Desde.val(), hasta: v.Hasta.val(), mes: v.Mes.val(), anio: v.Anio.val() }, function (data) {
                    v.body_agentes.empty();
                    var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                        "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
                    ];

                    var dias_mes = that.daysInMonth(v.Mes.val(), v.Anio.val());

                    $.each(data, function (i, o) {
                        if (o.Dias > 30)
                            o.Dias = 30;

                        var dias_agente = 30 - o.Dias;
                        v.body_agentes.append("<tr data-diaslicencia='"+o.Dias+"' data-organismo='"+o.IdOrganismo+"' data-cargo='"+o.IdCargo+"' data-id='"+o.Id+"' data-agente='"+o.Agente+"'><td>" + o.Organismo + "</td><td><input data-tipo='chklegajo' id='aplica_" + o.Legajo + "' type='checkbox' checked /></td><td>" + o.Legajo + "</td><td>" + o.Nombre + "</td><td>" + o.Cargo + "</td><td><input type='text' data-tipo='txtporcentaje' id='porcentaje_" + o.Legajo + "' class='form-control' value='" + o.Porcentaje + "' /></td><td>" + meses[v.Mes.val() - 1] + "</td><td><input type='text' class='form-control' data-tipo='dias' value='" + o.Dias + "' /></td><td><input type='text' data-tipo='txtdias' id='dias_" + o.Legajo + "' class='form-control' disabled value='" + dias_agente + "' /></td></tr>");


                    });

                });

            });

            v.Guardar.click(function (e) {

                var bonificaciones = [];

                $.each(v.body_agentes.find("tr"), function (i, o) {
                    
                    var b = {
                        Agente: $(o).data("agente"),
                        Mes: v.Mes.val(),
                        Anio: v.Anio.val(),
                        Porcentaje: $(o).find("input[data-tipo=txtporcentaje]").val(),
                        Aprobado: $(o).find("input[data-tipo=chklegajo]").is(":checked"),
                        FechaDesde: v.Desde.val(),
                        FechaHasta: v.Hasta.val(),
                        Cargo: $(o).data("cargo"),
                        Organismo: $(o).data("organismo"),
                        Id: $(o).data("id"),
                        Aplica: $(o).find("input[data-tipo=chklegajo]").is(":checked"),
                        DiasDeLicencia: $(o).data("diaslicencia")
                    };                   

                    bonificaciones.push(b);

                });

                var r = new Resultado();
                that.guardarBonificaciones(bonificaciones, "Guardar bonificaciones", r);
            });

            v.Excel.click(function (e) {
                e.preventDefault();
                window.open("/rrhh/agentes/GenerarExcelBonificaciones/?desde=" + v.Desde.val()+"&hasta="+v.Hasta.val()+"&mes="+v.Mes.val()+"&anio="+v.Anio.val(), "_blank");
            });

            v.ExcelMP.click(function (e) {
                e.preventDefault();
                window.open("/rrhh/agentes/GenerarExcelBonificacionesMP/?desde=" + v.Desde.val() + "&hasta=" + v.Hasta.val() + "&mes=" + v.Mes.val() + "&anio=" + v.Anio.val(), "_blank");
            });

        }


        //--- Inicialización de la vista Index
        public setResumen(v: Resumen) {
            var that = this;
            this.ViewResumen = v;
            // Eventos de la vista

        }

        //--- Inicialización de la vista Crear
        public setCrear(v: Crear) {
            var that = this;
            this.ViewCrear = v;
            // Eventos de la vista

            v.Cancelar.click(function (e) {
                app.irATab(0);
            });

            v.EstudiosCursados.change(function (e) {
                console.log(e);
            });


            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewCrear, "Resultado", resultado).done(function () {

                });
            });

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewCrear, "Resultado", resultado).done(function () {
                    that.ViewCrear.limpiar();
                });
            });

            v.Persona.click(function (e) {
                v.Modal.setearTitulo("Seleccionar Persona");
                v.Modal.loadAjax("Personas/Buscar");
                v.Modal.mostrar();
            });

        }

        //--- Inicialización de la vista Editar
        public setEditar(v: Crear) {
            var that = this;
            this.ViewEditar = v;
            // Eventos de la vista

            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                that.ajaxPost(that.ViewEditar, "Resultado", resultado).done(function () {
                });
            });

            v.Persona.click(function (e) {
                v.Modal.setearTitulo("Seleccionar Persona");
                v.Modal.loadAjax("Personas/Buscar");
                v.Modal.mostrar();
            });

        }

        //--- Inicialización de la vista Eliminar
        public setEliminar(v: Eliminar) {
            var that = this;
            this.ViewEliminar = v;
            // Eventos de la vista

        }

        //--- Inicialización de la vista Detalle
        public setDetalle(v: Detalle) {
            var that = this;
            this.ViewDetalle = v;
            // Eventos de la vista

        }

        //--- Función editar de Datatable Agentes
        public editar_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var i = new ItemMenu();
            i.label = "Editar";
            i.close = true;
            i.url = "RRHH/Agentes/Editar/" + id;
            i.cache = true;
            app.tabs.crearTab(i, true);
            //app.createTab("Editar", "Agentes/Editar/" + id, true, true, true);
        }

        //public ver_turno(): void {
        //    var id = this.ViewIndex.getData(0);
        //    var i = new ItemMenu();
        //    i.label = "Editar";
        //    i.close = true;
        //    i.url = "RRHH/Agentes/Editar/" + id;
        //    i.cache = true;
        //    app.tabs.crearTab(i, true);
        //    //app.createTab("Editar", "Agentes/Editar/" + id, true, true, true);
        //}

        public ver_proveedor(): void {
            var id = this.ViewIndex.getData(0);
            var i = new ItemMenu();
            i.label = "Editar";
            i.close = true;
            i.url = "RRHH/Agentes/Editar/" + id;
            i.cache = true;
            app.tabs.crearTab(i, true);
            //app.createTab("Editar", "Agentes/Editar/" + id, true, true, true);
        }

        //--- Función editar de Datatable Agentes
        public docencia_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var i = new ItemMenu();
            i.label = "Docencia";
            i.close = true;
            i.url = "RRHH/AgentesDocencia/Index/" + id;
            i.cache = true;
            app.tabs.crearTab(i, true);
            //app.createTab("Editar", "Agentes/Editar/" + id, true, true, true);
        }

        public adjuntos_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            var i = new ItemMenu();
            i.label = "Legajo digital de " + descripcion;
            i.close = true;
            i.url = "/RRHH/Agentes/ArchivosAdjuntos/?id=" + id;
            i.cache = true;
            app.tabs.crearTab(i, true);            
        }

        public certificado_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(1);
            
            $.get("RRHH/Agentes/crearcertificacion/" + id, null, function (e) {
                window.open("/Files/Certificaciones/Certificacion_servicios_" + descripcion + ".docx");
            });
        }

        //--- Función imprimir carátula
        public imprimircaratula_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            
            bootbox.prompt("Observaciones (impreso)", function (result) {

                app.getData("RRHH/Agentes/GetData/?agente=" + id).done(function (data) {
                    var lMargin = 15; //left margin in mm
                    var rMargin = 15; //right margin in mm
                    var pdfInMM = 150;  // width of A4 in mm

                    var doc = new jsPDF('p', 'mm', [215, 345]);


                    var d = new Date();
                    var n = "2021";//d.getFullYear();

                    //46 -> 60
                    //

                    //27 -> 20
                    //95
                    doc.setFontSize(20);
                    doc.text((100 * 27 / 27), (65 * 29 / 27), n.toString());

                    doc.text((55 * 27 / 27), (80 * 29 / 27), data.legajo.toString());

                    doc.setFontType("bold");
                    doc.text((30 * 27 / 27), (215 * 29 / 27), data.nombre);
                    doc.setFontType("normal");

                    //organismo
                    doc.setFontSize(18);
                    doc.text((30 * 29 / 27), (230 * 29 / 27), "S/LICENCIA");

                    if (result) {
                        doc.setFontSize(18);
                        doc.text((30 * 29 / 27), (260 * 29 / 27), "JUEZ DE PAZ SUP.: " + result);
                    }

                    doc.setFontType("bold");
                    doc.text((30 * 29 / 27), (300 * 29 / 27), data.nombre);
                    doc.setFontType("normal");

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

                    //var lines = doc.splitTextToSize(v.Caratula.val(), (pdfInMM - lMargin - rMargin));
                    //doc.text(15, 50, lines);
                    //doc.addPage();
                    //doc.text(20, 20, 'Do you like that?');
                    //app.tabs.reloadCurrent();
                    doc.autoPrint();
                    window.open(doc.output('bloburl'), '_blank');
                });


            });

            

            //var i = new ItemMenu();
            //i.label = "Docencia";
            //i.close = true;
            //i.url = "RRHH/AgentesDocencia/Index/" + id;
            //i.cache = true;
            //app.tabs.crearTab(i, true);
            //app.createTab("Editar", "Agentes/Editar/" + id, true, true, true);
        }

        //--- Función eliminar de Datatable Agentes
        public eliminar_dtAgentes(id: number): void {
            var res = new Resultado();
            this.eliminar("RRHH/Agentes/Eliminar", { id: id }, res);
            if (res.estado)
                this.ViewIndex.Agentes.fnDraw();          
        }

        //--- Función nombramientos de Datatable Agentes
        public nombramientos_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            var i = new ItemMenu();
            i.label = "Nombramientos de "+ descripcion;
            i.close = true;
            i.url = "RRHH/Nombramientos/Index/?agente=" + id;
            i.cache = true;
            app.tabs.crearTab(i, true);
            //pp.createTab("Nombramientos", "Nombramientos/Index/?agente=" + id, true, true, true);
        }

        //--- Función sustituciones de Datatable Agentes
        public sustituciones_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            app.createTab("Sustituciones de " + descripcion, "RRHH/Sustituciones/Index/?agente=" + id, true, true, true);
        }

        //--- Función medidas de Datatable Agentes
        public medidas_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            app.createTab("Medidas Disciplinarias de " + descripcion, "RRHH/MedidasDisciplinarias/Index/?agente=" + id, true, true, true);
        }

        //--- Función grupofamiliar de Datatable Agentes
        public grupofamiliar_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            app.createTab("Grupo Familiar de " + descripcion, "RRHH/GrupoFamiliar/Index/?agente=" + id, true, true, true);
        }

        //--- Función licencias de Datatable Agentes
        public licencias_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            app.createTab("Licencias de " + descripcion, "RRHH/LicenciasAgente/Consulta/?agente=" + id, true, true, true);
        }

        //--- Función licencias de Datatable Agentes
        public licenciasmm_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            app.createTab("Licencias de " + descripcion, "RRHH/LicenciasAgente/ConsultaMM/?agente=" + id, true, true, true);
        }

        //--- Función grupofamiliar de Datatable Agentes
        public resumen_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            app.createTab("Resumen " + descripcion, "RRHH/Agentes/Resumen/?agente=" + id, true, true, true);
        }

        //--- Función grupofamiliar de Datatable Agentes
        public movimientoscesida_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            app.createTab("Movimientos " + descripcion, "RRHH/Agentes/CrearMovimientoCesida/?agente=" + id, true, true, true);
        }

        //--- Función grupofamiliar de Datatable Agentes
        public resumenmm_dtAgentes(): void {
            var id = this.ViewIndex.getData(0);
            var descripcion = this.ViewIndex.getData(2);
            app.createTab("Resumen " + descripcion, "RRHH/Agentes/ResumenMM/?agente=" + id, true, true, true);
        }

        public guardarBonificaciones(bonificaciones: any, titulo: string, resultado: Resultado) {
            app.Bloquear();
            $.ajax({
                type: "POST",
                url: "rrhh/agentes/GuardarPlanillaDeBonificaciones",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify({ usuario: Usuarios }),
                success: function (data) {
                    resultado.estado = data[0];
                    resultado.Mensaje(data[1]);
                    if (data[0]) {
                        resultado.anexos.nro = data[3];
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
            })
        }


        //-- Método para pasar Vistas por Post según URL de formulario
        public ajaxPost(v: IControlador, titulo: string, resultado:Resultado): JQueryDeferred {
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

        public eliminar(url: string, data: any, res?:Resultado): JQueryDeferred {
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
                            res.estado = data[0];
                            res.mensaje = data[1];
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

        public daysInMonth(month, year) {
            return new Date(year, month, 0).getDate();
        }

        public getDaysInMonth(m: number, y:number) {
            return /8|3|5|10/.test(--m) ? 30 : m == 1 ? (!(y % 4) && y % 100) || !(y % 400) ? 29 : 28 : 31;
        }

    }//JS	
}