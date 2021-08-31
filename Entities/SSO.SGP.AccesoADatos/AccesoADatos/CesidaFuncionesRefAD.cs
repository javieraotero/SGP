
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
	public partial class CesidaFuncionesRefAD
	{
		private BDEntities db = new BDEntities();

		public CesidaFuncionesRef ObtenerPorId(int Id)
		{
			return db.CesidaFuncionesRef.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaFuncionesRef> ObtenerTodo()
		{
			return (DbQuery<CesidaFuncionesRef>)db.CesidaFuncionesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaFuncionesRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaFuncionesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaFuncionesRef
					select new CesidaFuncionesRefView
					{
						 Id = c.Id,
						 NroConvenio = c.NroConvenio,
						 NroFuncion = c.NroFuncion,
						 Funcion = c.Funcion,
					};
			return (DbQuery<CesidaFuncionesRefView>)x;
		}

		public void Guardar(CesidaFuncionesRef Objeto)
		{
			try
			{
				db.CesidaFuncionesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaFuncionesRef Objeto)
		{
			try
			{
				db.CesidaFuncionesRef.Attach(Objeto);
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
				CesidaFuncionesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaFuncionesRef.Remove(Objeto);
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

		public DbQuery<CesidaFuncionesRefViewT> JsonT(string term)
		{
			var x = from c in db.CesidaFuncionesRef
					select new CesidaFuncionesRefViewT
					{
						 Id = c.Id,
						 NroConvenio = c.NroConvenio,
						 NroFuncion = c.NroFuncion,
						 Funcion = c.Funcion,
					};
			return (DbQuery<CesidaFuncionesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
