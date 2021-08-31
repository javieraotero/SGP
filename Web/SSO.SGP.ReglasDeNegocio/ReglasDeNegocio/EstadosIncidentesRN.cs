
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
	public partial class EstadosIncidentesRN
	{
		EstadosIncidentesAD oEstadosIncidentesAD = new EstadosIncidentesAD();

		public EstadosIncidentes ObtenerPorId(int Id)
		{
			return this.oEstadosIncidentesAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosIncidentes> ObtenerTodo()
		{
			return this.oEstadosIncidentesAD.ObtenerTodo();
		}


		public DbQuery<EstadosIncidentesView> ObtenerParaGrilla()
		{
			return this.oEstadosIncidentesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosIncidentesAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosIncidentes Objeto)
		{
			try
			{
			this.oEstadosIncidentesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosIncidentes Objeto)
		{
			try
			{
			this.oEstadosIncidentesAD.Actualizar(Objeto);
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
			this.oEstadosIncidentesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosIncidentesAD.Dispose();
		}
		public DbQuery<EstadosIncidentesViewT> JsonT(string term)
		{
			return (DbQuery<EstadosIncidentesViewT>)this.oEstadosIncidentesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
