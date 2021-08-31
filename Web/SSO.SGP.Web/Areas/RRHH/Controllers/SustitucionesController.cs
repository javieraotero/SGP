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
	public class SustitucionesController : Controller
	{
        private SustitucionesRN oSustitucionesRN = new SustitucionesRN();
		private AgentesRN oAgentesRN = new AgentesRN();
		
		private CargosRefRN oCargosRefRN = new CargosRefRN();
		
		private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();
		
		public ActionResult Index(int agente)
        {
            ViewBag.Agente = agente;
            ViewBag.Nombre = "Modificar";
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<SustitucionesView> getSustitucionesGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oSustitucionesRN.ObtenerParaGrilla(), dataTableParam, a => new SustitucionesView()
            {	
			Id=a.Id,	
			Agente=a.Agente,	
			Acuerdo=a.Acuerdo,	
			Desde=a.Desde,	
			Hasta=a.Hasta,	
			Motivo=a.Motivo,	
			Cargo=a.Cargo,	
			Organismo=a.Organismo,});
        }

		public ActionResult Crear(int agente)
        {
            ViewBag.Agente = agente;
			ViewBag.CargosRef = new SelectList(oCargosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
			//ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Sustituciones sustituciones)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oSustitucionesRN.Guardar(sustituciones);
                    return Json(new object[] { true, String.Format("Se guardo Sustituciones satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar Sustituciones" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar Sustituciones" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(Sustituciones sustituciones)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oSustitucionesRN.Actualizar(sustituciones);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente Sustituciones") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse Sustituciones" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse Sustituciones" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.CargosRef = new SelectList(oCargosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");	
		
            Sustituciones sustituciones = oSustitucionesRN.ObtenerPorId(id);
            ViewBag.Organismo = oOrganismosRefRN.ObtenerPorId(sustituciones.Organismo).Descripcion;

            if (sustituciones == null)
            {
                return HttpNotFound();
            }
            return View(sustituciones);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oSustitucionesRN.Eliminar(id);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el sustituciones" });
            }
        }
		
		public JsonResult JsonT(int agente)
        {
            var res = from x in this.oSustitucionesRN.JsonT(agente, true)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oSustitucionesRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oSustitucionesRN.Dispose();
			
				oAgentesRN.Dispose();
			
				oCargosRefRN.Dispose();
			
				oOrganismosRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
