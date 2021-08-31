/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
module GrupoFamiliar.ts {

	export class GrupoFamiliarManager {
	
		public ViewIndex: Index;
		public ViewCrear: Crear;
		public ViewEditar: Editar;
		
		constructor() {
			// Constructor
		}
	
		//--- Inicialización de la vista Index
		public setIndex(v: Index) {
			var that = this;
            this.ViewIndex = v;

            v.GrupoFamiliar.setearSeleccionable(true);

            $.contextMenu({
                selector: "#" + that.ViewIndex.GrupoFamiliar.Id,
                items: {
                    "Bajar": {
                        name: "Bajar",
                        callback: function () {
                            $.when(that.eliminar("RRHH/GrupoFamiliar/Eliminar", { id: that.ViewIndex.GrupoFamiliar.id }))
                                .done(function () { that.ViewIndex.GrupoFamiliar.refrescar() });
                        }
                    },
                    "Editar": {
                        name: "Editar",
                        callback: function () {
                            v.modal.setearTitulo("Editar Familiar");
                            v.modal.loadAjax("RRHH/GrupoFamiliar/Editar/?id=" + v.GrupoFamiliar.id);
                            v.modal.mostrar();
                        }
                    }
                }
            });

            // Eventos de la vista
            v.Nuevo.click(function (e) {
                v.modal.cargar("Nuevo Familiar", "RRHH/GrupoFamiliar/Crear/?agente=" + v.Agente.val());
            });

            v.Cancelar.click(function (e) { 
                app.closeCurrentTab();
                app.irATab(0);
            });

		}
	
		//--- Inicialización de la vista Crear
		public setCrear(v: Crear) {
			var that = this;
			this.ViewCrear = v;
			// Eventos de la vista
			
			v.Cancelar.click(function (e) {
                that.ViewIndex.modal.cerrar();
			});
		
            v.Guardar.click(function (e) {
                var res = new Resultado();
				that.ajaxPost(that.ViewCrear, "Guardar Familiar", res).done(function (){
                    if (res.estado) {
                        that.ViewIndex.modal.cerrar();
                        that.ViewIndex.GrupoFamiliar.refrescar();
                    }
                });
			});
		
			v.GuardarYNuevo.click(function (e) {
                var res = new Resultado();
                that.ajaxPost(that.ViewCrear, "Guardar Familiar").done(function () {
                    if (res.estado)
                        that.ViewCrear.limpiar();                                   
                });
			});
		
		}
	
		//--- Inicialización de la vista Editar
		public setEditar(v: Editar) {
			var that = this;
			this.ViewEditar = v;
			// Eventos de la vista
			
			v.Cancelar.click(function (e) {
                that.ViewIndex.modal.cerrar();
			});
		
			v.Guardar.click(function (e) {
                var res = new Resultado();
                that.ajaxPost(that.ViewEditar, "Actualizar Familiar", res).done(function () {
                    if (res.estado)
                        that.ViewIndex.modal.cerrar();
                });
			});
		
		}
	
		//--- Función editar de Datatable GrupoFamiliar
		public editar_dtGrupoFamiliar(id:number):void{
            app.createTab("Editar", "RRHH/GrupoFamiliar/Editar/" + id, true, true, true);
		}
		
		//--- Función eliminar de Datatable GrupoFamiliar
		public eliminar_dtGrupoFamiliar(id:number):void{
            this.eliminar("RRHH/GrupoFamiliar/Eliminar", {id : id});
		}
		
	
		//-- Método para pasar Vistas por Post según URL de formulario
		public ajaxPost(v:IControlador, titulo:string, resultado?:Resultado): JQueryDeferred {
            var that = this;
            //var resultado = new Resultado();
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
		
		public eliminar(url:string, data: any): JQueryDeferred {
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