
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
	public partial class TiposParentescosRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposParentescosRef ObtenerPorId(int Id)
		{
			return db.TiposParentescosRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposParentescosRef> ObtenerTodo()
		{
			return (DbQuery<TiposParentescosRef>)db.TiposParentescosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposParentescosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposParentescosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposParentescosRef
					select new TiposParentescosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposParentescosRefView>)x;
		}

		public void Guardar(TiposParentescosRef Objeto)
		{
			try
			{
				db.TiposParentescosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposParentescosRef Objeto)
		{
			try
			{
				db.TiposParentescosRef.Attach(Objeto);
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
				TiposParentescosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposParentescosRef.Remove(Objeto);
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

		public DbQuery<TiposParentescosRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposParentescosRef
					select new TiposParentescosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposParentescosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
