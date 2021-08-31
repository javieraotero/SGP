
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
	public partial class PermisosGruposUsuarioRelAD
	{
		private BDEntities db = new BDEntities();

		public PermisosGruposUsuarioRel ObtenerPorId(int Id)
		{
			return db.PermisosGruposUsuarioRel.Single(c => c.Id == Id);
		}

		public DbQuery<PermisosGruposUsuarioRel> ObtenerTodo()
		{
			return (DbQuery<PermisosGruposUsuarioRel>)db.PermisosGruposUsuarioRel;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PermisosGruposUsuarioRel
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PermisosGruposUsuarioRelView> ObtenerParaGrilla()
		{
			var x = from c in db.PermisosGruposUsuarioRel
					select new PermisosGruposUsuarioRelView
					{
						 Permiso = c.Permiso,
						 GrupoUsuario = c.GrupoUsuario,
					};
			return (DbQuery<PermisosGruposUsuarioRelView>)x;
		}

		public void Guardar(PermisosGruposUsuarioRel Objeto)
		{
			try
			{
				db.PermisosGruposUsuarioRel.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PermisosGruposUsuarioRel Objeto)
		{
			try
			{
				db.PermisosGruposUsuarioRel.Attach(Objeto);
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
				PermisosGruposUsuarioRel Objeto = this.ObtenerPorId(IdObjeto);
				db.PermisosGruposUsuarioRel.Remove(Objeto);
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

		public DbQuery<PermisosGruposUsuarioRelViewT> JsonT(string term)
		{
			var x = from c in db.PermisosGruposUsuarioRel
					select new PermisosGruposUsuarioRelViewT
					{
						 Permiso = c.Permiso,
						 GrupoUsuario = c.GrupoUsuario,
					};
			return (DbQuery<PermisosGruposUsuarioRelViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
