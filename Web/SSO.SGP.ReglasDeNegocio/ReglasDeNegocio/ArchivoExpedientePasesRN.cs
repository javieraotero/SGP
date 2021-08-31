
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
	public partial class ArchivoExpedientePasesRN
	{
		ArchivoExpedientePasesAD oArchivoExpedientePasesAD = new ArchivoExpedientePasesAD();

		public ArchivoExpedientePases ObtenerPorId(int Id)
		{
			return this.oArchivoExpedientePasesAD.ObtenerPorId(Id);
		}

		public DbQuery<ArchivoExpedientePases> ObtenerTodo()
		{
			return this.oArchivoExpedientePasesAD.ObtenerTodo();
		}


		public DbQuery<ArchivoExpedientePasesView> ObtenerParaGrilla()
		{
			return this.oArchivoExpedientePasesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oArchivoExpedientePasesAD.ObtenerOptions(filtro);
		}

		public void Guardar(ArchivoExpedientePases Objeto)
		{
			try
			{
			this.oArchivoExpedientePasesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArchivoExpedientePases Objeto)
		{
			try
			{
			this.oArchivoExpedientePasesAD.Actualizar(Objeto);
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
			this.oArchivoExpedientePasesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oArchivoExpedientePasesAD.Dispose();
		}
		public DbQuery<ArchivoExpedientePasesViewT> JsonT(string term)
		{
			return (DbQuery<ArchivoExpedientePasesViewT>)this.oArchivoExpedientePasesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
