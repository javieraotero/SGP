
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
	public partial class RolesPersonaRefAD
	{
		private BDEntities db = new BDEntities();

		public RolesPersonaRef ObtenerPorId(int Id)
		{
			return db.RolesPersonaRef.Single(c => c.Id == Id);
		}

		public DbQuery<RolesPersonaRef> ObtenerTodo()
		{
			return (DbQuery<RolesPersonaRef>)db.RolesPersonaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.RolesPersonaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<RolesPersonaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.RolesPersonaRef
					select new RolesPersonaRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Funcionario = c.Funcionario,
						 NotificaAutoAudiencia = c.NotificaAutoAudiencia,
						 EsUsuarioSistema = c.EsUsuarioSistema,
					};
			return (DbQuery<RolesPersonaRefView>)x;
		}

		public void Guardar(RolesPersonaRef Objeto)
		{
			try
			{
				db.RolesPersonaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(RolesPersonaRef Objeto)
		{
			try
			{
				db.RolesPersonaRef.Attach(Objeto);
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
				RolesPersonaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.RolesPersonaRef.Remove(Objeto);
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

		public DbQuery<RolesPersonaRefViewT> JsonT(string term)
		{
			var x = from c in db.RolesPersonaRef
					select new RolesPersonaRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Funcionario = c.Funcionario,
						 NotificaAutoAudiencia = c.NotificaAutoAudiencia,
						 EsUsuarioSistema = c.EsUsuarioSistema,
					};
			return (DbQuery<RolesPersonaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
