
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
	public partial class ExpedientesSumariantesRelAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesSumariantesRel ObtenerPorId(int Id)
		{
			return db.ExpedientesSumariantesRel.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesSumariantesRel> ObtenerTodo()
		{
			return (DbQuery<ExpedientesSumariantesRel>)db.ExpedientesSumariantesRel;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesSumariantesRel
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesSumariantesRelView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesSumariantesRel
					select new ExpedientesSumariantesRelView
					{
						 Expediente = c.Expediente,
						 Usuario = c.Usuario,
					};
			return (DbQuery<ExpedientesSumariantesRelView>)x;
		}

		public void Guardar(ExpedientesSumariantesRel Objeto)
		{
			try
			{
				db.ExpedientesSumariantesRel.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesSumariantesRel Objeto)
		{
			try
			{
				db.ExpedientesSumariantesRel.Attach(Objeto);
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
				ExpedientesSumariantesRel Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesSumariantesRel.Remove(Objeto);
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

		public DbQuery<ExpedientesSumariantesRelViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesSumariantesRel
					select new ExpedientesSumariantesRelViewT
					{
						 Expediente = c.Expediente,
						 Usuario = c.Usuario,
					};
			return (DbQuery<ExpedientesSumariantesRelViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
