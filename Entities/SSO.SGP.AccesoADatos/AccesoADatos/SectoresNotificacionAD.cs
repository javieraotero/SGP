
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
	public partial class SectoresNotificacionAD
	{
		private BDEntities db = new BDEntities();

		public SectoresNotificacion ObtenerPorId(int Id)
		{
			return db.SectoresNotificacion.Single(c => c.Id == Id);
		}

		public DbQuery<SectoresNotificacion> ObtenerTodo()
		{
			return (DbQuery<SectoresNotificacion>)db.SectoresNotificacion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SectoresNotificacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SectoresNotificacionView> ObtenerParaGrilla()
		{
			var x = from c in db.SectoresNotificacion
					select new SectoresNotificacionView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<SectoresNotificacionView>)x;
		}

		public void Guardar(SectoresNotificacion Objeto)
		{
			try
			{
				db.SectoresNotificacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SectoresNotificacion Objeto)
		{
			try
			{
				db.SectoresNotificacion.Attach(Objeto);
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
				SectoresNotificacion Objeto = this.ObtenerPorId(IdObjeto);
				db.SectoresNotificacion.Remove(Objeto);
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

		public DbQuery<SectoresNotificacionViewT> JsonT(string term)
		{
			var x = from c in db.SectoresNotificacion
					select new SectoresNotificacionViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<SectoresNotificacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
