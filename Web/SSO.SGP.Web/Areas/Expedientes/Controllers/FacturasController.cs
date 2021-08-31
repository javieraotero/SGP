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
using SSO.SGP.AccesoADatos;
using Syncrosoft.Framework.Utils.Logs;
using Newtonsoft.Json;
using System.Collections.Generic;
using SSO.SGP.Web.Models;

namespace SSO.SGP.Web.Areas.Expedientes.Controllers
{
    public class FacturasController : Controller
    {
        private FacturasRN oFacturasRN = new FacturasRN();
        private ExpedientesadmRN oExpedientesadmRN = new ExpedientesadmRN();
        private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();
        private ProveedoresRN oProveedoresRN = new ProveedoresRN();
        private FacturasAD oFacturasAD = new FacturasAD();
        private UnidadesDeOrganizacionRefAD oUnidadDeOrganizacion = new UnidadesDeOrganizacionRefAD();
        private FacturasImputadasAD oFacturasImputadas = new FacturasImputadasAD();
        private ParametrosadmRN oParametros = new ParametrosadmRN();
        private TiposExpedienteadmRefAD oTiposExpedientes = new TiposExpedienteadmRefAD();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult ArmarExpediente()
        {
            var f = oFacturasAD.FacturasSinExpedienteJson().ToList();
            return View(f);
        }

        public ActionResult SinAsignacion()
        {
            return View();
        }

        public ActionResult SinOrdenDePago()
        {
            return View();
        }

        public ActionResult Asignar(int factura)
        {
            var f = oFacturasAD.ObtenerPorId(factura);
            ViewBag.UnidadDeOrganizacion = new SelectList(oUnidadDeOrganizacion.ObtenerTodo().ToList(), "Id", "Nombre");
            ViewBag.Numero = f.NumeroDeFactura;
            ViewBag.Importe = f.Importe;
            ViewBag.Id = factura;
            ViewBag.Resta = (f.FacturasImputadas.Count > 0) ? f.FacturasImputadas.FirstOrDefault().FacturasImputadasDetalle.Sum(d => d.Importe) : 0;

            return View(f.FacturasImputadas.FirstOrDefault());
        }

