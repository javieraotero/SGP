/// <reference path="../IControlador.ts"/>
/// <reference path="../AppManager.ts"/>
/// <reference path="Index.ts"/>
/// <reference path="Crear.ts"/>
/// <reference path="Editar.ts"/>
/// <reference path="../../../../ts/Model/MontosDeViaticos.ts"/>
/// <reference path="../../../../ts/Model/SolicitudesDeViaticosAgentes.ts"/>
/// <reference path="../../../../ts/Model/SolicitudesDeViaticosRendicionesAgentes.ts"/>
/// <reference path="../../../../ts/Model/SolicitudesDeViaticosRendicionesDetalle.ts"/>
module SolicitudesDeViaticos.ts {

    export class SolicitudesDeViaticosManager {
 
        public ViewIndex: Index;
        public ViewIndexBorrador: IndexBorrador;
        public ViewIndexPendientes: IndexPendientes;
        public ViewIndexPorRendir: IndexPorRendir;
        public ViewCrear: Crear;
        public ViewEditar: Crear;
        public ViewCrearRendicion: CrearRendicion;
        public ViewEditarRendicion: CrearRendicion;
        public ViewTodosAnticipo: Index;
        public ViewTodosReintegro: Index;
        public ViewTodosControlarRendicion: Index;
        public ViewTodos: Index;
        public ViewComisionesPendientesChofer: Index;
        public ViewRendidas: IndexRendidas;

        public detalle_solicitud: Array<model.SolicitudesDeViaticosAgentes>;
        public detalle_rendicion: Array<model.SolicitudesDeViaticosRendicionesAgentes>;
        public detalle_conceptos: Array<model.SolicitudesDeViaticosRendicionesDetalle>;
        public detalle_partidas: Array<model.DetallePartidas>;
        public id_agente: number;
        public comision_seleccionada: any;


        constructor() {
            app.getData("Expedientes/SolicitudesDeViaticos/GetConceptos", null).done(function (data) {
                global.conceptos = data;
            }); 
        }

        public setIndex(v: Index) {
            v.Buscar.click(function (e) {
                e.preventDefault();
                v.SolicitudesDeViaticos.fnNewAjax("Expedientes/SolicitudesDeViaticos/getSolicitudesDeViaticosGrid/?agente="+v.Agente.valor());
            });

            var self = this;
            this.ViewIndex = v;

        }

        public setIndexBorrador(v: IndexBorrador) {
            v.Buscar.click(function (e) {
                e.preventDefault();
                v.SolicitudesDeViaticos.fnNewAjax("Expedientes/SolicitudesDeViaticos/getSolicitudesDeViaticosGrid/?agente=" + v.Agente.valor());
            });

            var self = this;
            this.ViewIndexBorrador = v;
        }

        public setIndexPorRendir(v: IndexPorRendir) {
            v.Buscar.click(function (e) {
                e.preventDefault();
                v.SolicitudesDeViaticos.fnNewAjax("Expedientes/SolicitudesDeViaticos/getSolicitudesDeViaticosGrid/?agente=" + v.Agente.valor());
            });

            var self = this;
            this.ViewIndexPorRendir = v;
        }

        public setIndexRendidas(v: IndexRendidas) {
            v.Buscar.click(function (e) {
                e.preventDefault();
                v.SolicitudesDeViaticos.fnNewAjax("Expedientes/SolicitudesDeViaticos/getSolicitudesDeViaticosGrid/?agente=" + v.Agente.valor());
            });

            var self = this;
            this.ViewRendidas = v;
        }

        public setIndexPendientes(v: IndexPendientes) {
            v.Buscar.click(function (e) {
                e.preventDefault();
                v.SolicitudesDeViaticos.fnNewAjax("Expedientes/SolicitudesDeViaticos/getSolicitudesDeViaticosGrid/?agente=" + v.Agente.valor());
            });

            var self = this;
            this.ViewIndexPendientes = v;
        }

        public setTodosAnticipo(v: Index) {
            v.Buscar.click(function (e) {
                e.preventDefault();
                v.Anticipos.fnNewAjax("Expedientes/SolicitudesDeViaticos/getSolicitudesDeViaticosTodosPorAnticipoGrid/?agente=" + v.Agente.valor());
            });

            var self = this;
            this.ViewTodosAnticipo = v;
        }

        public setTodosReintegro(v: Index) {

            v.Buscar.click(function (e) {
                e.preventDefault();
                v.SolicitudesDeViaticos.fnNewAjax("Expedientes/SolicitudesDeViaticos/getSolicitudesDeViaticosTodosPorReintegroGrid/?agente=" + v.Agente.valor());
            });

            var self = this;
            this.ViewTodosReintegro = v;
        }

        public setTodosControlarRendicion(v: Index) {
            v.Buscar.click(function (e) {
                e.preventDefault();
                v.SolicitudesDeViaticos.fnNewAjax("Expedientes/SolicitudesDeViaticos/getSolicitudesDeViaticosTodosPorEstadoGrid/?estado=9&agente=" + v.Agente.valor());
            });

            var self = this;
            this.ViewTodosControlarRendicion = v;
        }

        public setComisionesPendientesChofer(v: Index) {
            var self = this;
            this.ViewComisionesPendientesChofer = v;
        }

        public setTodosHistorial(v: Index) {
            var self = this;
            this.ViewTodos = v;
        }

        public editar_AsignarChofer(el): void {
            this.ViewComisionesPendientesChofer.selectRow_Comisiones(el);
            var id = this.ViewComisionesPendientesChofer.getData_Comisiones(6);
            app.createTab("Editar", "Expedientes/SolicitudesDeViaticos/AsignarChofer/" + id, true, true, true);
        }

        public editar_dtSolicitudesDeViaticosReintegro(el): void {
            this.ViewTodosReintegro.selectRow_SolicitudesDeViaticosReintegro(el);
            var id = this.ViewTodosReintegro.getData_SolicitudesDeViaticosReintegro(0);
            app.createTab("Editar", "Expedientes/SolicitudesDeViaticos/Editar/" + id, true, true, true);
        } 

        public editar_dtSolicitudesDeViaticosControlarRendicion(el): void {
            this.ViewTodosControlarRendicion.selectRow_SolicitudesDeViaticosControlarRendicion(el);
            var id = this.ViewTodosControlarRendicion.getData_SolicitudesDeViaticosControlarRendicion(0);
            app.createTab("Editar", "Expedientes/SolicitudesDeViaticos/Editar/" + id, true, true, true);
        } 

        public editar_dtSolicitudesDeViaticosAnticipo(el): void {
            this.ViewTodosAnticipo.selectRow_SolicitudesDeViaticosAnticipo(el);
            var id = this.ViewTodosAnticipo.getData_SolicitudesDeViaticosAnticipo(0);
            app.createTab("Editar", "Expedientes/SolicitudesDeViaticos/Editar/" + id, true, true, true);
        }

        public editar_dtSolicitudesDeViaticos(el): void {
            this.ViewIndex.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndex.getData_SolicitudesDeViaticos(0);
            app.createTab("Editar", "Expedientes/SolicitudesDeViaticos/Editar/" + id, true, true, true);
        }

        public editar_dtSolicitudesDeViaticosBorrador(el): void {
            this.ViewIndexBorrador.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndexBorrador.getData_SolicitudesDeViaticos(0);
            app.createTab("Editar", "Expedientes/SolicitudesDeViaticos/Editar/" + id, true, true, true);
        }

        public editar_dtSolicitudesDeViaticosPendientes(el): void {
            this.ViewIndexPendientes.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndexPendientes.getData_SolicitudesDeViaticos(0);
            app.createTab("Editar", "Expedientes/SolicitudesDeViaticos/Editar/" + id, true, true, true);
        }

        public editar_dtSolicitudesDeViaticosPorRendir(el): void {
            this.ViewIndexPorRendir.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndexPorRendir.getData_SolicitudesDeViaticos(0);
            app.createTab("Editar", "Expedientes/SolicitudesDeViaticos/Editar/" + id, true, true, true);
        }

        public rendir_dtSolicitudesDeViaticos(el): void {
            this.ViewIndex.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndex.getData_SolicitudesDeViaticos(0);
            app.createTab("Rendir Viático #" + id, "Expedientes/SolicitudesDeViaticos/CrearRendicion/" + id, true, true, true);
        }

        public rendir_dtSolicitudesDeViaticosPorRendir(el): void {
            this.ViewIndexPorRendir.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndexPorRendir.getData_SolicitudesDeViaticos(0);
            app.createTab("Rendir Viático #" + id, "Expedientes/SolicitudesDeViaticos/CrearRendicion/" + id, true, true, true);
        }

        public rendir_dtSolicitudesDeViaticosPorRendirRendidas(el): void {
            this.ViewRendidas.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewRendidas.getData_SolicitudesDeViaticos(0);
            var estado = this.ViewRendidas.getData_SolicitudesDeViaticos(8);
            console.log("estado:" + estado);
            //if (estado.includes("Borrador")) {
            //    app.createTab("Editar Rendición Viático #" + id, "Expedientes/SolicitudesDeViaticos/EditarRendicion/" + id, true, true, true);
            //} else {
            //    app.createTab("Rendir Viático #" + id, "Expedientes/SolicitudesDeViaticos/CrearRendicion/" + id, true, true, true);
            //}

            app.createTab("Rendir Viático #" + id, "Expedientes/SolicitudesDeViaticos/CrearRendicion/" + id, true, true, true);
            
        }

        public ver_dtSolicitudesDeViaticos(el): void {
            var that = this;
            this.ViewIndex.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndex.getData_SolicitudesDeViaticos(0);
            app.modal.cargar("Ver Viático #" + id, "Expedientes/SolicitudesDeViaticos/Editar/" + id).done(function (e) {
                that.ViewEditar.Guardar.hide();
                that.ViewEditar.GuardarYNuevo.hide();
                that.ViewEditar.Cancelar.unbind("click");
                that.ViewEditar.Cancelar.click(function (e) {
                    app.modal.cerrar();
                });
            });
        }

        public ver_dtSolicitudesDeViaticosBorrador(el): void {
            var that = this;
            this.ViewIndexBorrador.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndexBorrador.getData_SolicitudesDeViaticos(0);
            app.modal.cargar("Ver Viático #" + id, "Expedientes/SolicitudesDeViaticos/Editar/" + id).done(function (e) {
                that.ViewEditar.Guardar.hide();
                that.ViewEditar.GuardarYNuevo.hide();
                that.ViewEditar.Cancelar.unbind("click");
                that.ViewEditar.Cancelar.click(function (e) {
                    app.modal.cerrar();
                });
            });
        }

        public ver_dtSolicitudesDeViaticosPendientes(el): void {
            var that = this;
            this.ViewIndexPendientes.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndexPendientes.getData_SolicitudesDeViaticos(0);
            app.modal.cargar("Ver Viático #" + id, "Expedientes/SolicitudesDeViaticos/Editar/" + id).done(function (e) {
                that.ViewEditar.Guardar.hide();
                that.ViewEditar.GuardarYNuevo.hide();
                that.ViewEditar.Cancelar.unbind("click");
                that.ViewEditar.Cancelar.click(function (e) {
                    app.modal.cerrar();
                });
            });
        }

        public imprimir_dtSolicitudesDeViaticosPendientes(el): void {
            var that = this;
            this.ViewIndexPendientes.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndexPendientes.getData_SolicitudesDeViaticos(0);
            this.GenerarSolicitudDeViatico(id, null, that.ViewIndexPendientes);
        }

        public ver_dtSolicitudesDeViaticosPorRendir(el): void {
            var that = this;
            this.ViewIndexPorRendir.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndexPorRendir.getData_SolicitudesDeViaticos(0);
            app.modal.cargar("Ver Viático #" + id, "Expedientes/SolicitudesDeViaticos/Editar/" + id).done(function (e) {
                that.ViewEditar.Guardar.hide();
                that.ViewEditar.GuardarYNuevo.hide();
                that.ViewEditar.Cancelar.unbind("click");
                that.ViewEditar.Cancelar.click(function (e) {
                    app.modal.cerrar();
                });
            });
        }

        public ver_dtSolicitudesDeViaticosPorRendirRendidas(el): void {
            var that = this;
            this.ViewRendidas.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewRendidas.getData_SolicitudesDeViaticos(0);
            app.modal.cargar("Ver Viático #" + id, "Expedientes/SolicitudesDeViaticos/Editar/" + id).done(function (e) {
                that.ViewEditar.Guardar.hide();
                that.ViewEditar.GuardarYNuevo.hide();
                that.ViewEditar.Cancelar.unbind("click");
                that.ViewEditar.Cancelar.click(function (e) {
                    app.modal.cerrar();
                });
            });
        }

        public eliminar_dtSolicitudesDeViaticos(el): void {
            this.ViewIndex.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndex.getData_SolicitudesDeViaticos(0);
            this.eliminar("Expedientes/SolicitudesDeViaticos/Eliminar", { id: id });
        }

        public eliminar_dtSolicitudesDeViaticosBorrador(el): void {
            this.ViewIndexBorrador.selectRow_SolicitudesDeViaticos(el);
            var id = this.ViewIndexBorrador.getData_SolicitudesDeViaticos(0);
            this.eliminar("Expedientes/SolicitudesDeViaticos/Eliminar", { id: id });
        }

        public setCrearRendicion(v: CrearRendicion) {
            var self = this;
            this.ViewCrearRendicion = v;
            this.detalle_solicitud = [];
            this.detalle_rendicion = [];
            this.detalle_conceptos = [];
            this.detalle_partidas = [];

            var monto_vigente: model.MontosDeViaticos;

            app.getData("Expedientes/MontosDeViaticos/GetVigente").done(function (data) {
                monto_vigente = data;
            });

            app.getData("Expedientes/SolicitudesDeViaticos/GetAgentes/" + v.SolicitudDeViatico.val(), null).done(function (data) {

                self.detalle_solicitud = data;

                self.detalle_solicitud.forEach(function (o, i) {
                    var r = new model.SolicitudesDeViaticosRendicionesAgentes();
                    r.Agente = o.Agente;

                    if (o.Anticipo) {
                        r.Anticipo = o.ImporteTotal;
                        r.TotalSolicitado = o.ImporteTotal;
                    } else {
                        r.Anticipo = 0;
                        r.TotalSolicitado = o.ImporteTotal;
                    }

                    r.Cobrar = 0;
                    r.Devolver = 0;
                    r.Dias = o.Dias;

                    r.GastosSolicitados = 0;

                    r.Gastos = 0;
                    r.ImportePorDia = o.ImportePorDia;
                    r.Subtotal = 0;
                    r.Total = o.ImporteTotal;
                    r.AgenteDescripcion = o.AgenteDescripcion;
                    r.GastosViaticos = o.ImporteGastos;
                    r.Viaticos = (o.ImportePorDia * o.Dias);

                    self.detalle_rendicion.push(r);

                });

                self.refrescarRendicionesAgentes();

            });

            v.FechaDeInicio.change(function (e) {

                if (v.FechaDeFin.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    var hora_inicio = inicio.hour();
                    var minutos_inicio = inicio.minute();

                    var hora_fin = fin.hour();
                    var minutos_fin = fin.minute();

                    //console.log(hora_inicio);
                    //console.log(minutos_inicio);

                    var horas = fin.diff(inicio, 'hours');
                    var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                    var dias = fin.diff(inicio, 'days');

                    console.log(dias_2);

                    //inicia y termina el mismo día
                    if (dias_2 == 1) {
                        if (hora_inicio <= 12) {
                            if (hora_fin >= 20) {
                                dias = 1;
                            } else {
                                dias = 0.5;
                            }
                        } else {
                            dias = 1;
                        }
                    }

                    //MAS de un dia
                    if (dias_2 > 1) {

                        if (hora_inicio <= 12) {
                            dias = 1;
                        } else {
                            dias = 0.5;
                        }

                        if (hora_fin > 12 && hora_fin < 20) {
                            dias += 0.5;
                        }

                        if (hora_fin >= 20) {
                            dias += 1;
                        }

                        dias += (dias_2 - 2)

                    }
                     
                    //var dias = 0;
                    var importe_dia = 0;
                    var subtotal = 0;
                    var total = 0;

                    var lapampa = false;
                    var veinticinco_de_mayo = false;

                    var destino = v.Destino.val();
                    if (destino.indexOf("La Pampa") >= 0)
                        lapampa = true;

                    if (destino.indexOf("Colonia 25 De") >= 0)
                        veinticinco_de_mayo = true;


                    self.detalle_rendicion.forEach(function (o, i) {

                        var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                        var grupo = solicitud.Grupo;

                        //El agente es funcionario
                        if (grupo == 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                            }

                        }

                        //No es funcionario
                        if (grupo != 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                            }

                        }

                        o.Dias = dias;
                        o.ImportePorDia = solicitud.ImportePorDia;
                        o.Subtotal = dias * solicitud.ImportePorDia;

                        self.refrescarRendicionesAgentes();

                    });


                }
            });

