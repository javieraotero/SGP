
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
	public partial class ItemsMenuGruposUsuarioRelAD
	{
		private BDEntities db = new BDEntities();

		public ItemsMenuGruposUsuarioRel ObtenerPorId(int Id)
		{
			return db.ItemsMenuGruposUsuarioRel.Single(c => c.Id == Id);
		}

		public DbQuery<ItemsMenuGruposUsuarioRel> ObtenerTodo()
		{
			return (DbQuery<ItemsMenuGruposUsuarioRel>)db.ItemsMenuGruposUsuarioRel;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ItemsMenuGruposUsuarioRel
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ItemsMenuGruposUsuarioRelView> ObtenerParaGrilla()
		{
			var x = from c in db.ItemsMenuGruposUsuarioRel
					select new ItemsMenuGruposUsuarioRelView
					{
						 ItemMenu = c.ItemMenu,
						 GrupoUsuario = c.GrupoUsuario,
					};
			return (DbQuery<ItemsMenuGruposUsuarioRelView>)x;
		}

		public void Guardar(ItemsMenuGruposUsuarioRel Objeto)
		{
			try
			{
				db.ItemsMenuGruposUsuarioRel.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ItemsMenuGruposUsuarioRel Objeto)
		{
			try
			{
				db.ItemsMenuGruposUsuarioRel.Attach(Objeto);
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
				ItemsMenuGruposUsuarioRel Objeto = this.ObtenerPorId(IdObjeto);
				db.ItemsMenuGruposUsuarioRel.Remove(Objeto);
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

		public DbQuery<ItemsMenuGruposUsuarioRelViewT> JsonT(string term)
		{
			var x = from c in db.ItemsMenuGruposUsuarioRel
					select new ItemsMenuGruposUsuarioRelViewT
					{
						 ItemMenu = c.ItemMenu,
						 GrupoUsuario = c.GrupoUsuario,
					};
			return (DbQuery<ItemsMenuGruposUsuarioRelViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
