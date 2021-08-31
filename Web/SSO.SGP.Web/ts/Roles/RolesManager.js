/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
var Roles;
(function (Roles) {
    var ts;
    (function (ts) {
        var RolesManager = (function () {
            function RolesManager() {
                //this.initHandler();
            }
            RolesManager.prototype.setIndex = function (v) {
                var self = this;
                this.ViewIndex = v;
            };
            RolesManager.prototype.editar_dtRoles = function (el) {
                this.ViewIndex.selectRow_Roles(el);
                var id = this.ViewIndex.getData_Roles(0);
                app.createTab("Editar", "Roles/Editar/" + id, true, true, true);
            };
            RolesManager.prototype.eliminar_dtRoles = function (el) {
                this.ViewIndex.selectRow_Roles(el);
                var id = this.ViewIndex.getData_Roles(0);
                this.eliminar("Roles/Eliminar", { id: id });
            };
            RolesManager.prototype.setCrear = function (v) {
                var self = this;
                this.ViewCrear = v;
                var resultado = new Resultado();
                v.Cancelar.click(function (e) {
                    self.ViewCrear.limpiar();
                    app.irATab(0);
                });
                // v.Guardar.click(function (e) {
                //     var resultado = new Resultado(); 
                //     self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () { 
                //         self.ViewIndex.Roles.fnDraw(); 
                //         self.ViewCrear.limpiar(); 
                //         app.irATab(0); });
                // });
                v.Guardar.click(function (e) {
                    self.ajaxPostRolesMenusLista(self.ViewCrear, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            self.ViewIndex.Roles.fnDraw();
                            self.ViewCrear.limpiar();
                            app.irATab(0);
                        }
                    });
                });
                v.GuardarYNuevo.click(function (e) {
                    var resultado = new Resultado();
                    self.ajaxPost(self.ViewCrear, "Resultado", resultado).done(function () {
                        self.ViewCrear.limpiar(); //self.ViewCrear.Descripcion.focus(); 
                    });
                });
                // v.MenuInicial.change(function (e) {
                //     console.log(v.MenuInicial.find("option:selected").text());
                //     console.log(v.form.find("select[name=MenuInicial] option:selected").val());
                // });
            };
            RolesManager.prototype.setEditar = function (v) {
                var self = this;
                this.ViewEditar = v;
                var resultado = new Resultado();
                v.Cancelar.click(function (e) {
                    app.closeCurrentTab();
                });
                // v.Guardar.click(function (e) {
                //     var resultado = new Resultado(); self.ajaxPost(self.ViewEditar, "Resultado", resultado).done(function () { 
                // self.ViewIndex.Roles.fnDraw(); 
                // self.ViewEditar.limpiar(); 
                // app.irATab(0); 
                // });
                // });
                v.Guardar.click(function (e) {
                    self.ajaxPostRolesMenusLista(self.ViewEditar, "Resultado", resultado).done(function () {
                        if (resultado.estado) {
                            self.ViewIndex.Roles.fnDraw();
                            self.ViewEditar.limpiar();
                            app.irATab(0);
                        }
                    });
                });
            };
            RolesManager.prototype.ajaxPost = function (v, titulo, resultado) {
                var that = this;
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
            RolesManager.prototype.ajaxPostURL = function (url, data, titulo, res) {
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
            RolesManager.prototype.ajaxPostRolesMenusLista = function (v, titulo, resultado) {
                var that = this;
                var df = $.Deferred();
                //v.form.validate();
                var success = false;
                var id = v.form.find("input[name=Id]").val();
                ;
                var roleName = v.form.find("input[name=Descripcion]").val();
                var itemMenuDefault = v.form.find("select[name=MenuInicial] option:selected").val();
                console.log(itemMenuDefault);
                var listaMenus;
                listaMenus = [];
                v.form.find("#tablaRolesMenus tbody tr").each(function () {
                    if ($(this).find("input[data-tipo=menu]").is(':checked')) {
                        listaMenus.push($(this).find("input[data-tipo=menu]").data("id"));
                    }
                });
                var retorno = 0;
                //if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: v.form.attr("action"),
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({ idRol: id, roleName: roleName, ItemMenuDefault: itemMenuDefault, listadoMenus: listaMenus }),
                    success: function (data) {
                        resultado.estado = data[0];
                        resultado.Mensaje(data[1]);
                        if (data[0]) {
                            app.crearNotificacionSuccess(titulo, data[1]);
                            resultado.id = data[2];
                        }
                        else {
                            app.crearNotificacionError("Mensaje", data[1]);
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
            RolesManager.prototype.eliminar = function (url, data) {
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
                                    that.ViewIndex.Roles.fnDraw();
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
            return RolesManager;
        })();
        ts.RolesManager = RolesManager; //JS
    })(ts = Roles.ts || (Roles.ts = {}));
})(Roles || (Roles = {})); // module
