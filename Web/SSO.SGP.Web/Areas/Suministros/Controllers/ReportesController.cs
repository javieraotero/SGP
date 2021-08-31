using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.ReglasDeNegocio;

namespace SSO.SGP.Web.Areas.Suministros.Controllers
{
    public class ReportesController : Controller
    {

        public ActionResult Articulos()
        {
            return View();
        }

        public ActionResult ConsumoPorArticulo()
        {
            return View();
        }

        public ActionResult Pedido(int pedido)
        {
            ViewBag.Pedido = pedido;
            return View();
        }

        public ActionResult Default() {
            return View();
        }

        public ActionResult ConsumoPorOrganismo()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
