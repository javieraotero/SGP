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
	public class FeriasRefController : Controller
	{
        private FeriasRefRN oFeriasRefRN = new FeriasRefRN();
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<FeriasRefView> getFeriasRefGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oFeriasRefRN.ObtenerParaGrilla(), dataTableParam, a => new FeriasRefView()
            {	
			Id=a.Id,	
			Descripcion=a.Descripcion,	
			FechaDesde=a.FechaDesde,	
			FechaHasta=a.FechaHasta,	
			Anio=a.Anio,	
			Paso1=a.Paso1,	
			Paso2=a.Paso2,});
        }

		public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(FeriasRef feriasref)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    feriasref.DiaDesde = feriasref.FechaDesde.Day;
                    feriasref.DiaHasta = feriasref.FechaHasta.Day;
                    feriasref.MesDesde = feriasref.FechaDesde.Month;
                    feriasref.MesHasta = feriasref.FechaHasta.Month;
                    feriasref.Anio = feriasref.FechaDesde.Year;
                    feriasref.Paso1 = false;
                    feriasref.Paso2 = false;
                    oFeriasRefRN.Guardar(feriasref);
                    return Json(new object[] { true, String.Format("Se guardo FeriasRef satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar FeriasRef" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar FeriasRef" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(FeriasRef feriasref)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oFeriasRefRN.Actualizar(feriasref);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente FeriasRef") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse FeriasRef" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse FeriasRef" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
		
            FeriasRef feriasref = oFeriasRefRN.ObtenerPorId(id);
            if (feriasref == null)
            {
                return HttpNotFound();
            }
            return View(feriasref);
        }

        [HttpPost]
        public ActionResult AsignarJuzgadosDePag(int id)
        {

            try
            {
                int feriasref = oFeriasRefRN.AsignacionDeFeriaJuzgadosDePaz(id);
                return Json(new object[] { true, "Se registraron " + feriasref.ToString() + " agentes a la feria." });
            }
            catch (Exception e) {
                return Json(new object[] { false, "No se pudo registrar la feria a Juzgados de Paz" });
            }
       
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oFeriasRefRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el feriasref" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oFeriasRefRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oFeriasRefRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oFeriasRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
