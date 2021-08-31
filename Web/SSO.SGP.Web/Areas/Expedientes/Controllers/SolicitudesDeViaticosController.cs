using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.EntidadesDeNegocio;
using Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using Syncrosoft.Framework.Utils.Logs;
using Microsoft.AspNet.SignalR;
using SSO.SGP.Web.Models;
using SSO.SGP.Web.Controllers;

/// <summary>
///  CODE GENERATED BY Xeus Technology 
///  Date: 13/12/2018 7:26:22
///  Version: 3
/// <summary>
namespace SSO.SGP.Web.Areas.Expedientes.Controllers
{
    public class SolicitudesDeViaticosController : Controller
    {
        private SolicitudesDeViaticosAD oSolicitudesDeViaticos = new SolicitudesDeViaticosAD();
        private VehiculosOficialesRefAD oVehiculos = new VehiculosOficialesRefAD();
        private OrganismosRefAD oOrganismos = new OrganismosRefAD();
        private LocalidadesRefAD oLocalidades = new LocalidadesRefAD();
        private SolicitudesDeViaticosAgentesAD oSolicitudesAgentes = new SolicitudesDeViaticosAgentesAD();
        private SolicitudesDeViaticosRendicionesAD oRendiciones = new SolicitudesDeViaticosRendicionesAD();
        private SolicitudesDeViaticosRendicionesAgentesAD oRendicionesAgentes = new SolicitudesDeViaticosRendicionesAgentesAD();
        private ConceptosDeGastosRefAD oConceptos = new ConceptosDeGastosRefAD();
        private SolicitudesDeViaticosRendicionesDetalleAD oDetalleRendicion = new SolicitudesDeViaticosRendicionesDetalleAD();
        private PartidasPresupuestariasAD oPartidas = new PartidasPresupuestariasAD();
        private ParametrosadmAD oParametros = new ParametrosadmAD();


        #region Views

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult IndexTodos()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult Index()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexBorrador()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexPendientes()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexPorRendir()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexRendidas()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexComisionPendienteChofer()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexPorEstado()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexPorComision()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexTodosAnticipo()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexTodosReintegro()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult IndexTodosControlarRendicion()
        {
            var m = new SolicitudesDeViaticos();
            return View(m);
        }


        public ActionResult Crear()
        {        
            var extensiones = oOrganismos.getExtensiones(SessionHelper.OficinaActual.Value);

            if (extensiones != null && extensiones.AutoPropioViaticos.HasValue && extensiones.AutoPropioViaticos.Value > 0)
            {
                ViewBag.AutoPropio = true;
            }
            else {
                ViewBag.AutoPropio = false;
            }


            ViewBag.AutoOficial = oVehiculos.ObtenerOptions("").ToList();
            var m = new SolicitudesDeViaticos();
            return View(m);
        }

        public ActionResult CrearRendicion(int id = 0)
        {            
            SolicitudesDeViaticos solicitudesdeviaticos = oSolicitudesDeViaticos.ObtenerPorId(id);
            if (solicitudesdeviaticos == null)
            {
                return HttpNotFound();
            }
            else
            {
                var rendicion = oRendiciones.ObtenerPorSolicitud(id);

                //editar la rendicion
                if (rendicion.Id > 0)
                {
                    ViewBag.Id = rendicion.Id;
                    ViewBag.Solicitud = id;
                    ViewBag.Organismo = oOrganismos.ObtenerPorId(solicitudesdeviaticos.OrganismoSolicitante).Descripcion;
                    var l = oLocalidades.ObtenerPorId(solicitudesdeviaticos.Destino);
                    ViewBag.Destino = l.Descripcion + " - " + l.Provincias.Descripcion;
                    return View("EditarRendicion", rendicion);
                }
                else
                {
                    ViewBag.Solicitud = id;
                    ViewBag.Organismo = oOrganismos.ObtenerPorId(solicitudesdeviaticos.OrganismoSolicitante).Descripcion;
                    var l = oLocalidades.ObtenerPorId(solicitudesdeviaticos.Destino);
                    ViewBag.Destino = l.Descripcion + " - " + l.Provincias.Descripcion;
                    return View(solicitudesdeviaticos);
                }
            }
        }

