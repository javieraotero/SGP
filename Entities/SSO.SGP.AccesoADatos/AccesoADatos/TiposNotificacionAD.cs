
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
	public partial class TiposNotificacionAD
	{
		private BDEntities db = new BDEntities();

		public TiposNotificacion ObtenerPorId(int Id)
		{
			return db.TiposNotificacion.Single(c => c.Id == Id);
		}

		public DbQuery<TiposNotificacion> ObtenerTodo()
		{
			return (DbQuery<TiposNotificacion>)db.TiposNotificacion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposNotificacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposNotificacionView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposNotificacion
					select new TiposNotificacionView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposNotificacionView>)x;
		}

		public void Guardar(TiposNotificacion Objeto)
		{
			try
			{
				db.TiposNotificacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposNotificacion Objeto)
		{
			try
			{
				db.TiposNotificacion.Attach(Objeto);
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
				TiposNotificacion Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposNotificacion.Remove(Objeto);
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

		public DbQuery<TiposNotificacionViewT> JsonT(string term)
		{
			var x = from c in db.TiposNotificacion
					select new TiposNotificacionViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposNotificacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
