
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
	public partial class MediadoresAD
	{
		private BDEntities db = new BDEntities();

		public Mediadores ObtenerPorId(int Id)
		{
			return db.Mediadores.Single(c => c.Id == Id);
		}

		public DbQuery<Mediadores> ObtenerTodo()
		{
			return (DbQuery<Mediadores>)db.Mediadores.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Mediadores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MediadoresView> ObtenerParaGrilla()
		{
			var x = from c in db.Mediadores
					where c.Activo == true
					select new MediadoresView
					{
						 Id = c.Id,
						 UsuarioCarga = c.UsuarioCarga,
						 UsuarioMediador = c.UsuarioMediador,
						 EspecialidadEnFamilia = c.EspecialidadEnFamilia,
						 Activo = c.Activo,
						 Tipo = c.Tipo,
						 FechaCarga = c.FechaCarga,
					};
			return (DbQuery<MediadoresView>)x;
		}

		public void Guardar(Mediadores Objeto)
		{
			try
			{
				db.Mediadores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Mediadores Objeto)
		{
			try
			{
				db.Mediadores.Attach(Objeto);
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
				Mediadores Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<MediadoresViewT> JsonT(string term)
		{
			var x = from c in db.Mediadores
					where c.Activo == true
					select new MediadoresViewT
					{
						 Id = c.Id,
						 UsuarioCarga = c.UsuarioCarga,
						 UsuarioMediador = c.UsuarioMediador,
						 EspecialidadEnFamilia = c.EspecialidadEnFamilia,
						 Activo = c.Activo,
						 Tipo = c.Tipo,
						 FechaCarga = c.FechaCarga,
					};
			return (DbQuery<MediadoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
