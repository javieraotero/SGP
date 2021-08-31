
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
	public partial class MediadoresInscripcionAD
	{
		private BDEntities db = new BDEntities();

		public MediadoresInscripcion ObtenerPorId(int Id)
		{
			return db.MediadoresInscripcion.Single(c => c.Id == Id);
		}

		public DbQuery<MediadoresInscripcion> ObtenerTodo()
		{
			return (DbQuery<MediadoresInscripcion>)db.MediadoresInscripcion.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MediadoresInscripcion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MediadoresInscripcionView> ObtenerParaGrilla()
		{
			var x = from c in db.MediadoresInscripcion
					where c.Activo == true
					select new MediadoresInscripcionView
					{
						 Id = c.Id,
						 Circunscripcion1 = c.Circunscripcion1,
						 Circunscripcion2 = c.Circunscripcion2,
						 Circunscripcion3 = c.Circunscripcion3,
						 Circunscripcion4 = c.Circunscripcion4,
						 FechaInscripcion = c.FechaInscripcion,
						 UsuarioCarga = c.UsuarioCarga,
						 Periodo = c.Periodo,
						 Mediador = c.Mediador,
						 Estado = c.Estado,
						 Activo = c.Activo,
					};
			return (DbQuery<MediadoresInscripcionView>)x;
		}

		public void Guardar(MediadoresInscripcion Objeto)
		{
			try
			{
				db.MediadoresInscripcion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresInscripcion Objeto)
		{
			try
			{
				db.MediadoresInscripcion.Attach(Objeto);
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
				MediadoresInscripcion Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<MediadoresInscripcionViewT> JsonT(string term)
		{
			var x = from c in db.MediadoresInscripcion
					where c.Activo == true
					select new MediadoresInscripcionViewT
					{
						 Id = c.Id,
						 Circunscripcion1 = c.Circunscripcion1,
						 Circunscripcion2 = c.Circunscripcion2,
						 Circunscripcion3 = c.Circunscripcion3,
						 Circunscripcion4 = c.Circunscripcion4,
						 FechaInscripcion = c.FechaInscripcion,
						 UsuarioCarga = c.UsuarioCarga,
						 Periodo = c.Periodo,
						 Mediador = c.Mediador,
						 Estado = c.Estado,
						 Activo = c.Activo,
					};
			return (DbQuery<MediadoresInscripcionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
