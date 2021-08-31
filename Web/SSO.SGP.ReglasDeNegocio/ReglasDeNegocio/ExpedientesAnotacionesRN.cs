
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
	public partial class ExpedientesAnotacionesRN
	{
		ExpedientesAnotacionesAD oExpedientesAnotacionesAD = new ExpedientesAnotacionesAD();

		public ExpedientesAnotaciones ObtenerPorId(int Id)
		{
			return this.oExpedientesAnotacionesAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesAnotaciones> ObtenerTodo()
		{
			return this.oExpedientesAnotacionesAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesAnotacionesView> ObtenerParaGrilla()
		{
			return this.oExpedientesAnotacionesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesAnotacionesAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesAnotaciones Objeto)
		{
			try
			{
			this.oExpedientesAnotacionesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesAnotaciones Objeto)
		{
			try
			{
			this.oExpedientesAnotacionesAD.Actualizar(Objeto);
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
			this.oExpedientesAnotacionesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesAnotacionesAD.Dispose();
		}
		public DbQuery<ExpedientesAnotacionesViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesAnotacionesViewT>)this.oExpedientesAnotacionesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
