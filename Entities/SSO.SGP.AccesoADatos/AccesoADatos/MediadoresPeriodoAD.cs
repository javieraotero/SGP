
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
	public partial class MediadoresPeriodoAD
	{
		private BDEntities db = new BDEntities();

		public MediadoresPeriodo ObtenerPorId(int Id)
		{
			return db.MediadoresPeriodo.Single(c => c.Id == Id);
		}

		public DbQuery<MediadoresPeriodo> ObtenerTodo()
		{
			return (DbQuery<MediadoresPeriodo>)db.MediadoresPeriodo.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MediadoresPeriodo
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MediadoresPeriodoView> ObtenerParaGrilla()
		{
			var x = from c in db.MediadoresPeriodo
					where c.Activo == true
					select new MediadoresPeriodoView
					{
						 Id = c.Id,
						 TipoPeriodo = c.TipoPeriodo,
						 FecIniInscripcion = c.FecIniInscripcion,
						 FecFinInscripcion = c.FecFinInscripcion,
						 FecIniPeriodo = c.FecIniPeriodo,
						 FecFinPeriodo = c.FecFinPeriodo,
						 Activo = c.Activo,
					};
			return (DbQuery<MediadoresPeriodoView>)x;
		}

		public void Guardar(MediadoresPeriodo Objeto)
		{
			try
			{
				db.MediadoresPeriodo.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresPeriodo Objeto)
		{
			try
			{
				db.MediadoresPeriodo.Attach(Objeto);
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
				MediadoresPeriodo Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<MediadoresPeriodoViewT> JsonT(string term)
		{
			var x = from c in db.MediadoresPeriodo
					where c.Activo == true
					select new MediadoresPeriodoViewT
					{
						 Id = c.Id,
						 TipoPeriodo = c.TipoPeriodo,
						 FecIniInscripcion = c.FecIniInscripcion,
						 FecFinInscripcion = c.FecFinInscripcion,
						 FecIniPeriodo = c.FecIniPeriodo,
						 FecFinPeriodo = c.FecFinPeriodo,
						 Activo = c.Activo,
					};
			return (DbQuery<MediadoresPeriodoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
