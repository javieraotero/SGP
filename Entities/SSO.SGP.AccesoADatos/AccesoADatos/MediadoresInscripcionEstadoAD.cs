
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
	public partial class MediadoresInscripcionEstadoAD
	{
		private BDEntities db = new BDEntities();

		public MediadoresInscripcionEstado ObtenerPorId(int Id)
		{
			return db.MediadoresInscripcionEstado.Single(c => c.Id == Id);
		}

		public DbQuery<MediadoresInscripcionEstado> ObtenerTodo()
		{
			return (DbQuery<MediadoresInscripcionEstado>)db.MediadoresInscripcionEstado;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MediadoresInscripcionEstado
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MediadoresInscripcionEstadoView> ObtenerParaGrilla()
		{
			var x = from c in db.MediadoresInscripcionEstado
					select new MediadoresInscripcionEstadoView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MediadoresInscripcionEstadoView>)x;
		}

		public void Guardar(MediadoresInscripcionEstado Objeto)
		{
			try
			{
				db.MediadoresInscripcionEstado.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresInscripcionEstado Objeto)
		{
			try
			{
				db.MediadoresInscripcionEstado.Attach(Objeto);
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
				MediadoresInscripcionEstado Objeto = this.ObtenerPorId(IdObjeto);
				db.MediadoresInscripcionEstado.Remove(Objeto);
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

		public DbQuery<MediadoresInscripcionEstadoViewT> JsonT(string term)
		{
			var x = from c in db.MediadoresInscripcionEstado
					select new MediadoresInscripcionEstadoViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MediadoresInscripcionEstadoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
