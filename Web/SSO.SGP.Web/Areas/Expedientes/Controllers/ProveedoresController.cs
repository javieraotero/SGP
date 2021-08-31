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
	public class ProveedoresController : Controller
	{
        private ProveedoresRN oProveedoresRN = new ProveedoresRN();
		private FormasDePagoRefRN oFormasDePagoRefRN = new FormasDePagoRefRN();
		
		private TiposCuentasBancariasRefRN oTiposCuentasBancariasRefRN = new TiposCuentasBancariasRefRN();
		
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<ProveedoresView> getProveedoresGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oProveedoresRN.ObtenerParaGrilla(), dataTableParam, a => new ProveedoresView()
            {	
			Id=a.Id,	
			Nombre=a.Nombre,	
			RazonSocial=a.RazonSocial,	
			DomicilioReal=a.DomicilioReal,	
			CodigoPostal=a.CodigoPostal,	
			CUIT=a.CUIT,	
			IngresosBrutos=a.IngresosBrutos,	
			Estado=a.Estado
            });
        }

		public ActionResult Crear()
        {
			ViewBag.FormasDePagoRef = new SelectList(oFormasDePagoRefRN.ObtenerTodo().ToList(), "Id", "Id");
			ViewBag.TiposCuentasBancariasRef = new SelectList(oTiposCuentasBancariasRefRN.ObtenerTodo().ToList(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    proveedores.FechaAlta = DateTime.Now;
                    proveedores.FechaModifica = DateTime.Now;
                    proveedores.UsuarioAlta = SessionHelper.IdUsuario.Value;
                    proveedores.UsuarioModifica = SessionHelper.IdUsuario.Value;
                    oProveedoresRN.Guardar(proveedores);
                    return Json(new object[] { true, String.Format("Se guardo Proveedores satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar Proveedores" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar Proveedores" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oProveedoresRN.Actualizar(proveedores);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente Proveedores") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse Proveedores" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse Proveedores" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.FormasDePagoRef = new SelectList(oFormasDePagoRefRN.ObtenerTodo().ToList(), "Id", "Id");
			
			ViewBag.TiposCuentasBancariasRef = new SelectList(oTiposCuentasBancariasRefRN.ObtenerTodo().ToList(), "Id", "Id");
			
		
            Proveedores proveedores = oProveedoresRN.ObtenerPorId(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }
            return View(proveedores);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oProveedoresRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el proveedores" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oProveedoresRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oProveedoresRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult Autocomplete(string term)
        {
            var res = from x in this.oProveedoresRN.GetAutocomplete(term)
                      select new {label=x.Nombre, id=x.Id, text = x.Nombre, cuit = x.CUIT };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		



	protected override void Dispose(bool disposing)
        {
            oProveedoresRN.Dispose();
			
				oFormasDePagoRefRN.Dispose();
			
				oTiposCuentasBancariasRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
