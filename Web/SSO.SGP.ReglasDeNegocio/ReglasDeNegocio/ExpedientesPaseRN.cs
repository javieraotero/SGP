
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
	public partial class ExpedientesPaseRN
	{
		ExpedientesPaseAD oExpedientesPaseAD = new ExpedientesPaseAD();

		public ExpedientesPase ObtenerPorId(int Id)
		{
			return this.oExpedientesPaseAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesPase> ObtenerTodo()
		{
			return this.oExpedientesPaseAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesPaseView> ObtenerParaGrilla()
		{
			return this.oExpedientesPaseAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesPaseAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesPase Objeto)
		{
			try
			{
			this.oExpedientesPaseAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPase Objeto)
		{
			try
			{
			this.oExpedientesPaseAD.Actualizar(Objeto);
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
			this.oExpedientesPaseAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesPaseAD.Dispose();
		}
		public DbQuery<ExpedientesPaseViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesPaseViewT>)this.oExpedientesPaseAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
