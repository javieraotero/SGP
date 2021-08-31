
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
	public partial class ExpedientesPaseadmRN
	{
		ExpedientesPaseadmAD oExpedientesPaseadmAD = new ExpedientesPaseadmAD();

		public ExpedientesPaseadm ObtenerPorId(int Id)
		{
			return this.oExpedientesPaseadmAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesPaseadm> ObtenerTodo()
		{
			return this.oExpedientesPaseadmAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesPaseadmView> ObtenerParaGrilla()
		{
			return this.oExpedientesPaseadmAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesPaseadmAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesPaseadm Objeto)
		{
			try
			{
			this.oExpedientesPaseadmAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPaseadm Objeto)
		{
			try
			{
			this.oExpedientesPaseadmAD.Actualizar(Objeto);
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
			this.oExpedientesPaseadmAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesPaseadmAD.Dispose();
		}
		public DbQuery<ExpedientesPaseadmViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesPaseadmViewT>)this.oExpedientesPaseadmAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
