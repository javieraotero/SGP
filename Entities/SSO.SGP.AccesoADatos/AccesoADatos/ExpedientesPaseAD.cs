
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
	public partial class ExpedientesPaseAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesPase ObtenerPorId(int Id)
		{
			return db.ExpedientesPase.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesPase> ObtenerTodo()
		{
			return (DbQuery<ExpedientesPase>)db.ExpedientesPase;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesPase
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesPaseView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesPase
					select new ExpedientesPaseView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 OrganismoEnvio = c.OrganismoEnvio,
						 UsuarioEnvio = c.UsuarioEnvio,
						 FechaEnvio = c.FechaEnvio,
						 OrganismoRecepcion = c.OrganismoRecepcion,
						 UsuarioRecepcion = c.UsuarioRecepcion,
						 FechaRecepcion = c.FechaRecepcion,
						 Recibido = c.Recibido,
						 PaseAnterior = c.PaseAnterior,
						 PaseSiguiente = c.PaseSiguiente,
						 Observaciones = c.Observaciones,
					};
			return (DbQuery<ExpedientesPaseView>)x;
		}

		public void Guardar(ExpedientesPase Objeto)
		{
			try
			{
				db.ExpedientesPase.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPase Objeto)
		{
			try
			{
				db.ExpedientesPase.Attach(Objeto);
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
				ExpedientesPase Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesPase.Remove(Objeto);
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

		public DbQuery<ExpedientesPaseViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesPase
					select new ExpedientesPaseViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 OrganismoEnvio = c.OrganismoEnvio,
						 UsuarioEnvio = c.UsuarioEnvio,
						 FechaEnvio = c.FechaEnvio,
						 OrganismoRecepcion = c.OrganismoRecepcion,
						 UsuarioRecepcion = c.UsuarioRecepcion,
						 FechaRecepcion = c.FechaRecepcion,
						 Recibido = c.Recibido,
						 PaseAnterior = c.PaseAnterior,
						 PaseSiguiente = c.PaseSiguiente,
						 Observaciones = c.Observaciones,
					};
			return (DbQuery<ExpedientesPaseViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
