
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
	public partial class TiposModelosEscritoadmRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposModelosEscritoadmRef ObtenerPorId(int Id)
		{
			return db.TiposModelosEscritoadmRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposModelosEscritoadmRef> ObtenerTodo()
		{
			return (DbQuery<TiposModelosEscritoadmRef>)db.TiposModelosEscritoadmRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposModelosEscritoadmRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposModelosEscritoadmRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposModelosEscritoadmRef
					select new TiposModelosEscritoadmRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TipoPadre = c.TipoPadre,
					};
			return (DbQuery<TiposModelosEscritoadmRefView>)x;
		}

		public void Guardar(TiposModelosEscritoadmRef Objeto)
		{
			try
			{
				db.TiposModelosEscritoadmRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposModelosEscritoadmRef Objeto)
		{
			try
			{
				db.TiposModelosEscritoadmRef.Attach(Objeto);
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
				TiposModelosEscritoadmRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposModelosEscritoadmRef.Remove(Objeto);
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

		public DbQuery<TiposModelosEscritoadmRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposModelosEscritoadmRef
					select new TiposModelosEscritoadmRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TipoPadre = c.TipoPadre,
					};
			return (DbQuery<TiposModelosEscritoadmRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
