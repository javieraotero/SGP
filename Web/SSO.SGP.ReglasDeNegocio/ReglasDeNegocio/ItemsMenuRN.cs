
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;


namespace SSO.SGP.ReglasDeNegocio
{
	/// <summary>
	/// Reglas De Negocio Generada por el Generador de codigo.
	/// </summary>
	public partial class ItemsMenuRN
	{
		ItemsMenuAD oItemsMenuAD = new ItemsMenuAD();

		public ItemsMenu ObtenerPorId(int Id)
		{
			return this.oItemsMenuAD.ObtenerPorId(Id);
		}

		public DbQuery<ItemsMenu> ObtenerTodo()
		{
			return this.oItemsMenuAD.ObtenerTodo();
		}


		public DbQuery<ItemsMenuView> ObtenerParaGrilla()
		{
			return this.oItemsMenuAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oItemsMenuAD.ObtenerOptions(filtro);
		}

		public void Guardar(ItemsMenu Objeto)
		{
			try
			{
			this.oItemsMenuAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ItemsMenu Objeto)
		{
			try
			{
			this.oItemsMenuAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
			this.oItemsMenuAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oItemsMenuAD.Dispose();
		}
		public DbQuery<ItemsMenuViewT> JsonT(string term)
		{
			return (DbQuery<ItemsMenuViewT>)this.oItemsMenuAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
