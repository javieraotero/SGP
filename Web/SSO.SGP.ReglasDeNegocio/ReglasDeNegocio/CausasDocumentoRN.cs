
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
	public partial class CausasDocumentoRN
	{
		CausasDocumentoAD oCausasDocumentoAD = new CausasDocumentoAD();

		public CausasDocumento ObtenerPorId(int Id)
		{
			return this.oCausasDocumentoAD.ObtenerPorId(Id);
		}

		public DbQuery<CausasDocumento> ObtenerTodo()
		{
			return this.oCausasDocumentoAD.ObtenerTodo();
		}


		public DbQuery<CausasDocumentoView> ObtenerParaGrilla()
		{
			return this.oCausasDocumentoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCausasDocumentoAD.ObtenerOptions(filtro);
		}

		public void Guardar(CausasDocumento Objeto)
		{
			try
			{
			this.oCausasDocumentoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasDocumento Objeto)
		{
			try
			{
			this.oCausasDocumentoAD.Actualizar(Objeto);
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
			this.oCausasDocumentoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCausasDocumentoAD.Dispose();
		}
		public DbQuery<CausasDocumentoViewT> JsonT(string term)
		{
			return (DbQuery<CausasDocumentoViewT>)this.oCausasDocumentoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
