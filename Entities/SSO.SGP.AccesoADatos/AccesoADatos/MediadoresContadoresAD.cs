
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
	public partial class MediadoresContadoresAD
	{
		private BDEntities db = new BDEntities();

		public MediadoresContadores ObtenerPorId(int Id)
		{
			return db.MediadoresContadores.Single(c => c.Id == Id);
		}

		public DbQuery<MediadoresContadores> ObtenerTodo()
		{
			return (DbQuery<MediadoresContadores>)db.MediadoresContadores.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MediadoresContadores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MediadoresContadoresView> ObtenerParaGrilla()
		{
			var x = from c in db.MediadoresContadores
					where c.Activo == true
					select new MediadoresContadoresView
					{
						 Id = c.Id,
						 Inscripcion = c.Inscripcion,
						 Contador = c.Contador,
						 Circunscripcion = c.Circunscripcion,
						 Categoria = c.Categoria,
						 Activo = c.Activo,
					};
			return (DbQuery<MediadoresContadoresView>)x;
		}

		public void Guardar(MediadoresContadores Objeto)
		{
			try
			{
				db.MediadoresContadores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresContadores Objeto)
		{
			try
			{
				db.MediadoresContadores.Attach(Objeto);
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
				MediadoresContadores Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<MediadoresContadoresViewT> JsonT(string term)
		{
			var x = from c in db.MediadoresContadores
					where c.Activo == true
					select new MediadoresContadoresViewT
					{
						 Id = c.Id,
						 Inscripcion = c.Inscripcion,
						 Contador = c.Contador,
						 Circunscripcion = c.Circunscripcion,
						 Categoria = c.Categoria,
						 Activo = c.Activo,
					};
			return (DbQuery<MediadoresContadoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
