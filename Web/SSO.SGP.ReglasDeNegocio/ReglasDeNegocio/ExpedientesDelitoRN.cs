
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
	public partial class ExpedientesDelitoRN
	{
		ExpedientesDelitoAD oExpedientesDelitoAD = new ExpedientesDelitoAD();

		public ExpedientesDelito ObtenerPorId(int Id)
		{
			return this.oExpedientesDelitoAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesDelito> ObtenerTodo()
		{
			return this.oExpedientesDelitoAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesDelitoView> ObtenerParaGrilla()
		{
			return this.oExpedientesDelitoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesDelitoAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesDelito Objeto)
		{
			try
			{
			this.oExpedientesDelitoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesDelito Objeto)
		{
			try
			{
			this.oExpedientesDelitoAD.Actualizar(Objeto);
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
			this.oExpedientesDelitoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesDelitoAD.Dispose();
		}
		public DbQuery<ExpedientesDelitoViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesDelitoViewT>)this.oExpedientesDelitoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
