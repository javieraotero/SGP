
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
	public partial class ExpedientesCategoriasRelRN
	{
		ExpedientesCategoriasRelAD oExpedientesCategoriasRelAD = new ExpedientesCategoriasRelAD();

		public ExpedientesCategoriasRel ObtenerPorId(int Id)
		{
			return this.oExpedientesCategoriasRelAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesCategoriasRel> ObtenerTodo()
		{
			return this.oExpedientesCategoriasRelAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesCategoriasRelView> ObtenerParaGrilla()
		{
			return this.oExpedientesCategoriasRelAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesCategoriasRelAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesCategoriasRel Objeto)
		{
			try
			{
			this.oExpedientesCategoriasRelAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesCategoriasRel Objeto)
		{
			try
			{
			this.oExpedientesCategoriasRelAD.Actualizar(Objeto);
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
			this.oExpedientesCategoriasRelAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesCategoriasRelAD.Dispose();
		}
		public DbQuery<ExpedientesCategoriasRelViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesCategoriasRelViewT>)this.oExpedientesCategoriasRelAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