        public ActionResult AsignarChofer(int id = 0)
        {
            ViewBag.AutoOficial = oVehiculos.ObtenerOptions("").ToList();
            var solicitudesdeviaticos = oSolicitudesDeViaticos.ObtenerPorComision(id).FirstOrDefault();

            ViewBag.Comisiones = oSolicitudesDeViaticos.ObtenerPorComision(id).ToList();
            ViewBag.AgentesComision = oSolicitudesDeViaticos.ObtenerAgentesDeComision(id);


            if (solicitudesdeviaticos == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Organismo = oOrganismos.ObtenerPorId(solicitudesdeviaticos.OrganismoSolicitante).Descripcion;
                var l = oLocalidades.ObtenerPorId(solicitudesdeviaticos.Destino);
                ViewBag.Destino = l.Descripcion + " - " + l.Provincias.Descripcion;
                return View(solicitudesdeviaticos);
            }
        }

        public ActionResult Editar(int id = 0)
        {
            var extensiones = oOrganismos.getExtensiones(SessionHelper.OficinaActual.Value);

            if (extensiones != null && extensiones.AutoPropioViaticos.HasValue && extensiones.AutoPropioViaticos.Value > 0)
            {
                ViewBag.AutoPropio = true;
            }
            else
            {
                ViewBag.AutoPropio = false;
            }

            ViewBag.AutoOficial = oVehiculos.ObtenerOptions("").ToList();
            SolicitudesDeViaticos solicitudesdeviaticos = oSolicitudesDeViaticos.ObtenerPorId(id);
            if (solicitudesdeviaticos == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Organismo = oOrganismos.ObtenerPorId(solicitudesdeviaticos.OrganismoSolicitante).Descripcion;
                var l = oLocalidades.ObtenerPorId(solicitudesdeviaticos.Destino);
                ViewBag.Destino = l.Descripcion + " - " + l.Provincias.Descripcion;
                return View(solicitudesdeviaticos);
            }
        }

        public ActionResult EditarRendicion(int id)
        {
            
            ViewBag.AutoOficial = oVehiculos.ObtenerOptions("").ToList();
            SolicitudesDeViaticosRendiciones rendicion = oRendiciones.ObtenerPorId(id);
            if (rendicion == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Organismo = oOrganismos.ObtenerPorId(rendicion.SolicitudDeViaticos.OrganismoSolicitante).Descripcion;
                ViewBag.idOrganismo = rendicion.SolicitudDeViaticos.OrganismoSolicitante;
                var l = oLocalidades.ObtenerPorId(rendicion.SolicitudDeViaticos.Destino);
                ViewBag.Destino = l.Descripcion + " - " + l.Provincias.Descripcion;
                ViewBag.Id = id;
                ViewBag.Solicitud = rendicion.SolicitudDeViatico;
                return View(rendicion);
            }
        }

        #endregion

        #region HttpPost
        [HttpPost]
        public ActionResult CancelarSolicitud(int Solicitud)
        {
            try
            {
                var s = oSolicitudesDeViaticos.ObtenerPorId(Solicitud);
                if (s != null)
                {
                    s.Estado = 13; //cancelado por solicitante
                    s.FechaModifica = DateTime.Now;
                    s.UsuarioModifica = (SessionHelper.IdUsuarioAppExterna.HasValue ? SessionHelper.IdUsuarioAppExterna.Value : SessionHelper.IdUsuario.Value);

                    oSolicitudesDeViaticos.Actualizar(s);

                    return Json(new object[] { true, String.Format("Operación satisfactoria") });
                }
                else {
                    return Json(new object[] { false, String.Format("Ocurrió un error al cancelar la solicitud") });
                }

            }
            catch (Exception ex) {
                return Json(new object[] { false, String.Format("Ocurrió una excepción al cancelar la solicitud") });
            }

        }


