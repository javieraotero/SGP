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
	public class FeriasAgentesController : Controller
	{
        private FeriasAgentesRN oFeriasAgentesRN = new FeriasAgentesRN();
		private AgentesRN oAgentesRN = new AgentesRN();
        private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();
		private FeriasRefRN oFeriasRefRN = new FeriasRefRN();
		
		public ActionResult Index(int feria, int paso)
        {
            FeriasRef f = oFeriasRefRN.ObtenerPorIdyPaso(feria, paso);
            ViewBag.Paso1 = oFeriasRefRN.ObtenerPorIdyPaso(feria, 1);
            ViewBag.Desde = f.FechaDesde.ToShortDateString();
            ViewBag.Hasta = f.FechaHasta.ToShortDateString();
            ViewBag.IdFeria = feria;
            ViewBag.Paso = paso;
            return View(oOrganismosRefRN.ObtenerTodo().Where(o=>o.Nombramientos.Count > 0).ToList());
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<FeriasAgentesView> getFeriasAgentesGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oFeriasAgentesRN.ObtenerParaGrilla(), dataTableParam, a => new FeriasAgentesView()
            {	
			Id=a.Id,	
			Agente=a.Agente,	
			Feria=a.Feria,	
			Dias=a.Dias,	
			Desde1=a.Desde1,	
			Desde2=a.Desde2,	
			Desde3=a.Desde3,	
			Hasta1=a.Hasta1,	
			Hasta2=a.Hasta2,	
			Hasta3=a.Hasta3,	
			Instancia=a.Instancia
            });
        }

		public ActionResult Crear()
        {
			ViewBag.Agentes = new SelectList(oAgentesRN.ObtenerTodo().ToList(), "Id", "Id");
			ViewBag.FeriasRef = new SelectList(oFeriasRefRN.ObtenerTodo().ToList(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(FeriasAgentes feriasagentes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //oFeriasAgentesRN.Guardar(feriasagentes);
                    return Json(new object[] { true, String.Format("Se guardo FeriasAgentes satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar FeriasAgentes" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar FeriasAgentes" });
            }
        }

        [HttpPost]
        public ActionResult AsignarFeria(int dias, int agente, int feria, DateTime desde1, DateTime? desde2, DateTime? desde3, DateTime hasta1, DateTime? hasta2, DateTime? hasta3, int instancia, int? id, string observaciones, bool sinefecto)
        {
            FeriasAgentes fa;
            int diasc;

            try
            {
                diasc = this.dias(desde1, hasta1, desde2, hasta2, desde3, hasta3);
                if (!id.HasValue)
                {                    
                    fa = new FeriasAgentes
                    {
                        Dias = diasc,
                        Feria = feria,
                        Agente = agente,
                        Desde1 = desde1,
                        Desde2 = desde2,
                        Desde3 = desde3,
                        Hasta1 = hasta1,
                        Hasta2 = hasta2,
                        Hasta3 = hasta3,
                        Instancia = instancia, 
                        Observaciones = observaciones
                    };
                    oFeriasAgentesRN.Guardar(fa, dias, sinefecto);
                }
                else
                {
                    fa = oFeriasAgentesRN.ObtenerPorId(id.Value);
                    int Dias = fa.Dias;
                    fa.Dias = diasc;
                    fa.Desde1 = desde1;
                    fa.Desde2 = desde2;
                    fa.Desde3 = desde3;
                    fa.Hasta1 = hasta1;
                    fa.Hasta2 = hasta2;
                    fa.Hasta3 = hasta3;
                    fa.Observaciones = observaciones;

                    oFeriasAgentesRN.Actualizar(fa, Dias, sinefecto);
                }
                return Json(new object[] { true, "Se asignó la feria al agente", fa.Id });
            }
            catch (Exception e)
            {
                return Json(new object[] { false, "No se ha podido asignar la feria al Agente", e.Message });
            }            

        }


        private int dias(DateTime desde1, DateTime hasta1, DateTime? desde2, DateTime? hasta2, DateTime? desde3, DateTime? hasta3) {

            int r = 0;

            r = (hasta1.Date - desde1.Date).Days + 1;

            if (desde2.HasValue)
                r += (hasta2.Value.Date - desde2.Value.Date).Days + 1;

            if (desde3.HasValue)
                r += (hasta3.Value.Date - desde3.Value.Date).Days + 1;

            return r;
        
        }


        //[HttpPost]
        //public ActionResult Editar(FeriasAgentes feriasagentes)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            oFeriasAgentesRN.Actualizar(feriasagentes, 0);
        //            return Json(new object[] { true, String.Format("Se guardo satisfactoriamente FeriasAgentes") });
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.GrabarExcepcion(ex, false);
        //            return Json(new object[] { false, "No pudo guardarse FeriasAgentes" });
        //        }
        //    }
        //    else
        //    {
        //        return Json(new object[] { false, "No pudo guardarse FeriasAgentes" });
        //    }

        //}

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.Agentes = new SelectList(oAgentesRN.ObtenerTodo().ToList(), "Id", "Id");
			
			ViewBag.FeriasRef = new SelectList(oFeriasRefRN.ObtenerTodo().ToList(), "Id", "Id");
			
		
            FeriasAgentes feriasagentes = oFeriasAgentesRN.ObtenerPorId(id);
            if (feriasagentes == null)
            {
                return HttpNotFound();
            }
            return View(feriasagentes);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oFeriasAgentesRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el feriasagentes" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oFeriasAgentesRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oFeriasAgentesRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oFeriasAgentesRN.Dispose();
			
		    oAgentesRN.Dispose();
			
			oFeriasRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
