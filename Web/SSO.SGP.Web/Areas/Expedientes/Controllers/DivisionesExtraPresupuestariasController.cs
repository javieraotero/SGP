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
	public class DivisionesExtraPresupuestariasController : Controller
	{
        private DivisionesExtraPresupuestariasRN oDivisionesExtraPresupuestariasRN = new DivisionesExtraPresupuestariasRN();
		private PartidasPresupuestariasRN oPartidasPresupuestariasRN = new PartidasPresupuestariasRN();
		
		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<DivisionesExtraPresupuestariasView> getDivisionesExtraPresupuestariasGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oDivisionesExtraPresupuestariasRN.ObtenerParaGrilla(), dataTableParam, a => new DivisionesExtraPresupuestariasView()
            {	
			Id=a.Id,	
			Nombre=a.Nombre,	
			CodigoCESIDA=a.CodigoCESIDA,	
			PartidaPresupuestaria=a.PartidaPresupuestaria,});
        }

		public ActionResult Crear()
        {
			ViewBag.PartidasPresupuestarias = new SelectList(oPartidasPresupuestariasRN.ObtenerTodo().ToList(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(DivisionesExtraPresupuestarias divisionesextrapresupuestarias)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oDivisionesExtraPresupuestariasRN.Guardar(divisionesextrapresupuestarias);
                    return Json(new object[] { true, String.Format("Se guardo DivisionesExtraPresupuestarias satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar DivisionesExtraPresupuestarias" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar DivisionesExtraPresupuestarias" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(DivisionesExtraPresupuestarias divisionesextrapresupuestarias)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oDivisionesExtraPresupuestariasRN.Actualizar(divisionesextrapresupuestarias);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente DivisionesExtraPresupuestarias") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse DivisionesExtraPresupuestarias" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse DivisionesExtraPresupuestarias" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.PartidasPresupuestarias = new SelectList(oPartidasPresupuestariasRN.ObtenerTodo().ToList(), "Id", "Id");
			
		
            DivisionesExtraPresupuestarias divisionesextrapresupuestarias = oDivisionesExtraPresupuestariasRN.ObtenerPorId(id);
            if (divisionesextrapresupuestarias == null)
            {
                return HttpNotFound();
            }
            return View(divisionesextrapresupuestarias);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oDivisionesExtraPresupuestariasRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el divisionesextrapresupuestarias" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oDivisionesExtraPresupuestariasRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oDivisionesExtraPresupuestariasRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oDivisionesExtraPresupuestariasRN.Dispose();
			
				oPartidasPresupuestariasRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
