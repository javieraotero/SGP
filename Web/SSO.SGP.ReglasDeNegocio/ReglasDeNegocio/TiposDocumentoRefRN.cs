
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
	public partial class TiposDocumentoRefRN
	{
		TiposDocumentoRefAD oTiposDocumentoRefAD = new TiposDocumentoRefAD();

		public TiposDocumentoRef ObtenerPorId(int Id)
		{
			return this.oTiposDocumentoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposDocumentoRef> ObtenerTodo()
		{
			return this.oTiposDocumentoRefAD.ObtenerTodo();
		}


		public DbQuery<TiposDocumentoRefView> ObtenerParaGrilla()
		{
			return this.oTiposDocumentoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposDocumentoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposDocumentoRef Objeto)
		{
			try
			{
			this.oTiposDocumentoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposDocumentoRef Objeto)
		{
			try
			{
			this.oTiposDocumentoRefAD.Actualizar(Objeto);
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
			this.oTiposDocumentoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposDocumentoRefAD.Dispose();
		}
		public DbQuery<TiposDocumentoRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposDocumentoRefViewT>)this.oTiposDocumentoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
