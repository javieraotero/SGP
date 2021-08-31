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
	public class ExpedientesDocumentoADMController : Controller
	{
        private ExpedientesDocumentoadmRN oExpedientesDocumentoADMRN = new ExpedientesDocumentoadmRN();
		private ActuacionesadmRN oActuacionesADMRN = new ActuacionesadmRN();
		
		private UsuariosRN oUsuariosRN = new UsuariosRN();
		
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<ExpedientesDocumentoadmView> getExpedientesDocumentoADMGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oExpedientesDocumentoADMRN.ObtenerParaGrilla(), dataTableParam, a => new ExpedientesDocumentoadmView()
            {	
			Id=a.Id,	
			Persona=a.Persona,	
			Actuacion=a.Actuacion,	
			NombreOriginal=a.NombreOriginal,	
			Extension=a.Extension,	
			Descripcion=a.Descripcion,	
			Usuario=a.Usuario,	
			FechaAlta=a.FechaAlta,	
			Confirmado=a.Confirmado,});
        }

		public ActionResult Crear()
        {
			ViewBag.ActuacionesADM = new SelectList(oActuacionesADMRN.ObtenerTodo().ToList(), "Id", "Id");
			ViewBag.Usuarios = new SelectList(oUsuariosRN.ObtenerTodo().ToList(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ExpedientesDocumentoadm expedientesdocumentoadm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oExpedientesDocumentoADMRN.Guardar(expedientesdocumentoadm);
                    return Json(new object[] { true, String.Format("Se guardo ExpedientesDocumentoADM satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar ExpedientesDocumentoADM" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar ExpedientesDocumentoADM" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(ExpedientesDocumentoadm expedientesdocumentoadm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oExpedientesDocumentoADMRN.Actualizar(expedientesdocumentoadm);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente ExpedientesDocumentoADM") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse ExpedientesDocumentoADM" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse ExpedientesDocumentoADM" });
            }

        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oExpedientesDocumentoADMRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el expedientesdocumentoadm" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oExpedientesDocumentoADMRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oExpedientesDocumentoADMRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oExpedientesDocumentoADMRN.Dispose();
			
				oActuacionesADMRN.Dispose();
			
				oUsuariosRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
