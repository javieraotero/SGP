
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
	public partial class ArticulosDeSuministrosAD
	{
		private BDEntities db = new BDEntities();

		public ArticulosDeSuministros ObtenerPorId(int Id)
		{
			return db.ArticulosDeSuministros.Single(c => c.Id == Id);
		}

		public DbQuery<ArticulosDeSuministros> ObtenerTodo()
		{
			return (DbQuery<ArticulosDeSuministros>)db.ArticulosDeSuministros;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ArticulosDeSuministros
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ArticulosDeSuministrosView> ObtenerParaGrilla()
		{
			var x = from c in db.ArticulosDeSuministros
					select new ArticulosDeSuministrosView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Codigo = c.Codigo,
						 StockMinimo = c.StockMinimo,
						 Stock = c.Stock,
						 UltimoCosto = c.UltimoCosto,
						 //FechaUltimoPrecio = c.FechaUltimoPrecio
					};
			return (DbQuery<ArticulosDeSuministrosView>)x;
		}

		public void Guardar(ArticulosDeSuministros Objeto)
		{
			try
			{
				db.ArticulosDeSuministros.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArticulosDeSuministros Objeto)
		{
			try
			{
				db.ArticulosDeSuministros.Attach(Objeto);
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
				ArticulosDeSuministros Objeto = this.ObtenerPorId(IdObjeto);
				db.ArticulosDeSuministros.Remove(Objeto);
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

		public DbQuery<ArticulosDeSuministrosViewT> JsonT(string term)
		{
			var x = from c in db.ArticulosDeSuministros
                    where c.Nombre.Contains(term)
					select new ArticulosDeSuministrosViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Codigo = c.Codigo,
						 StockMinimo = c.StockMinimo,
						 Stock = c.Stock,
						 UltimoCosto = c.UltimoCosto,
						 FechaUltimoPrecio = c.FechaUltimoPrecio,
						 FechaDeBaja = c.FechaDeBaja,
					};
			return (DbQuery<ArticulosDeSuministrosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
