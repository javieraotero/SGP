
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
	public partial class ExpedientesPersonaDetenidaRN
	{
		ExpedientesPersonaDetenidaAD oExpedientesPersonaDetenidaAD = new ExpedientesPersonaDetenidaAD();

		public ExpedientesPersonaDetenida ObtenerPorId(int Id)
		{
			return this.oExpedientesPersonaDetenidaAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesPersonaDetenida> ObtenerTodo()
		{
			return this.oExpedientesPersonaDetenidaAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesPersonaDetenidaView> ObtenerParaGrilla()
		{
			return this.oExpedientesPersonaDetenidaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesPersonaDetenidaAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesPersonaDetenida Objeto)
		{
			try
			{
			this.oExpedientesPersonaDetenidaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPersonaDetenida Objeto)
		{
			try
			{
			this.oExpedientesPersonaDetenidaAD.Actualizar(Objeto);
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
			this.oExpedientesPersonaDetenidaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesPersonaDetenidaAD.Dispose();
		}
		public DbQuery<ExpedientesPersonaDetenidaViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesPersonaDetenidaViewT>)this.oExpedientesPersonaDetenidaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
