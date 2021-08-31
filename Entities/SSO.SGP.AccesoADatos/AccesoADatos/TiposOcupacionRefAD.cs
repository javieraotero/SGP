
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
	public partial class TiposOcupacionRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposOcupacionRef ObtenerPorId(int Id)
		{
			return db.TiposOcupacionRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposOcupacionRef> ObtenerTodo()
		{
			return (DbQuery<TiposOcupacionRef>)db.TiposOcupacionRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposOcupacionRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposOcupacionRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposOcupacionRef
					select new TiposOcupacionRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposOcupacionRefView>)x;
		}

		public void Guardar(TiposOcupacionRef Objeto)
		{
			try
			{
				db.TiposOcupacionRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposOcupacionRef Objeto)
		{
			try
			{
				db.TiposOcupacionRef.Attach(Objeto);
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
				TiposOcupacionRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposOcupacionRef.Remove(Objeto);
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

		public DbQuery<TiposOcupacionRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposOcupacionRef
					select new TiposOcupacionRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposOcupacionRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
