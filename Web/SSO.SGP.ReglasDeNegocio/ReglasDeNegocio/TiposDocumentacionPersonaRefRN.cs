
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
	public partial class TiposDocumentacionPersonaRefRN
	{
		TiposDocumentacionPersonaRefAD oTiposDocumentacionPersonaRefAD = new TiposDocumentacionPersonaRefAD();

		public TiposDocumentacionPersonaRef ObtenerPorId(int Id)
		{
			return this.oTiposDocumentacionPersonaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposDocumentacionPersonaRef> ObtenerTodo()
		{
			return this.oTiposDocumentacionPersonaRefAD.ObtenerTodo();
		}


		public DbQuery<TiposDocumentacionPersonaRefView> ObtenerParaGrilla()
		{
			return this.oTiposDocumentacionPersonaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposDocumentacionPersonaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposDocumentacionPersonaRef Objeto)
		{
			try
			{
			this.oTiposDocumentacionPersonaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposDocumentacionPersonaRef Objeto)
		{
			try
			{
			this.oTiposDocumentacionPersonaRefAD.Actualizar(Objeto);
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
			this.oTiposDocumentacionPersonaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposDocumentacionPersonaRefAD.Dispose();
		}
		public DbQuery<TiposDocumentacionPersonaRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposDocumentacionPersonaRefViewT>)this.oTiposDocumentacionPersonaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
