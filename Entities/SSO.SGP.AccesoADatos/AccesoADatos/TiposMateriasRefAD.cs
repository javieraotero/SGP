
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
	public partial class TiposMateriasRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposMateriasRef ObtenerPorId(int Id)
		{
			return db.TiposMateriasRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposMateriasRef> ObtenerTodo()
		{
			return (DbQuery<TiposMateriasRef>)db.TiposMateriasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposMateriasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposMateriasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposMateriasRef
					select new TiposMateriasRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Mnemo = c.Mnemo,
					};
			return (DbQuery<TiposMateriasRefView>)x;
		}

		public void Guardar(TiposMateriasRef Objeto)
		{
			try
			{
				db.TiposMateriasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposMateriasRef Objeto)
		{
			try
			{
				db.TiposMateriasRef.Attach(Objeto);
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
				TiposMateriasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposMateriasRef.Remove(Objeto);
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

		public DbQuery<TiposMateriasRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposMateriasRef
					select new TiposMateriasRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Mnemo = c.Mnemo,
					};
			return (DbQuery<TiposMateriasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
