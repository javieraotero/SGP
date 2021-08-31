
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
	public partial class ReportesRN
	{
		ReportesAD oReportesAD = new ReportesAD();

		public Reportes ObtenerPorId(int Id)
		{
			return this.oReportesAD.ObtenerPorId(Id);
		}

		public DbQuery<Reportes> ObtenerTodo()
		{
			return this.oReportesAD.ObtenerTodo();
		}


		public DbQuery<ReportesView> ObtenerParaGrilla()
		{
			return this.oReportesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oReportesAD.ObtenerOptions(filtro);
		}

		public void Guardar(Reportes Objeto)
		{
			try
			{
			this.oReportesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Reportes Objeto)
		{
			try
			{
			this.oReportesAD.Actualizar(Objeto);
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
			this.oReportesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oReportesAD.Dispose();
		}
		public DbQuery<ReportesViewT> JsonT(string term)
		{
			return (DbQuery<ReportesViewT>)this.oReportesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
