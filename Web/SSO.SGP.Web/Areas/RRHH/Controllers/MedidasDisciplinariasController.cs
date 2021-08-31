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
	public class MedidasDisciplinariasController : Controller
	{
        private MedidasDisciplinariasRN oMedidasDisciplinariasRN = new MedidasDisciplinariasRN();

		public ActionResult Index(int agente)
        {
            ViewBag.Agente = agente;
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<MedidasDisciplinariasView> getMedidasDisciplinariasGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oMedidasDisciplinariasRN.ObtenerParaGrilla(), dataTableParam, a => new MedidasDisciplinariasView()
            {	
			Id=a.Id,	
			Agente=a.Agente,	
			Fecha=a.Fecha,	
			Causa=a.Causa,});
        }

		public ActionResult Crear(int agente)
        {
            ViewBag.Agente = agente;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(MedidasDisciplinarias medidasdisciplinarias)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oMedidasDisciplinariasRN.Guardar(medidasdisciplinarias);
                    return Json(new object[] { true, String.Format("Se guardo MedidasDisciplinarias satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar MedidasDisciplinarias" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar MedidasDisciplinarias" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(MedidasDisciplinarias medidasdisciplinarias)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oMedidasDisciplinariasRN.Actualizar(medidasdisciplinarias);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente MedidasDisciplinarias") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse MedidasDisciplinarias" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse MedidasDisciplinarias" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
		
            MedidasDisciplinarias medidasdisciplinarias = oMedidasDisciplinariasRN.ObtenerPorId(id);
            if (medidasdisciplinarias == null)
            {
                return HttpNotFound();
            }
            return View(medidasdisciplinarias);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oMedidasDisciplinariasRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el medidasdisciplinarias" });
            }
        }
		
		public JsonResult JsonT(int agente)
        {
            var res = from x in this.oMedidasDisciplinariasRN.JsonT(agente)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oMedidasDisciplinariasRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oMedidasDisciplinariasRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
