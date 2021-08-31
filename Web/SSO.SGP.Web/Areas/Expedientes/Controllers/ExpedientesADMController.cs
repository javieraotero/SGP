using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.EntidadesDeNegocio;
using Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables;
using SSO.SGP.ReglasDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System;
using System.Data;
using Syncrosoft.Framework.Utils.Logs;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Results;
using System.Collections.Generic;

namespace SSO.SGP.Web.Areas.Expedientes.Controllers
{
    public class ExpedientesADMController : Controller
    {
        private ExpedientesadmRN oExpedientesADMRN = new ExpedientesadmRN();
        private CategoriasExpedienteadmRefRN oCategoriasExpedienteADMRefRN = new CategoriasExpedienteadmRefRN();
        private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();
        private TiposExpedienteadmRefRN oTiposExpedienteADMRefRN = new TiposExpedienteadmRefRN();
        private UsuariosRN oUsuariosRN = new UsuariosRN();
        private ParametrosadmRN oParametrosRN = new ParametrosadmRN();
        private AmbitosRN oAmbitosRN = new AmbitosRN();
        private ExpedientesadmAD oExpedientesAD = new ExpedientesadmAD();
        private UnidadesDeOrganizacionRefAD oUnidadDeOrganizacion = new UnidadesDeOrganizacionRefAD();
        private ImputacionesContablesAD oImputacions = new ImputacionesContablesAD();
        private ImputacionesContablesDetalleAD oImputacionDetalle = new ImputacionesContablesDetalleAD();
        private FacturasAD oFacturas = new FacturasAD();
        private EjecucionesPresupuestariasAD oEjecucion = new EjecucionesPresupuestariasAD();
        private ActuacionesadmAD oActuaciones = new ActuacionesadmAD();


        public ActionResult Asignar(int expediente)
        {
            var f = oExpedientesAD.ObtenerPorId(expediente);
            ViewBag.UnidadDeOrganizacion = new SelectList(oUnidadDeOrganizacion.ObtenerTodo().ToList(), "Id", "Nombre");
            ViewBag.Numero = f.Numero;
            //ViewBag.Importe = f.Importe;
            ViewBag.Id = expediente;
            return View();
        }

        public ActionResult Sobreafectar(int expediente)
        {
            var f = oExpedientesAD.ObtenerPorId(expediente);
            ViewBag.UnidadDeOrganizacion = new SelectList(oUnidadDeOrganizacion.ObtenerTodo().ToList(), "Id", "Nombre");
            ViewBag.Numero = f.Numero;
            //ViewBag.Importe = f.Importe;
            ViewBag.Id = expediente;
            return View();
        }

        public ActionResult Desafectar(int expediente)
        {
            var f = oExpedientesAD.ObtenerPorId(expediente);
            ViewBag.UnidadDeOrganizacion = new SelectList(oUnidadDeOrganizacion.ObtenerTodo().ToList(), "Id", "Nombre");
            ViewBag.Numero = f.Numero;
            //ViewBag.Importe = f.Importe;
            ViewBag.Id = expediente;
            return View();
        }

        [HttpPost]
        public ActionResult AnularActuacion(int actuacion)
        {
            try
            {
                var x = this.oActuaciones.ObtenerPorId(actuacion);

                if (x.OficinaOrigen == SessionHelper.OficinaActual)
                {

                    x.Anulado = true;
                    x.FechaAnulado = DateTime.Now;
                    x.UsuarioAnulacion = SessionHelper.IdUsuario.Value;

                    oActuaciones.Actualizar(x);

                    return Json(new object[] { true, String.Format("La actuación ha sido anulada") });
                }
                else
                {
                    return Json(new object[] { false, String.Format("La actuación no puede anularse") });
                }
            }
            catch (Exception e)
            {
                return Json(new object[] { false, String.Format("Ocurrió un error al anular la actuación: " + e.Message) });
            }
        }

        [HttpPost]
        public ActionResult Sobreafectar(ImputacionesContables imputacion, bool compromiso_y_ordenado)
        {
            try
            {
                imputacion.Fecha = DateTime.Now;
                imputacion.UsuarioAlta = SessionHelper.IdUsuario.Value;
                imputacion.Operacion = (int)eOperacionesContables.SobreAfectacion;

                foreach (var d in imputacion.ImputacionesContablesDetalle)
                {
                    d.Fecha = DateTime.Now;
                    d.Usuario = SessionHelper.IdUsuario.Value;
                }

                oImputacions.Guardar(imputacion);

                var compromiso = oExpedientesAD.obtenerImputacionCompromiso(imputacion.ExpedienteAImputar).ToList();
                var ordenado = oExpedientesAD.obtenerImputacionOrdenadoAPagar(imputacion.ExpedienteAImputar).ToList();

                if (compromiso_y_ordenado)
                {                   
                    if (compromiso.Count() > 0)
                    {
                        var c = new ImputacionesContables()
                        {
                            ExpedienteAImputar = imputacion.ExpedienteAImputar,
                            UsuarioAlta = SessionHelper.IdUsuario.Value,
                            Operacion = (int)eOperacionesContables.Compromiso,
                            Fecha = DateTime.Now
                        };
                        //c.ImputacionesContablesDetalle = new List<ImputacionesContablesDetalle>();                        
                        oImputacions.Guardar(c);
                        foreach (var d in imputacion.ImputacionesContablesDetalle)
                        {
                            var cd = new ImputacionesContablesDetalle()
                            {
                                Division = d.Division,
                                Importe = (d.Importe > 0 ? d.Importe * (1) : d.Importe),
                                AnioContable = d.AnioContable,
                                Fecha = DateTime.Now,
                                Usuario = SessionHelper.IdUsuario.Value,
                                Partida = d.Partida,
                                ImputacionContable = c.Id
                            };
                            oImputacionDetalle.Guardar(cd);
                        }
                    }

                    if (ordenado.Count() > 0)
                    {
                        var o = new ImputacionesContables()
                        {
                            ExpedienteAImputar = imputacion.ExpedienteAImputar,
                            UsuarioAlta = SessionHelper.IdUsuario.Value,
                            Operacion = (int)eOperacionesContables.OrdenadoAPagar,
                            Fecha = DateTime.Now
                        };
                        //o.ImputacionesContablesDetalle = new List<ImputacionesContablesDetalle>();                        
                        oImputacions.Guardar(o);
                        foreach (var d in imputacion.ImputacionesContablesDetalle)
                        {
                            var od = new ImputacionesContablesDetalle()
                            {
                                Division = d.Division,
                                Importe = (d.Importe > 0 ? d.Importe * (1) : d.Importe),
                                AnioContable = d.AnioContable,
                                Fecha = DateTime.Now,
                                Usuario = SessionHelper.IdUsuario.Value,
                                Partida = d.Partida,
                                ImputacionContable = o.Id
                            };
                            oImputacionDetalle.Guardar(od);
                            //o.ImputacionesContablesDetalle.Add(od);
                        }
                    }
                    
                }

                foreach (var d in imputacion.ImputacionesContablesDetalle)
                {
                    var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, d.Partida);
                    ejecucion.MontoPreventiva += d.Importe;
                    ejecucion.CreditoDisponible -= d.Importe;

                    if (compromiso_y_ordenado & compromiso.Count() > 0)
                        ejecucion.MontoCompromiso += d.Importe;

                    if (compromiso_y_ordenado & ordenado.Count() > 0)
                        ejecucion.MontoOrdenadoAPagar += d.Importe;

                    oEjecucion.Actualizar(ejecucion);
                }

                return Json(new object[] { true, String.Format("La sobreafectación se realizó con éxito") });
            }
            catch (Exception e)
            {
                Logger.GrabarExcepcion(e, false);
                return Json(new object[] { false, "No se ha podido guardar la imputación" });
            }

        }

