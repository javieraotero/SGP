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

namespace SSO.SGP.Web.Areas.Suministros.Controllers
{
    public class CompraDeSuministrosController : Controller
    {
        private CompraDeSuministrosRN oCompraDeSuministrosRN = new CompraDeSuministrosRN();
        private UsuariosRN oUsuariosRN = new UsuariosRN();
        private ArticulosDeComprasDeSuministrosRN oArticulosDeCompraDeSuminitrosRN = new ArticulosDeComprasDeSuministrosRN();
        private ArticulosDeSuministrosRN oArticulosDeSuministrosRN = new ArticulosDeSuministrosRN();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public DataTablesResult<CompraDeSuministrosView> getCompraDeSuministrosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oCompraDeSuministrosRN.ObtenerParaGrilla(), dataTableParam, a => new CompraDeSuministrosView()
            {
                Id = a.Id,
                Fecha = a.Fecha,
                Comprobante = a.Comprobante,
                FechaDeCarga = a.FechaDeCarga
            });
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(CustomCompraDeSuministros c)
        {
            try
            {
                CompraDeSuministros compra = new CompraDeSuministros();
                compra.Fecha = c.Fecha;
                compra.Comprobante = c.Comprobante;
                compra.FechaDeCarga = DateTime.Now;
                compra.Usuario = SessionHelper.IdUsuario.Value;
                                
                oCompraDeSuministrosRN.Guardar(compra);
                
                // guardar el detalle de la compra
                foreach(var a in c.Detalle) {

                    ArticulosDeComprasDeSuministros ac = new ArticulosDeComprasDeSuministros();
                    ac.Articulo = a.idarticulo;
                    ac.Cantidad = a.cantidad;
                    ac.Precio = a.precio;
                    ac.Compra = compra.Id;

                    oArticulosDeCompraDeSuminitrosRN.Guardar(ac);

                    //suma al stock el artículo y actualiza último costo
                    var articulo = oArticulosDeSuministrosRN.ObtenerPorId(a.idarticulo);
                    articulo.Stock = articulo.Stock + a.cantidad;
                    articulo.UltimoCosto = a.precio;
                    oArticulosDeSuministrosRN.Actualizar(articulo);


                }

                
                return Json(new object[] { true, String.Format("Se registró  la compra satisfactoriamente") });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No se ha podido registrar la compra" });
            }

        }


        [HttpPost]
        public ActionResult Editar(CustomCompraDeSuministros compra)
        {
            
            CompraDeSuministros c = oCompraDeSuministrosRN.ObtenerPorId(compra.Id);
            int diferencia = 0;

            //artículos que ya estaban en la compra
            var existen = compra.Detalle.Where(a => c.ArticulosDeComprasDeSuministros.Any(a2 => a2.Articulo == a.idarticulo));
            foreach (var a in existen)
            {
                ArticulosDeComprasDeSuministros articulocompra = oArticulosDeCompraDeSuminitrosRN.ObtenerPorId(a.id);
                
                //si cambió la cantidad
                if (a.cantidad != articulocompra.Cantidad)
                {
                    //actualizar el stock
                    var articulo = oArticulosDeSuministrosRN.ObtenerPorId(a.idarticulo);
                    articulo.Stock = articulo.Stock - articulocompra.Cantidad + a.cantidad;
                    articulo.UltimoCosto = a.precio;
                    oArticulosDeSuministrosRN.Actualizar(articulo);

                    articulocompra.Cantidad = a.cantidad;
                    articulocompra.Precio = a.precio;

                    oArticulosDeCompraDeSuminitrosRN.Actualizar(articulocompra);

                }
            }

            //articulos que se agregaron (no estaban)
            var nuevos = compra.Detalle.Where(a => !c.ArticulosDeComprasDeSuministros.Any(a2 => a2.Articulo == a.idarticulo));
            foreach (var a in nuevos)
            {
                ArticulosDeComprasDeSuministros articulocompra = new ArticulosDeComprasDeSuministros();
                articulocompra.Articulo = a.idarticulo;
                articulocompra.Compra = compra.Id;
                articulocompra.Cantidad = a.cantidad;
                articulocompra.Precio = a.precio;

                //guardar en la compra en nuevo articulo
                oArticulosDeCompraDeSuminitrosRN.Guardar(articulocompra);
            
                //actualizar el stock
                var articulo = oArticulosDeSuministrosRN.ObtenerPorId(a.idarticulo);
                articulo.Stock = articulo.Stock + a.cantidad;
                articulo.UltimoCosto = a.precio;
                oArticulosDeSuministrosRN.Actualizar(articulo);
            }

            //articulos que se quitaron en la edicion
            var eliminados = c.ArticulosDeComprasDeSuministros.Where(a => !compra.Detalle.Any(a2 => a2.idarticulo == a.Articulo));
            foreach (var a in eliminados)
            {
                var articulo = oArticulosDeSuministrosRN.ObtenerPorId(a.Articulo);
                articulo.Stock = articulo.Stock - a.Cantidad;
                //actualizar el stock
                oArticulosDeSuministrosRN.Actualizar(articulo);
                //quitar el articulo del detalle de la compra
                oArticulosDeCompraDeSuminitrosRN.Eliminar(a.Id);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //oCompraDeSuministrosRN.Actualizar(compradesuministros);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente CompraDeSuministros") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse CompraDeSuministros" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse CompraDeSuministros" });
            }

        }

        public ActionResult Editar(int id = 0)
        {

            CompraDeSuministros compra = oCompraDeSuministrosRN.ObtenerPorId(id);

            CustomCompraDeSuministros c = new CustomCompraDeSuministros();

            c.Fecha = compra.Fecha;
            c.Id = compra.Id;
            c.Comprobante = compra.Comprobante;

            c.Detalle = (from x in compra.ArticulosDeComprasDeSuministros
                         select new DetalleDeCompra { articulo = x.Articulos.Nombre, idarticulo = x.Articulo, cantidad = x.Cantidad, precio = x.Precio, id = x.Id, nuevo = false }).ToArray();
            
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }


        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oCompraDeSuministrosRN.Eliminar(id, SessionHelper.IdUsuario.Value);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el compradesuministros" });
            }
        }

        public JsonResult JsonT(string term)
        {
            var res = from x in this.oCompraDeSuministrosRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oCompraDeSuministrosRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            oCompraDeSuministrosRN.Dispose();

            oUsuariosRN.Dispose();

            base.Dispose(disposing);
        }

    } //fin de clase
}
