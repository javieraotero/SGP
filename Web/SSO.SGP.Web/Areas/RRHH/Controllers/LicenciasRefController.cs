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

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
	public class LicenciasRefController : Controller
	{
        private LicenciasRefRN oLicenciasRefRN = new LicenciasRefRN();
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<LicenciasRefView> getLicenciasRefGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oLicenciasRefRN.ObtenerParaGrilla(), dataTableParam, a => new LicenciasRefView()
            {	
			Id=a.Id,	
			Descripcion=a.Descripcion,	
			PorAnio=a.PorAnio,	
			PorLicencia=a.PorLicencia,	
			CodigoRRHH=a.CodigoRRHH,
            PorAgente = a.PorAgente,
            Contexto = a.Contexto});
        }

		public ActionResult Crear()
        {
            ViewBag.UnidadesTemporales = new SelectList(this.oLicenciasRefRN.ObtenerUnidadesTemporales().ToList(), "value", "text");
            ViewBag.UnidadesDeContexto = new SelectList(this.oLicenciasRefRN.ObtenerUnidadesDeContexto().ToList(), "value", "text");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(LicenciasRef licenciasref)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oLicenciasRefRN.Guardar(licenciasref);
                    return Json(new object[] { true, String.Format("Se guardo LicenciasRef satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar LicenciasRef" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar LicenciasRef" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(LicenciasRef licenciasref)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oLicenciasRefRN.Actualizar(licenciasref);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente LicenciasRef") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse LicenciasRef" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse LicenciasRef" });
            }

        }

        public ActionResult Editar(int id = 0)
        {

            ViewBag.UnidadesTemporales = new SelectList(this.oLicenciasRefRN.ObtenerUnidadesTemporales().ToList(), "value", "text");
            ViewBag.UnidadesDeContexto = new SelectList(this.oLicenciasRefRN.ObtenerUnidadesDeContexto().ToList(), "value", "text");
            LicenciasRef licenciasref = oLicenciasRefRN.ObtenerPorId(id);
            if (licenciasref == null)
            {
                return HttpNotFound();
            }
            return View(licenciasref);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oLicenciasRefRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el licenciasref" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oLicenciasRefRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oLicenciasRefRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oLicenciasRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