        [HttpPost]
        public ActionResult Desafectar(ImputacionesContables imputacion, bool compromiso_y_ordenado)
        {

            try
            {
                imputacion.Fecha = DateTime.Now;
                imputacion.UsuarioAlta = SessionHelper.IdUsuario.Value;
                imputacion.Operacion = (int)eOperacionesContables.Desafectacion;

                foreach (var d in imputacion.ImputacionesContablesDetalle)
                {
                    d.Importe = d.Importe;
                    d.Fecha = DateTime.Now;
                    d.Usuario = SessionHelper.IdUsuario.Value;
                }

                oImputacions.Guardar(imputacion);

                var compromiso = oExpedientesAD.obtenerImputacionCompromiso(imputacion.ExpedienteAImputar).ToList();
                var ordenado = oExpedientesAD.obtenerImputacionOrdenadoAPagar(imputacion.ExpedienteAImputar).ToList();

                if (compromiso_y_ordenado)
                {                    
                    if (compromiso.Count() > 0)
                    {
                        var c = new ImputacionesContables()
                        {
                            ExpedienteAImputar = imputacion.ExpedienteAImputar,
                            UsuarioAlta = SessionHelper.IdUsuario.Value,
                            Operacion = (int)eOperacionesContables.Compromiso,
                            Fecha = DateTime.Now
                        };

                        oImputacions.Guardar(c);

                        foreach (var d in imputacion.ImputacionesContablesDetalle)
                        {
                            var cd = new ImputacionesContablesDetalle()
                            {
                                Division = d.Division,
                                Importe = (d.Importe > 0 ? d.Importe * (1) : d.Importe),
                                AnioContable = d.AnioContable,
                                Fecha = DateTime.Now,
                                Usuario = SessionHelper.IdUsuario.Value,
                                Partida = d.Partida,
                                ImputacionContable = c.Id
                            };
                            oImputacionDetalle.Guardar(cd);
                        }
                    }

                    if (ordenado.Count() > 0)
                    {
                        var o = new ImputacionesContables()
                        {
                            ExpedienteAImputar = imputacion.ExpedienteAImputar,
                            UsuarioAlta = SessionHelper.IdUsuario.Value,
                            Operacion = (int)eOperacionesContables.OrdenadoAPagar,
                            Fecha = DateTime.Now
                        };

                        oImputacions.Guardar(o);

                        foreach (var d in imputacion.ImputacionesContablesDetalle)
                        {
                            var od = new ImputacionesContablesDetalle()
                            {
                                Division = d.Division,
                                Importe = (d.Importe > 0 ? d.Importe * (1) : d.Importe),
                                AnioContable = d.AnioContable,
                                Fecha = DateTime.Now,
                                Usuario = SessionHelper.IdUsuario.Value,
                                Partida = d.Partida,
                                ImputacionContable = o.Id
                            };
                            oImputacionDetalle.Guardar(od);
                        }

                    }

                }

                foreach (var d in imputacion.ImputacionesContablesDetalle)
                {
                    var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, d.Partida);
                    ejecucion.MontoPreventiva -= d.Importe;
                    ejecucion.CreditoDisponible += d.Importe;

                    if (compromiso_y_ordenado & compromiso.Count() > 0)
                        ejecucion.MontoCompromiso -= d.Importe;

                    if (compromiso_y_ordenado & ordenado.Count() > 0)
                        ejecucion.MontoOrdenadoAPagar -= d.Importe;

                    oEjecucion.Actualizar(ejecucion);
                }

                return Json(new object[] { true, String.Format("La desafectación se realizó con éxito") });
            }
            catch (Exception e)
            {
                Logger.GrabarExcepcion(e, false);
                return Json(new object[] { false, "No se ha podido guardar la imputación" });
            }

        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Seleccionar()
        {
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        public ActionResult Archivar()
        {
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        //public ActionResult Seleccionar(List<int> expedientes)
        //{

        //    ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
        //    return View();
        //}

        public ActionResult Archivados()
        {
            return View();
        }

        public ActionResult IndexOperaciones()
        {
            return View();
        }

        public ActionResult IndexSinAsignar()
        {
            return View();
        }

        public ActionResult IndexConCargo()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            var ejecuciones = oEjecucion.ObtenerTodo().Where(e => e.Anio == DateTime.Now.Year && !e.FechaElimina.HasValue).OrderBy(o => o.PartidaPresupuestaria).ToList();

            return View(ejecuciones);
        }

        public ActionResult Detalle(int id)
        {
            ViewBag.Contabilidad = oImputacions.ObtenerPorExpediente(id).ToList();
            var expediente = oExpedientesADMRN.ObtenerPorId(id);

            return View(expediente);
        }

        public DataTablesResult<ExpedientesadmView> getExpedientesADMGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oExpedientesADMRN.ObtenerParaGrilla(), dataTableParam, a => new ExpedientesadmView()
            {
                Id = a.Id,
                Numero = a.Numero,
                Fecha = a.Fecha,
                Caratula = a.Caratula,
            });
        }

        public DataTablesResult<ExpedientesadmView> getExpedientesADMGrillaArchivados(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oExpedientesAD.ObtenerParaGrillaArchivados(), dataTableParam, a => new ExpedientesadmView()
            {
                Id = a.Id,
                Numero = a.Numero,
                Fecha = a.Fecha,
                Caratula = a.Caratula,
            });
        }

        public DataTablesResult<ExpedientesContablesView> getExpedientesContablesGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oExpedientesAD.ObtenerExpedientesContables(), dataTableParam, a => new ExpedientesContablesView()
            {
                Id = a.Id,
                Numero = a.Numero,
                Fecha = a.Fecha,
                Caratula = a.Caratula,
                Facturas = a.Facturas,
                Asignado = a.Asignado,
                Afectado = a.Afectado,
                OrdenadoAPagr = a.OrdenadoAPagr
            });
        }

        public DataTablesResult<ExpedientesContablesView> getExpedientesSinAsinar(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oExpedientesAD.ObtenerExpedientesSinAsignar(), dataTableParam, a => new ExpedientesContablesView()
            {
                Id = a.Id,
                Numero = a.Numero,
                Fecha = a.Fecha,
                Caratula = a.Caratula,
                Facturas = a.Facturas,
                Asignado = a.Asignado,
                Afectado = a.Afectado,
                OrdenadoAPagr = a.OrdenadoAPagr
            });
        }

        public DataTablesResult<ExpedientesContablesView> getExpedientesConCargoPendiente(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oExpedientesAD.ObtenerExpedientesConCargoPendiente(SessionHelper.OficinaActual.Value), dataTableParam, a => new ExpedientesContablesView()
            {
                Id = a.Id,
                Numero = a.Numero,
                Fecha = a.Fecha,
                Caratula = a.Caratula,
                Facturas = a.Facturas,
                Asignado = a.Asignado,
                Afectado = a.Afectado,
                OrdenadoAPagr = a.OrdenadoAPagr
            });
        }

        public ActionResult Crear()
        {
            var tipoexpedientes = oTiposExpedienteADMRefRN.ObtenerTodo().ToList();
            tipoexpedientes.Add(new TiposExpedienteadmRef() { Id = 0, Descripcion = "Seleccione..." });


            ViewBag.TiposExpedienteADMRef = new SelectList(tipoexpedientes, "Id", "Descripcion");
            ViewBag.CategoriasExpedienteADMRef = new SelectList(oCategoriasExpedienteADMRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Ambitos = new SelectList(oAmbitosRN.ObtenerDelFuero(4).ToList(), "Id", "Descripcion");
            //ViewBag.Expediente = this.oParametrosRN.ObtenerPorId(1).UltimoExpediente;

            return View();
        }

        [HttpPost]
        public ActionResult Archivar(int expediente)
        {
            var e = oExpedientesAD.ObtenerPorId(expediente);
            try
            {
                
                e.Archivado = true;
                e.FechaArchivado = DateTime.Now;
                e.UsuarioArchiva = SessionHelper.IdUsuario.Value;

                oExpedientesAD.Actualizar(e);

                return Json(new object[] { true, String.Format("El expediente {0} ha sido archivado", e.Numero) });
            }
            catch (Exception ex) {

                return Json(new object[] { false, String.Format("El expediente {0} no ha podido archivarse", e.Numero)});

            }
        }

        [HttpPost]
        public ActionResult Crear(Expedientesadm expedientesadm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (expedientesadm.OrganismoIniciador == 0)
                        expedientesadm.OrganismoIniciador = null;
                    //Parametrosadm Parametros = oParametrosRN.ObtenerPorId(1);
                    var tipo = oTiposExpedienteADMRefRN.ObtenerPorId(expedientesadm.Tipo);


                    if (!expedientesadm.NumeroDeCorresponde.HasValue)
                    {
                        tipo.UltimoNumero++;
                        expedientesadm.Numero = tipo.UltimoNumero.ToString();
                        oTiposExpedienteADMRefRN.Actualizar(tipo);
                    }

                    expedientesadm.FechaDeAlta = DateTime.Now;
                    expedientesadm.UsuarioAlta = SessionHelper.IdUsuario;
                    expedientesadm.Archivado = false;

                    oExpedientesADMRN.Guardar(expedientesadm);

                    Actuacionesadm a = new Actuacionesadm();
                    a.Anulado = false;
                    a.Descripcion = "Inicio";
                    a.RequiereCargo = true;
                    a.Expediente = expedientesadm.Id;
                    a.Fecha = DateTime.Now;
                    a.FechaAnulado = null;
                    //a.FechaCargo = DateTime.Now;
                    a.OficinaOrigen = SessionHelper.OficinaActual.Value;
                    a.SubAmbitoOrigen = SessionHelper.AmbitoActual;
                    a.OrganismoCargo = expedientesadm.Destino;
                    a.TipoActuacion = 8;
                    //a.RequiereCargo = expedientesadm

                    oActuaciones.Guardar(a);

                    return Json(new object[] { true, String.Format("El expediente ha sido guardado satisfactoriamente"), expedientesadm.Id });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar ExpedientesADM" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar ExpedientesADM" });
            }
        }


        [HttpPost]
        public ActionResult AsignarExpdiente(ImputacionesContables imputacion)
        {

            try
            {
                imputacion.Fecha = DateTime.Now;
                imputacion.UsuarioAlta = SessionHelper.IdUsuario.Value;
                imputacion.Operacion = 1;

                foreach (var d in imputacion.ImputacionesContablesDetalle)
                {
                    d.Fecha = DateTime.Now;
                    d.Usuario = SessionHelper.IdUsuario.Value;
                }

                oImputacions.Guardar(imputacion);

                return Json(new object[] { true, String.Format("El expediente ha sido asignado con éxito") });
            }
            catch (Exception e)
            {
                Logger.GrabarExcepcion(e, false);
                return Json(new object[] { false, "No se ha podido guardar la imputación" });
            }

        }

        //[HttpPost]
        //public ActionResult OrdenadoAPagar(int expediente)
        //{
        //    string mensaje_error = "";
        //    dynamic pendiente;

        //    try
        //    {
        //        var e = oExpedientesAD.ObtenerPorId(expediente);

        //        var saldoafectacion = oImputacions.obtenerSaldoDeOperacion(expediente, 2);
        //        var saldoordenado = oImputacions.obtenerSaldoDeOperacion(expediente, 4);

        //        if (saldoafectacion <= saldoordenado)
        //        {

        //            return Json(new object[] { false, "No hay saldo para efectuar de afectación para efectar la operación" });

        //        }
        //        else {

        //            var afectaciones = oImputacions.obtenerImputaciones(expediente, 2);
        //            var ordenados = oImputacions.obtenerImputaciones(expediente, 4);

        //            var tafectacion = from x in afectaciones
        //                              group x by new { x.Partida, x.Division } into g
        //                              select new
        //                              {
        //                                  partida = g.Key.Partida,
        //                                  division = g.Key.Division,
        //                                  total = g.Sum(_ => _.Importe)
        //                              };

        //            var tordenados = from x in ordenados
        //                             group x by new { x.Partida, x.Division } into g
        //                             select new
        //                             {
        //                                 partida = g.Key.Partida,
        //                                 division = g.Key.Division,
        //                                 total = g.Sum(_ => _.Importe)
        //                             };

        //            foreach (var a in tafectacion) {

        //                var saldo = a.total;

        //                var res = from x in tordenados
        //                          where x.partida == a.partida && x.division == a.division
        //                          select x;




        //            }


        //        }


        //    }
        //    catch (Exception e)
        //    {
        //        Logger.GrabarExcepcion(e, false);
        //        return Json(new object[] { false, "No se ha podido guardar la imputación" });
        //    }

        //}

        [HttpPost]
        public ActionResult AceptarCargo(int expediente, int organismo)
        {
            try
            {
                var a = oActuaciones.ObtenerPorExpedienteYOrganismo(expediente, organismo);
                a.FechaCargo = DateTime.Now;
                a.UsuarioCargo = SessionHelper.IdUsuario.Value;

                oActuaciones.Actualizar(a);

                return Json(new object[] { true, "El cargo ha sido aceptado" });

            }
            catch (Exception e)
            {
                return Json(new object[] { false, "Ocurrió un error al aceptar el cargo. " + e.Message });
            }
        }

        [HttpPost]
        public ActionResult CompromisoYOrdenado(int expediente)
        {
            //compromiso y ordenado de todo lo pendiente

            var afectaciones = oExpedientesAD.obtenerAfectaciones(expediente).ToList();

            afectaciones.ForEach(a => a.Importe = a.Importe * (-1));

            var op = oExpedientesAD.obtenerOrdenadosAPagar(expediente).ToList();

            afectaciones.AddRange(op);

            var res = from x in afectaciones
                      group x by new { x.Partida, x.Division } into g
                      select new
                      {
                          partida = g.Key.Partida,
                          division = g.Key.Division,
                          total = g.Sum(_ => _.Importe)
                      };

            return Json(new object[] { true, String.Format("La oepración se realizó con éxito") });
        }

        [HttpGet]
        public JsonResult FacturasPendientesDeAfectar(int expediente)
        {
            var res = oFacturas.FacturasSinAfectar(expediente).ToList();
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult FacturasPendientesDeOP(int expediente)
        {
            var res = oFacturas.FacturasSinOrdenDePago(expediente).ToList();
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ObtenerPendienteDeOP(int expediente)
        {
            //compromiso y ordenado de todo lo pendiente

            var afectaciones = oExpedientesAD.obtenerAfectaciones(expediente).ToList();
            var op = oExpedientesAD.obtenerOrdenadosAPagar(expediente).ToList();
            op.ForEach(a => a.Importe = a.Importe * (-1));

            afectaciones.AddRange(op);

            var res = from x in afectaciones
                      group x by new { x.Partida, x.Division, x.Descripcion } into g
                      select new
                      {
                          descripcion = g.Key.Descripcion,
                          partida = g.Key.Partida,
                          division = g.Key.Division,
                          total = g.Sum(_ => _.Importe)
                      };

            return this.Json(res, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Afectar(int expediente, List<int> facturas)
        {
            string mensaje_error = "";

            try
            {
                var e = oExpedientesAD.ObtenerPorId(expediente);

                if (e.Facturas.Count() > 0)
                {
                    //existen facturas sin asignar
                    if (e.Facturas.Where(f => !f.EstaAsignada).Count() > 0)
                    {
                        return Json(new object[] { false, String.Format("Hay facturas sin asignar. No se puede realizar la afectación.") });
                    }

                    //existen facturas marcadas como no afectadas
                    if (e.Facturas.Where(f => !f.Afectada).Count() > 0)
                    {
                        try
                        {

                            var asignacion = oFacturas.AsignacionPendiente(e.Id).ToList();
                            var res = from x in asignacion
                                      group x by new { x.Partida, x.Division } into g
                                      select new
                                      {
                                          partida = g.Key.Partida,
                                          division = g.Key.Division,
                                          total = g.Sum(_ => _.Importe)
                                      };

                            //chequear disponibilidad presupuestaria
                            foreach (var r in res)
                            {
                                var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, r.partida);
                                if (ejecucion != null)
                                {
                                    if (ejecucion.CreditoDisponible < r.total)
                                    {
                                        mensaje_error = "La partida " + ejecucion.PartidaPresupuestarias.NumeroDePartida + " no tiene saldo disponible (Saldo actual: $" + ejecucion.CreditoDisponible + ")  ";
                                    }
                                    if (mensaje_error.Length > 0)
                                        return Json(new object[] { false, String.Format(mensaje_error) });
                                }
                                else
                                    return Json(new object[] { false, "No existe ejecución para el año en curso" });
                            }



                            var imputacion = new ImputacionesContables()
                            {
                                ExpedienteAImputar = e.Id,
                                Fecha = DateTime.Now,
                                Operacion = 2,
                                UsuarioAlta = SessionHelper.IdUsuario.Value
                            };

                            oImputacions.Guardar(imputacion);

                            foreach (var d in res)
                            {
                                var imputaciondetalle = new ImputacionesContablesDetalle()
                                {
                                    ImputacionContable = imputacion.Id,
                                    Importe = d.total,
                                    Partida = d.partida,
                                    Division = d.division,
                                    AnioContable = DateTime.Now.Year,
                                    Usuario = SessionHelper.IdUsuario.Value,
                                    Fecha = DateTime.Now
                                };

                                oImputacionDetalle.Guardar(imputaciondetalle);
                            }

                            foreach (var x in facturas)
                            {
                                var f = oFacturas.ObtenerPorId(x);

                                f.Imputacion = imputacion.Id;
                                f.Afectada = true;

                                oFacturas.Actualizar(f);
                            }

                            oExpedientesAD.Actualizar(e);

                            foreach (var r in res)
                            {
                                var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, r.partida);
                                ejecucion.MontoPreventiva += r.total;
                                ejecucion.CreditoDisponible -= r.total;

                                oEjecucion.Actualizar(ejecucion);
                            }

                            return Json(new object[] { true, String.Format("La afectación se realizó con éxito"), imputacion.Id });
                        }
                        catch (Exception ex)
                        {

                            return Json(new object[] { false, String.Format("Ocurrió un error al realizar la afectación") });

                        }
                    }
                    else
                    {
                        return Json(new object[] { false, String.Format("No hay facturas pendientes de afectación") });
                    }
                }
                else
                {
                    //chequear si el expediente esta asignado
                    var asignacion = oExpedientesAD.obtenerAsignacion(expediente).ToList();
                    var res_asignacion = (from x in asignacion
                                          select new CustomImputacionJ
                                          {
                                              Descripcion = x.Partidas.Descripcion,
                                              Partida = x.Partida,
                                              Division = x.Division,
                                              Importe = x.Importe
                                          }).ToList();

                    var afectacion = oExpedientesAD.obtenerAfectaciones(expediente).ToList();
                    afectacion.ForEach(a => a.Importe = a.Importe * (-1));

                    res_asignacion.AddRange(afectacion);

                    var res = (from x in res_asignacion
                               group x by new { x.Partida, x.Division } into g
                               select new
                               {
                                   partida = g.Key.Partida,
                                   division = g.Key.Division,
                                   total = g.Sum(_ => _.Importe)
                               }).ToList();

                    foreach (var r in res)
                    {
                        var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, r.partida);
                        if (ejecucion != null)
                        {
                            if (ejecucion.CreditoDisponible < r.total)
                            {
                                mensaje_error = "La partida " + ejecucion.PartidaPresupuestarias.NumeroDePartida + " no tiene saldo disponible (Saldo actual: $" + ejecucion.CreditoDisponible + ")  ";
                            }
                            if (mensaje_error.Length > 0)
                                return Json(new object[] { false, String.Format(mensaje_error) });
                        }
                        else
                            return Json(new object[] { false, "No existe ejecución para el año en curso" });
                    }

                    if (res.Count() > 0 && res.Sum(x => x.total) > 0)
                    {
                        var imputacion = new ImputacionesContables()
                        {
                            ExpedienteAImputar = e.Id,
                            Fecha = DateTime.Now,
                            Operacion = 2,
                            UsuarioAlta = SessionHelper.IdUsuario.Value
                        };

                        oImputacions.Guardar(imputacion);

                        foreach (var d in res)
                        {
                            var imputaciondetalle = new ImputacionesContablesDetalle()
                            {
                                ImputacionContable = imputacion.Id,
                                Importe = d.total,
                                Partida = d.partida,
                                Division = d.division,
                                AnioContable = DateTime.Now.Year,
                                Usuario = SessionHelper.IdUsuario.Value,
                                Fecha = DateTime.Now
                            };

                            oImputacionDetalle.Guardar(imputaciondetalle);
                        }


                        foreach (var r in res)
                        {
                            var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, r.partida);
                            ejecucion.MontoPreventiva += r.total;
                            ejecucion.CreditoDisponible -= r.total;

                            oEjecucion.Actualizar(ejecucion);
                        }

                        return Json(new object[] { true, String.Format("El expediente ha sido afectado") });

                    }
                    else
                    {
                        return Json(new object[] { false, String.Format("No hay nada por afectar") });
                    }
                }


            }
            catch (Exception e)
            {
                Logger.GrabarExcepcion(e, false);
                return Json(new object[] { false, "No se ha podido guardar la imputación" });
            }

        }

        [HttpPost]
        public ActionResult OrdenadoAPagar(int expediente, List<int> facturas, bool compromiso)
        {
            string mensaje_error = "";

            try
            {
                var e = oExpedientesAD.ObtenerPorId(expediente);

                if (e.Facturas.Where(x => x.Afectada && !x.OrdenadoAPagar).Count() > 0)
                {
                    //existen facturas sin asignar
                    if (e.Facturas.Where(f => !f.EstaAsignada).Count() > 0)
                    {
                        return Json(new object[] { false, String.Format("Hay facturas sin asignar. No se puede realizar la afectación.") });
                    }

                    //existen facturas marcadas como no afectadas
                    if (e.Facturas.Where(f => !f.OrdenadoAPagar && f.Afectada).Count() > 0)
                    {
                        try
                        {
                            var afectaciones = oExpedientesAD.obtenerAfectaciones(expediente).ToList();
                            var op = oExpedientesAD.obtenerOrdenadosAPagar(expediente).ToList();
                            op.ForEach(a => a.Importe = a.Importe * (-1));

                            afectaciones.AddRange(op);

                            var res = from x in afectaciones
                                      group x by new { x.Partida, x.Division, x.Descripcion } into g
                                      select new
                                      {
                                          descripcion = g.Key.Descripcion,
                                          partida = g.Key.Partida,
                                          division = g.Key.Division,
                                          total = g.Sum(_ => _.Importe)
                                      };

                            //chequear disponibilidad presupuestaria
                            //foreach (var r in res)
                            //{
                            //    var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, r.partida);
                            //    if (ejecucion != null)
                            //    {
                            //        if (ejecucion.CreditoDisponible < r.total)
                            //        {
                            //            mensaje_error = "La partida " + ejecucion.PartidaPresupuestarias.NumeroDePartida + " no tiene saldo disponible (Saldo actual: $" + ejecucion.CreditoDisponible + ")  ";
                            //        }
                            //        if (mensaje_error.Length > 0)
                            //            return Json(new object[] { false, String.Format(mensaje_error) });
                            //    }
                            //    else
                            //        return Json(new object[] { false, "No existe ejecución para el año en curso" });
                            //}

                            if (res.Count() > 0 && res.Sum(x => x.total) > 0)
                            {

                                var imputacion = new ImputacionesContables()
                                {
                                    ExpedienteAImputar = e.Id,
                                    Fecha = DateTime.Now,
                                    Operacion = (int)eOperacionesContables.OrdenadoAPagar,
                                    UsuarioAlta = SessionHelper.IdUsuario.Value
                                };

                                var imputacion_compromiso = new ImputacionesContables();

                                if (compromiso)
                                {
                                    imputacion_compromiso = new ImputacionesContables()
                                    {
                                        ExpedienteAImputar = e.Id,
                                        Fecha = DateTime.Now,
                                        Operacion = (int)eOperacionesContables.Compromiso,
                                        UsuarioAlta = SessionHelper.IdUsuario.Value
                                    };
                                    oImputacions.Guardar(imputacion_compromiso);
                                }

                                oImputacions.Guardar(imputacion);

                                foreach (var d in res)
                                {
                                    if (compromiso)
                                    {
                                        var imputaciondetalle_compromiso = new ImputacionesContablesDetalle()
                                        {
                                            ImputacionContable = imputacion_compromiso.Id,
                                            Importe = d.total,
                                            Partida = d.partida,
                                            Division = d.division,
                                            AnioContable = DateTime.Now.Year,
                                            Usuario = SessionHelper.IdUsuario.Value,
                                            Fecha = DateTime.Now
                                        };
                                        if (imputaciondetalle_compromiso.Importe != 0)
                                        {
                                            oImputacionDetalle.Guardar(imputaciondetalle_compromiso);
                                        }
                                    }

                                    var imputaciondetalle = new ImputacionesContablesDetalle()
                                    {
                                        ImputacionContable = imputacion.Id,
                                        Importe = d.total,
                                        Partida = d.partida,
                                        Division = d.division,
                                        AnioContable = DateTime.Now.Year,
                                        Usuario = SessionHelper.IdUsuario.Value,
                                        Fecha = DateTime.Now
                                    };

                                    if (imputaciondetalle.Importe != 0)
                                    {                                       
                                        oImputacionDetalle.Guardar(imputaciondetalle);
                                    }
                                }

                                foreach (var x in facturas)
                                {
                                    var f = oFacturas.ObtenerPorId(x);

                                    f.Imputacion = imputacion.Id;
                                    f.Compromiso = true;
                                    f.OrdenadoAPagar = true;

                                    oFacturas.Actualizar(f);
                                }

                                oExpedientesAD.Actualizar(e);

                                foreach (var r in res)
                                {
                                    var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, r.partida);
                                    ejecucion.MontoOrdenadoAPagar += r.total;
                                    if (compromiso) {
                                        ejecucion.MontoCompromiso += r.total;
                                    }

                                    oEjecucion.Actualizar(ejecucion);
                                }

                                return Json(new object[] { true, String.Format("La orden de pago se realizó con éxito"), imputacion.Id });
                            }
                            else
                            {
                                return Json(new object[] { false, String.Format("No hay nada para Ordenar a Pagar"), 0 });
                            }
                        }
                        catch (Exception ex)
                        {

                            return Json(new object[] { false, String.Format("Ocurrió un error al realizar la orden de pago") });

                        }
                    }
                    else
                    {
                        return Json(new object[] { false, String.Format("No hay facturas pendientes de orden de pago") });
                    }
                }
                else
                {
                    //chequear si el expediente esta asignado
                    //var asignacion = oExpedientesAD.obtenerAsignacion(expediente).ToList();

                    //var res = from x in asignacion
                    //          group x by new { x.Partida, x.Division } into g
                    //          select new
                    //          {
                    //              partida = g.Key.Partida,
                    //              division = g.Key.Division,
                    //              total = g.Sum(_ => _.Importe)
                    //          };

                    var afectaciones = oExpedientesAD.obtenerAfectaciones(expediente).ToList();
                    var op = oExpedientesAD.obtenerOrdenadosAPagar(expediente).ToList();
                    op.ForEach(a => a.Importe = a.Importe * (-1));

                    afectaciones.AddRange(op);

                    var res = from x in afectaciones
                              group x by new { x.Partida, x.Division, x.Descripcion } into g
                              select new
                              {
                                  descripcion = g.Key.Descripcion,
                                  partida = g.Key.Partida,
                                  division = g.Key.Division,
                                  total = g.Sum(_ => _.Importe)
                              };

                    //foreach (var r in res)
                    //{
                    //    var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, r.partida);
                    //    if (ejecucion != null)
                    //    {
                    //        if (ejecucion.CreditoDisponible < r.total)
                    //        {
                    //            mensaje_error = "La partida " + ejecucion.PartidaPresupuestarias.NumeroDePartida + " no tiene saldo disponible (Saldo actual: $" + ejecucion.CreditoDisponible + ")  ";
                    //        }
                    //        if (mensaje_error.Length > 0)
                    //            return Json(new object[] { false, String.Format(mensaje_error) });
                    //    }
                    //    else
                    //        return Json(new object[] { false, "No existe ejecución para el año en curso" });
                    //}

                    if (res.Count() > 0 && res.Sum(x => x.total) > 0)
                    {
                        var imputacion_compromiso = new ImputacionesContables();
                        if (compromiso)
                        {
                            imputacion_compromiso = new ImputacionesContables()
                            {
                                ExpedienteAImputar = e.Id,
                                Fecha = DateTime.Now,
                                Operacion = (int)eOperacionesContables.Compromiso,
                                UsuarioAlta = SessionHelper.IdUsuario.Value
                            };

                            oImputacions.Guardar(imputacion_compromiso);
                        }

                        var imputacion = new ImputacionesContables()
                        {
                            ExpedienteAImputar = e.Id,
                            Fecha = DateTime.Now,
                            Operacion = (int)eOperacionesContables.OrdenadoAPagar,
                            UsuarioAlta = SessionHelper.IdUsuario.Value
                        };

                        oImputacions.Guardar(imputacion);

                        foreach (var d in res)
                        {
                            if (compromiso)
                            {
                                var imputaciondetalle_compromiso = new ImputacionesContablesDetalle()
                                {
                                    ImputacionContable = imputacion_compromiso.Id,
                                    Importe = d.total,
                                    Partida = d.partida,
                                    Division = d.division,
                                    AnioContable = DateTime.Now.Year,
                                    Usuario = SessionHelper.IdUsuario.Value,
                                    Fecha = DateTime.Now
                                };

                                oImputacionDetalle.Guardar(imputaciondetalle_compromiso);
                            }

                            var imputaciondetalle = new ImputacionesContablesDetalle()
                            {
                                ImputacionContable = imputacion.Id,
                                Importe = d.total,
                                Partida = d.partida,
                                Division = d.division,
                                AnioContable = DateTime.Now.Year,
                                Usuario = SessionHelper.IdUsuario.Value,
                                Fecha = DateTime.Now
                            };

                            oImputacionDetalle.Guardar(imputaciondetalle);
                        }

                        foreach (var r in res)
                        {
                            var ejecucion = oEjecucion.ObtenerPorPartidaYAnio(DateTime.Now.Year, r.partida);
                            ejecucion.MontoOrdenadoAPagar += r.total;
                            if (compromiso)
                                ejecucion.MontoCompromiso += r.total;

                            oEjecucion.Actualizar(ejecucion);
                        }

                        return Json(new object[] { true, String.Format("La operación de Ordenado a Pagar se realizó con éxito"), res.Sum(r => r.total) });
                    }
                    else
                    {
                        return Json(new object[] { false, String.Format("No hay nada para ordenar a pagar"), 0 });
                    }
                }
            }
            catch (Exception e)
            {
                Logger.GrabarExcepcion(e, false);
                return Json(new object[] { false, "No se ha podido guardar la imputación" });
            }

        }

        [HttpPost]
        public ActionResult Editar(Expedientesadm expedientesadm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oExpedientesADMRN.Actualizar(expedientesadm);
                    return Json(new object[] { true, String.Format("Se actualizó el expediente satisfactoriamente"), 0 });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse el expediente", 0 });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse ExpedientesADM" });
            }

        }

        public ActionResult Editar(int id = 0)
        {

            var tipoexpedientes = oTiposExpedienteADMRefRN.ObtenerTodo().ToList();
            tipoexpedientes.Add(new TiposExpedienteadmRef() { Id = 0, Descripcion = "Seleccione..." });


            ViewBag.TiposExpedienteADMRef = new SelectList(tipoexpedientes, "Id", "Descripcion");
            ViewBag.CategoriasExpedienteADMRef = new SelectList(oCategoriasExpedienteADMRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Ambitos = new SelectList(oAmbitosRN.ObtenerDelFuero(4).ToList(), "Id", "Descripcion");


            Expedientesadm expedientesadm = oExpedientesADMRN.ObtenerPorId(id);
            if (expedientesadm == null)
            {
                return HttpNotFound();
            }
            return View(expedientesadm);
        }


        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oExpedientesADMRN.Eliminar(id);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el expedientesadm" });
            }
        }

        public JsonResult JsonT(string term)
        {
            var res = from x in this.oExpedientesADMRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Facturas(int expediente)
        {
            var res = (from x in this.oExpedientesAD.ObtenerPorId(expediente).Facturas
                       select new FacturasResult
                       {
                           Id = x.Id,
                           Proveedor = x.Proveedors.RazonSocial,
                           NumeroDeFactura = x.NumeroDeFactura,
                           Fecha = x.Fecha,
                           Importe = x.Importe,
                           EstaAsignada = x.EstaAsignada
                       }).ToList();
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult proximoCorresponde(int expediente)
        {
            var res = oExpedientesADMRN.proximoCorresponde(expediente);
            return this.Json(new { corresponde = res }, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oExpedientesADMRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult Autocomplete(string term)
        {
            var res = from x in this.oExpedientesADMRN.ObtenerOptions(term)
                      select new { label = x.text, id = x.value, text = x.text };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult obtenerAsignacion(int expediente)
        {
            var res = oExpedientesAD.obtenerAsignacion(expediente).ToList();

            var res2 = from x in res
                       select new
                       {
                           Partida = x.Partida,
                           Division = x.Division,
                           Importe = x.Importe,
                           Id = x.Id
                       };

            return this.Json(res2.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetData(int id)
        {
            var res = this.oExpedientesAD.obtenerModeloCliente(id);

            res.hoy = DateTime.Now;
            res.hoy_en_letras = res.hoy.ToLongDateString();

            if (res.imputaciones != null)
            {
                foreach (var i in res.imputaciones)
                {
                    i.total_en_letras = this.ConvertirALetras(i.total.ToString()).ToUpper();
                }
            }

            return this.Json(res, JsonRequestBehavior.AllowGet);
            //return new JsonNetResult
            //{
            //    Data = res,
            //    ContentType = "application/json",
            //    //ContentEncoding  = System.Text.Encoding.UTF8,
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};
        }

        public JsonResult GetData2(int id, int imputacion)
        {
            var res = this.oExpedientesAD.obtenerModeloCliente(id, imputacion);

            res.hoy = DateTime.Now;
            res.hoy_en_letras = res.hoy.ToLongDateString();

            if (res.imputaciones != null)
            {
                foreach (var i in res.imputaciones)
                {
                    i.total_en_letras = new Conversor().enletras(i.total.ToString()).ToUpper(); //this.ConvertirALetras(i.total.ToString()).ToUpper();
                }
            }

            return this.Json(res, JsonRequestBehavior.AllowGet);
            //return new JsonNetResult
            //{
            //    Data = res,
            //    ContentType = "application/json",
            //    //ContentEncoding  = System.Text.Encoding.UTF8,
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};
        }

        public JsonResult obtenerNumero(int tipo, string numero, bool corresponde)
        {
            var tipos = oTiposExpedienteADMRefRN.ObtenerTodo().Where(t => t.Id == tipo).SingleOrDefault();
            var resultado = "";
            var nro_corresponde = "";

            dynamic res = new { numero = "", nro_corresponde = "" };

            if (corresponde)
            {
                //numero = (tipos.UltimoNumero + 1).ToString();
                var expediente = oExpedientesAD.ObtenerPorNumero(numero);
                if (expediente != null)
                {

                    resultado = numero + "-" + (expediente.UltimoCorresponde + 1).ToString("D3");
                    //res.numero = numero + "-" + (expediente.UltimoCorresponde + 1).ToString("D3");
                    nro_corresponde = (expediente.UltimoCorresponde + 1).ToString();
                    //res.nro_corresponde = (expediente.UltimoCorresponde + 1).ToString();
                    res = new { numero = numero + "-" + (expediente.UltimoCorresponde + 1).ToString("D3"), nro_corresponde = (expediente.UltimoCorresponde + 1).ToString() };
                }
            }
            else
            {
                string nro = "";

                //res.numero = (tipos.UltimoNumero + 1).ToString();
                resultado = (tipos.UltimoNumero + 1).ToString();
                res = new { numero = (tipos.UltimoNumero + 1).ToString(), nro_corresponde = "" };
            }

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            oExpedientesADMRN.Dispose();

            oCategoriasExpedienteADMRefRN.Dispose();

            oExpedientesADMRN.Dispose();

            oOrganismosRefRN.Dispose();

            oTiposExpedienteADMRefRN.Dispose();

            oUsuariosRN.Dispose();

            base.Dispose(disposing);
        }

        public string ConvertirALetras(string rawnumber)
        {
            int inputNum = 0;
            int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;
            string dollars, cents;
            try
            {
                string[] Splits = new string[2];
                Splits = rawnumber.Split(',');   //notice that it is ' and not "
                inputNum = Convert.ToInt32(Splits[0]);

                //get inputNum as an int

                //dollars = Convert.ToString(inputNum);
                dollars = "";
                cents = Splits[1];
                if (cents.Length == 1)
                {
                    cents += "0";   // 12.5 is twelve and 50/100, not twelve and 5/100
                }
            }
            catch
            {
                cents = "00";
                inputNum = Convert.ToInt32(rawnumber);
                dollars = "";
                //dollars = Convert.ToString(rawnumber);
            }

            string x = "";

            //they had zero for ones and tens but that gave ninety zero for 90
            string[] ones = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince", "dieciseis", "diecisiete", "dieciocho", "diecinueve" };
            string[] tens = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
            string[] thou = { "", "mil", "millón", "billón", "trillón", "cuatrillón", "quintilllón" };

            bool isNegative = false;
            if (inputNum < 0)
            {
                isNegative = true;
                inputNum *= -1;
            }
            if (inputNum == 0)
            {
                return "cero y " + cents + "/100";
            }

            string s = inputNum.ToString();

            //for (int t = 0; t < 5; t++)
            while (s.Length > 0)
            {
                if (s.Length > 0)
                {
                    //Get the three rightmost characters
                    x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);

                    // Separate the three digits
                    threeDigits = int.Parse(x);
                    lasttwo = threeDigits % 100;
                    dig1 = threeDigits / 100;
                    dig2 = lasttwo / 10;
                    dig3 = (threeDigits % 10);


                    // append a "thousand" where appropriate
                    if (level > 0 && dig1 + dig2 + dig3 > 0)
                    {
                        dollars = thou[level] + " " + dollars;
                        dollars = dollars.Trim();
                    }

                    // check that the last two digits is not a zero
                    if (lasttwo > 0)
                    {
                        if (lasttwo < 20)
                        {
                            // if less than 20, use "ones" only
                            dollars = ones[lasttwo] + " " + dollars;
                        }
                        else
                        {
                            // otherwise, use both "tens" and "ones" array
                            dollars = tens[dig2] + " " + ones[dig3] + " " + dollars;
                        }
                        if (s.Length < 3)
                        {
                            if (isNegative) { dollars = "negativo " + dollars; }
                            return dollars + " y " + cents + "/100";
                        }
                    }

                    // if a hundreds part is there, translate it
                    if (dig1 > 0)
                    {
                        dollars = ones[dig1] + " ciento " + dollars;
                        s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";
                        level++;
                    }
                }
            }
            if (isNegative) { dollars = "negativo " + dollars; }
            return dollars + " y " + cents + "/100";
        }

    } //fin de clase

    public class Imputacion
    {

        public int partida { get; set; }
        public int division { get; set; }
        public decimal importe { get; set; }

    }

}