        [HttpPost]
        public ActionResult Crear(SolicitudesDeViaticos solicitudesdeviaticos)
        {
            solicitudesdeviaticos.FechaAlta = DateTime.Now;
            solicitudesdeviaticos.UsuarioAlta = SessionHelper.IdUsuario.Value;
            solicitudesdeviaticos.FechaModifica = DateTime.Now;
            solicitudesdeviaticos.UsuarioModifica = SessionHelper.IdUsuario.Value;
            NotificacionesModel notificacion = new NotificacionesModel();

            try
            {
                bool envia_notificacion = false;
                int organismo_notificacion = 0;
                var organismo = oOrganismos.ObtenerPorId(solicitudesdeviaticos.OrganismoSolicitante);

                if (solicitudesdeviaticos.MedioDeTransporte == (int)eMediosDeTransporte.Auto_Poder_Judicial_Asignado_Organismo)
                                


                if (solicitudesdeviaticos.Estado == (int)eEstadosDeViaticos.Asignar_Chofer)
                {
                    if (!solicitudesdeviaticos.Comision.HasValue) {
                        envia_notificacion = true;

                        var circunscripcion = organismo.Circunscripcion;
                        if (circunscripcion.HasValue) {
                            switch (circunscripcion.Value)
                            {
                                case 1: organismo_notificacion = (int)eServiciosGenerales.Servicios_Generales_SR;
                                    break;
                                case 2: organismo_notificacion = (int)eServiciosGenerales.Servicios_Generales_Pico;
                                    break;
                                case 3:
                                    organismo_notificacion = (int)eServiciosGenerales.Servicios_Generales_Acha;
                                    break;
                                case 4:
                                    organismo_notificacion = (int)eServiciosGenerales.Servicios_Generales_Victorica;
                                    break;
                            }
                        }

                        notificacion = new NotificacionesModel()
                        {
                            Mensaje = "Hay una nueva comisión para asignar Chofer y Vehículo Oficial",
                            Titulo = "Nueva comisión",
                            Organismo = organismo_notificacion,                           
                        };
                    }                        
                }
                else {
                    envia_notificacion = true;
                    if (solicitudesdeviaticos.Estado == (int)eEstadosDeViaticos.Solicitado) {
                        notificacion = new NotificacionesModel()
                        {
                            Mensaje = string.Format("Hay una nueva solicitud de viáticos por revisar del organismo {0}",organismo.Descripcion),
                            Titulo = "Nueva solicitud",
                            Organismo = 783,
                        };
                    }                    
                }


                var p = oParametros.ObtenerPorId(1);
                int comision = 0;
                if (!solicitudesdeviaticos.Comision.HasValue)
                {                    
                    comision = (p.UltimaComision.Value + 1);
                    p.UltimaComision++;
                    solicitudesdeviaticos.Comision = comision;                    
                }


                if (envia_notificacion)
                {
                    var hubContext = GlobalHost.ConnectionManager.GetHubContext<ServiciosHub>();
                    hubContext.Clients.All.mostrarNotificacionPorOrganismo(notificacion.Titulo, notificacion.Mensaje, notificacion.Organismo);
                }

                oSolicitudesDeViaticos.Guardar(solicitudesdeviaticos);
                oParametros.Actualizar(p);

                return Json(new object[] { true, String.Format("Operación satisfactoria"), solicitudesdeviaticos.Id });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No se ha podido procesar la operación" });
            }

        }

