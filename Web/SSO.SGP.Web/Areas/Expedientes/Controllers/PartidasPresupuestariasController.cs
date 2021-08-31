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
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace SSO.SGP.Web.Areas.Expedientes.Controllers
{
	public class PartidasPresupuestariasController : Controller
	{
        private PartidasPresupuestariasRN oPartidasPresupuestariasRN = new PartidasPresupuestariasRN();
		private UnidadesDeOrganizacionRefRN oUnidadesDeOrganizacionRefRN = new UnidadesDeOrganizacionRefRN();
        private DivisionesExtraPresupuestariasAD oDivisiones = new DivisionesExtraPresupuestariasAD();
		
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<PartidasPresupuestariasView> getPartidasPresupuestariasGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oPartidasPresupuestariasRN.ObtenerParaGrilla(), dataTableParam, a => new PartidasPresupuestariasView()
            {	
			Id=a.Id,	
			NumeroDePartida=a.NumeroDePartida,	
			Descripcion=a.Descripcion,	
			Mnemo=a.Mnemo,	
			UnidadDeOrganizacion=a.UnidadDeOrganizacion,	
			Prioridad=a.Prioridad,});
        }

		public ActionResult Crear()
        {
			ViewBag.UnidadesDeOrganizacionRef = new SelectList(oUnidadesDeOrganizacionRefRN.ObtenerTodo().ToList(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(PartidasPresupuestarias partidaspresupuestarias, List<DivisionesExtraPresupuestarias> Divisiones) 
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    if (partidaspresupuestarias.Id == 0)
                        oPartidasPresupuestariasRN.Guardar(partidaspresupuestarias);
                    else
                    {
                        oPartidasPresupuestariasRN.Actualizar(partidaspresupuestarias);
                    }

                    foreach (var d in Divisiones) {
                        if (d.Id == 0) {
                            d.PartidaPresupuestaria = partidaspresupuestarias.Id;
                            oDivisiones.Guardar(d);
                        }
                    }

                    return Json(new object[] { true, String.Format("Se guardo la partida {0} satisfactoriamente", partidaspresupuestarias.NumeroDePartida) });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar la partida presupuestaria" });
                }
            //}
            //else
            //{
            //    return Json(new object[] { false, "No se ha podido guardar PartidasPresupuestarias" });
            //}
        }
	
	
		[HttpPost]
        public ActionResult Editar(PartidasPresupuestarias partidaspresupuestarias)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oPartidasPresupuestariasRN.Actualizar(partidaspresupuestarias);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente PartidasPresupuestarias") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse PartidasPresupuestarias" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse PartidasPresupuestarias" });
            }

        }

        public ActionResult Editar(int id = 0)
        {

            ViewBag.UnidadesDeOrganizacionRef = new SelectList(oUnidadesDeOrganizacionRefRN.ObtenerTodo().ToList(), "Id", "Nombre");
			
		
            PartidasPresupuestarias partidaspresupuestarias = oPartidasPresupuestariasRN.ObtenerPorId(id);
            if (partidaspresupuestarias == null)
            {
                return HttpNotFound();
            }
            return View(partidaspresupuestarias);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oPartidasPresupuestariasRN.Eliminar(id, SessionHelper.IdUsuario.Value);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse la Partida Presupuestaria" });
            }
        }
		
		public JsonResult JsonT(string term)
        {
            var res = from x in this.oPartidasPresupuestariasRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptionsPartidas(string term)
        {
            var res = from x in this.oPartidasPresupuestariasRN.ObtenerOptions(term)
                      select new { label = x.text, id = x.value };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Partidas(int unidad)
        {

            var res = (from x in this.oPartidasPresupuestariasRN.ObtenerPorUnidadDeOrganizacion(unidad)
                       select x).ToList();

            return new JsonNetResult
            {
                Data = res,
                ContentType = "application/json",
                //ContentEncoding  = System.Text.Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            

            //return JsonConvert.SerializeObject(res, Formatting.Indented, new JsonSerializerSettings {
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //  });
            //return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oPartidasPresupuestariasRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oPartidasPresupuestariasRN.Dispose();
			
				oUnidadesDeOrganizacionRefRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase

    public class JsonNetResult : JsonResult
    {
        public JsonNetResult()
        {
            Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
        }

        public JsonSerializerSettings Settings { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("JSON GET is not allowed");

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (this.Data == null)
                return;

            var scriptSerializer = JsonSerializer.Create(this.Settings);

            using (var sw = new StringWriter())
            {
                scriptSerializer.Serialize(sw, this.Data);
                response.Write(sw.ToString());
            }
        }
    }
}
