
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
	public partial class ItemsMenuGruposUsuarioRelRN
	{
		ItemsMenuGruposUsuarioRelAD oItemsMenuGruposUsuarioRelAD = new ItemsMenuGruposUsuarioRelAD();

		public ItemsMenuGruposUsuarioRel ObtenerPorId(int Id)
		{
			return this.oItemsMenuGruposUsuarioRelAD.ObtenerPorId(Id);
		}

		public DbQuery<ItemsMenuGruposUsuarioRel> ObtenerTodo()
		{
			return this.oItemsMenuGruposUsuarioRelAD.ObtenerTodo();
		}


		public DbQuery<ItemsMenuGruposUsuarioRelView> ObtenerParaGrilla()
		{
			return this.oItemsMenuGruposUsuarioRelAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oItemsMenuGruposUsuarioRelAD.ObtenerOptions(filtro);
		}

		public void Guardar(ItemsMenuGruposUsuarioRel Objeto)
		{
			try
			{
			this.oItemsMenuGruposUsuarioRelAD.Guardar(Objeto);
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
			this.oItemsMenuGruposUsuarioRelAD.Actualizar(Objeto);
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
			this.oItemsMenuGruposUsuarioRelAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oItemsMenuGruposUsuarioRelAD.Dispose();
		}
		public DbQuery<ItemsMenuGruposUsuarioRelViewT> JsonT(string term)
		{
			return (DbQuery<ItemsMenuGruposUsuarioRelViewT>)this.oItemsMenuGruposUsuarioRelAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
