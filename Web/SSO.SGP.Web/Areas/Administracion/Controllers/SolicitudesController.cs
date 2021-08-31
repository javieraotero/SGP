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
using SSO.SGP.EntidadesDeNegocio.Results;
using SSO.SGP.Web.BasicConsumer;
using SSO.SGP.AccesoADatos;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using Manatee.Trello.ManateeJson;
using Manatee.Trello;
using Manatee.Trello.WebApi;

namespace SSO.SGP.Web.Areas.Administracion.Controllers
{
    public class SolicitudesController : Controller
    {        
        //private AgentesAD oAgentes = new AgentesAD();
        //private CesidaParametrosDeMovimientosAD oParametrosDeMovimiento = new CesidaParametrosDeMovimientosAD();
        private OrganismosRefAD oOrganismosRefAD = new OrganismosRefAD();
        private AdministracionPedidosAD oAdministracionPedidosAD = new AdministracionPedidosAD();
        private AdministracionPedidosActuacionesAD oAdministracionPedidosActuacionesAD = new AdministracionPedidosActuacionesAD();
        private BDEntities db = new BDEntities();

        #region Results

        /*public JsonResult login(string device_id, int legajo) {
            return this.Json(oEstadosLetrasAD.validarApp(device_id, legajo), JsonRequestBehavior.AllowGet);
        }*/

        //public JsonResult testMovimiento() {

        //   Service.post<>


        //}

        /*public JsonResult deviceEnabled(string device_id) {

            var res = new Result();

            if (this.oAgentesRN.deviceEnabled(device_id))
            {
                res.state = true;
                res.message = "Dispositivo habilitado";
                res.exception = "";
            }
            else {
                res.state = false;
                res.message = "Dispositivo deshabilitado";
                res.exception = "El dispositivo " + device_id + " no está habilitado";
            }

            return this.Json(res, JsonRequestBehavior.AllowGet);

        }*/

        #endregion

        public ActionResult IndexRecepcion()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }        

        public ActionResult Default() 
		{
			return View();
		}

        public ActionResult EditarActuacionNO()
        {
            AdministracionPedidosActuaciones o = new AdministracionPedidosActuaciones();
            //ViewBag.OrganismosRef = new SelectList(oOrganismosRefAD.ObtenerTodo().ToList(), "Id", "Descripcion");
            
            return View(o);
            
        }

