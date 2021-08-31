
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
	public partial class RolesElementoRefAD
	{
		private BDEntities db = new BDEntities();

		public RolesElementoRef ObtenerPorId(int Id)
		{
			return db.RolesElementoRef.Single(c => c.Id == Id);
		}

		public DbQuery<RolesElementoRef> ObtenerTodo()
		{
			return (DbQuery<RolesElementoRef>)db.RolesElementoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.RolesElementoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<RolesElementoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.RolesElementoRef
					select new RolesElementoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<RolesElementoRefView>)x;
		}

		public void Guardar(RolesElementoRef Objeto)
		{
			try
			{
				db.RolesElementoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(RolesElementoRef Objeto)
		{
			try
			{
				db.RolesElementoRef.Attach(Objeto);
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
				RolesElementoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.RolesElementoRef.Remove(Objeto);
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

		public DbQuery<RolesElementoRefViewT> JsonT(string term)
		{
			var x = from c in db.RolesElementoRef
					select new RolesElementoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<RolesElementoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
