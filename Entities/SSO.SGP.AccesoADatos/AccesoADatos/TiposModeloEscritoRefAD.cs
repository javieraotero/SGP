
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
	public partial class TiposModeloEscritoRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposModeloEscritoRef ObtenerPorId(int Id)
		{
			return db.TiposModeloEscritoRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposModeloEscritoRef> ObtenerTodo()
		{
			return (DbQuery<TiposModeloEscritoRef>)db.TiposModeloEscritoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposModeloEscritoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposModeloEscritoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposModeloEscritoRef
					select new TiposModeloEscritoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TipoPadre = c.TipoPadre,
					};
			return (DbQuery<TiposModeloEscritoRefView>)x;
		}

		public void Guardar(TiposModeloEscritoRef Objeto)
		{
			try
			{
				db.TiposModeloEscritoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposModeloEscritoRef Objeto)
		{
			try
			{
				db.TiposModeloEscritoRef.Attach(Objeto);
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
				TiposModeloEscritoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposModeloEscritoRef.Remove(Objeto);
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

		public DbQuery<TiposModeloEscritoRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposModeloEscritoRef
					select new TiposModeloEscritoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TipoPadre = c.TipoPadre,
					};
			return (DbQuery<TiposModeloEscritoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
