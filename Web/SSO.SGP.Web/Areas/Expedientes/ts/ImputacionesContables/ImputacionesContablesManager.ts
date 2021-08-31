
/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Imputar.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="Sobreafectar.ts"/>
module ImputacionesContables.ts {

	export class ImputacionesContablesManager {
	
		public ViewIndex: Index;
		public ViewImputar: Imputar;
        public ViewEditar: Editar;
        public ViewSobreafectar: Sobreafectar;
		
		constructor() {
			// Constructor
		}
	
		//--- Inicialización de la vista Index
		public setIndex(v: Index) {
			var that = this;
			this.ViewIndex = v;
			// Eventos de la vista
			
        }

        public setSobreafectar(v: Sobreafectar) {
            var that = this;
            this.ViewSobreafectar = v;
            var total: number;

            total = 0.0;

            //this.refrescarPartidas();

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
                that.guardarImputacion("Guardar sobreafectación", resultado).done(function (e) {

                });

            });

            //v.UnidadOrganizacion.change(function (e) {
            //    that.refrescarPartidas();
            //});

        }
		//--- Inicialización de la vista Imputar
		public setImputar(v: Imputar) {
			var that = this;
			this.ViewImputar = v;
			// Eventos de la vista
			
			v.Cancelar.click(function (e) {
				app.irATab(0);
			});
		
			v.Guardar.click(function (e) {
				that.ajaxPost(that.ViewImputar, "Modificar título").done(function (){
});
			});
		
			v.GuardarYNuevo.click(function (e) {
				that.ajaxPost(that.ViewImputar, "Modificar título").done(function () {
     that.ViewImputar.limpiar();                                   
});
			});
		
		}
	
		//--- Inicialización de la vista Editar
		public setEditar(v: Editar) {
			var that = this;
			this.ViewEditar = v;
			// Eventos de la vista
			
			v.Cancelar.click(function (e) {
				app.closeCurrentTab();
			});
		
			v.Guardar.click(function (e) {
				that.ajaxPost(that.ViewEditar, "Modificar título").done(function (){
});
			});
		
		}
	
		//--- Función editar de Datatable ImputacionesContables
		public editar_dtImputacionesContables():void{ 
			var id = this.ViewIndex.getData(0);
			app.createTab("Editar", "ImputacionesContables/Editar/" + id, true, true, true);
		}
		
		//--- Función eliminar de Datatable ImputacionesContables
		public eliminar_dtImputacionesContables():void{ 
			var id = this.ViewIndex.getData(0);
			this.eliminar("ImputacionesContables/Eliminar", {id : id});
		}
		
        public guardarImputacion(titulo: string, resultado?: Resultado): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            var success = false;
            var retorno: number = 0;
            var imputacion: any;

            imputacion = {
                ExpedienteAImputar: that.ViewSobreafectar.Id.val(),
                Operacion: 5,
                ImputacionesContablesDetalle: new Array()
            };

            that.ViewSobreafectar.Partidas.find("tr").each(function () {
                var $el = $(this);
                if ($el.find("td input").val()) {
                    var detalle: any;
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
                url: "Expedientes/ImputacionesContables/Sobreafectar",
                data: JSON.stringify({ imputacion: imputacion }),
                contentType: "application/json",
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

            return (df.promise());
        }


		//-- Método para pasar Vistas por Post según URL de formulario
		public ajaxPost(v:IControlador, titulo:string, resultado?:Resultado): JQueryDeferred {
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
                })).done(function() { df.resolve() })
					.fail(function() {df.reject() }); //end ajax
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
		
		public eliminar(url:string, data: any, resultado:Resultado): JQueryDeferred {
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
							res.Mensaje(data[1]);
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
                    })).done(function() { df.resolve() })
						.fail(function() { df.reject() });
                }
            });
			return(df.promise());
        }
	
	}//JS	
}