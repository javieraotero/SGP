
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
	public partial class MediadoresPeriodosTipoAD
	{
		private BDEntities db = new BDEntities();

		public MediadoresPeriodosTipo ObtenerPorId(int Id)
		{
			return db.MediadoresPeriodosTipo.Single(c => c.Id == Id);
		}

		public DbQuery<MediadoresPeriodosTipo> ObtenerTodo()
		{
			return (DbQuery<MediadoresPeriodosTipo>)db.MediadoresPeriodosTipo;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MediadoresPeriodosTipo
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MediadoresPeriodosTipoView> ObtenerParaGrilla()
		{
			var x = from c in db.MediadoresPeriodosTipo
					select new MediadoresPeriodosTipoView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MediadoresPeriodosTipoView>)x;
		}

		public void Guardar(MediadoresPeriodosTipo Objeto)
		{
			try
			{
				db.MediadoresPeriodosTipo.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresPeriodosTipo Objeto)
		{
			try
			{
				db.MediadoresPeriodosTipo.Attach(Objeto);
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
				MediadoresPeriodosTipo Objeto = this.ObtenerPorId(IdObjeto);
				db.MediadoresPeriodosTipo.Remove(Objeto);
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

		public DbQuery<MediadoresPeriodosTipoViewT> JsonT(string term)
		{
			var x = from c in db.MediadoresPeriodosTipo
					select new MediadoresPeriodosTipoViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MediadoresPeriodosTipoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
