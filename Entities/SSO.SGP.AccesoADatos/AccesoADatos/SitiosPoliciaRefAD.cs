
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
	public partial class SitiosPoliciaRefAD
	{
		private BDEntities db = new BDEntities();

		public SitiosPoliciaRef ObtenerPorId(int Id)
		{
			return db.SitiosPoliciaRef.Single(c => c.Id == Id);
		}

		public DbQuery<SitiosPoliciaRef> ObtenerTodo()
		{
			return (DbQuery<SitiosPoliciaRef>)db.SitiosPoliciaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SitiosPoliciaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SitiosPoliciaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.SitiosPoliciaRef
					select new SitiosPoliciaRefView
					{
						 Id = c.Id,
						 IdSitio = c.IdSitio,
						 Sitio = c.Sitio,
					};
			return (DbQuery<SitiosPoliciaRefView>)x;
		}

		public void Guardar(SitiosPoliciaRef Objeto)
		{
			try
			{
				db.SitiosPoliciaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SitiosPoliciaRef Objeto)
		{
			try
			{
				db.SitiosPoliciaRef.Attach(Objeto);
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
				SitiosPoliciaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.SitiosPoliciaRef.Remove(Objeto);
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

		public DbQuery<SitiosPoliciaRefViewT> JsonT(string term)
		{
			var x = from c in db.SitiosPoliciaRef
					select new SitiosPoliciaRefViewT
					{
						 Id = c.Id,
						 IdSitio = c.IdSitio,
						 Sitio = c.Sitio,
					};
			return (DbQuery<SitiosPoliciaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
