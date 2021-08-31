
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
	public partial class AudienciasDemorasAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasDemoras ObtenerPorId(int Id)
		{
			return db.AudienciasDemoras.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasDemoras> ObtenerTodo()
		{
			return (DbQuery<AudienciasDemoras>)db.AudienciasDemoras;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasDemoras
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasDemorasView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasDemoras
					select new AudienciasDemorasView
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 MotivoDemora = c.MotivoDemora,
						 Observacion = c.Observacion,
					};
			return (DbQuery<AudienciasDemorasView>)x;
		}

		public void Guardar(AudienciasDemoras Objeto)
		{
			try
			{
				db.AudienciasDemoras.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasDemoras Objeto)
		{
			try
			{
				db.AudienciasDemoras.Attach(Objeto);
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
				AudienciasDemoras Objeto = this.ObtenerPorId(IdObjeto);
				db.AudienciasDemoras.Remove(Objeto);
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

		public DbQuery<AudienciasDemorasViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasDemoras
					select new AudienciasDemorasViewT
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 MotivoDemora = c.MotivoDemora,
						 Observacion = c.Observacion,
					};
			return (DbQuery<AudienciasDemorasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
