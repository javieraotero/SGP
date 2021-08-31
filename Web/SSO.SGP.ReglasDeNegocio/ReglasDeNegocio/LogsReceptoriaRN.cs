
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
	public partial class LogsReceptoriaRN
	{
		LogsReceptoriaAD oLogsReceptoriaAD = new LogsReceptoriaAD();

		public LogsReceptoria ObtenerPorId(int Id)
		{
			return this.oLogsReceptoriaAD.ObtenerPorId(Id);
		}

		public DbQuery<LogsReceptoria> ObtenerTodo()
		{
			return this.oLogsReceptoriaAD.ObtenerTodo();
		}


		public DbQuery<LogsReceptoriaView> ObtenerParaGrilla()
		{
			return this.oLogsReceptoriaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLogsReceptoriaAD.ObtenerOptions(filtro);
		}

		public void Guardar(LogsReceptoria Objeto)
		{
			try
			{
			this.oLogsReceptoriaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LogsReceptoria Objeto)
		{
			try
			{
			this.oLogsReceptoriaAD.Actualizar(Objeto);
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
			this.oLogsReceptoriaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLogsReceptoriaAD.Dispose();
		}
		public DbQuery<LogsReceptoriaViewT> JsonT(string term)
		{
			return (DbQuery<LogsReceptoriaViewT>)this.oLogsReceptoriaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
