
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
	public partial class MovimientosDeStockAD
	{
		private BDEntities db = new BDEntities();

		public MovimientosDeStock ObtenerPorId(int Id)
		{
			return db.MovimientosDeStock.Single(c => c.Id == Id);
		}

		public DbQuery<MovimientosDeStock> ObtenerTodo()
		{
			return (DbQuery<MovimientosDeStock>)db.MovimientosDeStock;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MovimientosDeStock
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MovimientosDeStockView> ObtenerParaGrilla()
		{
			var x = from c in db.MovimientosDeStock
					select new MovimientosDeStockView
					{
						 Id = c.Id,
						 Pedido = c.Pedido,
						 Movimiento = c.Movimiento,
						 Cantidad = c.Cantidad,
						 Articulo = c.Articulo,
						 CausaExpurgue = c.CausaExpurgue,
						 Compra = c.Compra,
						 Fecha = c.Fecha,
					};
			return (DbQuery<MovimientosDeStockView>)x;
		}

		public void Guardar(MovimientosDeStock Objeto)
		{
			try
			{
				db.MovimientosDeStock.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MovimientosDeStock Objeto)
		{
			try
			{
				db.MovimientosDeStock.Attach(Objeto);
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
				MovimientosDeStock Objeto = this.ObtenerPorId(IdObjeto);
				db.MovimientosDeStock.Remove(Objeto);
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

		public DbQuery<MovimientosDeStockViewT> JsonT(string term)
		{
			var x = from c in db.MovimientosDeStock
					select new MovimientosDeStockViewT
					{
						 Id = c.Id,
						 Pedido = c.Pedido,
						 Movimiento = c.Movimiento,
						 Cantidad = c.Cantidad,
						 Articulo = c.Articulo,
						 CausaExpurgue = c.CausaExpurgue,
						 Compra = c.Compra,
						 Fecha = c.Fecha,
					};
			return (DbQuery<MovimientosDeStockViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
