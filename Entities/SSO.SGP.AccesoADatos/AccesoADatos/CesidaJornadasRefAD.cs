
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
	public partial class CesidaJornadasRefAD
	{
		private BDEntities db = new BDEntities();

		public CesidaJornadasRef ObtenerPorId(int Id)
		{
			return db.CesidaJornadasRef.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaJornadasRef> ObtenerTodo()
		{
			return (DbQuery<CesidaJornadasRef>)db.CesidaJornadasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaJornadasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaJornadasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaJornadasRef
					select new CesidaJornadasRefView
					{
						 Id = c.Id,
						 Codigo = c.Codigo,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CesidaJornadasRefView>)x;
		}

		public void Guardar(CesidaJornadasRef Objeto)
		{
			try
			{
				db.CesidaJornadasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaJornadasRef Objeto)
		{
			try
			{
				db.CesidaJornadasRef.Attach(Objeto);
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
				CesidaJornadasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaJornadasRef.Remove(Objeto);
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

		public DbQuery<CesidaJornadasRefViewT> JsonT(string term)
		{
			var x = from c in db.CesidaJornadasRef
					select new CesidaJornadasRefViewT
					{
						 Id = c.Id,
						 Codigo = c.Codigo,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CesidaJornadasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
