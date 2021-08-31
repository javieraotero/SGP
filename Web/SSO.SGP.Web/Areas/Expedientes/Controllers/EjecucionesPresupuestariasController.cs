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

namespace SSO.SGP.Web.Areas.Expedientes.Controllers
{
	public class EjecucionesPresupuestariasController : Controller
	{
        private EjecucionesPresupuestariasRN oEjecucionesPresupuestariasRN = new EjecucionesPresupuestariasRN();
		private PartidasPresupuestariasRN oPartidasPresupuestariasRN = new PartidasPresupuestariasRN();
        private UnidadesDeOrganizacionRefRN oUnidadesDeOrganizacionRN = new UnidadesDeOrganizacionRefRN();
		
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public ActionResult CrearAnual()
        {
            ViewBag.UnidadesDeOrganizacionRef = new SelectList(oUnidadesDeOrganizacionRN.ObtenerTodo().ToList(), "Id", "Nombre");
            return View();
        }

        public DataTablesResult<EjecucionesPresupuestariasView> getEjecucionesPresupuestariasGrilla(DataTablesParam dataTableParam, int anio)
        {
            return DataTablesResult.Create(this.oEjecucionesPresupuestariasRN.ObtenerParaGrilla(), dataTableParam, a => new EjecucionesPresupuestariasView()
            {	
			Id=a.Id,	
			Anio=a.Anio,	
			PartidaPresupuestaria=a.PartidaPresupuestaria,	
			CreditoActual=a.CreditoActual,	
			CreditoDisponible=a.CreditoDisponible,	
			CreditoHabilitado=a.CreditoHabilitado,	
			MontoPreventiva=a.MontoPreventiva,	
			MontoCompromiso=a.MontoCompromiso,	
			MontoOrdenadoAPagar=a.MontoOrdenadoAPagar	
            });
        }

		public ActionResult Crear()
        {
			ViewBag.PartidasPresupuestarias = new SelectList(oPartidasPresupuestariasRN.ObtenerTodo().ToList(), "Id", "NumeroDePartida");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(EjecucionesPresupuestarias ejecucionespresupuestarias)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oEjecucionesPresupuestariasRN.Guardar(ejecucionespresupuestarias);
                    return Json(new object[] { true, String.Format("Se guardo EjecucionesPresupuestarias satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar EjecucionesPresupuestarias" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar EjecucionesPresupuestarias" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(EjecucionesPresupuestarias ejecucionespresupuestarias)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oEjecucionesPresupuestariasRN.Actualizar(ejecucionespresupuestarias);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente EjecucionesPresupuestarias") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse EjecucionesPresupuestarias" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse EjecucionesPresupuestarias" });
            }

        }

        [HttpPost]
        public ActionResult CrearAnual(int anio, int unidad_de_organizacion) {

            var errores = oEjecucionesPresupuestariasRN.CrearAnual(anio, unidad_de_organizacion);

            return this.Json(errores, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.PartidasPresupuestarias = new SelectList(oPartidasPresupuestariasRN.ObtenerTodo().ToList(), "Id", "NumeroDePartida");
			
		
            EjecucionesPresupuestarias ejecucionespresupuestarias = oEjecucionesPresupuestariasRN.ObtenerPorId(id);
            if (ejecucionespresupuestarias == null)
            {
                return HttpNotFound();
            }
            return View(ejecucionespresupuestarias);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oEjecucionesPresupuestariasRN.Eliminar(id, SessionHelper.IdUsuario.Value);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el ejecucionespresupuestarias" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oEjecucionesPresupuestariasRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oEjecucionesPresupuestariasRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oEjecucionesPresupuestariasRN.Dispose();
			
				oPartidasPresupuestariasRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
