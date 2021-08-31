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
using System.Threading.Tasks;
using SSO.SGP.Web.Nucleo_Demo;
using SSO.SGP.AccesoADatos;

namespace SSO.SGP.Web.Controllers
{
	public class PersonasController : Controller
	{
        private PersonasRN oPersonasRN = new PersonasRN();
        private ActuacionesRN oActuacionesRN = new ActuacionesRN();
        private BarriosRefRN oBarriosRefRN = new BarriosRefRN();
        private CallesRefRN oCallesRefRN = new CallesRefRN();
        private ConcursosRN oConcursosRN = new ConcursosRN();
        private EstadosCivilRefRN oEstadosCivilRefRN = new EstadosCivilRefRN();
        private EstadosEscolaridadRefRN oEstadosEscolaridadRefRN = new EstadosEscolaridadRefRN();
        private LocalidadesRefRN oLocalidadesRefRN = new LocalidadesRefRN();
        private PersonasCaracteristicasRefRN oPersonasCaracteristicasRefRN = new PersonasCaracteristicasRefRN();
        private SexosRefRN oSexosRefRN = new SexosRefRN();
        private TiposDocumentoRefRN oTiposDocumentoRefRN = new TiposDocumentoRefRN();
        private TiposEscolaridadRefRN oTiposEscolaridadRefRN = new TiposEscolaridadRefRN();
        private TiposOcupacionRefRN oTiposOcupacionRefRN = new TiposOcupacionRefRN();
        private UsuariosRN oUsuariosRN = new UsuariosRN();
        private TurnosWebAD oTurnos = new TurnosWebAD();
        private PersonasTrazabilidadAD oTrazabilidad = new PersonasTrazabilidadAD();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrazabilidadGrid()
        {
            return View();
        }

        public ActionResult TrazabilidadGridOrganismo()
        {
            return View();
        }

        public ActionResult Default() 
		{
			return View();
		}

        public ActionResult Trazabilidad()
        {

            return View();
        }

        public ActionResult TrazabilidadOrganismo()
        {

            return View();
        }

        public ActionResult Certificado(long id)
        {
            var oAgente = new SSO.SGP.AccesoADatos.AgentesAD();

            var a = oAgente.ObtenerCertificado(id);

            if (a.CertificadoFechaDesde.HasValue && a.CertificadoFechaDesde.Value.Date >= DateTime.Now.Date)
            {
                if (a.CertificadoFechaHasta.HasValue)
                {
                    return View("Certificadodia", a);
                }
                else {
                    return View("Certificado", a);
                }
            }
            else {

                return View("SinCertificado");

            }
            

            return View();
        }

        public DataTablesResult<PersonasTrazabilidadView> getTrazabilidad(DataTablesParam dataTableParam, int? organismo, string desde, string hasta, long? dni)
        {
            DateTime? fdesde = null;
            DateTime? fhasta = null;

            if (!string.IsNullOrEmpty(desde))
            {
                fdesde = DateTime.Parse(desde).Date.Add(new TimeSpan(0, 0, 0));
            }

            if (!string.IsNullOrEmpty(hasta))
            {
                fhasta = DateTime.Parse(hasta).Date.Add(new TimeSpan(23, 59, 59));
            }

            return DataTablesResult.Create(this.oTrazabilidad.ObtenerParaGrilla(organismo.HasValue ? organismo.Value : SessionHelper.OficinaActual, fdesde, fhasta, dni), dataTableParam, x => x);
        }


        public DataTablesResult<PersonasTrazabilidadDetalleView> getTrazabilidadDetalle(DataTablesParam dataTableParam, int? organismo, string desde, string hasta, long? dni, bool excluir_empleados, bool todos_organismos)
        {
            DateTime? fdesde = null;
            DateTime? fhasta = null;

            if (!string.IsNullOrEmpty(desde))
            {
                fdesde = DateTime.Parse(desde).Date.Add(new TimeSpan(0, 0, 0));
            }

            if (!string.IsNullOrEmpty(hasta))
            {
                fhasta = DateTime.Parse(hasta).Date.Add(new TimeSpan(23, 59, 59));
            }

            if (organismo == 0)
                organismo = null;

            return DataTablesResult.Create(this.oTrazabilidad.ObtenerParaGrillaDetalle(organismo.HasValue ? organismo.Value : SessionHelper.OficinaActual, fdesde, fhasta, dni, excluir_empleados, todos_organismos), dataTableParam, x => x);
        }


