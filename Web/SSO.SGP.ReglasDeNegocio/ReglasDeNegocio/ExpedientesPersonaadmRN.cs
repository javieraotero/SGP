
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
	public partial class ExpedientesPersonaadmRN
	{
		ExpedientesPersonaadmAD oExpedientesPersonaadmAD = new ExpedientesPersonaadmAD();

		public ExpedientesPersonaadm ObtenerPorId(int Id)
		{
			return this.oExpedientesPersonaadmAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesPersonaadm> ObtenerTodo()
		{
			return this.oExpedientesPersonaadmAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesPersonaadmView> ObtenerParaGrilla()
		{
			return this.oExpedientesPersonaadmAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesPersonaadmAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesPersonaadm Objeto)
		{
			try
			{
			this.oExpedientesPersonaadmAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPersonaadm Objeto)
		{
			try
			{
			this.oExpedientesPersonaadmAD.Actualizar(Objeto);
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
			this.oExpedientesPersonaadmAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesPersonaadmAD.Dispose();
		}
		public DbQuery<ExpedientesPersonaadmViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesPersonaadmViewT>)this.oExpedientesPersonaadmAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
