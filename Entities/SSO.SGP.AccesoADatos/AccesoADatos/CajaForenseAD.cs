
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
	public partial class CajaForenseAD
	{
		private BDEntities db = new BDEntities();

		public CajaForense ObtenerPorId(int Id)
		{
			return db.CajaForense.Single(c => c.Id == Id);
		}

		public DbQuery<CajaForense> ObtenerTodo()
		{
			return (DbQuery<CajaForense>)db.CajaForense;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CajaForense
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CajaForenseView> ObtenerParaGrilla()
		{
			var x = from c in db.CajaForense
					select new CajaForenseView
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Interes = c.Interes,
						 InteresAcu = c.InteresAcu,
					};
			return (DbQuery<CajaForenseView>)x;
		}

		public void Guardar(CajaForense Objeto)
		{
			try
			{
				db.CajaForense.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CajaForense Objeto)
		{
			try
			{
				db.CajaForense.Attach(Objeto);
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
				CajaForense Objeto = this.ObtenerPorId(IdObjeto);
				db.CajaForense.Remove(Objeto);
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

		public DbQuery<CajaForenseViewT> JsonT(string term)
		{
			var x = from c in db.CajaForense
					select new CajaForenseViewT
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Interes = c.Interes,
						 InteresAcu = c.InteresAcu,
					};
			return (DbQuery<CajaForenseViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
