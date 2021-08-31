
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
	public partial class TiposModeloEscritoRefRN
	{
		TiposModeloEscritoRefAD oTiposModeloEscritoRefAD = new TiposModeloEscritoRefAD();

		public TiposModeloEscritoRef ObtenerPorId(int Id)
		{
			return this.oTiposModeloEscritoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposModeloEscritoRef> ObtenerTodo()
		{
			return this.oTiposModeloEscritoRefAD.ObtenerTodo();
		}


		public DbQuery<TiposModeloEscritoRefView> ObtenerParaGrilla()
		{
			return this.oTiposModeloEscritoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposModeloEscritoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposModeloEscritoRef Objeto)
		{
			try
			{
			this.oTiposModeloEscritoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposModeloEscritoRef Objeto)
		{
			try
			{
			this.oTiposModeloEscritoRefAD.Actualizar(Objeto);
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
			this.oTiposModeloEscritoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposModeloEscritoRefAD.Dispose();
		}
		public DbQuery<TiposModeloEscritoRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposModeloEscritoRefViewT>)this.oTiposModeloEscritoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
