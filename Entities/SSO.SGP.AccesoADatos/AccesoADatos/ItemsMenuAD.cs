
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
	public partial class ItemsMenuAD
	{
		private BDEntities db = new BDEntities();

		public ItemsMenu ObtenerPorId(int Id)
		{
			return db.ItemsMenu.Single(c => c.Id == Id);
		}

		public DbQuery<ItemsMenu> ObtenerTodo()
		{
			return (DbQuery<ItemsMenu>)db.ItemsMenu;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ItemsMenu
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ItemsMenuView> ObtenerParaGrilla()
		{
			var x = from c in db.ItemsMenu
					select new ItemsMenuView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 ItemPadre = c.ItemPadre,
						 Parametros = c.Parametros,
						 Imagen = c.Imagen,
						 Tooltip = c.Tooltip,
						 MostrarEnBarra = c.MostrarEnBarra,
						 Camino = c.Camino,
						 Orden = c.Orden,
						 Modulo = c.Modulo,
						 Formulario = c.Formulario,
					};
			return (DbQuery<ItemsMenuView>)x;
		}

		public void Guardar(ItemsMenu Objeto)
		{
			try
			{
				db.ItemsMenu.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ItemsMenu Objeto)
		{
			try
			{
				db.ItemsMenu.Attach(Objeto);
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
				ItemsMenu Objeto = this.ObtenerPorId(IdObjeto);
				db.ItemsMenu.Remove(Objeto);
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

		public DbQuery<ItemsMenuViewT> JsonT(string term)
		{
			var x = from c in db.ItemsMenu
					select new ItemsMenuViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 ItemPadre = c.ItemPadre,
						 Parametros = c.Parametros,
						 Imagen = c.Imagen,
						 Tooltip = c.Tooltip,
						 MostrarEnBarra = c.MostrarEnBarra,
						 Camino = c.Camino,
						 Orden = c.Orden,
						 Modulo = c.Modulo,
						 Formulario = c.Formulario,
					};
			return (DbQuery<ItemsMenuViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
