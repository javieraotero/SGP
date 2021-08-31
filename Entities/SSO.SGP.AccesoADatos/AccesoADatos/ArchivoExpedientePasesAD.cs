
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
	public partial class ArchivoExpedientePasesAD
	{
		private BDEntities db = new BDEntities();

		public ArchivoExpedientePases ObtenerPorId(int Id)
		{
			return db.ArchivoExpedientePases.Single(c => c.Id == Id);
		}

		public DbQuery<ArchivoExpedientePases> ObtenerTodo()
		{
			return (DbQuery<ArchivoExpedientePases>)db.ArchivoExpedientePases;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ArchivoExpedientePases
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ArchivoExpedientePasesView> ObtenerParaGrilla()
		{
			var x = from c in db.ArchivoExpedientePases
					select new ArchivoExpedientePasesView
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
						 ArchivoExpediente = c.ArchivoExpediente,
					};
			return (DbQuery<ArchivoExpedientePasesView>)x;
		}

		public void Guardar(ArchivoExpedientePases Objeto)
		{
			try
			{
				db.ArchivoExpedientePases.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArchivoExpedientePases Objeto)
		{
			try
			{
				db.ArchivoExpedientePases.Attach(Objeto);
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
				ArchivoExpedientePases Objeto = this.ObtenerPorId(IdObjeto);
				db.ArchivoExpedientePases.Remove(Objeto);
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

		public DbQuery<ArchivoExpedientePasesViewT> JsonT(string term)
		{
			var x = from c in db.ArchivoExpedientePases
					select new ArchivoExpedientePasesViewT
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
						 ArchivoExpediente = c.ArchivoExpediente,
					};
			return (DbQuery<ArchivoExpedientePasesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