        [HttpPost]
        public ActionResult ActualizarEstado(int estado, int solicitud)
        {
            string warning = "";

            try
            {
                NotificacionesModel notificacion = new NotificacionesModel();
                 
                var s = oSolicitudesDeViaticos.ObtenerPorId(solicitud);
                s.Estado = estado;

                if (estado == 7)
                    s.Anticipo = true;

                if (s.Anticipo && estado == (int)eEstadosDeViaticos.Anticipo_Depositado) {
                    foreach (var a in s.SolicitudesDeViaticosAgentes) {
                        if (!string.IsNullOrEmpty(a.Agentes.Email))
                        {
                            new MailController().DepositoDeAnticipo(s.Id, a.Agente).Deliver();
                        }
                        else {
                            warning += "El agente " + a.Agentes.Personas.Apellidos + ", " + a.Agentes.Personas.Nombres + " no tiene email asignado para enviar notificación. ";
                        }
                    }                   
                }

                s.FechaModifica = DateTime.Now;
                s.UsuarioModifica = SessionHelper.IdUsuario.Value;
                oSolicitudesDeViaticos.Actualizar(s);

                /****** Economía aprueba la solicitud y se notifica al organismo solicitante  */
                if (estado == (int)eEstadosDeViaticos.Solicitud_Aprobada) {
                    notificacion = new NotificacionesModel()
                    {
                        Titulo = String.Format("Solicitud #{0} aprobada", s.Id.ToString()),
                        Mensaje = String.Format("La Sec. de Economía ha aprobado su solicitd de viáticos #{0}", s.Id.ToString()),
                        Organismo = s.OrganismoSolicitante
                    };
                }

                /****** Economía rechaza la solicitud y se notifica al organismo solicitante  */
                if (estado == (int)eEstadosDeViaticos.Rechazado)
                {
                    notificacion = new NotificacionesModel()
                    {
                        Titulo = String.Format("Solicitud #{0} rechazada", s.Id.ToString()),
                        Mensaje = String.Format("La Sec. de Economía ha rechazado su solicitd de viáticos #{0}", s.Id.ToString()),
                        Organismo = s.OrganismoSolicitante
                    };
                }

                /****** Servicios generales asignó chofer y se marca como solicitado  */
                if (estado == (int)eEstadosDeViaticos.Solicitado)
                {
                    var o = oOrganismos.ObtenerPorId(s.OrganismoSolicitante);
                    notificacion = new NotificacionesModel()
                    {
                        Titulo = String.Format("Nueva solicitud de viáticos"),
                        Mensaje = String.Format("Se ha recibido una nueva solicitud de viáticos. Comisión #{0}", s.Comision.ToString()),
                        Organismo = 783
                    };
                }

                if (!string.IsNullOrEmpty(notificacion.Titulo)) {
                    var hubContext = GlobalHost.ConnectionManager.GetHubContext<ServiciosHub>();
                    hubContext.Clients.All.mostrarNotificacionPorOrganismo(notificacion.Titulo, notificacion.Mensaje, notificacion.Organismo);
                }

                return Json(new object[] { true, String.Format("Operación satisfactoria"), s.Id, warning });
            }
            catch (Exception e) {
                return Json(new object[] { false, "No se ha podido procesar la operación", 0, warning });
            }
        }

        [HttpPost]
        public ActionResult CrearRendicion(SolicitudesDeViaticosRendiciones rendicion, int estado, List<SolicitudesDeViaticosRendicionesDetalle> detalle_gastos)
        {
            rendicion.FechaDeAlta = DateTime.Now;
            rendicion.UsuarioAlta = SessionHelper.IdUsuario.Value;

            try
            {
                oRendiciones.Guardar(rendicion);

                var solicitud = oSolicitudesDeViaticos.ObtenerPorId(rendicion.SolicitudDeViatico);
                solicitud.Estado = estado;

                oSolicitudesDeViaticos.Actualizar(solicitud);

                if (rendicion.SolicitudesDeViaticosRendicionesAgentes != null)
                {
                    foreach (var rendicion_agente in rendicion.SolicitudesDeViaticosRendicionesAgentes)
                    {
                        if (detalle_gastos != null)
                        {
                            foreach (var gasto in detalle_gastos.Where(g => g.Agente == rendicion_agente.Agente).ToList())
                            {
                                gasto.RendicionAgente = rendicion_agente.Id;
                                oDetalleRendicion.Guardar(gasto);
                            }
                        }
                    }
                }

                return Json(new object[] { true, String.Format("Operación satisfactoria"), rendicion.Id });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No se ha podido procesar la operación" });
            }

        }

