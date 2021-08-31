
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
	public partial class TiposEscolaridadRefRN
	{
		TiposEscolaridadRefAD oTiposEscolaridadRefAD = new TiposEscolaridadRefAD();

		public TiposEscolaridadRef ObtenerPorId(int Id)
		{
			return this.oTiposEscolaridadRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposEscolaridadRef> ObtenerTodo()
		{
			return this.oTiposEscolaridadRefAD.ObtenerTodo();
		}


		public DbQuery<TiposEscolaridadRefView> ObtenerParaGrilla()
		{
			return this.oTiposEscolaridadRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposEscolaridadRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposEscolaridadRef Objeto)
		{
			try
			{
			this.oTiposEscolaridadRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposEscolaridadRef Objeto)
		{
			try
			{
			this.oTiposEscolaridadRefAD.Actualizar(Objeto);
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
			this.oTiposEscolaridadRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposEscolaridadRefAD.Dispose();
		}
		public DbQuery<TiposEscolaridadRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposEscolaridadRefViewT>)this.oTiposEscolaridadRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
