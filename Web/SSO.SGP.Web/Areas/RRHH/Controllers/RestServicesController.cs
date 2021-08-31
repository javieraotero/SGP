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
using SSO.SGP.EntidadesDeNegocio.Results;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using SSO.SGP.Web.Controllers;
using System.Collections.Generic;
using SSO.SGP.AccesoADatos;
using SSO.Common.Utils;
using WebMatrix.WebData;
using SSO.SGP.EntidadesDeNegocio.Custom;
using Newtonsoft.Json;
using SSO.SGP.Web.Models;

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
    public class RestServicesController : Controller
    {
        private AgentesRN oAgentesRN = new AgentesRN();
        private CargosRefRN oCargosRefRN = new CargosRefRN();
        private LicenciasAgenteRN oLicenciasRN = new LicenciasAgenteRN();
        private LicenciasRefRN oLicenciasRefRN = new LicenciasRefRN();
        private OrganismosRefRN oOrganismosRN = new OrganismosRefRN();
        private ParametrosadmRN oParametrosRN = new ParametrosadmRN();
        private PersonasRN oPersonasRN = new PersonasRN();
        private ImagenesrrhhRN oImagenes = new ImagenesrrhhRN();
        public const string API_KEY = "AIzaSyBo5sICu_JFhsJi7NlZeHDsdKf2PABKIYM";
        private LicenciasOrdinariasInicialesRN oLicenciasOrdinarias = new LicenciasOrdinariasInicialesRN();
        private NoticiasAD oNoticias = new NoticiasAD();
        private NoticiasCivilAD oNoticiasCivil = new NoticiasCivilAD();
        private BDEntities db = new BDEntities();
        private AgentesAD oAgentes = new AgentesAD();
        private RegistroRebeldiadtoAD oRebeldia = new RegistroRebeldiadtoAD();

        private void sendPushNotification(string mensaje, int agente)
        {
            var jGcmData = new JObject();
            var jData = new JObject();

            jData.Add("message", mensaje);
            jGcmData.Add("agente", agente.ToString());
            jGcmData.Add("to", "/topics/global");
            jGcmData.Add("data", jData);

            var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Authorization", "key=" + API_KEY);

                    Task.WaitAll(client.PostAsync(url,
                        new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"))
                            .ContinueWith(response =>
                            {
                                // Console.WriteLine(response);
                                // Console.WriteLine("Message sent: check the client device notification tray.");
                            }));
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine("Unable to send GCM message:");
                // Console.Error.WriteLine(e.StackTrace);
            }
        }

        #region Results

        public ActionResult Noticias()
        {
            var noticias = oNoticias.ObtenerUltimas().ToList();
            return this.Json(noticias, JsonRequestBehavior.AllowGet);
        }

        public ActionResult consultar_foro(string dni, string token)
        {
            //var z = Request.Headers.GetValues("Authorization");
            //var token = z.FirstOrDefault().Substring(7, z.FirstOrDefault().Length - 7);
            //var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXJtb3ZpbCIsIm5iZiI6MTU0MzIzOTMxMSwiZXhwIjoxNTQzMjQxMTExLCJpYXQiOjE1NDMyMzkzMTEsImlzcyI6Imh0dHA6Ly9jYXB0dXJhcy5mb3JvcGF0YWdvbmljby5nb2IuYXIvcmViZWxkaWFzLmFwaSIsImF1ZCI6Imh0dHA6Ly9jYXB0dXJhcy5mb3JvcGF0YWdvbmljby5nb2IuYXIvcmViZWxkaWFzLmFwaSJ9.C2FAbX8ZNL_ZtnvlsEp7dbsrWJMSGCxWUPPkGZKfaNo";
            using (var client = new HttpClient())
            {
                var url = "http://capturas.foropatagonico.gob.ar/Rebeldias.API/api/rebeldiaspersona/" + dni;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var response = client.GetStringAsync(url);
                var json = JsonConvert.DeserializeObject<List<RebeldiaForo>>(response.Result);
                return this.Json(json, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ejecutar(string s) {
            new VocesAD().ejecutarSQL(s);
            return View();
        }

        public ActionResult Rebeldia(string dni)
        {
            var noticias = oRebeldia.ObtenerPorDNI(dni);
            return this.Json(noticias, JsonRequestBehavior.AllowGet);
        }

        public JsonResult updateData(int documento, string legajo_sueldo, string afiliado)
        {
            return this.Json(oAgentesRN.updateData(documento, legajo_sueldo, afiliado));
        }

        public JsonResult UltimaLicencia(string device_id)
        {

            List<string> fechas = new List<string>();
            var l = oAgentesRN.UltimaLicencia(device_id);

            fechas.Add(l.Value.AddDays(-2).ToShortDateString());
            fechas.Add(l.Value.AddDays(1).ToShortDateString());
            fechas.Add(l.Value.AddDays(2).ToShortDateString());
            fechas.Add(l.Value.AddDays(-3).ToShortDateString());
            fechas.Add(l.Value.ToShortDateString());

            return this.Json(fechas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult login(string device_id, int legajo)
        {
            return this.Json(oAgentesRN.validarApp(device_id, legajo), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        //[HttpPost]
        public ActionResult LoginExternal(string user, string password, string device_id)
        {
            var clave = EncriptacionSHA1.Encriptar(password);
            var oUsuario = new UsuariosAD();
            var x = oUsuario.LoginExternal(user, clave).ToList();

            if (x.Count > 0)
            {
                var u = x.FirstOrDefault();
                var agenteApp = oAgentes.GetAgentesApp(u.Persona);

                var agente = oAgentes.ObtenerPorId(agenteApp.Id);
                agente.Device_Id = device_id;
                agente.AppActivo = true;
                oAgentes.Actualizar(agente);

                return this.Json(agenteApp, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (WebSecurity.Login(user, password))
                {
                    var usgp = oUsuario.ObtenerPorUsuario(user);
                    var agenteApp = oAgentes.GetAgentesApp(usgp.Persona);

                    var agente = oAgentes.ObtenerPorId(agenteApp.Id);
                    agente.Device_Id = device_id;
                    agente.AppActivo = true;
                    oAgentes.Actualizar(agente);

                    return this.Json(agenteApp, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return this.Json(new { Id = 0 }, JsonRequestBehavior.AllowGet);
                }
            }

        }

        public ActionResult Image(string imagen)
        {
            var dir = Server.MapPath("/Files/Perfiles");
            var path = Path.Combine(dir, imagen + ".jpg");
            return base.File(path, "image/jpeg");
        }

        public JsonResult login2(string device_id, int legajo)
        {
            return this.Json(oAgentesRN.validarApp2(device_id, legajo), JsonRequestBehavior.AllowGet);
        }

        public JsonResult updateToken(string device_id, string token)
        {
            return this.Json(oAgentesRN.UpdateToken(device_id, token), JsonRequestBehavior.AllowGet);
        }

        public JsonResult MisLicencias(string device_id, int agente, int licencia, int anio)
        {
            return this.Json(oAgentesRN.MisLicencias(device_id, agente, licencia, anio), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Funcionarios()
        {
            return this.Json(oAgentes.GetFuncionarios(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgenteDisponible(int agente)
        {
            var disponible = oAgentes.agenteConLicencia(agente);

            return this.Json(disponible.con_licencia, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ResumenOrganismo(int organismo)
        {
            return this.Json(this.oOrganismosRN.ResumenDeLicencias(organismo), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LicenciasPendientes(string device_id, int organismo)
        {
            return this.Json(oAgentesRN.LicenciasPendientes(device_id, organismo), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaldoLicencias(string device_id, int agente)
        {
            return this.Json(oAgentesRN.SaldoLicencias(device_id, agente), JsonRequestBehavior.AllowGet);
        }

        public JsonResult MisLicenciasSolicitadas(string device_id, int agente, bool aprobada)
        {
            return Json(oAgentesRN.MisLicenciasSolicitadas(device_id, agente, aprobada), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AprobarLicencia(string device_id, int licencia, int agente)
        {
            var res = oAgentesRN.AprobarLicencia(licencia, agente);

            //if (res.state)
            //{
            //    this.sendPushNotification("Una licencia solicitada ha sido aprobada", res.id);
            //}

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DesaprobarLicencia(string device_id, int licencia, int agente)
        {
            var res = oAgentesRN.DesaprobarLicencia(device_id, licencia, agente);

            //if (res.state)
            //{
            //    this.sendPushNotification("Una licencia solicitada ha sido desaprobada", res.id);
            //}

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult deviceEnabled2(string device_id)
        {

            var res = new Result();

            var agenteapp = this.oAgentes.deviceEnabled2(device_id);

            if (agenteapp != null)
            {
                res.state = true;
                res.message = "Dispositivo habilitado";
                res.exception = "";
            }
            else
            {
                res.state = false;
                res.message = "Dispositivo deshabilitado";
                res.exception = "El dispositivo " + device_id + " no está habilitado";
            }

            return this.Json(agenteapp, JsonRequestBehavior.AllowGet);

        }

        public JsonResult deviceEnabled(string device_id)
        {

            var res = new Result();

            if (this.oAgentesRN.deviceEnabled(device_id))
            {
                res.state = true;
                res.message = "Dispositivo habilitado";
                res.exception = "";
            }
            else
            {
                res.state = false;
                res.message = "Dispositivo deshabilitado";
                res.exception = "El dispositivo " + device_id + " no está habilitado";
            }

            return this.Json(res, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> test_api2()
        {

            var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXJtb3ZpbCIsIm5iZiI6MTU0MzIzOTMxMSwiZXhwIjoxNTQzMjQxMTExLCJpYXQiOjE1NDMyMzkzMTEsImlzcyI6Imh0dHA6Ly9jYXB0dXJhcy5mb3JvcGF0YWdvbmljby5nb2IuYXIvcmViZWxkaWFzLmFwaSIsImF1ZCI6Imh0dHA6Ly9jYXB0dXJhcy5mb3JvcGF0YWdvbmljby5nb2IuYXIvcmViZWxkaWFzLmFwaSJ9.C2FAbX8ZNL_ZtnvlsEp7dbsrWJMSGCxWUPPkGZKfaNo";
            using (var client = new HttpClient())
            {
                var url = "http://capturas.foropatagonico.gob.ar/Rebeldias.API/api/rebeldiaspersona/37699971";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var response = await client.GetStringAsync(url);
                var x = 2;
            }

            return View();
        }

        public ActionResult ConfirmarYPasar(string token, int pasar_a) {

            try
            {
                var lic = oLicenciasRN.ObtenerPorToken(token);

                var viene_de = 0;

                var aprobaciones = oLicenciasRN.GetAprobaciones(lic.Id);
                if (aprobaciones.Count > 0)
                {
                    var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                    aprobacion.Aprobado = true;
                    viene_de = aprobacion.AgenteAprueba;
                    aprobacion.FechaAprobado = DateTime.Now;
                    oLicenciasRN.ActualizarAprobacion(aprobacion);

                    var ag = oAgentes.ObtenerPorId(aprobacion.AgenteAprueba);
                    ag.AgenteSolicitudLicenciaDefault = pasar_a;
                    oAgentes.Actualizar(ag);

                }

                var nueva_aprobacion = new LicenciasAgentesAprobaciones()
                {
                    Licencia = lic.Id,
                    FechaAlta = DateTime.Now,
                    AgenteAprueba = pasar_a,
                    Aprobado = false,
                };

                oLicenciasRN.GuardarAprobacion(nueva_aprobacion);

                var a = oAgentesRN.ObtenerPorId(lic.AgenteRRHH.Value);

                var lr = new LicenciasResult()
                {
                    Id = lic.Id,
                    Agente = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.Trim(),
                    Aprobada = false,
                    Licencia = lic.Licencias.Descripcion,
                    Desde = lic.FechaDesde,
                    Hasta = lic.FechaHasta.Value,                    
                    cargo = lic.Nombramientos.Cargos.Descripcion,
                    organismo = lic.Nombramientos.Organismos.Descripcion,
                    Subrogante = lic.SubroganteRRHH,
                    viene_de = viene_de
                };

                new MailController().SolicitudDeLicencia(lr, pasar_a, token).Deliver();

                return this.Json(new { state = true, message = "La licencia ha sido confirmada y pasada" }, JsonRequestBehavior.AllowGet);
            
            }
            catch (Exception e) {

                return this.Json(new { state = false, message = "La licencia no ha podido ser confirmada" }, JsonRequestBehavior.AllowGet);
            
            }
            
        }

        public ActionResult CancelarSolicitud(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);            

            if (!lic.FechaAprobada.HasValue) {

                var lr = new LicenciasResult()
                {
                    Agente = lic.AgenteRRHHs.Personas.Apellidos.TrimEnd() + ", " + lic.AgenteRRHHs.Personas.Nombres.Trim(),
                    Aprobada = false,
                    Licencia = lic.Licencias.Descripcion,
                    Desde = lic.FechaDesde,
                    Hasta = lic.FechaHasta.Value,
                    Subrogante = lic.Subrogante,
                    cargo = lic.Nombramientos.Cargos.Descripcion,
                    organismo = lic.Nombramientos.Organismos.Descripcion
                };

                if (lic.SubroganteRRHH.HasValue && lic.SubroganteAprobadaFecha.HasValue)
                {
                    new MailController().SolicitudDeLicenciaCancelada(lr, lic.SubroganteRRHH.Value, token).Deliver();
                }

                new MailController().SolicitudDeLicenciaCancelada(lr, lic.AgenteAprobada.Value, token).Deliver();

                oLicenciasRN.EliminarDeBD(lic.Id);

                return this.Json(new { state = true, message = "Su solicitud ha sido cancelada satisfactoriamente" }, JsonRequestBehavior.AllowGet);

            }


            ViewBag.Token = token;
            return RedirectToAction("ok", "home", new { area = "", mensaje = "", token = token });
        }


        public ActionResult Pre_Aprobar(string token)
        {
            ViewBag.Token = token;
            return RedirectToAction("ok", "home", new { area = "", mensaje = "", token = token });
        }

        public ActionResult Pre_Desaprobar(string token)
        {
            ViewBag.Token = token;
            return RedirectToAction("ok_desaprobar", "home", new { area = "", mensaje = "", token = token });
        }

        public ActionResult Pre_Desaprobar_Subrogancia(string token)
        {
            ViewBag.Token = token;
            return RedirectToAction("ok_desaprobar_subrogancia", "home", new { area = "", mensaje = "", token = token });
        }

        public ActionResult Pre_Aprobar_Subrogancia(string token)
        {
            ViewBag.Token = token;
            return RedirectToAction("ok_aprobar_subrogancia", "home", new { area = "", mensaje = "", token = token });
        }


        public ActionResult Aprobar(string token)
        {
            var agentesAprueban = new List<int> {155, 129, 168, 517, 2983, 526, 4279, 889, 37, 478, 682};
            var licenciasParticulares = new List<int> { 7, 24, 47 };


            var lic = oLicenciasRN.ObtenerPorToken(token);

            if (!lic.Aprobada)
            {

                string error = db.ControlarLicencia(0, lic.AgenteRRHH.Value, lic.Licencia, lic.FechaDesde, lic.FechaHasta.Value);

                if (error.Length == 0)
                {
                    var aprobaciones = oLicenciasRN.GetAprobaciones(lic.Id);
                    // no es una licencias particular ni ordinaria
                    if (!licenciasParticulares.Contains(lic.Licencia)) {
                        var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                        if (!agentesAprueban.Contains(aprobacion.AgenteAprueba)) {
                            return RedirectToAction("error", "home", new { area = "", error = "No está autorizado a aprobar esta licencia. Por favor realice el pase al Organismo o Funcionario correspondiente" });
                        }
                    }

                    lic.Aprobada = true;
                    //lic.AgenteAprobada = agente;
                    //lic.Token = null;
                    lic.FechaAprobada = DateTime.Now;
                    lic.Observaciones = "Aprobada desde Web";
                    lic.Activa = true;
                    lic.SinEfecto = false;
                    lic.FechaEliminacion = null;

                    //LICENCIA ORDINARIA
                    if (lic.Licencias.CodigoRRHH == 1)
                    {
                        var saldos = this.oLicenciasOrdinarias.ObtenerPorAgente(lic.AgenteRRHH.Value).ToList();
                        int dias = (int)((lic.FechaHasta.Value - lic.FechaDesde).TotalDays) + 1;

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
                    oLicenciasRN.Actualizar(lic);
                    
                    if (aprobaciones.Count > 0) {
                        var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                        aprobacion.Aprobado = true;
                        aprobacion.FechaAprobado = DateTime.Now;
                        oLicenciasRN.ActualizarAprobacion(aprobacion);
                    }

                    try
                    {
                        new MailController().ConfirmacionDeAprobacionDeLicencia(lic, lic.AgenteRRHH.Value, token).Deliver();

                        var a = oAgentes.ObtenerPorId(lic.AgenteRRHH.Value);
                        switch (a.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargo)
                        {
                            case 43:
                            case 44:
                            case 45:
                                var supl = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                                var emailJurisdiccionales = System.Configuration.ConfigurationManager.AppSettings["Email.Jurisdiccionales.Licencias"];
                                var emailRemuneraciones = System.Configuration.ConfigurationManager.AppSettings["Email.Remuneraciones.Licencias"];
                                var emailRRHH = System.Configuration.ConfigurationManager.AppSettings["Email.RRHH.Licencias"];
                                new MailController().LicenciaJuezDePaz(lic, lic.AgenteRRHH.Value, token, emailJurisdiccionales, "Secretaría de Servicios Jurisdiccionales").Deliver();
                                new MailController().LicenciaJuezDePaz(lic, lic.AgenteRRHH.Value, token, emailRRHH, "Secretaría de Recursos Humanos").Deliver();

                                if (supl.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Grupo == 5)
                                    new MailController().LicenciaJuezDePaz(lic, lic.AgenteRRHH.Value, token, emailRemuneraciones, "Secretaría de Economía y Finanzas").Deliver();
                                break;
                            default:
                                break;
                        }

                        if (lic.SubroganteRRHH.HasValue) {
                            var subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);
                            
                            if (!string.IsNullOrEmpty(subrogante.Email))
                                new MailController().ConfirmacionLicenciaSubrogante(lic, subrogante.Id, token).Deliver();
                        }

                    }
                    catch (Exception e) {

                    }

                    return RedirectToAction("ok", "home", new { area = "", mensaje = "Ha APROBADO la licencia" });
                }
                else {
                    return RedirectToAction("error", "home", new { area ="", error = error });
                }
            }
            else {
                return RedirectToAction("error", "home", new { area = "", error ="La licencia ya está aprobada/desaprobada" });
            }
            
        }

        public ActionResult AprobarAjax(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);
            var agentesAprueban = new List<int> { 155, 129, 168, 517, 2983, 526, 4279, 889, 37, 478, 682 };
            var licenciasParticulares = new List<int> { 7, 24, 47 };

            if (!lic.Aprobada)
            {

                string error = db.ControlarLicencia(0, lic.AgenteRRHH.Value, lic.Licencia, lic.FechaDesde, lic.FechaHasta.Value);

                if (error.Length == 0)
                {
                    var aprobaciones = oLicenciasRN.GetAprobaciones(lic.Id);
                    // no es una licencias particular ni ordinaria
                    if (!licenciasParticulares.Contains(lic.Licencia))
                    {
                        var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                        if (!agentesAprueban.Contains(aprobacion.AgenteAprueba))
                        {
                            return this.Json(new { state = false, message = "No está autorizado a aprobar licencias del tipo : " + lic.Licencias.Descripcion.Trim() + ". Por favor confirme y pase a Secretaría de RRHH." }, JsonRequestBehavior.AllowGet);
                        }
                    }


                    lic.Aprobada = true;
                    //lic.AgenteAprobada = agente;
                    //lic.Token = null;
                    lic.FechaAprobada = DateTime.Now;
                    lic.Observaciones = "Aprobada desde Web";
                    lic.Activa = true;
                    lic.SinEfecto = false;
                    lic.FechaEliminacion = null;

                    //LICENCIA ORDINARIA
                    if (lic.Licencias.CodigoRRHH == 1)
                    {
                        var saldos = this.oLicenciasOrdinarias.ObtenerPorAgente(lic.AgenteRRHH.Value).ToList();
                        int dias = (int)((lic.FechaHasta.Value - lic.FechaDesde).TotalDays) + 1;

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
                    oLicenciasRN.Actualizar(lic);

                    // var aprobaciones = oLicenciasRN.GetAprobaciones(lic.Id);
                    if (aprobaciones.Count > 0)
                    {
                        var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                        aprobacion.Aprobado = true;
                        aprobacion.FechaAprobado = DateTime.Now;
                        oLicenciasRN.ActualizarAprobacion(aprobacion);
                    }

                    try
                    {
                        new MailController().ConfirmacionDeAprobacionDeLicencia(lic, lic.AgenteRRHH.Value, token).Deliver();

                        var a = oAgentes.ObtenerPorId(lic.AgenteRRHH.Value);
                        switch (a.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargo)
                        {
                            case 43:
                            case 44:
                            case 45:
                                var supl = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                                var emailJurisdiccionales = System.Configuration.ConfigurationManager.AppSettings["Email.Jurisdiccionales.Licencias"];
                                var emailRemuneraciones = System.Configuration.ConfigurationManager.AppSettings["Email.Remuneraciones.Licencias"];
                                var emailRRHH = System.Configuration.ConfigurationManager.AppSettings["Email.RRHH.Licencias"];
                                new MailController().LicenciaJuezDePaz(lic, lic.AgenteRRHH.Value, token, emailJurisdiccionales, "Secretaría de Servicios Jurisdiccionales").Deliver();
                                new MailController().LicenciaJuezDePaz(lic, lic.AgenteRRHH.Value, token, emailRRHH, "Secretaría de Recursos Humanos").Deliver();

                                if (supl.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Grupo == 5)
                                    new MailController().LicenciaJuezDePaz(lic, lic.AgenteRRHH.Value, token, emailRemuneraciones, "Secretaría de Economía y Finanzas").Deliver();
                                break;
                            default:
                                break;
                        }

                        if (lic.SubroganteRRHH.HasValue)
                        {
                            var subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                            if (!string.IsNullOrEmpty(subrogante.Email))
                                new MailController().ConfirmacionLicenciaSubrogante(lic, subrogante.Id, token).Deliver();
                        }

                        //if (lic.SubroganteRRHH.HasValue)
                        //{
                        //    var subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                        //    if (!string.IsNullOrEmpty(subrogante.Email))
                        //        new MailController().ConfirmacionLicenciaSubrogante(lic, subrogante.Id, token).Deliver();
                        //}

                    }
                    catch (Exception e)
                    {

                    }

                    return Json(new { result = true, message = "Se ha APROBADO la licencia satisfactoriamente"}, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, message = error }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { result = false, message = "Error. Esta solicitud ya ha sido aprobada o desaprobada anteriormente" }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Aprobar_Web(int id)
        {
            var lic = oLicenciasRN.ObtenerPorId(id);

            var agentesAprueban = new List<int> { 155, 129, 168, 517, 2983, 526, 4279, 889, 37, 478, 682 };
            var licenciasParticulares = new List<int> { 7, 24, 47 };

            if (!lic.Aprobada)
            {

                string error = db.ControlarLicencia(0, lic.AgenteRRHH.Value, lic.Licencia, lic.FechaDesde, lic.FechaHasta.Value);

                if (error.Length == 0)
                {

                    var aprobaciones = oLicenciasRN.GetAprobaciones(lic.Id);
                    // no es una licencias particular ni ordinaria
                    if (!licenciasParticulares.Contains(lic.Licencia))
                    {
                        var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                        if (!agentesAprueban.Contains(aprobacion.AgenteAprueba))
                        {
                            return this.Json(new { state = false, message = "No está autorizado a aprobar licencias del tipo : "+lic.Licencias.Descripcion.Trim() + ". Por favor confirme y pase a Secretaría de RRHH." }, JsonRequestBehavior.AllowGet);
                        }
                    }

                    lic.Aprobada = true;
                    //lic.AgenteAprobada = agente;
                    //lic.Token = null;
                    lic.FechaAprobada = DateTime.Now;
                    lic.Observaciones = "Aprobada desde Web";
                    lic.Activa = true;
                    lic.SinEfecto = false;
                    lic.FechaEliminacion = null;

                    //LICENCIA ORDINARIA
                    if (lic.Licencias.CodigoRRHH == 1)
                    {
                        var saldos = this.oLicenciasOrdinarias.ObtenerPorAgente(lic.AgenteRRHH.Value).ToList();
                        int dias = (int)((lic.FechaHasta.Value - lic.FechaDesde).TotalDays) + 1;

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
                    oLicenciasRN.Actualizar(lic);

                    // var aprobaciones = oLicenciasRN.GetAprobaciones(lic.Id);
                    if (aprobaciones.Count > 0)
                    {
                        var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                        aprobacion.Aprobado = true;
                        aprobacion.FechaAprobado = DateTime.Now;
                        oLicenciasRN.ActualizarAprobacion(aprobacion);
                    }

                    try
                    {
                        new MailController().ConfirmacionDeAprobacionDeLicencia(lic, lic.AgenteRRHH.Value, lic.Token).Deliver();

                        var a = oAgentes.ObtenerPorId(lic.AgenteRRHH.Value);
                        switch (a.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargo)
                        {
                            case 43:
                            case 44:
                            case 45:
                                var supl = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                                var emailJurisdiccionales = System.Configuration.ConfigurationManager.AppSettings["Email.Jurisdiccionales.Licencias"];
                                var emailRemuneraciones = System.Configuration.ConfigurationManager.AppSettings["Email.Remuneraciones.Licencias"];
                                var emailRRHH = System.Configuration.ConfigurationManager.AppSettings["Email.RRHH.Licencias"];
                                new MailController().LicenciaJuezDePaz(lic, lic.AgenteRRHH.Value, lic.Token, emailJurisdiccionales, "Secretaría de Servicios Jurisdiccionales").Deliver();
                                new MailController().LicenciaJuezDePaz(lic, lic.AgenteRRHH.Value, lic.Token, emailRRHH, "Secretaría de Recursos Humanos").Deliver();

                                if (supl.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Grupo == 5)
                                    new MailController().LicenciaJuezDePaz(lic, lic.AgenteRRHH.Value, lic.Token, emailRemuneraciones, "Secretaría de Economía y Finanzas").Deliver();
                                break;
                            default:
                                break;
                        }

                        if (lic.SubroganteRRHH.HasValue)
                        {
                            var subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                            if (!string.IsNullOrEmpty(subrogante.Email))
                                new MailController().ConfirmacionLicenciaSubrogante(lic, subrogante.Id, lic.Token).Deliver();
                        }

                    }
                    catch (Exception e)
                    {

                    }
                   
                    return this.Json(new { state = true, message = "La licencia ha sido aprobada satisfactoriamente" }, JsonRequestBehavior.AllowGet);
                
                
                }
                else
                {
                    return this.Json(new { state = false, message = "La licencia no ha podido validarse: " + error }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return this.Json(new { state = false, message = "La licencia ya está aprobada" }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Desaprobar_Subrogante_web(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);

            if (!lic.SubroganteAprobada && lic.FechaDesde > DateTime.Now)
            {

                lic.SubroganteAprobada = false;
                lic.SubroganteAprobadaFecha = DateTime.Now;

                var agente_subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                var email = lic.AgenteRRHHs.Email;
                var funcionario = lic.AgenteRRHHs.Personas.Apellidos + ", " + lic.AgenteRRHHs.Personas.Nombres;
                var subrogante = agente_subrogante.Personas.Apellidos + ", " + agente_subrogante.Personas.Nombres;

                var organismo = lic.AgenteRRHHs.Nombramientos.Where(x => !x.FechaDeBaja.HasValue).FirstOrDefault().Organismos;

                lic.Observaciones = "Subrogante: " + subrogante;

                oLicenciasRN.Actualizar(lic);

                var lr = new LicenciasResult()
                {
                    Agente = lic.AgenteRRHHs.Personas.Apellidos.TrimEnd() + ", " + lic.AgenteRRHHs.Personas.Nombres.Trim(),
                    Aprobada = false,
                    Licencia = lic.Licencias.Descripcion,
                    Desde = lic.FechaDesde,
                    Id_Cargo = lic.Nombramientos.Cargo,
                    Hasta = lic.FechaHasta.Value,
                    Subrogante = lic.Subrogante
                };

                new MailController().RechazoSubrogante(lic, email, funcionario, subrogante, token).Deliver();
                return this.Json(new { state = true, message = "La subrogancia/suplencia ha sido rechazada satisfactoriamente" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return this.Json(new { state = true, message = "La subrogancia/suplencia ya ha sido rechazada anteriormente" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Desaprobar_Subrogante(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);

            if (!lic.SubroganteAprobada && lic.FechaDesde > DateTime.Now)
            {

                lic.SubroganteAprobada = false;
                lic.SubroganteAprobadaFecha = DateTime.Now;

                var agente_subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                var email = lic.AgenteRRHHs.Email;
                var funcionario = lic.AgenteRRHHs.Personas.Apellidos + ", " + lic.AgenteRRHHs.Personas.Nombres;
                var subrogante = agente_subrogante.Personas.Apellidos + ", " + agente_subrogante.Personas.Nombres;

                var organismo = lic.AgenteRRHHs.Nombramientos.Where(x => !x.FechaDeBaja.HasValue).FirstOrDefault().Organismos;

                lic.Observaciones = "Subrogante: " + subrogante;

                oLicenciasRN.Actualizar(lic);

                var lr = new LicenciasResult()
                {
                    Agente = lic.AgenteRRHHs.Personas.Apellidos.TrimEnd() + ", " + lic.AgenteRRHHs.Personas.Nombres.Trim(),
                    Aprobada = false,
                    Licencia = lic.Licencias.Descripcion,
                    Desde = lic.FechaDesde,
                    Hasta = lic.FechaHasta.Value,
                    Subrogante = lic.Subrogante
                };

                //new MailController().RechazoSubrogante2(lr, email, funcionario, subrogante, token).Deliver();
                new MailController().RechazoSubrogante(lic, agente_subrogante.Id, token).Deliver();
                return RedirectToAction("ok_subrogante", "home", new { area = "", mensaje = "Ha rechazado la subrogancia/suplencia" });

            }
            else
            {
                return RedirectToAction("error", "home", new { area = "", error = "La subrogancia/suplencia ya fue aceptada/denegada" });
            }
        }


        public ActionResult Desaprobar_SubroganteAjax(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);

            if (!lic.SubroganteAprobada && lic.FechaDesde > DateTime.Now)
            {

                lic.SubroganteAprobada = false;
                lic.SubroganteAprobadaFecha = DateTime.Now;

                var agente_subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                var email = lic.AgenteRRHHs.Email;
                var funcionario = lic.AgenteRRHHs.Personas.Apellidos + ", " + lic.AgenteRRHHs.Personas.Nombres;
                var subrogante = agente_subrogante.Personas.Apellidos + ", " + agente_subrogante.Personas.Nombres;

                var organismo = lic.AgenteRRHHs.Nombramientos.Where(x => !x.FechaDeBaja.HasValue).FirstOrDefault().Organismos;

                lic.Observaciones = "Subrogante: " + subrogante;

                oLicenciasRN.Actualizar(lic);

                var lr = new LicenciasResult()
                {
                    Agente = lic.AgenteRRHHs.Personas.Apellidos.TrimEnd() + ", " + lic.AgenteRRHHs.Personas.Nombres.Trim(),
                    Aprobada = false,
                    Licencia = lic.Licencias.Descripcion,
                    Desde = lic.FechaDesde,
                    Hasta = lic.FechaHasta.Value,
                    Subrogante = lic.Subrogante
                };

                //new MailController().RechazoSubrogante2(lr, email, funcionario, subrogante, token).Deliver();
                new MailController().RechazoSubrogante(lic, agente_subrogante.Id, token).Deliver();
                return this.Json(new { state = true, message = "La subrogancia/suplencia ha sido rechazada satisfactoriamente" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return this.Json(new { state = false, message = "Error. La subrogancia/suplencia no ha podido ser rechazada" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Aprobar_Subrogante_web(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);

            if (!lic.SubroganteAprobada)
            {

                lic.SubroganteAprobada = true;
                lic.SubroganteAprobadaFecha = DateTime.Now;

                var agente_subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                var email = "";
                var funcionario = lic.AgenteRRHHs.Personas.Apellidos + ", " + lic.AgenteRRHHs.Personas.Nombres;
                var subrogante = agente_subrogante.Personas.Apellidos + ", " + agente_subrogante.Personas.Nombres;
                int? agente_aprueba = null;

                var organismo = lic.AgenteRRHHs.Nombramientos.Where(x => !x.FechaDeBaja.HasValue).FirstOrDefault().Organismos;

                var organismo_destino = "";

                if (lic.AgenteAprobada.HasValue)
                {
                    var agente_aprobada = oAgentes.ObtenerPorId(lic.AgenteAprobada.Value);
                    email = agente_aprobada.Email;
                    agente_aprueba = agente_aprobada.Id;
                    organismo_destino = agente_aprobada.Personas.Apellidos.Trim() + ", " + agente_aprobada.Personas.Nombres.Trim();
                }
                else
                {
                    if (organismo.UnidadOrganizacionRRHH == 2)
                    {
                        email = (System.Configuration.ConfigurationManager.AppSettings["Email.Procuracion.Licencias"]).ToString();
                        organismo_destino = "Procuración";
                    }
                    else
                    {
                        email = (System.Configuration.ConfigurationManager.AppSettings["Email.Administracion.Licencias"]).ToString();
                        organismo_destino = "Dirección General de Administración";
                    }
                }
                lic.Observaciones = "Subrogante: " + subrogante;

                oLicenciasRN.Actualizar(lic);

                var lr = new LicenciasResult()
                {
                    Agente = lic.AgenteRRHHs.Personas.Apellidos.TrimEnd() + ", " + lic.AgenteRRHHs.Personas.Nombres.Trim(),
                    Aprobada = false,
                    Licencia = lic.Licencias.Descripcion,
                    Desde = lic.FechaDesde,
                    Hasta = lic.FechaHasta.Value,
                    Subrogante = lic.SubroganteRRHH,
                    cargo = lic.Nombramientos.Cargos.Descripcion,
                    Id_Cargo = lic.Nombramientos.Cargo,
                    organismo = lic.Nombramientos.Organismos.Descripcion,
                    agente_aprueba = agente_aprueba
                };

                new MailController().SolicitudDeLicenciaFuncionario(lr, email, funcionario, subrogante, organismo_destino, token).Deliver();
                return Json(new { result = true, message = "Se ha APROBADO la subrogancia/suplencia satisfactoriamente" }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("ok_subrogante", "home", new { area = "", mensaje = "Ha aceptado la subrogancia" });

            }
            else
            {
                return Json(new { result = false, message = "Ha ocurrido un error al aprobar la subrogancia/suplencia" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Aprobar_Subrogante(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);

            if (!lic.SubroganteAprobada )
            {

                lic.SubroganteAprobada = true;
                lic.SubroganteAprobadaFecha = DateTime.Now;

                var agente_subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                var email = "";
                var funcionario = lic.AgenteRRHHs.Personas.Apellidos + ", " + lic.AgenteRRHHs.Personas.Nombres;
                var subrogante = agente_subrogante.Personas.Apellidos + ", " + agente_subrogante.Personas.Nombres;
                int? agente_aprueba = null;

                var organismo = lic.AgenteRRHHs.Nombramientos.Where(x => !x.FechaDeBaja.HasValue).FirstOrDefault().Organismos;

                var organismo_destino = "";

                if (lic.AgenteAprobada.HasValue)
                {
                    var agente_aprobada = oAgentes.ObtenerPorId(lic.AgenteAprobada.Value);
                    email = agente_aprobada.Email;
                    agente_aprueba = agente_aprobada.Id;
                    organismo_destino = agente_aprobada.Personas.Apellidos.Trim() + ", " + agente_aprobada.Personas.Nombres.Trim();
                }
                else
                {
                    if (organismo.UnidadOrganizacionRRHH == 2)
                    {
                        email = (System.Configuration.ConfigurationManager.AppSettings["Email.Procuracion.Licencias"]).ToString();
                        organismo_destino = "Procuración";
                    }
                    else
                    {
                        email = (System.Configuration.ConfigurationManager.AppSettings["Email.Administracion.Licencias"]).ToString();
                        organismo_destino = "Dirección General de Administración";
                    }
                }
                lic.Observaciones = "Subrogante: " + subrogante;

                oLicenciasRN.Actualizar(lic);

                var lr = new LicenciasResult()
                {
                    Agente = lic.AgenteRRHHs.Personas.Apellidos.TrimEnd() + ", " + lic.AgenteRRHHs.Personas.Nombres.Trim(),
                    Aprobada = false,
                    Licencia = lic.Licencias.Descripcion,
                    Desde = lic.FechaDesde,
                    Hasta = lic.FechaHasta.Value,
                    Subrogante = lic.SubroganteRRHH,
                    cargo = lic.Nombramientos.Cargos.Descripcion,
                    Id_Cargo = lic.Nombramientos.Cargo,
                    organismo = lic.Nombramientos.Organismos.Descripcion,
                    agente_aprueba = agente_aprueba
                };

                new MailController().SolicitudDeLicenciaFuncionario(lr, email, funcionario, subrogante, organismo_destino, token).Deliver();
                return RedirectToAction("ok_subrogante", "home", new { area = "", mensaje = "Ha aceptado la subrogancia/suplencia" });

            }
            else {
                return RedirectToAction("error", "home", new { area = "", error = "La subrogancia/suplencia ya fue aceptada/denegada" });
            }           
        }

        public ActionResult Aprobar_SubroganteAjax(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);

            if (!lic.SubroganteAprobada)
            {

                lic.SubroganteAprobada = true;
                lic.SubroganteAprobadaFecha = DateTime.Now;

                var agente_subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                var email = "";
                var funcionario = lic.AgenteRRHHs.Personas.Apellidos + ", " + lic.AgenteRRHHs.Personas.Nombres;
                var subrogante = agente_subrogante.Personas.Apellidos + ", " + agente_subrogante.Personas.Nombres;
                int? agente_aprueba = null; 

                var organismo = lic.AgenteRRHHs.Nombramientos.Where(x => !x.FechaDeBaja.HasValue).FirstOrDefault().Organismos;

                var organismo_destino = "";

                if (lic.AgenteAprobada.HasValue)
                {
                    var agente_aprobada = oAgentes.ObtenerPorId(lic.AgenteAprobada.Value);
                    email = agente_aprobada.Email;
                    organismo_destino = agente_aprobada.Personas.Apellidos.Trim() + ", " + agente_aprobada.Personas.Nombres.Trim();
                    agente_aprueba = agente_aprobada.Id;
                }
                else
                {
                    if (organismo.UnidadOrganizacionRRHH == 2)
                    {
                        email = (System.Configuration.ConfigurationManager.AppSettings["Email.Procuracion.Licencias"]).ToString();
                        organismo_destino = "Procuración";
                    }
                    else
                    {
                        email = (System.Configuration.ConfigurationManager.AppSettings["Email.Administracion.Licencias"]).ToString();
                        organismo_destino = "Dirección General de Administración";
                    }
                }
                lic.Observaciones = "Subrogante: " + subrogante;

                oLicenciasRN.Actualizar(lic);

                var lr = new LicenciasResult()
                {
                    Agente = lic.AgenteRRHHs.Personas.Apellidos.TrimEnd() + ", " + lic.AgenteRRHHs.Personas.Nombres.Trim(),
                    Aprobada = false,
                    Licencia = lic.Licencias.Descripcion,
                    Desde = lic.FechaDesde,
                    Hasta = lic.FechaHasta.Value,
                    Subrogante = lic.SubroganteRRHH,
                    Id_Cargo = lic.Nombramientos.Cargo,
                    cargo = lic.Nombramientos.Cargos.Descripcion,
                    organismo = lic.Nombramientos.Organismos.Descripcion,
                    agente_aprueba = agente_aprueba
                };

                new MailController().SolicitudDeLicenciaFuncionario(lr, email, funcionario, subrogante, organismo_destino, token).Deliver();
                return Json(new { result = true, message = "Se ha APROBADO la subrogancia/suplencia satisfactoriamente" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { result = false, message = "Ocurrió un error al aprobar la subrogancia/suplencia" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult TestEmailConfirmation(string token)
        {

            var lic = oLicenciasRN.ObtenerPorToken(token);
            new MailController().ConfirmacionDeAprobacionDeLicencia(lic, lic.AgenteRRHH.Value, token).Deliver();
            return View("Aprobada", lic);

        }

        public ActionResult Desaprobar(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);

            if (!lic.Aprobada)
            {

                lic.Aprobada = false;
                //lic.Token = null;
                lic.FechaAprobada = DateTime.Now;
                lic.Observaciones = "Desaprobada desde Web";
                lic.Activa = true;
                lic.SinEfecto = false;

                oLicenciasRN.Actualizar(lic);


                var aprobaciones = oLicenciasRN.GetAprobaciones(lic.Id);
                if (aprobaciones.Count > 0)
                {
                    var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                    aprobacion.Aprobado = true;
                    aprobacion.FechaAprobado = DateTime.Now;
                    oLicenciasRN.ActualizarAprobacion(aprobacion);
                }

                try
                {
                    new MailController().ConfirmacionDeDesaprobacionDeLicencia(lic, lic.AgenteRRHH.Value, token).Deliver();

                    if (lic.Subrogante.HasValue)
                    {
                        var subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                        if (!string.IsNullOrEmpty(subrogante.Email))
                            new MailController().ConfirmacionLicenciaSubroganteDesaprobada(lic, subrogante.Id, token).Deliver();
                    }

                }
                catch (Exception e)
                {

                }

                return RedirectToAction("ok", "home", new { area = "", mensaje = "Ha RECHAZADO la licencia" });
            }
            else {
                return RedirectToAction("error", "home", new { area = "", error = "La licencia ya se encuentra aprobada" });
            }
        }


        public ActionResult DesaprobarAjax(string token)
        {
            var lic = oLicenciasRN.ObtenerPorToken(token);

            if (!lic.Aprobada)
            {

                lic.Aprobada = false;
                //lic.Token = null;
                lic.FechaAprobada = DateTime.Now;
                lic.Observaciones = "Desaprobada desde Web";
                lic.Activa = true;
                lic.SinEfecto = false;

                oLicenciasRN.Actualizar(lic);


                var aprobaciones = oLicenciasRN.GetAprobaciones(lic.Id);
                if (aprobaciones.Count > 0)
                {
                    var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                    aprobacion.Aprobado = false;
                    aprobacion.FechaAprobado = DateTime.Now;
                    oLicenciasRN.ActualizarAprobacion(aprobacion);
                }

                try
                {
                    new MailController().ConfirmacionDeDesaprobacionDeLicencia(lic, lic.AgenteRRHH.Value, token).Deliver();

                    if (lic.Subrogante.HasValue)
                    {
                        var subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                        if (!string.IsNullOrEmpty(subrogante.Email))
                            new MailController().ConfirmacionLicenciaSubroganteDesaprobada(lic, subrogante.Id, token).Deliver();
                    }

                }
                catch (Exception e)
                {

                }

                return Json(new { result = true, message = "Se ha RECHAZADO la licencia satisfactoriamente" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, message = "La solicitud ha sido previamente aprobada/desaprobada" }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Desaprobar_Web(int id)
        {
            var lic = oLicenciasRN.ObtenerPorId(id);

            if (!lic.Aprobada)
            {

                lic.Aprobada = false;
               // lic.Token = null;
                lic.FechaAprobada = DateTime.Now;
                lic.Observaciones = "Desaprobada desde Web";
                lic.Activa = true;
                lic.SinEfecto = false;

                oLicenciasRN.Actualizar(lic);

                var aprobaciones = oLicenciasRN.GetAprobaciones(lic.Id);
                if (aprobaciones.Count > 0)
                {
                    var aprobacion = aprobaciones.Where(x => !x.Aprobado && !x.FechaAprobado.HasValue).FirstOrDefault();
                    aprobacion.Aprobado = false;
                    aprobacion.FechaAprobado = DateTime.Now;
                    oLicenciasRN.ActualizarAprobacion(aprobacion);
                }

                try
                {
                    new MailController().ConfirmacionDeDesaprobacionDeLicencia(lic, lic.AgenteRRHH.Value, lic.Token).Deliver();

                    if (lic.Subrogante.HasValue)
                    {
                        var subrogante = oAgentes.ObtenerPorId(lic.SubroganteRRHH.Value);

                        if (!string.IsNullOrEmpty(subrogante.Email))
                            new MailController().ConfirmacionLicenciaSubroganteDesaprobada(lic, subrogante.Id, lic.Token).Deliver();
                    }

                }
                catch (Exception e)
                {

                }

                return this.Json(new { state = true, message = "La licencia ha sido desaprobada" }, JsonRequestBehavior.AllowGet);


            }
            else
            {
                return this.Json(new { state = false, message = "La licencia se encuentra previamente aprobada" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult solicitarLicencia(int agente, string sdesde, string shasta, int licencia,
            int nombramiento, int idsuperior, int? subrogante, int? agenteaprueba,
            int? pasar_a_agente, bool dga, int? certificado1, int? certificado2)
        {

            var LicenciasMedicas = new List<int>() { 8, 9, 10, 11, 12, 49, 46 };

            var oNombramientos = new NombramientosAD();

            string error = "";
            var res = new Result();
            DateTime desde = DateTime.Parse(sdesde);
            DateTime hasta = DateTime.Parse(shasta);
            Agentes a;
            LicenciasRef l;
            LicenciasResult lr = new LicenciasResult();
            string token = "";
            Nombramientos n;

            if (subrogante.HasValue && subrogante.Value == agente) {
                res.exception = "Se está intentando realizar una solicitud donde el subrogante/suplente y solicitante es la misma persona";
                res.message = "Error. El subrogante/suplente no puede ser la misma persona que el solicitante";
                res.state = false;
                return Json(res, JsonRequestBehavior.AllowGet);
            }

            if (subrogante.HasValue && agenteaprueba.HasValue && agenteaprueba.Value == subrogante.Value && !dga)
            {
                res.exception = "Se está intentando realizar una solicitud donde el subrogante/suplente y agente que aprueba es la misma persona";
                res.message = "Error. El subrogante/suplente no puede ser la misma persona que el agente que aprueba la solicitud";
                res.state = false;
                return Json(res, JsonRequestBehavior.AllowGet);
            }

            if (agenteaprueba.HasValue && agenteaprueba.Value == agente)
            {
                res.exception = "Se está intentando realizar una solicitud donde el solicitante y agente que aprueba es la misma persona";
                res.message = "Error. El solicitante no puede ser la misma persona que el agente que aprueba la solicitud";
                res.state = false;
                return Json(res, JsonRequestBehavior.AllowGet);
            }
               
            //if ((desde > hasta) || (desde.Date < DateTime.Now.Date)) {
            //     res.exception = "La fecha de inicio no puede ser anterior al día de la fecha";
            //     res.message = "La fecha de inicio no puede ser anterior al día de la fecha";
            //     res.state = false;
            //     return Json(res, JsonRequestBehavior.AllowGet);
            //}

            idsuperior = agenteaprueba > 0 ? agenteaprueba.Value : idsuperior;

            if (dga && !SessionHelper.es_MP)
                idsuperior = oNombramientos.ObtenerAdministrador().Id;
            
            if (dga && SessionHelper.es_MP)
                idsuperior = oNombramientos.ObtenerProcurador().Id;

            if (subrogante.HasValue) {

                var en_licencia = oAgentes.agenteConLicenciaEnFechas(subrogante.Value, desde, hasta);
                if (en_licencia.con_licencia) {
                    res.exception = "El subrogante se encuentra con licencia en el período solicitado";
                    res.message = "El subrogante se encuentra con licencia en el período solicitado";
                    res.state = false;
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
            }

            try
            {
                a = oAgentesRN.ObtenerPorId(agente);
                l = oLicenciasRefRN.ObtenerPorId(licencia);
                error = oLicenciasRN.ControlarInicioDeLicencia(0, agente, licencia, desde, hasta);
                n = oNombramientos.ObtenerPorId(nombramiento);
                token = Guid.NewGuid().ToString();

                if (error.Length == 0)
                {
                    a.AgenteSolicitudLicenciaDefault = agenteaprueba;
                    LicenciasAgente la = new LicenciasAgente()
                    {
                        AgenteRRHH = agente,
                        FechaDesde = desde,
                        FechaHasta = hasta,
                        Aprobada = false,
                        Estado = "OK",
                        Activa = false,
                        //FechaEliminacion = DateTime.Now,
                        Licencia = licencia,
                        UsuarioAlta = 431,
                        FechaAlta = DateTime.Now,
                        FechaModificacion = DateTime.Now,
                        UsuarioModifica = 431,
                        SinEfecto = false,
                        Nombramiento = nombramiento,
                        SolicitadaPorApp = true,
                        Token = token,
                        SubroganteRRHH = subrogante ?? null,
                        AgenteAprobada = idsuperior,
                        Certificado = certificado1,
                        Certificado2 = certificado2,
                        ApruebaReconocimiento = LicenciasMedicas.Contains(licencia)
                    };

                    oLicenciasRN.Guardar(la);

                    var licencias_aprobaciones = new LicenciasAgentesAprobaciones()
                    {
                        AgenteAprueba = idsuperior,
                        Aprobado = LicenciasMedicas.Contains(licencia),
                        FechaAlta = DateTime.Now,
                        Licencia = la.Id,
                        FechaAprobado = LicenciasMedicas.Contains(licencia) ? (DateTime?)DateTime.Now : null //Si es una carpeta médica marcamos como pasada a Reconomiento Médico
                    };

                    oLicenciasRN.GuardarAprobacion(licencias_aprobaciones);

                    if (LicenciasMedicas.Contains(licencia)) {

                        var circ = a.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Circunscripcion;

                        licencias_aprobaciones = new LicenciasAgentesAprobaciones()
                        {
                            AgenteAprueba = circ == 2 ? 447 : 1099,
                            Aprobado = false,
                            FechaAlta = DateTime.Now,
                            Licencia = la.Id                           
                        };

                        oLicenciasRN.GuardarAprobacion(licencias_aprobaciones);
                    }                    

                    lr = new LicenciasResult()
                    {
                        Agente = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.Trim(),
                        Aprobada = false,
                        Id_Cargo = n.Cargo,
                        Licencia = l.Descripcion,
                        Subrogante = subrogante ?? null,
                        Desde = desde,
                        Hasta = hasta,
                        cargo = n.Cargos.Descripcion,
                        organismo = n.Organismos.Descripcion,
                        Id = la.Id
                    };

                    res.state = true;
                    res.id = la.Id;
                    res.message = "La solicitud se realizó satisfactoriamente";
                    res.exception = "";
                }
                else
                {
                    res.state = false;
                    res.id = -1;
                    res.message = error;
                    res.exception = "";
                }
            }
            catch (Exception e)
            {
                res.state = false;
                res.message = "No se ha podido realizar la solicitud de licencia";
                res.exception = e.Message;
                res.id = 0;
            }
            finally {
                idsuperior = agenteaprueba > 0 ? agenteaprueba.Value : idsuperior;

                var ag = oAgentes.ObtenerPorId(agente);
                ag.AgenteSolicitudLicenciaDefault = idsuperior;
                oAgentes.Actualizar(ag);
            }

            if (string.IsNullOrEmpty(error))
            {
                try
                {
                    if (!subrogante.HasValue)
                        new MailController().SolicitudDeLicencia(lr, idsuperior, token).Deliver();
                    else
                        new MailController().SolicitudDeSubrogante(lr, subrogante.Value, token).Deliver();
                }
                catch (Exception e)
                {
                    res.message += " pero hubo un problema al enviar email de notificación.";
                }
            }

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult uploadImageProfile(int agente)
        {
            int id = 0;

            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        continue;
                    string savedFileName = Path.Combine(Server.MapPath("~/Files/Perfiles"), Path.GetFileName(hpf.FileName));
                    hpf.SaveAs(savedFileName);

                    Imagenesrrhh f = new Imagenesrrhh();
                    f.Nombre = hpf.FileName;
                    f.Imagen = "Files/Perfiles/" + hpf.FileName;
                    f.Categoria = 5;
                    f.Agente = agente;
                    f.FechaDeCarga = DateTime.Now;
                    f.FechaUltimaActualizacion = DateTime.Now;
                    f.Usuario = 4130;

                    this.oImagenes.Guardar(f);

                    id = f.Id;
                }

                return this.Json(new Result { state = true, exception = "", id = id, message = "La imagen ha sido actualizada" });
            }
            catch (Exception e)
            {
                return this.Json(new Result { state = false, exception = e.Message, id = id, message = "Ha ocurrido un error actualizando la imagen" });
            }

        }

        public JsonResult actualizarDatosDeContacto(int agente, string email, string domicilio, string telefono)
        {
            try
            {
                var a = oAgentes.ObtenerPorId(agente);
                a.Email = email;
                a.Domicilio = domicilio;
                a.Telefono = telefono;
                a.FechaActualizaContactoApp = DateTime.Now;

                oAgentes.Actualizar(a);

                return this.Json(new Result { state = true, exception = "", message = "Sus datos de contacto se actualizaron" });
            }
            catch (Exception ex)
            {
                return this.Json(new Result { state = false, exception = ex.Message, message = "Los datos de contacto no han podido actualizarse" });
            }
        }

        [HttpPost]
        public JsonResult uploadImageIncidencia()
        {
            int id = 0;

            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        continue;
                    string savedFileName = Path.Combine(Server.MapPath("~/Files/Incidencias"), Path.GetFileName(hpf.FileName));
                    hpf.SaveAs(savedFileName);
                }

                return this.Json(new Result { state = true, exception = "", id = id, message = "La imagen ha sido actualizada" });
            }
            catch (Exception e)
            {
                return this.Json(new Result { state = false, exception = e.Message, id = id, message = "Ha ocurrido un error actualizando la imagen" });
            }

        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            oAgentesRN.Dispose();

            oCargosRefRN.Dispose();

            oPersonasRN.Dispose();

            base.Dispose(disposing);
        }

    } //fin de clase
}