        [HttpPost]
        public ActionResult Editar(SolicitudesDeViaticos solicitudesdeviaticos, List<SolicitudesDeViaticosAgentes> detalle)
        {
            solicitudesdeviaticos.FechaModifica = DateTime.Now;
            solicitudesdeviaticos.UsuarioModifica = SessionHelper.IdUsuario.Value;

            NotificacionesModel notificacion = new NotificacionesModel();

            var agentes = oSolicitudesDeViaticos.ObtenerAgentes(solicitudesdeviaticos.Id).Select(s=>s.Id).ToList();

            foreach (var x in agentes) {
                oSolicitudesAgentes.Eliminar(x);
            }

            try
            {
                oSolicitudesDeViaticos.Actualizar(solicitudesdeviaticos);

                foreach (var x in detalle)
                {
                    x.Id = 0;
                    x.SolicitudDeViatico = solicitudesdeviaticos.Id;
                    oSolicitudesAgentes.Guardar(x);
                }

                //Se actualizó la solicitud y se marcó como solicitado
                if (solicitudesdeviaticos.Estado == (int)eEstadosDeViaticos.Solicitado)
                {
                    var o = oOrganismos.ObtenerPorId(solicitudesdeviaticos.OrganismoSolicitante);
                    notificacion = new NotificacionesModel()
                    {
                        Titulo = String.Format("Nueva solicitud de viáticos #" + solicitudesdeviaticos.Id),
                        Mensaje = String.Format("Ha recibido una nueva solicitud de viáticos del organismo {0}", o.Descripcion),
                        Organismo = 783
                    };
                }

                return Json(new object[] { true, String.Format("Operación satisfactoria") });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No se ha podido procesar la operación" });
            }

        }

        [HttpPost]
        public ActionResult ConfirmarChofer(SolicitudesDeViaticos solicitudesdeviaticos, List<SolicitudesDeViaticosAgentes> detalle)
        {
            try {

                var nuevasolicitud = new SolicitudesDeViaticos() {
                    Anticipo = solicitudesdeviaticos.Anticipo,
                    AutoOficial = solicitudesdeviaticos.AutoOficial,
                    Destino = solicitudesdeviaticos.Destino,
                    Estado = solicitudesdeviaticos.Estado,
                    ConChofer = solicitudesdeviaticos.ConChofer,
                    FechaAlta = DateTime.Now,
                    SolicitaAnticipo = solicitudesdeviaticos.SolicitaAnticipo,
                    UsuarioAlta = SessionHelper.IdUsuario.Value,
                    UsuarioModifica = SessionHelper.IdUsuario.Value,
                    OrganismoSolicitante = SessionHelper.OficinaActual.Value,
                    Fecha = solicitudesdeviaticos.Fecha,
                    FechaDeInicio = solicitudesdeviaticos.FechaDeInicio,
                    FechaDeFin = solicitudesdeviaticos.FechaDeFin,
                    MedioDeTransporte = solicitudesdeviaticos.MedioDeTransporte,
                    MotivoDeComision = solicitudesdeviaticos.MotivoDeComision,
                    Comision = solicitudesdeviaticos.Comision,
                    FechaModifica = DateTime.Now,
                    SolicitudesDeViaticosAgentes = detalle
                };

                oSolicitudesDeViaticos.Guardar(nuevasolicitud);

                var solicitudes = oSolicitudesDeViaticos.ObtenerPorComision(nuevasolicitud.Comision.Value).ToList();

                foreach (var s in solicitudes) {
                    s.AutoOficial = nuevasolicitud.AutoOficial;
                    s.FechaModifica = DateTime.Now;
                    s.UsuarioModifica = SessionHelper.IdUsuario.Value;
                    s.Estado = nuevasolicitud.Estado;

                    oSolicitudesDeViaticos.Actualizar(s);
                }

                var o = oOrganismos.ObtenerPorId(solicitudesdeviaticos.OrganismoSolicitante);
                var notificacion = new NotificacionesModel()
                {
                    Titulo = String.Format("Nueva solicitud de viáticos"),
                    Mensaje = String.Format("Ha recibido una nueva solicitud de viáticos del organismo {0}", o.Descripcion),
                    Organismo = 829
                };
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<ServiciosHub>();
                hubContext.Clients.All.mostrarNotificacionPorOrganismo(notificacion.Titulo, notificacion.Mensaje, notificacion.Organismo);

                return Json(new object[] { true, String.Format("Operación satisfactoria"), nuevasolicitud.Id });
            }
            catch (Exception e)
            {
                Logger.GrabarExcepcion(e, false);
                return Json(new object[] { false, "No se ha podido procesar la operación" });
            }
 

        }


