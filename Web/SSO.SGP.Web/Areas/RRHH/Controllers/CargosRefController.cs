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
	public class CargosRefController : Controller
	{
        private CargosRefRN oCargosRefRN = new CargosRefRN();
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<CargosRefView> getCargosRefGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oCargosRefRN.ObtenerParaGrilla(), dataTableParam, a => new CargosRefView()
            {	
			Id=a.Id,	
			Descripcion=a.Descripcion,	
			Orden=a.Orden,	
			Grupo=a.Grupo,	
			CodigoRRHH=a.CodigoRRHH,	
			Presupuesto=a.Presupuesto,});
        }

		public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(CargosRef cargosref)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oCargosRefRN.Guardar(cargosref);
                    return Json(new object[] { true, String.Format("Se guardo CargosRef satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar CargosRef" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar CargosRef" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(CargosRef cargosref)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oCargosRefRN.Actualizar(cargosref);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente CargosRef") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse CargosRef" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse CargosRef" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
		
            CargosRef cargosref = oCargosRefRN.ObtenerPorId(id);
            if (cargosref == null)
            {
                return HttpNotFound();
            }
            return View(cargosref);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oCargosRefRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el cargosref" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oCargosRefRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oCargosRefRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oCargosRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
