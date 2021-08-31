using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.ReglasDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Results;
using SSO.SGP.EntidadesDeNegocio;

namespace SSO.SGP.Web.Areas.AppWeb.Controllers
{
    public class InicioController : Controller
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
        private BDEntities db = new BDEntities();

        public ActionResult Index(string device_id)
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

            ViewBag.Device_Id = device_id;

            return View();
        }

        public ActionResult Login(string device_id, string legajo, string afiliado) {

           // Agentes a = oAgentesRN

            return View();
        }
  

    }
}
