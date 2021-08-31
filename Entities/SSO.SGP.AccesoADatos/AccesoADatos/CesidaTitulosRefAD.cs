
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
	public partial class CesidaTitulosRefAD
	{
		private BDEntities db = new BDEntities();

		public CesidaTitulosRef ObtenerPorId(int Id)
		{
			return db.CesidaTitulosRef.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaTitulosRef> ObtenerTodo()
		{
			return (DbQuery<CesidaTitulosRef>)db.CesidaTitulosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaTitulosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaTitulosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaTitulosRef
					select new CesidaTitulosRefView
					{
						 Id = c.Id,
						 Codigo = c.Codigo,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CesidaTitulosRefView>)x;
		}

		public void Guardar(CesidaTitulosRef Objeto)
		{
			try
			{
				db.CesidaTitulosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaTitulosRef Objeto)
		{
			try
			{
				db.CesidaTitulosRef.Attach(Objeto);
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
				CesidaTitulosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaTitulosRef.Remove(Objeto);
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

		public DbQuery<CesidaTitulosRefViewT> JsonT(string term)
		{
			var x = from c in db.CesidaTitulosRef
					select new CesidaTitulosRefViewT
					{
						 Id = c.Id,
						 Codigo = c.Codigo,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CesidaTitulosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
