
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
	public partial class ExpedientesAccesosRN
	{
		ExpedientesAccesosAD oExpedientesAccesosAD = new ExpedientesAccesosAD();

		public ExpedientesAccesos ObtenerPorId(int Id)
		{
			return this.oExpedientesAccesosAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesAccesos> ObtenerTodo()
		{
			return this.oExpedientesAccesosAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesAccesosView> ObtenerParaGrilla()
		{
			return this.oExpedientesAccesosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesAccesosAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesAccesos Objeto)
		{
			try
			{
			this.oExpedientesAccesosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesAccesos Objeto)
		{
			try
			{
			this.oExpedientesAccesosAD.Actualizar(Objeto);
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
			this.oExpedientesAccesosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesAccesosAD.Dispose();
		}
		public DbQuery<ExpedientesAccesosViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesAccesosViewT>)this.oExpedientesAccesosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
