
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
	public partial class GruposEstadoExpedienteRefAD
	{
		private BDEntities db = new BDEntities();

		public GruposEstadoExpedienteRef ObtenerPorId(int Id)
		{
			return db.GruposEstadoExpedienteRef.Single(c => c.Id == Id);
		}

		public DbQuery<GruposEstadoExpedienteRef> ObtenerTodo()
		{
			return (DbQuery<GruposEstadoExpedienteRef>)db.GruposEstadoExpedienteRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.GruposEstadoExpedienteRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<GruposEstadoExpedienteRefView> ObtenerParaGrilla()
		{
			var x = from c in db.GruposEstadoExpedienteRef
					select new GruposEstadoExpedienteRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<GruposEstadoExpedienteRefView>)x;
		}

		public void Guardar(GruposEstadoExpedienteRef Objeto)
		{
			try
			{
				db.GruposEstadoExpedienteRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposEstadoExpedienteRef Objeto)
		{
			try
			{
				db.GruposEstadoExpedienteRef.Attach(Objeto);
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
				GruposEstadoExpedienteRef Objeto = this.ObtenerPorId(IdObjeto);
				db.GruposEstadoExpedienteRef.Remove(Objeto);
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

		public DbQuery<GruposEstadoExpedienteRefViewT> JsonT(string term)
		{
			var x = from c in db.GruposEstadoExpedienteRef
					select new GruposEstadoExpedienteRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<GruposEstadoExpedienteRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
