
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
	public partial class RolesPersonaadmRefAD
	{
		private BDEntities db = new BDEntities();

		public RolesPersonaadmRef ObtenerPorId(int Id)
		{
			return db.RolesPersonaadmRef.Single(c => c.Id == Id);
		}

		public DbQuery<RolesPersonaadmRef> ObtenerTodo()
		{
			return (DbQuery<RolesPersonaadmRef>)db.RolesPersonaadmRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.RolesPersonaadmRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<RolesPersonaadmRefView> ObtenerParaGrilla()
		{
			var x = from c in db.RolesPersonaadmRef
					select new RolesPersonaadmRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Funcionario = c.Funcionario,
						 EsUsuarioSistema = c.EsUsuarioSistema,
					};
			return (DbQuery<RolesPersonaadmRefView>)x;
		}

		public void Guardar(RolesPersonaadmRef Objeto)
		{
			try
			{
				db.RolesPersonaadmRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(RolesPersonaadmRef Objeto)
		{
			try
			{
				db.RolesPersonaadmRef.Attach(Objeto);
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
				RolesPersonaadmRef Objeto = this.ObtenerPorId(IdObjeto);
				db.RolesPersonaadmRef.Remove(Objeto);
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

		public DbQuery<RolesPersonaadmRefViewT> JsonT(string term)
		{
			var x = from c in db.RolesPersonaadmRef
					select new RolesPersonaadmRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Funcionario = c.Funcionario,
						 EsUsuarioSistema = c.EsUsuarioSistema,
					};
			return (DbQuery<RolesPersonaadmRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
