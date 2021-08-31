
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
	public partial class ReportesParametrosRN
	{
		ReportesParametrosAD oReportesParametrosAD = new ReportesParametrosAD();

		public ReportesParametros ObtenerPorId(int Id)
		{
			return this.oReportesParametrosAD.ObtenerPorId(Id);
		}

		public DbQuery<ReportesParametros> ObtenerTodo()
		{
			return this.oReportesParametrosAD.ObtenerTodo();
		}


		public DbQuery<ReportesParametrosView> ObtenerParaGrilla()
		{
			return this.oReportesParametrosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oReportesParametrosAD.ObtenerOptions(filtro);
		}

		public void Guardar(ReportesParametros Objeto)
		{
			try
			{
			this.oReportesParametrosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ReportesParametros Objeto)
		{
			try
			{
			this.oReportesParametrosAD.Actualizar(Objeto);
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
			this.oReportesParametrosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oReportesParametrosAD.Dispose();
		}
		public DbQuery<ReportesParametrosViewT> JsonT(string term)
		{
			return (DbQuery<ReportesParametrosViewT>)this.oReportesParametrosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
