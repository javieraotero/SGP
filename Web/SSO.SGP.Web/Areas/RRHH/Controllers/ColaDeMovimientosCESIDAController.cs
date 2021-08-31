using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.EntidadesDeNegocio;
using Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System;
using System.Data;
using Syncrosoft.Framework.Utils.Logs;
using SSO.SGP.EntidadesDeNegocio.CESIDA;
using SSO.SGP.Web.BasicConsumer;

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
	public class ColaDeMovimientosCESIDAController : Controller
	{
        private ColaDeMovimientoscesidaAD oColaDeMovimientos = new ColaDeMovimientoscesidaAD();
		private MovimientoscesidaAD oMovimientos = new MovimientoscesidaAD();
        private AgentesAD oAgentes = new AgentesAD();
        private NombramientosAD oNombramientos = new NombramientosAD();
        private CesidaMovimientosAD oCesidaMovimientos = new CesidaMovimientosAD();
		
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Default() 
		{
			return View();
		}

        //public JsonResult Test(string id, int cod) {

        //    var movimiento = oColaDeMovimientos.ObtenerPorId(cod);
        //    object a = new object();

        //    Lote lote = new Lote()
        //    {
        //        nombreLote = "PoderJudicial-" + cod,
        //        clave = "justicia",
        //        // datosLote = data,
        //        nombreProceso = id,
        //        sistema = "RRHH_JUSTICIA",
        //        accion = "crearLote",
        //        incluyeRegistro = "No"
        //    };

        //    if (id == "ALTA_AGENTE_DEV") {
        //        a = new ALTA_AGENTE_DEV()
        //        {
        //            NRO_LEGAJO = "988",
        //            ID_PERSONA = movimiento.Id_Persona.Value,
        //            CODIGO_PLANTA = movimiento.Codigo_Planta,
        //            ID_JORNADA = movimiento.Jornada.Value,
        //            CODIGO_OBRA_SOCIAL = 600,
        //            FECHA_ALTA = movimiento.FechaDesde.Value.ToShortDateString(),
        //            NRO_CONVENIO = movimiento.Nro_Convenio.Value,
        //            NRO_RAMA = movimiento.Nro_Rama.Value,
        //            NRO_CATEGORIA = movimiento.Nro_Categoria.Value,
        //            FECHA_VIG_DESDE = movimiento.FechaDesde.Value.ToShortDateString(),
        //            CODIGO_JURISDICCION = movimiento.Codigo_Jurisdiccion,
        //            NRO_UNIDAD_ORG = movimiento.Nro_Unidad_Org.Value.ToString(),
        //            CODIGO_EMPRESA = "B",
        //            NRO_UBICACION = movimiento.Nro_Ubicacion.Value,
        //            ID_EXTERNO = movimiento.IdRegistro.Value,
        //            ID_FUNCION = 0,
        //            FECHA_APROBACION = movimiento.FechaDesde.Value.ToShortDateString(),
        //            FECHA_ALTA_OBRA_SOCIAL = movimiento.FechaDesde.Value.ToShortDateString()
                    
        //        };

        //        lote.datosLote = crearDatosLote(a);

        //    }

        //    var r = new Respuesta();

        //    var respuesta = Service.post<Lote>(lote, "http://10.2.1.59:8080/migrador/migrador/api/crearLoteViaParametros");

        //    movimiento.Intentos++;
        //    movimiento.MensajeRespuesta = respuesta.resultado;
        //    movimiento.CodOperacion = respuesta.codigoOperacion;

        //    oColaDeMovimientos.Actualizar(movimiento);

        //    r.mensaje = respuesta.resultado;
        //    r.codOperacion = respuesta.codigoOperacion;
        //    r.nroLote = respuesta.nroLote;
        //    r.datosLote = lote.datosLote;
        //    r.objeto = a;

        //    return Json(r, JsonRequestBehavior.AllowGet);


        //}

        [HttpPost]
        public JsonResult EnviarMovimiento(int id)
        {

            try
            {

                var movimiento = oColaDeMovimientos.ObtenerPorId(id);
                var tipo = oCesidaMovimientos.ObtenerPorId(movimiento.Movimiento);
                var agente = oAgentes.ObtenerPorId(movimiento.Agente.Value);
                object a = new object();

                Lote lote = new Lote()
                {
                    nombreLote = "PoderJudicial-" + movimiento.Id,
                    clave = "justicia",
                    // datosLote = data,
                    nombreProceso = tipo.CodigoCesida,
                    sistema = "RRHH_JUSTICIA",
                    //accion = "crearLote",
                    //incluyeRegistro = "No"
                };

                if (tipo.CodigoCesida == "ALTA_AGENTE_DEV")
                {
                    a = new ALTA_AGENTE_DEV()
                    {
                        //legajo no es obligatorio
                        //NRO_LEGAJO = "988",
                        ID_PERSONA = movimiento.Id_Persona.Value,
                        COD_REVISTA = movimiento.Codigo_Planta,
                        NRO_JORNADA = movimiento.Jornada.Value,
                        COD_OBRA_SOCIAL = 600,
                        FECHA_ALTA = movimiento.FechaDesde.Value.ToShortDateString(),
                        NRO_CONVENIO = movimiento.Nro_Convenio.Value,
                        NRO_RAMA = movimiento.Nro_Rama.Value,
                        NRO_CATEGORIA = movimiento.Nro_Categoria.Value,
                        FECHA_VIGENCIA_DESDE = movimiento.FechaDesde.Value.ToShortDateString(),
                        COD_JURISDICCION = movimiento.Codigo_Jurisdiccion,
                        NRO_UNIDAD_ORG = movimiento.Nro_Unidad_Org.Value.ToString(),
                        COD_EMPRESA = "B",
                        NRO_UBICACION = movimiento.Nro_Ubicacion.Value,
                        ID_EXTERNO = movimiento.IdRegistro.Value,
                        NRO_FUNCION = 0,
                        FECHA_ALTA_OBRA_SOCIAL = movimiento.FechaDesde.Value.ToShortDateString()
                    };

                    lote.datosLote = crearDatosLote(a);

                }

                if (tipo.CodigoCesida == "RECATEGORIZACION_AGENTE_DEV")
                {
                    a = new RECATEGORIZACION_AGENTE_DEV()
                    {
                        ID_DESIGNACION = movimiento.Id_Designacion.ToString(),
                        FECHA_VIGENCIA_DESDE = movimiento.Fecha_Vigencia_Desde.Value.ToShortDateString(),
                        NRO_CATEGORIA = movimiento.Nro_Categoria.Value.ToString(),
                        NRO_RAMA = movimiento.Nro_Rama.ToString(),
                        NRO_CONVENIO = movimiento.Nro_Rama.ToString(),
                        NRO_LEGAJO = agente.Legajo.ToString()
                    };

                    lote.datosLote = crearDatosLote(a);

                }

                if (tipo.CodigoCesida == "CAMBIO_ESTABLECIMIENTO_AGENTE_DEV")
                {
                    a = new CAMBIO_ESTABLECIMIENTO_AGENTE_DEV()
                    {
                        ID_DESIGNACION = movimiento.Id_Designacion.ToString(),
                        FECHA_VIGENCIA_DESDE = movimiento.Fecha_Vigencia_Desde.Value,
                        NRO_UBICACION = movimiento.Nro_Ubicacion.Value.ToString(),
                        NRO_LEGAJO = agente.Legajo.ToString()
                    };

                    lote.datosLote = crearDatosLote(a);

                }

                if (tipo.CodigoCesida == "CAMBIO_SITUACION_REVISTA_AGENTE_DEV")
                {
                    a = new CAMBIO_SITUACION_REVISTA_AGENTE()
                    {
                        ID_DESIGNACION = movimiento.Id_Designacion.ToString(),
                        NRO_LEGAJO = agente.Legajo.ToString(),
                        FECHA_DESDE = movimiento.FechaDesde.Value.ToShortDateString(),
                        TIPO_PLANTA = movimiento.Situacion_De_Revista
                    };

                    lote.datosLote = crearDatosLote(a);
                }

                if (tipo.CodigoCesida == "SUBROGACION_AGENTE_DEV")
                {
                    a = new SUBROGACION_AGENTE_DEV()
                    {
                        ID_DESIGNACION = movimiento.Id_Designacion.ToString(),
                        FECHA_VIGENCIA_DESDE = movimiento.FechaDesde.Value,
                        NRO_CATEGORIA = movimiento.Nro_Categoria.Value,
                        FECHA_VIGENCIA_HASTA = movimiento.FechaHasta,
                        //NRO_LEGAJO = movimiento                        
                    };

                    lote.datosLote = crearDatosLote(a);
                }

                var r = new Respuesta();

                var respuesta = Service.post<Lote>(lote, "http://10.2.1.59:8080/migrador/migrador/api/crearLoteViaParametros");

                movimiento.Intentos++;
                movimiento.MensajeRespuesta = respuesta.resultado;
                movimiento.CodOperacion = respuesta.codigoOperacion;

                //ASIGNAR EL ID DE DESIGNACION QUE RETORNA EL LIQUIDADOR
                if (tipo.CodigoCesida == "ALTA_AGENTE_DEV" && !string.IsNullOrEmpty(movimiento.CodOperacion))
                {
                    var n = oNombramientos.ObtenerPorId(movimiento.Nombramiento.Value);
                    n.Designacion_Cesida = int.Parse(movimiento.CodOperacion);
                    oNombramientos.Actualizar(n);
                }


                oColaDeMovimientos.Actualizar(movimiento);

                r.mensaje = respuesta.resultado;
                r.codOperacion = respuesta.codigoOperacion;
                r.nroLote = respuesta.nroLote;
                r.datosLote = lote.datosLote;
                r.objeto = a;

                return Json(r, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        //public JsonResult TestAlta() {

        //    string data = "";

        //    var test = new ALTA_AGENTE_DEV()
        //    {
        //        NRO_LEGAJO = "988",
        //        ID_PERSONA = 15105,
        //        CODIGO_PLANTA = "P",
        //        ID_JORNADA = 6,
        //        CODIGO_OBRA_SOCIAL = 600,
        //        FECHA_ALTA = "01/01/2017",
        //        NRO_CONVENIO = 6,
        //        NRO_RAMA = 11,
        //        NRO_CATEGORIA = 2202,
        //        FECHA_VIG_DESDE = "01/01/2017",
        //        CODIGO_JURISDICCION = "B",
        //        NRO_UNIDAD_ORG = "1",
        //        CODIGO_EMPRESA = "B",
        //        NRO_UBICACION = 3411,
        //        ID_EXTERNO = 7559,
        //        ID_FUNCION = 1,
        //        FECHA_APROBACION = "01/01/2017",
        //        FECHA_ALTA_OBRA_SOCIAL = "01/01/2017"
        //    };

            

        //    Lote lote = new Lote()
        //    {
        //        nombreLote = "PoderJudicial-test1",
        //        clave = "justicia",
        //        datosLote = data,
        //        nombreProceso = "ALTA_AGENTE_DEV",
        //        sistema = "RRHH_JUSTICIA",
        //        accion="crearLote", 
        //        incluyeRegistro = "No"
        //    };

        //    Service.post<Lote>(lote, "http://10.2.1.59:8080/migrador/migrador/api/crearLoteViaParametros");

        //    return Json(crearDatosLote(test), JsonRequestBehavior.AllowGet);

        //}

        private string crearDatosLote(dynamic obj) {

            string data = "";

            foreach (var prop in obj.GetType().GetProperties())
            {               
                data += String.Format("{1}|", prop.Name, prop.GetValue(obj, null));
            }

            data = data.Substring(0, data.Length - 1);

            return data;
        }



        public DataTablesResult<ColaDeMovimientoscesidaView> getColaDeMovimientosCESIDAGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oColaDeMovimientos.ObtenerParaGrilla(), dataTableParam, a => new ColaDeMovimientoscesidaView()
            {	
			Id=a.Id,	
			Agente=a.Agente,	
			Movimiento=a.Movimiento,	
			Fecha=a.Fecha,	
			FechaEnvio=a.FechaEnvio,	
			Respuesta=a.Respuesta,	
			Intentos=a.Intentos,	
			FechaDesde=a.FechaDesde,	
			FechaHasta=a.FechaHasta,	
			Cargo=a.Cargo,	
			Organismo=a.Organismo});
        }
		
		public ActionResult Detalle(int id = 0)
        {
            ColaDeMovimientoscesida colademovimientoscesida = oColaDeMovimientos.ObtenerPorId(id);
            if (colademovimientoscesida == null)
            {
                return HttpNotFound();
            }
            return View(colademovimientoscesida);
        }		
	

		public ActionResult Crear()
        {
			ViewBag.MovimientosCESIDA = new SelectList(oMovimientos.ObtenerTodo().ToList(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ColaDeMovimientoscesida colademovimientoscesida)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oColaDeMovimientos.Guardar(colademovimientoscesida);
                    return Json(new object[] { true, String.Format("Se guardo ColaDeMovimientosCESIDA satisfactoriamente") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar ColaDeMovimientosCESIDA" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar ColaDeMovimientosCESIDA" });
            }
        }
	
	
		[HttpPost]
        public ActionResult Editar(ColaDeMovimientoscesida colademovimientoscesida)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oColaDeMovimientos.Actualizar(colademovimientoscesida);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente ColaDeMovimientosCESIDA") });
                }
                catch (Exception ex)
				{
					Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse ColaDeMovimientosCESIDA" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse ColaDeMovimientosCESIDA" });
            }

        }

        public ActionResult Editar(int id = 0)
        {
			
			ViewBag.MovimientosCESIDA = new SelectList(oMovimientos.ObtenerTodo().ToList(), "Id", "Nombre");
			
		
            ColaDeMovimientoscesida colademovimientoscesida = oColaDeMovimientos.ObtenerPorId(id);
            if (colademovimientoscesida == null)
            {
                return HttpNotFound();
            }
            return View(colademovimientoscesida);
        }
	

        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oColaDeMovimientos.Eliminar(id);
                return Json(new 	object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
			{
				Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el colademovimientoscesida" });
            }
        }
		
		//public JsonResult JsonT(string term)
  //      {
  //          var res = from x in this.oColaDeMovimientos.JsonT(term)
  //                    select x;
  //          return this.Json(res, JsonRequestBehavior.AllowGet);
  //      }
		
		//--- Utilizar esta acción para Autocomplete
		public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oColaDeMovimientos.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }
		

		public ActionResult Eliminar(int id = 0)
        {
            ColaDeMovimientoscesida colademovimientoscesida = oColaDeMovimientos.ObtenerPorId(id);
            if (colademovimientoscesida == null)
            {
                return HttpNotFound();
            }
            return View(colademovimientoscesida);
        }
		
		

	protected override void Dispose(bool disposing)
        {
            oColaDeMovimientos.Dispose();
			
			oMovimientos.Dispose();
			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