            v.FechaDeFin.change(function (e) {
             
                if (v.FechaDeInicio.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    var hora_inicio = inicio.hour();
                    var minutos_inicio = inicio.minute();

                    var hora_fin = fin.hour();
                    var minutos_fin = fin.minute();

                    //console.log(hora_inicio);
                    //console.log(minutos_inicio);

                    var horas = fin.diff(inicio, 'hours');
                    var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                    var dias = fin.diff(inicio, 'days');

                    console.log(dias_2);

                    //inicia y termina el mismo día
                    if (dias_2 == 1) {
                        if (hora_inicio <= 12) {
                            if (hora_fin >= 20) {
                                dias = 1;
                            } else {
                                dias = 0.5;
                            }
                        } else {
                            dias = 1;
                        }
                    }

                    //MAS de un dia
                    if (dias_2 > 1) {

                        if (hora_inicio <= 12) {
                            dias = 1;
                        } else {
                            dias = 0.5;
                        }

                        if (hora_fin > 12 && hora_fin < 20) {
                            dias += 0.5;
                        }

                        if (hora_fin >= 20) {
                            dias += 1;
                        }

                        dias += (dias_2 - 2)

                    }
                     
                    //var dias = 0;
                    var importe_dia = 0;
                    var subtotal = 0;
                    var total = 0;

                    var lapampa = false;
                    var veinticinco_de_mayo = false;

                    var destino = v.Destino.val();
                    if (destino.indexOf("La Pampa") >= 0)
                        lapampa = true;

                    if (destino.indexOf("Colonia 25 De") >= 0)
                        veinticinco_de_mayo = true;


                    self.detalle_rendicion.forEach(function (o, i) {

                        var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                        var grupo = solicitud.Grupo;

                        //El agente es funcionario
                        if (grupo == 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                            }

                        }

                        //No es funcionario
                        if (grupo != 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                            }

                        }

                        o.Dias = dias;
                        o.ImportePorDia = solicitud.ImportePorDia;
                        o.Subtotal = dias * solicitud.ImportePorDia;

                        self.refrescarRendicionesAgentes();

                    });


                }
            });

            v.Boleta.change(function (e) {
                v.GuardarYNuevo.show();
            });

            $("input[data-tipo=gastos]").die("change");
            $("input[data-tipo=gastos]").live("change", function (data) {
                var agente = $(this).data("agente");
                Enumerable.From(self.detalle_rendicion).Where(function (x) { return x.Agente == agente }).First().Gastos = parseFloat($(this).val());
                self.refrescarRendicionesAgentes();
            });

            var input_gasto;
            var agente_gasto;

            $("input[data-tipo=gastos]").die("click");
            $("input[data-tipo=gastos]").live("click", function (data) {
                console.log("evento click en input gastos");
                v.ModalGastos.mostrar();
                input_gasto = $(this);
                agente_gasto = $(this).data("agente");
                self.refrescarDetalleDeGastos(agente_gasto);
                //self.refrescarPartidas();
            });

            $("a[data-tipo=quitar_gasto]").die("click");
            $("a[data-tipo=quitar_gasto]").live("click", function (data) {
                var agente = $(this).data("agente");
                var concepto = $(this).data("concepto");

                var gasto = Enumerable.From(self.detalle_conceptos).Delete(function (p) { return p.Agente == agente && p.Concepto == concepto })
                var rendicion_agente = Enumerable.From(self.detalle_rendicion).Where(function (p) { return p.Agente == agente }).First();

                var tot = Enumerable.From(self.detalle_conceptos).Where(function (p) { return p.Agente == agente_gasto }).Select(function (p) { return p.Importe });

                var total = 0;
                var total_general = 0;

                tot.ForEach(function (importe, index) {
                    total += parseFloat(importe.toString());
                });

                rendicion_agente.Gastos = total;

                self.refrescarDetalleDeGastos(agente);
                self.refrescarRendicionesAgentes();
                self.refrescarPartidas();

            });

            v.Listo_Gastos.click(function (e) {
                e.preventDefault();
                v.ModalGastos.cerrar();
            });

            v.Cancelar.click(function (e) {
                self.ViewCrearRendicion.limpiar(); app.irATab(0);
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                //if (v.MotivoDeComision.val() == "")
                //{
                //    app.crea
                //} 

                self.ajaxPostCrearRendicion(self.ViewCrearRendicion, "Resultado", resultado, 8).done(function () {
                    self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();
                    if (self.ViewRendidas)
                        self.ViewRendidas.SolicitudesDeViaticos.fnDraw();
                    app.closeCurrentTab();
                    app.irATab(3);
                });
            });

            v.GuardarYNuevo.click(function (e) {
                if ((v.Boleta.length > 0 && parseFloat(v.spTotalDevolver.html()) > 0) || (parseFloat(v.spTotalDevolver.html()) == 0)) {
                    var resultado = new Resultado();
                    self.ajaxPostCrearRendicion(self.ViewCrearRendicion, "Resultado", resultado, 9).done(function () {
                        if (resultado.estado) {
                            var id = resultado.id;
                            v.Id.val(id.toString());                            
                            self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();

                            if (self.ViewRendidas)
                                self.ViewRendidas.SolicitudesDeViaticos.fnDraw();

                            self.GenerarRendicionDeViatico(id, v);
                            //app.irATab(0);
                        }
                    });
                } else {
                    app.crearNotificacionError("Número de Depósito", "Debe ingresar un número de boleta de depósito");
                }
            });

            v.Imprimir.click(function (e) {
                e.preventDefault();
                self.GenerarRendicionDeViatico(v.Id.val(),v);
            });

            v.Guardar_Gastos.click(function (e) {
                var x = { concepto: v.Concepto_Gastos.val(), concepto_descripcion: v.Concepto_Gastos.find("option:selected").text(), importe: Number(v.Importe_Gastos.val().replace(",",".")) };
                var d = new model.SolicitudesDeViaticosRendicionesDetalle();
                d.Concepto = v.Concepto_Gastos.val();
                d.Importe = Number(v.Importe_Gastos.val().replace(",", "."));
                d.Agente = agente_gasto;
                d.Descripcion = v.Concepto_Gastos.find("option:selected").text();

                var existe = Enumerable.From(self.detalle_conceptos).Where(function (a) { return a.Concepto == d.Concepto && a.Agente == agente_gasto });

                if (existe.Count() > 0)
                    existe.First().Importe += d.Importe;
                else
                    self.detalle_conceptos.push(d);                

                var tot = Enumerable.From(self.detalle_conceptos).Where(function (p) { return p.Agente == agente_gasto}).Select(function (p) { return p.Importe });

                var total = 0;
                var total_general = 0;

                tot.ForEach(function (importe, index) {
                    total += parseFloat(importe.toString());
                });
                
                $(input_gasto).val(parseFloat(total.toString()).toFixed(2));

                var rendicion_agente = Enumerable.From(self.detalle_rendicion).Where(function (re) { return re.Agente == agente_gasto });
                rendicion_agente.First().Gastos = parseFloat(total.toString());

                self.refrescarDetalleDeGastos(agente_gasto);
                self.refrescarRendicionesAgentes();
                self.refrescarPartidas();
            });

           

        }

        public setEditarRendicion(v: CrearRendicion) {
            var self = this;
            this.ViewEditarRendicion = v;
            this.detalle_solicitud = [];
            this.detalle_rendicion = [];

            var monto_vigente: model.MontosDeViaticos;

            if (global.organismo != v.OrganismoSolicitante.val())
                $("#form_rendicion").hide();
            else
                $("#form_rendcion").show();

            app.getData("Expedientes/MontosDeViaticos/GetVigente").done(function (data) {
                monto_vigente = data;
            });

            //app.getData("Expedientes/MontosDeViaticos/GetVigente").done(function (data) {
            //    monto_vigente = data;
            //});

            app.getData("Expedientes/SolicitudesDeViaticos/GetDetalleRendicion/?id=" + v.Id.val(), null).done(function (data) {
                self.detalle_conceptos = data;
            });
            //app.getData("Expedientes/SolicitudesDeViaticos/GetAgentes/" + v.SolicitudDeViatico.val(), null).done(function (data) {

            //    self.detalle_solicitud = data;

            //    self.detalle_solicitud.forEach(function (o, i) {
            //        var r = new model.SolicitudesDeViaticosRendicionesAgentes();
            //        r.Agente = o.Agente,
            //        r.Anticipo = o.ImporteTotal,
            //        r.Cobrar = 0;
            //        r.Devolver = 0;
            //        r.Dias = 0;
            //        r.Gastos = 0;
            //        r.ImportePorDia = o.ImportePorDia;
            //        r.Subtotal = 0;
            //        r.Total = 0;
            //        r.AgenteDescripcion = o.AgenteDescripcion;

            //        self.detalle_rendicion.push(r);

            //    });

            //    self.refrescarRendicionesAgentes();

            //});

            app.getData("Expedientes/SolicitudesDeViaticos/GetAgentesRendicion/" + v.Id.val(), null).done(function (data) {

                self.detalle_rendicion = data;                
                //self.refrescarRendicionesAgentesEditar();
                //self.refrescarPartidasEditar();

            }).then(function () {
                app.getData("Expedientes/SolicitudesDeViaticos/GetAgentes/" + v.SolicitudDeViatico.val(), null).done(function (data) {
                    
                    self.detalle_solicitud = data;

                    self.detalle_solicitud.forEach(function (o, i) {
                        var r = new model.SolicitudesDeViaticosRendicionesAgentes();
                        r.Agente = o.Agente;

                        if (o.Anticipo) {
                            r.Anticipo = o.ImporteTotal;
                            r.TotalSolicitado = o.ImporteTotal;
                        } else {
                            r.Anticipo = 0;
                            r.TotalSolicitado = o.ImporteTotal;
                        }

                        r.Cobrar = 0;
                        r.Devolver = 0;
                        r.Dias = o.Dias;

                        r.GastosSolicitados = 0;

                        r.Gastos = 0;
                        r.ImportePorDia = o.ImportePorDia;
                        r.Subtotal = 0;
                        r.Total = o.ImporteTotal;
                        r.AgenteDescripcion = o.AgenteDescripcion;
                        r.GastosViaticos = o.ImporteGastos;
                        r.Viaticos = (o.ImportePorDia * o.Dias);

                        //var ren = Enumerable.From(self.detalle_rendicion).Where(function(x) {return x })


                        //self.detalle_rendicion.push(r);

                    });

                    self.refrescarRendicionesAgentesEditar();
                    self.refrescarPartidasEditar();

                });

                });



            v.Imprimir.click(function (e) {
                e.preventDefault();
                self.GenerarRendicionDeViatico(v.Id.val(),v);
            });

            v.FechaDeInicio.change(function (e) {

                if (v.FechaDeFin.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    var horas = fin.diff(inicio, 'hours');
                    var dias = fin.diff(inicio, 'days');

                    var dias = 0;
                    var importe_dia = 0;
                    var subtotal = 0;
                    var total = 0;

                    if (horas < 12)
                        dias = 0.5;
                    else if (horas <= 24)
                        dias = 1
                    else
                        dias = (horas / 24)

                    var lapampa = false;
                    var veinticinco_de_mayo = false;

                    var destino = v.Destino.val();
                    if (destino.indexOf("La Pampa") >= 0)
                        lapampa = true;

                    if (destino.indexOf("Colonia 25 De") >= 0)
                        veinticinco_de_mayo = true;


                    self.detalle_rendicion.forEach(function (o, i) {

                        var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                        var grupo = solicitud.Grupo;

                        //El agente es funcionario
                        if (grupo == 1) {

                            if (dias == 0.5) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia / 2;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }

                            if (dias == 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                            }

                        }

                        //No es funcionario
                        if (grupo != 1) {

                            if (dias == 0.5) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1 / 2;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias == 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                            }

                        }

                        o.Dias = dias;
                        o.ImportePorDia = solicitud.ImportePorDia;

                        self.refrescarRendicionesAgentesEditar();

                    });


                }
            });

            v.FechaDeFin.change(function (e) {

                if (v.FechaDeInicio.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    var horas = fin.diff(inicio, 'hours');
                    var dias = fin.diff(inicio, 'days');

                    var dias = 0;
                    var importe_dia = 0;
                    var subtotal = 0;
                    var total = 0;

                    if (horas < 12)
                        dias = 0.5;
                    else if (horas <= 24)
                        dias = 1
                    else
                        dias = (horas / 24)

                    var lapampa = false;
                    var veinticinco_de_mayo = false;

                    var destino = v.Destino.val();
                    if (destino.indexOf("La Pampa") >= 0)
                        lapampa = true;

                    if (destino.indexOf("Colonia 25 De") >= 0)
                        veinticinco_de_mayo = true;


                    self.detalle_rendicion.forEach(function (o, i) {

                        var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                        var grupo = solicitud.Grupo;

                        //El agente es funcionario
                        if (grupo == 1) {

                            if (dias == 0.5) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia / 2;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }

                            if (dias == 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                            }

                        }

                        //No es funcionario
                        if (grupo != 1) {

                            if (dias == 0.5) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1 / 2;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias == 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                            }

                        }

                        o.Dias = dias;
                        o.ImportePorDia = solicitud.ImportePorDia;

                        self.refrescarRendicionesAgentesEditar();

                    });


                }
            });

            $("input[data-tipo=gastos]").live("change", function (data) {
                var agente = $(this).data("agente");
                Enumerable.From(self.detalle_rendicion).Where(function (x) { return x.Agente == agente }).First().Gastos = parseFloat($(this).val());
                self.refrescarRendicionesAgentesEditar();
                self.refrescarPartidasEditar();
            });

            var input_gasto;
            var agente_gasto;

            $("input[data-tipo=gastos]").die("click");
            $("input[data-tipo=gastos]").live("click", function (data) {
                console.log("evento click en input gastos");
                v.ModalGastos.mostrar();
                input_gasto = $(this);
                agente_gasto = $(this).data("agente");
                self.refrescarDetalleDeGastosEdicion(agente_gasto);
            });

            $("a[data-tipo=quitar_gasto]").die("click");
            $("a[data-tipo=quitar_gasto]").live("click", function (data) {
                var agente = $(this).data("agente");
                var concepto = $(this).data("concepto");

                var gasto = Enumerable.From(self.detalle_conceptos).Delete(function (p) { return p.Agente == agente && p.Concepto == concepto })
                var rendicion_agente = Enumerable.From(self.detalle_rendicion).Where(function (p) { return p.Agente == agente }).First();

                var tot = Enumerable.From(self.detalle_conceptos).Where(function (p) { return p.Agente == agente_gasto }).Select(function (p) { return p.Importe });

                var total = 0;
                var total_general = 0;

                tot.ForEach(function (importe, index) {
                    total += parseFloat(importe.toString());
                });

                rendicion_agente.Gastos = total;

                self.refrescarDetalleDeGastosEdicion(agente);
                self.refrescarRendicionesAgentesEditar();
                self.refrescarPartidasEditar();
            });

            v.Listo_Gastos.click(function (e) {
                e.preventDefault();
                v.ModalGastos.cerrar();
            });


            v.Cancelar.click(function (e) {
                self.refrescarRendicionesAgentesEditar.limpiar(); app.irATab(0);
            });

            v.Guardar_Gastos.click(function (e) {
                var x = { concepto: v.Concepto_Gastos.val(), concepto_descripcion: v.Concepto_Gastos.find("option:selected").text(), importe: Number(v.Importe_Gastos.val().replace(",", ".")) };
                var d = new model.SolicitudesDeViaticosRendicionesDetalle();
                d.Concepto = v.Concepto_Gastos.val();
                d.Importe = Number(v.Importe_Gastos.val().replace(",", "."));
                d.Agente = agente_gasto;
                d.Descripcion = v.Concepto_Gastos.find("option:selected").text();

                var existe = Enumerable.From(self.detalle_conceptos).Where(function (a) { return a.Concepto == d.Concepto && a.Agente == agente_gasto });

                if (existe.Count() > 0)
                    existe.First().Importe += d.Importe;
                else
                    self.detalle_conceptos.push(d);

                var tot = Enumerable.From(self.detalle_conceptos).Where(function (p) { return p.Agente == agente_gasto }).Select(function (p) { return p.Importe });

                var total = 0;
                var total_general = 0;

                tot.ForEach(function (importe, index) {
                    total += parseFloat(importe.toString());
                });

                $(input_gasto).val(parseFloat(total.toString()).toFixed(2));

                var rendicion_agente = Enumerable.From(self.detalle_rendicion).Where(function (re) { return re.Agente == agente_gasto });
                rendicion_agente.First().Gastos = parseFloat(total.toString());

                self.refrescarDetalleDeGastosEditar(agente_gasto);
                self.refrescarRendicionesAgentesEditar();
                self.refrescarPartidasEditar();
            });


            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                self.ajaxPostEditarRendicion(self.ViewEditarRendicion, "Resultado", resultado, 8).done(function () {
                    if (self.ViewRendidas)
                        self.ViewRendidas.SolicitudesDeViaticos.fnDraw();

                    app.closeCurrentTab();
                    app.irATab(3);

                    //if (resultado.estado) {
                    //    self.GenerarRendicionDeViatico(v.Id.val(),v);
                    //}
                    //self.ViewIndex.SolicitudesDeViaticos.fnDraw();
                    //app.closeCurrentTab();
                    //app.irATab(0);
                });
            });

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado();
                self.ajaxPostEditarRendicion(self.ViewEditarRendicion, "Resultado", resultado, 9).done(function () {
                    if (resultado.estado) {
                        self.GenerarRendicionDeViatico(v.Id.val(),v);
                    }
                    if (self.ViewRendidas)
                        self.ViewRendidas.SolicitudesDeViaticos.fnDraw();
                    if (self.ViewIndex)
                        self.ViewIndex.SolicitudesDeViaticos.fnDraw();
                    app.closeCurrentTab();
                    app.irATab(0);
                });
            });
             
        }

        public sugerirComisiones(v: Crear, inicio: any) {
            console.log(inicio);
            $.get("Expedientes/SolicitudesDeViaticos/SugerirComisiones/?lugar=" + v.Destino.hidden.val() + "&desde=" + inicio.format("DD/MM/YYYY"), null,
                function (data) {
                    var tr = "";
                    v.body_comisiones.empty();
                    $.each(data, function (i, o) {
                        tr += "<tr data-id='" + o.Id + "' data-tipo='seleccionar'><td>" + o.Comision + "</td><td>" + o.Descripcion_Destino + "</td><td>" + app.formatearFecha(o.Desde) + "</td><td>" + app.formatearFecha(o.Hasta) + "</td><td>" + o.Motivo + "</td><td><button class='btn btn-success' data-id='" + o.Id + "' data-comision='" + o.Comision + "' data-medio='" + o.MedioDeTransporte + "' data-auto='" + o.AutoOficial + "' data-desde='"+o.Desde+"' data-hasta='"+o.Hasta+"' data-motivo='" + o.Motivo + "' data-tipo='select_comision'>Seleccionar</button></td></tr>";
                    });
                    v.body_comisiones.append(tr);
                    if (tr.length > 0) {
                        app.crearNotificacionWarning("Atención...", "Encontramos otras solicitudes de viáticos con el mismo Destino y Fecha. Por favor controle si su solicitud pertenece a la misma comisión");
                        v.tabla_comisiones.show();
                    }
                    else
                        v.tabla_comisiones.hide();

                });

            $("button[data-tipo=select_comision]").die("click");
            $("button[data-tipo=select_comision]").live("click", function (e) {
                e.preventDefault();
                var motivo = $(this).data("motivo");
                var medio = $(this).data("medio");
                var auto = $(this).data("auto");
                var comision = $(this).data("comision");
                var desde = $(this).data("desde");
                var hasta = $(this).data("hasta");
                var id = $(this).data("id");

                var inicio = moment(desde);

                console.log(inicio);
                var fin = moment(hasta);

                $("tr[data-tipo=seleccionar]").children("td").css("background-color", "#ffffff");
                $("tr[data-id=" + id + "]").children("td").css("background-color", "#DFF0F5");

                v.Comision.val(comision);
                v.MotivoDeComision.val(motivo);
                v.MedioDeTransporte.find("option[value=" + medio + "]").prop("selected", "selected");
                v.FechaDeInicio.val(inicio.format("YYYY-MM-DD HH:mm"));
                v.FechaDeFin.val(fin.format("YYYY-MM-DD HH:mm"));
                
                v.MedioDeTransporte.prop("disabled", "disabled");
                v.MotivoDeComision.prop("disabled", "disabled");
                v.FechaDeInicio.prop("disabled", "disabled");
                v.FechaDeFin.prop("disabled", "disabled");

            });
        }

        public setCrear(v: Crear) {
            var self = this;
            this.ViewCrear = v;
            this.detalle_solicitud = [];
            this.detalle_conceptos = [];
            this.id_agente = 0;
            v.Comision.val("");
            v.MedioDeTransporte.removeAttr("disabled");
            v.MotivoDeComision.removeAttr("disabled");
            v.FechaDeInicio.removeAttr("disabled");
            v.FechaDeFin.removeAttr("disabled");
            v.GuardarYNuevo.show();

            var monto_vigente: model.MontosDeViaticos;

            v.guardar_gasto.click(function (e) {
                e.preventDefault();
                var g = new model.SolicitudesDeViaticosRendicionesDetalle();
                g.Descripcion = v.concepto.find("option:selected").text();
                g.Concepto = v.concepto.val();
                g.Importe = parseFloat(v.importe_gastos.val());
                g.Agente = self.id_agente;

                self.detalle_conceptos.push(g);

                self.refrescarConceptos(self.id_agente);
            });

            app.getData("Expedientes/MontosDeViaticos/GetVigente").done(function (data) {
                monto_vigente = data;
            });

            $("input[data-tipo=gastos]").die("change");
            $("input[data-tipo=gastos]").live("change", function (data) {
                var agente = $(this).data("agente");
                Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == agente }).First().ImporteGastos = parseFloat($(this).val());
                self.refrescarSolicitudesAgentes();
            });

            $("input[data-tipo=gastos]").die("click");


            $("a[data-tipo=quitar-agente]").die("click");
            $("a[data-tipo=quitar-agente]").live("click", function (data) {
                var idagente = $(this).data("agente");
                bootbox.confirm("Está seguro que desea quitar el agente?", function (result) {
                    if (result) {
                        //var idagente = $(this).data("agente");
                        console.log(idagente);
                        Enumerable.From(self.detalle_solicitud).Delete(function (x) { return x.Agente == idagente });
                        self.refrescarSolicitudesAgentes();
                    }
                });
                
            });

            v.VigenciaSeguro.change(function (e) {
                var fecha = new moment($(this).val(), 'DD/MM/YYYY');
                var inicio = new moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");

                if (fecha.toDate() < inicio.toDate()) {
                    app.crearNotificacionError("Error", "El seguro no tendrá vigencia al inicio de la Solicitud");
                }                                     
            });

            v.FechaDeInicio.change(function (e) {
               
                if (v.FechaDeFin.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    if (fin < inicio) {
                        app.crearNotificacionError("Error", "La fecha de finalización de la solicitud debe ser posterior a la de inicio");              
                        v.FechaDeInicio.val("");
                        v.FechaDeFin.val("");
                        v.FechaDeInicio.focus();                                  
                    } else {
                    
                    var hora_inicio = inicio.hour();
                    var minutos_inicio = inicio.minute();

                    var hora_fin = fin.hour();
                    var minutos_fin = fin.minute();
                  
                    //console.log(hora_inicio);
                    //console.log(minutos_inicio);

                    var horas = fin.diff(inicio, 'hours');
                    var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                    var dias = fin.diff(inicio, 'days');

                    console.log(dias_2);

                    //inicia y termina el mismo día
                    if (dias_2 == 1) {
                        if (hora_inicio <= 12) {
                            if (hora_fin >= 20) {
                                dias = 1;
                            } else {
                                dias = 0.5;
                            }
                        } else {
                            dias = 1;
                        }
                    }

                    //MAS de un dia
                    if (dias_2 > 1) {

                        if (hora_inicio <= 12) {
                            dias = 1;
                        } else {
                            dias = 0.5;
                        }

                        if (hora_fin > 12 && hora_fin < 20) {
                            dias += 0.5;
                        }

                        if (hora_fin >= 20) {
                            dias += 1;
                        }

                        dias += (dias_2 - 2)

                    }
                     
                    //var dias = 0;
                    var importe_dia = 0;
                    var subtotal = 0;
                    var total = 0;

                    var lapampa = false;
                    var veinticinco_de_mayo = false;

                    var destino = v.Destino.txt.val();
                    if (destino.indexOf("La Pampa") >= 0)
                        lapampa = true;

                    if (destino.indexOf("Colonia 25 De") >= 0)
                        veinticinco_de_mayo = true;


                    self.detalle_solicitud.forEach(function (o, i) {

                        //var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                        //var grupo = solicitud.Grupo;

                        //El agente es funcionario
                        if (o.Grupo == 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                            }

                        }

                        //No es funcionario
                        if (o.Grupo != 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                            }

                        }

                        o.Dias = dias;
                        o.ImportePorDia = importe_dia;
                        o.Subtotal = dias * importe_dia;

                        self.refrescarSolicitudesAgentes();

                    });

                    }
            }

            });

            v.FechaDeFin.change(function (e) {

                if (v.FechaDeInicio.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    if (fin < inicio) {
                        app.crearNotificacionError("Error", "La fecha de finalización de la solicitud debe ser posterior a la de inicio");
                        v.FechaDeInicio.val("");
                        v.FechaDeFin.val("");
                        v.FechaDeInicio.focus();
                    } else {

                        self.sugerirComisiones(v, inicio);

                        var hora_inicio = inicio.hour();
                        var minutos_inicio = inicio.minute();

                        var hora_fin = fin.hour();
                        var minutos_fin = fin.minute();

                        //console.log(hora_inicio);
                        //console.log(minutos_inicio);

                        var horas = fin.diff(inicio, 'hours');
                        var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                        var dias = fin.diff(inicio, 'days');

                        console.log(dias_2);

                        //inicia y termina el mismo día
                        if (dias_2 == 1) {
                            if (hora_inicio <= 12) {
                                if (hora_fin >= 20) {
                                    dias = 1;
                                } else {
                                    dias = 0.5;
                                }
                            } else {
                                dias = 1;
                            }
                        }

                        //MAS de un dia
                        if (dias_2 > 1) {

                            if (hora_inicio <= 12) {
                                dias = 1;
                            } else {
                                dias = 0.5;
                            }

                            if (hora_fin > 12 && hora_fin < 20) {
                                dias += 0.5;
                            }

                            if (hora_fin >= 20) {
                                dias += 1;
                            }

                            dias += (dias_2 - 2)

                        }
                     
                        //var dias = 0;
                        var importe_dia = 0;
                        var subtotal = 0;
                        var total = 0;

                        var lapampa = false;
                        var veinticinco_de_mayo = false;

                        var destino = v.Destino.txt.val();
                        if (destino.indexOf("La Pampa") >= 0)
                            lapampa = true;

                        if (destino.indexOf("Colonia 25 De") >= 0)
                            veinticinco_de_mayo = true;


                        self.detalle_solicitud.forEach(function (o, i) {

                            //var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                            //var grupo = solicitud.Grupo;

                            //El agente es funcionario
                            if (o.Grupo == 1) {

                                if (dias <= 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                    else
                                        importe_dia = monto_vigente.FuncionarioFueraUnDia;
                                }

                                if (dias > 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                    else
                                        importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                    if (veinticinco_de_mayo)
                                        importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                                }

                            }

                            //No es funcionario
                            if (o.Grupo != 1) {

                                if (dias <= 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                    else
                                        importe_dia = monto_vigente.AgenteFueraUnDia1;
                                }

                                if (dias > 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                    else
                                        importe_dia = monto_vigente.AgenteFueraUnDia1;

                                    if (veinticinco_de_mayo)
                                        importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                                }

                            }

                            o.Dias = dias;
                            o.ImportePorDia = importe_dia;
                            o.Subtotal = dias * importe_dia;

                            self.refrescarSolicitudesAgentes();

                        });
                    }
                }
            });

            v.Agente.setCallback(function (ui: any) {

                var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");
             
                var existe = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == ui.item.id }).Count() > 0;

                if (existe) {
                    app.crearNotificacionWarning("Atención", "El agente que intenta añadir ya existe en esta solicitud");
                    return;
                } 

                $.get("Expedientes/SolicitudesDeViaticos/Solapamiento/?agente=" + ui.item.id + "&desde=" + encodeURIComponent(inicio.toISOString()) + "&hasta=" + encodeURIComponent(fin.toISOString()), null, function (data) {
                    if (data) {
                        app.crearNotificacionError("Error...", "Atención, el agente que desea agregar a la solicitud se SOLAPA con otra solicitud");
                    } else {
                        var hora_inicio = inicio.hour();
                        var minutos_inicio = inicio.minute();

                        var hora_fin = fin.hour();
                        var minutos_fin = fin.minute();

                        //console.log(hora_inicio);
                        //console.log(minutos_inicio);

                        var horas = fin.diff(inicio, 'hours');
                        var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                        var dias = fin.diff(inicio, 'days');

                        console.log(dias_2);

                        //inicia y termina el mismo día
                        if (dias_2 == 1) {
                            if (hora_inicio <= 12) {
                                if (hora_fin >= 20) {
                                    dias = 1;
                                } else {
                                    dias = 0.5;
                                }
                            } else {
                                dias = 1;
                            }
                        }

                        //MAS de un dia
                        if (dias_2 > 1) {

                            if (hora_inicio <= 12) {
                                dias = 1;
                            } else {
                                dias = 0.5;
                            }

                            if (hora_fin > 12 && hora_fin < 20) {
                                dias += 0.5;
                            }

                            if (hora_fin >= 20) {
                                dias += 1;
                            }

                            dias += (dias_2 - 2)

                        }
                     
                        //var dias = 0;
                        var importe_dia = 0;
                        var subtotal = 0;
                        var total = 0;

                        var lapampa = false;
                        var veinticinco_de_mayo = false;

                        var destino = v.Destino.txt.val();
                        if (v.Destino.txt.val().indexOf("La Pampa") >= 0)
                            lapampa = true;

                        if (v.Destino.txt.val().indexOf("Colonia 25 De") >= 0)
                            veinticinco_de_mayo = true;

                                    
                        //El agente es funcionario
                        if (ui.item.cargo.Grupo == 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }
                        
                            //if (dias == 1) {
                            //    if (lapampa)
                            //        importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                            //    else
                            //        importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            //}
                    
                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                            }

                        }

                        //No es funcionario
                        if (ui.item.cargo.Grupo != 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                            }

                        }

                        var d = new model.SolicitudesDeViaticosAgentes();

                        d.Agente = ui.item.id;
                        d.Dias = dias;
                        d.ImportePorDia = importe_dia;
                        d.ImporteGastos = 0;
                        d.ImporteTotal = parseFloat((importe_dia * dias).toFixed(2));
                        d.Subtotal = parseFloat((importe_dia * dias).toFixed(2));
                        d.AgenteDescripcion = ui.item.label;
                        d.CargoDescripcion = ui.item.cargo.Descripcion;
                        d.Grupo = ui.item.cargo.Grupo;
                        d.Afiliado = ui.item.afiliado;


                        self.detalle_solicitud.push(d);

                        self.refrescarSolicitudesAgentes();      
                    }
                });
                                    
            });

            v.Cancelar.click(function (e) {
                self.ViewCrear.limpiar(); app.irATab(0);
            });

            v.ImprimirSolicitud.click(function (e) {
                e.preventDefault();
                self.GenerarSolicitudDeViatico(v.Id.val(), v);
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();

                if (v.MedioDeTransporte.val() == 2) {

                    var fecha = new moment($(this).val(), 'DD/MM/YYYY');
                    var inicio = new moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");

                    if (fecha.toDate() < inicio.toDate()) {
                        app.crearNotificacionError("Error", "El seguro no tendrá vigencia al inicio de la Solicitud");
                        return;
                    }
                }

                if (global.appexterna) {
                    bootbox.prompt({
                        title: "Por favor ingrese su clave de acceso",
                        inputType: 'password',
                        callback: function (result) {
                            $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                if (data) {                                   
                                    self.ajaxPostCrearJson(self.ViewCrear, "Resultado", resultado, 1).done(function () {
                                        if (resultado.estado) {
                                            //app.hub.server.enviarNotificacionPorOrganismo("Nueva comisión","Hay una una solicitud de viático para asignar Chofer y/o Vehículo", global.id_servicios_generales);
                                            v.GuardarYNuevo.hide();
                                            //self.ViewTodos
                                            //self.ViewIndex.SolicitudesDeViaticos.fnDraw();
                                            //v.ImprimirSolicitud.show();
                                            app.reloadCurrentTab();
                                            if (self.ViewIndex)
                                                self.ViewIndex.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexBorrador)
                                                self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexPendientes)
                                                self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexPorRendir)
                                                self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();
                                            if (self.ViewTodosAnticipo)
                                                self.ViewTodosAnticipo.Anticipos.fnDraw();
                                            if (self.ViewTodosReintegro)
                                                self.ViewTodosReintegro.SolicitudesDeViaticos.fnDraw();

                                            //v.Id.val(resultado.id.toString());

                                            //if (estado == 12) {
                                            //self.GenerarSolicitudDeViatico(resultado.id, v);
                                            //}
                                            app.reloadCurrentTab();
                                            app.irATab(0);
                                        }
                                    });
                                } else {
                                    app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                }
                            });
                        }
                    });
                } else {
                    if (v.MotivoDeComision.val() == "") {
                        app.crearNotificacionWarning("Atención...", "Por favor ingrese un motivo de viático");
                        v.MotivoDeComision.focus();
                    } else {
                        self.ajaxPostCrearJson(self.ViewCrear, "Resultado", resultado, 1).done(function () {
                            if (resultado.estado) {
                                //app.hub.server.enviarNotificacionPorOrganismo("Nueva comisión","Hay una una solicitud de viático para asignar Chofer y/o Vehículo", global.id_servicios_generales);
                                v.GuardarYNuevo.hide();
                                if (self.ViewIndex)
                                    self.ViewIndex.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexBorrador)
                                    self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexPendientes)
                                    self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexPorRendir)
                                    self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();
                                
                                v.ImprimirSolicitud.show();
                                v.Id.val(resultado.id.toString());
                                //if (estado == 12) {
                                self.GenerarSolicitudDeViatico(resultado.id, v);
                                //}
                                app.reloadCurrentTab();
                                app.irATab(0);
                            }

                        });
                    }

                }
            });

            //------------ Confirmar --------------//
            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado();
                var estado = 2;

                if (global.appexterna) {
                    bootbox.prompt({
                        title: "Por favor ingrese su clave de acceso",
                        inputType: 'password',
                        callback: function (result) {
                            $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                if (data) {
                                    //está marcada la opción con chofer o medio de transporte es Auto Poder Judicial y no está asignado
                                    if (global.Organismo != global.id_servicios_generales && (v.ConChofer.is(":checked") || (v.MedioDeTransporte.val() == 1 && v.AutoOficial.val() == 0))) {
                                        console.log("Marcar como pendiente de asignar chofer y vehículo");
                                        estado = 12;
                                    }

                                    self.ajaxPostCrearJson(self.ViewCrear, "Resultado", resultado, estado).done(function () {
                                        if (resultado.estado) {
                                            app.hub.server.enviarNotificacionPorOrganismo("Nueva comisión","Hay una una solicitud de viático para asignar Chofer y/o Vehículo", global.id_servicios_generales);
                                            v.GuardarYNuevo.hide();

                                            if (self.ViewIndex)
                                                self.ViewIndex.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexBorrador)
                                                self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexPendientes)
                                                self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexPorRendir)
                                                self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();

                                            //self.ViewIndex.SolicitudesDeViaticos.fnDraw();
                                            v.ImprimirSolicitud.show();
                                            v.Id.val(resultado.id.toString());
                                            //if (estado == 12) {
                                            self.GenerarSolicitudDeViatico(resultado.id, v);
                                            //}
                                            app.reloadCurrentTab();
                                            app.irATab(1);
                                        }

                                    });
                                } else {
                                    app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                }
                            });
                        }
                    });
                } else {

                    if (v.MotivoDeComision.val() == "") {
                        app.crearNotificacionWarning("Atención...", "Por favor ingrese un motivo de viático");
                        v.MotivoDeComision.focus();
                    } else {

                        if (global.Organismo != global.id_servicios_generales && (v.ConChofer.is(":checked") || (v.MedioDeTransporte.val() == 1 && v.AutoOficial.val() == 0))) {
                            console.log("Marcar como pendiente de asignar chofer y vehículo");
                            estado = 12;
                        }

                        self.ajaxPostCrearJson(self.ViewCrear, "Resultado", resultado, estado).done(function () {
                            if (resultado.estado) {
                                //app.hub.server.enviarNotificacionPorOrganismo("Nueva comisión","Hay una una solicitud de viático para asignar Chofer y/o Vehículo", global.id_servicios_generales);
                                v.GuardarYNuevo.hide();

                                if (self.ViewIndex)
                                    self.ViewIndex.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexBorrador)
                                    self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexPendientes)
                                    self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexPorRendir)
                                    self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();

                                v.ImprimirSolicitud.show();
                                v.Id.val(resultado.id.toString());
                                //if (estado == 12) {
                                self.GenerarSolicitudDeViatico(resultado.id, v);
                                //}
                                app.reloadCurrentTab();
                                app.irATab(1);
                            }

                        });
                    }

                }
            });

            v.Destino.txt.focus();

        }

        public refrescarSolicitudesAgentes() {
            var that = this;
            this.ViewCrear.bodyAgente.empty();
            var total = 0.0;

            this.detalle_solicitud.forEach(function (o, i) {
                var importeTotal = (o.ImportePorDia * o.Dias) + o.ImporteGastos;
                o.ImporteTotal = importeTotal;
                var tr = "<tr data-agente='" + o.Agente + "'><td>" + o.AgenteDescripcion + "</td><td>" + o.Afiliado + "</td><td>" + o.CargoDescripcion + "</td><td>" + o.Dias + "</td><td>" + o.ImportePorDia + "</td><td>" + o.Subtotal + "</td><td><input type='text' class='form-control' data-agente='" + o.Agente + "' data-tipo='gastos' value='"+o.ImporteGastos+"' /></td><td><span data-agente='" + o.Agente + "'>" + o.ImporteTotal + "</span></td><td><a class='btn' data-tipo='quitar-agente' data-agente='"+o.Agente+"'>-</a> </td></tr>";
                that.ViewCrear.bodyAgente.append(tr);
                total += importeTotal;
            });   
            this.ViewCrear.spTotalASolicitar.html(total.toString());    
        }

        public refrescarSolicitudesAgentesAsignarChofer() {
            var that = this;
            this.ViewCrear.bodyAgente.empty();
            var total = 0.0;

            this.detalle_solicitud.forEach(function (o, i) {
                var importeTotal = (o.ImportePorDia * o.Dias) + o.ImporteGastos;
                o.ImporteTotal = importeTotal;
                var tr = "<tr data-agente='" + o.Agente + "'><td>" + o.AgenteDescripcion + "</td><td>" + o.Afiliado + "</td><td>" + o.CargoDescripcion + "</td><td>" + o.Dias + "</td><td>" + o.ImportePorDia + "</td><td>" + o.Subtotal + "</td><td><input type='text' class='form-control' data-agente='" + o.Agente + "' data-tipo='gastos' value='" + o.ImporteGastos + "' /></td><td><span data-agente='" + o.Agente + "'>" + o.ImporteTotal + "</span></td><td><a class='btn' data-agente='" + o.Agente + "'>-</a> </td></tr>";
                that.ViewCrear.bodyAgente.append(tr);
                total += importeTotal;
            });
            this.ViewCrear.spTotalASolicitar.html(total.toString());
        }

        public refrescarSolicitudesAgentesEditar() {
            var that = this;
            this.ViewEditar.bodyAgente.empty();
            var total = 0.0;

            this.detalle_solicitud.forEach(function (o, i) {
                var importeTotal = (o.ImportePorDia * o.Dias) + o.ImporteGastos;
                o.ImporteTotal = importeTotal;
                //var tr = "<tr data-agente='" + o.Agente + "'><td>" + o.AgenteDescripcion + "</td><td>" + o.Agente + "</td><td>" + o.Dias + "</td><td>" + o.ImportePorDia + "</td><td>" + o.Subtotal + "</td><td><input type='text' class='form-control' data-agente='" + o.Agente + "' data-tipo='gastos' value='" + o.ImporteGastos + "' /></td><td><span data-agente='" + o.Agente + "'>" + o.ImporteTotal + "</span></td><td>"+o.ImporteTotal+"<td>0</td><td>0</td></td><td><a class='btn' data-agente='" + o.Agente + "'>-</a> </td></tr>";
                var tr = "<tr data-agente='" + o.Agente + "'><td>" + o.AgenteDescripcion + "</td><td>" + o.Afiliado + "</td><td>" + o.CargoDescripcion + "</td><td>" + o.Dias + "</td><td>" + o.ImportePorDia + "</td><td>" + o.Subtotal + "</td><td><input type='text' class='form-control' data-agente='" + o.Agente + "' data-tipo='gastos' value='" + o.ImporteGastos + "' /></td><td><span data-agente='" + o.Agente + "'>" + o.ImporteTotal + "</span></td><td><a class='btn' data-tipo='quitar-agente' data-agente='" + o.Agente + "'>-</a> </td></tr>";
                that.ViewEditar.bodyAgente.append(tr);
                total += importeTotal;
            });
            this.ViewEditar.spTotalASolicitar.html(total.toString());
        }

        public refrescarConceptos(agente: number) {

            this.ViewCrear.body_gastos.empty();

            var r = Enumerable.From(this.detalle_conceptos).Where(function (x) { return x.Agente == agente });
            var tr = "";
            var total = 0;

            r.ForEach(function (o, i) {
                tr += "<tr><td>" + o.Descripcion + "</td><td>" + o.Importe + "</td><td><a class='btn' onclick='quitar_agente("+o.Agente+")'>quitar</a></td></tr>"; 
                total += o.Importe;
            });

            Enumerable.From(this.detalle_solicitud).Where(function (x) { return x.Agente == agente}).First().ImporteGastos = total;

            this.ViewCrear.body_gastos.append(tr);

            this.refrescarSolicitudesAgentes();

        }

        public refrescarDetalleDeGastos(agente: number) {
            var v = this.ViewCrearRendicion;

            v.Body_Gastos.empty();
            this.detalle_conceptos.forEach(function (o, i) {
                if (o.Agente == agente) {
                    var tr = "<tr><td>" + o.Descripcion + "</td><td>" + o.Importe + "</td><td><a class='btn' data-agente='"+o.Agente+"' data-concepto='"+o.Concepto+"' data-tipo='quitar_gasto'>quitar</a></td></tr>";
                    v.Body_Gastos.append(tr);
                }
            });
        }

        public refrescarDetalleDeGastosEditar(agente: number) {
            var v = this.ViewEditarRendicion;

            v.Body_Gastos.empty();
            this.detalle_conceptos.forEach(function (o, i) {
                if (o.Agente == agente) {
                    var tr = "<tr><td>" + o.Descripcion + "</td><td>" + o.Importe + "</td><td><a class='btn' data-agente='" + o.Agente + "' data-concepto='" + o.Concepto + "' data-tipo='quitar_gasto'>quitar</a></td></tr>";
                    v.Body_Gastos.append(tr);
                }
            });
        }

        public refrescarPartidas() {
            var v = this.ViewCrearRendicion;

            v.Body_Partidas.empty();

            var detalle = new Array<model.DetallePartidas>();
            detalle = [];

            this.detalle_conceptos.forEach(function (o, i) {

                var partida = global.conceptos.filter(x=> x.Id == o.Concepto)[0].Partida; 

                if (detalle.filter(x=> x.Id == partida).length > 0) {
                    console.log("actualiza detalle partida");
                    detalle.filter(x=> x.Id == partida)[0].Total += o.Importe;
                } else {
                    console.log("crea detalle partida");
                    var d = new model.DetallePartidas();
                    d.Id = partida;
                    d.Partida = global.partidas.filter(x=> x.Id == partida)[0].Partida;
                    d.Total = o.Importe;
                    detalle.push(d);
                }
            });

            var total = 0;
            this.detalle_rendicion.forEach(function (o, i) {
                total += o.Subtotal;
            });
           
            detalle.forEach(function (o, i) {
                if (o.Id == 4) {
                    total = parseFloat(total.toString()) + parseFloat(o.Total.toString()); 
                } else {
                    console.log("se muestra partida: " + o.Partida);
                    v.Body_Partidas.append("<tr><td>" + o.Partida + "</td><td>" + o.Total + "</td></tr>");
                }
            });

            v.Body_Partidas.append("<tr><td>0035 - Servicios No Personales</td><td><span Id='snp'>" + total + "</span></td></tr>");
        }

        public refrescarPartidasEditar() {
            //var v = this.ViewEditarRendicion;

            //v.Body_Partidas.empty();

            //var detalle = new Array<model.DetallePartidas>();
            //detalle = [];

            //this.detalle_conceptos.forEach(function (o, i) {

            //    var partida = global.conceptos.filter(x=> x.Id == o.Concepto)[0].Partida;

            //    if (detalle.filter(x=> x.Id == partida).length > 0) {
            //        console.log("actualiza detalle partida");
            //        detalle.filter(x=> x.Id == partida)[0].Total += o.Importe;
            //    } else {
            //        console.log("crea detalle partida");
            //        var d = new model.DetallePartidas();
            //        d.Id = partida;
            //        d.Partida = global.partidas.filter(x=> x.Id == partida)[0].Partida;
            //        d.Total = o.Importe;
            //        detalle.push(d);
            //    }
            //});

            //var total = 0;
            //this.detalle_solicitud.forEach(function (o, i) {
            //    total += o.Subtotal;
            //});

            //v.Body_Partidas.append("<tr><td>Servicios No Personales</td><td>" + total + "</td></tr>");

            //detalle.forEach(function (o, i) {
            //    console.log("se muestra partida: " + o.Partida);
            //    v.Body_Partidas.append("<tr><td>" + o.Partida + "</td><td>" + o.Total + "</td></tr>");
            //});
            var v = this.ViewEditarRendicion;

            v.Body_Partidas.empty();

            var detalle = new Array<model.DetallePartidas>();
            detalle = [];

            this.detalle_conceptos.forEach(function (o, i) {

                var partida = global.conceptos.filter(x=> x.Id == o.Concepto)[0].Partida;

                if (detalle.filter(x=> x.Id == partida).length > 0) {
                    console.log("actualiza detalle partida");
                    detalle.filter(x=> x.Id == partida)[0].Total += o.Importe;
                } else {
                    console.log("crea detalle partida");
                    var d = new model.DetallePartidas();
                    d.Id = partida;
                    d.Partida = global.partidas.filter(x=> x.Id == partida)[0].Partida;
                    d.Total = o.Importe;
                    detalle.push(d);
                }
            });

            var total = 0;
            this.detalle_rendicion.forEach(function (o, i) {
                total += o.Subtotal;
            });

            detalle.forEach(function (o, i) {
                if (o.Id == 4) {
                    total = parseFloat(total.toString()) + parseFloat(o.Total.toString());
                } else {
                    console.log("se muestra partida: " + o.Partida);
                    v.Body_Partidas.append("<tr><td>" + o.Partida + "</td><td>" + o.Total + "</td></tr>");
                }
            });

            v.Body_Partidas.append("<tr><td>0035 - Servicios No Personales</td><td><span Id='snp'>" + total + "</span></td></tr>");
        }

        public refrescarDetalleDeGastosEdicion(agente: number) {
            var v = this.ViewEditarRendicion;

            v.Body_Gastos.empty();
            this.detalle_conceptos.forEach(function (o, i) {
                if (o.Agente == agente) {
                    var tr = "<tr><td>" + o.Descripcion + "</td><td>" + o.Importe + "</td><td><a class='btn' data-agente='" + o.Agente + "' data-concepto='" + o.Concepto + "' data-tipo='quitar_gasto'>quitar</a></td></tr>";
                    v.Body_Gastos.append(tr);
                }
            });

        }

        public refrescarRendicionesAgentes() {
            var totalGastos = 0;
            var totalTotal = 0;
            var totalAnticipo = 0;
            var totalCobrar = 0;
            var totalDevolver = 0;
            var totalSubtotal = 0;

            var that = this;
            this.ViewCrearRendicion.bodyAgente.empty();
            var total = 0.0;

            this.detalle_rendicion.forEach(function (o, i) {
                var subtotal = Math.round((o.ImportePorDia * o.Dias) * 100) / 100;
                var importeTotal = Math.round(((o.ImportePorDia * o.Dias) + o.Gastos) * 100) / 100;
                              
                o.Subtotal = subtotal;
                o.Total = importeTotal;

                var diferencia = Math.round((o.Anticipo - o.Total) * 100) /100;

                // el anticipo fue mayor 
                if (diferencia >= 0) {
                    o.Devolver = Math.abs(diferencia);
                    o.Cobrar = 0;
                } else {
                    o.Cobrar = Math.abs(diferencia);
                    o.Devolver = 0;
                }

                totalGastos += o.Gastos;
                totalTotal += o.Total;
                totalAnticipo += o.Anticipo;
                totalCobrar += o.Cobrar;

                totalDevolver += o.Devolver;
                totalSubtotal += o.Subtotal;

                var tr = "<tr data-agente='" + o.Agente + "'><td>" + o.AgenteDescripcion + "</td><td>" + o.Agente + "</td><td>" + o.Dias + "</td><td>" + o.ImportePorDia + "</td><td>" + o.Anticipo + "</td><td>" + o.Subtotal + "</td><td>" + o.GastosViaticos + "</td><td>" + o.Viaticos + "</td><td><input type='text' class='form-control' data-agente='" + o.Agente + "' data-tipo='gastos' value='" + o.Gastos + "' /></td><td><span data-agente='" + o.Agente + "'>" + o.Total + "</span></td><td>" + o.Anticipo + "<td>" + o.Cobrar + "</td><td>" + o.Devolver + "<input id='input_boleta_" + o.Agente +"' data-tipo='input-boleta' class='form-control' style='display:none'/></td></tr>";
                
                that.ViewCrearRendicion.bodyAgente.append(tr);

                if (o.Devolver > 0) {
                    $("#input_boleta_" + o.Agente).show();
                }


                total += importeTotal;
            });

            this.ViewCrearRendicion.spTotalAnticipo.html(totalAnticipo.toString());
            this.ViewCrearRendicion.spTotalCobrar.html(totalCobrar.toString());
            this.ViewCrearRendicion.spTotalDevolver.html(totalDevolver.toString());
            this.ViewCrearRendicion.spTotalGastos.html(totalGastos.toString());
            this.ViewCrearRendicion.spTotalTotal.html(totalTotal.toString());

            this.ViewCrearRendicion.spServiciosNoPersonales.html(totalSubtotal.toString());
            this.ViewCrearRendicion.spBienesDeConsumo.html(totalGastos.toString());

            if (totalDevolver > 0) {
                //this.ViewCrearRendicion.GuardarYNuevo.hide();                
                //this.ViewCrearRendicion.rowBoleta.show();
            }
        }

        public refrescarRendicionesAgentesEditar() {
            var totalGastos = 0;
            var totalTotal = 0;
            var totalAnticipo = 0;
            var totalCobrar = 0;
            var totalDevolver = 0;
            var totalSubtotal = 0;

            var that = this;
            this.ViewEditarRendicion.bodyAgente.empty();
            var total = 0.0;

            this.detalle_rendicion.forEach(function (o, i) {
                var subtotal = Math.round((o.ImportePorDia * o.Dias) * 100) / 100;
                var importeTotal = Math.round(((o.ImportePorDia * o.Dias) + o.Gastos) * 100) / 100;

                o.Subtotal = subtotal;
                o.Total = importeTotal;

                var diferencia = Math.round((o.Anticipo - o.Total) * 100) / 100;

                // el anticipo fue mayor 
                if (diferencia >= 0) {
                    o.Devolver = Math.abs(diferencia);
                    o.Cobrar = 0;
                } else {
                    o.Cobrar = Math.abs(diferencia);
                    o.Devolver = 0;
                }

                totalGastos += o.Gastos;
                totalTotal += o.Total;
                totalAnticipo += o.Anticipo;
                totalCobrar += o.Cobrar;

                totalDevolver += o.Devolver;
                totalSubtotal += o.Subtotal;
                o.GastosViaticos = that.detalle_solicitud.filter(x=> x.Agente == o.Agente)[0].ImporteGastos;
                o.Viaticos = that.detalle_solicitud.filter(x=> x.Agente == o.Agente)[0].ImporteTotal;

                var tr = "<tr data-agente='" + o.Agente + "'><td>" + o.AgenteDescripcion + "</td><td>" + o.Agente + "</td><td>" + o.Dias + "</td><td>" + o.ImportePorDia + "</td><td>" + o.Anticipo + "</td><td>" + o.Subtotal + "</td><td>" + o.GastosViaticos + "</td><td>" + o.Viaticos + "</td><td><input type='text' class='form-control' data-agente='" + o.Agente + "' data-tipo='gastos' value='" + o.Gastos + "' /></td><td><span data-agente='" + o.Agente + "'>" + o.Total + "</span></td><td>" + o.Anticipo + "<td>" + o.Cobrar + "</td><td>" + o.Devolver + "<input id='input_boleta_" + o.Agente + "' data-tipo='input-boleta' class='form-control' style='display:none'/></td></tr>";

                that.ViewEditarRendicion.bodyAgente.append(tr);

                if (o.Devolver > 0) {
                    $("#input_boleta_" + o.Agente).show();
                }


                total += importeTotal;
            });

            this.ViewEditarRendicion.spTotalAnticipo.html(totalAnticipo.toString());
            this.ViewEditarRendicion.spTotalCobrar.html(totalCobrar.toString());
            this.ViewEditarRendicion.spTotalDevolver.html(totalDevolver.toString());
            this.ViewEditarRendicion.spTotalGastos.html(totalGastos.toString());
            this.ViewEditarRendicion.spTotalTotal.html(totalTotal.toString());

            this.ViewEditarRendicion.spServiciosNoPersonales.html(totalSubtotal.toString());
            this.ViewEditarRendicion.spBienesDeConsumo.html(totalGastos.toString());

            if (totalDevolver > 0) {
                //this.ViewCrearRendicion.GuardarYNuevo.hide();                
                //this.ViewCrearRendicion.rowBoleta.show();
            }
        }

        //public refrescarRendicionesAgentesEditar() {
        //    var totalGastos = 0;
        //    var totalTotal = 0;
        //    var totalAnticipo = 0;
        //    var totalCobrar = 0;
        //    var totalDevolver = 0;
        //    var totalSubtotal = 0;

        //    var that = this;
        //    this.ViewEditarRendicion.bodyAgente.empty();
        //    var total = 0.0;

        //    this.detalle_rendicion.forEach(function (o, i) {
        //        var subtotal = Math.round((o.ImportePorDia * o.Dias) * 100) / 100;
        //        var importeTotal = Math.round(((o.ImportePorDia * o.Dias) + o.Gastos) * 100) / 100;

        //        o.Subtotal = subtotal;
        //        o.Total = importeTotal;

        //        var diferencia = Math.round((o.Anticipo - o.Total) * 100) / 100;

        //        // el anticipo fue mayor 
        //        if (diferencia >= 0) {
        //            o.Devolver = Math.abs(diferencia);
        //            o.Cobrar = 0;
        //        } else {
        //            o.Cobrar = Math.abs(diferencia);
        //            o.Devolver = 0;
        //        }

        //        totalGastos += o.Gastos;
        //        totalTotal += o.Total;
        //        totalAnticipo += o.Anticipo;
        //        totalCobrar += o.Cobrar;
        //        totalDevolver += o.Devolver;
        //        totalSubtotal += o.Subtotal;

        //        var tr = "<tr data-agente='" + o.Agente + "'><td>" + o.AgenteDescripcion + "</td><td>" + o.Agente + "</td><td>" + o.Dias + "</td><td>" + o.ImportePorDia + "</td><td>" + o.Subtotal + "</td><td><input type='text' class='form-control' data-agente='" + o.Agente + "' data-tipo='gastos' value='" + o.Gastos + "' /></td><td><span data-agente='" + o.Agente + "'>" + o.Total + "</span></td><td>" + o.Anticipo + "<td>" + o.Cobrar + "</td><td>" + o.Devolver + "</td></td></tr>";

        //        that.ViewEditarRendicion.bodyAgente.append(tr);
        //        total += importeTotal;
        //    });

        //    this.ViewEditarRendicion.spTotalAnticipo.html(totalAnticipo.toString());
        //    this.ViewEditarRendicion.spTotalCobrar.html(totalCobrar.toString());
        //    this.ViewEditarRendicion.spTotalDevolver.html(totalDevolver.toString());
        //    this.ViewEditarRendicion.spTotalGastos.html(totalGastos.toString());
        //    this.ViewEditarRendicion.spTotalTotal.html(totalTotal.toString());

        //    this.ViewEditarRendicion.spServiciosNoPersonales.html(totalSubtotal.toString());
        //    this.ViewEditarRendicion.spBienesDeConsumo.html(totalGastos.toString());
        //}

        public setEditar(v: Crear) {
            var self = this;
            this.ViewEditar = v;

            v.ImprimirSolicitud.show();

            app.getData("Expedientes/SolicitudesDeViaticos/GetAgentes/" + v.Id.val(), null).done(function (data) {

                self.detalle_solicitud = data;
                self.refrescarSolicitudesAgentesEditar();

            });

            if (v.OrganismoSolicitante.val() != global.organismo) {
                v.Guardar.hide();
                v.GuardarYNuevo.hide();               
            }


            var monto_vigente: model.MontosDeViaticos;

            app.getData("Expedientes/MontosDeViaticos/GetVigente").done(function (data) {
                monto_vigente = data;
            });

            v.CancelarSolicitud.click(function (e) {              
                bootbox.confirm("Atención, va a cancelar esta solicitud. Está seguro? ", function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: "Expedientes/SolicitudesDeViaticos/CancelarSolicitud",
                            data: { Solicitud: v.Id.val() },
                            success: function (data) {
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                    app.closeCurrentTab();
                                    if (self.ViewIndex)
                                        self.ViewIndex.SolicitudesDeViaticos.fnDraw();
                                    if (self.ViewIndexBorrador)
                                        self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();
                                    if (self.ViewIndexPendientes)
                                        self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();
                                    if (self.ViewIndexPorRendir)
                                        self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();
                                    if (self.ViewTodosAnticipo)
                                        self.ViewTodosAnticipo.Anticipos.fnDraw();
                                    if (self.ViewTodosReintegro)
                                        self.ViewTodosReintegro.SolicitudesDeViaticos.fnDraw();
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
                        }));
                    }
                });
            });

            v.Estado.change(function (e) {

                var descripcion = v.Estado.find("option:selected").text();
                var valor = $(this).val();

                if (valor > 0) {

                    bootbox.confirm("Atención, va a modificar el estado del trámite a " + descripcion, function (result) {
                        if (result) {
                            app.Bloquear();
                            $.when($.ajax({
                                type: "POST",
                                url: "Expedientes/SolicitudesDeViaticos/ActualizarEstado",
                                data: {estado:valor, solicitud:v.Id.val() },
                                success: function (data) {
                                    if (data[0]) {
                                        app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                        if (self.ViewIndex)
                                            self.ViewIndex.SolicitudesDeViaticos.fnDraw();
                                        if (self.ViewTodosAnticipo)
                                            self.ViewTodosAnticipo.Anticipos.fnDraw();
                                        if (self.ViewTodosReintegro)
                                            self.ViewTodosReintegro.SolicitudesDeViaticosReintegro.fnDraw();
                                    } else {
                                        app.crearNotificacionError("Error", data[1]);
                                    }
                                    if (data[3] != "") {
                                        app.crearNotificacionWarning("Atención", data[3]);                                        
                                    }
                                    app.Desbloquear();
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
                }   


            });

            v.ImprimirSolicitud.click(function (e) {
                e.preventDefault();
                self.GenerarSolicitudDeViatico(v.Id.val(),v);
            });

            $("input[data-tipo=gastos]").die("change");
            $("input[data-tipo=gastos]").live("change", function (data) {
                var agente = $(this).data("agente");
                Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == agente }).First().ImporteGastos = parseFloat($(this).val());
                self.refrescarSolicitudesAgentesEditar();
            });

            $("a[data-tipo=quitar-agente]").die("click");
            $("a[data-tipo=quitar-agente]").live("click", function (data) {
                var idagente = $(this).data("agente");
                bootbox.confirm("Está seguro que desea quitar el agente?", function (result) {
                    if (result) {                        
                        console.log("Quitar el id agente: " + idagente);
                        Enumerable.From(self.detalle_solicitud).Delete(function (x) { return x.Agente == idagente });
                        self.refrescarSolicitudesAgentesEditar();
                    }
                });

            });

            v.FechaDeInicio.change(function (e) {

                if (v.FechaDeFin.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    if (fin < inicio) {
                        app.crearNotificacionError("Error", "La fecha de finalización de la solicitud debe ser posterior a la de inicio");
                        v.FechaDeInicio.val("");
                        v.FechaDeFin.val("");
                        v.FechaDeInicio.focus();
                    } else {

                        var hora_inicio = inicio.hour();
                        var minutos_inicio = inicio.minute();

                        var hora_fin = fin.hour();
                        var minutos_fin = fin.minute();

                        //console.log(hora_inicio);
                        //console.log(minutos_inicio);

                        var horas = fin.diff(inicio, 'hours');
                        var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                        var dias = fin.diff(inicio, 'days');

                        console.log(dias_2);

                        //inicia y termina el mismo día
                        if (dias_2 == 1) {
                            if (hora_inicio <= 12) {
                                if (hora_fin >= 20) {
                                    dias = 1;
                                } else {
                                    dias = 0.5;
                                }
                            } else {
                                dias = 1;
                            }
                        }

                        //MAS de un dia
                        if (dias_2 > 1) {

                            if (hora_inicio <= 12) {
                                dias = 1;
                            } else {
                                dias = 0.5;
                            }

                            if (hora_fin > 12 && hora_fin < 20) {
                                dias += 0.5;
                            }

                            if (hora_fin >= 20) {
                                dias += 1;
                            }

                            dias += (dias_2 - 2)

                        }
                     
                        //var dias = 0;
                        var importe_dia = 0;
                        var subtotal = 0;
                        var total = 0;

                        var lapampa = false;
                        var veinticinco_de_mayo = false;

                        var destino = v.Destino.txt.val();
                        if (destino.indexOf("La Pampa") >= 0)
                            lapampa = true;

                        if (destino.indexOf("Colonia 25 De") >= 0)
                            veinticinco_de_mayo = true;


                        self.detalle_solicitud.forEach(function (o, i) {

                            //var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                            //var grupo = solicitud.Grupo;

                            //El agente es funcionario
                            if (o.Grupo == 1) {

                                if (dias <= 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                    else
                                        importe_dia = monto_vigente.FuncionarioFueraUnDia;
                                }

                                if (dias > 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                    else
                                        importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                    if (veinticinco_de_mayo)
                                        importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                                }

                            }

                            //No es funcionario
                            if (o.Grupo != 1) {

                                if (dias <= 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                    else
                                        importe_dia = monto_vigente.AgenteFueraUnDia1;
                                }

                                if (dias > 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                    else
                                        importe_dia = monto_vigente.AgenteFueraUnDia1;

                                    if (veinticinco_de_mayo)
                                        importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                                }

                            }

                            o.Dias = dias;
                            o.ImportePorDia = importe_dia;
                            o.Subtotal = dias * importe_dia;

                            self.refrescarSolicitudesAgentesEditar();

                        });

                    }
                }

            });

            v.FechaDeFin.change(function (e) {

                if (v.FechaDeInicio.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    if (fin < inicio) {
                        app.crearNotificacionError("Error", "La fecha de finalización de la solicitud debe ser posterior a la de inicio");
                        v.FechaDeInicio.val("");
                        v.FechaDeFin.val("");
                        v.FechaDeInicio.focus();
                    } else {

                        var hora_inicio = inicio.hour();
                        var minutos_inicio = inicio.minute();

                        var hora_fin = fin.hour();
                        var minutos_fin = fin.minute();

                        //console.log(hora_inicio);
                        //console.log(minutos_inicio);

                        var horas = fin.diff(inicio, 'hours');
                        var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                        var dias = fin.diff(inicio, 'days');

                        console.log(dias_2);

                        //inicia y termina el mismo día
                        if (dias_2 == 1) {
                            if (hora_inicio <= 12) {
                                if (hora_fin >= 20) {
                                    dias = 1;
                                } else {
                                    dias = 0.5;
                                }
                            } else {
                                dias = 1;
                            }
                        }

                        //MAS de un dia
                        if (dias_2 > 1) {

                            if (hora_inicio <= 12) {
                                dias = 1;
                            } else {
                                dias = 0.5;
                            }

                            if (hora_fin > 12 && hora_fin < 20) {
                                dias += 0.5;
                            }

                            if (hora_fin >= 20) {
                                dias += 1;
                            }

                            dias += (dias_2 - 2)

                        }
                     
                        //var dias = 0;
                        var importe_dia = 0;
                        var subtotal = 0;
                        var total = 0;

                        var lapampa = false;
                        var veinticinco_de_mayo = false;

                        var destino = v.Destino.txt.val();
                        if (destino.indexOf("La Pampa") >= 0)
                            lapampa = true;

                        if (destino.indexOf("Colonia 25 De") >= 0)
                            veinticinco_de_mayo = true;


                        self.detalle_solicitud.forEach(function (o, i) {

                            //var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                            //var grupo = solicitud.Grupo;

                            //El agente es funcionario
                            if (o.Grupo == 1) {

                                if (dias <= 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                    else
                                        importe_dia = monto_vigente.FuncionarioFueraUnDia;
                                }

                                if (dias > 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                    else
                                        importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                    if (veinticinco_de_mayo)
                                        importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                                }

                            }

                            //No es funcionario
                            if (o.Grupo != 1) {

                                if (dias <= 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                    else
                                        importe_dia = monto_vigente.AgenteFueraUnDia1;
                                }

                                if (dias > 1) {
                                    if (lapampa)
                                        importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                    else
                                        importe_dia = monto_vigente.AgenteFueraUnDia1;

                                    if (veinticinco_de_mayo)
                                        importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                                }

                            }

                            o.Dias = dias;
                            o.ImportePorDia = importe_dia;
                            o.Subtotal = dias * importe_dia;

                            self.refrescarSolicitudesAgentesEditar();

                        });

                    }
                }

            });

            v.Agente.setCallback(function (ui: any) {
                debugger;

                var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                var hora_inicio = inicio.hour();
                var minutos_inicio = inicio.minute();

                var hora_fin = fin.hour();
                var minutos_fin = fin.minute();

                //console.log(hora_inicio);
                //console.log(minutos_inicio);

                var horas = fin.diff(inicio, 'hours');
                var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                var dias = fin.diff(inicio, 'days');

                console.log(dias_2);

                //inicia y termina el mismo día
                if (dias_2 == 1) {
                    if (hora_inicio <= 12) {
                        if (hora_fin >= 20) {
                            dias = 1;
                        } else {
                            dias = 0.5;
                        }
                    } else {
                        dias = 1;
                    }
                }

                //MAS de un dia
                if (dias_2 > 1) {

                    if (hora_inicio <= 12) {
                        dias = 1;
                    } else {
                        dias = 0.5;
                    }

                    if (hora_fin > 12 && hora_fin < 20) {
                        dias += 0.5;
                    }

                    if (hora_fin >= 20) {
                        dias += 1;
                    }

                    dias += (dias_2 - 2)

                }
                     
                //var dias = 0;
                var importe_dia = 0;
                var subtotal = 0;
                var total = 0;

                var lapampa = false;
                var veinticinco_de_mayo = false;

                var destino = v.Destino.txt.val();
                if (v.Destino.txt.val().indexOf("La Pampa") >= 0)
                    lapampa = true;

                if (v.Destino.txt.val().indexOf("Colonia 25 De") >= 0)
                    veinticinco_de_mayo = true;

                                    
                //El agente es funcionario
                if (ui.item.cargo.Grupo == 1) {

                    if (dias <= 1) {
                        if (lapampa)
                            importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                        else
                            importe_dia = monto_vigente.FuncionarioFueraUnDia;
                    }
                        
                    //if (dias == 1) {
                    //    if (lapampa)
                    //        importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                    //    else
                    //        importe_dia = monto_vigente.FuncionarioFueraUnDia;
                    //}
                    
                    if (dias > 1) {
                        if (lapampa)
                            importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                        else
                            importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                        if (veinticinco_de_mayo)
                            importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                    }

                }

                //No es funcionario
                if (ui.item.cargo.Grupo != 1) {

                    if (dias <= 1) {
                        if (lapampa)
                            importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                        else
                            importe_dia = monto_vigente.AgenteFueraUnDia1;
                    }

                    if (dias > 1) {
                        if (lapampa)
                            importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                        else
                            importe_dia = monto_vigente.AgenteFueraUnDia1;

                        if (veinticinco_de_mayo)
                            importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                    }

                }

                var d = new model.SolicitudesDeViaticosAgentes();

                d.Agente = ui.item.id;
                d.Dias = dias;
                d.ImportePorDia = importe_dia;
                d.ImporteGastos = 0;
                d.ImporteTotal = parseFloat((importe_dia * dias).toFixed(2));
                d.Subtotal = parseFloat((importe_dia * dias).toFixed(2));
                d.AgenteDescripcion = ui.item.label;
                d.CargoDescripcion = ui.item.cargo.Descripcion;
                d.Grupo = ui.item.cargo.Grupo;
                d.Afiliado = ui.item.afiliado;


                self.detalle_solicitud.push(d);

                self.refrescarSolicitudesAgentesEditar();
            });


            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
            }); 


            v.Guardar.click(function (e) {
                var resultado = new Resultado();

                if (v.MedioDeTransporte.val() == 2) {

                    var fecha = new moment($(this).val(), 'DD/MM/YYYY');
                    var inicio = new moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");

                    if (fecha.toDate() < inicio.toDate()) {
                        app.crearNotificacionError("Error", "El seguro no tendrá vigencia al inicio de la Solicitud");
                        return;
                    }
                }

                if (global.appexterna) {
                    bootbox.prompt({
                        title: "Por favor ingrese su clave de acceso",
                        inputType: 'password',
                        callback: function (result) {
                            $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                if (data) {
                                    self.ajaxPostEditarJson(self.ViewEditar, "Resultado", resultado, 1).done(function () {
                                        if (resultado.estado) {
                                            //app.hub.server.enviarNotificacionPorOrganismo("Nueva comisión","Hay una una solicitud de viático para asignar Chofer y/o Vehículo", global.id_servicios_generales);
                                            v.GuardarYNuevo.hide();
                                            //self.ViewTodos
                                            //self.ViewIndex.SolicitudesDeViaticos.fnDraw();
                                            //v.ImprimirSolicitud.show();
                                            app.reloadCurrentTab();
                                            if (self.ViewIndex)
                                                self.ViewIndex.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexBorrador)
                                                self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexPendientes)
                                                self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexPorRendir)
                                                self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();
                                            if (self.ViewTodosAnticipo)
                                                self.ViewTodosAnticipo.Anticipos.fnDraw();
                                            if (self.ViewTodosReintegro)
                                                self.ViewTodosReintegro.SolicitudesDeViaticos.fnDraw();

                                            //v.Id.val(resultado.id.toString());

                                            //if (estado == 12) {
                                            //self.GenerarSolicitudDeViatico(resultado.id, v);
                                            //}
                                            //app.reloadCurrentTab();
                                            app.closeCurrentTab();
                                            app.irATab(0);
                                        }
                                    });
                                } else {
                                    app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                }
                            });
                        }
                    });
                } else {
                    if (v.MotivoDeComision.val() == "") {
                        app.crearNotificacionWarning("Atención...", "Por favor ingrese un motivo de viático");
                        v.MotivoDeComision.focus();
                    } else {
                        self.ajaxPostEditarJson(self.ViewEditar, "Resultado", resultado, 1).done(function () {
                            if (resultado.estado) {
                                //app.hub.server.enviarNotificacionPorOrganismo("Nueva comisión","Hay una una solicitud de viático para asignar Chofer y/o Vehículo", global.id_servicios_generales);
                                v.GuardarYNuevo.hide();
                                if (self.ViewIndex)
                                    self.ViewIndex.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexBorrador)
                                    self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexPendientes)
                                    self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexPorRendir)
                                    self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();

                                v.ImprimirSolicitud.show();
                                //v.Id.val(resultado.id.toString());
                                //if (estado == 12) {
                                self.GenerarSolicitudDeViatico(v.Id.val(), v);
                                //}
                                //app.reloadCurrentTab();
                                app.closeCurrentTab();
                                app.irATab(0);
                            }

                        });
                    }

                }
            });

            //v.Guardar.click(function (e) {
            //    var resultado = new Resultado();
            //    self.ajaxPostEditarJson(self.ViewEditar, "Resultado", resultado, 1).done(function () {
            //        if (self.ViewIndexBorrador)
            //            self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();
            //        if (self.ViewIndexPendientes)
            //            self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();
            //        if (self.ViewIndexPorRendir)
            //            self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();
            //        app.closeCurrentTab();
            //        app.irATab(0);
            //    });
            //});

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado();
                var estado = 2;

                if (global.appexterna) {
                    bootbox.prompt({
                        title: "Por favor ingrese su clave de acceso",
                        inputType: 'password',
                        callback: function (result) {
                            $.post("/account/validarusuarioexterno", { password: result }, function (data) {
                                if (data) {
                                    //está marcada la opción con chofer o medio de transporte es Auto Poder Judicial y no está asignado
                                    if (global.Organismo != global.id_servicios_generales && (v.ConChofer.is(":checked") || (v.MedioDeTransporte.val() == 1 && v.AutoOficial.val() == 0))) {
                                        console.log("Marcar como pendiente de asignar chofer y vehículo");
                                        estado = 12;
                                    }

                                    self.ajaxPostEditarJson(self.ViewEditar, "Resultado", resultado, estado).done(function () {
                                        if (resultado.estado) {
                                            app.hub.server.enviarNotificacionPorOrganismo("Nueva comisión", "Hay una una solicitud de viático para asignar Chofer y/o Vehículo", global.id_servicios_generales);
                                            v.GuardarYNuevo.hide();

                                            if (self.ViewIndex)
                                                self.ViewIndex.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexBorrador)
                                                self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexPendientes)
                                                self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();

                                            if (self.ViewIndexPorRendir)
                                                self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();

                                            //self.ViewIndex.SolicitudesDeViaticos.fnDraw();
                                            v.ImprimirSolicitud.show();
                                            //v.Id.val(resultado.id.toString());
                                            //if (estado == 12) {
                                            self.GenerarSolicitudDeViatico(v.Id.val(), v);
                                            //}
                                            //app.reloadCurrentTab();
                                            app.closeCurrentTab();
                                            app.irATab(1);
                                        }

                                    });
                                } else {
                                    app.crearNotificacionError("Error", "Su usuario no ha podido ser validado");
                                }
                            });
                        }
                    });
                } else {

                    if (v.MotivoDeComision.val() == "") {
                        app.crearNotificacionWarning("Atención...", "Por favor ingrese un motivo de viático");
                        v.MotivoDeComision.focus();
                    } else {

                        if (global.Organismo != global.id_servicios_generales && (v.ConChofer.is(":checked") || (v.MedioDeTransporte.val() == 1 && v.AutoOficial.val() == 0))) {
                            console.log("Marcar como pendiente de asignar chofer y vehículo");
                            estado = 12;
                        }

                        self.ajaxPostEditarJson(self.ViewEditar, "Resultado", resultado, estado).done(function () {
                            if (resultado.estado) {
                                //app.hub.server.enviarNotificacionPorOrganismo("Nueva comisión","Hay una una solicitud de viático para asignar Chofer y/o Vehículo", global.id_servicios_generales);
                                v.GuardarYNuevo.hide();

                                if (self.ViewIndex)
                                    self.ViewIndex.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexBorrador)
                                    self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexPendientes)
                                    self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();

                                if (self.ViewIndexPorRendir)
                                    self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();

                                v.ImprimirSolicitud.show();
                                //v.Id.val(resultado.id.toString());
                                //if (estado == 12) {
                                self.GenerarSolicitudDeViatico(v.Id.val(), v);
                                //}
                                //app.reloadCurrentTab();
                                app.closeCurrentTab();
                                app.irATab(1);
                            }

                        });
                    }

                }
            });


            //v.GuardarYNuevo.click(function (e) {
            //    var resultado = new Resultado();
            //    console.log("Evento Botón Confirma Solicitud");

            //    var estado = 2;

            //    if (v.ConChofer.is(":checked"))
            //        estado = 12; 

            //    self.ajaxPostEditarJson(self.ViewEditar, "Resultado", resultado, estado).done(function () {
            //        if (self.ViewIndexBorrador)
            //            self.ViewIndexBorrador.SolicitudesDeViaticos.fnDraw();
            //        if (self.ViewIndexPendientes)
            //            self.ViewIndexPendientes.SolicitudesDeViaticos.fnDraw();
            //        if (self.ViewIndexPorRendir)
            //            self.ViewIndexPorRendir.SolicitudesDeViaticos.fnDraw();
            //        app.closeCurrentTab();
            //        app.irATab(1);
            //    });
            //});

        }


        public setAsignarChofer(v: Crear) {
            var self = this;
            this.ViewEditar = v;

            v.GuardarYNuevo.show();

            self.detalle_solicitud = [];
            //app.getData("Expedientes/SolicitudesDeViaticos/GetAgentes/" + v.Id.val(), null).done(function (data) {

            //    self.detalle_solicitud = data;
            //    self.refrescarSolicitudesAgentesEditar();

            //});

            var monto_vigente: model.MontosDeViaticos;

            app.getData("Expedientes/MontosDeViaticos/GetVigente").done(function (data) {
                monto_vigente = data;
            });

            v.Estado.change(function (e) {

                var descripcion = v.Estado.find("option:selected").text();
                var valor = $(this).val();

                bootbox.confirm("Atención, va a modificar el estado del trámite a " + descripcion, function (result) {
                    if (result) {
                        app.Bloquear();
                        $.when($.ajax({
                            type: "POST",
                            url: "Expedientes/SolicitudesDeViaticos/ActualizarEstado",
                            data: { estado: valor, solicitud: v.Id.val() },
                            success: function (data) {
                                if (data[0]) {
                                    app.crearNotificacionSuccess("Operación satisfactoria", data[1]);
                                    self.ViewIndex.SolicitudesDeViaticos.fnDraw();
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
                        }));
                    }
                });


            });

            $("input[data-tipo=gastos]").die("change");
            $("input[data-tipo=gastos]").live("change", function (data) {
                var agente = $(this).data("agente");
                Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == agente }).First().ImporteGastos = parseFloat($(this).val());
                self.refrescarSolicitudesAgentesEditar();
            });

            v.FechaDeInicio.change(function (e) {

                if (v.FechaDeFin.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    var hora_inicio = inicio.hour();
                    var minutos_inicio = inicio.minute();

                    var hora_fin = fin.hour();
                    var minutos_fin = fin.minute();

                    //console.log(hora_inicio);
                    //console.log(minutos_inicio);

                    var horas = fin.diff(inicio, 'hours');
                    var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                    var dias = fin.diff(inicio, 'days');

                    console.log(dias_2);

                    //inicia y termina el mismo día
                    if (dias_2 == 1) {
                        if (hora_inicio <= 12) {
                            if (hora_fin >= 20) {
                                dias = 1;
                            } else {
                                dias = 0.5;
                            }
                        } else {
                            dias = 1;
                        }
                    }

                    //MAS de un dia
                    if (dias_2 > 1) {

                        if (hora_inicio <= 12) {
                            dias = 1;
                        } else {
                            dias = 0.5;
                        }

                        if (hora_fin > 12 && hora_fin < 20) {
                            dias += 0.5;
                        }

                        if (hora_fin >= 20) {
                            dias += 1;
                        }

                        dias += (dias_2 - 2)

                    }
                     
                    //var dias = 0;
                    var importe_dia = 0;
                    var subtotal = 0;
                    var total = 0;

                    var lapampa = false;
                    var veinticinco_de_mayo = false;

                    var destino = v.Destino.txt.val();
                    if (destino.indexOf("La Pampa") >= 0)
                        lapampa = true;

                    if (destino.indexOf("Colonia 25 De") >= 0)
                        veinticinco_de_mayo = true;


                    self.detalle_solicitud.forEach(function (o, i) {

                        //var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                        //var grupo = solicitud.Grupo;

                        //El agente es funcionario
                        if (o.Grupo == 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                            }

                        }

                        //No es funcionario
                        if (o.Grupo != 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                            }

                        }

                        o.Dias = dias;
                        o.ImportePorDia = importe_dia;
                        o.Subtotal = dias * importe_dia;

                        self.refrescarSolicitudesAgentesEditar();

                    });

                }

            });

            v.FechaDeFin.change(function (e) {

                if (v.FechaDeInicio.val() != "") {
                    var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                    var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");

                    var hora_inicio = inicio.hour();
                    var minutos_inicio = inicio.minute();

                    var hora_fin = fin.hour();
                    var minutos_fin = fin.minute();

                    //console.log(hora_inicio);
                    //console.log(minutos_inicio);

                    var horas = fin.diff(inicio, 'hours');
                    var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                    var dias = fin.diff(inicio, 'days');

                    console.log(dias_2);

                    //inicia y termina el mismo día
                    if (dias_2 == 1) {
                        if (hora_inicio <= 12) {
                            if (hora_fin >= 20) {
                                dias = 1;
                            } else {
                                dias = 0.5;
                            }
                        } else {
                            dias = 1;
                        }
                    }

                    //MAS de un dia
                    if (dias_2 > 1) {

                        if (hora_inicio <= 12) {
                            dias = 1;
                        } else {
                            dias = 0.5;
                        }

                        if (hora_fin > 12 && hora_fin < 20) {
                            dias += 0.5;
                        }

                        if (hora_fin >= 20) {
                            dias += 1;
                        }

                        dias += (dias_2 - 2)

                    }
                     
                    //var dias = 0;
                    var importe_dia = 0;
                    var subtotal = 0;
                    var total = 0;

                    var lapampa = false;
                    var veinticinco_de_mayo = false;

                    var destino = v.Destino.txt.val();
                    if (destino.indexOf("La Pampa") >= 0)
                        lapampa = true;

                    if (destino.indexOf("Colonia 25 De") >= 0)
                        veinticinco_de_mayo = true;


                    self.detalle_solicitud.forEach(function (o, i) {

                        //var solicitud = Enumerable.From(self.detalle_solicitud).Where(function (x) { return x.Agente == o.Agente }).First();
                        //var grupo = solicitud.Grupo;

                        //El agente es funcionario
                        if (o.Grupo == 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraUnDia;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                                else
                                    importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                            }

                        }

                        //No es funcionario
                        if (o.Grupo != 1) {

                            if (dias <= 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;
                            }

                            if (dias > 1) {
                                if (lapampa)
                                    importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                                else
                                    importe_dia = monto_vigente.AgenteFueraUnDia1;

                                if (veinticinco_de_mayo)
                                    importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                            }

                        }

                        o.Dias = dias;
                        o.ImportePorDia = importe_dia;
                        o.Subtotal = dias * importe_dia;

                        self.refrescarSolicitudesAgentesEditar();

                    });

                }

            });

            v.Agente.setCallback(function (ui: any) {

                var inicio = moment(v.FechaDeInicio.val(), "YYYY-MM-DD HH:mm");
                var fin = moment(v.FechaDeFin.val(), "YYYY-MM-DD HH:mm");


                var hora_inicio = inicio.hour();
                var minutos_inicio = inicio.minute();

                var hora_fin = fin.hour();
                var minutos_fin = fin.minute();

                //console.log(hora_inicio);
                //console.log(minutos_inicio);

                var horas = fin.diff(inicio, 'hours');
                var dias_2 = fin.startOf('day').diff(inicio.startOf('day'), 'days') + 1;
                var dias = fin.diff(inicio, 'days');

                console.log(dias_2);

                //inicia y termina el mismo día
                if (dias_2 == 1) {
                    if (hora_inicio <= 12) {
                        if (hora_fin >= 20) {
                            dias = 1;
                        } else {
                            dias = 0.5;
                        }
                    } else {
                        dias = 1;
                    }
                }

                //MAS de un dia
                if (dias_2 > 1) {

                    if (hora_inicio <= 12) {
                        dias = 1;
                    } else {
                        dias = 0.5;
                    }

                    if (hora_fin > 12 && hora_fin < 20) {
                        dias += 0.5;
                    }

                    if (hora_fin >= 20) {
                        dias += 1;
                    }

                    dias += (dias_2 - 2)

                }
                     
                //var dias = 0;
                var importe_dia = 0;
                var subtotal = 0;
                var total = 0;

                var lapampa = false;
                var veinticinco_de_mayo = false;

                var destino = v.Destino.txt.val();
                if (v.Destino.txt.val().indexOf("La Pampa") >= 0)
                    lapampa = true;

                if (v.Destino.txt.val().indexOf("Colonia 25 De") >= 0)
                    veinticinco_de_mayo = true;

                                    
                //El agente es funcionario
                if (ui.item.cargo.Grupo == 1) {

                    if (dias <= 1) {
                        if (lapampa)
                            importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                        else
                            importe_dia = monto_vigente.FuncionarioFueraUnDia;
                    }
                        
                    //if (dias == 1) {
                    //    if (lapampa)
                    //        importe_dia = monto_vigente.FuncionarioProvinciaUnDia;
                    //    else
                    //        importe_dia = monto_vigente.FuncionarioFueraUnDia;
                    //}
                    
                    if (dias > 1) {
                        if (lapampa)
                            importe_dia = monto_vigente.FuncionarioProvinciaMasUnDia;
                        else
                            importe_dia = monto_vigente.FuncionarioFueraMasUnDia;

                        if (veinticinco_de_mayo)
                            importe_dia = monto_vigente.FuncionarioProvincia25Mayo;
                    }

                }

                //No es funcionario
                if (ui.item.cargo.Grupo != 1) {

                    if (dias <= 1) {
                        if (lapampa)
                            importe_dia = monto_vigente.AgenteProvinciaUnDia1;
                        else
                            importe_dia = monto_vigente.AgenteFueraUnDia1;
                    }

                    if (dias > 1) {
                        if (lapampa)
                            importe_dia = monto_vigente.AgenteProvinciaMasUnDia1;
                        else
                            importe_dia = monto_vigente.AgenteFueraUnDia1;

                        if (veinticinco_de_mayo)
                            importe_dia = monto_vigente.AgenteProvincia25Mayo1;
                    }

                }

                var d = new model.SolicitudesDeViaticosAgentes();

                d.Agente = ui.item.id;
                d.Dias = dias;
                d.ImportePorDia = importe_dia;
                d.ImporteGastos = 0;
                d.ImporteTotal = parseFloat((importe_dia * dias).toFixed(2));
                d.Subtotal = parseFloat((importe_dia * dias).toFixed(2));
                d.AgenteDescripcion = ui.item.label;
                d.CargoDescripcion = ui.item.cargo.Descripcion;
                d.Grupo = ui.item.cargo.Grupo;
                d.Afiliado = ui.item.afiliado;


                self.detalle_solicitud.push(d);

                self.refrescarSolicitudesAgentesEditar();

            });


            v.Cancelar.click(function (e) {
                app.closeCurrentTab();
            });

            v.ImprimirSolicitud.click(function (e) {
                e.preventDefault();
                self.GenerarSolicitudDeViatico(v.Id.val(), v);
            });

            v.Guardar.click(function (e) {
                var resultado = new Resultado();
                self.ajaxPostEditarJson(self.ViewEditar, "Resultado", resultado, 1).done(function () {
                    if (resultado.estado) {
                        self.ViewIndex.SolicitudesDeViaticos.fnDraw();
                        v.ImprimirSolicitud.show();
                        v.Id.val(resultado.id.toString());
                        self.GenerarSolicitudDeViatico(resultado.id, v); 
                        //app.closeCurrentTab();
                        //app.irATab(0);
                    }
                });
            });

            v.GuardarYNuevo.click(function (e) {
                var resultado = new Resultado();
                self.ajaxPostAsignarChoferJson(self.ViewEditar, "Resultado", resultado, 2).done(function () {
                    if (resultado.estado) {
                        v.GuardarYNuevo.hide();
                        self.ViewComisionesPendientesChofer.Comisiones.fnDraw();
                        self.GenerarSolicitudDeViatico(resultado.id, v);
                    }
                });
            });

        }

        public ajaxPost(v: IControlador, titulo: string, resultado: Resultado): JQueryDeferred {
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
                })).done(function () { df.resolve() })
                    .fail(function () { df.reject() }); //end ajax
            }
            return (df.promise());
        }

        public ajaxPostCrearJson(v: IControlador, titulo: string, resultado: Resultado, estado_de_solicitud:number): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            v.form.validate();
            var success = false;
            var retorno: number = 0;

            var vista = that.ViewCrear;

            if (vista.MedioDeTransporte.val() != 2) {
                vista.TipoVehiculo.val("");
                vista.Patente.val("");
                vista.Seguro.val("");
                vista.VigenciaSeguro.val("");
            }

            var solicitud = {                
                OrganismoSolicitante: that.ViewCrear.OrganismoSolicitante.val(),
                Destino: vista.Destino.hidden.val(),
                FechaDeInicio: vista.FechaDeInicio.val(),
                FechaDeFin: vista.FechaDeFin.val(),
                MedioDeTransporte: vista.MedioDeTransporte.val(),
                Estado: estado_de_solicitud,
                MotivoDeComision: vista.MotivoDeComision.val(),
                Fecha: vista.Fecha.val(),
                ConChofer: vista.ConChofer.is(":checked"),
                AutoOficial: vista.AutoOficial.val(),
                SolicitudesDeViaticosAgentes: that.detalle_solicitud,
                Seguro: vista.Seguro.val(),
                VigenciaSeguro: vista.VigenciaSeguro.val(),
                TipoVehiculo: vista.TipoVehiculo.val(),
                Patente: vista.Patente.val(),
                Comision: vista.Comision.val(),
                SolicitaAnticipo: vista.Anticipo.is(":checked")
            };

            if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "expedientes/solicitudesdeviaticos/crear",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({ solicitudesdeviaticos: solicitud }),
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
            }
            return (df.promise());
        }

        public ajaxPostCrearRendicion(v: IControlador, titulo: string, resultado: Resultado, estado_de_solicitud: number): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            v.form.validate();
            var success = false;
            var retorno: number = 0;

            var vista = that.ViewCrearRendicion;

            var rendicion = {
                SolicitudDeViatico: vista.SolicitudDeViatico.val(),                
                FechaDeInicio: vista.FechaDeInicio.val(),
                FechaDeFin: vista.FechaDeFin.val(),
                TotalBienesDeConsumo: parseFloat(vista.spBienesDeConsumo.html()),
                Estado: estado_de_solicitud,
                TotalServiciosNoPersonales: parseFloat(vista.spServiciosNoPersonales.val()),
                TotalOtros:0,
                SolicitudesDeViaticosRendicionesAgentes: that.detalle_rendicion
            };

            if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "expedientes/solicitudesdeviaticos/crearrendicion",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({ rendicion: rendicion, estado:estado_de_solicitud, detalle_gastos: that.detalle_conceptos}),
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
            }
            return (df.promise());
        }

        public ajaxPostEditarRendicion(v: IControlador, titulo: string, resultado: Resultado, estado_de_solicitud: number): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            v.form.validate();
            var success = false;
            var retorno: number = 0;

            var vista = that.ViewEditarRendicion;

            var rendicion = {
                Id: vista.Id.val(),
                SolicitudDeViatico: vista.SolicitudDeViatico.val(),
                FechaDeInicio: vista.FechaDeInicio.val(),
                FechaDeFin: vista.FechaDeFin.val(),
                TotalBienesDeConsumo: parseFloat(vista.spBienesDeConsumo.html()),
                Estado: estado_de_solicitud,
                TotalServiciosNoPersonales: parseFloat(vista.spServiciosNoPersonales.val()),
                TotalOtros: 0,                
                FechaDeAlta: vista.FechaAlta.val(),
                UsuarioAlta: vista.UsuarioAlta.val()
            };            

            if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "expedientes/solicitudesdeviaticos/editarrendicion",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({ rendicion: rendicion, detalle: that.detalle_rendicion, estado: estado_de_solicitud, detalle_gastos: that.detalle_conceptos }),
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
            }
            return (df.promise());
        }

        public ajaxPostEditarJson(v: IControlador, titulo: string, resultado: Resultado, estado_de_solicitud: number): JQueryDeferred {
            console.log("Post Editar Anticipo");
            var that = this;
            var df = $.Deferred();
            v.form.validate();
            var success = false;
            var retorno: number = 0;

            var vista = that.ViewEditar;

            if (vista.MedioDeTransporte.val() != 2) {
                vista.TipoVehiculo.val("");
                vista.Patente.val("");
                vista.Seguro.val("");
                vista.VigenciaSeguro.val("");
            }
                
            var solicitud = {
                Id: vista.Id.val(),
                OrganismoSolicitante: vista.OrganismoSolicitante.val(),
                Destino: vista.Destino.hidden.val(),
                FechaDeInicio: vista.FechaDeInicio.val(),
                FechaDeFin: vista.FechaDeFin.val(),
                MedioDeTransporte: vista.MedioDeTransporte.val(),
                Estado: estado_de_solicitud,
                MotivoDeComision: vista.MotivoDeComision.val(),
                Fecha: vista.Fecha.val(),
                ConChofer: vista.ConChofer.is(":checked"),
                AutoOficial: (vista.AutoOficial.val() > 0 ? vista.AutoOficial.val() : null),
                FechaAlta: vista.FechaAlta.val(),
                UsuarioAlta: vista.UsuarioAlta.val(),
                Seguro: vista.Seguro.val(),
                VigenciaSeguro: vista.VigenciaSeguro.val(),
                TipoVehiculo: vista.TipoVehiculo.val(),
                Patente: vista.Patente.val(),
                SolicitaAnticipo: vista.Anticipo.is(":checked"),
                Comision: vista.Comision.val(),               
            };

            if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "expedientes/solicitudesdeviaticos/editar",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({ solicitudesdeviaticos: solicitud, detalle: that.detalle_solicitud }),
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
            }
            return (df.promise());
        }

        public ajaxPostAsignarChoferJson(v: IControlador, titulo: string, resultado: Resultado, estado_de_solicitud: number): JQueryDeferred {
            var that = this;
            var df = $.Deferred();
            v.form.validate();
            var success = false;
            var retorno: number = 0;

            var vista = that.ViewEditar;

            if (vista.MedioDeTransporte.val() != 2) {
                vista.TipoVehiculo.val("");
                vista.Patente.val("");
                vista.Seguro.val("");
                vista.VigenciaSeguro.val("");
            }

            var solicitud = {
                Id: vista.Id.val(),
                OrganismoSolicitante: vista.OrganismoSolicitante.val(),
                Destino: vista.Destino.hidden.val(),
                FechaDeInicio: vista.FechaDeInicio.val(),
                FechaDeFin: vista.FechaDeFin.val(),
                MedioDeTransporte: vista.MedioDeTransporte.val(),
                Estado: estado_de_solicitud,
                MotivoDeComision: vista.MotivoDeComision.val(),
                Fecha: vista.Fecha.val(),
                ConChofer: vista.ConChofer.is(":checked"),
                AutoOficial: (vista.AutoOficial.val() > 0 ? vista.AutoOficial.val() : null),
                //SolicitudesDeViaticosAgentes: that.detalle_solicitud,
                FechaAlta: vista.FechaAlta.val(),
                UsuarioAlta: vista.UsuarioAlta.val(),
                Seguro: vista.Seguro.val(),
                VigenciaSeguro: vista.VigenciaSeguro.val(),
                TipoVehiculo: vista.TipoVehiculo.val(),
                Patente: vista.Patente.val(),
                Comision: vista.Comision.val(),
                SolicitaAnticipo: vista.Anticipo.is(":checked")                
            };

            if (v.form.valid()) {
                app.Bloquear();
                $.when($.ajax({
                    type: "POST",
                    url: "expedientes/solicitudesdeviaticos/confirmarchofer",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({ solicitudesdeviaticos: solicitud, detalle: that.detalle_solicitud }),
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
            }
            return (df.promise());
        }


        public GenerarSolicitudDeViatico(id, v: Crear, v2?: IndexPendientes): void {
            var self = this;
            var o: any;
            var html;

            var parsered = v == null ? v2.Parsered : v.parsered;


            // Obtener el modelo de escrito
            $.get("Expedientes/SolicitudesDeViaticos/GetData/" + id, null, function (result) {
                o = result;
                $.get("Expedientes/ModelosEscritoADM/getText/?id=1022", null, function (data) {
                    
                    html = data;
                  
                    //console.log(html);

                    parsered.empty();
                    parsered.append($.parseHTML(html));

                    //console.log($("#parsered").html());

                    if (parsered.find("table[data-tipo=detalle]").length) {

                        var tr = parsered.find("table[data-tipo=detalle]").find("tbody").html();
                        parsered.find("table[data-tipo=detalle]").find("tbody").empty();

                        //Enumerable.From(self.o.expediente.imputaciones).Delete(function (x) { return parseInt(x.id) != parseInt(self.id_imputacion) });
                        var detalle = Enumerable.From(o.Detalle);

                        $.each(o.Detalle, function (index, value) {
                            var tr = "<tr><td>" + value.Nombre + "</td><td>" + value.Afiliado + "</td><td>" + value.Categoria + "</td><td>" + value.Dias + "</td><td>" + value.PesosPorDia + "</td><td>" + value.Viatico + "</td><td>" + value.Gastos + "</td><td>" + value.Total + "</td></tr>";
                            console.log(tr);
                            parsered.find("table[data-tipo=detalle]").find("tbody").append(tr);
                        });

                    }
                   

                    var pattern = /\{{(.*?)\}}/g;
                    var match;
                    var matches = [];
                    while ((match = pattern.exec(parsered.html())) != null) {
                        matches.push(match[1]);
                    }
  
                    matches.forEach(function (value, index) {
                        parsered.html(parsered.html().replace("{{" + value + "}}", app.byString(o, value)));
                        //console.log("{{"+value+"}}");
                        //console.log(value);
                        //console.log(value.replace("{{","").replace("}}",""));
                        //console.log(self.byString(self.o, value));
                    });

                    //$("#parsered").show();

                    //html = $("#parsered").html().toString();
                    //var doc = new jsPDF('p', 'mm', [215, 345]);
                    //var doc = new jsPDF();
                    //doc.fromHTML($("#parsered").html());
                    //doc.save('sample-file.pdf');

                    //console.log("Expediente: " + self.o.id);          
                    // $.post("Expedientes/ActuacionesADM/GuardarAutomatica", {texto:self.html, expediente: self.o.expediente.id, tipo:3, requierecargo:false, descripcion: "Nota de Afectación"}, function(data) {
                    //     if (data[0]) {
                    //         app.crearNotificacionSuccess("Resultado",data[1]);
                    //         app.reloadCurrentTab();
                    //     } else {
                    //         app.crearNotificacionError("Resultado",data[1]);
                    //     }
                    // });

                    // self.print();



                    //tinyMCE.activeEditor.setContent(parsered.html());
                    //tinyMCE.get("TextoSolicitud" + v2.hash).setContent(parsered.html());
                    //tinymce.EditorManager.editors = []; 
                    tinymce.init({
                        mode: "exact",
                        height: 600,
                        theme: 'modern',
                        language: "es",
                        selector: "#TextoSolicitud" + (v == null ? v2.hash : v.hash),
                        valid_elements: '*[*]',
                        valid_children: "+body[style], +style[type]",
                        //elements: "Contenido" + hash,                
                        plugins: [
                            'advlist autolink lists link image charmap print preview hr anchor pagebreak',
                            'searchreplace wordcount visualblocks visualchars code fullscreen',
                            'insertdatetime media nonbreaking save table contextmenu directionality',
                            'emoticons template paste textcolor colorpicker textpattern imagetools',
                            "responsivefilemanager customtemplate propiedades"
                        ],
                        content_css: [
                        //'//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
                            '/Scripts/a4.css'
                        ],
                        toolbar1: "responsivefilemanager insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | variables",
                        toolbar2: 'print preview media | forecolor backcolor emoticons | sizeselect | fontselect  fontsizeselect',
                        external_filemanager_path: "/filemanager/",
                        templates: [
                            { title: 'A4', content: '<body class="document" ><div class="page" contenteditable = "true" ></div></body>' },
                            { title: 'Test template 2', content: 'Test 2' }
                        ],
                        contextmenu: "link image inserttable | cell row column deletetable customtemplate propiedades",
                        //valid_elements: "a[onclick|style],strong/b,div,br,link,img",
                        filemanager_title: "Responsive Filemanager",
                        external_plugins: { "filemanager": "/filemanager/plugin.min.js" },
                        mentions: {
                            source: [
                                { name: 'Valor 1' },
                                { name: 'Valor 2' },
                                { name: 'Valor 3' },
                                { name: 'Valor4 ' }
                            ]
                        },
                        setup: function (editor) {
                            editor.addMenuItem('example', {
                                text: 'Abrir Word',
                                context: 'file',
                                onclick: function () {
                                    app.modal.cargar("prueba", "/expedientes/ModelosEscritoADM/files");
                                }
                            });
                            editor.addMenuItem('paper', {
                                text: 'Papel',
                                context: 'format',
                                menu: [
                                    {
                                        text: 'A4',
                                        onclick: function () {
                                            editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                        }
                                    },
                                    {
                                        text: 'Legal',
                                        onclick: function () {
                                            editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Fecha_Expediente]</a>');
                                        }
                                    }
                                ]
                            });
                            editor.addMenuItem('orientation', {
                                text: 'Orientacion',
                                context: 'format',
                                menu: [
                                    {
                                        text: 'Vertical',
                                        onclick: function () {
                                            //tinymce.dom.DomQuery("link[data-mce-href]").remove();
                                            //editor.dom.loadCSS("/scripts/a4l.css");
                                        }
                                    },
                                    {
                                        text: 'Horizontal',
                                        onclick: function () {
                                            editor.formatter.register('div.page', {
                                                inline: 'div',
                                                styles: { color: '#ff0000' }
                                            });
                                            editor.formatter.apply('div.page');
                                        }
                                    }
                                ]
                            });
                            editor.addButton('variables',
                                {
                                    text: 'Variables',
                                    type: 'menubutton',
                                    icon: false,
                                    menu: [
                                        {
                                            text: 'Expedientes',
                                            menu: [
                                                {
                                                    text: 'N&uacute;mero',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Fecha',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Fecha_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Car&aacute;tula',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Caratula_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Iniciador',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Iniciador_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Imputado',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Imputado_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: "Detalle Imputaci&oacute;n",
                                                    menu: [
                                                        {
                                                            text: 'Partida',
                                                            onclick: function () {
                                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                            }
                                                        },
                                                        {
                                                            text: 'Division',
                                                            onclick: function () {
                                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                            }
                                                        },
                                                        {
                                                            text: 'Importe',
                                                            onclick: function () {
                                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                            }
                                                        },
                                                    ]
                                                },
                                                {
                                                    text: "Detalle Factura",
                                                    menu: [
                                                        {
                                                            text: 'N&uacute;mero',
                                                            onclick: function () {
                                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                            }
                                                        },
                                                        {
                                                            text: 'Proveedor',
                                                            onclick: function () {
                                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                            }
                                                        },
                                                        {
                                                            text: 'Importe',
                                                            onclick: function () {
                                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                            }
                                                        },
                                                    ]
                                                }
                                            ]
                                        },
                                        {
                                            text: 'Agregar Campo',
                                            onclick: function () {
                                                bootbox.prompt("Ingrese el nombre del campo", function (result) {
                                                    editor.insertContent('<a href="#" data-type="text" data-pk="1" data-title="' + result + '">' + result + '</a>');
                                                });
                                            }
                                        }
                                    ]
                                });

                        }
                    });


                    if (v != null) {
                        tinyMCE.get("TextoSolicitud" + v.hash).setContent(parsered.html());
                        v.ModalSolicitud.mostrar();
                    }
                    else {

                        tinyMCE.get("TextoSolicitud" + v2.hash).setContent(parsered.html());
                        v2.ModalSolicitud.mostrar();
                    }

                });
            }); 

           

            //console.log(this.byString(this.o, "expediente.fecha"));

        }
        
        


        public GenerarRendicionDeViatico(id, v:CrearRendicion): void {
            var self = this;
            var o: any;
            var html;

            // Obtener el modelo de escrito
            $.get("Expedientes/SolicitudesDeViaticos/GetDataRendicion/" + id, null, function (result) {
                o = result;
                $.get("Expedientes/ModelosEscritoADM/getText/?id=1023", null, function (data) {

                    html = data;                  
                    //console.log(html);
                    $("#parsered").empty();
                    $("#parsered").append($.parseHTML(html));

                    //console.log($("#parsered").html());

                    if ($("#parsered").find("table[data-tipo=detalle]").length) {

                        var tr = $("#parsered").find("table[data-tipo=detalle]").find("tbody").html();
                        $("#parsered").find("table[data-tipo=detalle]").find("tbody").empty();

                        //Enumerable.From(self.o.expediente.imputaciones).Delete(function (x) { return parseInt(x.id) != parseInt(self.id_imputacion) });
                        var detalle = Enumerable.From(o.Detalle);

                        $.each(o.Detalle, function (index, value) {
                            var tr = "<tr><td>" + value.Afiliado + "</td><td>" + value.Nombre + "</td><td>" + value.Dias + "</td><td>" + value.PesosPorDia + "</td><td>" + value.Viatico + "</td><td>" + value.Gastos + "</td><td>" + value.Total + "</td><td>"+value.Anticipo+"</td><td>"+value.Cobrar+"</td><td>"+value.Devolver+"</td></tr>";
                            console.log(tr);
                            $("#parsered").find("table[data-tipo=detalle]").find("tbody").append(tr);
                        });

                    }


                    var pattern = /\{{(.*?)\}}/g;
                    var match;
                    var matches = [];
                    while ((match = pattern.exec($("#parsered").html())) != null) {
                        matches.push(match[1]);
                    }

                    matches.forEach(function (value, index) {
                        $("#parsered").html($("#parsered").html().replace("{{" + value + "}}", app.byString(o, value)));
                        //console.log("{{"+value+"}}");
                        //console.log(value);
                        //console.log(value.replace("{{","").replace("}}",""));
                        //console.log(self.byString(self.o, value));
                    });

                    //$("#parsered").show();

                    //html = $("#parsered").html().toString();
                    //var doc = new jsPDF('p', 'mm', [215, 345]);
                    //var doc = new jsPDF();
                    //doc.fromHTML($("#parsered").html());
                    //doc.save('sample-file.pdf');

                    //console.log("Expediente: " + self.o.id);          
                    // $.post("Expedientes/ActuacionesADM/GuardarAutomatica", {texto:self.html, expediente: self.o.expediente.id, tipo:3, requierecargo:false, descripcion: "Nota de Afectación"}, function(data) {
                    //     if (data[0]) {
                    //         app.crearNotificacionSuccess("Resultado",data[1]);
                    //         app.reloadCurrentTab();
                    //     } else {
                    //         app.crearNotificacionError("Resultado",data[1]);
                    //     }
                    // });

                    // self.print();



                    tinyMCE.activeEditor.setContent($("#parsered").html());
                    v.ModalSolicitud.mostrar();

                });
            }); 

           

            //console.log(this.byString(this.o, "expediente.fecha"));

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

        public eliminar(url: string, data: any): JQueryDeferred {
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
                                that.ViewIndex.SolicitudesDeViaticos.fnDraw();
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
    } //JS
} // module