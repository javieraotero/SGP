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
	public class GrupoFamiliarController : Controller
	{
        private GrupoFamiliarRN oGrupoFamiliarRN = new GrupoFamiliarRN();
		
		private TiposParentescosRefRN oTiposParentescosRefRN = new TiposParentescosRefRN();
		
		public ActionResult Index(int agente)
        {
            ViewBag.Agente = agente;
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<GrupoFamiliarView> getGrupoFamiliarGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oGrupoFamiliarRN.ObtenerParaGrilla(), dataTableParam, a => new GrupoFamiliarView()
            {	
			Id=a.Id,	
			Agente=a.Agente,	
			ApellidosYNombre=a.ApellidosYNombre,	
			FechaDeNacimiento=a.FechaDeNacimiento,	
			Documento=a.Documento,	
			TipoMiembro=a.TipoMiembro,	
			Activo=a.Activo,	
			FechaBaja=a.FechaBaja,	
			FechaAlta=a.FechaAlta,});
        }

		public ActionResult Crear(int agente)
        {
            ViewBag.Agente = agente;
			ViewBag.TiposParentescosRef = new SelectList(oTiposParentescosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(GrupoFamiliar grupofamiliar)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    grupofamiliar.FechaAlta = DateTime.Now;
                    grupofamiliar.Activo = true;
                    oGrupoFamiliarRN.Guardar(grupofamiliar);
                    return Json(new object[] { true, String.Format("Se guardo GrupoFamiliar satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar GrupoFamiliar" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar GrupoFamiliar" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(GrupoFamiliar grupofamiliar)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oGrupoFamiliarRN.Actualizar(grupofamiliar);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente GrupoFamiliar") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse GrupoFamiliar" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse GrupoFamiliar" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.TiposParentescosRef = new SelectList(oTiposParentescosRefRN.ObtenerTodo().ToList(), "Id", "Id");
			
		
            GrupoFamiliar grupofamiliar = oGrupoFamiliarRN.ObtenerPorId(id);
            if (grupofamiliar == null)
            {
                return HttpNotFound();
            }
            return View(grupofamiliar);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oGrupoFamiliarRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el grupofamiliar" });
            }
        }
		
		public JsonResult JsonT(int agente)
        {
            var res = from x in this.oGrupoFamiliarRN.JsonT(agente)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oGrupoFamiliarRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oGrupoFamiliarRN.Dispose();
					
			oTiposParentescosRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
