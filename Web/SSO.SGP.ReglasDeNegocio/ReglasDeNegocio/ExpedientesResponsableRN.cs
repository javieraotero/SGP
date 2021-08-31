
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
	public partial class ExpedientesResponsableRN
	{
		ExpedientesResponsableAD oExpedientesResponsableAD = new ExpedientesResponsableAD();

		public ExpedientesResponsable ObtenerPorId(int Id)
		{
			return this.oExpedientesResponsableAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesResponsable> ObtenerTodo()
		{
			return this.oExpedientesResponsableAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesResponsableView> ObtenerParaGrilla()
		{
			return this.oExpedientesResponsableAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesResponsableAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesResponsable Objeto)
		{
			try
			{
			this.oExpedientesResponsableAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesResponsable Objeto)
		{
			try
			{
			this.oExpedientesResponsableAD.Actualizar(Objeto);
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
			this.oExpedientesResponsableAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesResponsableAD.Dispose();
		}
		public DbQuery<ExpedientesResponsableViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesResponsableViewT>)this.oExpedientesResponsableAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
