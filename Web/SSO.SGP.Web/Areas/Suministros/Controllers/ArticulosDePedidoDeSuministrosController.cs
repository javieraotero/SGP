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
	public class ArticulosDePedidoDeSuministrosController : Controller
	{
        private ArticulosDePedidoDeSuministrosRN oArticulosDePedidoDeSuministrosRN = new ArticulosDePedidoDeSuministrosRN();
		private ArticulosDeSuministrosRN oArticulosDeSuministrosRN = new ArticulosDeSuministrosRN();		
		private PedidosDeSuministrosRN oPedidosDeSuministrosRN = new PedidosDeSuministrosRN();
		
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<ArticulosDePedidoDeSuministrosView> getArticulosDePedidoDeSuministrosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oArticulosDePedidoDeSuministrosRN.ObtenerParaGrilla(), dataTableParam, a => new ArticulosDePedidoDeSuministrosView()
            {	
			Id=a.Id,	
			Articulo=a.Articulo,	
			Pedido=a.Pedido,	
			CantidadEntregada=a.CantidadEntregada,	
			Precio=a.Precio,	
			CantidadPedida=a.CantidadPedida,});
        }
		
		public ActionResult Detalle(int id = 0)
        {
            ArticulosDePedidoDeSuministros articulosdepedidodesuministros = oArticulosDePedidoDeSuministrosRN.ObtenerPorId(id);
            if (articulosdepedidodesuministros == null)
            {
                return HttpNotFound();
            }
            return View(articulosdepedidodesuministros);
        }		
	

		public ActionResult Crear()
        {
			ViewBag.ArticulosDeSuministros = new SelectList(oArticulosDeSuministrosRN.ObtenerTodo().ToList(), "Id", "Id");
			ViewBag.PedidosDeSuministros = new SelectList(oPedidosDeSuministrosRN.ObtenerTodo().ToList(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ArticulosDePedidoDeSuministros articulosdepedidodesuministros)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oArticulosDePedidoDeSuministrosRN.Guardar(articulosdepedidodesuministros);
                    return Json(new object[] { true, String.Format("Se guardo ArticulosDePedidoDeSuministros satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar ArticulosDePedidoDeSuministros" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar ArticulosDePedidoDeSuministros" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(ArticulosDePedidoDeSuministros articulosdepedidodesuministros)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oArticulosDePedidoDeSuministrosRN.Actualizar(articulosdepedidodesuministros);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente ArticulosDePedidoDeSuministros") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse ArticulosDePedidoDeSuministros" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse ArticulosDePedidoDeSuministros" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.ArticulosDeSuministros = new SelectList(oArticulosDeSuministrosRN.ObtenerTodo().ToList(), "Id", "Id");
			
			ViewBag.PedidosDeSuministros = new SelectList(oPedidosDeSuministrosRN.ObtenerTodo().ToList(), "Id", "Id");
			
		
            ArticulosDePedidoDeSuministros articulosdepedidodesuministros = oArticulosDePedidoDeSuministrosRN.ObtenerPorId(id);
            if (articulosdepedidodesuministros == null)
            {
                return HttpNotFound();
            }
            return View(articulosdepedidodesuministros);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oArticulosDePedidoDeSuministrosRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el articulosdepedidodesuministros" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oArticulosDePedidoDeSuministrosRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oArticulosDePedidoDeSuministrosRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		

		public ActionResult Eliminar(int id = 0)
        {
            ArticulosDePedidoDeSuministros articulosdepedidodesuministros = oArticulosDePedidoDeSuministrosRN.ObtenerPorId(id);
            if (articulosdepedidodesuministros == null)
            {
                return HttpNotFound();
            }
            return View(articulosdepedidodesuministros);
        }
		
		

	protected override void Dispose(bool disposing)
        {
            oArticulosDePedidoDeSuministrosRN.Dispose();
			
				oArticulosDeSuministrosRN.Dispose();
			
				oPedidosDeSuministrosRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
