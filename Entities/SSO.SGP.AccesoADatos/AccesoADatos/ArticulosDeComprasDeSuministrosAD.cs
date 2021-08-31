
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ArticulosDeComprasDeSuministrosAD
	{
		private BDEntities db = new BDEntities();

		public ArticulosDeComprasDeSuministros ObtenerPorId(int Id)
		{
			return db.ArticulosDeComprasDeSuministros.Single(c => c.Id == Id);
		}

		public DbQuery<ArticulosDeComprasDeSuministros> ObtenerTodo()
		{
			return (DbQuery<ArticulosDeComprasDeSuministros>)db.ArticulosDeComprasDeSuministros;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ArticulosDeComprasDeSuministros
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ArticulosDeComprasDeSuministrosView> ObtenerParaGrilla()
		{
			var x = from c in db.ArticulosDeComprasDeSuministros
					select new ArticulosDeComprasDeSuministrosView
					{
						 Id = c.Id,
						 Compra = c.Compra,
						 Articulo = c.Articulo,
						 Cantidad = c.Cantidad,
						 Precio = c.Precio,
					};
			return (DbQuery<ArticulosDeComprasDeSuministrosView>)x;
		}

        public DbQuery<ArticulosDeComprasDeSuministros> articulosBorradosDeCompra(CustomCompraDeSuministros custom) {

            var articulos = from x in db.ArticulosDeComprasDeSuministros
                    where x.Compra == custom.Id
                    select x;

            return (DbQuery<ArticulosDeComprasDeSuministros>) articulos;
        }

		public void Guardar(ArticulosDeComprasDeSuministros Objeto)
		{
			try
			{
				db.ArticulosDeComprasDeSuministros.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArticulosDeComprasDeSuministros Objeto)
		{
			try
			{
				db.ArticulosDeComprasDeSuministros.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
				ArticulosDeComprasDeSuministros Objeto = this.ObtenerPorId(IdObjeto);
				db.ArticulosDeComprasDeSuministros.Remove(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}

		public DbQuery<ArticulosDeComprasDeSuministrosViewT> JsonT(string term)
		{
			var x = from c in db.ArticulosDeComprasDeSuministros
					select new ArticulosDeComprasDeSuministrosViewT
					{
						 Id = c.Id,
						 Compra = c.Compra,
						 Articulo = c.Articulo,
						 Cantidad = c.Cantidad,
						 Precio = c.Precio,
					};
			return (DbQuery<ArticulosDeComprasDeSuministrosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