        public DataTablesResult<FacturasDetalleView> getFacturasGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oFacturasRN.ObtenerParaGrilla(), dataTableParam, a => new FacturasDetalleView()
            {
                Id = a.Id,
                NumeroDeFactura = a.NumeroDeFactura,
                IdentificacionDeFactura = a.IdentificacionDeFactura,
                //Tipo = a.Tipo,
                Concepto = a.Concepto,
                Organismo = a.Organismo,
                Expediente = a.Expediente,
                Proveedor = a.Proveedor,
                Fecha = a.Fecha,
                Importe = a.Importe,
            });
        }

        public DataTablesResult<FacturasView> getFacturasSinAsignar(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oFacturasAD.FacturasSinAsignar(), dataTableParam, a => new FacturasView()
            {
                Id = a.Id,
                NumeroDeFactura = a.NumeroDeFactura,
                IdentificacionDeFactura = a.IdentificacionDeFactura,
                Tipo = a.Tipo,
                Expediente = a.Expediente,
                Proveedor = a.Proveedor,
                Fecha = a.Fecha,
                Importe = a.Importe,
            });
        }

        public DataTablesResult<FacturasView> getFacturasAfectadasSinOrdenDePago(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oFacturasAD.FacturasAfectadasSinOrdenDePago(), dataTableParam, a => new FacturasView()
            {
                Id = a.Id,
                NumeroDeFactura = a.NumeroDeFactura,
                IdentificacionDeFactura = a.IdentificacionDeFactura,
                Tipo = a.Tipo,
                Expediente = a.Expediente,
                Proveedor = a.Proveedor,
                Fecha = a.Fecha,
                Importe = a.Importe,
            });
        }

        public DataTablesResult<FacturasView> getFacturasSinExpediente(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oFacturasAD.FacturasSinExpediente(), dataTableParam, a => new FacturasView()
            {
                Id = a.Id,
                NumeroDeFactura = a.NumeroDeFactura,
                IdentificacionDeFactura = a.IdentificacionDeFactura,
                Tipo = a.Tipo,
                Expediente = a.Expediente,
                Proveedor = a.Proveedor,
                Fecha = a.Fecha,
                Importe = a.Importe,
            });
        }

        public ActionResult Crear(int? expediente, string numero)
        {
            ViewBag.Expediente = expediente.HasValue ? expediente : 0;
            ViewBag.Numero = numero;

            ViewBag.Proveedores = new SelectList(oProveedoresRN.ObtenerTodo().ToList(), "Id", "Nombre");
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Facturas facturas)
        {
            var identificador = oParametros.ObtenerPorId(1);
            facturas.IdentificacionDeFactura = identificador.UltimaFactura;
            identificador.UltimaFactura++;
            facturas.FechaAlta = DateTime.Now;
            facturas.UsuarioAlta = SessionHelper.IdUsuario.Value;
            facturas.FechaModifica = DateTime.Now;
            facturas.UsuarioModifica = SessionHelper.IdUsuario.Value;

            if (facturas.Expediente == 0)
                facturas.Expediente = null;

            if (string.IsNullOrEmpty(facturas.Tipo))
                facturas.Tipo = "F";

            oParametros.Actualizar(identificador);

            if (ModelState.IsValid)
            {
                try
                {
                    oFacturasRN.Guardar(facturas);
                    return Json(new object[] { true, String.Format("Se guardo Facturas satisfactoriamente") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar Facturas" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar Facturas" });
            }
        }

        [HttpPost]
        public ActionResult asignarFactura(FacturasImputadas imputacion)
        {
            try
            {
                oFacturasImputadas.LimpiarAsignacion(imputacion.Factura, SessionHelper.IdUsuario.Value);
                   
                imputacion.Usuario = SessionHelper.IdUsuario.Value;
                imputacion.Fecha = DateTime.Now;
                //TODO: obtener el año contable del parametro del usuario
                imputacion.AnioContable = DateTime.Now.Year;

                oFacturasImputadas.Guardar(imputacion);

                var f = oFacturasAD.ObtenerPorId(imputacion.Factura);
                f.EstaAsignada = true;

                oFacturasAD.Actualizar(f);

                return Json(new object[] { true, String.Format("Se guardó la asignación de la factura") });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No se ha podido guardar la asignación" });
            }
        }

        [HttpPost]
        public ActionResult ArmarExpediente(List<int> facturas)
        {
            try
            {
                //var t = oParametros.ObtenerPorId(1);
                //var nro = t.UltimoExpediente++;
                var tipo = oTiposExpedientes.ObtenerPorId(1);

                tipo.UltimoNumero++;
                var nro = tipo.UltimoNumero.ToString();
                oTiposExpedientes.Actualizar(tipo);

                var e = new Expedientesadm()
                {
                    Fecha = DateTime.Now,
                    OrganismoIniciador = SessionHelper.OficinaActual.Value,
                    Caratula = "Pago de Facturas varias",
                    UsuarioAlta = SessionHelper.IdUsuario.Value,
                    FechaDeAlta = DateTime.Now,
                    Tipo = 1,
                    Archivado = false,
                    Numero = nro,
                    Categoria = 1
                };

                oExpedientesadmRN.Guardar(e);

                foreach (var i in facturas)
                {

                    var f = oFacturasAD.ObtenerPorId(i);
                    f.Expediente = e.Id;
                    oFacturasAD.Actualizar(f);

                }

                //t.UltimoExpediente++;
                //oParametros.Actualizar(t);

                return Json(new object[] { true, String.Format("Se generó el expediente " + nro + " con éxito"), e.Id });
            }
            catch (Exception e)
            {

                return Json(new object[] { true, String.Format("No se ha podido generar el expediente") });

            }
        }

        [HttpPost]
        public ActionResult Editar(Facturas facturas)
        {
            facturas.FechaModifica = DateTime.Now;
            facturas.UsuarioModifica = SessionHelper.IdUsuario.Value;
            // if (ModelState.IsValid)
            //{
            try
            {
                facturas.FechaModifica = DateTime.Now;
                facturas.UsuarioModifica = SessionHelper.IdUsuario.Value;
                oFacturasRN.Actualizar(facturas);
                return Json(new object[] { true, String.Format("Se guardo satisfactoriamente Facturas") });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo guardarse Facturas" });
            }
            //}
            //else
            //{
            //    return Json(new object[] { false, "No pudo guardarse Facturas" });
            //}

        }

        public ActionResult Editar(int id = 0)
        {

            ViewBag.Proveedores = new SelectList(oProveedoresRN.ObtenerTodo().ToList(), "Id", "Nombre");
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");

            Facturas facturas = oFacturasRN.ObtenerPorId(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }


        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oFacturasRN.Eliminar(id);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el facturas" });
            }
        }

        public JsonResult JsonT(string term)
        {
            var res = from x in this.oFacturasRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oFacturasRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerAsiganacion(int id)
        {
            var res = (from x in this.oFacturasAD.ObtenerAsignacion(id)
                       select x).FirstOrDefault();

            List<FacturasAsignadasModel> m = new List<FacturasAsignadasModel>();

            if (res != null)
            {
                foreach (var d in res.FacturasImputadasDetalle)
                {
                    var i = new FacturasAsignadasModel()
                    {
                        Partida = d.Partida,
                        Division = d.Division,
                        Importe = d.Importe,
                        Id = d.Id
                    };
                    m.Add(i);
                }
            }

            //return JsonResponse(res); 

            return this.Json(m, JsonRequestBehavior.AllowGet);
        }

        //public virtual ActionResult JsonResponse(object obj)
        //{
        //    return Content(JsonConvert.SerializeObject(obj, Formatting.Indented), "application/json");
        //}

        public JsonResult FacturasSinExpedienteJson2()
        {
            var res = from x in this.oFacturasAD.FacturasSinExpedienteJson2()
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            oFacturasRN.Dispose();

            oExpedientesadmRN.Dispose();

            oOrganismosRefRN.Dispose();

            oProveedoresRN.Dispose();

            base.Dispose(disposing);
        }

    } //fin de clase
}
