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
using System.Data.Objects;
using SSO.SGP.Web.Models;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Results;

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
    public class LicenciasAgenteController : Controller
    {
        private LicenciasAgenteRN oLicenciasAgenteRN = new LicenciasAgenteRN();
        private AgentesRN oAgentesRN = new AgentesRN();
        private LicenciasOrdinariasInicialesRN oLicenciasOrdinarias = new LicenciasOrdinariasInicialesRN();
        private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();
        private LicenciasRefRN oLicenciasRefRN = new LicenciasRefRN();
        private NombramientosRN oNombramientosRN = new NombramientosRN();
        private LicenciasAgenteAD oLicencias = new LicenciasAgenteAD();
        private AgentesAD oAgentes = new AgentesAD();
        private OrganismosRefAD oOrganismos = new OrganismosRefAD();

        #region Json


        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Excepcion(int licencia, int agente)
        {
            ViewBag.Licencia = licencia;
            ViewBag.Agente = agente;
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Timeline()
        {
            var licencias = oLicencias.LicenciasPorOrganismo(SessionHelper.OficinaActual.Value);
            var agentes = oOrganismos.AgentesDelOrganismo(SessionHelper.OficinaActual.Value);

            return View();
        }

        public ActionResult ResumenOrganizacion()
        {
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerRRHH().ToList(), "Id", "Descripcion");
            return View();
        }

        public JsonResult ResumenOrganismo(int organismo)
        {
            //todas las licencias del tipo licencia que tiene el agente
            var resumen = this.oOrganismosRefRN.ResumenDeLicencias(organismo);

            return this.Json(resumen, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Limitar(int Id)
        {
            ViewBag.Licencia = Id;
            return View();
        }

        public ActionResult Procesadas()
        {
            return View();
        }

        public ActionResult ProcesadasAgente()
        {
            return View();
        }

        public ActionResult PendientesAprobar()
        {
            return View();
        }

        public ActionResult PendientesAprobarAgente()
        {
            return View();
        }

        public ActionResult PendientesAprobarTodos()
        {
            return View();
        }

        public ActionResult PendientesPorEnfermedad()
        {
            return View();
        }

        public ActionResult PendientesAprobarTodosDetalle(int licencia)
        {
            var lic = oLicenciasAgenteRN.ObtenerPorId(licencia);

            ViewBag.Aprobaciones = oLicencias.GetAprobacionesDetalleResult(licencia);
            return View(lic);
        }

        public ActionResult PendientesAprobarSubrogancia()
        {
            return View();
        }

        public ActionResult HistorialSubrogancias()
        {
            return View();
        }

        public ActionResult Fechas(int id)
        {
            var lic = oLicencias.SinFechaDeAlta().ToList();

            foreach (var l in lic)
            {
                l.FechaAlta = DateTime.Now;
                oLicencias.Actualizar(l);
            }

            return View();
        }

        public JsonResult GetPorOrganismo()
        {

            var res = oLicencias.LicenciasPorOrganismo(SessionHelper.OficinaActual.Value).ToList();

            return Json(res, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ActualizarSubrogante(int id, int subrogante)
        {
            var lic = oLicenciasAgenteRN.ObtenerPorId(id);

            lic.SubroganteRRHH = subrogante;

            oLicenciasAgenteRN.Actualizar(lic);

            return View();
        }

        [HttpPost]
        public ActionResult Limitar(CustomLimitar c)
        {

            string error = "";

            if (c.Licencia == 1)
                error = "No puede limitarse esta licencia ordinaria. Contactese con sistemas.";

            LicenciasAgente l = oLicenciasAgenteRN.ObtenerPorId(c.Licencia);

            if (!c.FechaBaja.HasValue && !c.FechaInicio.HasValue)
                error = "No ha proporcionado ningún valor";

            if (c.FechaInicio.HasValue)
                if ((c.FechaInicio.Value < l.FechaDesde) || (c.FechaInicio.Value > l.FechaHasta))
                {
                    error = "La fecha de inicio de la limitación debe estar comprendida entre la fecha de inicio y fin de la licencia";
                }

            if (c.FechaBaja.HasValue)
                if ((c.FechaBaja.Value < l.FechaDesde) || (c.FechaBaja.Value > l.FechaHasta))
                {
                    error = "La fecha de fin de la limitación debe estar comprendida entre la fecha de inicio y fin de la licencia";
                }

            if (string.IsNullOrEmpty(error))
            {

                //es licencia ordinaria
                if (l.Licencias.CodigoRRHH == 1)
                {
                    int dias = 0;
                    var sinsaldo = false;

                    if (c.FechaBaja.HasValue && c.FechaInicio.HasValue)
                        dias = (int)((c.FechaBaja.Value - c.FechaInicio.Value).TotalDays) + 1;
                    else if (c.FechaInicio.HasValue && !c.FechaBaja.HasValue)
                        dias = (int)((c.FechaInicio.Value - l.FechaDesde).TotalDays);
                    else
                        dias = (int)((l.FechaHasta.Value - c.FechaBaja.Value).TotalDays);

                    var saldos = this.oLicenciasOrdinarias.ObtenerPorAgente(l.AgenteRRHH.Value).ToList();

                    if (saldos.Count() == 0)
                    {
                        saldos = this.oLicenciasOrdinarias.ObtenerTodoPorAgente(l.AgenteRRHH.Value).ToList();
                        sinsaldo = true;
                    }


                    var saldo = !sinsaldo ? saldos.First() : saldos.Last();

                    saldo.Saldo = saldo.Saldo + dias;

                    oLicenciasOrdinarias.Actualizar(saldo);
                }

                if (c.FechaInicio.HasValue && c.FechaBaja.HasValue)
                {
                    l.Observaciones = (string.IsNullOrEmpty(l.Observaciones)) ? "LICENCIA LIMITADA. Fecha de inicio original: " + l.FechaDesde.ToShortDateString() + " Baja: " + l.FechaHasta.Value.ToShortDateString() : l.Observaciones + ". " + "LICENCIA LIMITADA. Fecha de inicio original: " + l.FechaDesde.ToShortDateString() + " Baja: " + l.FechaHasta.Value.ToShortDateString();

                    LicenciasAgente l2 = new LicenciasAgente()
                    {
                        FechaDesde = c.FechaBaja.Value.AddDays(1),
                        FechaHasta = l.FechaHasta,
                        Estado = l.Estado,
                        Licencia = l.Licencia,
                        Nombramiento = l.Nombramiento,
                        Activa = true,

                        UsuarioAlta = l.UsuarioAlta,
                        FechaAlta = DateTime.Now,
                        UsuarioModifica = l.UsuarioModifica,
                        FechaModificacion = DateTime.Now,
                        AgenteRRHH = l.AgenteRRHH,
                        Observaciones = "LICENCIA LIMITADA. Fecha de inicio original: " + l.FechaDesde.ToShortDateString() + " Baja: " + l.FechaHasta.Value.ToShortDateString()
                    };

                    l.FechaHasta = c.FechaInicio.Value.AddDays(-1);
                    oLicenciasAgenteRN.Guardar(l2);

                }
                else
                {

                    if (c.FechaInicio.HasValue && !c.FechaBaja.HasValue)
                    {
                        l.Observaciones = (string.IsNullOrEmpty(l.Observaciones)) ? "LICENCIA LIMITADA. Fecha de inicio original: " + l.FechaDesde.ToShortDateString() : l.Observaciones + ". " + "LICENCIA LIMITADA. Fecha de inicio original: " + l.FechaDesde.ToShortDateString();
                        l.FechaDesde = c.FechaInicio.Value;
                        oLicenciasAgenteRN.Actualizar(l);

                    }
                    else
                        if (!c.FechaInicio.HasValue && c.FechaBaja.HasValue)
                    {
                        l.Observaciones = (string.IsNullOrEmpty(l.Observaciones)) ? "LICENCIA LIMITADA. Fecha de fin original: " + l.FechaHasta.Value.ToShortDateString() : l.Observaciones + ". " + "LICENCIA LIMITADA. Fecha de finalización original: " + l.FechaHasta.Value.ToShortDateString();
                        l.FechaHasta = c.FechaBaja;
                        oLicenciasAgenteRN.Actualizar(l);
                    }

                }


                return Json(new object[] { true, String.Format("La licencia se limitó satisfactoriamente") });
            }
            else
            {
                return Json(new object[] { false, String.Format("Ha ocurrido error: " + error) });
            }
        }

        [HttpPost]
        public ActionResult DejarSinEfecto(int licencia)
        {
            try
            {
                // TODO: Al dejar sin efecto si es licencia ordinaria -> sumar el salgo
                LicenciasAgente l = oLicenciasAgenteRN.ObtenerPorId(licencia);
                l.SinEfecto = true;
                l.Observaciones += "/SIN EFECTO";
                oLicenciasAgenteRN.Actualizar(l);


                //TODO: SI ES SUSTITUTO, no hay saldos de ordinaria!!
                if (!l.Nombramientos.SituacionRevista.ToUpper().Equals("S"))
                {
                    if (l.Licencias.CodigoRRHH == 1)
                    {
                        var saldos = this.oLicenciasOrdinarias.ObtenerPorAgente(l.AgenteRRHH.Value).ToList();
                        int dias = (int)((l.FechaHasta.Value - l.FechaDesde).TotalDays) + 1;

                        var saldo = saldos.First();

                        saldo.Saldo = saldo.Saldo + dias;

                        oLicenciasOrdinarias.Actualizar(saldo);
                    }
                }


                return Json(new object[] { true, String.Format("La licencia se fue dejada sin efecto") });
            }
            catch (Exception e)
            {
                return Json(new object[] { false, String.Format("Ocurrio un error al dejar sin efecto la licencia: " + e.Message) });
            }

        }

        [HttpPost]
        public ActionResult CrearExcepcion(CustomExepcionLicencia excepcion)
        {
            try
            {
                LicenciasRef l = this.oLicenciasRefRN.ObtenerPorId(excepcion.Licencia);

                if (l.DiasTopeExcepcion != 0 && l.DiasTopeExcepcion < excepcion.DiasOtorgados)
                {
                    return Json(new object[] { true, String.Format("Los días otorgados ({0}) superan al tope de excepción ({1}) de la licencia {2}", excepcion.DiasOtorgados, l.DiasTopeExcepcion, l.Descripcion), 0 });
                }
                else
                {
                    LicenciasAgenteExcepciones ex = new LicenciasAgenteExcepciones()
                    {
                        Agente = excepcion.Agente,
                        Licencia = excepcion.Licencia,
                        Fecha = DateTime.Now,
                        DiasQueHabilita = excepcion.DiasOtorgados,
                        Observaciones = excepcion.Observaciones,
                        UsuarioAlta = SessionHelper.IdUsuario.Value,
                        Resolucion = excepcion.Resolucion,
                        FechaFin = excepcion.FechaFin
                    };

                    this.oLicenciasAgenteRN.GuardarExcepcion(ex);

                    return Json(new object[] { true, String.Format("La excepción ha sido guardada"), ex.Id });
                }
            }
            catch (Exception e)
            {
                return Json(new object[] { true, String.Format("No se ha podido guardar la excepción. ({0})", e.Message), 0 });
            }
        }


        [HttpPost]
        public ActionResult Denegar(LicenciasAgente licenciasagente)
        {
            try
            {
                // TODO: Al dejar sin efecto si es licencia ordinaria -> sumar el saldo                
                licenciasagente.FechaAlta = DateTime.Now;
                licenciasagente.SinEfecto = true;
                licenciasagente.Observaciones += "/DENEGADA";
                licenciasagente.Estado = "DE";
                oLicenciasAgenteRN.Guardar(licenciasagente);

                //if (l.Licencias.CodigoRRHH == 1)
                //{
                //    var saldos = this.oLicenciasOrdinarias.ObtenerPorAgente(l.AgenteRRHH.Value).ToList();
                //    int dias = (int)((l.FechaHasta.Value - l.FechaDesde).TotalDays) + 1;

                //    var saldo = saldos.First();

                //    saldo.Saldo = saldo.Saldo + dias;

                //    oLicenciasOrdinarias.Actualizar(saldo);
                //}


                return Json(new object[] { true, String.Format("La licencia ha sido agregada como DENEGADA") });
            }
            catch (Exception e)
            {
                return Json(new object[] { false, String.Format("Ocurrio un error al denegar la licencia: " + e.Message) });
            }

        }

        public JsonResult totalDeDiasOrdinaria(int agente)
        {

            var a = oAgentesRN.ObtenerPorId(agente);
            int x = a.LicenciasOrdinariasIniciales.Sum(d => d.Saldo);

            return Json(new object[] { x, true }, JsonRequestBehavior.AllowGet);

        }


        public DataTablesResult<LicenciasAgenteView> getLicenciasAgenteGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oLicenciasAgenteRN.ObtenerParaGrilla(), dataTableParam, a => new LicenciasAgenteView()
            {
                Id = a.Id,
                Agente = a.Agente,
                FechaDesde = a.FechaDesde,
                FechaHasta = a.FechaHasta,
                Licencia = a.Licencia,
                Subrogante = a.Subrogante,
                Activa = a.Activa,
                FechaAlta = a.FechaAlta,
                UsuarioAlta = a.UsuarioAlta,
                FechaModificacion = a.FechaModificacion,
                UsuarioModifica = a.UsuarioModifica,
                FechaEliminacion = a.FechaEliminacion,
                UsuarioElimina = a.UsuarioElimina,
                AgenteRRHH = a.AgenteRRHH,
                Observaciones = a.Observaciones,
            });
        }

        public DataTablesResult<LicenciasAgentePorAprobarView> getLicenciasPendientesAprobar(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oLicencias.ObtenerLicenciasPendientesAprobar(SessionHelper.OficinaActual.Value), dataTableParam, x => x);
        }

        public DataTablesResult<LicenciasAgentePorAprobarView> getLicenciasPendientesAprobar2(DataTablesParam dataTableParam)
        {
            var a = oAgentes.GetByUser(SessionHelper.NombrePersona);
            return DataTablesResult.Create(this.oLicencias.ObtenerLicenciasPendientesAprobar2(a.Id), dataTableParam, x => x);
        }

        public DataTablesResult<LicenciasAgentePorAprobarView> getLicenciasPendientesAprobarAgente(DataTablesParam dataTableParam)
        {
            var ag = SessionHelper.NombrePersona;
            var agente = oAgentes.GetByUser(ag);
            return DataTablesResult.Create(this.oLicencias.ObtenerLicenciasPendientesAprobarAgente(agente.Id), dataTableParam, x => x);
        }

        public DataTablesResult<LicenciasAgentePorAprobarReconocimientoView> getLicenciaPendientesReconocimiento(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oLicencias.ObtenerLicenciasPendientesReconocimiento(), dataTableParam, x => x);
        }

        public DataTablesResult<LicenciasAgentePorAprobarView> getLicenciasPendientesAprobarTodos(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oLicencias.ObtenerLicenciasPendientesAprobarTodos(), dataTableParam, x => x);
        }

        public DataTablesResult<LicenciasAgentePorAprobarView> getLicenciasPendientesSubrogancia(DataTablesParam dataTableParam)
        {
            var ag = SessionHelper.NombrePersona;
            var agente = oAgentes.GetByUser(ag);
            return DataTablesResult.Create(this.oLicencias.ObtenerLicenciasPendientesSubrogar(agente.Id), dataTableParam, x => x);
        }

        public DataTablesResult<SubroganciasAceptadasView> getHistorialSubrogancias(DataTablesParam dataTableParam)
        {
            var ag = SessionHelper.NombrePersona;
            var agente = oAgentes.GetByUser(ag);
            return DataTablesResult.Create(this.oLicencias.ObtenerHistorialSubrogancias(agente.Id), dataTableParam, x => x);
        }

        public DataTablesResult<LicenciasAgenteProcesadasView> getLicenciasProcesadas(DataTablesParam dataTableParam)
        {
            var ag = SessionHelper.NombrePersona;
            var agente = oAgentes.GetByUser(ag);
            return DataTablesResult.Create(this.oLicencias.ObtenerLicenciasProcesadas(SessionHelper.OficinaActual.Value, agente.Id), dataTableParam, x => x);
        }

        public DataTablesResult<LicenciasAgenteProcesadasView> getLicenciasProcesadasAgente(DataTablesParam dataTableParam)
        {
            var ag = SessionHelper.NombrePersona;
            var agente = oAgentes.GetByUser(ag);
            return DataTablesResult.Create(this.oLicencias.ObtenerLicenciasProcesadasAgente(agente.Id), dataTableParam, x => x);
        }

        public ActionResult Crear()
        {
            ViewBag.LicenciasRef = new SelectList(oLicenciasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Licencias = oLicenciasRefRN.ObtenerTodo().ToList();
            return View();
        }

        public ActionResult Solicitar()
        {
            var a = oAgentes.GetByUser(SessionHelper.NombrePersona);

            var juezPaz = false;

            ViewBag.TextoSubrogante = "";
            ViewBag.JuezPaz = "0";

            switch (a.Id_Cargo)
            {
                case 43:
                case 44:
                case 45:
                    ViewBag.TextoSubrogante = "suplente";
                    ViewBag.JuezPaz = "1";
                    juezPaz = true;
                    break;
                default:
                    ViewBag.TextoSubrogante = "subrogante";
                    break;
            }


            ViewBag.Id_Cargo = a.Id_Cargo;
            ViewBag.Legajo = a.Legajo;
            ViewBag.IdAgente = a.Id;
            ViewBag.Agente = a.Nombre;
            ViewBag.Superior = a.Superior;
            ViewBag.IdSuperior = a.IdSuperior;
            ViewBag.Nombramiento = a.Id_Nombramiento;
            ViewBag.Funcionarios = a.Funcionarios;
            ViewBag.Grupo = a.Grupo;
            ViewBag.Cargo = a.Cargo;
            ViewBag.LicenciasRef = new SelectList(oLicenciasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Licencias = oLicenciasRefRN.ObtenerTodo().ToList();
            ViewBag.EmailSuperior = a.EmailSuperior;
            ViewBag.RequiereSubrogante = a.RequiereSubrogante;
            ViewBag.AgenteSolicitudLicenciaDefault = !juezPaz ? (a.AgenteSolicitudLicenciaDefault.HasValue ? oAgentes.ObtenerPorId(a.AgenteSolicitudLicenciaDefault.Value) : null) : oAgentes.ObtenerPorId(889);
            return View();
        }

        public ActionResult EditarSolicitud(int id)
        {
            var licencia = oLicenciasAgenteRN.ObtenerPorId(id);

            var a = oAgentes.GetByUser(SessionHelper.NombrePersona);

            var juezPaz = false;

            ViewBag.TextoSubrogante = "";
            ViewBag.JuezPaz = "0";

            switch (a.Id_Cargo)
            {
                case 43:
                case 44:
                case 45:
                    ViewBag.TextoSubrogante = "suplente";
                    ViewBag.JuezPaz = "1";
                    juezPaz = true;
                    break;
                default:
                    ViewBag.TextoSubrogante = "subrogante";
                    break;
            }
          

            ViewBag.Id_Cargo = a.Id_Cargo;
            ViewBag.Legajo = a.Legajo;
            ViewBag.IdAgente = a.Id;
            ViewBag.Agente = a.Nombre;
            ViewBag.Superior = a.Superior;
            ViewBag.IdSuperior = a.IdSuperior;
            ViewBag.Nombramiento = a.Id_Nombramiento;
            ViewBag.Funcionarios = a.Funcionarios;
            ViewBag.Grupo = a.Grupo;
            ViewBag.Cargo = a.Cargo;
            ViewBag.LicenciasRef = new SelectList(oLicenciasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Licencias = oLicenciasRefRN.ObtenerTodo().ToList();
            ViewBag.EmailSuperior = a.EmailSuperior;
            ViewBag.RequiereSubrogante = a.RequiereSubrogante;
            ViewBag.AgenteSolicitudLicenciaDefault = !juezPaz ? (a.AgenteSolicitudLicenciaDefault.HasValue ? oAgentes.ObtenerPorId(a.AgenteSolicitudLicenciaDefault.Value) : null) : oAgentes.ObtenerPorId(889);
            ViewBag.EsMedico = a.Profesion.ToUpper().Contains("MEDIC");

            return View(licencia);
        }

        public ActionResult SolicitarPorEnfermedad()
        {
            var a = oAgentes.GetByUser(SessionHelper.NombrePersona);

            var juezPaz = false;

            ViewBag.TextoSubrogante = "";
            ViewBag.JuezPaz = "0";

            switch (a.Id_Cargo)
            {
                case 43:
                case 44:
                case 45:
                    ViewBag.TextoSubrogante = "suplente";
                    ViewBag.JuezPaz = "1";
                    juezPaz = true;
                    break;
                default:
                    ViewBag.TextoSubrogante = "subrogante";
                    break;
            }


            ViewBag.Id_Cargo = a.Id_Cargo;
            ViewBag.Legajo = a.Legajo;
            ViewBag.IdAgente = a.Id;
            ViewBag.Agente = a.Nombre;
            ViewBag.Superior = a.Superior;
            ViewBag.IdSuperior = a.IdSuperior;
            ViewBag.Nombramiento = a.Id_Nombramiento;
            ViewBag.Funcionarios = a.Funcionarios;
            ViewBag.Grupo = a.Grupo;
            ViewBag.Cargo = a.Cargo;
            ViewBag.LicenciasRef = new SelectList(oLicenciasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Licencias = oLicenciasRefRN.ObtenerTodo().ToList();
            ViewBag.EmailSuperior = a.EmailSuperior;
            ViewBag.RequiereSubrogante = a.RequiereSubrogante;
            ViewBag.AgenteSolicitudLicenciaDefault = !juezPaz ? (a.AgenteSolicitudLicenciaDefault.HasValue ? oAgentes.ObtenerPorId(a.AgenteSolicitudLicenciaDefault.Value) : null) : oAgentes.ObtenerPorId(889);
            return View();
        }

        public bool contrlDeLicencia(LicenciasAgente licencia)
        {
            bool PorAnio = (licencia.Licencias.PorAnio.HasValue);
            bool PorLicencia = (licencia.Licencias.PorLicencia.HasValue);
            return false;
        }


        public ActionResult agenteConLicencia(int agente, string desde, string hasta)
        {

            DateTime fdesde = DateTime.Parse(desde);
            DateTime fhasta = DateTime.Parse(hasta);

            var res = oLicencias.AgenteConLicencia(agente, fdesde.Date, fhasta.Date);

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Crear(LicenciasAgente licenciasagente)
        {

            string error = "";
            if (ModelState.IsValid)
            {
                try
                {
                    error = oLicenciasAgenteRN.ControlarInicioDeLicencia(licenciasagente.Id, licenciasagente.AgenteRRHH.Value, licenciasagente.Licencia, licenciasagente.FechaDesde, licenciasagente.FechaHasta.Value);
                    licenciasagente.Activa = true;
                    licenciasagente.FechaAlta = DateTime.Now;
                    licenciasagente.UsuarioAlta = SessionHelper.IdUsuario.Value;
                    licenciasagente.Estado = (SessionHelper.UsuarioMinisterioPublico) ? "P" : "OK";
                    licenciasagente.Aprobada = true;

                    LicenciasRef l = oLicenciasRefRN.ObtenerPorId(licenciasagente.Licencia);
                    Agentes a = oAgentesRN.ObtenerPorId(licenciasagente.AgenteRRHH.Value);
                    a.AnioExpediente = Int32.Parse(Request["AnioExpediente"]);

                    if (a.Nombramientos.Where(n => !n.FechaDeBaja.HasValue && !n.FechaEliminacion.HasValue && n.SituacionRevista == "S").Count() > 0)
                    {
                        licenciasagente.Nombramiento = a.Nombramientos.Where(n => !n.FechaDeBaja.HasValue && !n.FechaEliminacion.HasValue && n.SituacionRevista == "S").FirstOrDefault().Id;
                    }
                    else
                    {
                        licenciasagente.Nombramiento = a.Nombramientos.Where(n => !n.FechaDeBaja.HasValue && !n.FechaEliminacion.HasValue).FirstOrDefault().Id;
                    }

                    if (licenciasagente.Nombramiento == null)
                        licenciasagente.Nombramiento = a.Nombramientos.Where(n => n.FechaDeBaja != null && n.FechaDeBaja > licenciasagente.FechaHasta).FirstOrDefault().Id;


                    if (error.Length == 0)
                    {
                        oLicenciasAgenteRN.Guardar(licenciasagente);

                        //LICENCIA ORDINARIA
                        if (l.CodigoRRHH == 1 && a.Nombramientos.Where(x => x.SituacionRevista == "S" && x.FechaDeBaja == null).Count() == 0)
                        {
                            var saldos = this.oLicenciasOrdinarias.ObtenerPorAgente(licenciasagente.AgenteRRHH.Value).ToList();
                            int dias = (int)((licenciasagente.FechaHasta.Value - licenciasagente.FechaDesde).TotalDays) + 1;

                            while (dias > 0)
                            {
                                foreach (LicenciasOrdinariasIniciales s in saldos)
                                {
                                    if (s.Saldo < dias)
                                    {
                                        dias = dias - s.Saldo;
                                        s.Saldo = 0;
                                        oLicenciasOrdinarias.Actualizar(s);
                                    }
                                    else
                                    {
                                        s.Saldo = s.Saldo - dias;

                                        dias = 0;
                                        oLicenciasOrdinarias.Actualizar(s);
                                        break;
                                    }
                                }
                            }
                        }

                        //Actualizar el año del expediente


                        oAgentesRN.Actualizar(a);

                        return Json(new object[] { true, String.Format("La licencia ha sigo guardada satisfactoriamente"), -1 });
                    }
                    else
                    {
                        return Json(new object[] { false, String.Format("Hay errores en el control de la licencia: " + error), l.DiasTopeExcepcion });
                    }
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar LicenciasAgente" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar LicenciasAgente" });
            }
        }


        [HttpPost]
        public ActionResult Editar(LicenciasAgente licenciasagente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oLicenciasAgenteRN.Actualizar(licenciasagente);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente LicenciasAgente") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse LicenciasAgente" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse LicenciasAgente" });
            }

        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oLicenciasAgenteRN.Eliminar(id, SessionHelper.IdUsuario.Value);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "Ocurrió un error al elimin ar la licencia: " + ex.Message });
            }
        }

        public JsonResult JsonT(int agente, int licencia, DateTime? fechadesde, DateTime? fechahasta)
        {
            var res = from x in this.oLicenciasAgenteRN.JsonT(agente, licencia, fechadesde, fechahasta)
                      select x;
            return this.Json(res.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonTPendientes(int agente, int licencia, DateTime? fechadesde, DateTime? fechahasta)
        {
            var res = from x in this.oLicencias.JsonTPendiente(agente, fechadesde, fechahasta)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonTotales(int agente, int licencia, DateTime? fechadesde, DateTime? fechahasta)
        {
            var res = from x in this.oLicenciasAgenteRN.JsonT(agente, licencia, fechadesde, fechahasta)
                      select x;

            var res2 = from x in res
                       group x by x.Licencia into l
                       select new ResumenDiasDeLicenciaDeAgenteViewT
                       {
                           Descripcion = l.Key,
                           Dias = l.Sum(t => t.Dias)
                       };

            return this.Json(res2, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oLicenciasAgenteRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ResumenLicenciaJson(int agente, int licencia)
        {
            //todas las licencias del tipo licencia que tiene el agente
            var licencias = oLicenciasAgenteRN.DiasDeLicenciaDeAgente(agente, licencia);
            var EnElAnio = licencias.Where(l => l.FechaDesde.Year == DateTime.Now.Year).Sum(x => EntityFunctions.DiffDays(x.FechaDesde, x.FechaHasta) + 1);
            var EnTotal = licencias.Sum(x => EntityFunctions.DiffDays(x.FechaDesde, x.FechaHasta) + 1); ;

            return this.Json(new { enelanio = EnElAnio, entotal = EnTotal }, JsonRequestBehavior.AllowGet);
        }


        //IMPLEMENTAR la accion Consulta
        public ActionResult ConsultaMM(int? agente)
        {

            ViewBag.Id = -1;

            if (agente.HasValue)
            {
                var ag = oAgentesRN.ObtenerPorId(agente.Value);
                ViewBag.Agente = ag.Personas.Apellidos.Trim() + ", " + ag.Personas.Nombres.Trim();
                ViewBag.Id = ag.Id;
            }


            CustomConsultaLicencias c = new CustomConsultaLicencias()
            {
                FechaDesde = DateTime.Parse("01/01/" + DateTime.Now.Year.ToString())
            };



            ViewBag.LicenciasRef = new SelectList(oLicenciasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View(c);
        }


        //IMPLEMENTAR la accion Consulta
        public ActionResult Consulta(int? agente)
        {

            ViewBag.Id = -1;

            if (agente.HasValue)
            {
                var ag = oAgentesRN.ObtenerPorId(agente.Value);
                ViewBag.Agente = ag.Personas.Apellidos.Trim() + ", " + ag.Personas.Nombres.Trim();
                ViewBag.Id = ag.Id;
            }


            CustomConsultaLicencias c = new CustomConsultaLicencias()
            {
                FechaDesde = DateTime.Parse("01/01/" + DateTime.Now.Year.ToString())
            };



            ViewBag.LicenciasRef = new SelectList(oLicenciasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View(c);
        }

        public ActionResult MisLicencias()
        {
            var ag = oAgentes.GetByUser(SessionHelper.NombrePersona);
            ViewBag.Agente = ag.Nombre;
            ViewBag.Id = ag.Id;

            CustomConsultaLicencias c = new CustomConsultaLicencias()
            {
                FechaDesde = DateTime.Parse("01/01/" + DateTime.Now.Year.ToString())
            };

            ViewBag.LicenciasRef = new SelectList(oLicenciasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View(c);
        }

        public ActionResult MisLicenciasPendientes()
        {
            var ag = oAgentes.GetByUser(SessionHelper.NombrePersona);
            ViewBag.Agente = ag.Nombre;
            ViewBag.Id = ag.Id;

            CustomConsultaLicencias c = new CustomConsultaLicencias()
            {
                FechaDesde = DateTime.Parse("01/01/" + DateTime.Now.Year.ToString())
            };

            //ViewBag.LicenciasRef = new SelectList(oLicenciasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View(c);
        }

        [HttpPost]
        public ActionResult Consultar(CustomConsultaLicencias consulta)
        {
            return this.Json(new { }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            oLicenciasAgenteRN.Dispose();

            oAgentesRN.Dispose();

            oLicenciasRefRN.Dispose();

            base.Dispose(disposing);
        }

    } //fin de clase
}
