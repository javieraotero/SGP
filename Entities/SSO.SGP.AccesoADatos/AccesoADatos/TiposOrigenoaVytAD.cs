
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
	public partial class TiposOrigenoaVytAD
	{
		private BDEntities db = new BDEntities();

		public TiposOrigenoaVyt ObtenerPorId(int Id)
		{
			return db.TiposOrigenoaVyt.Single(c => c.Id == Id);
		}

		public DbQuery<TiposOrigenoaVyt> ObtenerTodo()
		{
			return (DbQuery<TiposOrigenoaVyt>)db.TiposOrigenoaVyt;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposOrigenoaVyt
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposOrigenoaVytView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposOrigenoaVyt
					select new TiposOrigenoaVytView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposOrigenoaVytView>)x;
		}

		public void Guardar(TiposOrigenoaVyt Objeto)
		{
			try
			{
				db.TiposOrigenoaVyt.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposOrigenoaVyt Objeto)
		{
			try
			{
				db.TiposOrigenoaVyt.Attach(Objeto);
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
				TiposOrigenoaVyt Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposOrigenoaVyt.Remove(Objeto);
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

		public DbQuery<TiposOrigenoaVytViewT> JsonT(string term)
		{
			var x = from c in db.TiposOrigenoaVyt
					select new TiposOrigenoaVytViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposOrigenoaVytViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
