
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
	public partial class UnidadesDeOrganizacionRefAD
	{
		private BDEntities db = new BDEntities();

		public UnidadesDeOrganizacionRef ObtenerPorId(int Id)
		{
			return db.UnidadesDeOrganizacionRef.Single(c => c.Id == Id);
		}

		public DbQuery<UnidadesDeOrganizacionRef> ObtenerTodo()
		{
			return (DbQuery<UnidadesDeOrganizacionRef>)db.UnidadesDeOrganizacionRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.UnidadesDeOrganizacionRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<UnidadesDeOrganizacionRefView> ObtenerParaGrilla()
		{
			var x = from c in db.UnidadesDeOrganizacionRef
					select new UnidadesDeOrganizacionRefView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
					};
			return (DbQuery<UnidadesDeOrganizacionRefView>)x;
		}

		public void Guardar(UnidadesDeOrganizacionRef Objeto)
		{
			try
			{
				db.UnidadesDeOrganizacionRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UnidadesDeOrganizacionRef Objeto)
		{
			try
			{
				db.UnidadesDeOrganizacionRef.Attach(Objeto);
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
				UnidadesDeOrganizacionRef Objeto = this.ObtenerPorId(IdObjeto);
				db.UnidadesDeOrganizacionRef.Remove(Objeto);
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

		public DbQuery<UnidadesDeOrganizacionRefViewT> JsonT(string term)
		{
			var x = from c in db.UnidadesDeOrganizacionRef
					select new UnidadesDeOrganizacionRefViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
					};
			return (DbQuery<UnidadesDeOrganizacionRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
