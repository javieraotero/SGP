
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
	public partial class ArchivoExpedienteRN
	{
		ArchivoExpedienteAD oArchivoExpedienteAD = new ArchivoExpedienteAD();

		public ArchivoExpediente ObtenerPorId(int Id)
		{
			return this.oArchivoExpedienteAD.ObtenerPorId(Id);
		}

		public DbQuery<ArchivoExpediente> ObtenerTodo()
		{
			return this.oArchivoExpedienteAD.ObtenerTodo();
		}


		public DbQuery<ArchivoExpedienteView> ObtenerParaGrilla()
		{
			return this.oArchivoExpedienteAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oArchivoExpedienteAD.ObtenerOptions(filtro);
		}

		public void Guardar(ArchivoExpediente Objeto)
		{
			try
			{
			this.oArchivoExpedienteAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArchivoExpediente Objeto)
		{
			try
			{
			this.oArchivoExpedienteAD.Actualizar(Objeto);
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
			this.oArchivoExpedienteAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oArchivoExpedienteAD.Dispose();
		}
		public DbQuery<ArchivoExpedienteViewT> JsonT(string term)
		{
			return (DbQuery<ArchivoExpedienteViewT>)this.oArchivoExpedienteAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
