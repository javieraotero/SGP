
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
	public partial class ExpedientesPersonaRN
	{
		ExpedientesPersonaAD oExpedientesPersonaAD = new ExpedientesPersonaAD();

		public ExpedientesPersona ObtenerPorId(int Id)
		{
			return this.oExpedientesPersonaAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesPersona> ObtenerTodo()
		{
			return this.oExpedientesPersonaAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesPersonaView> ObtenerParaGrilla()
		{
			return this.oExpedientesPersonaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesPersonaAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesPersona Objeto)
		{
			try
			{
			this.oExpedientesPersonaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPersona Objeto)
		{
			try
			{
			this.oExpedientesPersonaAD.Actualizar(Objeto);
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
			this.oExpedientesPersonaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesPersonaAD.Dispose();
		}
		public DbQuery<ExpedientesPersonaViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesPersonaViewT>)this.oExpedientesPersonaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
