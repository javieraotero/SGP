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

namespace SSO.SGP.Web.Controllers
{
	public class ImputacionesContablesController : Controller
	{
        private ImputacionesContablesRN oImputacionesContablesRN = new ImputacionesContablesRN();
		private DivisionesExtraPresupuestariasRN oDivisionesExtraPresupuestariasRN = new DivisionesExtraPresupuestariasRN();
		
		private ExpedientesadmRN oExpedientesADMRN = new ExpedientesadmRN();
        private UnidadesDeOrganizacionRefAD oUnidadDeOrganizacion = new UnidadesDeOrganizacionRefAD();
        private OperacionesContablesRefRN oOperacionesContablesRefRN = new OperacionesContablesRefRN();
        private FacturasAD oFacturas = new FacturasAD();
        private ImputacionesContablesAD oImputacions = new ImputacionesContablesAD();
        private ExpedientesadmAD oExpedientesAD = new ExpedientesadmAD();

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<ImputacionesContablesView> getImputacionesContablesGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oImputacionesContablesRN.ObtenerParaGrilla(), dataTableParam, a => new ImputacionesContablesView()
            {	
			Id=a.Id,	
			ExpedienteAImputar=a.ExpedienteAImputar,	
			Fecha=a.Fecha,	
			UsuarioAlta=a.UsuarioAlta,	
			FechaElimina=a.FechaElimina,	
			Operacion=a.Operacion,	
			ExpedienteIndirecto=a.ExpedienteIndirecto,});
        }

		public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ImputacionesContables imputacionescontables)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oImputacionesContablesRN.Guardar(imputacionescontables);
                    return Json(new object[] { true, String.Format("Se guardo ImputacionesContables satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar ImputacionesContables" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar ImputacionesContables" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(ImputacionesContables imputacionescontables)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oImputacionesContablesRN.Actualizar(imputacionescontables);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente ImputacionesContables") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse ImputacionesContables" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse ImputacionesContables" });
            }

        }

        public ActionResult Sobreafectar(int expediente)
        {
            var f = oExpedientesAD.ObtenerPorId(expediente);
            ViewBag.UnidadDeOrganizacion = new SelectList(oUnidadDeOrganizacion.ObtenerTodo().ToList(), "Id", "Nombre");
            ViewBag.Numero = f.Numero;
            //ViewBag.Importe = f.Importe;
            ViewBag.Id = expediente;
            return View();
        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.ExpedientesADM = new SelectList(oExpedientesADMRN.ObtenerTodo().ToList(), "Id", "Id");
			
			ViewBag.OperacionesContablesRef = new SelectList(oOperacionesContablesRefRN.ObtenerTodo().ToList(), "Id", "Id");
			
			ViewBag.ExpedientesADM = new SelectList(oExpedientesADMRN.ObtenerTodo().ToList(), "Id", "Id");
			
		
            ImputacionesContables imputacionescontables = oImputacionesContablesRN.ObtenerPorId(id);
            if (imputacionescontables == null)
            {
                return HttpNotFound();
            }
            return View(imputacionescontables);
        }


        [HttpPost]
        public ActionResult Sobreafectar(ImputacionesContables imputacion)
        {

            try
            {
                imputacion.Fecha = DateTime.Now;
                imputacion.UsuarioAlta = SessionHelper.IdUsuario.Value;
                imputacion.Operacion = (int)eOperacionesContables.SobreAfectacion;

                foreach (var d in imputacion.ImputacionesContablesDetalle)
                {
                    d.Fecha = DateTime.Now;
                    d.Usuario = SessionHelper.IdUsuario.Value;
                }

                oImputacions.Guardar(imputacion);

                return Json(new object[] { true, String.Format("La sobreafectación se realizó con éxito") });
            }
            catch (Exception e)
            {
                Logger.GrabarExcepcion(e, false);
                return Json(new object[] { false, "No se ha podido guardar la imputación" });
            }

        }


        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oImputacionesContablesRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el imputacionescontables" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oImputacionesContablesRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oImputacionesContablesRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //IMPLEMENTAR la accion Imputar
        public ActionResult Imputar() {
		ViewBag.ExpedientesADM = new SelectList(oExpedientesADMRN.ObtenerTodo().ToList(), "Id", "Id");
			
		ViewBag.DivisionesExtraPresupuestarias = new SelectList(oDivisionesExtraPresupuestariasRN.ObtenerTodo().ToList(), "Id", "Id");
			
	
		return View();
	}

	protected override void Dispose(bool disposing)
        {
            oImputacionesContablesRN.Dispose();
			
				oDivisionesExtraPresupuestariasRN.Dispose();
			
				oExpedientesADMRN.Dispose();
			
				oOperacionesContablesRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
