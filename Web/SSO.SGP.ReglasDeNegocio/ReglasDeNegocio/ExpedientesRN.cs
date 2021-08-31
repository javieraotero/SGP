
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
	public partial class ExpedientesRN
	{
		ExpedientesAD oExpedientesAD = new ExpedientesAD();

		public Expedientes ObtenerPorId(int Id)
		{
			return this.oExpedientesAD.ObtenerPorId(Id);
		}

		public DbQuery<Expedientes> ObtenerTodo()
		{
			return this.oExpedientesAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesView> ObtenerParaGrilla()
		{
			return this.oExpedientesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesAD.ObtenerOptions(filtro);
		}

		public void Guardar(Expedientes Objeto)
		{
			try
			{
			this.oExpedientesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Expedientes Objeto)
		{
			try
			{
			this.oExpedientesAD.Actualizar(Objeto);
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
			this.oExpedientesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesAD.Dispose();
		}
		public DbQuery<ExpedientesViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesViewT>)this.oExpedientesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
