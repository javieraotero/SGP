
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
	public partial class RolesPersonaCivilRefAD
	{
		private BDEntities db = new BDEntities();

		public RolesPersonaCivilRef ObtenerPorId(int Id)
		{
			return db.RolesPersonaCivilRef.Single(c => c.Id == Id);
		}

		public DbQuery<RolesPersonaCivilRef> ObtenerTodo()
		{
			return (DbQuery<RolesPersonaCivilRef>)db.RolesPersonaCivilRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.RolesPersonaCivilRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<RolesPersonaCivilRefView> ObtenerParaGrilla()
		{
			var x = from c in db.RolesPersonaCivilRef
					select new RolesPersonaCivilRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Tipo = c.Tipo,
						 NotificaAutoAudiencia = c.NotificaAutoAudiencia,
					};
			return (DbQuery<RolesPersonaCivilRefView>)x;
		}

		public void Guardar(RolesPersonaCivilRef Objeto)
		{
			try
			{
				db.RolesPersonaCivilRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(RolesPersonaCivilRef Objeto)
		{
			try
			{
				db.RolesPersonaCivilRef.Attach(Objeto);
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
				RolesPersonaCivilRef Objeto = this.ObtenerPorId(IdObjeto);
				db.RolesPersonaCivilRef.Remove(Objeto);
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

		public DbQuery<RolesPersonaCivilRefViewT> JsonT(string term)
		{
			var x = from c in db.RolesPersonaCivilRef
					select new RolesPersonaCivilRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Tipo = c.Tipo,
						 NotificaAutoAudiencia = c.NotificaAutoAudiencia,
					};
			return (DbQuery<RolesPersonaCivilRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
