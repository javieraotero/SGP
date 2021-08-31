
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
	public partial class ExpedientesDocumentoRN
	{
		ExpedientesDocumentoAD oExpedientesDocumentoAD = new ExpedientesDocumentoAD();

		public ExpedientesDocumento ObtenerPorId(int Id)
		{
			return this.oExpedientesDocumentoAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesDocumento> ObtenerTodo()
		{
			return this.oExpedientesDocumentoAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesDocumentoView> ObtenerParaGrilla()
		{
			return this.oExpedientesDocumentoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesDocumentoAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesDocumento Objeto)
		{
			try
			{
			this.oExpedientesDocumentoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesDocumento Objeto)
		{
			try
			{
			this.oExpedientesDocumentoAD.Actualizar(Objeto);
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
			this.oExpedientesDocumentoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesDocumentoAD.Dispose();
		}
		public DbQuery<ExpedientesDocumentoViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesDocumentoViewT>)this.oExpedientesDocumentoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
