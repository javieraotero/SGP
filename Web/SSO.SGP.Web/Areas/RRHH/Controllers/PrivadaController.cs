using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.ReglasDeNegocio;

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
    public class PrivadaController : Controller
    {
        //
        // GET: /RRHH/Privada/

        private LicenciasAgenteRN oLicencias = new LicenciasAgenteRN();

        public ActionResult Aprobada(string token)
        {
            var l = oLicencias.ObtenerPorToken(token);
            l.Token = null;

            oLicencias.Actualizar(l);

            return View(l);
        }

        public ActionResult Desaprobada(string token)
        {
            var l = oLicencias.ObtenerPorToken(token);
            l.Token = null;

            oLicencias.Actualizar(l);

            return View(l);
        }

    }
}
