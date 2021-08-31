
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
	public partial class MediadoresTipoAD
	{
		private BDEntities db = new BDEntities();

		public MediadoresTipo ObtenerPorId(int Id)
		{
			return db.MediadoresTipo.Single(c => c.Id == Id);
		}

		public DbQuery<MediadoresTipo> ObtenerTodo()
		{
			return (DbQuery<MediadoresTipo>)db.MediadoresTipo;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MediadoresTipo
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MediadoresTipoView> ObtenerParaGrilla()
		{
			var x = from c in db.MediadoresTipo
					select new MediadoresTipoView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MediadoresTipoView>)x;
		}

		public void Guardar(MediadoresTipo Objeto)
		{
			try
			{
				db.MediadoresTipo.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresTipo Objeto)
		{
			try
			{
				db.MediadoresTipo.Attach(Objeto);
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
				MediadoresTipo Objeto = this.ObtenerPorId(IdObjeto);
				db.MediadoresTipo.Remove(Objeto);
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

		public DbQuery<MediadoresTipoViewT> JsonT(string term)
		{
			var x = from c in db.MediadoresTipo
					select new MediadoresTipoViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MediadoresTipoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
