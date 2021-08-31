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

namespace SSO.SGP.Web.Areas.Expedientes.Controllers
{
    public class ActuacionesADMController : Controller
    {
        private ActuacionesadmRN oActuacionesadmRN = new ActuacionesadmRN();
        private AmbitosRN oAmbitosRN = new AmbitosRN();
        private ExpedientesadmRN oExpedientesadmRN = new ExpedientesadmRN();
        private ModelosEscritoadmRN oModelosEscritoRN = new ModelosEscritoadmRN();
        private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();
        private TiposActuacionadmRefRN oTiposActuacionadmRefRN = new TiposActuacionadmRefRN();
        private UsuariosRN oUsuariosRN = new UsuariosRN();
        private ActuacionesadmAD oActuaciones = new ActuacionesadmAD();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public DataTablesResult<ActuacionesadmView> getActuacionesADMGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oActuacionesadmRN.ObtenerParaGrilla(), dataTableParam, a => new ActuacionesadmView()
            {
                Id = a.Id,
                Expediente = a.Expediente,
                Descripcion = a.Descripcion,
                Fecha = a.Fecha,
                FechaRecepcion = a.FechaRecepcion,
                UsuarioRecepcion = a.UsuarioRecepcion,
                OficinaOrigen = a.OficinaOrigen,
                SubAmbitoOrigen = a.SubAmbitoOrigen,
                Anulado = a.Anulado,
                FechaAnulado = a.FechaAnulado,
                UsuarioAnulacion = a.UsuarioAnulacion,
                MotivoAnulacion = a.MotivoAnulacion,
                Texto = a.Texto,
                FechaPublicacion = a.FechaPublicacion,
                UsuarioPublica = a.UsuarioPublica,
                FechaUltimaModificacion = a.FechaUltimaModificacion,
                TipoActuacion = a.TipoActuacion,
                ModeloAplicado = a.ModeloAplicado,
                Firmante1 = a.Firmante1,
                FechaFirmante1 = a.FechaFirmante1,
                Firmante2 = a.Firmante2,
                FechaFirmante2 = a.FechaFirmante2,
                Firmante3 = a.Firmante3,
                FechaFirmante3 = a.FechaFirmante3,
                Firmante4 = a.Firmante4,
                FechaFirmante4 = a.FechaFirmante4,
                Firmante5 = a.Firmante5,
                FechaFirmante5 = a.FechaFirmante5,
                RequiereCargo = a.RequiereCargo,
                SubAmbitoCargo = a.SubAmbitoCargo,
                FechaCargo = a.FechaCargo,
                UsuarioCargo = a.UsuarioCargo,
                Fojas = a.Fojas,
            });
        }

        public ActionResult Crear(int expediente)
        {
            ViewBag.TiposActuacionADMRef = new SelectList(oTiposActuacionadmRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.ModelosEscrito = new SelectList(oModelosEscritoRN.ObtenerTodo().Where(m => m.Oficina == SessionHelper.OficinaActual.Value).ToList(), "Id", "Titulo");
            ViewBag.Ambitos = new SelectList(oAmbitosRN.ObtenerTodo().Where(a => a.Fuero == 4).ToList(), "Id", "Descripcion");
            ViewBag.Organismos = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Expediente = expediente;
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult GuardarAutomatica(string texto, int expediente, int tipo, bool requierecargo, string descripcion)
        {

            try
            {
                var actuacion = new Actuacionesadm()
                {
                    Texto = texto,
                    Expediente = expediente,
                    OficinaOrigen = SessionHelper.OficinaActual.Value,
                    Fecha = DateTime.Now,
                    Anulado = false,
                    FechaPublicacion = DateTime.Now,
                    FechaUltimaModificacion = DateTime.Now,
                    UsuarioAlta = SessionHelper.IdUsuario.Value,
                    TipoActuacion = tipo,
                    RequiereCargo = requierecargo,
                    Descripcion = descripcion
                };

                oActuacionesadmRN.Guardar(actuacion);

                return Json(new object[] { true, String.Format("Se guardo la actuación satisfactoriamente") });
            }
            catch (Exception e)
            {
                return Json(new object[] { false, String.Format("Ocurrió un error al guardar la actuación") });
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Crear(Actuacionesadm actuacionesadm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (actuacionesadm.OrganismoCargo.HasValue && actuacionesadm.OrganismoCargo.Value == 0)
                        actuacionesadm.OrganismoCargo = null;

                    if (actuacionesadm.SubAmbitoCargo.HasValue && actuacionesadm.SubAmbitoCargo.Value == 0)
                        actuacionesadm.SubAmbitoCargo = null;

                    actuacionesadm.OficinaOrigen = SessionHelper.OficinaActual.Value;
                    oActuacionesadmRN.Guardar(actuacionesadm);
                    return Json(new object[] { true, String.Format("Se guardo ActuacionesADM satisfactoriamente") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar ActuacionesADM" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar ActuacionesADM" });
            }
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Editar(Actuacionesadm actuacionesadm)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                if (actuacionesadm.OrganismoCargo == 0)
                    actuacionesadm.OrganismoCargo = null;

                    oActuacionesadmRN.Actualizar(actuacionesadm);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente ActuacionesADM") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse ActuacionesADM" });
                }
           // }
            //else
           // {
            //    return Json(new object[] { false, "No pudo guardarse ActuacionesADM" });
            //}

        }

        public ActionResult Editar(int id = 0)
        {

            //ViewBag.TiposActuacionADMRef = new SelectList(oTiposActuacionadmRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            //ViewBag.ModelosEscrito = new SelectList(oModelosEscritoRN.ObtenerTodo().Where(m => m.Oficina == SessionHelper.OficinaActual.Value).ToList(), "Id", "Titulo");
            //ViewBag.Ambitos = new SelectList(oAmbitosRN.ObtenerTodo().Where(a => a.Fuero == 4).ToList(), "Id", "Descripcion");

            ViewBag.TiposActuacionADMRef = new SelectList(oTiposActuacionadmRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.ModelosEscrito = new SelectList(oModelosEscritoRN.ObtenerTodo().Where(m => m.Oficina == SessionHelper.OficinaActual.Value).ToList(), "Id", "Titulo");
            ViewBag.Ambitos = new SelectList(oAmbitosRN.ObtenerTodo().Where(a => a.Fuero == 4).ToList(), "Id", "Descripcion");
            ViewBag.Organismos = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");

            Actuacionesadm actuacionesadm = oActuacionesadmRN.ObtenerPorId(id);
            if (actuacionesadm == null)
            {
                return HttpNotFound();
            }
            return View(actuacionesadm);
        }


        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oActuacionesadmRN.Eliminar(id);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el actuacionesadm" });
            }
        }

        public JsonResult JsonT(string term)
        {
            var res = from x in this.oActuacionesadmRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oActuacionesadmRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ActuacionesConCargo(int organismo)
        {
            var res = (from x in this.oActuaciones.ActuacionConCargoPendiente(organismo)
                       select x).ToList();
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            oActuacionesadmRN.Dispose();

            oAmbitosRN.Dispose();

            oExpedientesadmRN.Dispose();

            oModelosEscritoRN.Dispose();

            oOrganismosRefRN.Dispose();

            oTiposActuacionadmRefRN.Dispose();

            oUsuariosRN.Dispose();

            base.Dispose(disposing);
        }

    } //fin de clase
}
