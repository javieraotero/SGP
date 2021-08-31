
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
	public partial class CesidaRevistasRefAD
	{
		private BDEntities db = new BDEntities();

		public CesidaRevistasRef ObtenerPorId(int Id)
		{
			return db.CesidaRevistasRef.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaRevistasRef> ObtenerTodo()
		{
			return (DbQuery<CesidaRevistasRef>)db.CesidaRevistasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaRevistasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaRevistasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaRevistasRef
					select new CesidaRevistasRefView
					{
						 Id = c.Id,
						 Codigo = c.Codigo,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CesidaRevistasRefView>)x;
		}

		public void Guardar(CesidaRevistasRef Objeto)
		{
			try
			{
				db.CesidaRevistasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaRevistasRef Objeto)
		{
			try
			{
				db.CesidaRevistasRef.Attach(Objeto);
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
				CesidaRevistasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaRevistasRef.Remove(Objeto);
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

		public DbQuery<CesidaRevistasRefViewT> JsonT(string term)
		{
			var x = from c in db.CesidaRevistasRef
					select new CesidaRevistasRefViewT
					{
						 Id = c.Id,
						 Codigo = c.Codigo,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CesidaRevistasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
