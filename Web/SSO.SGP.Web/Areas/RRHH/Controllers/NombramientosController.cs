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
using System.Collections.Generic;
using SSO.SGP.AccesoADatos;

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
	public class NombramientosController : Controller
	{
        private NombramientosRN oNombramientosRN = new NombramientosRN();
		private CargosRefRN oCargosRefRN = new CargosRefRN();
        private NombramientosMovimientosRN oMovimientosRN = new NombramientosMovimientosRN();		
		private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();		
		private SituacionesDeRevistaRN oSituacionesDeRevistaRN = new SituacionesDeRevistaRN();
        private NombramientosAD oNombramientos = new NombramientosAD();
        private ColaDeMovimientoscesidaAD oColaDeMovimientos = new ColaDeMovimientoscesidaAD();

		public ActionResult Index(int agente)
        {
            ViewBag.Agente = agente;
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<NombramientosView> getNombramientosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oNombramientosRN.ObtenerParaGrilla(), dataTableParam, a => new NombramientosView()
            {	
			    Id=a.Id,	
			    Agente=a.Agente,	
			    FechaDeAlta=a.FechaDeAlta,	
			    FechaDeBaja=a.FechaDeBaja,	
			    Motivo=a.Motivo,	
			    Organismo=a.Organismo,	
			    Cargo=a.Cargo,	
			    SituacionRevista=a.SituacionRevista,	
			    FechaFinContrato=a.FechaFinContrato,	
			    FechaFinSustitucion=a.FechaFinSustitucion,	
			    FechaRenuncia=a.FechaRenuncia,	
			    FechaPaseAPlanta=a.FechaPaseAPlanta,	
			    FechaUltimoAscenso=a.FechaUltimoAscenso,});
        }

		public ActionResult Crear(int agente)
        {
			//ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.CargosRef = new SelectList(oCargosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerRRHH().ToList(), "Id", "Descripcion");
            //ViewBag.SituacionesDeRevista = new SelectList(oSituacionesDeRevistaRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Agente = agente;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Nombramientos nombramiento)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    oNombramientosRN.Guardar(nombramiento);
                    //var nombramientos = oNombramientosRN.ObtenerTodo().ToList();

                    //var cat_cesida = nombramientos.Where(nom => nom.Cargo == nombramiento.Cargo && nom.Categoria_Cesida != null).FirstOrDefault().Categoria_Cesida;
                    //var org_cesida = nombramientos.Where(nom => nom.Organismo == nombramiento.Organismo && nom.Ubicacion_Cesida != null).FirstOrDefault().Ubicacion_Cesida;

                    var sr = "";

                    switch (nombramiento.SituacionRevista)
                    {
                        case "C":
                            sr = "C";
                            break;
                        case "P":
                            sr = "P";
                            break;
                    };

                    //var c = new ColaDeMovimientoscesida()
                    //{
                    //    Agente = nombramiento.Agente,
                    //    Fecha = DateTime.Now,
                    //    FechaDesde = nombramiento.FechaDeAlta,
                    //    FechaHasta = nombramiento.FechaDeBaja,
                    //    Cargo = nombramiento.Cargo,
                    //    Organismo = nombramiento.Organismo,
                    //    Nro_Categoria = cat_cesida.Value,
                    //    Nro_Ubicacion = org_cesida.Value,
                    //    Id_Persona = nombramiento.Persona_Cesida,
                    //    Intentos = 0,
                    //    Movimiento = 12,
                    //    Nombramiento = nombramiento.Id,
                    //    Situacion_De_Revista = sr
                    //};
                                    
                    //oColaDeMovimientos.Guardar(c);
                    
                    return Json(new object[] { true, String.Format("Se guardo Nombramientos satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar Nombramientos" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar Nombramientos" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(Nombramientos nombramientos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Nombramientos anterior = oNombramientosRN.ObtenerPorId(nombramientos.Id);

                    //NombramientosMovimientos movimiento = new NombramientosMovimientos();
                    //movimiento.Cargo = anterior.Cargo;
                    //movimiento.Desde = anterior.FechaDeAlta;
                    //movimiento.Hasta = nombramientos.FechaDeAlta.AddDays(-1);
                    //movimiento.Nombramiento = anterior.Id;
                    //movimiento.SituacionRevista = anterior.SituacionRevista;
                    //movimiento.Organismo = anterior.Organismo;

                    //oMovimientosRN.Guardar(movimiento);
                    oNombramientosRN.Actualizar(nombramientos);

                    
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente Nombramientos") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse Nombramientos" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse Nombramientos" });
            }

        }

        public JsonResult JsonTodosLosOrganismos(bool todos)
        {
            List<SelectOptionsView> res;

            if (todos)
            {
                res = (from x in this.oOrganismosRefRN.ObtenerTodo()
                          select new SelectOptionsView { text = x.Descripcion, value = x.Id }).ToList();
            }
            else {
                res = (from x in this.oOrganismosRefRN.ObtenerRRHH()
                          select new SelectOptionsView { text = x.Descripcion, value = x.Id }).ToList();
            }
             
            
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(int id = 0)
        {
					
			ViewBag.CargosRef = new SelectList(oCargosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerRRHH().ToList(), "Id", "Descripcion");		
            Nombramientos nombramientos = oNombramientosRN.ObtenerPorId(id);
            if (nombramientos == null)
            {
                return HttpNotFound();
            }
            return View(nombramientos);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oNombramientosRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el nombramientos" });
            }
        }
		
		public JsonResult JsonT(int agente)
        {   
            var res = from x in this.oNombramientosRN.JsonT(agente)
                      //select new {Agente = x.Agente, Cargo = x.Cargo, FechaDeAlta = x.FechaDeAlta.ToShortDateString(), FechaDeBaja = x.FechaDeBaja, Organismo = x.Organismo, Id = x.Id };
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getNombramiento(int agente) {

            return this.Json(oNombramientos.getNombramiento(agente), JsonRequestBehavior.AllowGet);

        }


        //public JsonResult JsonT2(int agente)
        //{
        //    JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
        //    serializerSettings.Converters.Add(new IsoDateTimeConverter());
        //    GlobalConfiguration.Configuration.Formatters[0] = new JsonNetFormatter(serializerSettings);
        //    var res = from x in this.oNombramientosRN.JsonT(agente)
        //              //select new {Agente = x.Agente, Cargo = x.Cargo, FechaDeAlta = x.FechaDeAlta.ToShortDateString(), FechaDeBaja = x.FechaDeBaja, Organismo = x.Organismo, Id = x.Id };
        //              select x;
        //    return this.Json(res, JsonRequestBehavior.AllowGet);
        //}
		
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oNombramientosRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oNombramientosRN.Dispose();
			
				oCargosRefRN.Dispose();
			
				oOrganismosRefRN.Dispose();
			
				oSituacionesDeRevistaRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
