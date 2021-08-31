
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
	public partial class TiposSucesosAD
	{
		private BDEntities db = new BDEntities();

		public TiposSucesos ObtenerPorId(int Id)
		{
			return db.TiposSucesos.Single(c => c.Id == Id);
		}

		public DbQuery<TiposSucesos> ObtenerTodo()
		{
			return (DbQuery<TiposSucesos>)db.TiposSucesos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposSucesos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposSucesosView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposSucesos
					select new TiposSucesosView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TareaManual = c.TareaManual,
					};
			return (DbQuery<TiposSucesosView>)x;
		}

		public void Guardar(TiposSucesos Objeto)
		{
			try
			{
				db.TiposSucesos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposSucesos Objeto)
		{
			try
			{
				db.TiposSucesos.Attach(Objeto);
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
				TiposSucesos Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposSucesos.Remove(Objeto);
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

		public DbQuery<TiposSucesosViewT> JsonT(string term)
		{
			var x = from c in db.TiposSucesos
					select new TiposSucesosViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TareaManual = c.TareaManual,
					};
			return (DbQuery<TiposSucesosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
