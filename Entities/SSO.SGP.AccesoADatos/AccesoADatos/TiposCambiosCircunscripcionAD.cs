
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
	public partial class TiposCambiosCircunscripcionAD
	{
		private BDEntities db = new BDEntities();

		public TiposCambiosCircunscripcion ObtenerPorId(int Id)
		{
			return db.TiposCambiosCircunscripcion.Single(c => c.Id == Id);
		}

		public DbQuery<TiposCambiosCircunscripcion> ObtenerTodo()
		{
			return (DbQuery<TiposCambiosCircunscripcion>)db.TiposCambiosCircunscripcion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposCambiosCircunscripcion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposCambiosCircunscripcionView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposCambiosCircunscripcion
					select new TiposCambiosCircunscripcionView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposCambiosCircunscripcionView>)x;
		}

		public void Guardar(TiposCambiosCircunscripcion Objeto)
		{
			try
			{
				db.TiposCambiosCircunscripcion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposCambiosCircunscripcion Objeto)
		{
			try
			{
				db.TiposCambiosCircunscripcion.Attach(Objeto);
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
				TiposCambiosCircunscripcion Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposCambiosCircunscripcion.Remove(Objeto);
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

		public DbQuery<TiposCambiosCircunscripcionViewT> JsonT(string term)
		{
			var x = from c in db.TiposCambiosCircunscripcion
					select new TiposCambiosCircunscripcionViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposCambiosCircunscripcionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
