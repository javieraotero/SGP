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

namespace SSO.SGP.Web.Areas.Suministros.Controllers
{
	public class ArticulosDeSuministrosController : Controller
	{
        private ArticulosDeSuministrosRN oArticulosDeSuministrosRN = new ArticulosDeSuministrosRN();
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<ArticulosDeSuministrosView> getArticulosDeSuministrosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oArticulosDeSuministrosRN.ObtenerParaGrilla(), dataTableParam, a => new ArticulosDeSuministrosView()
            {	
			Id=a.Id,	
			Nombre=a.Nombre,	
			Codigo=a.Codigo,	
			StockMinimo=a.StockMinimo,	
			Stock=a.Stock,	
			UltimoCosto=a.UltimoCosto,	
			//FechaUltimoPrecio=a.FechaUltimoPrecio,	
            });
        }

		public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ArticulosDeSuministros articulosdesuministros)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oArticulosDeSuministrosRN.Guardar(articulosdesuministros);
                    return Json(new object[] { true, String.Format("Se guardo ArticulosDeSuministros satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar ArticulosDeSuministros" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar ArticulosDeSuministros" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(ArticulosDeSuministros articulosdesuministros)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oArticulosDeSuministrosRN.Actualizar(articulosdesuministros);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente ArticulosDeSuministros") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse ArticulosDeSuministros" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse ArticulosDeSuministros" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
		
            ArticulosDeSuministros articulosdesuministros = oArticulosDeSuministrosRN.ObtenerPorId(id);
            if (articulosdesuministros == null)
            {
                return HttpNotFound();
            }
            return View(articulosdesuministros);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oArticulosDeSuministrosRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el articulosdesuministros" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oArticulosDeSuministrosRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonAutocomplete(string term)
        {
            var res = from x in this.oArticulosDeSuministrosRN.JsonT(term)
                      select new { label = x.Nombre, id = x.Id, stock = x.Stock };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oArticulosDeSuministrosRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oArticulosDeSuministrosRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
