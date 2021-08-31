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
	public class UnidadesDeOrganizacionRefController : Controller
	{
        private UnidadesDeOrganizacionRefRN oUnidadesDeOrganizacionRefRN = new UnidadesDeOrganizacionRefRN();
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<UnidadesDeOrganizacionRefView> getUnidadesDeOrganizacionRefGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oUnidadesDeOrganizacionRefRN.ObtenerParaGrilla(), dataTableParam, a => new UnidadesDeOrganizacionRefView()
            {	
			    Id=a.Id,	
			    Nombre=a.Nombre
            });
        }
		
		public ActionResult Detalle(int id = 0)
        {
            UnidadesDeOrganizacionRef unidadesdeorganizacionref = oUnidadesDeOrganizacionRefRN.ObtenerPorId(id);
            if (unidadesdeorganizacionref == null)
            {
                return HttpNotFound();
            }
            return View(unidadesdeorganizacionref);
        }		
	

		public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(UnidadesDeOrganizacionRef unidadesdeorganizacionref)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oUnidadesDeOrganizacionRefRN.Guardar(unidadesdeorganizacionref);
                    return Json(new object[] { true, String.Format("Se guardo UnidadesDeOrganizacionRef satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar UnidadesDeOrganizacionRef" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar UnidadesDeOrganizacionRef" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(UnidadesDeOrganizacionRef unidadesdeorganizacionref)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oUnidadesDeOrganizacionRefRN.Actualizar(unidadesdeorganizacionref);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente UnidadesDeOrganizacionRef") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse UnidadesDeOrganizacionRef" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse UnidadesDeOrganizacionRef" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
		
            UnidadesDeOrganizacionRef unidadesdeorganizacionref = oUnidadesDeOrganizacionRefRN.ObtenerPorId(id);
            if (unidadesdeorganizacionref == null)
            {
                return HttpNotFound();
            }
            return View(unidadesdeorganizacionref);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oUnidadesDeOrganizacionRefRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el unidadesdeorganizacionref" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oUnidadesDeOrganizacionRefRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oUnidadesDeOrganizacionRefRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		

		public ActionResult Eliminar(int id = 0)
        {
            UnidadesDeOrganizacionRef unidadesdeorganizacionref = oUnidadesDeOrganizacionRefRN.ObtenerPorId(id);
            if (unidadesdeorganizacionref == null)
            {
                return HttpNotFound();
            }
            return View(unidadesdeorganizacionref);
        }
		
		

	protected override void Dispose(bool disposing)
        {
            oUnidadesDeOrganizacionRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
