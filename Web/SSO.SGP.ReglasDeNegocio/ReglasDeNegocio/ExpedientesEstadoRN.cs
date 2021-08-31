
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
	public partial class ExpedientesEstadoRN
	{
		ExpedientesEstadoAD oExpedientesEstadoAD = new ExpedientesEstadoAD();

		public ExpedientesEstado ObtenerPorId(int Id)
		{
			return this.oExpedientesEstadoAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesEstado> ObtenerTodo()
		{
			return this.oExpedientesEstadoAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesEstadoView> ObtenerParaGrilla()
		{
			return this.oExpedientesEstadoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesEstadoAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesEstado Objeto)
		{
			try
			{
			this.oExpedientesEstadoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesEstado Objeto)
		{
			try
			{
			this.oExpedientesEstadoAD.Actualizar(Objeto);
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
			this.oExpedientesEstadoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesEstadoAD.Dispose();
		}
		public DbQuery<ExpedientesEstadoViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesEstadoViewT>)this.oExpedientesEstadoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
