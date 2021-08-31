using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.EntidadesDeNegocio;
using Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables;
using SSO.SGP.ReglasDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System;
using System.Data;
using Syncrosoft.Framework.Utils.Logs;

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
	public class AgentesDocenciaController : Controller
	{
        private AgentesDocenciaAD oAgentesDocenciaRN = new AgentesDocenciaAD();
		private AgentesRN oAgentesRN = new AgentesRN();
		
		public ActionResult Index(int id)
        {
            ViewBag.Agente = id;
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<AgentesDocenciaView> getAgentesDocenciaGrilla(DataTablesParam dataTableParam, int agente)
        {
            return DataTablesResult.Create(this.oAgentesDocenciaRN.ObtenerParaGrilla(agente), dataTableParam, a => new AgentesDocenciaView()
            {	
			Id=a.Id,
			Fecha=a.Fecha,	
			Institucion=a.Institucion,	
			CargaHoraria=a.CargaHoraria,	
			HorasCatedra=a.HorasCatedra,	
			HorasSemanales=a.HorasSemanales,	
			Observaciones=a.Observaciones});
        }
		
		public ActionResult Detalle(int id = 0)
        {
            AgentesDocencia agentesdocencia = oAgentesDocenciaRN.ObtenerPorId(id);
            if (agentesdocencia == null)
            {
                return HttpNotFound();
            }
            return View(agentesdocencia);
        }		
	

		public ActionResult Crear(int id)
        {
            ViewBag.Agente = id;
			ViewBag.Agentes = new SelectList(oAgentesRN.ObtenerTodo().ToList(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(AgentesDocencia agentesdocencia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oAgentesDocenciaRN.Guardar(agentesdocencia);
                    return Json(new object[] { true, String.Format("Se guardo AgentesDocencia satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar AgentesDocencia" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar AgentesDocencia" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(AgentesDocencia agentesdocencia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oAgentesDocenciaRN.Actualizar(agentesdocencia);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente AgentesDocencia") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse AgentesDocencia" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse AgentesDocencia" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.Agentes = new SelectList(oAgentesRN.ObtenerTodo().ToList(), "Id", "Id");
			
		
            AgentesDocencia agentesdocencia = oAgentesDocenciaRN.ObtenerPorId(id);
            if (agentesdocencia == null)
            {
                return HttpNotFound();
            }
            return View(agentesdocencia);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oAgentesDocenciaRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el agentesdocencia" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oAgentesDocenciaRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oAgentesDocenciaRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		

		public ActionResult Eliminar(int id = 0)
        {
            AgentesDocencia agentesdocencia = oAgentesDocenciaRN.ObtenerPorId(id);
            if (agentesdocencia == null)
            {
                return HttpNotFound();
            }
            return View(agentesdocencia);
        }
		
		

	protected override void Dispose(bool disposing)
        {
            oAgentesDocenciaRN.Dispose();
			
				oAgentesRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