        public DataTablesResult<AdministracionPedidosSolicitudesView> getAdministracionRecepcionPedidosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oAdministracionPedidosAD.ObtenerParaGrillaRecepcionSolicitudes((int)SessionHelper.OficinaActual), dataTableParam, a => new AdministracionPedidosSolicitudesView()
            {
                Id = a.Id,
                OrganismoOrigen = a.OrganismoOrigen ,
                OrganismoDestino_Hide =a.OrganismoDestino_Hide ,
                Descripcion = a.Descripcion ,
                FechaAlta =a.FechaAlta ,
                UsuarioAlta=a.UsuarioAlta ,
                Numero =a.Numero ,
                //Activo=a.Activo ,
                
            });
          }

        public DataTablesResult<AdministracionPedidosSolicitudesView> getAdministracionPedidosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oAdministracionPedidosAD.ObtenerParaGrillaSolicitudes((int)SessionHelper.OficinaActual), dataTableParam, a => new AdministracionPedidosSolicitudesView()
            {
                Id = a.Id,
                OrganismoOrigen = a.OrganismoOrigen,
                OrganismoDestino_Hide = a.OrganismoDestino_Hide,
                Descripcion = a.Descripcion,
                FechaAlta = a.FechaAlta,
                UsuarioAlta = a.UsuarioAlta,
                Numero = a.Numero,
                //Activo=a.Activo ,

            });
        }


        /*public DataTablesResult<AdministracionPedidosView> getAdministracionPedidosGrillaMM(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oAdministracionPedidosAD.ObtenerParaGrillaMM(), dataTableParam, a => new AdministracionPedidosView()
            {
                Id = a.Id,
                OrganismoOrigen =a.OrganismoOrigen,
                OrganismoDestino =a.OrganismoDestino,
                
                Descripcion = a.Descripcion,
                
                Activo = a.Activo,
                

            });
        }*/


        public JsonResult JsonT(string term)
        {
            var res = from x in this.oAdministracionPedidosAD.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JsonT2(string term)
        {
            var res = from x in this.oAdministracionPedidosActuacionesAD.JsonT(int.Parse (term))
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }


        //--- Utilizar esta acción para Autocomplete
        /*public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oEstadosLetrasAD.ObtenerOptions(term)
                      select new { id = x.value, label = x.text};
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }*/

        //--- Utilizar esta acción para Autocomplete
        /*public JsonResult CesidaCategoriasJson(string term)
        {
            var res = from x in this.oCesidaCategorias.ObtenerOptions(term)
                      select new { id = x.value, label = x.text };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }*/

        public ActionResult Detalle(int id = 0)
        {
            AdministracionPedidosActuaciones  articulosdepedidodesuministros = oAdministracionPedidosActuacionesAD .ObtenerPorId(id);
            if (articulosdepedidodesuministros == null)
            {
                return HttpNotFound();
            }
            return View(articulosdepedidodesuministros);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult GetJson(string term)
        {
            var res = from x in this.oAdministracionPedidosAD.GetJson(term)
                      select new {  id = x.Id,
                                    
                      };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        /*public JsonResult GetParametrosDeMovimiento(int movimiento)
        {
            var res = oParametrosDeMovimiento.ObtenerPorMovmiento(movimiento);
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }*/


        /*public JsonResult OrganismosJson(string term)
        {
            var res = from x in this.oOrganismosRN.ObtenerOptions(term)
                      select new { id=x.value, label=x.text};
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }*/

        public ActionResult Crear()
        {
            //ViewBag.Legajo = oParametrosRN.ObtenerPorId(1).UltimoLegajo.Value;
            AdministracionPedidos o = new AdministracionPedidos()
            {
                //Legajo = oParametrosRN.ObtenerPorId(1).UltimoLegajo.Value
            };
            //ViewBag.CargosRef = new SelectList(oCargosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefAD.ObtenerTodo().ToList(), "Id", "Descripcion");
            //return View(o);
            return View(o);
        }

        [HttpPost]
        public ActionResult Crear(AdministracionPedidos objeto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    objeto.UsuarioAlta = (int)SessionHelper.IdUsuario;
                    objeto.FechaAlta = DateTime.Now;
                    objeto.OrganismoOrigen =(int) SessionHelper.OficinaActual;
                    objeto.Activo = true;
                    objeto.Numero = oAdministracionPedidosAD.UltimoNumeroPedido() + 1;                    
                    oAdministracionPedidosAD.Guardar(objeto);

                    /*Parametrosadm p = oParametrosRN.ObtenerPorId(1);
                    p.UltimoLegajo = agentes.Legajo + 1;
                    oParametrosRN.Actualizar(p);*/

                    return Json(new object[] { true, String.Format("El Pedido se guardó satisfactoriamente") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar el Pedido" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar Pedido" });
            }
        }

        [HttpPost, ActionName("Editar")]
        public ActionResult Editar(AdministracionPedidos objeto)
        {
            try
            {
                AdministracionPedidos pedido = new AdministracionPedidos();
                pedido = oAdministracionPedidosAD.ObtenerPorId(objeto.Id);               

                pedido.Descripcion = objeto.Descripcion ;
                pedido.OrganismoDestino = objeto.OrganismoDestino ;

                oAdministracionPedidosAD.Actualizar(pedido);

                return Json(new object[] { true, String.Format("Se actualizó satisfactoriamente el pedido " + objeto.Id), objeto.Id });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo actualizarse el pedido " + objeto.Id, objeto.Id });
            }

        }

        public ActionResult Editar(int id)
        {

            ViewBag.OrganismosRef = new SelectList(oOrganismosRefAD.ObtenerTodo().ToList(), "Id", "Descripcion");

            AdministracionPedidos p = new AdministracionPedidos();
            AdministracionPedidos pedido = oAdministracionPedidosAD.ObtenerPorId(id);

            CustomAdministracionPedidos  cp = new CustomAdministracionPedidos();

            p.Descripcion  = pedido.Descripcion ;
            p.OrganismoDestino = pedido.OrganismoDestino ;
            p.FechaAlta = pedido.FechaAlta;
            p.UsuarioAlta = pedido.UsuarioAlta;
            p.Activo = pedido.Activo;
            p.OrganismoOrigen = p.OrganismoOrigen;
            p.Id = pedido.Id;

            //cp.Detalle = (from x in pedido.AdministracionPedidosActuaciones
            //             select new DetalleDeAdministracionPedido { descripcion  = x.Descripcion}).ToList();

            ///ViewBag.DetalleVista = (from x in pedido.AdministracionPedidosActuaciones
            ///                        select new DetalleDeAdministracionPedido { Descripcion = x.Descripcion }).ToList();

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        public ActionResult Eliminar(int id )
        {
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefAD.ObtenerTodo().ToList(), "Id", "Descripcion");

            AdministracionPedidos p = new AdministracionPedidos();
            AdministracionPedidos pedido = oAdministracionPedidosAD.ObtenerPorId(id);

            p.Descripcion = pedido.Descripcion;
            p.OrganismoDestino = pedido.OrganismoDestino;
            p.FechaAlta = pedido.FechaAlta;
            p.UsuarioAlta = pedido.UsuarioAlta;
            p.Activo = pedido.Activo;
            p.OrganismoOrigen = p.OrganismoOrigen;
            p.Id = pedido.Id;

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult Eliminar(AdministracionPedidos objeto)
        {
            try
            {
                AdministracionPedidos pedido = new AdministracionPedidos();
                pedido = oAdministracionPedidosAD.ObtenerPorId(objeto.Id);

                pedido.Activo = false;                

                oAdministracionPedidosAD.Actualizar(pedido);

                return Json(new object[] { true, String.Format("Se eliminó satisfactoriamente el pedido " + objeto.Id), objeto.Id });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el pedido " + objeto.Id, objeto.Id });
            }

        }
        
        [HttpPost, ActionName("Recibir")]
        public ActionResult Recibir(AdministracionPedidos objeto)
        {
            try
            {
                AdministracionPedidos pedido = new AdministracionPedidos();
                pedido = oAdministracionPedidosAD.ObtenerPorId(objeto.Id);
                                
                pedido.FechaRecepcion = DateTime.Now;
                pedido.UsuarioRecepcion = (int)SessionHelper.IdUsuario;

                oAdministracionPedidosAD.Actualizar(pedido);

                return Json(new object[] { true, String.Format("Se ha recibido la solicitud " + objeto.Id), objeto.Id });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "La solicitud no pudo ser recibida " + objeto.Id, objeto.Id });
            }

        }

        public ActionResult Recibir(int id)
        {

            ViewBag.OrganismosRef = new SelectList(oOrganismosRefAD.ObtenerTodo().ToList(), "Id", "Descripcion");

            AdministracionPedidos p = new AdministracionPedidos();
            AdministracionPedidos pedido = oAdministracionPedidosAD.ObtenerPorId(id);

            p.Descripcion = pedido.Descripcion;
            p.OrganismoDestino = pedido.OrganismoDestino;
            p.FechaAlta = pedido.FechaAlta;
            p.UsuarioAlta = pedido.UsuarioAlta;
            p.Activo = pedido.Activo;
            p.OrganismoOrigen = p.OrganismoOrigen;
            p.Id = pedido.Id;


            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        [HttpPost, ActionName("Rechazar")]
        public ActionResult Rechazar(AdministracionPedidos objeto)
        {
            try
            {
                AdministracionPedidos pedido = new AdministracionPedidos();
                pedido = oAdministracionPedidosAD.ObtenerPorId(objeto.Id);

                pedido.MotivoRechazado = objeto.MotivoRechazado;
                pedido.FechaRechazado = DateTime.Now;
                pedido.UsuarioRechazado = (int)SessionHelper.IdUsuario;

                oAdministracionPedidosAD.Actualizar(pedido);

                return Json(new object[] { true, String.Format("Se ha rechazado la solicitud " + objeto.Id), objeto.Id });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "La solicitud no pudo ser rechazada " + objeto.Id, objeto.Id });
            }

        }

        public ActionResult Rechazar(int id)
        {

            ViewBag.OrganismosRef = new SelectList(oOrganismosRefAD.ObtenerTodo().ToList(), "Id", "Descripcion");

            AdministracionPedidos p = new AdministracionPedidos();
            AdministracionPedidos pedido = oAdministracionPedidosAD.ObtenerPorId(id);

            p.Descripcion = pedido.Descripcion;
            p.OrganismoDestino = pedido.OrganismoDestino;
            p.FechaAlta = pedido.FechaAlta;
            p.UsuarioAlta = pedido.UsuarioAlta;
            p.Activo = pedido.Activo;
            p.OrganismoOrigen = p.OrganismoOrigen;
            p.Id = pedido.Id;

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // ---------------------- ACTUACIONES -------------------------------

        [HttpPost, ActionName("EditarActuacion")]
        public ActionResult EditarActuacion(AdministracionPedidosActuaciones objeto)
        {
            try
            {
                AdministracionPedidosActuaciones actuacion = new AdministracionPedidosActuaciones();
                if (objeto.Id == 0)
                {
                    actuacion.Descripcion = objeto.Descripcion;
                    actuacion.Pedido = objeto.Pedido;
                    actuacion.Activo = true;
                    actuacion.FechaAlta = DateTime.Today;
                    actuacion.UsuarioAlta = (int)SessionHelper.IdUsuario;

                    oAdministracionPedidosActuacionesAD.Guardar (actuacion);

                }
                else
                {

                    actuacion = oAdministracionPedidosActuacionesAD.ObtenerPorId(objeto.Id);

                    actuacion.Descripcion = objeto.Descripcion;
                    
                    oAdministracionPedidosActuacionesAD.Actualizar(actuacion);
                }
                return Json(new object[] { true, String.Format("Se actualizó satisfactoriamente la actuación " + objeto.Id), objeto.Id });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo actualizarse la actuación " + objeto.Id, objeto.Id });
            }

        }

        public ActionResult EditarActuacion(int id, int idpedido)
        {

            //ViewBag.OrganismosRef = new SelectList(oOrganismosRefAD.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.IdPedido = idpedido;
            AdministracionPedidosActuaciones  p = new AdministracionPedidosActuaciones();
            p.Pedido = idpedido;
            if (id != 0)
            {
                AdministracionPedidosActuaciones pedido = oAdministracionPedidosActuacionesAD.ObtenerPorId(id);

                p.Descripcion = pedido.Descripcion;
                p.FechaAlta = pedido.FechaAlta;
                p.UsuarioAlta = pedido.UsuarioAlta;
                p.Activo = pedido.Activo;
                p.Id = pedido.Id;
            }

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }


        protected override void Dispose(bool disposing)
        {
            oAdministracionPedidosAD.Dispose();
            oAdministracionPedidosActuacionesAD.Dispose();
            oOrganismosRefAD.Dispose();
            			
            base.Dispose(disposing);
        }
	
	} //fin de clase
}
