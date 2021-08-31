
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
	public partial class CesidaEmpresasRefAD
	{
		private BDEntities db = new BDEntities();

		public CesidaEmpresasRef ObtenerPorId(int Id)
		{
			return db.CesidaEmpresasRef.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaEmpresasRef> ObtenerTodo()
		{
			return (DbQuery<CesidaEmpresasRef>)db.CesidaEmpresasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaEmpresasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaEmpresasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaEmpresasRef
					select new CesidaEmpresasRefView
					{
						 Id = c.Id,
						 Codigo = c.Codigo,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CesidaEmpresasRefView>)x;
		}

		public void Guardar(CesidaEmpresasRef Objeto)
		{
			try
			{
				db.CesidaEmpresasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaEmpresasRef Objeto)
		{
			try
			{
				db.CesidaEmpresasRef.Attach(Objeto);
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
				CesidaEmpresasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaEmpresasRef.Remove(Objeto);
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

		public DbQuery<CesidaEmpresasRefViewT> JsonT(string term)
		{
			var x = from c in db.CesidaEmpresasRef
					select new CesidaEmpresasRefViewT
					{
						 Id = c.Id,
						 Codigo = c.Codigo,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CesidaEmpresasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