        [HttpPost]
        public ActionResult EditarRendicion(SolicitudesDeViaticosRendiciones rendicion, List<SolicitudesDeViaticosRendicionesAgentes> detalle, int estado, List<SolicitudesDeViaticosRendicionesDetalle> detalle_gastos)
        {            
           
            var agentes = oSolicitudesDeViaticos.ObtenerAgentesRendicion(rendicion.Id).Select(s => s.Id).ToList();

            //var conceptos = oDetalleRendicion.ObtenerPorRendicion(rendicion.Id).Select(x=>x.Id).ToList();
            //foreach (var c in conceptos) {
            //    oDetalleRendicion.Eliminar(c);
            //}

            foreach (var x in agentes)
            {                
                oRendicionesAgentes.Eliminar(x);                
            }

            try
            {
                var solicitud = oSolicitudesDeViaticos.ObtenerPorId(rendicion.SolicitudDeViatico);
                solicitud.Estado = estado;
                solicitud.FechaModifica = DateTime.Now;
                solicitud.UsuarioModifica = SessionHelper.IdUsuario.Value;
                oSolicitudesDeViaticos.Actualizar(solicitud);
                                
                oRendiciones.Actualizar(rendicion);

                foreach (var x in detalle)
                {
                    x.Id = 0;
                    x.Rendicion = rendicion.Id;
                    oRendicionesAgentes.Guardar(x);
                }

                if (detalle_gastos != null)
                {
                    foreach (var x in detalle_gastos)
                    {
                        x.RendicionAgente = detalle.Where(c => c.Agente == x.Agente).FirstOrDefault().Id;
                        oDetalleRendicion.Guardar(x);
                    }
                }

                return Json(new object[] { true, String.Format("Operación satisfactoria") });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No se ha podido procesar la operación" });
            }

        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oSolicitudesDeViaticos.Eliminar(id);

                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception)
            {
                return Json(new object[] { false, "No pudo eliminarse el elementos" });
            }

        }


        #endregion

        #region JsonResult

        public DataTablesResult<SolicitudesDeViaticosView> getSolicitudesDeViaticosPorEstadoGrid(DataTablesParam dataTableParam, string estado)
        {
            List<int> aEstados = new List<int>();
            var estados = estado.Split(',');
            foreach (var e in estados) {
                aEstados.Add(int.Parse(e));
            }

            return DataTablesResult.Create(this.oSolicitudesDeViaticos.ObtenerParaGrillaPorEstado(SessionHelper.OficinaActual.Value, aEstados), dataTableParam, x => x);
        }

        public DataTablesResult<SolicitudesDeViaticosView> getSolicitudesDeViaticosGrid(DataTablesParam dataTableParam, int? agente, int? destino)
        {
            return DataTablesResult.Create(this.oSolicitudesDeViaticos.ObtenerParaGrilla(SessionHelper.OficinaActual.Value, agente, destino), dataTableParam, x => x);
        }

        public DataTablesResult<SolicitudesDeViaticosView> getSolicitudesDeViaticosTodosGrid(DataTablesParam dataTableParam, int? agente, int? destino)
        {
            return DataTablesResult.Create(this.oSolicitudesDeViaticos.ObtenerParaGrilla(null, agente, destino), dataTableParam, x => x);
        }

        public DataTablesResult<SolicitudesDeViaticosView> getSolicitudesDeViaticosTodosPorEstadoGrid(DataTablesParam dataTableParam, string estado, int? agente, int? destino)
        {
            List<int> aEstados = new List<int>();
            var estados = estado.Split(',');
            foreach (var e in estados)
            {
                aEstados.Add(int.Parse(e));
            }

            return DataTablesResult.Create(this.oSolicitudesDeViaticos.ObtenerParaGrillaPorEstado(null, aEstados), dataTableParam, x => x);
        }

        public DataTablesResult<SolicitudesDeViaticosView> getSolicitudesDeViaticosTodosPorAnticipoGrid(DataTablesParam dataTableParam, int? agente, int? destino)
        {
            return DataTablesResult.Create(this.oSolicitudesDeViaticos.ObtenerParaGrillaPorAnticipo(null, agente, destino), dataTableParam, x => x);
        }

