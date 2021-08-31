
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
	public partial class CesidaCargosRefAD
	{
		private BDEntities db = new BDEntities();

		public CesidaCargosRef ObtenerPorId(int Id)
		{
			return db.CesidaCargosRef.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaCargosRef> ObtenerTodo()
		{
			return (DbQuery<CesidaCargosRef>)db.CesidaCargosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaCargosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}


		public DbQuery<CesidaCargosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaCargosRef
					select new CesidaCargosRefView
					{
						 Id = c.Id,
						 NroConvenio = c.NroConvenio,
						 Convenio = c.Convenio,
						 NroRama = c.NroRama,
						 Rama = c.Rama,
						 NroCategoria = c.NroCategoria,
						 Categoria = c.Categoria,
					};
			return (DbQuery<CesidaCargosRefView>)x;
		}

		public void Guardar(CesidaCargosRef Objeto)
		{
			try
			{
				db.CesidaCargosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaCargosRef Objeto)
		{
			try
			{
				db.CesidaCargosRef.Attach(Objeto);
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
				CesidaCargosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaCargosRef.Remove(Objeto);
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

		public DbQuery<CesidaCargosRefViewT> JsonT(string term)
		{
			var x = from c in db.CesidaCargosRef
					select new CesidaCargosRefViewT
					{
						 Id = c.Id,
						 NroConvenio = c.NroConvenio,
						 Convenio = c.Convenio,
						 NroRama = c.NroRama,
						 Rama = c.Rama,
						 NroCategoria = c.NroCategoria,
						 Categoria = c.Categoria,
					};
			return (DbQuery<CesidaCargosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
