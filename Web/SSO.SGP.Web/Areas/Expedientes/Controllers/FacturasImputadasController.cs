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
	public class FacturasImputadasController : Controller
	{
        private FacturasImputadasRN oFacturasImputadasRN = new FacturasImputadasRN();
		private DivisionesExtraPresupuestariasRN oDivisionesExtraPresupuestariasRN = new DivisionesExtraPresupuestariasRN();
		
		private FacturasRN oFacturasRN = new FacturasRN();
		
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<FacturasImputadasView> getFacturasImputadasGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oFacturasImputadasRN.ObtenerParaGrilla(), dataTableParam, a => new FacturasImputadasView()
            {	
			Id=a.Id,	
			Factura=a.Factura,	
			Fecha=a.Fecha,	
			AnioContable=a.AnioContable,	
			Usuario=a.Usuario,	
			FechaElimina=a.FechaElimina,	
			UsuarioElimina=a.UsuarioElimina,});
        }

		public ActionResult Crear()
        {
			ViewBag.Facturas = new SelectList(oFacturasRN.ObtenerTodo().ToList(), "Id", "Id");
			ViewBag.DivisionesExtraPresupuestarias = new SelectList(oDivisionesExtraPresupuestariasRN.ObtenerTodo().ToList(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(FacturasImputadas facturasimputadas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oFacturasImputadasRN.Guardar(facturasimputadas);
                    return Json(new object[] { true, String.Format("Se guardo FacturasImputadas satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar FacturasImputadas" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar FacturasImputadas" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(FacturasImputadas facturasimputadas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oFacturasImputadasRN.Actualizar(facturasimputadas);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente FacturasImputadas") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse FacturasImputadas" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse FacturasImputadas" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.Facturas = new SelectList(oFacturasRN.ObtenerTodo().ToList(), "Id", "Id");
			
		
            FacturasImputadas facturasimputadas = oFacturasImputadasRN.ObtenerPorId(id);
            if (facturasimputadas == null)
            {
                return HttpNotFound();
            }
            return View(facturasimputadas);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oFacturasImputadasRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el facturasimputadas" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oFacturasImputadasRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oFacturasImputadasRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oFacturasImputadasRN.Dispose();
			
				oDivisionesExtraPresupuestariasRN.Dispose();
			
				oFacturasRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
