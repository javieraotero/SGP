
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
	public partial class EstadosArchivoExpedienteRefRN
	{
		EstadosArchivoExpedienteRefAD oEstadosArchivoExpedienteRefAD = new EstadosArchivoExpedienteRefAD();

		public EstadosArchivoExpedienteRef ObtenerPorId(int Id)
		{
			return this.oEstadosArchivoExpedienteRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosArchivoExpedienteRef> ObtenerTodo()
		{
			return this.oEstadosArchivoExpedienteRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosArchivoExpedienteRefView> ObtenerParaGrilla()
		{
			return this.oEstadosArchivoExpedienteRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosArchivoExpedienteRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosArchivoExpedienteRef Objeto)
		{
			try
			{
			this.oEstadosArchivoExpedienteRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosArchivoExpedienteRef Objeto)
		{
			try
			{
			this.oEstadosArchivoExpedienteRefAD.Actualizar(Objeto);
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
			this.oEstadosArchivoExpedienteRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosArchivoExpedienteRefAD.Dispose();
		}
		public DbQuery<EstadosArchivoExpedienteRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosArchivoExpedienteRefViewT>)this.oEstadosArchivoExpedienteRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
