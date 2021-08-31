
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
	public partial class ExpedientesAccesosAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesAccesos ObtenerPorId(int Id)
		{
			return db.ExpedientesAccesos.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesAccesos> ObtenerTodo()
		{
			return (DbQuery<ExpedientesAccesos>)db.ExpedientesAccesos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesAccesos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesAccesosView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesAccesos
					select new ExpedientesAccesosView
					{
						 Id = c.Id,
						 Expedientes = c.Expedientes,
						 Actuacion = c.Actuacion,
						 Usuario = c.Usuario,
						 FechaHora = c.FechaHora,
					};
			return (DbQuery<ExpedientesAccesosView>)x;
		}

		public void Guardar(ExpedientesAccesos Objeto)
		{
			try
			{
				db.ExpedientesAccesos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesAccesos Objeto)
		{
			try
			{
				db.ExpedientesAccesos.Attach(Objeto);
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
				ExpedientesAccesos Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesAccesos.Remove(Objeto);
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

		public DbQuery<ExpedientesAccesosViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesAccesos
					select new ExpedientesAccesosViewT
					{
						 Id = c.Id,
						 Expedientes = c.Expedientes,
						 Actuacion = c.Actuacion,
						 Usuario = c.Usuario,
						 FechaHora = c.FechaHora,
					};
			return (DbQuery<ExpedientesAccesosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
