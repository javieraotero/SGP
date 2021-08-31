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
using SSO.SGP.AccesoADatos;

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
	public class NombramientosMovimientosController : Controller
	{
        private NombramientosMovimientosRN oNombramientosMovimientosRN = new NombramientosMovimientosRN();
		private CargosRefRN oCargosRefRN = new CargosRefRN();	
		private NombramientosRN oNombramientosRN = new NombramientosRN();		
		private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();
		private SituacionesDeRevistaRN oSituacionesDeRevistaRN = new SituacionesDeRevistaRN();
        private ColaDeMovimientoscesidaAD oColaDeMovimientos = new ColaDeMovimientoscesidaAD();
        private CesidaCargosRefAD oCesidaCargos = new CesidaCargosRefAD();
		
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        public DataTablesResult<NombramientosMovimientosView> getNombramientosMovimientosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oNombramientosMovimientosRN.ObtenerParaGrilla(), dataTableParam, a => new NombramientosMovimientosView()
            {	
			Id=a.Id,	
			Nombramiento=a.Nombramiento,	
			Desde=a.Desde,	
			Hasta=a.Hasta,	
			Cargo=a.Cargo,	
			SituacionRevista=a.SituacionRevista,	
			Organismo=a.Organismo
            });
        }

		public ActionResult Crear(int nombramiento)
        {

            Nombramientos n = oNombramientosRN.ObtenerPorId(nombramiento);

            NombramientosMovimientos m = new NombramientosMovimientos
            {
                Nombramiento = n.Id,
                Cargo = n.Cargo,
                SituacionRevista = n.SituacionRevista,
                Organismos = n.Organismos
            };
            
            ViewBag.CargosRef = new SelectList(oCargosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
			//ViewBag.SituacionesDeRevista = new SelectList(oSituacionesDeRevistaRN.ObtenerTodo().ToList(), "Id", "Descripcion");
			ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerRRHH().ToList(), "Id", "Descripcion");

            return View(m);
        }

        [HttpPost]
        public ActionResult Crear(NombramientosMovimientos nombramientosmovimientos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DateTime desde;
                    DateTime hasta;

                    Nombramientos n = oNombramientosRN.ObtenerPorId(nombramientosmovimientos.Nombramiento);

                    NombramientosMovimientos m = new NombramientosMovimientos()
                    {
                        Cargo = n.Cargo,
                        Organismo = n.Organismo,
                        SituacionRevista = n.SituacionRevista,
                        //Desde = nombramientosmovimientos.Desde,
                        Hasta = nombramientosmovimientos.Desde,
                        Nombramiento = nombramientosmovimientos.Nombramiento
                    };

                    oNombramientosMovimientosRN.Guardar(m);

                    if (n.Cargo != nombramientosmovimientos.Cargo)
                        n.FechaUltimoAscenso = nombramientosmovimientos.Desde;

                    ////ES UNA RECATEGORIZACIÓN
                    //if (n.Cargo != nombramientosmovimientos.Cargo) {

                    //    var nombramientos = oNombramientosRN.ObtenerTodo().ToList();

                    //    var cat_cesida = nombramientos.Where(nom => nom.Cargo == nombramientosmovimientos.Cargo && nom.Categoria_Cesida != null).FirstOrDefault().Categoria_Cesida;
                    //    var org_cesida = nombramientos.Where(nom => nom.Organismo == n.Organismo && nom.Ubicacion_Cesida != null).FirstOrDefault().Ubicacion_Cesida;
                    //    var cargos = oCesidaCargos.ObtenerPorId(cat_cesida.Value);

                    //    var c = new ColaDeMovimientoscesida()
                    //    {
                    //        Nro_Ubicacion = org_cesida,
                    //        Movimiento = 8,
                    //        Agente = n.Agente,
                    //        Fecha = DateTime.Now,
                    //        Nro_Categoria = cat_cesida,
                    //        Cargo = m.Cargo,
                    //        FechaDesde = nombramientosmovimientos.Desde,
                    //        Fecha_Vigencia_Desde = nombramientosmovimientos.Desde,
                    //        Id_Persona = n.Persona_Cesida,
                    //        Intentos = 0,
                    //        Organismo = n.Organismo,
                    //        Nombramiento = n.Id,
                    //        Id_Designacion = n.Designacion_Cesida.Value,
                    //        Nro_Rama = cargos.NroRama,
                    //        Nro_Convenio = cargos.NroConvenio
                    //    };

                    //    oColaDeMovimientos.Guardar(c);
                    //}

                    ////ES UN CAMBIO DE ESTABLECIMIENTO
                    //if (n.Organismo != nombramientosmovimientos.Organismo)
                    //{

                    //    var nombramientos = oNombramientosRN.ObtenerTodo().ToList();

                    //    var cat_cesida = nombramientos.Where(nom => nom.Cargo == nombramientosmovimientos.Cargo && nom.Categoria_Cesida != null).FirstOrDefault().Categoria_Cesida;
                    //    var org_cesida = nombramientos.Where(nom => nom.Organismo == n.Organismo && nom.Ubicacion_Cesida != null).FirstOrDefault().Ubicacion_Cesida;

                    //    var c = new ColaDeMovimientoscesida()
                    //    {
                    //        Nro_Ubicacion = org_cesida,
                    //        Movimiento = 7,
                    //        Agente = n.Agente,
                    //        Fecha = DateTime.Now,
                    //        Nro_Categoria = cat_cesida,
                    //        Cargo = m.Cargo,
                    //        FechaDesde = m.Desde,
                    //        Id_Persona = n.Persona_Cesida,
                    //        Intentos = 0,
                    //        Organismo = n.Organismo,
                    //        Nombramiento = n.Id,
                    //        Id_Designacion = n.Designacion_Cesida.Value
                    //    };

                    //    oColaDeMovimientos.Guardar(c);
                    //}

                    ////ES UN CAMBIO DE SITUACION DE REVISTA (que n o sea Jubilado)
                    //if (n.SituacionRevista != nombramientosmovimientos.SituacionRevista && nombramientosmovimientos.SituacionRevista != "B" && nombramientosmovimientos.SituacionRevista != "X")
                    //{

                    //    var sr = "";
                            
                    //    switch (nombramientosmovimientos.SituacionRevista)
                    //    {
                    //        case "C":
                    //            sr = "C";
                    //            break;
                    //        case "P":
                    //            sr = "P";
                    //            break;                            
                    //    };


                    //    var nombramientos = oNombramientosRN.ObtenerTodo().ToList();

                    //    var cat_cesida = nombramientos.Where(nom => nom.Cargo == n.Cargo && nom.Categoria_Cesida != null).FirstOrDefault().Categoria_Cesida;
                    //    var org_cesida = nombramientos.Where(nom => nom.Organismo == nombramientosmovimientos.Organismo && nom.Ubicacion_Cesida != null).FirstOrDefault().Ubicacion_Cesida;

                    //    var c = new ColaDeMovimientoscesida()
                    //    {
                    //        Nro_Ubicacion = org_cesida,
                    //        Movimiento = 19,
                    //        Agente = n.Agente,
                    //        Fecha = DateTime.Now,
                    //        Nro_Categoria = cat_cesida,
                    //        Cargo = m.Cargo,
                    //        FechaDesde = m.Desde,
                    //        Id_Persona = n.Persona_Cesida,
                    //        Intentos = 0,
                    //        Organismo = n.Organismo,
                    //        Nombramiento = n.Id,
                    //        Id_Designacion = n.Designacion_Cesida.Value,
                    //        Situacion_De_Revista = sr                            
                    //    };

                    //    oColaDeMovimientos.Guardar(c);
                    //}


                    n.Organismo = nombramientosmovimientos.Organismo;
                    n.Cargo = nombramientosmovimientos.Cargo;
                    n.SituacionRevista = nombramientosmovimientos.SituacionRevista;

                    oNombramientosRN.Actualizar(n);



                    //oNombramientosMovimientosRN.Guardar(nombramientosmovimientos);
                    return Json(new object[] { true, String.Format("Se actualizó el nombramiento satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido actualizar el nombramiento" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar NombramientosMovimientos" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(NombramientosMovimientos nombramientosmovimientos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oNombramientosMovimientosRN.Actualizar(nombramientosmovimientos);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente NombramientosMovimientos") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse NombramientosMovimientos" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse NombramientosMovimientos" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			//ViewBag.Nombramientos = new SelectList(oNombramientosRN.ObtenerTodo().ToList(), "Id", "Id");
			
			ViewBag.CargosRef = new SelectList(oCargosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
			
			//ViewBag.SituacionesDeRevista = new SelectList(oSituacionesDeRevistaRN.ObtenerTodo().ToList(), "Id", "Id");
			
			ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");           			
		
            NombramientosMovimientos nombramientosmovimientos = oNombramientosMovimientosRN.ObtenerPorId(id);

            ViewBag.SituacionRevista = nombramientosmovimientos.SituacionRevista; 

            if (nombramientosmovimientos == null)
            {
                return HttpNotFound();
            }
            return View(nombramientosmovimientos);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oNombramientosMovimientosRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el nombramientosmovimientos" });
            }
        }
		
		public JsonResult JsonT(int nombramiento)
        {
            var res = from x in this.oNombramientosMovimientosRN.JsonT(nombramiento)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oNombramientosMovimientosRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		


	protected override void Dispose(bool disposing)
        {
            oNombramientosMovimientosRN.Dispose();
			
				oCargosRefRN.Dispose();
			
				oNombramientosRN.Dispose();
			
				oOrganismosRefRN.Dispose();
			
				oSituacionesDeRevistaRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
