
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
	public partial class TiposRelevarControlAD
	{
		private BDEntities db = new BDEntities();

		public TiposRelevarControl ObtenerPorId(int Id)
		{
			return db.TiposRelevarControl.Single(c => c.Id == Id);
		}

		public DbQuery<TiposRelevarControl> ObtenerTodo()
		{
			return (DbQuery<TiposRelevarControl>)db.TiposRelevarControl;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposRelevarControl
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposRelevarControlView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposRelevarControl
					select new TiposRelevarControlView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposRelevarControlView>)x;
		}

		public void Guardar(TiposRelevarControl Objeto)
		{
			try
			{
				db.TiposRelevarControl.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposRelevarControl Objeto)
		{
			try
			{
				db.TiposRelevarControl.Attach(Objeto);
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
				TiposRelevarControl Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposRelevarControl.Remove(Objeto);
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

		public DbQuery<TiposRelevarControlViewT> JsonT(string term)
		{
			var x = from c in db.TiposRelevarControl
					select new TiposRelevarControlViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposRelevarControlViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
