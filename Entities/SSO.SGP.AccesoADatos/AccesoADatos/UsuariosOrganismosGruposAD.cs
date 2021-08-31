
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
	public partial class UsuariosOrganismosGruposAD
	{
		private BDEntities db = new BDEntities();

		public UsuariosOrganismosGrupos ObtenerPorId(int Id)
		{
			return db.UsuariosOrganismosGrupos.Single(c => c.Id == Id);
		}

		public DbQuery<UsuariosOrganismosGrupos> ObtenerTodo()
		{
			return (DbQuery<UsuariosOrganismosGrupos>)db.UsuariosOrganismosGrupos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.UsuariosOrganismosGrupos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<UsuariosOrganismosGruposView> ObtenerParaGrilla()
		{
			var x = from c in db.UsuariosOrganismosGrupos
					select new UsuariosOrganismosGruposView
					{
						 Id = c.Id,
						 Usuario = c.Usuario,
						 Organismo = c.Organismo,
						 GrupoUsuario = c.GrupoUsuario,
					};
			return (DbQuery<UsuariosOrganismosGruposView>)x;
		}

		public void Guardar(UsuariosOrganismosGrupos Objeto)
		{
			try
			{
				db.UsuariosOrganismosGrupos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UsuariosOrganismosGrupos Objeto)
		{
			try
			{
				db.UsuariosOrganismosGrupos.Attach(Objeto);
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
				UsuariosOrganismosGrupos Objeto = this.ObtenerPorId(IdObjeto);
				db.UsuariosOrganismosGrupos.Remove(Objeto);
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

		public DbQuery<UsuariosOrganismosGruposViewT> JsonT(string term)
		{
			var x = from c in db.UsuariosOrganismosGrupos
					select new UsuariosOrganismosGruposViewT
					{
						 Id = c.Id,
						 Usuario = c.Usuario,
						 Organismo = c.Organismo,
						 GrupoUsuario = c.GrupoUsuario,
					};
			return (DbQuery<UsuariosOrganismosGruposViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