        public DataTablesResult<PersonasView> getPersonasGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oPersonasRN.ObtenerParaGrilla(), dataTableParam, a => new PersonasView()
            {	
			Id=a.Id,	
			Apellidos=a.Apellidos,	
			Nombres=a.Nombres,	
			TipoDocumento=a.TipoDocumento,	
			NroDocumento=a.NroDocumento,	
			FechaNacimiento=a.FechaNacimiento,	
			LugarNacimiento=a.LugarNacimiento,	
			Sexo=a.Sexo,	
			EsMenor=a.EsMenor,	
			Alias=a.Alias,	
			PersonaFisica=a.PersonaFisica,	
			Barrio=a.Barrio,	
			Calle=a.Calle,	
			Domicilio=a.Domicilio,	
			Localidad=a.Localidad,	
			Ocupacion=a.Ocupacion,	
			Nacionalidad=a.Nacionalidad,	
			Activa=a.Activa,	
			Telefono=a.Telefono,	
			Fallecido=a.Fallecido,	
			FechaDefuncion=a.FechaDefuncion,	
			TipoEscolaridad=a.TipoEscolaridad,	
			EstadoEscolaridad=a.EstadoEscolaridad,	
			TipoOcupacion=a.TipoOcupacion,	
			EstadoCivil=a.EstadoCivil,	
			Ocupado=a.Ocupado,	
			ObraSocial=a.ObraSocial,	
			Detenido=a.Detenido,	
			IncluirIdentikit=a.IncluirIdentikit,	
			FotoIdentikit=a.FotoIdentikit,	
			RegistroVoz=a.RegistroVoz,	
			ColorOjos=a.ColorOjos,	
			ColorPelo=a.ColorPelo,	
			LongitudPelo=a.LongitudPelo,	
			Altura=a.Altura,	
			Peso=a.Peso,	
			Piel=a.Piel,	
			BarbaBigote=a.BarbaBigote,	
			LongitudBarbaBigote=a.LongitudBarbaBigote,	
			ColorBarbaBigote=a.ColorBarbaBigote,	
			PielVarios=a.PielVarios,	
			Varios=a.Varios,	
			Tonada=a.Tonada,	
			CriterioOportunidadArt15=a.CriterioOportunidadArt15,	
			Celular=a.Celular,	
			TelefonoTrabajo=a.TelefonoTrabajo,	
			DomicilioTrabajo=a.DomicilioTrabajo,	
			FechaAlta=a.FechaAlta,	
			UsuarioAlta=a.UsuarioAlta,	
			ActuacionCriterioOportunidad=a.ActuacionCriterioOportunidad,	
			FechaCriterioOportunidad=a.FechaCriterioOportunidad,	
			UsuarioCriterioOportunidad=a.UsuarioCriterioOportunidad,	
			ObservacionCriterioOportunidad=a.ObservacionCriterioOportunidad,	
			Observaciones=a.Observaciones,	
			FechaEliminacion=a.FechaEliminacion,	
			UsuarioEliminacion=a.UsuarioEliminacion,	
			FechaModificacion=a.FechaModificacion,	
			UsuarioModificacion=a.UsuarioModificacion,	
			NombrePadre=a.NombrePadre,	
			NombreMadre=a.NombreMadre,	
			ActuacionSuspencionProcesoAPrueba=a.ActuacionSuspencionProcesoAPrueba,	
			FechaSuspencionProcesoAPrueba=a.FechaSuspencionProcesoAPrueba,	
			UsuarioSuspencionProcesoAPrueba=a.UsuarioSuspencionProcesoAPrueba,	
			ObservacionSuspencionProcesoAPrueba=a.ObservacionSuspencionProcesoAPrueba,	
			SuspencionProcesoAPrueba=a.SuspencionProcesoAPrueba,	
			Concurso=a.Concurso,	
			DomicilioProcesal=a.DomicilioProcesal,	
			LocalidadProcesal=a.LocalidadProcesal,});
        }

        public ActionResult Crear()
        {
            ViewBag.TiposDocumentoRef = new SelectList(oTiposDocumentoRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.SexosRef = new SelectList(oSexosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.BarriosRef = new SelectList(oBarriosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.CallesRef = new SelectList(oCallesRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.LocalidadesRef = new SelectList(oLocalidadesRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.TiposEscolaridadRef = new SelectList(oTiposEscolaridadRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.EstadosEscolaridadRef = new SelectList(oEstadosEscolaridadRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.TiposOcupacionRef = new SelectList(oTiposOcupacionRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.EstadosCivilRef = new SelectList(oEstadosCivilRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.PersonasCaracteristicasRef = new SelectList(oPersonasCaracteristicasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");

            return View();
        }

        public ActionResult CrearSimple()
        {
            ViewBag.TiposDocumentoRef = new SelectList(oTiposDocumentoRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.SexosRef = new SelectList(oSexosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            //ViewBag.BarriosRef = new SelectList(oBarriosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            //ViewBag.CallesRef = new SelectList(oCallesRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            //ViewBag.LocalidadesRef = new SelectList(oLocalidadesRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            //ViewBag.TiposEscolaridadRef = new SelectList(oTiposEscolaridadRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            //ViewBag.EstadosEscolaridadRef = new SelectList(oEstadosEscolaridadRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            //ViewBag.TiposOcupacionRef = new SelectList(oTiposOcupacionRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            //ViewBag.EstadosCivilRef = new SelectList(oEstadosCivilRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            //ViewBag.PersonasCaracteristicasRef = new SelectList(oPersonasCaracteristicasRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Personas personas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    personas.Activa = true;
                    personas.FechaAlta = DateTime.Now;
                    personas.UsuarioAlta = SessionHelper.IdUsuario.Value;
                    personas.FechaModificacion = DateTime.Now;
                    personas.UsuarioModificacion = SessionHelper.IdUsuario.Value;

                    oPersonasRN.Guardar(personas);
                    return Json(new object[] { true, String.Format("Se guardo Personas satisfactoriamente") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar Personas" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar Personas" });
            }
        }

        [HttpPost]
        public ActionResult CrearSimple(Personas personas)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    personas.EsMenor = false;
                    personas.Fallecido = false;
                    personas.PersonaFisica = true;
                    personas.Ocupado = true;
                    personas.ObraSocial = false;
                    personas.Detenido = false;
                    personas.IncluirIdentikit = false;
                    personas.ColorOjos = 1;
                    personas.ColorPelo = 1;
                    personas.LongitudPelo = 1;
                    personas.Altura = 1;
                    personas.Peso = 1;
                    personas.Piel = 1;
                    personas.BarbaBigote = 1;
                    personas.LongitudBarbaBigote = 1;
                    personas.ColorBarbaBigote= 1;
                    personas.PielVarios = 1;
                    personas.Varios = 1;
                    personas.Tonada = 1;
                    personas.CriterioOportunidadArt15 = false;
                    personas.SuspencionProcesoAPrueba = false;
                    personas.Observaciones = "CREADO POR TRAZABILIDAD COVID-19"; 

                    personas.Activa = true;
                    personas.FechaAlta = DateTime.Now;
                    personas.UsuarioAlta = SessionHelper.IdUsuario.Value;
                    personas.FechaModificacion = DateTime.Now;
                    personas.UsuarioModificacion = SessionHelper.IdUsuario.Value;

                    oPersonasRN.Guardar(personas);
                    return Json(new object[] { true, String.Format("Se guardo Personas satisfactoriamente") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar Personas" });
                }
            //}
            //else
            //{
            //    return Json(new object[] { false, "No se ha podido guardar Personas" });
            //}
        }

        [HttpPost]
        public ActionResult GuardarTrazabilidad(int persona, string sfecha, string telefono, int organismo) 
        {
            try
            {
                var t = new PersonasTrazabilidad()
                {
                    FechaAlta = DateTime.Now,
                    Fecha = DateTime.Parse(sfecha),
                    Persona = persona,
                    Organismo = organismo,
                    Usuario = SessionHelper.IdUsuario.Value,
                    Hora = DateTime.Parse(sfecha).TimeOfDay
                };

                oTrazabilidad.Guardar(t);

                var p = oPersonasRN.ObtenerPorId(persona);
                p.Telefono = telefono;
                p.FechaModificacion = DateTime.Now;

                oPersonasRN.Actualizar(p);

                return this.Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) {
                return this.Json(new { result = false }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult Editar(Personas personas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oPersonasRN.Actualizar(personas);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente Personas") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse Personas" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse Personas" });
            }

        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oPersonasRN.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el personas" });
            }
        }

        [HttpPost, ActionName("Buscar")]
        public async Task<ActionResult> BuscarPersona(CustomBuscarPersona custom)
        {
            var apellidos = (!String.IsNullOrEmpty(custom.Apellidos) ? custom.Apellidos : "");
            var nombre = (!String.IsNullOrEmpty(custom.Nombre) ? custom.Nombre : "");

            var res = from x in this.oPersonasRN.BuscarPersona(custom.Documento, apellidos, nombre, custom.Sexo)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ActionName("BuscarNucleo")]
        public ActionResult BuscarPersonaNucleo(string documento)
        {
            short error;
            string sError;

            var usuario = System.Configuration.ConfigurationManager.AppSettings["Nucleo.WebServices.Usuario"];
            var clave = System.Configuration.ConfigurationManager.AppSettings["Nucleo.WebServices.Clave"];

            var ws = new WSConsultaPersonaN();
            ws.Url = System.Configuration.ConfigurationManager.AppSettings["Nucleo.WebServices.BuscarPersona"];

            var result = ws.Execute(documento, usuario, clave, out error, out sError);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarPersona(string dni)
        {
            var res = this.oPersonasRN.BuscarPersona(long.Parse(dni), string.Empty, string.Empty, 0).ToList();
            var turno = oTurnos.ObtenerPorDni(long.Parse(dni));

            string telefono = "";
            int? sexo = null;
            int idPersona = -1;
            string nombre = "";

            if (res.Count() > 0) {
                idPersona = res.FirstOrDefault().Id;
                sexo = res.FirstOrDefault().sexo;
                nombre = res.FirstOrDefault().Apellidos.Trim() + ", " + res.FirstOrDefault().Nombres.Trim();
                telefono = !string.IsNullOrEmpty(res.FirstOrDefault().Telefono) ? res.FirstOrDefault().Telefono : "";
                if (turno != null && string.IsNullOrWhiteSpace(telefono))
                    telefono = turno.Telefono;
            }


            return this.Json(new { id_persona = idPersona, sexo = sexo, telefono = telefono, nombre }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonT(string term)
        {
            var res = from x in this.oPersonasRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oPersonasRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult getPersonaConNucleo(int id)
        {
            Personas p = oPersonasRN.ObtenerPorId(id);

            short error;
            string sError;

            var usuario = System.Configuration.ConfigurationManager.AppSettings["Nucleo.WebServices.Usuario"];
            var clave = System.Configuration.ConfigurationManager.AppSettings["Nucleo.WebServices.Clave"];

            var ws = new WSConsultaPersonaN();
            ws.Url = System.Configuration.ConfigurationManager.AppSettings["Nucleo.WebServices.BuscarPersona"];

            var result = ws.Execute(p.NroDocumento.ToString(), usuario, clave, out error, out sError);

            return this.Json(new { id=id, nombre=p.Nombres, apellido = p.Apellidos, domicilio = p.Domicilio, documento = p.NroDocumento}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPersona(int id)
        {
            Personas p = oPersonasRN.ObtenerPorId(id);

            //short error;
            //string sError;

            //var usuario = System.Configuration.ConfigurationManager.AppSettings["Nucleo.WebServices.Usuario"];
            //var clave = System.Configuration.ConfigurationManager.AppSettings["Nucleo.WebServices.Clave"];

            //var ws = new WSConsultaPersonaN();
            //ws.Url = System.Configuration.ConfigurationManager.AppSettings["Nucleo.WebServices.BuscarPersona"];

            //var result = ws.Execute(p.NroDocumento.ToString(), usuario, clave, out error, out sError);

            return this.Json(new { id = id, nombre = p.Nombres, apellido = p.Apellidos, domicilio = p.Domicilio, documento = p.NroDocumento }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult existeDocumento(long? documento)
        {
            bool existe = oPersonasRN.ExisteDocumento(documento);

            return this.Json(new { existe = existe }, JsonRequestBehavior.AllowGet);
        }
		

	//IMPLEMENTAR la accion Buscar
	public ActionResult Buscar(bool usuario = false) {
        ViewBag.Sexos = new SelectList(this.oSexosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
        ViewBag.usuario = usuario;
        return View();
	}

	protected override void Dispose(bool disposing)
        {
            oPersonasRN.Dispose();
			
				oPersonasRN.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
