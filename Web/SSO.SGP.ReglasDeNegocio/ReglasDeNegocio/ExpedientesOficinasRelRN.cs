
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
	public partial class ExpedientesOficinasRelRN
	{
		ExpedientesOficinasRelAD oExpedientesOficinasRelAD = new ExpedientesOficinasRelAD();

		public ExpedientesOficinasRel ObtenerPorId(int Id)
		{
			return this.oExpedientesOficinasRelAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesOficinasRel> ObtenerTodo()
		{
			return this.oExpedientesOficinasRelAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesOficinasRelView> ObtenerParaGrilla()
		{
			return this.oExpedientesOficinasRelAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesOficinasRelAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesOficinasRel Objeto)
		{
			try
			{
			this.oExpedientesOficinasRelAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesOficinasRel Objeto)
		{
			try
			{
			this.oExpedientesOficinasRelAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
			this.oExpedientesOficinasRelAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesOficinasRelAD.Dispose();
		}
		public DbQuery<ExpedientesOficinasRelViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesOficinasRelViewT>)this.oExpedientesOficinasRelAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
