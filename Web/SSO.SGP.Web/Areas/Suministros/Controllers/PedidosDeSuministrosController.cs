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

namespace SSO.SGP.Web.Areas.Suministros.Controllers
{
    public class PedidosDeSuministrosController : Controller
    {
        private PedidosDeSuministrosRN oPedidosDeSuministrosRN = new PedidosDeSuministrosRN();
        private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();
        private ArticulosDePedidoDeSuministrosRN oArticulosDePedidoDeSuministrosRN = new ArticulosDePedidoDeSuministrosRN();
        private ArticulosDeSuministrosRN oArticulosDeSuministrosRN = new ArticulosDeSuministrosRN();

        private UsuariosRN oUsuariosRN = new UsuariosRN();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public DataTablesResult<PedidosDeSuministrosView> getPedidosDeSuministrosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oPedidosDeSuministrosRN.ObtenerParaGrilla(), dataTableParam, a => new PedidosDeSuministrosView()
            {
                Id = a.Id,
                Organismo = a.Organismo,
                FechaDePedido = a.FechaDePedido,
                FechaDeCarga = a.FechaDeCarga,
                Entregado = a.Entregado
            });
        }

        public ActionResult Crear()
        {
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(CustomPedidoDeSuministros p)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                PedidosDeSuministros pedido = new PedidosDeSuministros();
                pedido.Organismo = p.Organismo;
                pedido.Usuario = 3927;
                pedido.FechaDeCarga = DateTime.Now;
                pedido.Entregado = p.Entregado;
                pedido.FechaDePedido = p.FechaDePedido;

                oPedidosDeSuministrosRN.Guardar(pedido);

                // Guardar el detalle y descontar el stock de articulos
                foreach (var a in p.Detalle)
                {
                    ArticulosDePedidoDeSuministros ap = new ArticulosDePedidoDeSuministros();
                    ap.Articulo = a.idarticulo;
                    ap.CantidadEntregada = a.entregado;
                    ap.CantidadPedida = a.solicitado;
                    ap.Pedido = pedido.Id;

                    oArticulosDePedidoDeSuministrosRN.Guardar(ap);

                    // actualizar el stock
                    var articulo = oArticulosDeSuministrosRN.ObtenerPorId(a.idarticulo);
                    articulo.Stock = articulo.Stock - a.entregado;
                    oArticulosDeSuministrosRN.Actualizar(articulo);

                }

                //oPedidosDeSuministrosRN.Guardar(pedidosdesuministros);
                return Json(new object[] { true, String.Format("Se guardo el Pedido satisfactoriamente"), pedido.Id });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No se ha podido guardar PedidosDeSuministros" });
            }
            //}
            //else
            //{
            //    return Json(new object[] { false, "No se ha podido guardar PedidosDeSuministros" });
            //}
        }


        [HttpPost]
        public ActionResult Editar(CustomPedidoDeSuministros custom)
        {
            try
            {
                PedidosDeSuministros pedido = new PedidosDeSuministros();
                pedido = oPedidosDeSuministrosRN.ObtenerPorId(custom.Id);

                // los articulos que ya existiam
                var existen = custom.Detalle.Where(a => pedido.ArticulosDePedidoDeSuministros.Any(a2 => a2.Articulo == a.idarticulo));
                foreach (var a in existen)
                {
                    ArticulosDePedidoDeSuministros articulopedido = oArticulosDePedidoDeSuministrosRN.ObtenerPorId(a.id);

                    // si se modifica la cantidad entregada
                    if (a.entregado != articulopedido.CantidadEntregada)
                    {

                        //actualizar el stock
                        var articulo = oArticulosDeSuministrosRN.ObtenerPorId(a.idarticulo);

                        articulo.Stock = articulo.Stock + articulopedido.CantidadEntregada - a.entregado;
                        oArticulosDeSuministrosRN.Actualizar(articulo);

                        articulopedido.CantidadEntregada = a.entregado;
                        articulopedido.CantidadPedida = a.solicitado;

                        this.oArticulosDePedidoDeSuministrosRN.Actualizar(articulopedido);

                    }

                }

                var nuevos = custom.Detalle.Where(a => !pedido.ArticulosDePedidoDeSuministros.Any(a2 => a2.Articulo == a.idarticulo));
                foreach (var a in nuevos)
                {
                    ArticulosDePedidoDeSuministros articulopedido = new ArticulosDePedidoDeSuministros();
                    articulopedido.Articulo = a.idarticulo;
                    articulopedido.Pedido = custom.Id;
                    articulopedido.CantidadEntregada = a.entregado;
                    articulopedido.CantidadPedida = a.solicitado;

                    //guardar en la compra en nuevo articulo
                    this.oArticulosDePedidoDeSuministrosRN.Guardar(articulopedido);

                    //actualizar el stock
                    var articulo = oArticulosDeSuministrosRN.ObtenerPorId(a.idarticulo);
                    articulo.Stock = articulo.Stock - a.entregado;
                    oArticulosDeSuministrosRN.Actualizar(articulo);
                }

                //articulos que se quitaron en la edicion
                var eliminados = pedido.ArticulosDePedidoDeSuministros.Where(a => !custom.Detalle.Any(a2 => a2.idarticulo == a.Articulo));
                foreach (var a in eliminados)
                {
                    var articulo = oArticulosDeSuministrosRN.ObtenerPorId(a.Articulo);
                    articulo.Stock = articulo.Stock + a.CantidadEntregada;
                    //actualizar el stock
                    oArticulosDeSuministrosRN.Actualizar(articulo);
                    //quitar el articulo del detalle de la compra
                    this.oArticulosDePedidoDeSuministrosRN.Eliminar(a.Id);
                }

                pedido.FechaDePedido = custom.FechaDePedido;
                pedido.Organismo = custom.Organismo;
                pedido.Entregado = custom.Entregado;

                oPedidosDeSuministrosRN.Actualizar(pedido);

                return Json(new object[] { true, String.Format("Se actualizó satisfactoriamente el pedido " + custom.Id), custom.Id });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo actualizarse el pedido " + custom.Id, custom.Id });
            }

        }

        public ActionResult Editar(int id = 0)
        {

            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");

            CustomPedidoDeSuministros p = new CustomPedidoDeSuministros();
            PedidosDeSuministros pedido = oPedidosDeSuministrosRN.ObtenerPorId(id);

            p.Entregado = pedido.Entregado;
            p.FechaDePedido = pedido.FechaDePedido;
            p.Organismo = pedido.Organismo;
            p.Id = pedido.Id;

            p.Detalle = (from x in pedido.ArticulosDePedidoDeSuministros
                         select new DetalleDePedido { articulo = x.Articulos.Nombre, idarticulo = x.Articulo, id = x.Id, entregado = x.CantidadEntregada, nuevo = false, solicitado = x.CantidadPedida }).ToArray();

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }


        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                //var p = oPedidosDeSuministrosRN.ObtenerPorId(id);

                //foreach (var a in p.ArticulosDePedidoDeSuministros.ToList())
                //{
                //    var art = a.Articulos;
                //    art.Stock = art.Stock + a.CantidadEntregada;

                //    new ArticulosDeSuministrosRN().Actualizar(art);
                //}

                oPedidosDeSuministrosRN.Eliminar(id, SessionHelper.IdUsuario.Value);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el pedidosdesuministros" });
            }
        }

        public JsonResult JsonT(string term)
        {
            var res = from x in this.oPedidosDeSuministrosRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oPedidosDeSuministrosRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            oPedidosDeSuministrosRN.Dispose();

            oOrganismosRefRN.Dispose();

            oPedidosDeSuministrosRN.Dispose();

            oUsuariosRN.Dispose();

            base.Dispose(disposing);
        }

    } //fin de clase
}
