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
using System.ComponentModel;

namespace SSO.SGP.Web.Areas.Suministros.Controllers
{
	public class ArticulosDeComprasDeSuministrosController : Controller
	{
        private ArticulosDeComprasDeSuministrosRN oArticulosDeComprasDeSuministrosRN = new ArticulosDeComprasDeSuministrosRN();
		private ArticulosDeSuministrosRN oArticulosDeSuministrosRN = new ArticulosDeSuministrosRN();
		
		private CompraDeSuministrosRN oCompraDeSuministrosRN = new CompraDeSuministrosRN();
		
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<ArticulosDeComprasDeSuministrosView> getArticulosDeComprasDeSuministrosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oArticulosDeComprasDeSuministrosRN.ObtenerParaGrilla(), dataTableParam, a => new ArticulosDeComprasDeSuministrosView()
            {	
			Id=a.Id,	
			Compra=a.Compra,	
			Articulo=a.Articulo,	
			Cantidad=a.Cantidad,	
			Precio=a.Precio,});
        }
		
		public ActionResult Detalle(int id = 0)
        {
            ArticulosDeComprasDeSuministros articulosdecomprasdesuministros = oArticulosDeComprasDeSuministrosRN.ObtenerPorId(id);
            if (articulosdecomprasdesuministros == null)
            {
                return HttpNotFound();
            }
            return View(articulosdecomprasdesuministros);
        }		
	

		public ActionResult Crear()
        {
			ViewBag.CompraDeSuministros = new SelectList(oCompraDeSuministrosRN.ObtenerTodo().ToList(), "Id", "Id");
			ViewBag.ArticulosDeSuministros = new SelectList(oArticulosDeSuministrosRN.ObtenerTodo().ToList(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ArticulosDeComprasDeSuministros articulosdecomprasdesuministros)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oArticulosDeComprasDeSuministrosRN.Guardar(articulosdecomprasdesuministros);
                    return Json(new object[] { true, String.Format("Se guardo ArticulosDeComprasDeSuministros satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar ArticulosDeComprasDeSuministros" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar ArticulosDeComprasDeSuministros" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(ArticulosDeComprasDeSuministros articulosdecomprasdesuministros)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oArticulosDeComprasDeSuministrosRN.Actualizar(articulosdecomprasdesuministros);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente ArticulosDeComprasDeSuministros") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse ArticulosDeComprasDeSuministros" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse ArticulosDeComprasDeSuministros" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.CompraDeSuministros = new SelectList(oCompraDeSuministrosRN.ObtenerTodo().ToList(), "Id", "Id");
			
			ViewBag.ArticulosDeSuministros = new SelectList(oArticulosDeSuministrosRN.ObtenerTodo().ToList(), "Id", "Id");
			
		
            ArticulosDeComprasDeSuministros articulosdecomprasdesuministros = oArticulosDeComprasDeSuministrosRN.ObtenerPorId(id);
            if (articulosdecomprasdesuministros == null)
            {
                return HttpNotFound();
            }
            return View(articulosdecomprasdesuministros);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oArticulosDeComprasDeSuministrosRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el articulosdecomprasdesuministros" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oArticulosDeComprasDeSuministrosRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oArticulosDeComprasDeSuministrosRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		

		public ActionResult Eliminar(int id = 0)
        {
            ArticulosDeComprasDeSuministros articulosdecomprasdesuministros = oArticulosDeComprasDeSuministrosRN.ObtenerPorId(id);
            if (articulosdecomprasdesuministros == null)
            {
                return HttpNotFound();
            }
            return View(articulosdecomprasdesuministros);
        }
		
		
	
	[HttpPost]
    public ActionResult Editable(int pk, string value, string name)
	{
		ArticulosDeComprasDeSuministros obj = oArticulosDeComprasDeSuministrosRN.ObtenerPorId(pk);
        foreach (var item in typeof(ArticulosDeComprasDeSuministros).GetProperties().ToList())
        {
			if (item.Name == name)
			{
				var converter = TypeDescriptor.GetConverter(item.PropertyType);
				var result = converter.ConvertFrom(value);
				item.SetValue(obj, result, null);
			}        
		}
		
		oArticulosDeComprasDeSuministrosRN.Actualizar(obj);
		return Json(new object[] { true, String.Format("Se guardo Elementos satisfactoriamente") });
    }


	protected override void Dispose(bool disposing)
        {
            oArticulosDeComprasDeSuministrosRN.Dispose();
			
				oArticulosDeSuministrosRN.Dispose();
			
				oCompraDeSuministrosRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
