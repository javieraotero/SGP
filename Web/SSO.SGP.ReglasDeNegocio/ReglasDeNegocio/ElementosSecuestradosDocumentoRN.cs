
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
	public partial class ElementosSecuestradosDocumentoRN
	{
		ElementosSecuestradosDocumentoAD oElementosSecuestradosDocumentoAD = new ElementosSecuestradosDocumentoAD();

		public ElementosSecuestradosDocumento ObtenerPorId(int Id)
		{
			return this.oElementosSecuestradosDocumentoAD.ObtenerPorId(Id);
		}

		public DbQuery<ElementosSecuestradosDocumento> ObtenerTodo()
		{
			return this.oElementosSecuestradosDocumentoAD.ObtenerTodo();
		}


		public DbQuery<ElementosSecuestradosDocumentoView> ObtenerParaGrilla()
		{
			return this.oElementosSecuestradosDocumentoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oElementosSecuestradosDocumentoAD.ObtenerOptions(filtro);
		}

		public void Guardar(ElementosSecuestradosDocumento Objeto)
		{
			try
			{
			this.oElementosSecuestradosDocumentoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ElementosSecuestradosDocumento Objeto)
		{
			try
			{
			this.oElementosSecuestradosDocumentoAD.Actualizar(Objeto);
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
			this.oElementosSecuestradosDocumentoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oElementosSecuestradosDocumentoAD.Dispose();
		}
		public DbQuery<ElementosSecuestradosDocumentoViewT> JsonT(string term)
		{
			return (DbQuery<ElementosSecuestradosDocumentoViewT>)this.oElementosSecuestradosDocumentoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
