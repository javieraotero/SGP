
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
	public partial class ArticulosDePedidoDeSuministrosAD
	{
		private BDEntities db = new BDEntities();

		public ArticulosDePedidoDeSuministros ObtenerPorId(int Id)
		{
			return db.ArticulosDePedidoDeSuministros.Single(c => c.Id == Id);
		}

		public DbQuery<ArticulosDePedidoDeSuministros> ObtenerTodo()
		{
			return (DbQuery<ArticulosDePedidoDeSuministros>)db.ArticulosDePedidoDeSuministros;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ArticulosDePedidoDeSuministros
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ArticulosDePedidoDeSuministrosView> ObtenerParaGrilla()
		{
			var x = from c in db.ArticulosDePedidoDeSuministros
					select new ArticulosDePedidoDeSuministrosView
					{
						 Id = c.Id,
						 Articulo = c.Articulo,
						 Pedido = c.Pedido,
						 CantidadEntregada = c.CantidadEntregada,
						 Precio = c.Precio,
						 CantidadPedida = c.CantidadPedida,
					};
			return (DbQuery<ArticulosDePedidoDeSuministrosView>)x;
		}

		public void Guardar(ArticulosDePedidoDeSuministros Objeto)
		{
			try
			{
				db.ArticulosDePedidoDeSuministros.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArticulosDePedidoDeSuministros Objeto)
		{
			try
			{
				db.ArticulosDePedidoDeSuministros.Attach(Objeto);
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
				ArticulosDePedidoDeSuministros Objeto = this.ObtenerPorId(IdObjeto);
				db.ArticulosDePedidoDeSuministros.Remove(Objeto);
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

		public DbQuery<ArticulosDePedidoDeSuministrosViewT> JsonT(string term)
		{
			var x = from c in db.ArticulosDePedidoDeSuministros
					select new ArticulosDePedidoDeSuministrosViewT
					{
						 Id = c.Id,
						 Articulo = c.Articulo,
						 Pedido = c.Pedido,
						 CantidadEntregada = c.CantidadEntregada,
						 Precio = c.Precio,
						 CantidadPedida = c.CantidadPedida,
					};
			return (DbQuery<ArticulosDePedidoDeSuministrosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
