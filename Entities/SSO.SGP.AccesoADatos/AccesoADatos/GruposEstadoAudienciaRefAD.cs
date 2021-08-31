
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
	public partial class GruposEstadoAudienciaRefAD
	{
		private BDEntities db = new BDEntities();

		public GruposEstadoAudienciaRef ObtenerPorId(int Id)
		{
			return db.GruposEstadoAudienciaRef.Single(c => c.Id == Id);
		}

		public DbQuery<GruposEstadoAudienciaRef> ObtenerTodo()
		{
			return (DbQuery<GruposEstadoAudienciaRef>)db.GruposEstadoAudienciaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.GruposEstadoAudienciaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<GruposEstadoAudienciaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.GruposEstadoAudienciaRef
					select new GruposEstadoAudienciaRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<GruposEstadoAudienciaRefView>)x;
		}

		public void Guardar(GruposEstadoAudienciaRef Objeto)
		{
			try
			{
				db.GruposEstadoAudienciaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposEstadoAudienciaRef Objeto)
		{
			try
			{
				db.GruposEstadoAudienciaRef.Attach(Objeto);
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
				GruposEstadoAudienciaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.GruposEstadoAudienciaRef.Remove(Objeto);
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

		public DbQuery<GruposEstadoAudienciaRefViewT> JsonT(string term)
		{
			var x = from c in db.GruposEstadoAudienciaRef
					select new GruposEstadoAudienciaRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<GruposEstadoAudienciaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
