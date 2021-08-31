/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module ExpedientesADM.ts {
	
	export class Index implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        public index: number;
        public index_multi: Array<number>;
        public numeros_multi: Array<string>;
				 
		public ExpedientesADM:DataTables.DataTable;
        public ExpedientesADM_Id: number;
        public ExpedientesADM_Index: number;
        public ExpedientesADM_Id_multi: Array<any>;
        public spExpedientes: JQuery;
        public hash: string;
        public modal: SyncroModal;
        public body_expedientes: JQuery;
        public Confirmar: JQuery;
        public Generar: JQuery;
        public Organismo: JQuery;
        public Observaciones: JQuery;
        public Archivar: JQuery;
        public ArchivarConfirmar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
            this.datatables = [];
            this.index_multi = [];		
            this.ExpedientesADM_Id_multi = [];
            this.hash = hash;
			//operaciones			
		}
		
		public limpiar():void {			
			this.ExpedientesADM.fnDraw();
		}
		
		//--- Funciones para seteo de Datatables ---/
		public setExpedientesADM(dt: DataTables.DataTable):void {
            var that = this;
            this.ExpedientesADM = dt;            

            $("#dtExpedientesADM tbody").click(function (event) {
                $(that.ExpedientesADM.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
         
                var id = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[0];
                that.ExpedientesADM_Id = id;
                that.index = $(event.target).closest("tr").index();
            });

            $(document).unbind("keydown");
            $(document).on("keydown", function (e) {
                if ((((e.which || e.keyCode) == 38) || ((e.which || e.keyCode) == 40)) && ($("input[aria-controls=dtExpedientesADM]").is(":focus") || $(".text_filter").is(":focus"))) {
                    e.preventDefault();
                    e.stopImmediatePropagation();
                    var i = $("#dtExpedientesADM tbody").find("tr.row_selected").index();

                    //console.log("se presiona tecla del cursor en dtArticulos");
                    //if (i < 1)
                    //    i = 0;
                    console.log(i);
                    var next: number;

                    if (((e.which || e.keyCode) == 40)) {
                        if (i == that.ExpedientesADM.fnSettings()._iDisplayLength - 1) {
                            that.ExpedientesADM.fnPageChange("next");
                            next = 0;
                        } else
                            next = i + 1;
                    }
                    else {
                        if (i == 0) {
                            that.ExpedientesADM.fnPageChange("previous");
                            next = 0;
                        } else
                            next = i - 1;
                    }

                    $(that.ExpedientesADM.fnSettings().aoData).each(function () {
                        $(this.nTr).removeClass('row_selected');
                    });

                    $("#dtExpedientesADM tbody").find("tr:eq(" + next + ")").addClass('row_selected');
                    that.ExpedientesADM_Id = that.ExpedientesADM.fnGetData($("#dtExpedientesADM tbody").find("tr:eq(" + next + ")").index())[0];;
                    that.ExpedientesADM_Index = next;

                    if (((e.which || e.keyCode) == 40)) {
                        if (!app.elementVisible($("#dtExpedientesADM tbody").find("tr:eq(" + next + ")"), 50)) {
                            $(document).scrollTop(next * 50);
                        }
                    }
                    else {
                        $(document).scrollTop(next * 50);
                    }
                }
            });

        }

        public setExpedientesADMMulti(dt: DataTables.DataTable, id: string): void {
            var that = this;
            this.ExpedientesADM = dt;
            this.spExpedientes = $("#ListadoExpedientes" + that.hash);
            this.modal = new SyncroModal($("#ModalExpedientes"));
            this.body_expedientes = $("#body_expedientes" + that.hash);
            this.Confirmar = $("#Confirmar" + that.hash);
            this.Generar = $("#Generar" + that.hash);
            this.Organismo = $("#OrganismoCargo" + that.hash);
            this.Observaciones = $("#Observaciones");
            this.Archivar = $("#Archivar" + that.hash);
            this.ArchivarConfirmar = $("#ArchivarConfirmar" + that.hash);

            this.Generar.click(function (e) {
                that.modal.mostrar();
                that.body_expedientes.empty();
                $(that.ExpedientesADM_Id_multi).each(function (ind, o) {
                    var tr = "<tr><td>" + o.numero + "</td><td>" + o.caratula + "</td></tr>";
                    that.body_expedientes.append(tr);
                });
            });

            this.Archivar.click(function (e) {
                that.modal.mostrar();
                that.body_expedientes.empty();
                $(that.ExpedientesADM_Id_multi).each(function (ind, o) {
                    var tr = "<tr><td>" + o.numero + "</td><td>" + o.caratula + "</td></tr>";
                    that.body_expedientes.append(tr);
                });
            });

            this.ArchivarConfirmar.click(function (e) {
                $.get("Expedientes/ModelosEscritoADM/getText/?id=1021", null, function (data) {

                    var res = "";

                    var nota = data;
                    $("#parsered").empty();
                    $("#parsered").append($.parseHTML(nota));

                    $("#parsered").html($("#parsered").html().replace("{{comprobante.origen}}", global.organismo_descripcion));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.origen}}", global.organismo_descripcion));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.hacia}}", that.Organismo.find("option:selected").text()));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.observaciones}}", that.Observaciones.val()));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.fecha}}", new Date().toLocaleDateString()));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.numero}}", new Date().toTimeString()));

                    var tr = $("#parsered").find("tr[data-tipo=expedientes]").wrap('<p/>').parent().html();
                    var body = $("#parsered").find("tbody[data-tipo=detalle]").empty();
                    var ntr = "";

                    that.ExpedientesADM_Id_multi.forEach(function (obj, ind) {
                        ntr += tr.replace("{{detalle.expediente}}", obj.numero).replace("{{detalle.caratula}}", obj.caratula).replace("{{detalle.fojas}}", "0").replace("{{detalle.orden}}", "0");
                        $("#parsered").find("tbody[data-tipo=detalle]").append(ntr);
                        ntr = "";
                    });

                    that.ExpedientesADM_Id_multi.forEach(function (obj, ind) {
                        var actuacion = {
                            Expediente: obj.id,
                            Descripcion: "Archivado - Pase al archivo",
                            Observaciones: that.Observaciones.val(),
                            OficinaOrigen: global.organismo,
                            OrganismoCargo: that.Organismo.val(),
                            TipoActuacion: 8,
                            RequiereCargo: true,
                            Fojas: 5,
                            Anulado: false,
                            Fecha: new Date().toLocaleDateString(),
                            Texto: $("#parsered").html()
                        };

                        var resultado = new Resultado();
                        that.archivarExpediente("/Expedientes/Expedientesadm/Archivar", obj.id, resultado).done(function (e) {
                            res += "<br/>" + resultado.mensaje;
                        });
                    });
                });
                var wnd = window.open("about:blank", "", "_blank");
                wnd.document.write($("#parsered").html());

            });


            this.Confirmar.click(function (e) {
                $.get("Expedientes/ModelosEscritoADM/getText/?id=1021", null, function (data) {

                    var nota = data;
                    $("#parsered").empty();
                    $("#parsered").append($.parseHTML(nota));

                    $("#parsered").html($("#parsered").html().replace("{{comprobante.origen}}", global.organismo_descripcion));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.origen}}", global.organismo_descripcion));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.hacia}}", that.Organismo.find("option:selected").text()));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.observaciones}}", that.Observaciones.val()));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.fecha}}", new Date().toLocaleDateString()));
                    $("#parsered").html($("#parsered").html().replace("{{comprobante.numero}}", new Date().toTimeString()));

                    var tr = $("#parsered").find("tr[data-tipo=expedientes]").wrap('<p/>').parent().html();
                    var body = $("#parsered").find("tbody[data-tipo=detalle]").empty();
                    var ntr = "";

                    that.ExpedientesADM_Id_multi.forEach(function (obj, ind) {
                        ntr += tr.replace("{{detalle.expediente}}", obj.numero).replace("{{detalle.caratula}}", obj.caratula).replace("{{detalle.fojas}}", "0").replace("{{detalle.orden}}", "0");
                        $("#parsered").find("tbody[data-tipo=detalle]").append(ntr);
                        ntr = "";                                     
                    });

                    that.ExpedientesADM_Id_multi.forEach(function (obj, ind) {
                        var actuacion = {
                            Expediente: obj.id,
                            Descripcion: "Pase de Expedientes",
                            Observaciones: that.Observaciones.val(),
                            OficinaOrigen: global.organismo,
                            OrganismoCargo: that.Organismo.val(),
                            TipoActuacion: 8,
                            RequiereCargo: true,
                            Fojas: 5,
                            Anulado: false,
                            Fecha: new Date().toLocaleDateString(),
                            Texto: $("#parsered").html()
                        };
                     
                        var resultado = new Resultado();
                        that.guardarActuacion("/Expedientes/ActuacionesADM/Crear", actuacion, resultado);
                    });
                });
                var wnd = window.open("about:blank", "", "_blank");
                wnd.document.write($("#parsered").html());
                
            });



            $("#" + id + " tbody").click(function (event) {
                //$(that.ExpedientesADM.fnSettings().aoData).each(function () {
                //    $(this.nTr).removeClass('row_selected');
                //});
                that.index = $(event.target).closest("tr").index();
                if (Enumerable.From(that.index_multi).Where(function (x) { return x == that.index }).Count() == 0) {
                    $(event.target).closest("tr").addClass('row_selected');
                    var id = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[0];
                    var numero = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[2];
                    var caratula  = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[3];                    
                    that.ExpedientesADM_Id = id;

                    var ex = {
                        id: id,
                        numero: numero,
                        caratula: caratula
                    };

                    that.index_multi.push(that.index);
                    that.ExpedientesADM_Id_multi.push(ex);

                } else {
                    $(event.target).closest("tr").removeClass('row_selected');         
                    var id = that.ExpedientesADM.fnGetData($(event.target).closest("tr").index())[0];
                    that.ExpedientesADM_Id = id;
                    Enumerable.From(that.ExpedientesADM_Id_multi).Delete(function (x) { return x.id == id });
                                                   
                    Enumerable.From(that.index_multi).Delete(function (x) { return x == that.index });
                }
            });
        }
		
        public guardarActuacion(url: string, data: any, res?: Resultado): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            var success = false;
            var retorno: number = 0;
            app.Bloquear();
            $.when($.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify({ actuacionesadm: data }),
                url: url,              
                success: function (data) {
                    res.estado = data[0];
                    res.Mensaje(data[1]);
                    if (data[0]) {
                        //app.crearNotificacionSuccess(titulo, data[1]);
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

        public archivarExpediente(url: string, data: any, res?: Resultado): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            var success = false;
            var retorno: number = 0;
            app.Bloquear();
            $.when($.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify({ expediente: data }),
                url: url,
                success: function (data) {
                    res.estado = data[0];
                    res.Mensaje(data[1]);
                    if (data[0]) {
                        res.mensaje = data[1];
                        //app.crearNotificacionSuccess(titulo, data[1]);
                        //res.id = data[2];
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



		public getData(col: number): any {
            return(this.ExpedientesADM.fnGetData(this.index)[col]); 
        }
		//--- /Funciones para seteo de Datatables ---/
		
		public fnRegistrarDataTable(d: DataTables.DataTable): void {
			this.datatables.push(d);
		}

		public fnRefrescarDataTables():void {
			var that = this;
			this.datatables.forEach(function (d) {
				d.fnDraw();
			});    
		}
	} //JS
} // module