        public DataTablesResult<SolicitudesDeViaticosView> getSolicitudesDeViaticosTodosPorReintegroGrid(DataTablesParam dataTableParam, int? agente, int? destino)
        {
            return DataTablesResult.Create(this.oSolicitudesDeViaticos.ObtenerParaGrillaPorReintegro(null, agente, destino), dataTableParam, x => x);
        }

        public DataTablesResult<SolicitudesDeViaticosPorComisionView> getComisionesPendientesDeChofer(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oSolicitudesDeViaticos.ObtenerPorComisionGrilla(null, 12), dataTableParam, x => x);
        }

        public JsonResult Options()
        {
            var res = from x in this.oSolicitudesDeViaticos.ObtenerOptions("")
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Solapamiento(int agente, string desde, string hasta)
        {
            var inicio = DateTime.Parse(desde);
            var fin = DateTime.Parse(hasta);

            var res = oSolicitudesDeViaticos.solapamientoSolicitud(agente, inicio, fin);

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult Table(string term)
        //{
        //    var res = from x in this.oSolicitudesDeViaticos.JsonT(term)
        //              select x;
        //    return this.Json(res, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetData(int id)
        {
            var res = this.oSolicitudesDeViaticos.GetResult(id);
            res.sFechaDeFin = res.FechaDeFin.ToString("dd/MM/yyyy HH:mm:ss");
            res.sFechaDeInicio = res.FechaDeInicio.ToString("dd/MM/yyyy HH:mm:ss");
            res.LugarYFecha = "Santa Rosa, " + res.Fecha.ToShortDateString();
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataRendicion(int id)
        {
            var res = this.oSolicitudesDeViaticos.GetRendicionResult(id);
            res.sFechaDeFin = res.FechaDeFin.ToString("dd/MM/yyyy HH:mm:ss");
            res.sFechaDeInicio = res.FechaDeInicio.ToString("dd/MM/yyyy HH:mm:ss");
            res.LugarYFecha = "Santa Rosa, " + res.Fecha.ToShortDateString();
            res.TGastos = res.Detalle.Sum(x => x.Gastos);
            res.Total = res.Detalle.Sum(x => x.Total);
            res.Anticipo = res.Detalle.Sum(x => x.Anticipo);
            res.Cobrar = res.Detalle.Sum(x => x.Cobrar);
            res.Devolver = res.Detalle.Sum(x => x.Devolver);
            res.ServiciosNoPersonales = res.Total;
             
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetalleRendicion(int id)
        {
            return this.Json(this.oDetalleRendicion.ObtenerPorRendicion(id).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPartidas()
        {
            return this.Json(this.oPartidas.ObtenerMin().ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetConceptos()
        {
            return this.Json(this.oConceptos.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgentes(int id)
        {
            return this.Json(this.oSolicitudesDeViaticos.ObtenerAgentes(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SugerirComisiones(int lugar, string desde)
        {
            var fecha = DateTime.Parse(desde);
            return this.Json(this.oSolicitudesDeViaticos.SugerirComisiones(lugar, fecha), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJsonConceptosGastos(string term)
        {
            var res = from x in this.oConceptos.ObtenerOptions(term)
                      select new
                      {
                          id = x.value,
                          label = x.text,                         
                      };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgentesRendicion(int id)
        {
            return this.Json(this.oSolicitudesDeViaticos.ObtenerAgentesRendicion(id), JsonRequestBehavior.AllowGet);
        }

        //public JsonResult Autocomplete(string term)
        //{
        //    var res = from x in this.oSolicitudesDeViaticos.ObtenerAutocomplete(term)
        //              select new { id = x.Id, label = x.Id.ToString() };
        //    return this.Json(res, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult ExecuteQuery(string where_c, string order_c)
        //{
        //    var res = from x in this.oSolicitudesDeViaticos.ExecuteQuery(where_c, order_c, 0, 0)
        //              select x;
        //    return this.Json(res, JsonRequestBehavior.AllowGet);
        //}

        #endregion

        protected override void Dispose(bool disposing)
        {
            //oSolicitudesDeViaticos.Dispose();

            base.Dispose(disposing);
        }


    }
}
