
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
	public partial class ExpedientesSumariantesRelRN
	{
		ExpedientesSumariantesRelAD oExpedientesSumariantesRelAD = new ExpedientesSumariantesRelAD();

		public ExpedientesSumariantesRel ObtenerPorId(int Id)
		{
			return this.oExpedientesSumariantesRelAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesSumariantesRel> ObtenerTodo()
		{
			return this.oExpedientesSumariantesRelAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesSumariantesRelView> ObtenerParaGrilla()
		{
			return this.oExpedientesSumariantesRelAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesSumariantesRelAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesSumariantesRel Objeto)
		{
			try
			{
			this.oExpedientesSumariantesRelAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesSumariantesRel Objeto)
		{
			try
			{
			this.oExpedientesSumariantesRelAD.Actualizar(Objeto);
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
			this.oExpedientesSumariantesRelAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesSumariantesRelAD.Dispose();
		}
		public DbQuery<ExpedientesSumariantesRelViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesSumariantesRelViewT>)this.oExpedientesSumariantesRelAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
