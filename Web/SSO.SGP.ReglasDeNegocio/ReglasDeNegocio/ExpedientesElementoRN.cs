
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
	public partial class ExpedientesElementoRN
	{
		ExpedientesElementoAD oExpedientesElementoAD = new ExpedientesElementoAD();

		public ExpedientesElemento ObtenerPorId(int Id)
		{
			return this.oExpedientesElementoAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesElemento> ObtenerTodo()
		{
			return this.oExpedientesElementoAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesElementoView> ObtenerParaGrilla()
		{
			return this.oExpedientesElementoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesElementoAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesElemento Objeto)
		{
			try
			{
			this.oExpedientesElementoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesElemento Objeto)
		{
			try
			{
			this.oExpedientesElementoAD.Actualizar(Objeto);
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
			this.oExpedientesElementoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesElementoAD.Dispose();
		}
		public DbQuery<ExpedientesElementoViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesElementoViewT>)this.oExpedientesElementoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
