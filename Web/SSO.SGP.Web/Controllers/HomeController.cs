using OfficeOpenXml.Packaging.Ionic.Zlib;
using SSO.SGP.AccesoADatos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SSO.SGP.Web.Controllers
{
    public class HomeController : Controller
    {
        private CargosRefAD oCargos = new CargosRefAD();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult ok(string mensaje, string token)
        {
            ViewBag.Message = mensaje;
            ViewBag.Token = token;

            return View();
        }

        public ActionResult ok_desaprobar(string mensaje, string token)
        {
            ViewBag.Message = mensaje;
            ViewBag.Token = token;

            return View();
        }

        public ActionResult ok_desaprobar_subrogancia(string mensaje, string token)
        {
            ViewBag.Message = mensaje;
            ViewBag.Token = token;

            return View();
        }

        public ActionResult ok_aprobar_subrogancia(string mensaje, string token)
        {
            ViewBag.Message = mensaje;
            ViewBag.Token = token;

            return View();
        }

        public ActionResult ok_subrogante(string mensaje, string token)
        {
            ViewBag.Message = mensaje;
            ViewBag.Token = token;

            return View();
        }

        public ActionResult ConfirmarLicencia(string token)
        {
            var oLicencias = new LicenciasAgenteAD();
            var oAgentes = new AgentesAD();
            var lic = oLicencias.ObtenerPorToken(token);

            var a = oAgentes.ObtenerPorId(lic.AgenteRRHH.Value);
           
            var aprobadas = oLicencias.GetAprobaciones(lic.Id);

            if (aprobadas.Where(x => !x.FechaAprobado.HasValue).Count() > 0)
            {
                var ag = oAgentes.ObtenerPorId(aprobadas.FirstOrDefault().AgenteAprueba);

                ViewBag.AgenteDefault = ag.AgenteSolicitudLicenciaDefault;
                ViewBag.Token = token;

                return View();
            }

            return View("error", "Ya ha realizado la confirmación");
        }

        public ActionResult error(String error)
        {
            ViewBag.error = error;

            return View();
        }

        public ActionResult Cargos()
        {
            var m = oCargos.PlantaDePersonal();
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View(m);
        }

        public ActionResult Certificado()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult MiCertificado(long dni)
        {
            var oAgentes = new AgentesAD();
            var certificado = oAgentes.ObtenerCertificadoAgente(dni);

            return View(certificado);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult SubirFoto(HttpPostedFileBase file)
        {
            var oAgentes = new AgentesAD();

            if (file == null) return View();

            Object stragente = Request.Params["agente"];
            Object stremail = Request.Params["email"];

            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + stragente + "-" + file.FileName).ToLower();

            var agente = oAgentes.ObtenerPorId(int.Parse(stragente.ToString()));
            agente.TokenGCM = archivo;
            agente.Email = stremail.ToString();
            agente.CertificadoFechaDesde = DateTime.Now;
            agente.CertificadoValidez = "GENERADO";
            oAgentes.Actualizar(agente);


            file.SaveAs(Server.MapPath("~/Files/Perfiles/" + archivo));

            return RedirectToAction("MiCertificado", "Home", new { dni = agente.Personas.NroDocumento });
        }

        public async Task<string> getHtml(string url) {
            HttpClient _HttpClient = new HttpClient();
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url)))
            {
                request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                request.Headers.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

                using (var response = await _HttpClient.SendAsync(request).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    using (var streamReader = new StreamReader(decompressedStream))
                    {
                        return await streamReader.ReadToEndAsync().ConfigureAwait(false);
                    }
                }
            }
        }
    }
}
