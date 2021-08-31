
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
	public partial class ExpedientesDocumentoadmRN
	{
		ExpedientesDocumentoadmAD oExpedientesDocumentoadmAD = new ExpedientesDocumentoadmAD();

		public ExpedientesDocumentoadm ObtenerPorId(int Id)
		{
			return this.oExpedientesDocumentoadmAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesDocumentoadm> ObtenerTodo()
		{
			return this.oExpedientesDocumentoadmAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesDocumentoadmView> ObtenerParaGrilla()
		{
			return this.oExpedientesDocumentoadmAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesDocumentoadmAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesDocumentoadm Objeto)
		{
			try
			{
			this.oExpedientesDocumentoadmAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesDocumentoadm Objeto)
		{
			try
			{
			this.oExpedientesDocumentoadmAD.Actualizar(Objeto);
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
			this.oExpedientesDocumentoadmAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesDocumentoadmAD.Dispose();
		}
		public DbQuery<ExpedientesDocumentoadmViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesDocumentoadmViewT>)this.oExpedientesDocumentoadmAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
